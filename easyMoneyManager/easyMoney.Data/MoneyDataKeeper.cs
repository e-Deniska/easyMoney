using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using easyMoney.Utilities;

namespace easyMoney.Data
{
    public class MoneyDataKeeper
    {

        #region Class members

        private MoneyDataSet ds;
        private MoneyDataSet dsTmp;
        private String validationErrors = String.Empty;
        private String filename = String.Empty;
        private String password = String.Empty;
        private String dataFilename = String.Empty;
        private bool saveAllowed = false;

        #endregion

        #region Singleton implementation

        private static readonly Lazy<MoneyDataKeeper> instance = new Lazy<MoneyDataKeeper>(() => new MoneyDataKeeper());

        public static MoneyDataKeeper Instance
        {
            get { return instance.Value; }
        }

        #endregion

        #region Class properties

        public MoneyDataSet DataSet
        {
            get { return ds; }
        }

        public String Filename
        {
            get { return dataFilename; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    filename = value;
                }
                else
                {
                    filename = String.Empty;
                }
            }
        }

        public String Password
        {
            get { return password; }

            set
            {
                if (value != null)
                {
                    password = value;
                }
                else
                {
                    password = String.Empty;
                }
            }
        }

        #endregion

        #region Init/load/save utilities

        protected MoneyDataKeeper()
        {
            ds = new MoneyDataSet();
            dsTmp = null;
        }

        public bool FilePreLoad()
        {
            // loading file to dsTmp, only basic checks are done
            try
            {
                if (String.IsNullOrWhiteSpace(filename))
                {
                    // looking up command line (first parameter is a datafile name)
                    String[] commandLine = Environment.GetCommandLineArgs();
                    if (commandLine.Count() > 1)
                    {
                        dataFilename = commandLine[1];
                    }
                    else
                    {
                        String folderName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar +
                            Consts.Application.ProfileFolder;

                        // looking up for default data files
                        dataFilename = folderName + Path.DirectorySeparatorChar + Consts.Application.DefaultFileName;

                        if (!File.Exists(dataFilename))
                        {
                            dataFilename = folderName + Path.DirectorySeparatorChar + Consts.Application.XmlDataFileName;
                        }

                        String backupFileName = folderName + Path.DirectorySeparatorChar + String.Format(Consts.Application.BackupFileNameFormat, DateTime.Now);
                        
                        // backup current file
                        if ((File.Exists(dataFilename)) && (!File.Exists(backupFileName)))
                        {
                            File.Copy(dataFilename, backupFileName);
                        }

                        // remove archives that are too old
                        foreach (String fileName in Directory.EnumerateFiles(folderName, Consts.Application.BackupFileSearchPattern))
                        {
                            if (File.GetLastWriteTime(fileName).AddDays(Parameters.KeepArchivesDays) < DateTime.Now)
                            {
                                File.Delete(fileName);
                            }
                        }
                    }
                }
                else
                {
                    dataFilename = filename;
                }

                dsTmp = new MoneyDataSet();
                
                if (File.Exists(dataFilename))
                {
                    dsTmp.ReadXml(dataFilename);
                }

                return true;
            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(ErrorHelper.Errors.ErrorReadingData, e);
                return false;
            }
        }

