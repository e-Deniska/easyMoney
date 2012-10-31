using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using easyMoney.Data;
using System.Globalization;
using easyMoney.Utilities;

namespace easyMoney.Manager.Forms
{
    public partial class TransactionEditForm : Form
    {

        #region Class members

        private MoneyDataKeeper keeper = null;
        private MoneyDataSet.TransactionTemplatesRow template = null;
        private MoneyDataSet.PlannedTransactionsRow sourcePlan = null;
        private MoneyDataSet.PlannedTransactionsRow destinationPlan = null;
        private IEnumerable<MoneyDataSet.AccountsRow> sourceAccounts = null;
        private IEnumerable<MoneyDataSet.AccountsRow> destinationAccounts = null;
        private IEnumerable<MoneyDataSet.PlannedTransactionsRow> sourcePlans = null;
        private MoneyDataSet.AccountsRow sourceAccountSelected = null;
        private MoneyDataSet.AccountsRow destinationAccountSelected = null;
        private MoneyDataSet.TransactionsRow transaction = null;

        #endregion

        #region Edited element accessor

        public MoneyDataSet.TransactionsRow UpdatedTransaction
        {
            get { return transaction; }
        }

        #endregion

        #region Init/load

        public TransactionEditForm(MoneyDataSet.TransactionTemplatesRow template, MoneyDataSet.PlannedTransactionsRow plan = null)
        {
            InitializeComponent();
            this.keeper = MoneyDataKeeper.Instance;
            this.template = template;
            this.sourcePlan = plan;

            sourceAccounts = keeper.GetAccounts(template.AccountTypesRowByFK_AccountTypes_Source_TransactionTemplates,
                template.ExactSourceAccountType);

            if (template.HasDestinationAccount)
            {
                if (sourcePlan != null)
                {
                    int pairID = sourcePlan.PairReferenceID;
                    sourcePlan = null;

                    // trying to find source and destination plans
                    foreach(MoneyDataSet.PlannedTransactionsRow pairedPlan in keeper.PlannedTransactions.Where(p =>
                        ((!p.IsPairReferenceIDNull()) && (p.PairReferenceID != 0) && (p.PairReferenceID == pairID))))
                    {
                        if (pairedPlan.TransactionTypeID.Equals(template.SourceTransactionTypeID))
                        {
                            sourcePlan = pairedPlan;
                        }
                        if (pairedPlan.TransactionTypeID.Equals(template.DestinationTransactionTypeID))
                        {
                            destinationPlan = pairedPlan;
                        }
                    }
                }

                destinationAccounts = keeper.GetAccounts(template.AccountTypesRowByFK_AccountTypes_Destination_TransactionTemplates,
                    template.ExactDestinationAccountType);
            }
        }

        private void TransactionFromTemplateForm_Load(object sender, EventArgs e)
        {
            if (!PreCheck())
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }

            this.Text = template.Title;

            tbTitle.AutoCompleteCustomSource.AddRange(keeper.GetTextHistory(String.Format(Consts.Keeper.TransactionTitleHistoryIDFormat, template.ID)));

            lblTransactionMessage.Text = template.Message;

            tbTitle.Text = template.TransactionDefaultTitle;
            ttbTags.SetAvailableTags(keeper.Tags);

            cbSourceAccount.DisplayMember = MoneyDataSet.IDs.SpecialColumns.FullTitleColumnName;
            cbSourceAccount.ValueMember = keeper.DataSet.Accounts.IDColumn.ColumnName;
            // cbSourceAccount.DataSource = sourceAccounts;
            foreach (var account in sourceAccounts)
            {
                cbSourceAccount.Items.Add(account);
            }
            cbSourceAccount.SelectedIndex = 0;

            updateSourceCurrency();

            cbSourcePlan.DisplayMember = MoneyDataSet.IDs.SpecialColumns.FullTitleColumnName;
            cbSourcePlan.ValueMember = keeper.DataSet.PlannedTransactions.IDColumn.ColumnName;
            sourcePlans = keeper.GetRelevantPlannedTransactions(template.SourceTransactionTypeID);
            if (sourcePlans.Any())
            {
                cbSourceImplementsPlan.Enabled = true;
                //cbSourcePlan.DataSource = sourcePlans;
                foreach (var srcPlan in sourcePlans)
                {
                    cbSourcePlan.Items.Add(srcPlan);
                }
                cbSourcePlan.SelectedIndex = 0;
            }

