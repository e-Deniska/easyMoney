using System;
using System.Globalization;
using System.Collections.Generic;
namespace easyMoney.Data 
{
    public partial class MoneyDataSet 
    {

        #region ID constants

        public class IDs
        {
            public class SpecialColumns
            {
                public const String FullTitleColumnName = "FullTitle";
            }

            public class TransactionTypes
            {
                public const String Salary = "SALARY";
                public const String Dividents = "DIVIDENTS";
                public const String Interest = "INTEREST";
                public const String Shopping = "SHOPPING";
                public const String Purchase = "PURCHASE";
                public const String Payment = "PAYMENT";
                public const String CreditRepayment = "CREDITREPAYMENT";
                public const String Fine = "FINE";
                public const String GiftReceived = "GIFTIN";
                public const String Bonus = "BONUS";
                public const String Prize = "PRIZE";
                public const String Tax = "TAX";
                public const String TransferOut = "TRANSFEROUT";
                public const String TransferIn = "TRANSFERIN";
                public const String Charity = "CHARITY";
                public const String GiftGiven = "GIFTOUT";
                public const String Medical = "MEDICAL";
                public const String InsuranceFee = "INSURANCEOUT";
                public const String BenefitPayment = "INSURANCEIN";
                public const String Utilities = "UTILITITES";
                public const String Services = "SERVICES";
                public const String Return = "RETURN";
                public const String TaxReturn = "TAXRETURN";
                public const String Lend = "LEND";
                public const String Borrow = "BORROW";
                //public const String PayDebt = "PAYDEBT";
                public const String CreditReduction = "CREDITREDUCTION";
                //public const String BorrowedReduction = "BORROWEDREDUCTION";
                public const String DebtReduction = "DEBTREDUCTION";
                public const String BorrowedIncrease = "BORROWEDINCREASE";
                public const String DebtIncrease = "DEBTINCREASE";
                public const String DebtReturned = "DEBTRETURNED";
                public const String Correction = "CORRECTION";
                public const String VehicleExpenses = "VEHICLEEXPENSES";
                public const String Entertainment = "ENTERTAINMENT";
                public const String ItemSold = "ITEMSOLD";
                public const String Sport = "SPORT";
                public const String Dinner = "DINNER";
                public const String Transportation = "TRANSPORTATION";
                public const String PetExpenses = "PETEXPENSES";
                public const String Communication = "COMMUNICATION";
                public const String OtherIncome = "OTHERINCOME";
                public const String OtherPayment = "OTHERPAYMENT";
                public const String CosmeticTreatments = "COSMETICTREATMENTS";
            }

            public class AccountTypes
            {
                public const String Cash = "CASH";
                public const String DebitCard = "DEBITCARD";
                public const String CreditCard = "CREDITCARD";
                public const String SavingsAccount = "SAVINGSACCOUNT";
                public const String CheckingAccount = "CHECKINGACCOUNT";
                public const String Loan = "LOAN";
                public const String Borrowed = "BORROWED";
                public const String Lended = "LENDED";
            }

            public class Recurrencies
            {
                public const String None = "NONE";
                public const String Daily = "DAILY";
                public const String Weekly = "WEEKLY";
                public const String Biweekly = "BIWEEKLY";
                public const String Monthly = "MONTHLY";
                public const String Quarterly = "QUARTERLY";
                public const String Yearly = "YEARLY";
            }

            public class Currencies
            {
                public const String USDollar = "USD";
                public const String Euro = "EUR";
                public const String Rouble = "RUR";
            }

            public class ValidationRules
            {
                public const String DebitPositiveBalance = "DEBITPOSITIVEBALANCE";
                public const String CreditAccountsNegativeBalance = "CREDITNEGATIVEBALANCE";
                public const String CreditCardNegativeBalance = "CREDITCARDNEGATIVEBALANCE";
                public const String TransactionNonZero = "TRANSACTIONNONZERO";
                public const String OnlyCorrectionNegative = "ONLYCORRECTIONNEGATIVE";
            }

            public class TransactionTemplates
            {
                public const String CreditRepayment = "CREDITREPAYMENT";
                public const String Shopping = "SHOPPING";
                public const String Salary = "SALARY";
                public const String Transfer = "TRANSFER";
                public const String DebtReturned = "DEBTRETURNED";
                //public const String PayDebt = "PAYDEBT";
                public const String Lended = "LENDED";
                public const String Borrowed = "BORROWED";
                public const String Dividents = "DIVIDENTS";
                public const String Interest = "INTEREST";
                public const String Purchase = "PURCHASE";
                public const String Fine = "FINE";
                public const String GiftReceived = "GIFTIN";
                public const String Bonus = "BONUS";
                public const String Prize = "PRIZE";
                public const String Tax = "TAX";
                public const String Charity = "CHARITY";
                public const String GiftGiven = "GIFTOUT";
                public const String Medical = "MEDICAL";
                public const String InsuranceFee = "INSURANCEOUT";
                public const String BenefitPayment = "INSURANCEIN";
                public const String Utilities = "UTILITITES";
                public const String Services = "SERVICES";
                public const String Return = "RETURN";
                public const String TaxReturn = "TAXRETURN";
                public const String VehicleExpenses = "VEHICLEEXPENSES";
                public const String Entertainment = "ENTERTAINMENT";
                public const String ItemSold = "ITEMSOLD";
                public const String Sport = "SPORT";
                public const String Dinner = "DINNER";
                public const String Transportation = "TRANSPORTATION";
                public const String PetExpenses = "PETEXPENSES";
                public const String Communication = "COMMUNICATION";
                public const String OtherIncome = "OTHERINCOME";
                public const String OtherPayment = "OTHERPAYMENT";
                public const String CosmeticTreatments = "COSMETICTREATMENTS";
            }
        }

