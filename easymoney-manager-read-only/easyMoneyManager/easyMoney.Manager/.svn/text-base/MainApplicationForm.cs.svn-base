using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using easyMoney.Controls;
using easyMoney.Data;
using easyMoney.Setup;
using easyMoney.SimpleReports;
using easyMoney.Utilities;
using System.Windows.Forms.DataVisualization.Charting;
using easyMoney.Manager.Forms;

namespace easyMoney.Manager
{

    public partial class MainApplicationForm : Form
    {

        #region Form members

        private MoneyDataKeeper keeper = null;

        #endregion

        #region Form loading / closing code

        public MainApplicationForm()
        {
            LocalizationHelper.SetThreadLocale();

            InitializeComponent();

            if ((Parameters.MainWindowTop != -1) && (Parameters.MainWindowLeft != -1) && (Parameters.MainWindowHeight != -1) && (Parameters.MainWindowWidth != -1))
            {
                this.Left = Parameters.MainWindowLeft;
                this.Top = Parameters.MainWindowTop;
                this.Height = Parameters.MainWindowHeight;
                this.Width = Parameters.MainWindowWidth;
                this.StartPosition = FormStartPosition.Manual;
            }
            if (Parameters.MainWindowMaximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// Set form title according to parameters
        /// </summary>
        private void updateFormTitle()
        {
            if (Parameters.ShowFilenameInTitle)
            {
                this.Text = String.Format(Resources.Labels.PortableFormTitleFormat, Consts.Application.Version, keeper.Filename);
            }
            else
            {
                this.Text = String.Format(Resources.Labels.DefaultFormTitleFormat, Consts.Application.Version);
            }
        }

        /// <summary>
        /// Form load handler
        /// </summary>
        private void MainApplicationForm_Load(object sender, EventArgs e)
        {
            fdSaveData.DefaultExt = Consts.Application.DefaultExtension;
            fdSaveData.Filter = Resources.Labels.FileFilter;
            fdOpenData.DefaultExt = Consts.Application.DefaultExtension;
            fdOpenData.Filter = Resources.Labels.FileFilter;

            keeper = MoneyDataKeeper.Instance;

            if ((Environment.GetCommandLineArgs().Count() == 1) && (Parameters.ShowOpenDialogEachStart))
            {
                if (fdOpenData.ShowDialog(this) == DialogResult.OK)
                {
                    keeper.Password = String.Empty;
                    keeper.Filename = fdOpenData.FileName;
                }
            }

            FileLoadForm frmLoad = new FileLoadForm(Resources.Labels.ApplicationLoadingMessage, true);
            frmLoad.ShowDialog(this);

            updateFormTitle();

            imageListTabs.ImageSize = new System.Drawing.Size(16, 16);
            imageListTabs.ColorDepth = ColorDepth.Depth32Bit;
            imageListTabs.TransparentColor = Color.Transparent;
            imageListTabs.Images.Add(Consts.ImageKeys.TabAbout, Properties.Resources.information);
            imageListTabs.Images.Add(Consts.ImageKeys.TabPlans, Properties.Resources.date);
            imageListTabs.Images.Add(Consts.ImageKeys.TabSettings, Properties.Resources.cog);
            imageListTabs.Images.Add(Consts.ImageKeys.TabReports, Properties.Resources.chart_bar);
            imageListTabs.Images.Add(Consts.ImageKeys.TabWelcome, Properties.Resources.star);
            imageListTabs.Images.Add(Consts.ImageKeys.TabTransactions, Properties.Resources.table_multiple);
            imageListTabs.Images.Add(Consts.ImageKeys.TabSearch, Properties.Resources.magnifier);
            imageListTabs.Images.Add(Consts.ImageKeys.TabAccounts, Properties.Resources.book_open);

            tabWelcome.ImageKey = Consts.ImageKeys.TabWelcome;
            tabAbout.ImageKey = Consts.ImageKeys.TabAbout;
            tabPlannedTransactions.ImageKey = Consts.ImageKeys.TabPlans;
            tabSettings.ImageKey = Consts.ImageKeys.TabSettings;
            tabReports.ImageKey = Consts.ImageKeys.TabReports;
            tabTransactions.ImageKey = Consts.ImageKeys.TabTransactions;
            tabSearch.ImageKey = Consts.ImageKeys.TabSearch;
            tabAccounts.ImageKey = Consts.ImageKeys.TabAccounts;

            // setting data binding column names
            lbAccounts.DisplayMember = MoneyDataSet.IDs.SpecialColumns.FullTitleColumnName;
            lbAccounts.ValueMember = keeper.DataSet.Accounts.IDColumn.ColumnName;

            lbTransactions.DisplayMember = MoneyDataSet.IDs.SpecialColumns.FullTitleColumnName;
            lbTransactions.ValueMember = keeper.DataSet.Transactions.IDColumn.ColumnName;

            lbPlannedTransactions.DisplayMember = MoneyDataSet.IDs.SpecialColumns.FullTitleColumnName;
            lbPlannedTransactions.ValueMember = keeper.DataSet.PlannedTransactions.IDColumn.ColumnName;
                        
            // update accounts tab
            updateAccountsTab();

            // setting transaction tab
            updateTransactionsTab();

            // setting planned transaction tab
            updatePlannedTransactionsTab();
            
            // updating welcome screen
            updateWelcomeTab();

            // update Reports tab
            lbReports.DisplayMember = Reports.ReportEntry.FieldTitle;
            lbReports.ValueMember = Reports.ReportEntry.FieldID;
            lbReports.DataSource = Reports.GetAvailableReports();
            
            // update Settings tab
            updateSettingsTab();

            // setting about tab
            lblVersionApplication.Text = String.Format(Consts.UI.FullVersionFormat, Consts.Application.Version, 
                Consts.Application.VersionCodeName);
            lblVersionAssembly.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblBuildDate.Text = (new DateTime(2000, 1, 1)).AddDays(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build).ToShortDateString();

            // update tag list on search tab
            updateTagCloud();
            
            this.Activate();

            if (!String.IsNullOrWhiteSpace(keeper.ValidationErrors))
            {
                ErrorHelper.ShowErrorBox(keeper.ValidationErrors);
            }

            if (!Parameters.IntroductionShown) 
            {
                showIntroduction();
                Parameters.IntroductionShown = true;
            }

            if ((Parameters.CheckForUpdates) && (Parameters.LastUpdateDate.AddDays(Consts.Application.AutoUpdatePeriod) < DateTime.Now))
            {
                bgwUpdateCheck.RunWorkerAsync();
                Parameters.LastUpdateDate = DateTime.Now;
            }
            (new Forms.WelcomeScreenForm()).Show();
        }

        /// <summary>
        /// Shows introduction dialog
        /// </summary>
        private void showIntroduction()
        {
            try
            {
                List<IntroductionForm.Page> wizardPages = new List<IntroductionForm.Page>();
                wizardPages.Add(new IntroductionForm.Page(Resources.Introduction.WelcomeTitle, Resources.Introduction.WelcomeText));
                wizardPages.Add(new IntroductionForm.Page(Resources.Introduction.AccountsTitle, Resources.Introduction.AccountsText));
                wizardPages.Add(new IntroductionForm.Page(Resources.Introduction.TransactionsTitle, Resources.Introduction.TransactionsText));
                wizardPages.Add(new IntroductionForm.Page(Resources.Introduction.PlansTitle, Resources.Introduction.PlansText));
                wizardPages.Add(new IntroductionForm.Page(Resources.Introduction.TagsTitle, Resources.Introduction.TagsText));
                wizardPages.Add(new IntroductionForm.Page(Resources.Introduction.ReportsTitle, Resources.Introduction.ReportsText));
                wizardPages.Add(new IntroductionForm.Page(Resources.Introduction.NextStepsTitle, Resources.Introduction.NextStepsText));

                IntroductionForm wizard = new IntroductionForm(wizardPages);
                wizard.Icon = this.Icon;
                wizard.Text = Resources.Introduction.WelcomeTitle;
                wizard.ShowDialog(this);
            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(ErrorHelper.Errors.ErrorShowingIntroduction, e);
            }
        }

        /// <summary>
        /// Form closing event hanlder
        /// </summary>
        private void MainApplicationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            keeper.FileSave();
            if (this.WindowState == FormWindowState.Normal)
            {
                Parameters.MainWindowLeft = this.Left;
                Parameters.MainWindowTop = this.Top;
                Parameters.MainWindowHeight = this.Height;
                Parameters.MainWindowWidth = this.Width;
            }
            else
            {
                Parameters.MainWindowLeft = this.RestoreBounds.Left;
                Parameters.MainWindowTop = this.RestoreBounds.Top;
                Parameters.MainWindowHeight = this.RestoreBounds.Height;
                Parameters.MainWindowWidth = this.RestoreBounds.Width;
            }
            Parameters.MainWindowMaximized = (this.WindowState == FormWindowState.Maximized);
            Parameters.SearchTabSplitterPosition = scSearchTabSplit.SplitterDistance;
            Parameters.Save();
        }
        
        #endregion

        #region Welcome tab routines (transferred)

        /// <summary>
        /// Update all information on welcome tab
        /// </summary>
        private void updateWelcomeTab()
        {
            updateAssets();
            updateDebts();
            updateMonthPlans();
            updateRecentTransactions();
            updateNewTransactionList();
            updateSearchSuggestions();
            updateNewPlanList();
        }

        /// <summary>
        /// Update list of text suggestions on search boxes
        /// </summary>
        private void updateSearchSuggestions()
        {
            tsstbSearchString.AutoCompleteCustomSource.Clear();
            tsstbSearchText.AutoCompleteCustomSource.Clear();
            tsstbSearchString.AutoCompleteCustomSource.AddRange(keeper.GetTextHistory(Consts.Keeper.HistorySearchID));
            tsstbSearchText.AutoCompleteCustomSource.AddRange(keeper.GetTextHistory(Consts.Keeper.HistorySearchID));
        }

        /// <summary>
        /// Add template to a specific list
        /// </summary>
        /// <param name="collection">List, where to add template</param>
        /// <param name="template">Template to add</param>
        /// <param name="onClick">Click handlers</param>
        private void insertTemplate(ToolStripItemCollection collection, MoneyDataSet.TransactionTemplatesRow template, EventHandler onClick)
        {
            Image image = null;
            if (template.ID.Equals(MoneyDataSet.IDs.TransactionTemplates.Transfer))
            {
                image = Properties.Resources.table_relationship;
            }
            ToolStripMenuItem tsmiFromTemplate = new ToolStripMenuItem(template.Title, image, onClick);
            tsmiFromTemplate.Tag = template;
            tsmiFromTemplate.ToolTipText = template.Message;

            collection.Add(tsmiFromTemplate);
        }

        /// <summary>
        /// Update list of possible new transactions
        /// </summary>
        private void updateNewTransactionList()
        {
            tsddbNewTransaction.DropDownItems.Clear();

            if (!keeper.Accounts.Any())
            {
                ToolStripMenuItem tsmiCreateAccountsFirst = new ToolStripMenuItem(Resources.Labels.CreateAccountsFirst,
                    Properties.Resources.book_open, tsmiCreateAccountsFirst_Click);
                tsmiCreateAccountsFirst.ImageScaling = ToolStripItemImageScaling.None;
                tsddbNewTransaction.DropDownItems.Add(tsmiCreateAccountsFirst);
                return;
            }

            bool groupExist = false;
            
            // payment transactions
            tsmiNewPaymentTransaction.DropDownItems.Clear();
            tsddbNewTransaction.DropDownItems.Add(tsmiNewPaymentTransaction);
            foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.GetTransactionTemplates(false))
            {
                insertTemplate(tsmiNewPaymentTransaction.DropDownItems, template, tsmiTransactionFromTemplate_Click);
                groupExist = true;
            }

            // income transactions
            tsmiNewIncomeTransaction.DropDownItems.Clear();
            tsddbNewTransaction.DropDownItems.Add(tsmiNewIncomeTransaction);
            foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.GetTransactionTemplates(true))
            {
                insertTemplate(tsmiNewIncomeTransaction.DropDownItems, template, tsmiTransactionFromTemplate_Click);
                groupExist = true;
            }