            IEnumerable<MoneyDataSet.PlannedTransactionsRow> destinationPlans = null;

            if (template.HasDestinationAccount)
            {
                cbDestinationAccount.DisplayMember = MoneyDataSet.IDs.SpecialColumns.FullTitleColumnName;
                cbDestinationAccount.ValueMember = keeper.DataSet.Accounts.IDColumn.ColumnName;
                cbDestinationAccount.DataSource = destinationAccounts;

                if (template.IsAmountIdentical)
                {
                    numDestinationAmount.Enabled = false;
                }
                updateDestinationCurrency();
                updateDestinationAmount();

                destinationPlans = keeper.GetRelevantPlannedTransactions(template.DestinationTransactionTypeID);
                if (destinationPlans.Any())
                {
                    cbDestinationImplementsPlan.Enabled = true;
                    cbDestinationPlan.DisplayMember = MoneyDataSet.IDs.SpecialColumns.FullTitleColumnName;
                    cbDestinationPlan.ValueMember = keeper.DataSet.PlannedTransactions.IDColumn.ColumnName;
                    // cbDestinationPlan.DataSource = destinationPlans;
                    foreach (var destPlan in destinationPlans)
                    {
                        cbDestinationPlan.Items.Add(destPlan);
                    }
                    cbDestinationPlan.SelectedIndex = 0;
                }
            }
            else
            {
                tlpTemplateTransaction.Controls.Remove(gbDestination);
                tlpTemplateTransaction.SetColumnSpan(gbSource, 2);

                // renaming Source to Account
                gbSource.Text = Resources.Labels.AccountAmountGroupBoxLabel;
            }

            if ((sourcePlan != null) && (sourcePlans.Contains(sourcePlan)))
            {
                cbSourceImplementsPlan.Checked = true;
                cbSourcePlan.SelectedItem = sourcePlan;
                cbSourcePlan_SelectionChangeCommitted(null, null);
            }

            if ((template.HasDestinationAccount) && (destinationPlan != null) && ((destinationPlans != null) && (destinationPlans.Contains(destinationPlan))))
            {
                cbDestinationImplementsPlan.Checked = true;
                cbDestinationPlan.SelectedItem = sourcePlan;
                cbDestinationPlan_SelectionChangeCommitted(null, null);
            }
            numSourceAmount.Select(0, Int32.MaxValue);
            numDestinationAmount.Select(0, Int32.MaxValue);
        }

        #endregion

        #region Template validity check

