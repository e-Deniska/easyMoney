using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using easyMoney.Data;
using easyMoney.Utilities;
using System.Windows.Forms.DataVisualization.Charting;
using easyMoney.SimpleReports;
using easyMoney.Controls;

namespace easyMoney.Manager.Forms
{
    public partial class WelcomeScreenForm : Form
    {
        // TODO: replace screen update with only one loop through each table instead of several loops

        MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
        DateTime statsDay = DateTime.Now.Date;
        DateTime statsMonth = DateTime.Now.Date;
        DateTime statsYear = DateTime.Now.Date;

        #region Form init/load/close

        public WelcomeScreenForm()
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

        private void WelcomeScreenForm_Load(object sender, EventArgs e)
        {
            fdSaveData.DefaultExt = Consts.Application.DefaultExtension;
            fdSaveData.Filter = Resources.Labels.FileFilter;
            fdOpenData.DefaultExt = Consts.Application.DefaultExtension;
            fdOpenData.Filter = Resources.Labels.FileFilter;

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

            if (!Parameters.IntroductionShown)
            {
                FormHelper.ShowIntroduction(this);
                Parameters.IntroductionShown = true;
            }

            if ((Parameters.CheckForUpdates) && (Parameters.LastUpdateDate.AddDays(Consts.Application.AutoUpdatePeriod) < DateTime.Now))
            {
                bgwUpdateCheck.RunWorkerAsync();
                Parameters.LastUpdateDate = DateTime.Now;
            }

            updateFormTitle();

            refreshForm();

            this.Activate();

            if (!String.IsNullOrWhiteSpace(keeper.ValidationErrors))
            {
                ErrorHelper.ShowErrorBox(keeper.ValidationErrors);
            }
        }

        private void WelcomeScreenForm_FormClosing(object sender, FormClosingEventArgs e)
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

            Parameters.Save();
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

        #endregion
        
        #region Welcome tab routines (to be updated)


        private void updateStatsAll()
        {
            updateStatsButtons();
            updateStatsDay();
            updateStatsMonth();
            updateStatsYear();
        }

        private void updateStatsButtons()
        {
            btnNextYear.Enabled = (statsYear.Year < DateTime.Now.Year);

            if (statsMonth.Year < DateTime.Now.Year)
            {
                btnNextMonth.Enabled = true;
            }
            else
            {
                btnNextMonth.Enabled = (statsMonth.Month < DateTime.Now.Month);
            }

            if (statsDay.Year < DateTime.Now.Year)
            {
                btnNextDay.Enabled = true;
            }
            else
            {
                btnNextDay.Enabled = (statsDay.DayOfYear < DateTime.Now.DayOfYear);
            }        
        }

        private void updateStatsDay()
        {
            double earned = 0;
            double spent = 0;
            foreach (MoneyDataSet.TransactionsRow transaction in
                keeper.Transactions.Where(t => (
                    (t.TransactionTime.Year == statsDay.Year) &&
                    (t.TransactionTime.DayOfYear == statsDay.DayOfYear) &&
                    (t.IsStasticicCountable))))
            {
                if (transaction.TransactionTypesRow.IsIncome)
                {
                    earned += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                }
                else
                {
                    spent += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                }
            }
            lblStatsDay.Text = String.Format(Resources.Labels.StatsDay, statsDay.ToShortDateString());
            lblStatsDayEarned.Text = String.Format(Consts.UI.EarnedFormat, earned, keeper.GetDefaultCurrency().CurrencyCultureInfo);
            lblStatsDaySpent.Text = String.Format(Consts.UI.SpentFormat, spent, keeper.GetDefaultCurrency().CurrencyCultureInfo);
        }

        private void updateStatsMonth()
        {
            double earned = 0;
            double spent = 0;
            foreach (MoneyDataSet.TransactionsRow transaction in
                keeper.Transactions.Where(t => (
                    (t.TransactionTime.Year == statsMonth.Year) &&
                    (t.TransactionTime.Month == statsMonth.Month) &&
                    (t.IsStasticicCountable))))
            {
                if (transaction.TransactionTypesRow.IsIncome)
                {
                    earned += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                }
                else
                {
                    spent += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                }
            }
            lblStatsMonth.Text = String.Format(Resources.Labels.StatsMonth, statsMonth.ToString(Consts.UI.MonthFormat));
            lblStatsMonthEarned.Text = String.Format(Consts.UI.EarnedFormat, earned, keeper.GetDefaultCurrency().CurrencyCultureInfo);
            lblStatsMonthSpent.Text = String.Format(Consts.UI.SpentFormat, spent, keeper.GetDefaultCurrency().CurrencyCultureInfo);
        }