            if (groupExist)
            {
                ToolStripSeparator tssTransactionSeparator = new ToolStripSeparator();
                tsddbNewTransaction.DropDownItems.Add(tssTransactionSeparator);
            }

            // undefined transactions
            foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.GetTransactionTemplates(null))
            {
                insertTemplate(tsddbNewTransaction.DropDownItems, template, tsmiTransactionFromTemplate_Click);
            }

            ToolStripMenuItem tsmiAccountCorrection = new ToolStripMenuItem(Resources.Labels.AccountCorrectionLabel,
                Properties.Resources.calculator, tsmiAccountCorrection_Click);
            tsmiAccountBalanceCorrection.ImageScaling = ToolStripItemImageScaling.None;
            tsmiAccountBalanceCorrection.ToolTipText = Resources.Labels.AccountBalanceButtonToolTip;
            tsddbNewTransaction.DropDownItems.Add(tsmiAccountCorrection);
        }

        /// <summary>
        /// Update list of possible plans
        /// </summary>
        private void updateNewPlanList()
        {
            tsddbNewPlan.DropDownItems.Clear();

            bool groupExist = false;

            // payment transactions
            tsmiPlanAPayment.DropDownItems.Clear();
            tsddbNewPlan.DropDownItems.Add(tsmiPlanAPayment);
            foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.GetAllTransactionTemplates(false))
            {
                insertTemplate(tsmiPlanAPayment.DropDownItems, template, tsmiPlanFromTemplate_Click);
                groupExist = true;
            }

            // income transactions
            tsmiPlanAnIncome.DropDownItems.Clear();
            tsddbNewPlan.DropDownItems.Add(tsmiPlanAnIncome);
            foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.GetAllTransactionTemplates(true))
            {
                insertTemplate(tsmiPlanAnIncome.DropDownItems, template, tsmiPlanFromTemplate_Click);
                groupExist = true;
            }

            if (groupExist)
            {
                ToolStripSeparator tssTransactionSeparator = new ToolStripSeparator();
                tsddbNewPlan.DropDownItems.Add(tssTransactionSeparator);
            }

            // undefined transactions
            foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.GetAllTransactionTemplates(null))
            {
                insertTemplate(tsddbNewPlan.DropDownItems, template, tsmiPlanFromTemplate_Click);
            }
        }

        /// <summary>
        /// Update list of plans for current month
        /// </summary>
        private void updateMonthPlans()
        {
            DateTime start = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Month, 1);
            DateTime end = start.AddMonths(1).AddDays(-1);
            double monthIncome = 0, monthSpending = 0;
            bool datePassed = true;
            dgvPlans.Rows.Clear();
            foreach (MoneyDataKeeper.ActivePlannedTransactionEntry entry in keeper.GetActivePlannedTransactions(start, end).OrderBy(o => (o.Date)))
            {
                Image image;
                Color textColor = Color.Black;
                Color backColor = Color.White;
                String typeToolTip = String.Empty;

                if (keeper.IsPlannedTransactionImplemented(entry.PlannedTransaction, entry.Date))
                {
                    image = entry.PlannedTransaction.TransactionTypeRow.IsIncome ? Properties.Resources.coins : Properties.Resources.basket;
                    typeToolTip = Resources.Labels.PlanImplementedToolTip;
                    textColor = Color.DarkGreen;
                    backColor = ControlPaint.LightLight(Color.LightGreen);
                }
                else if (entry.Date >= DateTime.Now.Date)
                {
                    image = entry.PlannedTransaction.TransactionTypeRow.IsIncome ? Properties.Resources.coins_add : Properties.Resources.basket_add;
                    typeToolTip = Resources.Labels.PlanNotImplementedYetToolTip;
                    //textColor = Color.DarkBlue;
                    //backColor = ControlPaint.LightLight(Color.LightBlue);
                }
                else
                {
                    image = entry.PlannedTransaction.TransactionTypeRow.IsIncome ? Properties.Resources.coins_delete : Properties.Resources.basket_delete;
                    typeToolTip = Resources.Labels.PlanNotImplementedToolTip;
                    if (!entry.PlannedTransaction.IsAggregated)
                    {
                        textColor = Color.DarkRed;
                        backColor = ControlPaint.LightLight(Color.LightCoral);
                    }
                }

                if (entry.PlannedTransaction.TransactionTypeRow.IsIncome)
                {
                    monthIncome += entry.PlannedTransaction.Amount * entry.PlannedTransaction.CurrenciesRow.ExchangeRate;
                }
                else
                {
                    monthSpending += entry.PlannedTransaction.Amount * entry.PlannedTransaction.CurrenciesRow.ExchangeRate;
                }

                int j = dgvPlans.Rows.Add(entry.Date, image, entry.AmountWithCurrency, entry.PlannedTransaction.Title);

                //dgvPlans.Rows[j].DefaultCellStyle.ForeColor = textColor;
                dgvPlans.Rows[j].DefaultCellStyle.BackColor = backColor;
                dgvPlans.Rows[j].DefaultCellStyle.SelectionForeColor = textColor;
                //dgvPlans.Rows[j].DefaultCellStyle.SelectionBackColor = textColor;

                dgvPlans.Rows[j].Tag = entry.PlannedTransaction;

                dgvPlans.Rows[j].Cells[dgvcPlansDate.Name].ToolTipText = entry.FullTitle;
                dgvPlans.Rows[j].Cells[dgvcPlansTransactionType.Name].ToolTipText = typeToolTip;
                dgvPlans.Rows[j].Cells[dgvcPlansAmount.Name].ToolTipText = entry.FullTitle;
                dgvPlans.Rows[j].Cells[dgvcPlansTitle.Name].ToolTipText = entry.FullTitle;

                // put divider between past and future dates in plan list
                if ((datePassed) && (entry.Date > DateTime.Now))
                {
                    if (j > 0)
                    {
                        dgvPlans.Rows[j - 1].DividerHeight++;
                    }
                    datePassed = false;
                }

            }
            dgvcPlansDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvcPlansAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //lblMonthPlannedTotals.Text = String.Format(keeper.GetDefaultCurrency().CurrencyCultureInfo,
            //    Resources.Labels.MonthPlannedTotalsFormat, start.ToString(Consts.UI.MonthFormat).ToLower(), monthIncome, monthSpending);
        }

        /// <summary>
        /// Handler for double click on month plans grid
        /// </summary>
        private void dgvPlans_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lbPlannedTransactions.SelectedItem = dgvPlans.Rows[e.RowIndex].Tag as MoneyDataSet.PlannedTransactionsRow;
            tabsMain.SelectedTab = tabPlannedTransactions;
        }

        /// <summary>
        /// Handler for double click on recent transactions list
        /// </summary>
        private void dgvRecentTransactions_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lbTransactions.SelectedItem = dgvRecentTransactions.Rows[e.RowIndex].Tag as MoneyDataSet.TransactionsRow;
            tabsMain.SelectedTab = tabTransactions;
        }

        /// <summary>
        /// Update list of recent transactions
        /// </summary>
        private void updateRecentTransactions()
        {
            DateTime totalsStart = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Month, 1);
            DateTime recentListStart = DateTime.Now.Date.AddMonths(-1);
            bool currentMonth = true;

            double monthEarned = 0, monthSpent = 0;
            dgvRecentTransactions.Rows.Clear();
            foreach (MoneyDataSet.TransactionsRow transaction in 
                keeper.Transactions.Where(t => (t.TransactionTime >= recentListStart)).OrderByDescending(o => (o.TransactionTime)))
            {
                Image image = transaction.TransactionTypesRow.IsIncome ? Properties.Resources.coins : Properties.Resources.basket;

                String amount = transaction.Amount.ToString(Consts.UI.CurrencyFormat, transaction.AccountRow.CurrenciesRow.CurrencyCultureInfo);

                if (transaction.TransactionTypesRow.ID.Equals(MoneyDataSet.IDs.TransactionTypes.TransferIn))
                {
                    image = Properties.Resources.arrow_in;
                }
                else if (transaction.TransactionTypesRow.ID.Equals(MoneyDataSet.IDs.TransactionTypes.TransferOut))
                {
                    image = Properties.Resources.arrow_out;
                }
                else
                {
                    if (transaction.TransactionTime >= totalsStart)
                    {
                        if ((transaction.TransactionTypesRow.IsIncome) || 
                            ((transaction.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.Correction) &&
                            (transaction.Amount < 0))))
                        {
                            monthEarned += Math.Abs(transaction.Amount) * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                        }
                        else
                        {
                            monthSpent += Math.Abs(transaction.Amount) * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                        }
                    }

                    if (transaction.TransactionTypesRow.ID.Equals(MoneyDataSet.IDs.TransactionTypes.Correction))
                    {
                        image = Properties.Resources.bullet_error;
                        amount = (-transaction.Amount).ToString(Consts.UI.CurrencyFormat, transaction.AccountRow.CurrenciesRow.CurrencyCultureInfo);
                    }
                }

                int j = dgvRecentTransactions.Rows.Add(transaction.TransactionTime, image, amount, transaction.Title);

                dgvRecentTransactions.Rows[j].Tag = transaction;

                String title = String.Format(Consts.UI.RecentTransactionToolTipFormat, 
                    transaction.FullTitle, Environment.NewLine, transaction.AccountRow.FullTitle, amount);

                dgvRecentTransactions.Rows[j].Cells[dgvcRecentDate.Name].ToolTipText = title;
                dgvRecentTransactions.Rows[j].Cells[dgvcRecentTransactionType.Name].ToolTipText = title;
                dgvRecentTransactions.Rows[j].Cells[dgvcRecentAmount.Name].ToolTipText = title;
                dgvRecentTransactions.Rows[j].Cells[dgvcRecentTitle.Name].ToolTipText = title;
                
                if ((currentMonth) && (transaction.TransactionTime.Month != DateTime.Now.Month))
                {
                    if (j > 0)
                    {
                        dgvRecentTransactions.Rows[j - 1].DividerHeight++;
                    }
                    currentMonth = false;
                }
            }
            
            dgvcRecentDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvcRecentAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //lblMonthActualTotals.Text = String.Format(keeper.GetDefaultCurrency().CurrencyCultureInfo,
            //    Resources.Labels.MonthTotalsFormat, totalsStart.ToString(Consts.UI.MonthFormat).ToLower(), monthEarned, monthSpent);
        }

        private void fillAccountsChart(Chart chart, IEnumerable<MoneyDataSet.AccountsRow> accounts)
        {
            chart.Series[0].Points.Clear();
            foreach (MoneyDataSet.AccountsRow account in accounts)
            {
                DataPoint point = new DataPoint(chart.Series[0]);
                point.AxisLabel = account.Title;
                point.YValues = new double[1];
                point.YValues[0] = account.GraphicBalance;
                point.Label = Math.Abs(account.Balance).ToString(Consts.UI.CurrencyFormat, account.CurrenciesRow.CurrencyCultureInfo);
                chart.Series[0].Points.Add(point);
            }
        }

        /// <summary>
        /// Update assests - overall value and graphical presentations
        /// </summary>
        private void updateAssets()
        {
            lblAssets.Text = getTotalAmount(true);
            fillAccountsChart(chartAssets, 
                keeper.Accounts.Where(a => ((a.Balance > 0) || ((a.AccountTypesRow.IsDebit) && (a.Balance == 0)))).OrderBy(o => (o.GraphicBalance)));
        }

        /// <summary>
        /// Update debts - overall value and graphical presentations
        /// </summary>
        private void updateDebts()
        {
            lblDebts.Text = getTotalAmount(false);

            fillAccountsChart(chartDebts,
                keeper.Accounts.Where(a => ((a.Balance < 0) || ((!a.AccountTypesRow.IsDebit) && (a.Balance == 0)))).OrderBy(o => (o.GraphicBalance)));
            /*
            chartDebts.DataSource = .ToList();
            chartDebts.Series[0].XValueMember = keeper.DataSet.Accounts.TitleColumn.ColumnName;
            chartDebts.Series[0].YValueMembers = keeper.DataSet.Accounts.GraphicBalanceColumn.ColumnName;
            chartDebts.DataBind();
             */
        }

        /// <summary>
        /// Create text with overal value of assets/debts in default currency
        /// </summary>
        /// <param name="isAssets">Calculate assests (if false, debts)</param>
        /// <returns>Text with value in default currency</returns>
        private String getTotalAmount(bool isAssets)
        {
            IEnumerable<MoneyDataSet.AccountsRow> accounts = isAssets ? keeper.Accounts.Where(a => (a.Balance > 0)) : keeper.Accounts.Where(a => (a.Balance < 0));
            double value = 0;

            foreach (MoneyDataSet.AccountsRow account in accounts)
            {
                value += account.Balance * account.CurrenciesRow.ExchangeRate;
            }

            return value.ToString(Consts.UI.CurrencyFormat, keeper.GetDefaultCurrency().CurrencyCultureInfo);
        }

        /// <summary>
        /// New transaction based on template menu item click
        /// </summary>
        private void tsmiTransactionFromTemplate_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            TransactionEditForm form = new TransactionEditForm(item.Tag as MoneyDataSet.TransactionTemplatesRow);
            if (form.PreCheck())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    updateWelcomeTab();
                    updateTransactionsTab();
                    updatePlannedTransactionsTab();
                    updateAccountsTab();
                    updateTagCloud();
                }
            }
        }

        /// <summary>
        /// New plan based on template menu item click
        /// </summary>
        private void tsmiPlanFromTemplate_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            PlanEditForm form = new PlanEditForm(item.Tag as MoneyDataSet.TransactionTemplatesRow);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                updateWelcomeTab();
                updatePlannedTransactionsTab();
                updateAccountsTab();
                updateTagCloud();
            }
        }

        /// <summary>
        /// Redirect to accounts tab
        /// </summary>
        private void tsmiCreateAccountsFirst_Click(object sender, EventArgs e)
        {
            tabsMain.SelectedTab = tabAccounts;
        }

        /// <summary>
        /// Show account correction form
        /// </summary>
        private void tsmiAccountCorrection_Click(object sender, EventArgs e)
        {
            if (!keeper.Accounts.Any())
            {
                MessageBox.Show(Resources.Labels.NoAccountsText, Resources.Labels.NoAccountsTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabsMain.SelectedTab = tabAccounts;
                return;
            }

            AccountCorrectionForm form = new AccountCorrectionForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                updateWelcomeTab();
                updateTransactionsTab();
                updateAccountsTab();
            }
        }

        /// <summary>
        /// Handler of KeyDown event on search text box (to start search on Enter key press)
        /// </summary>
        private void tsstbSearchString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                tsbSearch.PerformClick();
            }
        }

        /// <summary>
        /// Search button click handler
        /// </summary>
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            tsstbSearchText.Text = tsstbSearchString.Text;
            tsbDisplaySearchResults.PerformClick();
            tabsMain.SelectedTab = tabSearch;
        }

        /// <summary>
        /// Show month balance report for current month
        /// </summary>
        private void tsbMonthBalance_Click(object sender, EventArgs e)
        {
            Reports.MonthBalanceReport(null);
        }
        
        #endregion

        #region Transaction tab routines (transferred)

        private void deleteTransaction(int transactionID)
        {
            keeper.DeleteTransaction(transactionID);
        }

        private void updateTransactionsTab()
        {
            clearTransactionDetails();
            refreshTransactionsListBox();
        }

        private void refreshTransactionsListBox()
        {
            lbTransactions.DataSource = null;
            lbTransactions.DisplayMember = MoneyDataSet.IDs.SpecialColumns.FullTitleColumnName;
            lbTransactions.ValueMember = keeper.DataSet.Transactions.IDColumn.ColumnName;

            if (cbTransactionsShowAll.Checked)
            {
                lbTransactions.DataSource = keeper.Transactions;
            }
            else
            {
                lbTransactions.DataSource = keeper.Transactions.Where(t => (t.TransactionTime.AddMonths(1) > DateTime.Now)).ToList();
            }

            if (lbAccounts.Items.Count > 0)
            {
                btnAddIncomeTransaction.Enabled = true;
                btnAddPaymentTransaction.Enabled = true;
            }
            else
            {
                btnAddIncomeTransaction.Enabled = false;
                btnAddPaymentTransaction.Enabled = false;
            }
        }


        private void clearTransactionDetails()
        {
            tbTransactionTitle.Text = String.Empty;
            tbTransactionDescription.Text = String.Empty;
            tbTransactionTags.Text = String.Empty;
            tbTransactionAccount.Text = String.Empty;
            tbTransactionType.Text = String.Empty;
            tbTransactionAmount.Text = String.Empty;
            tbTransactionTime.Text = String.Empty;
            tbTransactionPlan.Text = String.Empty;

            if (lbTransactions.Items.Count == 0)
            {
                btnTransactionDelete.Enabled = false;
            }
        }

        private void displayTransactionDetails(MoneyDataSet.TransactionsRow transaction)
        {
            tbTransactionTitle.Text = transaction.Title;
            tbTransactionDescription.Text = transaction.Description;
            tbTransactionTags.Text = String.Join(Consts.UI.EnumerableSeparator, keeper.GetTransactionTagStrings(transaction));
            tbTransactionAccount.Text = transaction.AccountRow.FullTitle;
            tbTransactionType.Text = transaction.TransactionTypesRow.Title;

            double amount = transaction.Amount;
            if (transaction.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.Correction))
            {
                amount *= -1;
            }

            tbTransactionAmount.Text = amount.ToString(Consts.UI.CurrencyFormat, transaction.AccountRow.CurrenciesRow.CurrencyCultureInfo);
            tbTransactionTime.Text = transaction.TransactionTime.ToString(Consts.UI.DateTimeFormat);

            if (transaction.PlannedTransactionsRow != null)
            {
                tbTransactionPlan.Text = transaction.PlannedTransactionsRow.FullTitle;
            }
            else
            {
                tbTransactionPlan.Text = Resources.Labels.TransactionNotPlanned;
            }
            btnTransactionDelete.Enabled = true;
        }

        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            TemplateSelectorForm selector = new TemplateSelectorForm(keeper.GetTransactionTemplates((sender as Button).Equals(btnAddIncomeTransaction)));
            if (selector.ShowDialog(this) == DialogResult.OK)
            {
                TransactionEditForm form = new TransactionEditForm(selector.SelectedTemplate);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    updateWelcomeTab();
                    updateTransactionsTab();
                    updatePlannedTransactionsTab();
                    updateTagCloud();
                    lbTransactions.SelectedItem = form.UpdatedTransaction;
                }
            }
        }

        private bool askDeleteTransaction(MoneyDataSet.TransactionsRow transaction)
        {
            String message = String.Empty;
            if (transaction.IsPairReferenceIDNull())
            {
                message = String.Format(Resources.Labels.DeleteTransactionFormat, transaction.FullTitle);
            }
            else
            {
                message = String.Format(Resources.Labels.DeletePairedTransactionFormat, transaction.FullTitle);
            }

            if (MessageBox.Show(message, Resources.Labels.DeleteTransactionTitle, MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                deleteTransaction(transaction.ID);
                updateTransactionsTab();
                updatePlannedTransactionsTab();
                updateAccountsTab();
                updateWelcomeTab();
                updateTagCloud();
                return true;
            }
            return false;
        }
        
        private void btnTransactionDelete_Click(object sender, EventArgs e)
        {
            if (lbTransactions.SelectedItem != null)
            {
                askDeleteTransaction(lbTransactions.SelectedItem as MoneyDataSet.TransactionsRow);
            }
        }

        private void cbTransactionsShowAll_CheckedChanged(object sender, EventArgs e)
        {
            clearTransactionDetails();
            refreshTransactionsListBox();
        }

        private void lbTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTransactions.SelectedItem != null)
            {
                displayTransactionDetails(lbTransactions.SelectedItem as MoneyDataSet.TransactionsRow);
            }
            else
            {
                clearTransactionDetails();
            }
        }

        #endregion

        #region Planned transaction tab routines (transferred)

        private void deletePlannedTransaction(int planID)
        {
            keeper.DeletePlannedTransaction(planID);
        }

        private void updatePlannedTransactionsTab()
        {
            clearPlannedTransactionDetails();
            refreshPlannedTransactionsListBox();
        }

        private void refreshPlannedTransactionsListBox()
        {
            lbPlannedTransactions.DataSource = null;
            lbPlannedTransactions.DisplayMember = MoneyDataSet.IDs.SpecialColumns.FullTitleColumnName;
            lbPlannedTransactions.ValueMember = keeper.DataSet.PlannedTransactions.IDColumn.ColumnName;
            if (cbPlannedTransactionsShowAll.Checked)
            {
                lbPlannedTransactions.DataSource = keeper.PlannedTransactions;
            }
            else
            {
                lbPlannedTransactions.DataSource = keeper.GetRelevantPlannedTransactions();
            }
            if (lbPlannedTransactions.Items.Count == 0)
            {
                btnPlannedTransactionEdit.Enabled = false;
                btnPlannedTransactionCopy.Enabled = false;
                btnPlannedTransactionDelete.Enabled = false;
                btnPlannedTransactionImplement.Enabled = false;
            }
        }

        private void clearPlannedTransactionDetails()
        {
            tbPlannedTransactionRecurrency.Text = String.Empty;
            tbPlannedTransactionStartDate.Text = String.Empty;
            tbPlannedTransactionTitle.Text = String.Empty;
            tbPlannedTransactionDescription.Text = String.Empty;
            tbPlannedTransactionTags.Text = String.Empty;
            tbPlannedTransactionAccountType.Text = String.Empty;
            tbPlannedTransactionType.Text = String.Empty;
            tbPlannedTransactionAmount.Text = String.Empty;
        }

        private void displayPlannedTransactionDetails(MoneyDataSet.PlannedTransactionsRow plan)
        {
            tbPlannedTransactionTitle.Text = plan.Title;
            tbPlannedTransactionDescription.Text = plan.Description;
            tbPlannedTransactionTags.Text = String.Join(Consts.UI.EnumerableSeparator, keeper.GetPlannedTransactionTagStrings(plan));

            tbPlannedTransactionAccountType.Text = plan.AccountTypeRow.Title;
            tbPlannedTransactionType.Text = plan.TransactionTypeRow.Title;

            tbPlannedTransactionAmount.Text = plan.Amount.ToString(Consts.UI.CurrencyFormat, plan.CurrenciesRow.CurrencyCultureInfo);

            tbPlannedTransactionStartDate.Text = plan.StartTime.ToString(Consts.UI.DateFormat);

            if (plan.IsEndTimeNull())
            {
                tbPlannedTransactionRecurrency.Text = plan.RecurrenciesRow.Title;
            }
            else
            {
                tbPlannedTransactionRecurrency.Text = String.Format(Resources.Labels.RecurrencyUntilFormat, 
                    plan.RecurrenciesRow.Title, plan.EndTime);
            }

            btnPlannedTransactionEdit.Enabled = true;
            btnPlannedTransactionCopy.Enabled = true;
            btnPlannedTransactionDelete.Enabled = true;
            btnPlannedTransactionImplement.Enabled = true;
        }

        private void cbPlannedTransactionsShowAll_CheckedChanged(object sender, EventArgs e)
        {
            clearPlannedTransactionDetails();
            refreshPlannedTransactionsListBox();
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            TemplateSelectorForm selector = new TemplateSelectorForm(keeper.GetAllTransactionTemplates((sender as Button).Equals(btnPlanIncome)));
            if (selector.ShowDialog(this) == DialogResult.OK)
            {
                PlanEditForm form = new PlanEditForm(selector.SelectedTemplate);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    updateWelcomeTab();
                    updatePlannedTransactionsTab();
                    updateTagCloud();
                    lbPlannedTransactions.SelectedItem = form.UpdatedPlan;
                }
            }
        }

        private void btnPlannedTransactionEditCopy_Click(object sender, EventArgs e)
        {
            MoneyDataSet.PlannedTransactionsRow selectedPlan = lbPlannedTransactions.SelectedItem as MoneyDataSet.PlannedTransactionsRow;
            MoneyDataSet.PlannedTransactionsRow sourcePlan = null;
            MoneyDataSet.PlannedTransactionsRow destinationPlan = null;

            if (selectedPlan.TransactionTemplatesRow == null)
            {
                ErrorHelper.ShowErrorBox(ErrorHelper.Errors.PlanWithoutTemplate);
                Log.Write("Plan", selectedPlan);
                return;
            }

            if (selectedPlan.TransactionTemplatesRow.HasDestinationAccount)
            {
                sourcePlan = keeper.PlannedTransactions.SingleOrDefault(p => ((!p.IsPairReferenceIDNull()) &&
                    (p.PairReferenceID == selectedPlan.PairReferenceID) &&
                    (p.TransactionTypeID.Equals(selectedPlan.TransactionTemplatesRow.SourceTransactionTypeID))));

                destinationPlan = keeper.PlannedTransactions.SingleOrDefault(p => ((!p.IsPairReferenceIDNull()) &&
                    (p.PairReferenceID == selectedPlan.PairReferenceID) &&
                    (p.TransactionTypeID.Equals(selectedPlan.TransactionTemplatesRow.DestinationTransactionTypeID))));
            }
            else
            {
                sourcePlan = selectedPlan;
            }

            PlanEditForm form = new PlanEditForm(sourcePlan.TransactionTemplatesRow, 
                sourcePlan, destinationPlan, (sender as Button).Equals(btnPlannedTransactionCopy));

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                updateWelcomeTab();
                updatePlannedTransactionsTab();
                updateTagCloud();
                lbPlannedTransactions.SelectedItem = form.UpdatedPlan;
            }
        }

        private bool askDeletePlannedTransaction(MoneyDataSet.PlannedTransactionsRow plan)
        {
            String message = String.Empty;
            if (plan.IsPairReferenceIDNull())
            {
                message = String.Format(Resources.Labels.DeletePlannedTransactionFormat, plan.FullTitle);
            }
            else
            {
                message = String.Format(Resources.Labels.DeletePairedPlannedTransactionFormat, plan.FullTitle);
            }

            if (MessageBox.Show(message, Resources.Labels.DeletePlannedTransactionTitle, MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                deletePlannedTransaction(plan.ID);
                updatePlannedTransactionsTab();
                updateWelcomeTab();
                updateTagCloud();
                return true;
            }
            return false;
        }

        private void btnPlannedTransactionDelete_Click(object sender, EventArgs e)
        {
            if (lbPlannedTransactions.SelectedItem != null)
            {
                askDeletePlannedTransaction(lbPlannedTransactions.SelectedItem as MoneyDataSet.PlannedTransactionsRow);
            }
        }

        private void lbPlannedTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPlannedTransactions.SelectedItem != null)
            {
                displayPlannedTransactionDetails(lbPlannedTransactions.SelectedItem as MoneyDataSet.PlannedTransactionsRow);
            }
            else
            {
                clearPlannedTransactionDetails();
            }
        }

        private void btnPlannedTransactionImplement_Click(object sender, EventArgs e)
        {
            if (lbPlannedTransactions.SelectedItem != null)
            {
                TransactionEditForm form = new TransactionEditForm(
                    (lbPlannedTransactions.SelectedItem as MoneyDataSet.PlannedTransactionsRow).TransactionTemplatesRow,
                    lbPlannedTransactions.SelectedItem as MoneyDataSet.PlannedTransactionsRow);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    updateWelcomeTab();
                    updateTransactionsTab();
                    updatePlannedTransactionsTab();
                    updateAccountsTab();
                    updateTagCloud();
                    lbTransactions.SelectedItem = form.UpdatedTransaction;
                    tabsMain.SelectedTab = tabTransactions;
                }
            }
        }

        #endregion

        #region Search tab routines

        private void updateTagCloud()
        {
            flpTagFlow.Controls.Clear();
            IEnumerable<MoneyDataKeeper.TagUsagesEntry> tags = keeper.TagUsages;

            if (tags.Any())
            {
                int maxUsages = tags.Max(t => (t.Usages));

                foreach (MoneyDataKeeper.TagUsagesEntry tag in tags.OrderBy(o => (o.Title)))
                {
                    LinkLabel linkTag = new LinkLabel();
                    linkTag.Text = tag.Title;
                    linkTag.ContextMenuStrip = cmsTag;

                    int sizeIncrease = tag.Usages * Consts.UI.TagsMaxFontIncrease / maxUsages;

                    Font font = new System.Drawing.Font(linkTag.Font.FontFamily, linkTag.Font.Size + sizeIncrease);

                    linkTag.Font = font;
                    linkTag.AutoSize = true;
                    linkTag.LinkClicked += linkTag_LinkClicked;

                    toolTipMain.SetToolTip(linkTag, String.Format(Resources.Labels.TagToolTipFormat, tag.Title));
                    flpTagFlow.Controls.Add(linkTag);
                }
            }
        }

        private void tsmiShowTagUsages_Click(object sender, EventArgs e)
        {
            try
            {
                showResults((cmsTag.SourceControl as LinkLabel).Text);
            }
            catch (Exception ex)
            {
                ErrorHelper.ShowErrorBox(e: ex);
            }
        }

        private void tsmiRenameTag_Click(object sender, EventArgs e)
        {

            try
            {
                TagRenameForm form = new TagRenameForm((cmsTag.SourceControl as LinkLabel).Text);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    updateAccountsTab();
                    updateTransactionsTab();
                    updatePlannedTransactionsTab();
                    updateWelcomeTab();
                    updateTagCloud();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.ShowErrorBox(e: ex);
            }
        }

        private void tsmiDeleteTag_Click(object sender, EventArgs e)
        {
            try
            {
                String tag = (cmsTag.SourceControl as LinkLabel).Text;
                if (MessageBox.Show(String.Format(Resources.Labels.DeleteTagFormat, tag), Resources.Labels.DeleteTagTitle,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    keeper.DeleteTag(tag);
                    updateAccountsTab();
                    updateTransactionsTab();
                    updatePlannedTransactionsTab();
                    updateWelcomeTab();
                    updateTagCloud();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.ShowErrorBox(e: ex);
            }
        }

        private void linkTag_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                showResults((sender as LinkLabel).Text);
            }
        }

        private void tsstbSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                tsbDisplaySearchResults.PerformClick();
            }
        }

        private void tsbDisplaySearchResults_Click(object sender, EventArgs e)
        {
            showResults();
        }

        private void clearSearchResults()
        {
            dgvSearchResults.Rows.Clear();
        }

        private void showResults(String tag = null)
        {
            clearSearchResults();

            IEnumerable<MoneyDataSet.AccountsRow> accounts = null;
            IEnumerable<MoneyDataSet.TransactionsRow> transactions = null;
            IEnumerable<MoneyDataSet.PlannedTransactionsRow> plans = null;

            if (String.IsNullOrEmpty(tag))
            {
                keeper.AddTextHistory(Consts.Keeper.HistorySearchID, tsstbSearchText.Text);
                updateSearchSuggestions();

                String searchString = tsstbSearchText.Text.ToLower().Trim();
                                
                accounts = keeper.Accounts;
                transactions = keeper.Transactions;
                plans = keeper.PlannedTransactions;
                
                foreach (String word in searchString.Split(Consts.UI.WordDividers, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (String.IsNullOrEmpty(word))
                    {
                        continue;
                    }

                    accounts = accounts.Where(a => ((a.Title.ToLower().Contains(word)) ||
                        (a.Description.ToLower().Contains(word)) || (a.AccountTypesRow.Title.ToLower().Contains(word)) ||
                        (a.GetAccountTagsRows().Where(at => (at.TagRow.Title.ToLower().Contains(word))).Any())
                        ));

                    transactions = transactions.Where(t => ((t.Title.ToLower().Contains(word)) ||
                        (t.Description.ToLower().Contains(word)) || (t.TransactionTypesRow.Title.ToLower().Contains(word)) ||
                        (t.GetTransactionTagsRows().Where(tt => (tt.TagRow.Title.ToLower().Contains(word))).Any())
                        ));

                    plans = plans.Where(p => ((p.Title.ToLower().Contains(word)) ||
                        (p.Description.ToLower().Contains(word)) || (p.TransactionTypeRow.Title.ToLower().Contains(word)) ||
                        (p.AccountTypeRow.Title.ToLower().Contains(word)) ||
                        (p.GetPlannedTransactionTagsRows().Where(pt => (pt.TagRow.Title.ToLower().Contains(word))).Any())
                        ));

                    if ((!accounts.Any()) && (!transactions.Any()) && (!plans.Any()))
                    {
                        // nothing found, no need to look further
                        break;
                    }
                }
            }
            else
            {
                accounts = keeper.Accounts.Where(a =>
                    (a.GetAccountTagsRows().Where(at => (at.TagRow.Title.Equals(tag))).Any()));
                
                transactions = keeper.Transactions.Where(t =>
                    (t.GetTransactionTagsRows().Where(tt => (tt.TagRow.Title.Equals(tag))).Any()));
                
                plans = keeper.PlannedTransactions.Where(p =>
                    (p.GetPlannedTransactionTagsRows().Where(pt => (pt.TagRow.Title.Equals(tag))).Any()));
            }

            // accounts
            foreach (MoneyDataSet.AccountsRow a in accounts)
            {
                StringBuilder tags = new StringBuilder();
                foreach (MoneyDataSet.AccountTagsRow at in a.GetAccountTagsRows())
                {
                    if (tags.Length > 0)
                    {
                        tags.Append(Consts.UI.EnumerableSeparator);
                    }
                    tags.Append(at.TagRow.Title);
                }

                int i = dgvSearchResults.Rows.Add(Properties.Resources.book_open, a.FullTitle, a.EntryTime,
                    a.Balance.ToString(Consts.UI.CurrencyFormat, a.CurrenciesRow.CurrencyCultureInfo),
                    tags.ToString());
                
                dgvSearchResults.Rows[i].Tag = a;
            }

            // transactions
            foreach (MoneyDataSet.TransactionsRow t in transactions)
            {
                StringBuilder tags = new StringBuilder();
                foreach (MoneyDataSet.TransactionTagsRow tt in t.GetTransactionTagsRows())
                {
                    if (tags.Length > 0)
                    {
                        tags.Append(Consts.UI.EnumerableSeparator);
                    }
                    tags.Append(tt.TagRow.Title);
                }

                int i = dgvSearchResults.Rows.Add(Properties.Resources.application_form, t.FullTitle, t.TransactionTime,
                    t.Amount.ToString(Consts.UI.CurrencyFormat, t.AccountRow.CurrenciesRow.CurrencyCultureInfo),
                    tags.ToString());
                
                dgvSearchResults.Rows[i].Tag = t;
            }

            // plans
            foreach (MoneyDataSet.PlannedTransactionsRow p in plans)
            {
                StringBuilder tags = new StringBuilder();
                foreach (MoneyDataSet.PlannedTransactionTagsRow pt in p.GetPlannedTransactionTagsRows())
                {
                    if (tags.Length > 0)
                    {
                        tags.Append(Consts.UI.EnumerableSeparator);
                    }
                    tags.Append(pt.TagRow.Title);
                }

                int i = dgvSearchResults.Rows.Add(Properties.Resources.date, p.FullTitle, p.StartTime,
                    p.Amount.ToString(Consts.UI.CurrencyFormat, p.CurrenciesRow.CurrencyCultureInfo),
                    tags.ToString());
                
                dgvSearchResults.Rows[i].Tag = p;
            }

            dgvcSearchResultsAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvcSearchResultsTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvcSearchResultsDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSearchResults.Sort(dgvcSearchResultsDate, ListSortDirection.Descending);
        }

        private void dgvSearchResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // check type of row tag
            openSearchResult(dgvSearchResults.Rows[e.RowIndex]);
        }

        private void dgvSearchResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                openSearchResult(dgvSearchResults.CurrentRow);
            }
        }

        private void dgvSearchResults_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hti = dgvSearchResults.HitTest(e.X, e.Y);

                if (hti.Type == DataGridViewHitTestType.Cell)
                {
                    dgvSearchResults.CurrentCell = dgvSearchResults[hti.ColumnIndex, hti.RowIndex];
                    cmsSearchResults.Show(dgvSearchResults, e.Location);
                }
            }

        }

        private void cmsSearchResults_Opening(object sender, CancelEventArgs e)
        {
            // showing only relevant menu items

            object tag = dgvSearchResults.CurrentRow.Tag;

            tsmiOpenResult.Font = new Font(tsmiOpenResult.Font, FontStyle.Bold);
            if (tag is MoneyDataSet.AccountsRow)
            {
                tsmiOpenResult.Image = Properties.Resources.book_open;
                tsmiAccountBalanceCorrection.Visible = true;
                tsmiSubmitPlanTransaction.Visible = false;
                tsmiEditResult.Visible = true;
            }
            else if (tag is MoneyDataSet.TransactionsRow)
            {
                tsmiOpenResult.Image = Properties.Resources.application_form;
                tsmiAccountBalanceCorrection.Visible = false;
                tsmiSubmitPlanTransaction.Visible = false;
                tsmiEditResult.Visible = false;
            }
            else if (tag is MoneyDataSet.PlannedTransactionsRow)
            {
                tsmiOpenResult.Image = Properties.Resources.date;
                tsmiAccountBalanceCorrection.Visible = false;
                tsmiSubmitPlanTransaction.Visible = true;
                tsmiEditResult.Visible = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void tsmiOpenResult_Click(object sender, EventArgs e)
        {
            openSearchResult(dgvSearchResults.CurrentRow);
        }

        private void tsmiDeleteResult_Click(object sender, EventArgs e)
        {
            object tag = dgvSearchResults.CurrentRow.Tag;

            if (tag is MoneyDataSet.AccountsRow)
            {
                if (askDeleteAccount(tag as MoneyDataSet.AccountsRow))
                {
                    dgvSearchResults.Rows.Remove(dgvSearchResults.CurrentRow);
                }
            }
            else if (tag is MoneyDataSet.TransactionsRow)
            {
                if (askDeleteTransaction(tag as MoneyDataSet.TransactionsRow))
                {
                    dgvSearchResults.Rows.Remove(dgvSearchResults.CurrentRow);
                }
            }
            else if (tag is MoneyDataSet.PlannedTransactionsRow)
            {
                if (askDeletePlannedTransaction(tag as MoneyDataSet.PlannedTransactionsRow))
                {
                    dgvSearchResults.Rows.Remove(dgvSearchResults.CurrentRow);
                }
            }
            else
            {
                ErrorHelper.ShowErrorBox(ErrorHelper.Errors.UnknownSearchResult);
                Log.Write("Found in search", tag);
            }
        }

        private void tsmiSubmitPlanTransaction_Click(object sender, EventArgs e)
        {
            TransactionEditForm form = new TransactionEditForm( 
                (dgvSearchResults.CurrentRow.Tag as MoneyDataSet.PlannedTransactionsRow).TransactionTemplatesRow,
                dgvSearchResults.CurrentRow.Tag as MoneyDataSet.PlannedTransactionsRow);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                updateWelcomeTab();
                updateTransactionsTab();
                updatePlannedTransactionsTab();
                updateAccountsTab();
                updateTagCloud();
            }

        }

        private void tsmiEditResult_Click(object sender, EventArgs e)
        {
            openSearchResult(dgvSearchResults.CurrentRow, true);
        }

        private void tsmiAccountBalanceCorrection_Click(object sender, EventArgs e)
        {
            MoneyDataSet.AccountsRow selected = dgvSearchResults.CurrentRow.Tag as MoneyDataSet.AccountsRow;
            AccountCorrectionForm form = new AccountCorrectionForm(selected);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                updateAssets();
                updateDebts();
                refreshAccountsListBox();
                refreshTransactionsListBox();
                updateRecentTransactions();
                dgvSearchResults.CurrentRow.Cells[2].Value = selected.EntryTime;
                dgvSearchResults.CurrentRow.Cells[3].Value = selected.Balance.ToString(Consts.UI.CurrencyFormat, 
                    selected.CurrenciesRow.CurrencyCultureInfo);
            }
        }

        private void openSearchResult(DataGridViewRow row, bool editMode = false)
        {
            object tag = row.Tag;

            if (tag is MoneyDataSet.AccountsRow)
            {
                lbAccounts.SelectedItem = tag;
                tabsMain.SelectedTab = tabAccounts;
                if (editMode)
                {
                    btnAccountEdit.PerformClick();
                }
            }
            else if (tag is MoneyDataSet.TransactionsRow)
            {
                lbTransactions.SelectedItem = tag;
                tabsMain.SelectedTab = tabTransactions;
            }
            else if (tag is MoneyDataSet.PlannedTransactionsRow)
            {
                lbPlannedTransactions.SelectedItem = tag;
                tabsMain.SelectedTab = tabPlannedTransactions;
                if (editMode)
                {
                    btnPlannedTransactionEdit.PerformClick();
                }
            }
            else
            {
                ErrorHelper.ShowErrorBox(ErrorHelper.Errors.UnknownSearchResult);
                Log.Write("Found in search", tag);
            }
        }

        #endregion

        #region Account tab routines (transferred)

        private void deleteAccount(int accountID)
        {
            keeper.DeleteAccount(accountID);
        }

        private void updateAccountsTab()
        {
            clearAccountDetails();
            refreshAccountsListBox();
        }

        private void refreshAccountsListBox()
        {
            lbAccounts.DataSource = null;
            lbAccounts.DisplayMember = MoneyDataSet.IDs.SpecialColumns.FullTitleColumnName;
            lbAccounts.ValueMember = keeper.DataSet.Accounts.IDColumn.ColumnName;
            if (cbAccountsShowAll.Checked)
            {
                lbAccounts.DataSource = keeper.AccountsAll;
            }
            else
            {
                lbAccounts.DataSource = keeper.Accounts;
            }
        }


        private void clearAccountDetails()
        {
            tbAccountTitle.Text = String.Empty;
            tbAccountDescription.Text = String.Empty;
            tbAccountType.Text = String.Empty;
            tbAccountTags.Text = String.Empty;
            tbAccountBalance.Text = String.Empty;
            if (lbAccounts.Items.Count == 0)
            {
                btnAccountEdit.Enabled = false;
                btnAccountBalance.Enabled = false;
                btnAccountDelete.Enabled = false;
            }
        }


        private void displayAccountDetails(MoneyDataSet.AccountsRow account)
        {
            tbAccountTitle.Text = account.Title;
            tbAccountDescription.Text = account.Description;

            tbAccountType.Text = account.AccountTypesRow.Title;
            tbAccountBalance.Text = account.Balance.ToString(Consts.UI.CurrencyFormat, account.CurrenciesRow.CurrencyCultureInfo);

            tbAccountTags.Text = String.Join(Consts.UI.EnumerableSeparator, keeper.GetAccountTagStrings(account));

            btnAccountEdit.Enabled = true;
            btnAccountBalance.Enabled = true;
            btnAccountDelete.Enabled = true;
        }

        private void lbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAccounts.SelectedItem != null)
            {
                displayAccountDetails(lbAccounts.SelectedItem as MoneyDataSet.AccountsRow);
            }
            else
            {
                clearAccountDetails();
            }
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            AccountEditForm form = new AccountEditForm((sender as Button).Equals(btnNewDebitAccount));
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                AccountCorrectionForm initialBalanceForm = new AccountCorrectionForm(form.UpdatedAccount);
                initialBalanceForm.ShowDialog(this);
                refreshAccountsListBox();
                updateWelcomeTab();
                updateTransactionsTab();
                updateTagCloud();
                lbAccounts.SelectedItem = form.UpdatedAccount;
            }       
        }

        private void btnAccountEdit_Click(object sender, EventArgs e)
        {
            MoneyDataSet.AccountsRow selected = lbAccounts.SelectedItem as MoneyDataSet.AccountsRow;
            AccountEditForm form = new AccountEditForm(selected.AccountTypesRow.IsDebit, account: selected);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                updateTransactionsTab();
                updateWelcomeTab();
                updateAccountsTab();
                updateTagCloud();
                lbAccounts.SelectedItem = form.UpdatedAccount;
            }
        }

        private void btnAccountBalance_Click(object sender, EventArgs e)
        {
            MoneyDataSet.AccountsRow selected = lbAccounts.SelectedItem as MoneyDataSet.AccountsRow;
            AccountCorrectionForm form = new AccountCorrectionForm(selected);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                updateTransactionsTab();
                updateWelcomeTab();
                updateAccountsTab();
                lbAccounts.SelectedItem = form.UpdatedAccount;
            }
        }

        private bool askDeleteAccount(MoneyDataSet.AccountsRow account)
        {
            if (MessageBox.Show(String.Format(Resources.Labels.DeleteAccountFormat,
                (lbAccounts.SelectedItem as MoneyDataSet.AccountsRow).Title),
                Resources.Labels.DeleteAccountTitle, MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                deleteAccount(account.ID);
                updateAccountsTab();
                updateTransactionsTab();
                updateWelcomeTab();
                updateTagCloud();
                return true;
            }
            return false;
        }

        private void btnAccountDelete_Click(object sender, EventArgs e)
        {
            if (lbAccounts.SelectedItem != null)
            {
                askDeleteAccount(lbAccounts.SelectedItem as MoneyDataSet.AccountsRow);
            }
        }

        private void cbAccountsShowAll_CheckedChanged(object sender, EventArgs e)
        {
            clearAccountDetails();
            refreshAccountsListBox();
        }

        #endregion

        #region Reports tab routines (transferred)

        private void lbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelReportParameters.Controls.Clear();
            if (lbReports.SelectedItem != null)
            {
                Reports.ReportEntry entry = lbReports.SelectedItem as Reports.ReportEntry;
                entry.DefaultsHandler(entry.ReportParameters);

                panelReportParameters.Visible = false;
                Label description = new Label();
                if (entry.ReportParameters != null)
                {
                    panelReportParameters.Controls.Add(entry.ReportParameters);
                }
                panelReportParameters.Controls.Add(description);
                description.Text = entry.Description;
                description.Dock = DockStyle.Top;
                description.Padding = new Padding(0, 0, 0, 6);
                //description.AutoSize = true;
                description.Size = description.GetPreferredSize(description.Size);
                panelReportParameters.Visible = true;
                btnRunReport.Enabled = true;
            }
            else
            {
                btnRunReport.Enabled = false;
            }
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            if (lbReports.SelectedItem != null)
            {
                Reports.ReportEntry entry = lbReports.SelectedItem as Reports.ReportEntry;
                entry.RunHandler(entry.ReportParameters);
            }
        }

        #endregion

        #region Settings tab routines

        /// <summary>
        /// Update settings tab with values from parameters
        /// </summary>
        private void updateSettingsTab()
        {
            // set settings from saved parameters
            cbAllowAutoUpdate.Checked = Parameters.CheckForUpdates;
            
            // setting languages
            rbLanguageSystemDefault.Tag = Consts.Language.SystemDefault;
            rbLanguageEnglish.Tag = Consts.Language.English;
            rbLanguageRussian.Tag = Consts.Language.Russian;
            if (Parameters.Language.Equals(Consts.Language.English))
            {
                rbLanguageEnglish.Checked = true;
            }
            else if (Parameters.Language.Equals(Consts.Language.Russian))
            {
                rbLanguageRussian.Checked = true;
            }
            else
            {
                rbLanguageSystemDefault.Checked = true;
            }

            // ui settings
            cbShowFilenameInTitle.Checked = Parameters.ShowFilenameInTitle;

            // portability options
            cbShowOpenDialogEachStart.Checked = Parameters.ShowOpenDialogEachStart;

            updateFileSpecificSettings();
        }

        /// <summary>
        /// Set update file specific information on settings tab
        /// </summary>
        private void updateFileSpecificSettings()
        {
            if (String.IsNullOrEmpty(keeper.Password))
            {
                cbEncryptFileWithPassword.Checked = false;
            }
            else
            {
                String password = keeper.Password;
                cbEncryptFileWithPassword.Checked = true;
                tbFilePassword1.Text = password;
                tbFilePassword2.Text = password;
            }
            cbEncryptFileWithPassword_CheckedChanged(null, null);
        }

        /// <summary>
        /// Open metadata editor button click hanlder
        /// </summary>
        private void btnMetadata_Click(object sender, EventArgs e)
        {
            CustomMetadataForm form = new CustomMetadataForm();
            form.Icon = this.Icon;
            form.ShowDialog(this);
            updateWelcomeTab();
            updateTransactionsTab();
            updatePlannedTransactionsTab();
            updateAccountsTab();
        }

        /// <summary>
        /// Clear custom metadata button click hanlder
        /// </summary>
        private void btnClearCustomMetadata_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.Labels.ClearCustomMetadataMessage, Resources.Labels.ClearCustomMetadataTitle, 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                keeper.ClearUserMetadata();
                updateWelcomeTab();
                updateTransactionsTab();
                updatePlannedTransactionsTab();
                updateAccountsTab();
            }
        }

        /// <summary>
        /// Set parameters with value of allow autoupdate checkbox
        /// </summary>
        private void cbAllowAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            Parameters.CheckForUpdates = cbAllowAutoUpdate.Checked;
        }

        /// <summary>
        /// Set parameters with value of language radiobuttons
        /// </summary>
        private void rbLanguage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Parameters.Language = (sender as RadioButton).Tag.ToString();
            }
            catch (Exception ex)
            {
                ErrorHelper.ShowErrorBox(e: ex);
            }
        }

        /// <summary>
        /// Set parameters with value of allow show filename in title checkbox
        /// </summary>
        private void cbShowFilenameInTitle_CheckedChanged(object sender, EventArgs e)
        {
            Parameters.ShowFilenameInTitle = cbShowFilenameInTitle.Checked;
            updateFormTitle();
        }

        /// <summary>
        /// Set parameters with value of show open dialog each start checkbox
        /// </summary>
        private void cbShowOpenDialogEachStart_CheckedChanged(object sender, EventArgs e)
        {
            Parameters.ShowOpenDialogEachStart = cbShowOpenDialogEachStart.Checked;
        }

        /// <summary>
        /// Open data file button click hanlder
        /// </summary>
        private void btnOpenDataFile_Click(object sender, EventArgs e)
        {
            openDataFile();
        }

        /// <summary>
        /// Save file as button click hanlder
        /// </summary>
        private void btnSaveAsDataFile_Click(object sender, EventArgs e)
        {
            if (fdSaveData.ShowDialog(this) == DialogResult.OK)
            {
                keeper.Filename = fdSaveData.FileName;
                keeper.FileSave();
            }
        }

        /// <summary>
        /// Open data file, showing "please wait" window
        /// </summary>
        private bool openDataFile()
        {
            if (fdOpenData.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    keeper.FileSave();
                    keeper.Password = String.Empty;
                    keeper.Filename = fdOpenData.FileName;
                    FileLoadForm frmLoad = new FileLoadForm(Resources.Labels.DataLoadingMessage, false);
                    if (frmLoad.ShowDialog(this) != DialogResult.OK)
                    {
                        return false;
                    }
                    updateFormTitle();
                    updateFileSpecificSettings();
                    updateWelcomeTab();
                    updateTransactionsTab();
                    updatePlannedTransactionsTab();
                    updateAccountsTab();
                    updateTagCloud();
                    return true;
                }
                catch (Exception e)
                {
                    ErrorHelper.ShowErrorBox(e: e);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Handler for encrypt file with password checkbox
        /// </summary>
        private void cbEncryptFileWithPassword_CheckedChanged(object sender, EventArgs e)
        {
            lblFilePassword1.Enabled = cbEncryptFileWithPassword.Checked;
            lblFilePassword2.Enabled = cbEncryptFileWithPassword.Checked;
            lblPasswordValid.Enabled = cbEncryptFileWithPassword.Checked;
            tbFilePassword1.Enabled = cbEncryptFileWithPassword.Checked;
            tbFilePassword2.Enabled = cbEncryptFileWithPassword.Checked;
            if (!cbEncryptFileWithPassword.Checked)
            {
                tbFilePassword1.Text = String.Empty;
                tbFilePassword2.Text = String.Empty;
                lblPasswordValid.Text = String.Empty;
                lblPasswordValid.ForeColor = Color.Black;
                keeper.Password = String.Empty;
            }
            else
            {
                tbFilePassword_TextChanged(null, null);
            }
        }

        /// <summary>
        /// Ensure passwords are set and identical
        /// </summary>
        private void tbFilePassword_TextChanged(object sender, EventArgs e)
        {
            if ((tbFilePassword1.Text.Length == 0) || ((tbFilePassword2.Text.Length == 0)) ||
                (!tbFilePassword1.Text.Equals(tbFilePassword2.Text)))
            {
                lblPasswordValid.Text = Resources.Labels.PasswordInvalid;
                lblPasswordValid.ForeColor = Color.Red;
                keeper.Password = String.Empty;
            }
            else
            {
                lblPasswordValid.Text = Resources.Labels.PasswordValid;
                lblPasswordValid.ForeColor = Color.Green;
                keeper.Password = tbFilePassword1.Text;
            }
        }

        #endregion

        #region About tab routines (transferred)

        /// <summary>
        /// Show intoroduction button click hanlder
        /// </summary>
        private void btnShowIntroduction_Click(object sender, EventArgs e)
        {
            showIntroduction();
        }
        
        /// <summary>
        /// Check for updates button click handler
        /// </summary>
        private void btnCheckForUpdates_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateHelper helper = new UpdateHelper(Consts.Application.UpdateCheckURL, Consts.Application.Version);
                if (helper.IsUpdateAvailable())
                {
                    if (MessageBox.Show(String.Format(Resources.Labels.UpdateAvailableFormat, Consts.Application.Version, helper.AvailableVersion()),
                        Resources.Labels.UpdateAvailableTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        helper.StartUpdate(this);
                    }
                }
                else
                {
                    MessageBox.Show(String.Format(Resources.Labels.NoUpdatesFormat, Consts.Application.Version), Resources.Labels.NoUpdatesTitle, 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Parameters.LastUpdateDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Resources.Labels.UpdateErrorFormat, ex.Message), Resources.Labels.UpdateErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Write(ex);
            }
        }

        /// <summary>
        /// Open development site button click hanlder
        /// </summary>
        private void btnOpenDevelopmentSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Consts.Application.SiteURL);
        }

        #endregion

        #region Auto update check background worker (transferred)

        /// <summary>
        /// Background worker procedure
        /// </summary>
        private void bgwUpdateCheck_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                UpdateHelper helper = new UpdateHelper(Consts.Application.UpdateCheckURL, Consts.Application.Version);
                helper.IsUpdateAvailable();
                e.Result = helper;
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                e.Result = ex;
            }
        }

        /// <summary>
        /// Code to run on complete of background worker
        /// </summary>
        private void bgwUpdateCheck_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if ((e.Result == null) || (e.Result is Exception))
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();

                    String message = "Unknown error";
                    if (e.Result != null)
                    {
                        message = (e.Result as Exception).Message;
                    }

                    // update process failed
                    MessageBox.Show(String.Format(Resources.Labels.UpdateErrorFormat, message),
                        Resources.Labels.UpdateErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                      
                }
                else
                {
                    UpdateHelper helper = e.Result as UpdateHelper;
                    if (UpdateHelper.IsVersionHigher(helper.AvailableVersion()))
                    {
                        this.Show();
                        this.WindowState = FormWindowState.Normal;
                        this.Activate();
                        
                        if (MessageBox.Show(String.Format(Resources.Labels.UpdateAvailableFormat, Consts.Application.Version, helper.AvailableVersion()),
                            Resources.Labels.UpdateAvailableTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1) == DialogResult.OK)
                        {
                            helper.StartUpdate(this);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Resources.Labels.UpdateErrorFormat, ex.Message), Resources.Labels.UpdateErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Write(ex);
            }
        }

        #endregion
        
        #region Form/application level handlers

        /// <summary>
        /// Hanlder for Deselecting event on tabs
        /// </summary>
        private void tabsMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabReports)
            {
                // refresh report parameters
                lbReports_SelectedIndexChanged(null, null);
            }
        }
        
        /// <summary>
        /// Link label click hanlder - open URL, which is stored in Text property
        /// </summary>
        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start((sender as LinkLabel).Text);
        }
        
        /// <summary>
        /// Shortcut event halnder
        /// </summary>
        private void MainApplicationForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (HotKeyHelper.GetShortcut(e))
            {
                case KeyShortcut.ShowTemplates:
                    tabsMain.SelectedTab = tabWelcome;
                    tsddbNewTransaction.Select();
                    tsddbNewTransaction.ShowDropDown();
                    break;

                case KeyShortcut.ShowPlans:
                    tabsMain.SelectedTab = tabWelcome;
                    tsddbNewPlan.Select();
                    tsddbNewPlan.ShowDropDown();
                    break;

                case KeyShortcut.ShowMonthBalance:
                    tsbMonthBalance.PerformClick();
                    break;

                case KeyShortcut.Search:
                    {
                        if (tabsMain.SelectedTab == tabWelcome)
                        {
                            tsbSearch.PerformClick();
                        }
                    }
                    break;

                case KeyShortcut.Edit:
                    {
                        if ((tabsMain.SelectedTab == tabPlannedTransactions) && (btnPlannedTransactionEdit.Enabled))
                        {
                            btnPlannedTransactionEdit.PerformClick();
                        }
                        else if ((tabsMain.SelectedTab == tabAccounts) && (btnAccountEdit.Enabled))
                        {
                            btnAccountEdit.PerformClick();
                        }
                    }
                    break;

                case KeyShortcut.Delete:
                    {
                        if ((tabsMain.SelectedTab == tabPlannedTransactions) && (btnPlannedTransactionDelete.Enabled))
                        {
                            btnPlannedTransactionDelete.PerformClick();
                        }
                        else if ((tabsMain.SelectedTab == tabTransactions) && (btnTransactionDelete.Enabled))
                        {
                            btnTransactionDelete.PerformClick();
                        }
                        else if ((tabsMain.SelectedTab == tabAccounts) && (btnAccountDelete.Enabled))
                        {
                            btnAccountDelete.PerformClick();
                        }
                        else if ((tabsMain.SelectedTab == tabSettings) && (btnClearCustomMetadata.Enabled))
                        {
                            btnClearCustomMetadata.PerformClick();
                        }
                    }
                    break;
                    
                case KeyShortcut.NewIncomeTransaction:
                    tabsMain.SelectedTab = tabPlannedTransactions;
                    btnPlanIncome.PerformClick();
                    break;

                case KeyShortcut.NewPaymentTransaction:
                    tabsMain.SelectedTab = tabPlannedTransactions;
                    btnPlanPayment.PerformClick();
                    break;

                case KeyShortcut.NewCreditAccount:
                    tabsMain.SelectedTab = tabAccounts;
                    btnNewCreditAccount.PerformClick();
                    break;

                case KeyShortcut.NewDebitAccount:
                    tabsMain.SelectedTab = tabAccounts;
                    btnNewDebitAccount.PerformClick();
                    break;
            }
        }

        #endregion

    }
}