        #endregion

        #region Planned transactions custom columns

        public partial class PlannedTransactionsRow
        {
            private const String ShortTitleFormat = "{0}{1}";
            private const String FullTitleFormat = "{0}, {1}{2}";
            private const String NoRecurrencyFormat = "{0} ({1:d})";
            private const String RecurrencyWithEndDateFormat = "{0} ({1}, {2:d}-{3:d})";
            private const String RecurrencyWithNoEndDateFormat = "{0} ({1}, {2:d}-...)";

            private const String OnlyRecurrencyWithEndDateFormat = "{0}, {1:d}-{2:d}";
            private const String OnlyRecurrencyWithNoEndDateFormat = "{0}, {1:d}-...";

            public String FullTitle
            {
                get
                {
                    String title = (String.IsNullOrWhiteSpace(this.Title) ?
                        String.Format(ShortTitleFormat, this.TransactionTypeRow.Title, (this.IsAggregated ? Resources.Labels.AggregatedLabel : String.Empty)) :
                        String.Format(FullTitleFormat, this.TransactionTypeRow.Title, this.Title,
                            (this.IsAggregated ? Resources.Labels.AggregatedLabel : String.Empty)));

                    if (this.IsStartTimeNull())
                    {
                        return title;
                    }
                    else
                    {
                        return this.RecurrencyID.Equals(MoneyDataSet.IDs.Recurrencies.None) ? String.Format(NoRecurrencyFormat, title, this.StartTime) :
                            (this.IsEndTimeNull() ? String.Format(RecurrencyWithNoEndDateFormat, title, this.RecurrenciesRow.Title.ToLower(), this.StartTime) :
                                 String.Format(RecurrencyWithEndDateFormat, title, this.RecurrenciesRow.Title.ToLower(), this.StartTime, this.EndTime));
                    }
                }
            }

            public String DateRecurrency
            {
                get
                {
                    if (this.IsStartTimeNull())
                    {
                        return Resources.Labels.NoDate;
                    }
                    else
                    {
                        return this.RecurrencyID.Equals(MoneyDataSet.IDs.Recurrencies.None) ? this.StartTime.ToShortDateString() :
                            (this.IsEndTimeNull() ? String.Format(OnlyRecurrencyWithNoEndDateFormat, this.RecurrenciesRow.Title.ToLower(), this.StartTime) :
                                 String.Format(OnlyRecurrencyWithEndDateFormat, this.RecurrenciesRow.Title.ToLower(), this.StartTime, this.EndTime));
                    }
                }
            }
        }

        #endregion

        #region Transactions custom columns

        public partial class TransactionsRow
        {
            private const String TitleFormat = "{0}, {1}";
            private const String FullFormat = "[{0:d}] {1}";

            public String FullTitle
            {
                get
                {
                    return String.Format(FullFormat, this.TransactionTime, 
                        (String.IsNullOrWhiteSpace(this.Title) ? this.TransactionTypesRow.Title : String.Format(TitleFormat, this.TransactionTypesRow.Title, this.Title)));
                }
            }

            public bool IsStasticicCountable
            {
                get
                {
                    return !((this.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.Correction)) ||
                        (this.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.TransferIn)) ||
                        (this.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.TransferOut)) ||
                        (this.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.DebtReduction)) ||
                        (this.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.CreditReduction)));
                }
            }
        }

        #endregion

        #region Accounts custom columns

        public partial class AccountsRow
        {
            private const String TitleFormat = "{0}, {1}";

            public String FullTitle
            {
                get
                {
                    return (String.IsNullOrWhiteSpace(this.Title) ? this.AccountTypesRow.Title : String.Format(TitleFormat, this.AccountTypesRow.Title, this.Title));
                }
            }
        }

        #endregion

        #region Currency custom columns

        public partial class CurrenciesRow
        {
            private static Dictionary<String, CultureInfo> cachedCultures = new Dictionary<String, CultureInfo>();

            public CultureInfo CurrencyCultureInfo
            {
                get
                {
                    if (!cachedCultures.ContainsKey(this.CurrencyCulture))
                    {
                        cachedCultures.Add(this.CurrencyCulture, CultureInfo.CreateSpecificCulture(this.CurrencyCulture));
                    }

                    return cachedCultures[this.CurrencyCulture];
                }
            }
        }

        #endregion

    }
}