        public bool PreCheck()
        {
            if (!sourceAccounts.Any())
            {
                MessageBox.Show(String.Format(Resources.Labels.TemplateAccountNotFoundFormat,
                    template.AccountTypesRowByFK_AccountTypes_Source_TransactionTemplates.Title),
                    Resources.Labels.TemplateAccountNotFoundTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (template.HasDestinationAccount)
            {
                if (!destinationAccounts.Any())
                {
                    MessageBox.Show(String.Format(Resources.Labels.TemplateAccountNotFoundFormat,
                        template.AccountTypesRowByFK_AccountTypes_Destination_TransactionTemplates.Title),
                        Resources.Labels.TemplateAccountNotFoundTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Button handlers

        private void btnOk_Click(object sender, EventArgs e)
        {
            tbTitle.Text = tbTitle.Text.Trim();

            MoneyDataSet.AccountsRow sourceAccount = cbSourceAccount.SelectedItem as MoneyDataSet.AccountsRow;
            double sourceAmount = (double)numSourceAmount.Value;

            MoneyDataSet.PlannedTransactionsRow sourcePlan = null;
            if (cbSourceImplementsPlan.Checked)
            {
                sourcePlan = cbSourcePlan.SelectedItem as MoneyDataSet.PlannedTransactionsRow;
            }

            MoneyDataSet.TransactionsRow preCreateSource =
                keeper.PreCreateTransaction(template.TransactionTypesRowByFK_TransactionTypes_Source_TransactionTemplates,
                tbTitle.Text, tbDescription.Text, dtpTransactionDate.Value, sourceAccount, sourceAmount, 
                plan: sourcePlan, template: template);

            MoneyDataSet.TransactionsRow preCreateDestination = null;

            ValidationResult resultSource = keeper.Validate(transaction: preCreateSource);
            ValidationResult resultDestination = new ValidationResult(success: true, preventAction: false, message: String.Empty);
            
            if (template.HasDestinationAccount)
            {
                MoneyDataSet.AccountsRow destinationAccount = cbDestinationAccount.SelectedItem as MoneyDataSet.AccountsRow;
                double destinationAmount = (double)numDestinationAmount.Value;

                MoneyDataSet.PlannedTransactionsRow destinationPlan = null;
                if (cbDestinationImplementsPlan.Checked)
                {
                    destinationPlan = cbDestinationPlan.SelectedItem as MoneyDataSet.PlannedTransactionsRow;
                }

                preCreateDestination = keeper.PreCreateTransaction(template.TransactionTypesRowByFK_TransactionTypes_Destination_TransactionTemplates,
                    tbTitle.Text, tbDescription.Text, dtpTransactionDate.Value, destinationAccount, destinationAmount, 
                    plan: destinationPlan, template: template, pairReference: preCreateSource.ID);
                
                resultDestination = keeper.Validate(transaction: preCreateDestination);
            }

            if (!((resultSource.Success) && (resultDestination.Success)))
            {
                StringBuilder message = new StringBuilder();

                if (String.IsNullOrWhiteSpace(resultSource.Message))
                {
                    message.AppendLine(Resources.Labels.TransactionDestinationValidation);
                    message.Append(resultDestination.Message);
                }
                else if (String.IsNullOrWhiteSpace(resultDestination.Message))
                {
                    if (template.HasDestinationAccount)
                    {
                        message.AppendLine(Resources.Labels.TransactionSourceValidation);
                    }
                    message.Append(resultSource.Message);
                }
                else
                {
                    message.Append(String.Join(Environment.NewLine, new String[] { Resources.Labels.TransactionSourceValidation,
                        resultSource.Message, String.Empty, Resources.Labels.TransactionDestinationValidation,
                        resultDestination.Message }));
                }

                if ((resultSource.PreventAction) || (resultDestination.PreventAction))
                {
                    MessageBox.Show(String.Format(Resources.Labels.TransactionValidationErrorsFoundFormat, message.ToString()),
                        Resources.Labels.TransactionValidationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                else
                {
                    if (MessageBox.Show(String.Format(Resources.Labels.TransactionValidationWarningsFoundFormat, message.ToString()),
                        Resources.Labels.TransactionValidationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }

            transaction = keeper.CreateTransaction(preCreateSource, ttbTags.Tags);
            if (template.HasDestinationAccount)
            {
                keeper.CreateTransaction(preCreateDestination, ttbTags.Tags);
            }

            keeper.AddTextHistory(String.Format(Consts.Keeper.TransactionTitleHistoryIDFormat, template.ID), tbTitle.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region Other control handlers

        private void cbSourceAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateSourceCurrency();
            updateDestinationAmount();
        }

        private void cbDestinationAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateDestinationCurrency();
            updateDestinationAmount();
        }

        private void numSourceAmount_ValueChanged(object sender, EventArgs e)
        {
            updateDestinationAmount();
        }

        private void cbSourceImplementsPlan_CheckedChanged(object sender, EventArgs e)
        {
            cbSourcePlan.Enabled = cbSourceImplementsPlan.Checked;
            if (cbSourcePlan.Enabled)
            {
                cbSourcePlan_SelectionChangeCommitted(null, null);
            }
        }

        private void cbDestinationImplementsPlan_CheckedChanged(object sender, EventArgs e)
        {
            cbDestinationPlan.Enabled = cbDestinationImplementsPlan.Checked;
            if (cbDestinationPlan.Enabled)
            {
                cbDestinationPlan_SelectionChangeCommitted(null, null);
            }
        }

        private void cbSourcePlan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MoneyDataSet.PlannedTransactionsRow plan = cbSourcePlan.SelectedItem as MoneyDataSet.PlannedTransactionsRow;
            // protection from old schema
            if (plan.TransactionTemplatesRow == null)
            {
                ErrorHelper.ShowErrorBox(ErrorHelper.Errors.PlanTemplateIsNull);
                return;
            }

            // cbSourceAccount.DataSource = keeper.GetAccounts(plan.AccountTypeRow, plan.TransactionTemplatesRow.ExactSourceAccountType);
            cbSourceAccount.Items.Clear();
            foreach (var acc in keeper.GetAccounts(plan.AccountTypeRow, plan.TransactionTemplatesRow.ExactSourceAccountType))
            {
                cbSourceAccount.Items.Add(acc);
            }
            cbSourceAccount.SelectedIndex = 0;
            cbSourceAccount_SelectionChangeCommitted(null, null);

            MoneyDataSet.AccountsRow account = cbSourceAccount.SelectedItem as MoneyDataSet.AccountsRow;

            if (!plan.IsAggregated)
            {
                numSourceAmount.Value = (decimal)(plan.Amount * plan.CurrenciesRow.ExchangeRate / account.CurrenciesRow.ExchangeRate);
            }
            else
            {
                numSourceAmount.Value = 0;
            }

            numSourceAmount.Select(0, Int32.MaxValue);

            if ((tbTitle.Text.Equals(template.TransactionDefaultTitle)) || (sourcePlans.Count(p => (p.Title.Equals(tbTitle.Text))) > 0))
            {
                if (String.IsNullOrWhiteSpace(plan.Title))
                {
                    tbTitle.Text = template.Title;
                }
                else
                {
                    tbTitle.Text = plan.Title;
                }
            }
            ttbTags.Tags = keeper.GetPlannedTransactionTagStrings(plan);
        }

        private void cbDestinationPlan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MoneyDataSet.PlannedTransactionsRow plan = cbDestinationPlan.SelectedItem as MoneyDataSet.PlannedTransactionsRow;

            // protection from old schema
            if (plan.TransactionTemplatesRow == null)
            {
                ErrorHelper.ShowErrorBox(ErrorHelper.Errors.PlanTemplateIsNull);
                return;
            }

            // cbDestinationAccount.DataSource = keeper.GetAccounts(plan.AccountTypeRow, plan.TransactionTemplatesRow.ExactDestinationAccountType);
            cbDestinationAccount.Items.Clear();
            foreach (var acc in keeper.GetAccounts(plan.AccountTypeRow, plan.TransactionTemplatesRow.ExactDestinationAccountType))
            {
                cbDestinationAccount.Items.Add(acc);
            }
            cbDestinationAccount.SelectedIndex = 0;
            
            cbDestinationAccount_SelectionChangeCommitted(null, null);

            if (!plan.IsAggregated)
            {
                MoneyDataSet.AccountsRow account = cbDestinationAccount.SelectedItem as MoneyDataSet.AccountsRow;
                numDestinationAmount.Value = (decimal)(plan.Amount * plan.CurrenciesRow.ExchangeRate / account.CurrenciesRow.ExchangeRate);
            }
            else
            {
                numDestinationAmount.Value = 0;
            }
            numDestinationAmount.Select(0, Int32.MaxValue);
        }

        #endregion

        #region Key shortcuts handler

        private void TransactionFromTemplateForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (HotKeyHelper.GetShortcut(e))
            {
                case KeyShortcut.Save:
                    btnOk.PerformClick();
                    break;

                case KeyShortcut.Cancel:
                    if (ttbTags.PopupOpened)
                    {
                        ttbTags.PopupOpened = false;
                        e.SuppressKeyPress = true;
                    }
                    else if (cbSourceAccount.DroppedDown)
                    {
                        cbSourceAccount.DroppedDown = false;
                        e.SuppressKeyPress = true;
                    }
                    else if (cbSourcePlan.DroppedDown)
                    {
                        cbSourcePlan.DroppedDown = false;
                        e.SuppressKeyPress = true;
                    }
                    else if (cbDestinationAccount.DroppedDown)
                    {
                        cbDestinationAccount.DroppedDown = false;
                        e.SuppressKeyPress = true;
                    }
                    else if (cbDestinationPlan.DroppedDown)
                    {
                        cbDestinationPlan.DroppedDown = false;
                        e.SuppressKeyPress = true;
                    }
                    else
                    {
                        btnCancel.PerformClick();
                    }
                    break;
            }
        }
        
        #endregion

        #region Form control update routines

        private void updateSourceCurrency()
        {
            if (cbSourceAccount.SelectedItem != null)
            {
                MoneyDataSet.AccountsRow account = cbSourceAccount.SelectedItem as MoneyDataSet.AccountsRow;
                MoneyDataSet.CurrenciesRow currency = account.CurrenciesRow;
                lblSourceCurrency.Visible = false;
                numSourceAmount.Visible = false;
                CultureInfo culture = account.CurrenciesRow.CurrencyCultureInfo;
                lblSourceBalance.Text = String.Format(culture, Resources.Labels.BalanceFormat, account.Balance);
                lblSourceCurrency.Text = culture.NumberFormat.CurrencySymbol;

                if (sourceAccountSelected != null)
                {
                    numSourceAmount.Value = (decimal)(((double)numSourceAmount.Value) * 
                        sourceAccountSelected.CurrenciesRow.ExchangeRate / currency.ExchangeRate);
                    numSourceAmount.Select(0, Int32.MaxValue);
                }

                if (currency.IsSymbolAfterAmount)
                {
                    tlpSource.SetCellPosition(lblSourceCurrency, new TableLayoutPanelCellPosition(2, 6));
                    tlpSource.SetCellPosition(numSourceAmount, new TableLayoutPanelCellPosition(0, 6));
                    lblSourceCurrency.TextAlign = ContentAlignment.MiddleLeft;
                    lblSourceCurrency.Dock = DockStyle.Left;
                }
                else
                {
                    tlpSource.SetCellPosition(lblSourceCurrency, new TableLayoutPanelCellPosition(0, 6));
                    tlpSource.SetCellPosition(numSourceAmount, new TableLayoutPanelCellPosition(1, 6));
                    lblSourceCurrency.TextAlign = ContentAlignment.MiddleRight;
                    lblSourceCurrency.Dock = DockStyle.Right;
                }

                lblSourceCurrency.Visible = true;
                numSourceAmount.Visible = true;
                sourceAccountSelected = account;
            }
        }

        private void updateDestinationCurrency()
        {
            if ((template.HasDestinationAccount) && (cbDestinationAccount.SelectedItem != null))
            {
                MoneyDataSet.AccountsRow account = cbDestinationAccount.SelectedItem as MoneyDataSet.AccountsRow;
                MoneyDataSet.CurrenciesRow currency = account.CurrenciesRow;
                lblDestinationCurrency.Visible = false;
                numDestinationAmount.Visible = false;
                CultureInfo culture = account.CurrenciesRow.CurrencyCultureInfo;
                lblDestinationBalance.Text = String.Format(culture, Resources.Labels.BalanceFormat, account.Balance);
                lblDestinationCurrency.Text = culture.NumberFormat.CurrencySymbol;

                if (destinationAccountSelected != null)
                {
                    numDestinationAmount.Value = (decimal)(((double)numDestinationAmount.Value) *
                        destinationAccountSelected.CurrenciesRow.ExchangeRate / currency.ExchangeRate);
                    numDestinationAmount.Select(0, Int32.MaxValue);
                }

                if (currency.IsSymbolAfterAmount)
                {
                    tlpDestination.SetCellPosition(lblDestinationCurrency, new TableLayoutPanelCellPosition(2, 6));
                    tlpDestination.SetCellPosition(numDestinationAmount, new TableLayoutPanelCellPosition(0, 6));
                    lblDestinationCurrency.TextAlign = ContentAlignment.MiddleLeft;
                    lblDestinationCurrency.Dock = DockStyle.Left;
                }
                else
                {
                    tlpDestination.SetCellPosition(lblDestinationCurrency, new TableLayoutPanelCellPosition(0, 6));
                    tlpDestination.SetCellPosition(numDestinationAmount, new TableLayoutPanelCellPosition(1, 6));
                    lblDestinationCurrency.TextAlign = ContentAlignment.MiddleRight;
                    lblDestinationCurrency.Dock = DockStyle.Right;
                }

                lblDestinationCurrency.Visible = true;
                numDestinationAmount.Visible = true;
                destinationAccountSelected = account;
            }
        }

        private void updateDestinationAmount()
        {
            if (template.HasDestinationAccount)
            {
                MoneyDataSet.AccountsRow source = cbSourceAccount.SelectedItem as MoneyDataSet.AccountsRow;
                MoneyDataSet.AccountsRow destination = cbDestinationAccount.SelectedItem as MoneyDataSet.AccountsRow;
                double amount = ((double)numSourceAmount.Value) * source.CurrenciesRow.ExchangeRate /
                    destination.CurrenciesRow.ExchangeRate;
                numDestinationAmount.Value = (decimal)amount;
                numDestinationAmount.Select(0, Int32.MaxValue);
            }
        }

        #endregion
        
    }
}