        public bool FileIsEncrypted()
        {
            if (dsTmp != null)
            {
                if (dsTmp.Setup.Count == 1)
                {
                    return (!String.IsNullOrWhiteSpace(dsTmp.Setup[0].EncryptedData));
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool FileTryDecrypt()
        {
            if (dsTmp != null)
            {
                try
                {
                    EncryptionHelper.Instance.Password = this.Password;
                    StringReader reader = new StringReader(EncryptionHelper.Instance.Decrypt(dsTmp.Setup[0].EncryptedData));

                    MoneyDataSet dsTry = new MoneyDataSet();
                    dsTry.ReadXml(reader);
                    dsTmp = dsTry;
                    return true;
                }
                catch (CryptographicException ce)
                {
                    Log.Write(ce);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void FileCancel()
        {
            // cancel loading process
            dsTmp = null;
        }

        public void FileActivate()
        {
            // process with data checks, dictionary update and activate loaded file 
            ds = dsTmp;
            dsTmp = null;
            fillDictionaries();
            schemaCheck();
            schemaCleanup();
            saveAllowed = true;
        }

        public void FileSave()
        {
            try
            {
                if (!saveAllowed)
                {
                    return;
                }

                //String dataFilename;
                if (String.IsNullOrWhiteSpace(filename))
                {
                    // looking up command line (first parameter is a datafile name)
                    String[] commandLine = Environment.GetCommandLineArgs();
                    if (commandLine.Count() > 1)
                    {
                        dataFilename = commandLine[1];
                    }
                    else
                    {
                        String fileFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar +
                            Consts.Application.ProfileFolder;

                        if (!Directory.Exists(fileFolder))
                        {
                            Directory.CreateDirectory(fileFolder);
                        }

                        // looking up for default data files
                        dataFilename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar +
                            Consts.Application.ProfileFolder + Path.DirectorySeparatorChar + Consts.Application.DefaultFileName;
                    }
                }
                else
                {
                    dataFilename = filename;
                }

                if (String.IsNullOrEmpty(this.Password))
                {
                    ds.WriteXml(dataFilename);
                }
                else
                {
                    MoneyDataSet encryptedSet = new MoneyDataSet();
                    MoneyDataSet.SetupRow setup = encryptedSet.Setup.NewSetupRow();
                    setup.ApplicationVersion = Consts.Application.Version;
                    setup.SchemaVersion = Consts.Application.SchemaVersion;
                    StringWriter writer = new StringWriter();
                    ds.WriteXml(writer);
                    writer.Flush();
                    EncryptionHelper.Instance.Password = this.Password;
                    setup.EncryptedData = EncryptionHelper.Instance.Encrypt(writer.ToString());
                    encryptedSet.Setup.AddSetupRow(setup);
                    encryptedSet.WriteXml(dataFilename);
                }
            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(ErrorHelper.Errors.ErrorSavingData, e);
            }
        }

        private void schemaCleanup()
        {
            int ticksStart = Environment.TickCount;
            
            // removing soft-deleted transactions

            int transactions = clearTransactionHistory();

            if (ds.Setup.Count > 1)
            {
                // too many, removing all entries
                ds.Setup.Clear();
            }

            MoneyDataSet.SetupRow setup = null;
            if (ds.Setup.Any())
            {
                setup = ds.Setup.SingleOrDefault();
            }
            else
            {
                setup = ds.Setup.NewSetupRow();
                ds.Setup.AddSetupRow(setup);
            }
            setup.SchemaVersion = Consts.Application.SchemaVersion;
            setup.ApplicationVersion = Consts.Application.Version;

            ds.AcceptChanges(); 
            Log.Write(String.Format("Cleanup took {0} msecs, removed {1} transaction history entries", (Environment.TickCount - ticksStart), transactions));
        }

        private void schemaCheck()
        {
            StringBuilder validations = new StringBuilder();
            // some housekeeping
            int ticksStart = Environment.TickCount;

            // check for plans without templates (was possible in early version)
            IEnumerable<int> planIDs = ds.PlannedTransactions.Where(p => (p.TransactionTemplatesRow == null)).Select(s => (s.ID)).ToArray();
            if (planIDs.Any())
            {
                validations.AppendLine(Resources.Labels.SchemaValidationPlansWithoutTemplate);
                foreach (int ID in planIDs)
                {
                    DeletePlannedTransaction(ID);
                }
                ds.AcceptChanges();
            }
            validationErrors = validations.ToString();

            int accounts = 0;
            int transactions = 0;
            int plans = 0;
            foreach (MoneyDataSet.AccountsRow account in ds.Accounts)
            {
                account.Balance = Math.Round(account.Balance, Consts.Keeper.AmountRoundingDigits);
                accounts++;
            }

            foreach (MoneyDataSet.TransactionsRow transaction in ds.Transactions)
            {
                transaction.Amount = Math.Round(transaction.Amount, Consts.Keeper.AmountRoundingDigits);
                transactions++;
            }

            foreach (MoneyDataSet.PlannedTransactionsRow plan in ds.PlannedTransactions)
            {
                plan.Amount = Math.Round(plan.Amount, Consts.Keeper.AmountRoundingDigits);
                plans++;
            }

            ds.AcceptChanges();

            Log.Write(String.Format("Housekeeping took {0} msecs, processed: {1} account(s), {2} transaction(s), {3} plan(s)",
                (Environment.TickCount - ticksStart), accounts, transactions, plans));
        }

        public String ValidationErrors { get { return validationErrors; } }

        private int clearTransactionHistory()
        {
            int removed = 0;
            foreach (MoneyDataSet.TransactionsRow transaction in ds.Transactions.Where(t => ((t.IsIsActiveNull()) || (!t.IsActive))).ToList())
            {
                ds.Transactions.RemoveTransactionsRow(transaction);
                ++removed;
            }
            ds.AcceptChanges();
            return removed;
        }

        #endregion

        #region Default values

        private MoneyDataSet.CurrenciesRow addCurrency(String ID, String Title, bool IsSymbolAfterAmount, double ExchangeRate, int SortOrder, String CurrencyCulture)
        {
            MoneyDataSet.CurrenciesRow currency = ds.Currencies.FindByID(ID);
            bool add = false;
            if (currency == null)
            {
                currency = ds.Currencies.NewCurrenciesRow();
                currency.ID = ID;
                currency.ExchangeRate = ExchangeRate;
                add = true;
            }
            currency.Title = Title;
            currency.IsSymbolAfterAmount = IsSymbolAfterAmount;
            currency.CurrencyCulture = CurrencyCulture;
            currency.SortOrder = SortOrder;
            if (add)
            {
                ds.Currencies.AddCurrenciesRow(currency);
            }
            return currency;
        }

        private MoneyDataSet.RecurrenciesRow addRecurrency(String ID, String Title, int IncrementDays, int IncrementMonths, int IncrementYears, int SortOrder)
        {
            MoneyDataSet.RecurrenciesRow recurrency = ds.Recurrencies.FindByID(ID);
            bool add = false;
            if (recurrency == null)
            {
                recurrency = ds.Recurrencies.NewRecurrenciesRow();
                recurrency.ID = ID;
                add = true;
            }
            recurrency.Title = Title;
            recurrency.IncrementDays = IncrementDays;
            recurrency.IncrementMonths = IncrementMonths;
            recurrency.IncrementYears = IncrementYears;
            recurrency.SortOrder = SortOrder;
            if (add)
            {
                ds.Recurrencies.AddRecurrenciesRow(recurrency);
            }
            return recurrency;
        }

        private MoneyDataSet.AccountTypesRow addAccountType(String ID, String Title, bool IsDebit, int SortOrder)
        {
            MoneyDataSet.AccountTypesRow accountType = ds.AccountTypes.FindByID(ID);
            bool add = false;
            if (accountType == null)
            {
                accountType = ds.AccountTypes.NewAccountTypesRow();
                accountType.ID = ID;
                accountType.SortOrder = SortOrder;
                add = true;
            }
            accountType.Title = Title;
            accountType.IsDebit = IsDebit;
            if (add)
            {
                ds.AccountTypes.AddAccountTypesRow(accountType);
            }
            return accountType;
        }

        private MoneyDataSet.TransactionTypesRow addTransactionType(String ID, String Title, bool IsIncome)
        {
            MoneyDataSet.TransactionTypesRow transactionType = ds.TransactionTypes.FindByID(ID);
            bool add = false;
            if (transactionType == null)
            {
                transactionType = ds.TransactionTypes.NewTransactionTypesRow();
                transactionType.ID = ID;
                add = true;
            }
            transactionType.Title = Title;
            transactionType.IsIncome = IsIncome;
            if (add)
            {
                ds.TransactionTypes.AddTransactionTypesRow(transactionType);
            }
            return transactionType;
        }

        private MoneyDataSet.TransactionTemplatesRow addSingleTransactionTemplate(String ID, String Title, String Message, String TransactionDefaultTitle,
            String SourceAccountTypeID, String SourceTransactionTypeID, bool ExactSourceAccountType, bool? IsIncome)
        {
            MoneyDataSet.TransactionTemplatesRow transactionTemplate = ds.TransactionTemplates.FindByID(ID);
            bool add = false;
            if (transactionTemplate == null)
            {
                transactionTemplate = ds.TransactionTemplates.NewTransactionTemplatesRow();
                transactionTemplate.ID = ID;
                transactionTemplate.IsVisible = true;
                add = true;
            }
            transactionTemplate.Title = Title;
            transactionTemplate.Message = Message;
            transactionTemplate.TransactionDefaultTitle = TransactionDefaultTitle;
            transactionTemplate.HasDestinationAccount = false;
            transactionTemplate.IsAmountIdentical = false;
            transactionTemplate.SourceAccountTypeID = SourceAccountTypeID;
            transactionTemplate.SourceTransactionTypeID = SourceTransactionTypeID;
            transactionTemplate.ExactSourceAccountType = ExactSourceAccountType;
            if (IsIncome.HasValue)
            {
                transactionTemplate.IsIncome = IsIncome.Value;
            }
            else
            {
                transactionTemplate.SetIsIncomeNull();
            }
            if (add)
            {
                ds.TransactionTemplates.AddTransactionTemplatesRow(transactionTemplate);
            }
            return transactionTemplate;
        }

        private MoneyDataSet.TransactionTemplatesRow addDualTransactionTemplate(String ID, String Title, String Message, String TransactionDefaultTitle,
            bool IsAmountIdentical, String SourceAccountTypeID, String SourceTransactionTypeID, bool ExactSourceAccountType,
            String DestinationAccountTypeID, String DestinationTransactionTypeID, bool ExactDestinationAccountType,
            bool? IsIncome)
        {
            MoneyDataSet.TransactionTemplatesRow transactionTemplate = ds.TransactionTemplates.FindByID(ID);
            bool add = false;
            if (transactionTemplate == null)
            {
                transactionTemplate = ds.TransactionTemplates.NewTransactionTemplatesRow();
                transactionTemplate.ID = ID;
                transactionTemplate.IsVisible = true;
                add = true;
            }
            transactionTemplate.Title = Title;
            transactionTemplate.Message = Message;
            transactionTemplate.TransactionDefaultTitle = TransactionDefaultTitle;
            transactionTemplate.HasDestinationAccount = true;
            transactionTemplate.IsAmountIdentical = IsAmountIdentical;
            transactionTemplate.SourceAccountTypeID = SourceAccountTypeID;
            transactionTemplate.SourceTransactionTypeID = SourceTransactionTypeID;
            transactionTemplate.ExactSourceAccountType = ExactSourceAccountType;
            transactionTemplate.DestinationAccountTypeID = DestinationAccountTypeID;
            transactionTemplate.DestinationTransactionTypeID = DestinationTransactionTypeID;
            transactionTemplate.ExactDestinationAccountType = ExactDestinationAccountType;
            if (IsIncome.HasValue)
            {
                transactionTemplate.IsIncome = IsIncome.Value;
            }
            else
            {
                transactionTemplate.SetIsIncomeNull();
            }
            if (add)
            {
                ds.TransactionTemplates.AddTransactionTemplatesRow(transactionTemplate);
            }
            return transactionTemplate;
        }

        private MoneyDataSet.ValidationRulesRow addValidationRule(String ID, String Title, String Message, bool PreventAction, bool IsIncompatible, bool IsCompatible)
        {
            MoneyDataSet.ValidationRulesRow validationRule = ds.ValidationRules.FindByID(ID);
            bool add = false;
            if (validationRule == null)
            {
                validationRule = ds.ValidationRules.NewValidationRulesRow();
                validationRule.ID = ID;
                add = true;
            }
            validationRule.Title = Title;
            validationRule.Message = Message;
            validationRule.PreventAction = PreventAction;
            validationRule.IsIncompatible = IsIncompatible;
            validationRule.IsCompatible = IsCompatible;
            if (add)
            {
                ds.ValidationRules.AddValidationRulesRow(validationRule);
            }
            return validationRule;
        }

        private void removeValidationCriteriaRules(String ValidationRuleID)
        {
            IEnumerable<int> IDs = ds.ValidationCriteria.Where(vc => (vc.ValidationRuleID.Equals(ValidationRuleID))).Select(s => (s.ID)).ToArray();
            foreach (int ID in IDs)
            {
                ds.ValidationCriteria.RemoveValidationCriteriaRow(ds.ValidationCriteria.FindByID(ID));
            }
        }

        private void fillDictionaries()
        {
            int ticksStart = Environment.TickCount;

            // fill currencies
            addCurrency(MoneyDataSet.IDs.Currencies.USDollar, Resources.Currencies.USDollarTitle, false, 30, 3, Consts.Keeper.USDollarCulture);
            addCurrency(MoneyDataSet.IDs.Currencies.Euro, Resources.Currencies.EuroTitle, true, 40, 2, Consts.Keeper.EuroCulture);
            addCurrency(MoneyDataSet.IDs.Currencies.Rouble, Resources.Currencies.RoubleTitle, true, 1, 1, Consts.Keeper.RoubleCulture);

            // fill recurrencies
            addRecurrency(MoneyDataSet.IDs.Recurrencies.None, Resources.Recurrencies.NoneTitle, 0, 0, 0, 0);
            addRecurrency(MoneyDataSet.IDs.Recurrencies.Daily, Resources.Recurrencies.DailyTitle, 1, 0, 0, 1);
            addRecurrency(MoneyDataSet.IDs.Recurrencies.Weekly, Resources.Recurrencies.WeeklyTitle, 7, 0, 0, 2);
            addRecurrency(MoneyDataSet.IDs.Recurrencies.Biweekly, Resources.Recurrencies.BiweeklyTitle, 14, 0, 0, 3);
            addRecurrency(MoneyDataSet.IDs.Recurrencies.Monthly, Resources.Recurrencies.MonthlyTitle, 0, 1, 0, 4);
            addRecurrency(MoneyDataSet.IDs.Recurrencies.Quarterly, Resources.Recurrencies.QuarterlyTitle, 0, 3, 0, 5);
            addRecurrency(MoneyDataSet.IDs.Recurrencies.Yearly, Resources.Recurrencies.YearlyTitle, 0, 0, 1, 6);

            // fill account types
            addAccountType(MoneyDataSet.IDs.AccountTypes.Cash, Resources.AccountTypes.CashTitle, true, 1);
            addAccountType(MoneyDataSet.IDs.AccountTypes.DebitCard, Resources.AccountTypes.DebitCardTitle, true, 2);
            addAccountType(MoneyDataSet.IDs.AccountTypes.CreditCard, Resources.AccountTypes.CreditCardTitle, false, 4);
            addAccountType(MoneyDataSet.IDs.AccountTypes.SavingsAccount, Resources.AccountTypes.SavingsAccountTitle, true, 5);
            addAccountType(MoneyDataSet.IDs.AccountTypes.CheckingAccount, Resources.AccountTypes.CheckingAccountTitle, true, 6);
            addAccountType(MoneyDataSet.IDs.AccountTypes.Loan, Resources.AccountTypes.LoanTitle, false, 3);
            addAccountType(MoneyDataSet.IDs.AccountTypes.Borrowed, Resources.AccountTypes.BorrowedTitle, false, 4);
            addAccountType(MoneyDataSet.IDs.AccountTypes.Lended, Resources.AccountTypes.LendedTitle, true, 7);

            // fill transaction types
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Salary, Resources.TransactionTypes.SalaryTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Dividents, Resources.TransactionTypes.DividentsTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Interest, Resources.TransactionTypes.InterestTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Shopping, Resources.TransactionTypes.ShoppingTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.VehicleExpenses, Resources.TransactionTypes.VehicleExpensesTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Purchase, Resources.TransactionTypes.PurchaseTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Payment, Resources.TransactionTypes.PaymentTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.CreditRepayment, Resources.TransactionTypes.CreditRepaymentTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Fine, Resources.TransactionTypes.FineTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.GiftReceived, Resources.TransactionTypes.GiftReceivedTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Bonus, Resources.TransactionTypes.BonusTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Prize, Resources.TransactionTypes.PrizeTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Tax, Resources.TransactionTypes.TaxTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.TransferOut, Resources.TransactionTypes.TransferOutTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.TransferIn, Resources.TransactionTypes.TransferInTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Charity, Resources.TransactionTypes.CharityTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.GiftGiven, Resources.TransactionTypes.GiftGivenTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Medical, Resources.TransactionTypes.MedicalTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.InsuranceFee, Resources.TransactionTypes.InsuranceFeeTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Entertainment, Resources.TransactionTypes.EntertainmentTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.BenefitPayment, Resources.TransactionTypes.BenefitPaymentTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Utilities, Resources.TransactionTypes.UtilitiesTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Services, Resources.TransactionTypes.ServicesTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Correction, Resources.TransactionTypes.CorrectionTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Return, Resources.TransactionTypes.ReturnTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.TaxReturn, Resources.TransactionTypes.TaxReturnTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Borrow, Resources.TransactionTypes.BorrowTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Lend, Resources.TransactionTypes.LendTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.CreditReduction, Resources.TransactionTypes.CreditReductionTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.BorrowedIncrease, Resources.TransactionTypes.BorrowedIncreaseTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.DebtReduction, Resources.TransactionTypes.DebtReductionTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.DebtIncrease, Resources.TransactionTypes.DebtIncreaseTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.DebtReturned, Resources.TransactionTypes.DebtReturnedTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.ItemSold, Resources.TransactionTypes.ItemSoldTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Sport, Resources.TransactionTypes.SportTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Communication, Resources.TransactionTypes.CommunicationTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Dinner, Resources.TransactionTypes.DinnerTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.Transportation, Resources.TransactionTypes.TransportationTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.PetExpenses, Resources.TransactionTypes.PetExpensesTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.OtherPayment, Resources.TransactionTypes.OtherPaymentTitle, false);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.OtherIncome, Resources.TransactionTypes.OtherIncomeTitle, true);
            addTransactionType(MoneyDataSet.IDs.TransactionTypes.CosmeticTreatments, Resources.TransactionTypes.CosmeticTreatmentsTitle, false);

            // fill validation rules
            // TODO: add more validation rules
            MoneyDataSet.ValidationRulesRow vr1 = addValidationRule(MoneyDataSet.IDs.ValidationRules.CreditAccountsNegativeBalance,
                Resources.ValidationRules.CreditAccountsNegativeBalanceTitle, Resources.ValidationRules.CreditAccountsNegativeBalanceMessage, true, true, false);

            if (vr1 != null)
            {
                removeValidationCriteriaRules(vr1.ID);
                MoneyDataSet.ValidationCriteriaRow vr1c1 = ds.ValidationCriteria.NewValidationCriteriaRow();
                vr1c1.ValidationRulesRow = vr1;
                vr1c1.AccountTypeID = MoneyDataSet.IDs.AccountTypes.Loan;
                vr1c1.IsAccountBalancePositive = true;
                ds.ValidationCriteria.AddValidationCriteriaRow(vr1c1);

                MoneyDataSet.ValidationCriteriaRow vr1c2 = ds.ValidationCriteria.NewValidationCriteriaRow();
                vr1c2.ValidationRulesRow = vr1;
                vr1c2.AccountTypeID = MoneyDataSet.IDs.AccountTypes.Borrowed;
                vr1c2.IsAccountBalancePositive = true;
                ds.ValidationCriteria.AddValidationCriteriaRow(vr1c2);
                ds.AcceptChanges();
            }

            MoneyDataSet.ValidationRulesRow vr1a = addValidationRule(MoneyDataSet.IDs.ValidationRules.CreditCardNegativeBalance,
                Resources.ValidationRules.CreditCardNegativeBalanceTitle, Resources.ValidationRules.CreditCardNegativeBalanceMessage, false, true, false);

            if (vr1a != null)
            {
                removeValidationCriteriaRules(vr1a.ID);
                MoneyDataSet.ValidationCriteriaRow vr1ac1 = ds.ValidationCriteria.NewValidationCriteriaRow();
                vr1ac1.ValidationRulesRow = vr1a;
                vr1ac1.AccountTypeID = MoneyDataSet.IDs.AccountTypes.CreditCard;
                vr1ac1.IsAccountBalancePositive = true;
                ds.ValidationCriteria.AddValidationCriteriaRow(vr1ac1);
                ds.AcceptChanges();
            }

            MoneyDataSet.ValidationRulesRow vr2 = addValidationRule(MoneyDataSet.IDs.ValidationRules.DebitPositiveBalance,
                Resources.ValidationRules.DebitPositiveBalanceTitle, Resources.ValidationRules.DebitPositiveBalanceMessage, false, true, false);

            if (vr2 != null)
            {
                removeValidationCriteriaRules(vr2.ID);
                MoneyDataSet.ValidationCriteriaRow vr2c1 = ds.ValidationCriteria.NewValidationCriteriaRow();
                vr2c1.ValidationRulesRow = vr2;
                vr2c1.IsAccountDebit = true;
                vr2c1.IsAccountBalanceNegative = true;
                ds.ValidationCriteria.AddValidationCriteriaRow(vr2c1);
                ds.AcceptChanges();
            }

            MoneyDataSet.ValidationRulesRow vr3 = addValidationRule(MoneyDataSet.IDs.ValidationRules.TransactionNonZero,
                Resources.ValidationRules.TransactionNonZeroTitle, Resources.ValidationRules.TransactionNonZeroMessage, false, true, false);

            if (vr3 != null)
            {
                removeValidationCriteriaRules(vr3.ID);
                MoneyDataSet.ValidationCriteriaRow vr3c1 = ds.ValidationCriteria.NewValidationCriteriaRow();
                vr3c1.ValidationRulesRow = vr3;
                vr3c1.IsTransactionAmountZero = true;
                ds.ValidationCriteria.AddValidationCriteriaRow(vr3c1);
                ds.AcceptChanges();
            }

            MoneyDataSet.ValidationRulesRow vr4 = addValidationRule(MoneyDataSet.IDs.ValidationRules.OnlyCorrectionNegative,
                Resources.ValidationRules.OnlyCorrectionNegativeTitle, Resources.ValidationRules.OnlyCorrectionNegativeMessage, true, false, true);

            if (vr4 != null)
            {
                removeValidationCriteriaRules(vr4.ID);
                MoneyDataSet.ValidationCriteriaRow vr4c1 = ds.ValidationCriteria.NewValidationCriteriaRow();
                vr4c1.ValidationRulesRow = vr4;
                vr4c1.IsTransactionAmountZero = true;
                ds.ValidationCriteria.AddValidationCriteriaRow(vr4c1);

                MoneyDataSet.ValidationCriteriaRow vr4c2 = ds.ValidationCriteria.NewValidationCriteriaRow();
                vr4c2.ValidationRulesRow = vr4;
                vr4c2.TransactionTypeID = MoneyDataSet.IDs.TransactionTypes.Correction;
                vr4c2.IsTransactionAmountNegative = true;
                ds.ValidationCriteria.AddValidationCriteriaRow(vr4c2);

                MoneyDataSet.ValidationCriteriaRow vr4c3 = ds.ValidationCriteria.NewValidationCriteriaRow();
                vr4c3.ValidationRulesRow = vr4;
                vr4c3.IsTransactionAmountPositive = true;
                ds.ValidationCriteria.AddValidationCriteriaRow(vr4c3);
                ds.AcceptChanges();
            }

            // fill transaction templates
            addDualTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.CreditRepayment, Resources.Templates.CreditRepaymentTitle, 
                Resources.Templates.CreditRepaymentMessage, Resources.Templates.CreditRepaymentDefault, false, MoneyDataSet.IDs.AccountTypes.Cash, 
                MoneyDataSet.IDs.TransactionTypes.CreditRepayment, false, MoneyDataSet.IDs.AccountTypes.Loan, MoneyDataSet.IDs.TransactionTypes.CreditReduction, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Shopping, Resources.Templates.ShoppingTitle,
                Resources.Templates.ShoppingMessage, Resources.Templates.ShoppingDefault, MoneyDataSet.IDs.AccountTypes.Cash, 
                MoneyDataSet.IDs.TransactionTypes.Shopping, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.VehicleExpenses, Resources.Templates.VehicleExpensesTitle,
                Resources.Templates.VehicleExpensesMessage, Resources.Templates.VehicleExpensesDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.VehicleExpenses, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Entertainment, Resources.Templates.EntertainmentTitle,
                Resources.Templates.EntertainmentMessage, Resources.Templates.EntertainmentDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Entertainment, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Salary, Resources.Templates.SalaryTitle,
                Resources.Templates.SalaryMessage, Resources.Templates.SalaryDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Salary, false, true);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Sport, Resources.Templates.SportTitle,
                Resources.Templates.SportMessage, Resources.Templates.SportDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Sport, false, false);

            addDualTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Transfer, Resources.Templates.TransferTitle,
                Resources.Templates.TransferMessage, Resources.Templates.TransferDefault,
                false, MoneyDataSet.IDs.AccountTypes.DebitCard, MoneyDataSet.IDs.TransactionTypes.TransferOut,
                false, MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.TransferIn, false, null);

            addDualTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.DebtReturned, Resources.Templates.DebtReturnedTitle,
                Resources.Templates.DebtReturnedMessage, Resources.Templates.DebtReturnedDefault, false,
                MoneyDataSet.IDs.AccountTypes.Lended, MoneyDataSet.IDs.TransactionTypes.DebtReduction, true,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.DebtReturned, false, true);

            addDualTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Lended, Resources.Templates.LendedTitle,
                Resources.Templates.LendedMessage, Resources.Templates.LendedDefault,
                false, MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Lend, false,
                MoneyDataSet.IDs.AccountTypes.Lended, MoneyDataSet.IDs.TransactionTypes.DebtIncrease, true, false);

            addDualTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Borrowed, Resources.Templates.BorrowedTitle,
                Resources.Templates.BorrowedMessage, Resources.Templates.BorrowedDefault, false,
                MoneyDataSet.IDs.AccountTypes.Borrowed, MoneyDataSet.IDs.TransactionTypes.BorrowedIncrease, true, 
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Borrow, false, true);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Dividents, Resources.Templates.DividentsTitle,
                Resources.Templates.DividentsMessage, Resources.Templates.DividentsDefault, MoneyDataSet.IDs.AccountTypes.Cash,
                MoneyDataSet.IDs.TransactionTypes.Dividents, false, true);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Interest, Resources.Templates.InterestTitle,
                Resources.Templates.InterestMessage, Resources.Templates.InterestDefault,
                MoneyDataSet.IDs.AccountTypes.DebitCard, MoneyDataSet.IDs.TransactionTypes.Interest, false, true);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Purchase, Resources.Templates.PurchaseTitle,
                Resources.Templates.PurchaseMessage, Resources.Templates.PurchaseDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Purchase, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Dinner, Resources.Templates.DinnerTitle,
                Resources.Templates.DinnerMessage, Resources.Templates.DinnerDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Dinner, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Communication, Resources.Templates.CommunicationTitle,
                Resources.Templates.CommunicationMessage, Resources.Templates.CommunicationDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Communication, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Transportation, Resources.Templates.TransportationTitle,
                Resources.Templates.TransportationMessage, Resources.Templates.TransportationDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Transportation, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Fine, Resources.Templates.FineTitle,
                Resources.Templates.FineMessage, Resources.Templates.FineDefault, MoneyDataSet.IDs.AccountTypes.Cash, 
                MoneyDataSet.IDs.TransactionTypes.Fine, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.GiftReceived, Resources.Templates.GiftReceivedTitle,
                Resources.Templates.GiftReceivedMessage, Resources.Templates.GiftReceivedDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.GiftReceived, false, true);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.GiftGiven, Resources.Templates.GiftGivenTitle,
                Resources.Templates.GiftGivenMessage, Resources.Templates.GiftGivenDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.GiftGiven, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Bonus, Resources.Templates.BonusTitle,
                Resources.Templates.BonusMessage, Resources.Templates.BonusDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Bonus, false, true);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Prize, Resources.Templates.PrizeTitle,
                Resources.Templates.PrizeMessage, Resources.Templates.PrizeDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Prize, false, true);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Tax, Resources.Templates.TaxTitle,
                Resources.Templates.TaxMessage, Resources.Templates.TaxDefault, MoneyDataSet.IDs.AccountTypes.Cash, 
                MoneyDataSet.IDs.TransactionTypes.Tax, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Charity, Resources.Templates.CharityTitle,
                Resources.Templates.CharityMessage, Resources.Templates.CharityDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Charity, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Medical, Resources.Templates.MedicalTitle,
                Resources.Templates.MedicalMessage, Resources.Templates.MedicalDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Medical, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.CosmeticTreatments, 
                Resources.Templates.CosmeticTreatmentsTitle, Resources.Templates.CosmeticTreatmentsMessage, 
                Resources.Templates.CosmeticTreatmentsDefault, MoneyDataSet.IDs.AccountTypes.Cash, 
                MoneyDataSet.IDs.TransactionTypes.Medical, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.PetExpenses, Resources.Templates.PetExpensesTitle,
                Resources.Templates.PetExpensesMessage, Resources.Templates.PetExpensesDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.PetExpenses, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.InsuranceFee, Resources.Templates.InsuranceFeeTitle,
                Resources.Templates.InsuranceFeeMessage, Resources.Templates.InsuranceFeeDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.InsuranceFee, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.BenefitPayment, Resources.Templates.BenefitPaymentTitle,
                Resources.Templates.BenefitPaymentMessage, Resources.Templates.BenefitPaymentDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.InsuranceFee, false, true);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Utilities, Resources.Templates.UtilitiesTitle,
                Resources.Templates.UtilitiesMessage, Resources.Templates.UtilitiesDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Utilities, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Services, Resources.Templates.ServicesTitle,
                Resources.Templates.ServicesMessage, Resources.Templates.ServicesDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Services, false, false);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.Return, Resources.Templates.ReturnTitle,
                Resources.Templates.ReturnMessage, Resources.Templates.ReturnDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.Return, false, true);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.TaxReturn, Resources.Templates.TaxReturnTitle,
                Resources.Templates.TaxReturnMessage, Resources.Templates.TaxReturnDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.TaxReturn, false, true);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.ItemSold, Resources.Templates.ItemSoldTitle,
                Resources.Templates.ItemSoldMessage, Resources.Templates.ItemSoldDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.ItemSold, false, true);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.OtherIncome, Resources.Templates.OtherIncomeTitle,
                Resources.Templates.OtherIncomeMessage, Resources.Templates.OtherIncomeDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.OtherIncome, false, true);

            addSingleTransactionTemplate(MoneyDataSet.IDs.TransactionTemplates.OtherPayment, Resources.Templates.OtherPaymentTitle,
                Resources.Templates.OtherPaymentMessage, Resources.Templates.OtherPaymentDefault,
                MoneyDataSet.IDs.AccountTypes.Cash, MoneyDataSet.IDs.TransactionTypes.OtherPayment, false, false);
            
            ds.AcceptChanges();
            Log.Write(String.Format("Dictionary refresh took {0} msecs", (Environment.TickCount - ticksStart)));
        }

        #endregion

        #region Currency management

        public IEnumerable<MoneyDataSet.CurrenciesRow> Currencies
        {
            get { return ds.Currencies.OrderBy(o => (o.SortOrder)); }
        }

        public MoneyDataSet.CurrenciesRow GetDefaultCurrency()
        {
            // this approach requires that there should be currency with ExchangeRate == 1, and it would be better that it would only one currency
            // TODO: consider using other methods of determining default currency (setup, for example)
            MoneyDataSet.CurrenciesRow currency = ds.Currencies.FirstOrDefault(c => (c.ExchangeRate == 1));
            if (currency == null)
            {
                return ds.Currencies.OrderBy(c => (c.SortOrder)).First();
            }
            else
            {
                return currency;
            }
        }

        #endregion

        #region Recurrency management

        public IEnumerable<MoneyDataSet.RecurrenciesRow> Recurrencies
        {
            get { return ds.Recurrencies.OrderBy(o => (o.SortOrder)); }
        }

        #endregion

        #region Transaction management

        public IEnumerable<MoneyDataSet.TransactionsRow> Transactions
        {
            get
            {
               return ds.Transactions.OrderByDescending(o => (o.ID));
            }
        }


        public IEnumerable<MoneyDataSet.TransactionTypesRow> GetTransactionTypes(bool? isIncome = null)
        {
            if (isIncome == null)
            {
                return ds.TransactionTypes;
            }
            else
            {
                return ds.TransactionTypes.Where(tt => (tt.IsIncome == isIncome));
            }
        }

        public MoneyDataSet.TransactionTypesRow GetTransactionType(String id)
        {
            return ds.TransactionTypes.SingleOrDefault(tt => (tt.ID.Equals(id)));
        }

        public MoneyDataSet.TransactionsRow GetTransaction(int id)
        {
            return ds.Transactions.SingleOrDefault(t => (t.ID == id));
        }

        public IEnumerable<String> GetTransactionTagStrings(MoneyDataSet.TransactionsRow transaction)
        {
            return ds.TransactionTags.Where(t => (t.TransactionID == transaction.ID)).Select(tt => (tt.TagRow.Title));
        }
        
        public void DeleteTransaction(int transactionID)
        {
            MoneyDataSet.TransactionsRow transaction = GetTransaction(transactionID);

            if (transaction.IsPairReferenceIDNull())
            {

                // updating account balance
                if (transaction.TransactionTypesRow.IsIncome)
                {
                    transaction.AccountRow.Balance -= transaction.Amount;
                }
                else
                {
                    transaction.AccountRow.Balance += transaction.Amount;
                }
                ds.Transactions.RemoveTransactionsRow(transaction);
            }
            else
            {
                IEnumerable<MoneyDataSet.TransactionsRow> paired = ds.Transactions.Where(t => ((!t.IsPairReferenceIDNull()) && 
                    (t.PairReferenceID == transaction.PairReferenceID))).ToArray();
                foreach (MoneyDataSet.TransactionsRow one in paired)
                {

                    // updating account balance
                    if (one.TransactionTypesRow.IsIncome)
                    {
                        one.AccountRow.Balance -= one.Amount;
                    }
                    else
                    {
                        one.AccountRow.Balance += one.Amount;
                    }
                    ds.Transactions.RemoveTransactionsRow(one);
                }
            }

            ds.AcceptChanges();
        }


        private void addTransactionTags(MoneyDataSet.TransactionsRow transcation, IEnumerable<String> tags)
        {
            // removing tags from account
            IEnumerable<MoneyDataSet.TransactionTagsRow> ttrs = ds.TransactionTags.Where(tt => (tt.TransactionID == transcation.ID)).ToArray();

            foreach (MoneyDataSet.TransactionTagsRow tt in ttrs)
            {
                ds.TransactionTags.RemoveTransactionTagsRow(tt);
            }

            // adding tags to account
            foreach (String tag in tags)
            {
                String lowerTag = tag.ToLower();
                MoneyDataSet.TransactionTagsRow tt = ds.TransactionTags.NewTransactionTagsRow();
                tt.TransactionRow = transcation;
                if (ds.Tags.Count(t => (t.Title.Equals(lowerTag))) > 0)
                {
                    tt.TagRow = ds.Tags.Single(t => (t.Title.Equals(tag.ToLower())));
                }
                else
                {
                    tt.TagRow = ds.Tags.AddTagsRow(lowerTag);
                }
                ds.TransactionTags.AddTransactionTagsRow(tt);
            }

            ds.AcceptChanges();
        }

        public MoneyDataSet.TransactionsRow PreCreateTransaction(MoneyDataSet.TransactionTypesRow type, String title, String description, DateTime dateTime, 
            MoneyDataSet.AccountsRow account, double amount, MoneyDataSet.PlannedTransactionsRow plan = null, 
            MoneyDataSet.TransactionTemplatesRow template = null, int pairReference = 0)
        {
            MoneyDataSet.TransactionsRow transaction = ds.Transactions.NewTransactionsRow();

            transaction.Title = title;
            transaction.Description = description;
            transaction.AccountRow = account;
            transaction.TransactionTypesRow = type;
            transaction.Amount = Math.Round(amount, Consts.Keeper.AmountRoundingDigits);
            transaction.TransactionTime = dateTime;
            transaction.EntryTime = DateTime.Now;

            if (plan != null)
            {
                transaction.PlannedTransactionsRow = plan;
            }

            if (template != null)
            {
                transaction.TransactionTemplatesRow = template;
                if (template.HasDestinationAccount)
                {
                    if (pairReference > 0)
                    {
                        transaction.PairReferenceID = pairReference;
                    }                        
                    else
                    {
                        transaction.PairReferenceID = transaction.ID;
                    }
                }
            }


            
            return transaction;
        }

        public MoneyDataSet.TransactionsRow CreateTransaction(MoneyDataSet.TransactionsRow preCreate, IEnumerable<String> tags)
        {
            MoneyDataSet.TransactionsRow transaction = preCreate;

            ds.Transactions.AddTransactionsRow(transaction);
            addTransactionTags(transaction, tags);

            // updating account amount
            if (transaction.TransactionTypesRow.IsIncome)
            {
                transaction.AccountRow.Balance += transaction.Amount;
            }
            else
            {
                transaction.AccountRow.Balance -= transaction.Amount;
            }

            ds.AcceptChanges();

            return transaction;
        }
        

        #endregion

        #region Planned transaction management

        public bool IsPlannedTransactionImplemented(MoneyDataSet.PlannedTransactionsRow plan, DateTime date)
        {

            return (GetPlannedTransactionImplementations(plan, date).Any());
        }

        public IEnumerable<MoneyDataSet.TransactionsRow> GetPlannedTransactionImplementations(MoneyDataSet.PlannedTransactionsRow plan, DateTime date)
        {
            IEnumerable<MoneyDataSet.TransactionsRow> transactions = this.Transactions.Where(t => (!t.IsPlannedTransactionIDNull()));

            if ((plan.IsHistoryReferenceIDNull()) || (plan.HistoryReferenceID == 0))
            {
                transactions = transactions.Where(t => (t.PlannedTransactionID == plan.ID));
            }
            else
            {
                IEnumerable<int> planIDs = ds.PlannedTransactions.Where(p => (p.HistoryReferenceID == plan.HistoryReferenceID)).Select(s => (s.ID));
                transactions = transactions.Where(t => (planIDs.Contains(t.PlannedTransactionID)));
            }

            int days =  plan.RecurrenciesRow.IncrementDays + plan.RecurrenciesRow.IncrementMonths * 30 + plan.RecurrenciesRow.IncrementYears * 365;
            DateTime startDate;
            DateTime endDate;

            if (plan.IsAggregated)
            {
                startDate = date.Date;
                endDate = date.AddDays(days).Date;
            }
            else
            {
                startDate = date.AddDays(-days / 2).Date;
                endDate = date.AddDays(days / 2).Date;
            }

            return (days > 0 ? transactions.Where(t => ((t.TransactionTime.Date >= startDate) && (t.TransactionTime.Date <= endDate))) : transactions);
        }

        public void DeletePlannedTransaction(int planID)
        {
            MoneyDataSet.PlannedTransactionsRow plan = GetPlannedTransaction(planID);

            if (plan.IsPairReferenceIDNull())
            {
                if (plan.HistoryReferenceID == 0)
                {
                    plan.HistoryReferenceID = planID;
                }
                MoneyDataSet.PlannedTransactionsRow newPlan = clonePlannedTransaction(plan);
                newPlan.IsActive = false;
            }
            else
            {
                IEnumerable<MoneyDataSet.PlannedTransactionsRow> paired = ds.PlannedTransactions.Where(pt => ((!pt.IsPairReferenceIDNull()) &&
                    (pt.PairReferenceID == plan.PairReferenceID))).ToArray();
                foreach (MoneyDataSet.PlannedTransactionsRow one in paired)
                {
                    if (one.HistoryReferenceID == 0)
                    {
                        one.HistoryReferenceID = planID;
                    }
                    MoneyDataSet.PlannedTransactionsRow newPlan = clonePlannedTransaction(one);
                    newPlan.IsActive = false;
                }
            }

            ds.AcceptChanges();
        }

        public IEnumerable<String> GetPlannedTransactionTagStrings(MoneyDataSet.PlannedTransactionsRow plan)
        {
            return ds.PlannedTransactionTags.Where(t => (t.PlannedTransactionID == plan.ID)).Select(tt => (tt.TagRow.Title));
        }

        private MoneyDataSet.PlannedTransactionsRow clonePlannedTransaction(MoneyDataSet.PlannedTransactionsRow source)
        {
            MoneyDataSet.PlannedTransactionsRow newPlan = ds.PlannedTransactions.NewPlannedTransactionsRow();
            newPlan.HistoryReferenceID = source.HistoryReferenceID;
            newPlan.Title = source.Title;
            newPlan.Description = source.Description;
            newPlan.AccountTypeID = source.AccountTypeID;
            newPlan.TransactionTypeID = source.TransactionTypeID;
            newPlan.Amount = source.Amount;
            newPlan.IsActive = source.IsActive;
            if (source.IsStartTimeNull())
            {
                newPlan.SetStartTimeNull();
            }
            else
            {
                newPlan.StartTime = source.StartTime;
            }
            newPlan.CurrencyID = source.CurrencyID;
            newPlan.RecurrencyID = source.RecurrencyID;
            newPlan.IsAggregated = source.IsAggregated;
            newPlan.TransactionTemplatesRow = source.TransactionTemplatesRow;
            if (!source.IsPairReferenceIDNull())
            {
                newPlan.PairReferenceID = source.PairReferenceID;
            }
            if (!source.IsEndTimeNull())
            {
                newPlan.EndTime = source.EndTime;
            }
            newPlan.EntryTime = DateTime.Now;
            ds.PlannedTransactions.AddPlannedTransactionsRow(newPlan);

            foreach (MoneyDataSet.TagsRow tag in source.GetPlannedTransactionTagsRows().Select(ptt => (ptt.TagRow)))
            {
                ds.PlannedTransactionTags.AddPlannedTransactionTagsRow(newPlan, tag);
            }

            return newPlan;
        }

        public MoneyDataSet.PlannedTransactionsRow PreCreatePlannedTransaction(MoneyDataSet.TransactionTypesRow type, String title, String description, DateTime? dateTime,
            MoneyDataSet.AccountTypesRow accountType, double amount, MoneyDataSet.CurrenciesRow currency, MoneyDataSet.RecurrenciesRow recurrency,
            DateTime? endDateTime, bool isAggregated, MoneyDataSet.TransactionTemplatesRow template = null, int pairReference = 0)
        {
            MoneyDataSet.PlannedTransactionsRow plan = ds.PlannedTransactions.NewPlannedTransactionsRow();

            plan.Title = title;
            plan.Description = description;
            plan.AccountTypeRow = accountType;
            plan.TransactionTypeRow = type;
            plan.Amount = Math.Round(amount, Consts.Keeper.AmountRoundingDigits);
            if (dateTime != null)
            {
                plan.StartTime = dateTime.Value;
            }
            if (endDateTime != null)
            {
                plan.EndTime = endDateTime.Value;
            }
            plan.CurrenciesRow = currency;
            plan.RecurrenciesRow = recurrency;
            plan.EntryTime = DateTime.Now;
            plan.TransactionTemplatesRow = template;
            plan.IsAggregated = isAggregated;

            if (template != null)
            {
                if (template.HasDestinationAccount)
                {
                    if (pairReference > 0)
                    {
                        plan.PairReferenceID = pairReference;
                    }
                    else
                    {
                        plan.PairReferenceID = plan.ID;
                    }
                }
            }

            return plan;
        }

        public MoneyDataSet.PlannedTransactionsRow UpdatePlannedTransaction(int planID, String title, String description, DateTime? dateTime,
            MoneyDataSet.AccountTypesRow accountType, double amount, MoneyDataSet.CurrenciesRow currency, MoneyDataSet.RecurrenciesRow recurrency, 
            DateTime? endDateTime, bool isAggregated, IEnumerable<String> tags, MoneyDataSet.TransactionTemplatesRow template = null)
        {
            MoneyDataSet.PlannedTransactionsRow plan = GetPlannedTransaction(planID);
            if (plan.HistoryReferenceID == 0)
            {
                plan.HistoryReferenceID = planID;
            }

            MoneyDataSet.PlannedTransactionsRow newPlan = clonePlannedTransaction(plan);

            newPlan.Title = title;
            newPlan.Description = description;
            if (dateTime != null)
            {
                newPlan.StartTime = dateTime.Value;
            }
            else
            {
                newPlan.SetStartTimeNull();
            }
            newPlan.CurrenciesRow = currency;
            newPlan.RecurrenciesRow = recurrency;
            newPlan.AccountTypeRow = accountType;
            newPlan.Amount = Math.Round(amount, Consts.Keeper.AmountRoundingDigits);
            if (endDateTime != null)
            {
                newPlan.EndTime = endDateTime.Value;
            }
            else
            {
                newPlan.SetEndTimeNull();
            }
            newPlan.EntryTime = DateTime.Now;
            newPlan.IsAggregated = isAggregated;

            addPlannedTransactionTags(newPlan, tags);

            ds.AcceptChanges();

            return newPlan;
        }
        
        public List<MoneyDataSet.PlannedTransactionsRow> PlannedTransactions
        {
            get
            {
                List<MoneyDataSet.PlannedTransactionsRow> list = new List<MoneyDataSet.PlannedTransactionsRow>();

                // add unchanged accounts
                list.AddRange(ds.PlannedTransactions.Where(a => ((a.HistoryReferenceID == 0) && (a.IsActive))));

                // get list of changed account groups
                foreach (int historyID in ds.PlannedTransactions.Where(a => (a.HistoryReferenceID > 0)).Select(a => (a.HistoryReferenceID)).Distinct())
                {
                    int planID = ds.PlannedTransactions.Where(a => (a.HistoryReferenceID == historyID)).Select(a => (a.ID)).Max();
                    MoneyDataSet.PlannedTransactionsRow plan = GetPlannedTransaction(planID);
                    if (plan.IsActive)
                    {
                        list.Add(plan);
                    }
                }

                return list;
            }
        }

        public List<MoneyDataSet.PlannedTransactionsRow> GetRelevantPlannedTransactions(String typeID = null)
        {
            List<MoneyDataSet.PlannedTransactionsRow> list = new List<MoneyDataSet.PlannedTransactionsRow>();
            IEnumerable<MoneyDataSet.PlannedTransactionsRow> plans = this.PlannedTransactions;
            if (typeID != null)
            {
                plans = plans.Where(pt => (pt.TransactionTypeID.Equals(typeID)));
            }

            foreach (MoneyDataSet.PlannedTransactionsRow plan in plans.Where(p => (!p.IsStartTimeNull())))
            {
                if (plan.RecurrencyID.Equals(MoneyDataSet.IDs.Recurrencies.None))
                {
                    if ((plan.IsAggregated) || (this.Transactions.Count(t => ((!t.IsPlannedTransactionIDNull()) && (t.PlannedTransactionID == plan.ID))) == 0))
                    {
                        // plan is non-reccurrent and is not implemented, aggregated plans will be added anyway
                        list.Add(plan);
                    }
                }
                else
                {
                    int days = (plan.RecurrenciesRow.IncrementDays + plan.RecurrenciesRow.IncrementMonths * 30  + plan.RecurrenciesRow.IncrementYears * 365);
                    if (plan.IsAggregated)
                    {
                        if (((DateTime.Now > plan.StartTime) && ((plan.IsEndTimeNull()) || (DateTime.Now < plan.EndTime.AddDays(days)))))
                        {
                            // aggregated plans have slightly different period of validity
                            list.Add(plan);
                        }
                    }
                    else if ((DateTime.Now > plan.StartTime.AddDays(-days/2)) && ((plan.IsEndTimeNull()) || (DateTime.Now < plan.EndTime.AddDays(days/2))))
                    {
                        // plan is recurrent, but currently it is valid
                        list.Add(plan);
                    }
                }
            }
            foreach (MoneyDataSet.PlannedTransactionsRow plan in plans.Where(p => (p.IsStartTimeNull())))
            {
                if ((plan.IsAggregated) || (this.Transactions.Count(t => ((!t.IsPlannedTransactionIDNull()) && (t.PlannedTransactionID == plan.ID))) == 0))
                {
                    // plan is non-reccurrent and is not implemented, aggregated plans will be added anyway
                    list.Add(plan);
                }
            }
            return list;
        }

        public MoneyDataSet.PlannedTransactionsRow GetPlannedTransaction(int id)
        {
            return ds.PlannedTransactions.SingleOrDefault(t => (t.ID == id));
        }

        public MoneyDataSet.PlannedTransactionsRow CreatePlannedTransaction(MoneyDataSet.PlannedTransactionsRow preCreate, IEnumerable<String> tags)
        {
            MoneyDataSet.PlannedTransactionsRow plan = preCreate;

            ds.PlannedTransactions.AddPlannedTransactionsRow(plan);
            addPlannedTransactionTags(plan, tags);

            ds.AcceptChanges();

            return plan;
        }

        private void addPlannedTransactionTags(MoneyDataSet.PlannedTransactionsRow plan, IEnumerable<String> tags)
        {
            // removing tags from plan
            IEnumerable<MoneyDataSet.PlannedTransactionTagsRow> ttrs = ds.PlannedTransactionTags.Where(tt => (tt.PlannedTransactionID == plan.ID)).ToArray();

            foreach (MoneyDataSet.PlannedTransactionTagsRow tt in ttrs)
            {
                ds.PlannedTransactionTags.RemovePlannedTransactionTagsRow(tt);
            }

            // adding tags to plan
            foreach (String tag in tags)
            {
                String lowerTag = tag.ToLower();
                MoneyDataSet.PlannedTransactionTagsRow tt = ds.PlannedTransactionTags.NewPlannedTransactionTagsRow();
                tt.PlannedTransactionRow = plan;
                if (ds.Tags.Count(t => (t.Title.Equals(lowerTag))) > 0)
                {
                    tt.TagRow = ds.Tags.Single(t => (t.Title.Equals(tag.ToLower())));
                }
                else
                {
                    tt.TagRow = ds.Tags.AddTagsRow(lowerTag);
                }
                ds.PlannedTransactionTags.AddPlannedTransactionTagsRow(tt);
            }

            ds.AcceptChanges();
        }

        public class ActivePlannedTransactionEntry
        {
            public ActivePlannedTransactionEntry(DateTime date, MoneyDataSet.PlannedTransactionsRow plan)
            {
                Date = date;
                PlannedTransaction = plan;
            }

            public DateTime Date { get; set; }
            public MoneyDataSet.PlannedTransactionsRow PlannedTransaction { get; set; }

            public String AmountWithCurrency
            {
                get
                {
                    return PlannedTransaction.Amount.ToString(Consts.UI.CurrencyFormat, PlannedTransaction.CurrenciesRow.CurrencyCultureInfo);
                }
            }

            public String FullTitle
            {
                get
                {
                    return String.Format(Consts.UI.PlanToolTipFormat, Date.ToShortDateString(), PlannedTransaction.TransactionTypeRow.Title, PlannedTransaction.Title, 
                        (PlannedTransaction.IsAggregated ? Resources.Labels.AggregatedLabel : String.Empty), AmountWithCurrency);
                }
            }
        }

        public List<ActivePlannedTransactionEntry> GetActivePlannedTransactions(DateTime startDate, DateTime endDate, bool includePlansWithoutDate = true)
        {
            DateTime start = startDate.Date;
            DateTime end = endDate.Date.AddDays(1);
            
            List<ActivePlannedTransactionEntry> list = new List<ActivePlannedTransactionEntry>();
            foreach (MoneyDataSet.PlannedTransactionsRow plan in this.PlannedTransactions.Where(p => (!p.IsStartTimeNull())))
            {
                if (plan.RecurrencyID.Equals(MoneyDataSet.IDs.Recurrencies.None))
                {
                    if ((plan.StartTime >= start) && (plan.StartTime < end))
                    {
                        list.Add(new ActivePlannedTransactionEntry(plan.StartTime, plan));
                    }
                }
                else
                {
                    DateTime recurrencyDate = plan.StartTime;
                    DateTime limit = end;
                    if ((!plan.IsEndTimeNull()) && (limit > plan.EndTime))
                    {
                        limit = plan.EndTime;
                    }
                    while (recurrencyDate < limit)
                    {
                        if (recurrencyDate >= start)
                        {
                            list.Add(new ActivePlannedTransactionEntry(recurrencyDate, plan));
                        }
                        recurrencyDate = recurrencyDate.AddDays(plan.RecurrenciesRow.IncrementDays).AddMonths(plan.RecurrenciesRow.IncrementMonths).AddYears(plan.RecurrenciesRow.IncrementYears);
                    }
                }
            }
            if (includePlansWithoutDate)
            {
                foreach (MoneyDataSet.PlannedTransactionsRow plan in this.PlannedTransactions.Where(p => (p.IsStartTimeNull())))
                {
                    list.Add(new ActivePlannedTransactionEntry(DateTime.MaxValue, plan));
                }
            }
            return list;
        }
        
        #endregion

        #region Tag management

        public class TagUsagesEntry
        {
            public TagUsagesEntry(String title, int usages)
            {
                Title = title;
                Usages = usages;
            }

            public String Title { get; set; }
            public int Usages { get; set; }
        }

        public IEnumerable<String> Tags
        {
            get { return this.TagUsages.OrderByDescending(o => (o.Usages)).Select(t => (t.Title)); }
        }

        public IEnumerable<TagUsagesEntry> TagUsages
        {
            get
            {
                List<TagUsagesEntry> list = new List<TagUsagesEntry>();

                foreach (MoneyDataSet.TagsRow tag in ds.Tags)
                {
                    int usages = 0;
                    usages += this.Transactions.Where(t => (t.GetTransactionTagsRows().Where(tt => (tt.TagID == tag.ID)).Any())).Count();
                    usages += this.PlannedTransactions.Where(p => (p.GetPlannedTransactionTagsRows().Where(pt => (pt.TagID == tag.ID)).Any())).Count();
                    usages += this.Accounts.Where(a => (a.GetAccountTagsRows().Where(at => (at.TagID == tag.ID)).Any())).Count();
                    if (usages > 0)
                    {
                        list.Add(new TagUsagesEntry(tag.Title, usages));
                    }
                }
                return list;
            }
        }

        public void DeleteTag(String tag)
        {
            try
            {
                ds.Tags.RemoveTagsRow(ds.Tags.Single(t => (t.Title.Equals(tag))));
                ds.AcceptChanges();
            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(e: e);
            }
        }

        public bool RenameTag(String currentTitle, String newTitle)
        {
            try
            {
                if (ds.Tags.SingleOrDefault(t => (t.Title.Equals(newTitle))) != null)
                {
                    return false;
                }

                MoneyDataSet.TagsRow tag = ds.Tags.Single(t => (t.Title.Equals(currentTitle)));
                tag.Title = newTitle;
                ds.AcceptChanges();

                return true;
            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(e: e);
                return false;
            }
        }
        
        #endregion

        #region Account management

        public IEnumerable<MoneyDataSet.AccountsRow> Accounts
        {
            get
            {
                return this.AccountsAll.Where(a => (!a.IsHidden));
            }
        }

        public IEnumerable<MoneyDataSet.AccountsRow> AccountsAll
        {
            get
            {
                List<MoneyDataSet.AccountsRow> list = new List<MoneyDataSet.AccountsRow>();

                // add unchanged accounts
                list.AddRange(ds.Accounts.Where(a => ((a.HistoryReferenceID == 0) && (a.IsActive))));

                // get list of changed account groups
                foreach (int historyID in ds.Accounts.Where(a => (a.HistoryReferenceID > 0)).Select(a => (a.HistoryReferenceID)).Distinct())
                {
                    int accountID = ds.Accounts.Where(a => (a.HistoryReferenceID == historyID)).Select(a => (a.ID)).Max();
                    MoneyDataSet.AccountsRow account = GetAccount(accountID);
                    if (account.IsActive)
                    {
                        list.Add(account);
                    }
                }

                return list;
            }
        }

        public IEnumerable<MoneyDataSet.AccountsRow> GetAccounts(MoneyDataSet.AccountTypesRow firstAccountType = null,  
            bool showOnlyFirstType = false)
        {
            if (firstAccountType != null)
            {
                List<MoneyDataSet.AccountsRow> sorted = new List<MoneyDataSet.AccountsRow>();
                sorted.AddRange(this.Accounts.Where(a => (a.TypeID.Equals(firstAccountType.ID))));
                if (!showOnlyFirstType)
                {
                    sorted.AddRange(this.Accounts.Where(a => ((!a.TypeID.Equals(firstAccountType.ID)) && 
                        (a.AccountTypesRow.IsDebit == firstAccountType.IsDebit))));
                    sorted.AddRange(this.Accounts.Where(a => (a.AccountTypesRow.IsDebit != firstAccountType.IsDebit)));
                }
                return sorted;
            }
            else
            {
                return this.Accounts;
            }
        }

        public double GetAccountBalace(MoneyDataSet.AccountsRow account, DateTime date)
        {
            double amount = 0;

            if (account.IsActive)
            {
                // checking for account creation time
                DateTime creationTime = account.EntryTime;
                if ((!account.IsHistoryReferenceIDNull()) && ((account.HistoryReferenceID != 0)))
                {
                    creationTime = ds.Accounts.Where(a => ((!a.IsHistoryReferenceIDNull()) && (a.HistoryReferenceID == account.HistoryReferenceID))).Select(s => (s.EntryTime)).Min();
                }
                if (creationTime < date)
                {
                    // rolling back transactions until we pass required date
                    amount = account.Balance;
                    IOrderedEnumerable<MoneyDataSet.TransactionsRow> transactions = null;
                    if ((account.IsHistoryReferenceIDNull()) || (account.HistoryReferenceID == 0))
                    {
                        transactions = this.Transactions.Where(t => ((t.AccountID == account.ID))).OrderByDescending(o => (o.TransactionTime));
                    }
                    else
                    {
                        transactions = this.Transactions.Where(t => ((!t.AccountRow.IsHistoryReferenceIDNull()) &&
                            (t.AccountRow.HistoryReferenceID == account.HistoryReferenceID))).OrderByDescending(o => (o.TransactionTime));
                    }

                    foreach (MoneyDataSet.TransactionsRow transaction in transactions)
                    {
                        if (transaction.TransactionTime < date)
                        {
                            // we've passed required date, current amount is actual balance
                            return amount;
                        }

                        if (transaction.TransactionTypesRow.IsIncome)
                        {
                            amount -= transaction.Amount;
                        }
                        else
                        {
                            amount += transaction.Amount;
                        }
                    }
                    // no transactions found before that date
                }
            }
            return amount;
        }

        private MoneyDataSet.AccountsRow cloneAccount(MoneyDataSet.AccountsRow source)
        {
            MoneyDataSet.AccountsRow newAccount = ds.Accounts.NewAccountsRow();
            newAccount.HistoryReferenceID = source.HistoryReferenceID;
            newAccount.Title = source.Title;
            newAccount.Description = source.Description;
            newAccount.CurrencyID = source.CurrencyID;
            newAccount.TypeID = source.TypeID;
            newAccount.Balance = source.Balance;
            newAccount.IsActive = source.IsActive;
            newAccount.IsHidden = source.IsHidden;
            newAccount.EntryTime = DateTime.Now;
            ds.Accounts.AddAccountsRow(newAccount);
            foreach (MoneyDataSet.TagsRow tag in source.GetAccountTagsRows().Select(at => (at.TagRow)))
            {
                ds.AccountTags.AddAccountTagsRow(newAccount, tag);
            }
            return newAccount;
        }

        public MoneyDataSet.AccountsRow GetAccount(int id)
        {
            return ds.Accounts.SingleOrDefault(a => (a.ID == id));
        }

        public IEnumerable<String> GetAccountTagStrings(MoneyDataSet.AccountsRow account)
        {
            return ds.AccountTags.Where(t => (t.AccountID == account.ID)).Select(at => (at.TagRow.Title));
        }

        public void DeleteAccount(int accountID)
        {
            MoneyDataSet.AccountsRow account = GetAccount(accountID);
            if (account.HistoryReferenceID == 0)
            {
                account.HistoryReferenceID = accountID;
            }
            MoneyDataSet.AccountsRow newAccount = cloneAccount(account);
            newAccount.IsActive = false;
            ds.AcceptChanges();
        }

        public IEnumerable<MoneyDataSet.AccountTypesRow> GetAccountTypes(bool? isDebit = null)
        {
            if (isDebit == null)
            {
                return ds.AccountTypes.OrderBy(o => (o.SortOrder));
            }
            else
            {
                return ds.AccountTypes.Where(at => (at.IsDebit == isDebit)).OrderBy(o => (o.SortOrder));
            }
        }

        public IEnumerable<MoneyDataSet.AccountTypesRow> GetAccountTypes(MoneyDataSet.AccountTypesRow selected, bool onlySelected = false)
        {
            List<MoneyDataSet.AccountTypesRow> list = new List<MoneyDataSet.AccountTypesRow>();
            list.Add(selected);
            if (!onlySelected)
            {
                list.AddRange(ds.AccountTypes.Where(at => ((at.IsDebit == selected.IsDebit) && (!at.ID.Equals(selected.ID)))).OrderBy(o => (o.SortOrder)));
            }
            return list;
        }

        public MoneyDataSet.AccountsRow UpdateAccount(int accountID, String title, String description, bool isHidden, IEnumerable<String> tags)
        {
            MoneyDataSet.AccountsRow account = GetAccount(accountID); 
            if (account.HistoryReferenceID == 0)
            {
                account.HistoryReferenceID = accountID;
            }

            MoneyDataSet.AccountsRow newAccount = cloneAccount(account);

            newAccount.Title = title;
            newAccount.Description = description;
            newAccount.EntryTime = DateTime.Now;
            newAccount.IsHidden = isHidden;

            addAccountTags(newAccount, tags);

            ds.AcceptChanges();

            return newAccount;
        }

        public MoneyDataSet.AccountsRow PreCreateAccount(MoneyDataSet.AccountTypesRow type, String title, String description, MoneyDataSet.CurrenciesRow currency, 
            double balance)
        {
            MoneyDataSet.AccountsRow account = ds.Accounts.NewAccountsRow();

            account.Title = title;
            account.Description = description;
            account.CurrenciesRow = currency;
            account.AccountTypesRow = type;
            account.Balance = balance;
            account.EntryTime = DateTime.Now;
            account.IsHidden = false;

            return account;
        }

        public MoneyDataSet.AccountsRow CreateAccount(MoneyDataSet.AccountsRow preCreate, IEnumerable<String> tags)
        {
            MoneyDataSet.AccountsRow account = preCreate;

            ds.Accounts.AddAccountsRow(account);
            addAccountTags(account, tags);

            ds.AcceptChanges();

            return account;
        }

        private void addAccountTags(MoneyDataSet.AccountsRow account, IEnumerable<String> tags)
        {
            // removing tags from account
            IEnumerable<MoneyDataSet.AccountTagsRow> atrs = ds.AccountTags.Where(at => (at.AccountID == account.ID)).ToArray();

            foreach (MoneyDataSet.AccountTagsRow at in atrs)
            {
                ds.AccountTags.RemoveAccountTagsRow(at);
            }

            // adding tags to account
            foreach (String tag in tags)
            {
                String lowerTag = tag.ToLower();
                MoneyDataSet.AccountTagsRow at = ds.AccountTags.NewAccountTagsRow();
                at.AccountRow = account;
                if (ds.Tags.Count(t =>(t.Title.Equals(lowerTag))) > 0)
                {
                    at.TagRow = ds.Tags.Single(t => (t.Title.Equals(tag.ToLower())));
                }
                else
                {
                    at.TagRow = ds.Tags.AddTagsRow(lowerTag);
                }
                ds.AccountTags.AddAccountTagsRow(at);
            }

            ds.AcceptChanges();
        }

        private MoneyDataSet.AccountsRow getActualAccount(MoneyDataSet.AccountsRow account)
        {
            if (account == null)
            {
                return null;
            }

            if ((account.IsHistoryReferenceIDNull()) || (account.HistoryReferenceID == 0))
            {
                return account;
            }

            return ds.Accounts.FindByID(ds.Accounts.Where(a => ((!a.IsHistoryReferenceIDNull()) && (a.HistoryReferenceID == account.HistoryReferenceID))).Select(s => (s.ID)).Max());
        }
                
        #endregion

        #region Rules management

        private bool? validationCriteriaValid(MoneyDataSet.ValidationCriteriaRow criteria,
            MoneyDataSet.AccountsRow account, bool accountOnly = false, MoneyDataSet.TransactionsRow transaction = null,
            MoneyDataSet.PlannedTransactionsRow plan = null)
        {
            if (accountOnly)
            {
                if (!((criteria.IsIsTransactionAmountNegativeNull()) &&
                    (criteria.IsIsTransactionAmountPositiveNull()) &&
                    (criteria.IsIsTransactionAmountZeroNull()) &&
                    (criteria.IsIsTransactionIncomeNull()) &&
                    (criteria.IsIsTransactionPaymentNull()) &&
                    (criteria.IsTransactionTypeIDNull())))
                {
                    return null;
                }

                if (!criteria.IsIsAccountBalanceNegativeNull())
                {
                    if ((criteria.IsAccountBalanceNegative) && (account.Balance >= 0))
                    {
                        return false;
                    }
                }

                if (!criteria.IsIsAccountBalancePositiveNull())
                {
                    if ((criteria.IsAccountBalancePositive) && (account.Balance <= 0))
                    {
                        return false;
                    }
                }
            }

            if (!criteria.IsAccountTypeIDNull())
            {
                if (criteria.AccountTypeID != account.AccountTypesRow.ID)
                {
                    return false;
                }
            }


            if (!criteria.IsIsAccountCreditNull())
            {
                if ((criteria.IsAccountCredit) && (account.AccountTypesRow.IsDebit))
                {
                    return false;
                }
            }

            if (!criteria.IsIsAccountDebitNull())
            {
                if ((criteria.IsAccountDebit) && (!account.AccountTypesRow.IsDebit))
                {
                    return false;
                }
            }

            if (!accountOnly)
            {
                if (!criteria.IsIsAccountBalanceNegativeNull())
                {
                    if (transaction != null)
                    {
                        double resultBalance = account.Balance;
                        if (transaction.TransactionTypesRow.IsIncome)
                        {
                            resultBalance += transaction.Amount;
                        }
                        else
                        {
                            resultBalance -= transaction.Amount;
                        }

                        if ((criteria.IsAccountBalanceNegative) && (resultBalance >= 0))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if ((criteria.IsAccountBalanceNegative) && (account.Balance >= 0))
                        {
                            return false;
                        }
                    }
                }

                if (!criteria.IsIsAccountBalancePositiveNull())
                {
                    if (transaction != null)
                    {
                        double resultBalance = account.Balance;
                        if (transaction.TransactionTypesRow.IsIncome)
                        {
                            resultBalance += transaction.Amount;
                        }
                        else
                        {
                            resultBalance -= transaction.Amount;
                        }

                        if ((criteria.IsAccountBalancePositive) && (resultBalance <= 0))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if ((criteria.IsAccountBalancePositive) && (account.Balance <= 0))
                        {
                            return false;
                        }
                    }
                }

                if (!criteria.IsIsTransactionAmountNegativeNull())
                {
                    if (transaction != null)
                    {
                        if ((criteria.IsTransactionAmountNegative) && (transaction.Amount >= 0))
                        {
                            return false;
                        }
                    }
                    else if (plan != null)
                    {
                        if ((criteria.IsTransactionAmountNegative) && (plan.Amount >= 0))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        ErrorHelper.ShowErrorBox(ErrorHelper.Errors.InvalidValidation);
                        Log.Write("Criteria", criteria);
                    }
                }

                if ((!criteria.IsIsTransactionAmountPositiveNull()) && (criteria.IsTransactionAmountPositive))
                {
                    if (transaction != null)
                    {
                        if (transaction.Amount <= 0)
                        {
                            return false;
                        }
                    }
                    else if (plan != null)
                    {
                        if (plan.Amount <= 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        ErrorHelper.ShowErrorBox(ErrorHelper.Errors.InvalidValidation);
                        Log.Write("Criteria", criteria);
                    }
                }

                if ((!criteria.IsIsTransactionAmountZeroNull()) && (criteria.IsTransactionAmountZero))
                {
                    if (transaction != null)
                    {
                        if (transaction.Amount != 0)
                        {
                            return false;
                        }
                    }
                    else if (plan != null)
                    {
                        if (plan.Amount != 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        ErrorHelper.ShowErrorBox(ErrorHelper.Errors.InvalidValidation);
                        Log.Write("Criteria", criteria);
                    }
                }

                if ((!criteria.IsIsTransactionIncomeNull()) && (criteria.IsTransactionIncome))
                {
                    if (transaction != null)
                    {
                        if (!transaction.TransactionTypesRow.IsIncome)
                        {
                            return false;
                        }
                    }
                    else if (plan != null)
                    {
                        if (!plan.TransactionTypeRow.IsIncome)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        ErrorHelper.ShowErrorBox(ErrorHelper.Errors.InvalidValidation);
                        Log.Write("Criteria", criteria);
                    }
                }

                if ((!criteria.IsIsTransactionPaymentNull()) && (criteria.IsTransactionPayment))
                {
                    if (transaction != null)
                    {
                        if (transaction.TransactionTypesRow.IsIncome)
                        {
                            return false;
                        }
                    }
                    else if (plan != null)
                    {
                        if (plan.TransactionTypeRow.IsIncome)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        ErrorHelper.ShowErrorBox(ErrorHelper.Errors.InvalidValidation);
                        Log.Write("Criteria", criteria);
                    }
                }

                if (!criteria.IsTransactionTypeIDNull())
                {
                    if (transaction != null)
                    {
                        if (criteria.TransactionTypeID != transaction.TransactionTypesRow.ID)
                        {
                            return false;
                        }
                    }
                    else if (plan != null)
                    {
                        if (criteria.TransactionTypeID != plan.TransactionTypeRow.ID)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        ErrorHelper.ShowErrorBox(ErrorHelper.Errors.InvalidValidation);
                        Log.Write("Criteria", criteria);
                    }
                }
            }

            return true;
        }

        public ValidationResult Validate(MoneyDataSet.AccountsRow account = null, 
            MoneyDataSet.TransactionsRow transaction = null, 
            MoneyDataSet.PlannedTransactionsRow plan = null)
        {
            bool success = true;
            bool preventAction = false;
            List<String> messages = new List<String>();

            foreach (MoneyDataSet.ValidationRulesRow rule in ds.ValidationRules)
            {
                bool anyApplied = false;
                bool anyFailed = false;

                foreach (MoneyDataSet.ValidationCriteriaRow criteria in ds.ValidationCriteria.Where(c => (c.ValidationRuleID == rule.ID)))
                {
                    // getting rules where only account-related data is not null

                    if (account != null)
                    {
                        bool? result = validationCriteriaValid(criteria, account, true);
                        if (result.HasValue)
                        {
                            if (result.Value)
                            {
                                anyApplied = true;
                            }
                            else
                            {
                                anyFailed = true;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (transaction != null)
                    {
                        bool? result = validationCriteriaValid(criteria, transaction.AccountRow, false, transaction);
                        if (result.HasValue)
                        {
                            if (result.Value)
                            {

                                anyApplied = true;
                            }
                            else
                            {
                                anyFailed = true;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (plan != null)
                    {
                        // TODO: rethink fake accounts concept, or change planned transaction verification
                        MoneyDataSet.AccountsRow fakeAccount = ds.Accounts.NewAccountsRow();
                        fakeAccount.AccountTypesRow = plan.AccountTypeRow;
                        fakeAccount.CurrenciesRow = plan.CurrenciesRow;
                        fakeAccount.Title = String.Empty;
                        fakeAccount.EntryTime = DateTime.Now;
                        fakeAccount.IsActive = true;
                        fakeAccount.Balance = 0;
                        bool? result = validationCriteriaValid(criteria, fakeAccount, false, null, plan);
                        if (result.HasValue)
                        {
                            if (result.Value)
                            {
                                anyApplied = true;
                            }
                            else
                            {
                                anyFailed = true;
                            }
                        }
                    }
                    else
                    {
                        ErrorHelper.ShowErrorBox(ErrorHelper.Errors.InvalidCallToValidate);
                    }
                }

                // compatible rule is checked only if none criteria applied and any was failed
                // this will prevent firing tranasction rules on account creation

                if ((rule.IsCompatible) && (!anyApplied) && (anyFailed))
                {
                    success = false;
                    if (rule.PreventAction)
                    {
                        preventAction = true;
                        messages.Add(String.Format(Resources.Labels.ValidationErrorFormat, rule.Message));
                    }
                    else
                    {
                        messages.Add(String.Format(Resources.Labels.ValidationWarningFormat, rule.Message));
                    }
                }
                else if ((rule.IsIncompatible) && (anyApplied))
                {
                    success = false;
                    if (rule.PreventAction)
                    {
                        preventAction = true;
                        messages.Add(String.Format(Resources.Labels.ValidationErrorFormat, rule.Message));
                    }
                    else
                    {
                        messages.Add(String.Format(Resources.Labels.ValidationWarningFormat, rule.Message));
                    }
                }
            }
            return new ValidationResult(success, preventAction, messages);
        }

        #endregion

        #region Template management

        public IEnumerable<MoneyDataSet.TransactionTemplatesRow> TransactionTemplates
        {
            get 
            { 
                return ds.TransactionTemplates.Where(t => (IsTemplateRelevant(t))).OrderBy(o => (o.SortOrder)); 
            }
        }

        public IEnumerable<MoneyDataSet.TransactionTemplatesRow> GetTransactionTemplates(bool? isIncome)
        {
            if (isIncome.HasValue)
            {
                return ds.TransactionTemplates.Where(t => ((IsTemplateRelevant(t)) && (!t.IsIsIncomeNull()) &&
                    (t.IsIncome == isIncome.Value))).OrderByDescending(o => (o.SortOrder));
            }
            else
            {
                return ds.TransactionTemplates.Where(t => ((IsTemplateRelevant(t)) &&
                    (t.IsIsIncomeNull()))).OrderBy(o => (o.SortOrder));
            }
        }

        public IEnumerable<MoneyDataSet.TransactionTemplatesRow> GetAllTransactionTemplates(bool? isIncome)
        {
            if (isIncome.HasValue)
            {
                return ds.TransactionTemplates.Where(t => ((!t.IsIsIncomeNull()) &&
                    (t.IsIncome == isIncome.Value))).OrderByDescending(o => (o.SortOrder));
            }
            else
            {
                return ds.TransactionTemplates.Where(t => ((t.IsIsIncomeNull()))).OrderBy(o => (o.SortOrder));
            }
        }

        public bool IsTemplateRelevant(MoneyDataSet.TransactionTemplatesRow template)
        {
            if (!template.IsVisible)
            {
                return false;
            }

            if (!GetAccounts(template.AccountTypesRowByFK_AccountTypes_Source_TransactionTemplates, template.ExactSourceAccountType).Any())
            {
                return false;
            }

            if (template.HasDestinationAccount)
            {
                if (!GetAccounts(template.AccountTypesRowByFK_AccountTypes_Destination_TransactionTemplates, template.ExactDestinationAccountType).Any())
                {
                    return false;
                }
            }

            return true;
        }
        
        #endregion

        #region Text entry history management

        public String[] GetTextHistory(String historyID)
        {
            return ds.TextEntryHistory.Where(t => (t.HistoryReferenceID.Equals(historyID))).Select(s => (s.TextLine)).ToArray();
        }

        public void AddTextHistory(String historyID, String textLine)
        {
            int count = ds.TextEntryHistory.Count(t => (t.HistoryReferenceID.Equals(historyID)));
            String line = textLine.Trim();

            if (ds.TextEntryHistory.Count(t => ((t.HistoryReferenceID.Equals(historyID) && t.TextLine.Equals(line)))) > 0)
            {
                // already in the list

                return;
            }
            
            if (count >= Consts.Keeper.MaxHistoryEntries)
            {
                ds.TextEntryHistory.RemoveTextEntryHistoryRow(ds.TextEntryHistory.OrderBy(o => (o.ID)).First(t => (t.HistoryReferenceID.Equals(historyID))));
            }
            ds.TextEntryHistory.AddTextEntryHistoryRow(historyID, textLine);
        }
        
        #endregion

        #region User metadata management

        public void ClearUserMetadata()
        {
            try
            {
                // very dangerous operation...
                IEnumerable<String> templateIDs = ds.TransactionTemplates.Where(t => (t.ID.StartsWith(Consts.Keeper.UserMetadataPrefix))).Select(s => (s.ID)).ToArray();

                foreach (String ID in templateIDs)
                {
                    ds.TransactionTemplates.RemoveTransactionTemplatesRow(ds.TransactionTemplates.FindByID(ID));
                }
                
                IEnumerable<String> transactionTypeIDs = ds.TransactionTypes.Where(t => (t.ID.StartsWith(Consts.Keeper.UserMetadataPrefix))).Select(s => (s.ID)).ToArray();

                foreach (String ID in transactionTypeIDs)
                {
                    ds.TransactionTypes.RemoveTransactionTypesRow(ds.TransactionTypes.FindByID(ID));
                }
                
                IEnumerable<String> accountTypeIDs = ds.AccountTypes.Where(t => (t.ID.StartsWith(Consts.Keeper.UserMetadataPrefix))).Select(s => (s.ID)).ToArray();

                foreach (String ID in accountTypeIDs)
                {
                    ds.AccountTypes.RemoveAccountTypesRow(ds.AccountTypes.FindByID(ID));
                }
                
                IEnumerable<String> currencyIDs = ds.Currencies.Where(t => (t.ID.StartsWith(Consts.Keeper.UserMetadataPrefix))).Select(s => (s.ID)).ToArray();

                foreach (String ID in currencyIDs)
                {
                    ds.Currencies.RemoveCurrenciesRow(ds.Currencies.FindByID(ID));
                }
                
                ds.AcceptChanges();
            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(e: e);
            }
        }

        #endregion

    }
}