        private void updateStatsYear()
        {
            double earned = 0;
            double spent = 0;
            foreach (MoneyDataSet.TransactionsRow transaction in
                keeper.Transactions.Where(t => ((t.TransactionTime.Year == statsYear.Year) && (t.IsStasticicCountable)                    
                    )))
            {
                if (transaction.TransactionTypesRow.IsIncome)
                {
                    earned += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                }
                else
                {
                    spent += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                }
            }
            lblStatsYear.Text = String.Format(Resources.Labels.StatsYear, statsYear.Year);
            lblStatsYearEarned.Text = String.Format(Consts.UI.EarnedFormat, earned, keeper.GetDefaultCurrency().CurrencyCultureInfo);
            lblStatsYearSpent.Text = String.Format(Consts.UI.SpentFormat, spent, keeper.GetDefaultCurrency().CurrencyCultureInfo);
        }

        /// <summary>
        /// Update all information on welcome tab
        /// </summary>
        private void refreshForm()
        {
            refreshAccounts();
            refreshNewMenus();
            updateStatsAll();
            updateMonthPlans();
            refreshSearchSuggestions();
        }

        /// <summary>
        /// Update list of text suggestions on search boxes
        /// </summary>
        private void refreshSearchSuggestions()
        {
            tsstbSearch.AutoCompleteCustomSource.Clear();
            tsstbSearch.AutoCompleteCustomSource.AddRange(keeper.GetTextHistory(Consts.Keeper.HistorySearchID));
        }

        /// <summary>
        /// Update contents of Transactions and Plans menus
        /// </summary>
        private void refreshNewMenus()
        {
            tsmiNewIncome.DropDownItems.Clear();
            tsmiNewPayment.DropDownItems.Clear();
            tsmiPlanPayment.DropDownItems.Clear();
            tsmiPlanIncome.DropDownItems.Clear();

            if (!keeper.Accounts.Any())
            {
                ToolStripMenuItem tsmiCreateAccountsFirst = new ToolStripMenuItem(Resources.Labels.CreateAccountsFirst,
                    Properties.Resources.book_open, tsmiCreateAccountsFirst_Click);
                tsmiCreateAccountsFirst.ImageScaling = ToolStripItemImageScaling.None;
                tsmiNewIncome.DropDownItems.Add(tsmiCreateAccountsFirst);
                tsmiNewPayment.DropDownItems.Add(tsmiCreateAccountsFirst);

                // removing undefined transactions
                for (int i = tsmiTransactions.DropDownItems.Count - 1; i > 3; i--)
                {
                    tsmiTransactions.DropDownItems.Remove(tsmiTransactions.DropDownItems[i]);
                }

                // removing undefined planned transactions
                for (int i = tsmiPlans.DropDownItems.Count - 1; i > 3; i--)
                {
                    tsmiPlans.DropDownItems.Remove(tsmiPlans.DropDownItems[i]);
                }
            }
            else
            {
                // payment transactions
                foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.GetTransactionTemplates(false))
                {
                    FormHelper.InsertTemplate(tsmiNewPayment.DropDownItems, template, tsmiTransactionFromTemplate_Click);
                    FormHelper.InsertTemplate(tsmiPlanPayment.DropDownItems, template, tsmiPlanFromTemplate_Click);
                }

                // income transactions
                foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.GetTransactionTemplates(true))
                {
                    FormHelper.InsertTemplate(tsmiNewIncome.DropDownItems, template, tsmiTransactionFromTemplate_Click);
                    FormHelper.InsertTemplate(tsmiPlanIncome.DropDownItems, template, tsmiPlanFromTemplate_Click);
                }

                // TODO: replace these hacks with something adequate
                // removing undefined transactions
                for (int i = tsmiTransactions.DropDownItems.Count - 1; i > 3; i--)
                {
                    tsmiTransactions.DropDownItems.Remove(tsmiTransactions.DropDownItems[i]);
                }

                // removing undefined planned transactions
                for (int i = tsmiPlans.DropDownItems.Count - 1; i > 3; i--)
                {
                    tsmiPlans.DropDownItems.Remove(tsmiPlans.DropDownItems[i]);
                }
                
                // undefined transactions
                foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.GetTransactionTemplates(null))
                {
                    FormHelper.InsertTemplate(tsmiTransactions.DropDownItems, template, tsmiTransactionFromTemplate_Click);
                    FormHelper.InsertTemplate(tsmiPlans.DropDownItems, template, tsmiPlanFromTemplate_Click);
                }

