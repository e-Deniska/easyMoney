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
    public partial class PlanEditForm : Form
    {

        #region Class members

        private MoneyDataKeeper keeper = null;
        private MoneyDataSet.TransactionTemplatesRow template = null;
        private MoneyDataSet.PlannedTransactionsRow sourcePlan = null;
        private MoneyDataSet.PlannedTransactionsRow destinationPlan = null;
        private MoneyDataSet.PlannedTransactionsRow selectedPlan = null;
        private bool isCopy = false;

        #endregion

        #region Form properties

        public MoneyDataSet.PlannedTransactionsRow UpdatedPlan
        {
            get { return selectedPlan; }
        }

        #endregion

        #region Init/load

        public PlanEditForm(MoneyDataSet.TransactionTemplatesRow template,
            MoneyDataSet.PlannedTransactionsRow sourcePlan = null, MoneyDataSet.PlannedTransactionsRow destinationPlan = null, bool isCopy = false)
        {
            InitializeComponent();
            this.keeper = MoneyDataKeeper.Instance;
            this.template = template;
            this.sourcePlan = sourcePlan;
            this.destinationPlan = destinationPlan;
            this.isCopy = isCopy;
        }

        private void PlanFromTemplateForm_Load(object sender, EventArgs e)
        {
            // some pre-checks
            if (template == null)
            {
                ErrorHelper.ShowErrorBox(ErrorHelper.Errors.PlanTemplateIsNull);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            if ((sourcePlan != null) && (template.HasDestinationAccount) && (destinationPlan == null))
            {
                ErrorHelper.ShowErrorBox(ErrorHelper.Errors.PlanDestinationAccountIsNull);
                Log.Write("Source plan", sourcePlan);
                Log.Write("Template", template);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            this.Text = String.Format(Resources.Labels.PlannedTemplateFormat, template.Title);
            lblTransactionMessage.Text = template.Message;

            tbTitle.AutoCompleteCustomSource.AddRange(keeper.GetTextHistory(String.Format(Consts.Keeper.TransactionTitleHistoryIDFormat, template.ID)));

            if (sourcePlan != null)
            {
                if (isCopy)
                {
                    tbTitle.Text = String.Format(Resources.Labels.CopyFormat, sourcePlan.Title);
                }
                else
                {
                    tbTitle.Text = sourcePlan.Title;
                }

                cbIsAggregated.Checked = sourcePlan.IsAggregated;
            }
            else
            {
                tbTitle.Text = template.TransactionDefaultTitle;
            }
            ttbTags.SetAvailableTags(keeper.Tags);


            cbSourceAccountType.DisplayMember = keeper.DataSet.AccountTypes.TitleColumn.ColumnName;
            cbSourceAccountType.ValueMember = keeper.DataSet.AccountTypes.IDColumn.ColumnName;
            // cbSourceAccountType.DataSource = keeper.GetAccountTypes(template.AccountTypesRowByFK_AccountTypes_Source_TransactionTemplates,
            //    template.ExactSourceAccountType);
            foreach (var accountType in keeper.GetAccountTypes(template.AccountTypesRowByFK_AccountTypes_Source_TransactionTemplates, template.ExactSourceAccountType))
            {
                cbSourceAccountType.Items.Add(accountType);
            }
            cbSourceAccountType.SelectedIndex = 0;

            cbSourceCurrency.DisplayMember = keeper.DataSet.Currencies.TitleColumn.ColumnName;
            cbSourceCurrency.ValueMember = keeper.DataSet.Currencies.IDColumn.ColumnName;
            //cbSourceCurrency.DataSource = keeper.Currencies;
            cbDestinationCurrency.DisplayMember = keeper.DataSet.Currencies.TitleColumn.ColumnName;
            cbDestinationCurrency.ValueMember = keeper.DataSet.Currencies.IDColumn.ColumnName;
            //cbDestinationCurrency.DataSource = keeper.Currencies;

            foreach (MoneyDataSet.CurrenciesRow currency in keeper.Currencies)
            {
                cbSourceCurrency.Items.Add(currency);
                cbDestinationCurrency.Items.Add(currency);
            }
            cbSourceCurrency.SelectedIndex = 0;
            cbDestinationCurrency.SelectedIndex = 0;

            cbRecurrency.DisplayMember = keeper.DataSet.Recurrencies.TitleColumn.ColumnName;
            cbRecurrency.ValueMember = keeper.DataSet.Recurrencies.IDColumn.ColumnName;
            // cbRecurrency.DataSource = keeper.Recurrencies;
            foreach (var recurrency in keeper.Recurrencies)
            {
                cbRecurrency.Items.Add(recurrency);
            }
            cbRecurrency.SelectedIndex = 0;

            cbRecurrency_SelectionChangeCommitted(null, null);

            if (template.HasDestinationAccount)
            {
                cbDestinationAccountType.DisplayMember = keeper.DataSet.AccountTypes.TitleColumn.ColumnName;
                cbDestinationAccountType.ValueMember = keeper.DataSet.AccountTypes.IDColumn.ColumnName;
                //cbDestinationAccountType.DataSource = keeper.GetAccountTypes(template.AccountTypesRowByFK_AccountTypes_Destination_TransactionTemplates,
                //    template.ExactDestinationAccountType);
                foreach (var accountType in keeper.GetAccountTypes(template.AccountTypesRowByFK_AccountTypes_Destination_TransactionTemplates, template.ExactDestinationAccountType))
                {
                    cbDestinationAccountType.Items.Add(accountType);
                }
                cbDestinationAccountType.SelectedIndex = 0;

                if (template.IsAmountIdentical)
                {
                    numDestinationAmount.Enabled = false;
                }
                updateDestinationAmount();
            }
            else
            {
                tlpTemplatePlan.Controls.Remove(gbDestination);
                tlpTemplatePlan.SetColumnSpan(gbSource, 2);

                // renaming Source to Account
                gbSource.Text = Resources.Labels.AccountAmountGroupBoxLabel;
            }

            if (sourcePlan != null)
            {
                cbSourceAccountType.SelectedItem = sourcePlan.AccountTypeRow;
                cbSourceCurrency.SelectedItem = sourcePlan.CurrenciesRow;
                cbRecurrency.SelectedItem = sourcePlan.RecurrenciesRow;
                ttbTags.Tags = keeper.GetPlannedTransactionTagStrings(sourcePlan);
                numSourceAmount.Value = (decimal)sourcePlan.Amount;

                if (sourcePlan.IsStartTimeNull())
                {
                    dtpStartDate.Checked = false;
                }
                else
                {
                    dtpStartDate.Checked = true;
                    dtpStartDate.Value = sourcePlan.StartTime;
                }
                dtpStartDate_ValueChanged(null, null);

                if (destinationPlan != null)
                {
                    cbDestinationAccountType.SelectedItem = destinationPlan.AccountTypeRow;
                    cbDestinationCurrency.SelectedItem = destinationPlan.CurrenciesRow;
                    numDestinationAmount.Value = (decimal)destinationPlan.Amount;
                }
            }
            else
            {
                dtpStartDate.Checked = true;
            }

            if ((sourcePlan != null) && (!sourcePlan.RecurrencyID.Equals(MoneyDataSet.IDs.Recurrencies.None)) && (!sourcePlan.IsEndTimeNull()))
            {
                dtpEndDate.Value = sourcePlan.EndTime;
                dtpEndDate.Enabled = true;
                lblEndDate.Enabled = true;
            }
            else
            {
                // default end date - next month, unchecked
                dtpEndDate.Value = DateTime.Now.AddMonths(1);
                dtpEndDate.Checked = false;
                lblEndDate.Enabled = false;
            }

            if (isCopy)
            {
                // clearing info, so submit will create new entries
                sourcePlan = null;
                destinationPlan = null;
            }
            numSourceAmount.Select(0, Int32.MaxValue);
            numDestinationAmount.Select(0, Int32.MaxValue);
        }

        #endregion

        #region Button handlers

        private void btnOk_Click(object sender, EventArgs e)
        {
            tbTitle.Text = tbTitle.Text.Trim();

            DateTime? startDate = null;
            DateTime? endDate = null;
            MoneyDataSet.RecurrenciesRow recurrency = cbRecurrency.SelectedItem as MoneyDataSet.RecurrenciesRow;
            if (dtpStartDate.Checked)
            {
                startDate = dtpStartDate.Value;
            }
            else
            {
                recurrency = keeper.Recurrencies.SingleOrDefault(r => (r.ID.Equals(MoneyDataSet.IDs.Recurrencies.None)));
            }

            if ((dtpEndDate.Enabled) && (dtpEndDate.Checked))
            {
                endDate = dtpEndDate.Value;
            }

            MoneyDataSet.PlannedTransactionsRow preCreateSource =
                keeper.PreCreatePlannedTransaction(template.TransactionTypesRowByFK_TransactionTypes_Source_TransactionTemplates,
                tbTitle.Text, tbDescription.Text, startDate, cbSourceAccountType.SelectedItem as MoneyDataSet.AccountTypesRow,
                (double)numSourceAmount.Value, cbSourceCurrency.SelectedItem as MoneyDataSet.CurrenciesRow,
                recurrency, endDate, cbIsAggregated.Checked, template);

            MoneyDataSet.PlannedTransactionsRow preCreateDestination = null;

            ValidationResult resultSource = keeper.Validate(plan: preCreateSource);
            ValidationResult resultDestination = new ValidationResult(success: true, preventAction: false, message: String.Empty);

            if (template.HasDestinationAccount)
            {
                preCreateDestination = keeper.PreCreatePlannedTransaction(template.TransactionTypesRowByFK_TransactionTypes_Destination_TransactionTemplates,
                    tbTitle.Text, tbDescription.Text, startDate, cbDestinationAccountType.SelectedItem as MoneyDataSet.AccountTypesRow,
                    (double)numDestinationAmount.Value, cbDestinationCurrency.SelectedItem as MoneyDataSet.CurrenciesRow,
                    recurrency, endDate, cbIsAggregated.Checked, template, preCreateSource.PairReferenceID);

                resultDestination = keeper.Validate(plan: preCreateDestination);
            }

            if (!((resultSource.Success) && (resultDestination.Success)))
            {
                String message = String.Empty;

                if (String.IsNullOrWhiteSpace(resultSource.Message))
                {
                    message = Resources.Labels.TransactionDestinationValidation + resultDestination.Message;
                }
                else if (String.IsNullOrWhiteSpace(resultDestination.Message))
                {
                    if (template.HasDestinationAccount)
                    {
                        message = Resources.Labels.TransactionSourceValidation + Environment.NewLine;
                    }
                    message += resultSource.Message;
                }
                else
                {
                    message = String.Join(Environment.NewLine, new String[] { Resources.Labels.TransactionSourceValidation,
                        resultSource.Message, String.Empty, Resources.Labels.TransactionDestinationValidation,
                        resultDestination.Message });
                }

                if ((resultSource.PreventAction) || (resultDestination.PreventAction))
                {
                    MessageBox.Show(String.Format(Resources.Labels.TransactionValidationErrorsFoundFormat, message),
                        Resources.Labels.TransactionValidationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                else
                {
                    if (MessageBox.Show(String.Format(Resources.Labels.TransactionValidationWarningsFoundFormat, message),
                        Resources.Labels.TransactionValidationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }

            if (sourcePlan != null)
            {
                // updating existing plans
                selectedPlan = keeper.UpdatePlannedTransaction(sourcePlan.ID, preCreateSource.Title, preCreateSource.Description, startDate, preCreateSource.AccountTypeRow,
                    preCreateSource.Amount, preCreateSource.CurrenciesRow, preCreateSource.RecurrenciesRow, endDate, cbIsAggregated.Checked, ttbTags.Tags, template);

                if (template.HasDestinationAccount)
                {
                    keeper.UpdatePlannedTransaction(destinationPlan.ID, preCreateDestination.Title, preCreateDestination.Description, startDate,
                        preCreateDestination.AccountTypeRow, preCreateDestination.Amount, preCreateDestination.CurrenciesRow, preCreateDestination.RecurrenciesRow, endDate,
                        cbIsAggregated.Checked, ttbTags.Tags, template);
                }
            }
            else
            {
                // creating new plans
                selectedPlan = keeper.CreatePlannedTransaction(preCreateSource, ttbTags.Tags);
                if (template.HasDestinationAccount)
                {
                    keeper.CreatePlannedTransaction(preCreateDestination, ttbTags.Tags);
                }
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

        private void numSourceAmount_ValueChanged(object sender, EventArgs e)
        {
            updateDestinationAmount();
        }

        private void cbSourceCurrency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (template.HasDestinationAccount)
            {
                cbDestinationCurrency.SelectedItem = cbSourceCurrency.SelectedItem;
            }
            updateDestinationAmount();
        }

        private void cbRecurrency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MoneyDataSet.RecurrenciesRow recurrency = cbRecurrency.SelectedItem as MoneyDataSet.RecurrenciesRow;
            if (recurrency.ID.Equals(MoneyDataSet.IDs.Recurrencies.None))
            {
                lblEndDate.Enabled = false;
                dtpEndDate.Enabled = false;
            }
            else
            {
                lblEndDate.Enabled = true;
                dtpEndDate.Enabled = true;
            }
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
                    else if (cbSourceAccountType.DroppedDown)
                    {
                        cbSourceAccountType.DroppedDown = false;
                        e.SuppressKeyPress = true;
                    }
                    else if (cbDestinationAccountType.DroppedDown)
                    {
                        cbDestinationAccountType.DroppedDown = false;
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

        private void updateDestinationAmount()
        {
            if (template.HasDestinationAccount)
            {
                MoneyDataSet.CurrenciesRow source = cbSourceCurrency.SelectedItem as MoneyDataSet.CurrenciesRow;
                MoneyDataSet.CurrenciesRow destination = cbDestinationCurrency.SelectedItem as MoneyDataSet.CurrenciesRow;
                double amount = ((double)numSourceAmount.Value) * source.ExchangeRate / destination.ExchangeRate;
                numDestinationAmount.Value = (decimal)amount;
                numDestinationAmount.Select(0, Int32.MaxValue);
            }
        }

        #endregion

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartDate.Checked)
            {
                lblRecurrency.Enabled = true;
                cbRecurrency.Enabled = true;
                cbRecurrency_SelectionChangeCommitted(null, null);
            }
            else
            {
                lblRecurrency.Enabled = false;
                cbRecurrency.Enabled = false;
                lblEndDate.Enabled = false;
                dtpEndDate.Enabled = false;
            }
        }

    }
}