                ToolStripMenuItem tsmiAccountBalanceCorrection = new ToolStripMenuItem(Resources.Labels.AccountCorrectionLabel,
                    Properties.Resources.calculator, tsmiAccountCorrection_Click);
                tsmiAccountBalanceCorrection.ImageScaling = ToolStripItemImageScaling.None;
                tsmiAccountBalanceCorrection.ToolTipText = Resources.Labels.AccountBalanceButtonToolTip;
                tsmiTransactions.DropDownItems.Add(tsmiAccountBalanceCorrection);
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
            bool noDatesPassed = true;
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

                int j = dgvPlans.Rows.Add(entry.Date.Equals(DateTime.MaxValue) ? String.Empty : entry.Date.ToShortDateString(), image, entry.AmountWithCurrency, entry.PlannedTransaction.Title);

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

                // put divider between plans without date
                if ((noDatesPassed) && (entry.Date.Equals(DateTime.MaxValue)))
                {
                    if (j > 0)
                    {
                        dgvPlans.Rows[j - 1].DividerHeight++;
                    }
                    noDatesPassed = false;
                }


            }
            dgvcPlansDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvcPlansAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }


        private void refreshAccounts()
        {
            double assetsTotal = 0;
            double debtsTotal = 0;
            int assetAccounts = 5; // this value should be verified against real data
            int debtAccounts = 5;

            chartAssets.Series[0].Points.Clear();
            chartDebts.Series[0].Points.Clear();

            foreach (MoneyDataSet.AccountsRow account in keeper.Accounts.OrderBy(o => (o.GraphicBalance)))
            {
                double value = account.Balance * account.CurrenciesRow.ExchangeRate;
                Chart chart = null;
                if ((account.Balance < 0) || ((!account.AccountTypesRow.IsDebit) && (account.Balance == 0)))
                {
                    // debts
                    debtsTotal += value;
                    chart = chartDebts;
                    debtAccounts++;
                }
                else
                {
                    // assets
                    assetsTotal += value;
                    chart = chartAssets;
                    assetAccounts++;
                }

                DataPoint point = new DataPoint(chart.Series[0]);
                point.AxisLabel = account.Title;
                point.YValues = new double[1];
                point.YValues[0] = account.GraphicBalance;
                point.Label = Math.Abs(account.Balance).ToString(Consts.UI.CurrencyFormat, account.CurrenciesRow.CurrencyCultureInfo);
                chart.Series[0].Points.Add(point);
            }
            lblAssets.Text = assetsTotal.ToString(Consts.UI.CurrencyFormat, keeper.GetDefaultCurrency().CurrencyCultureInfo);
            lblDebts.Text = debtsTotal.ToString(Consts.UI.CurrencyFormat, keeper.GetDefaultCurrency().CurrencyCultureInfo);

            tlpAccounts.RowStyles[1].Height = assetAccounts;
            tlpAccounts.RowStyles[1].SizeType = SizeType.Percent;
            tlpAccounts.RowStyles[3].Height = debtAccounts;
            tlpAccounts.RowStyles[3].SizeType = SizeType.Percent;
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
                    refreshForm();
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
                refreshForm();
            }
        }

        /// <summary>
        /// Redirect to accounts tab
        /// </summary>
        private void tsmiCreateAccountsFirst_Click(object sender, EventArgs e)
        {
            AccountListForm form = new AccountListForm();
            form.ShowDialog();
            refreshForm();
        }

        /// <summary>
        /// Show account correction form
        /// </summary>
        private void tsmiAccountCorrection_Click(object sender, EventArgs e)
        {
            if (!keeper.Accounts.Any())
            {
                MessageBox.Show(Resources.Labels.NoAccountsText, Resources.Labels.NoAccountsTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                AccountListForm accountsForm = new AccountListForm();
                accountsForm.ShowDialog();
                refreshForm();
                return;
            }

            AccountCorrectionForm form = new AccountCorrectionForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                refreshForm();
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
                tsmiStartSearch.PerformClick();
            }
        }

        /// <summary>
        /// Search button click handler
        /// </summary>
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            SearchForm form = new SearchForm(tsstbSearch.Text);
            form.ShowDialog();
            refreshForm();
        }

        #endregion
        
        #region Toolstrip button handlers

        private void tsmiTransactionList_Click(object sender, EventArgs e)
        {
            TransactionListForm form = new TransactionListForm();
            form.ShowDialog();
            refreshForm();
        }

        private void tsmiPlanList_Click(object sender, EventArgs e)
        {
            PlanListForm form = new PlanListForm();
            form.ShowDialog();
            refreshForm();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog();
        }

        private void tsmiReportList_Click(object sender, EventArgs e)
        {
            ReportListForm form = new ReportListForm();
            form.ShowDialog();
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog();
            refreshForm();
        }

        private void tsmiSearch_Click(object sender, EventArgs e)
        {
            SearchForm form = new SearchForm();
            form.ShowDialog();
            refreshForm();
        }

        private void tsmiMonthBalance_Click(object sender, EventArgs e)
        {
            Reports.ReportEntry monthBalance = new Reports.ReportEntry(1, null, null, null, null, Reports.MonthBalanceReport);
            ReportLoadForm form = new ReportLoadForm(monthBalance);
            form.ShowDialog();
            Form report = form.ReportForm;
            report.Show();
        }

        private void tsmiAccountList_Click(object sender, EventArgs e)
        {
            AccountListForm form = new AccountListForm();
            form.ShowDialog();
            refreshForm();
        }

        private void tsmiNewAccount_Click(object sender, EventArgs e)
        {
            AccountEditForm form = new AccountEditForm((sender as ToolStripMenuItem).Equals(tsmiNewDebitAccount));
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                AccountCorrectionForm initialBalanceForm = new AccountCorrectionForm(form.UpdatedAccount);
                initialBalanceForm.ShowDialog(this);
                refreshForm();
            }
        }

        private void tsmiShowIntroduction_Click(object sender, EventArgs e)
        {
            FormHelper.ShowIntroduction(this);
        }

        #endregion

        #region Auto update check background worker

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

        private void dgvPlans_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvPlans.SelectedRows.Count == 1)
                {
                    PlanViewForm form = new PlanViewForm(dgvPlans.SelectedRows[0].Tag as MoneyDataSet.PlannedTransactionsRow);
                    if (form.ShowDialog() != DialogResult.Cancel)
                    {
                        refreshForm();
                    }
                }
            }
        }

        /// <summary>
        /// Handler for double click on month plans grid
        /// </summary>
        private void dgvPlans_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PlanViewForm form = new PlanViewForm(dgvPlans.Rows[e.RowIndex].Tag as MoneyDataSet.PlannedTransactionsRow);
                if (form.ShowDialog() != DialogResult.Cancel)
                {
                    refreshForm();
                }
            }
        }

        #region File management handlers

        private void tsmiOpen_Click(object sender, EventArgs e)
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
                        return;
                    }
                    updateFormTitle();
                    refreshForm();
                }
                catch (Exception ex)
                {
                    ErrorHelper.ShowErrorBox(e: ex);
                }
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            keeper.FileSave();
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            if (fdSaveData.ShowDialog() == DialogResult.OK)
            {
                FileOptionsForm form = new FileOptionsForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.PasswordProtection)
                    {
                        keeper.Password = form.Password;
                    }
                    else
                    {
                        keeper.Password = String.Empty;
                    }
                    keeper.Filename = fdSaveData.FileName;
                    keeper.FileSave();
                    updateFormTitle();
                }
            }
        }

        #endregion

        #region Hot key management

        private void WelcomeScreenForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (HotKeyHelper.GetShortcut(e))
            {
                case KeyShortcut.NewIncomeTransaction:
                    //tsmiTransactions.Select();
                    tsmiTransactions.ShowDropDown();
                    //tsmiNewIncome.Select();
                    tsmiNewIncome.ShowDropDown();
                    if (tsmiNewIncome.DropDownItems.Count > 0)
                    {
                        tsmiNewIncome.DropDownItems[0].Select();
                    }
                    break;

                case KeyShortcut.NewPaymentTransaction:
                    //tsmiTransactions.Select();
                    tsmiTransactions.ShowDropDown();
                    //tsmiNewPayment.Select();
                    tsmiNewPayment.ShowDropDown();
                    if (tsmiNewPayment.DropDownItems.Count > 0)
                    {
                        tsmiNewPayment.DropDownItems[0].Select();
                    }
                    break;
            }
        }

        #endregion

        private void btnPrevDay_Click(object sender, EventArgs e)
        {
            statsDay = statsDay.AddDays(-1);
            updateStatsDay();
            updateStatsButtons();
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            statsMonth = statsMonth.AddMonths(-1);
            updateStatsMonth();
            updateStatsButtons();
        }

        private void btnPrevYear_Click(object sender, EventArgs e)
        {
            statsYear = statsYear.AddYears(-1);
            updateStatsYear();
            updateStatsButtons();
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            statsDay = statsDay.AddDays(1);
            updateStatsDay();
            updateStatsButtons();
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            statsMonth = statsMonth.AddMonths(1);
            updateStatsMonth();
            updateStatsButtons();
        }

        private void btnNextYear_Click(object sender, EventArgs e)
        {
            statsYear = statsYear.AddYears(1);
            updateStatsYear();
            updateStatsButtons();
        }

        private void tsmiImport_Click(object sender, EventArgs e)
        {
            FileImportForm form = new FileImportForm();
            form.ShowDialog();
            refreshForm();
        }

    }
}
