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

namespace easyMoney.Setup
{
    public partial class TemplateForm : Form
    {

        #region Form members

        private MoneyDataSet.TransactionTemplatesRow existingItem = null;
        private MoneyDataKeeper keeper = null;

        #endregion

        #region Form init/load

        public TemplateForm(MoneyDataSet.TransactionTemplatesRow existingItem)
        {
            InitializeComponent();
            this.keeper = MoneyDataKeeper.Instance;
            this.existingItem = existingItem;
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            // set combobox data sources
            cbSourceAccountType.DisplayMember = keeper.DataSet.AccountTypes.TitleColumn.ColumnName;
            cbSourceAccountType.ValueMember = keeper.DataSet.AccountTypes.IDColumn.ColumnName;
            cbSourceAccountType.DataSource = keeper.DataSet.AccountTypes.ToList();

            cbSourceTransactionType.DisplayMember = keeper.DataSet.TransactionTypes.TitleColumn.ColumnName;
            cbSourceTransactionType.ValueMember = keeper.DataSet.TransactionTypes.IDColumn.ColumnName;
            cbSourceTransactionType.DataSource = keeper.DataSet.TransactionTypes.ToList();

            cbDestinationAccountType.DisplayMember = keeper.DataSet.AccountTypes.TitleColumn.ColumnName;
            cbDestinationAccountType.ValueMember = keeper.DataSet.AccountTypes.IDColumn.ColumnName;
            cbDestinationAccountType.DataSource = keeper.DataSet.AccountTypes.ToList();

            cbDestinationTransactionType.DisplayMember = keeper.DataSet.TransactionTypes.TitleColumn.ColumnName;
            cbDestinationTransactionType.ValueMember = keeper.DataSet.TransactionTypes.IDColumn.ColumnName;
            cbDestinationTransactionType.DataSource = keeper.DataSet.TransactionTypes.ToList();
            
            if (existingItem != null)
            {
                tbID.ReadOnly = true;
                tbID.Text = existingItem.ID;
                tbTitle.Text = existingItem.Title;
                tbMessage.Text = existingItem.Message;
                tbTransactionDefaultTitle.Text = existingItem.TransactionDefaultTitle;
                cbIsVisible.Checked = existingItem.IsVisible;

                if (existingItem.IsIsIncomeNull())
                {
                    cbIsIncome.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    cbIsIncome.Checked = existingItem.IsIncome;
                }
                cbSourceAccountType.SelectedItem = existingItem.AccountTypesRowByFK_AccountTypes_Source_TransactionTemplates;
                cbSourceTransactionType.SelectedItem = existingItem.TransactionTypesRowByFK_TransactionTypes_Source_TransactionTemplates;
                cbExactSourceAccountType.Checked = existingItem.ExactSourceAccountType;
                cbHasDestinationAccount.Checked = existingItem.HasDestinationAccount;
                cbHasDestinationAccount_CheckedChanged(null, null);

                if (existingItem.HasDestinationAccount)
                {
                    cbDestinationAccountType.SelectedItem = existingItem.AccountTypesRowByFK_AccountTypes_Destination_TransactionTemplates;
                    cbDestinationTransactionType.SelectedItem = existingItem.TransactionTypesRowByFK_TransactionTypes_Destination_TransactionTemplates;
                    cbExactDestinationAccountType.Checked = existingItem.ExactDestinationAccountType;
                    cbIsAmountIdentical.Checked = existingItem.IsAmountIdentical;
                }

                if (!existingItem.ID.StartsWith(Consts.Keeper.UserMetadataPrefix))
                {
                    tbTitle.ReadOnly = true;
                    tbMessage.ReadOnly = true;
                    tbTransactionDefaultTitle.ReadOnly = true;
                    cbIsIncome.Enabled = false;
                    cbSourceAccountType.Enabled = false;
                    cbSourceTransactionType.Enabled = false;
                    cbExactSourceAccountType.Enabled = false;
                    cbHasDestinationAccount.Enabled = false;
                    cbDestinationAccountType.Enabled = false;
                    cbDestinationTransactionType.Enabled = false;
                    cbExactDestinationAccountType.Enabled = false;
                    cbIsAmountIdentical.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            else
            {
                tbID.Text = Consts.Keeper.UserMetadataPrefix + Guid.NewGuid().ToString().ToUpper();
                cbHasDestinationAccount_CheckedChanged(null, null);
                cbIsVisible.Checked = true;
                btnDelete.Enabled = false;
            }
        }

        #endregion

        #region Form button handlers

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // some additional checks (we're deleting only user metadata)
            if ((existingItem != null) && (existingItem.ID.StartsWith(Consts.Keeper.UserMetadataPrefix)))
            {
                if (MessageBox.Show(Resources.Labels.DeleteTransactionTypeText, Resources.Labels.DeleteItemTitle,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    keeper.DataSet.TransactionTemplates.RemoveTransactionTemplatesRow(existingItem);
                    keeper.DataSet.AcceptChanges();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // TODO: consider adding some validation or plausibility checks

            if (existingItem != null)
            {
                if (existingItem.ID.StartsWith(Consts.Keeper.UserMetadataPrefix))
                {
                    existingItem.Title = tbTitle.Text.Trim();
                    existingItem.Message = tbMessage.Text.Trim();
                    existingItem.TransactionDefaultTitle = tbTransactionDefaultTitle.Text.Trim();
                    existingItem.TransactionTypesRowByFK_TransactionTypes_Source_TransactionTemplates = 
                        cbSourceTransactionType.SelectedItem as MoneyDataSet.TransactionTypesRow;
                    existingItem.AccountTypesRowByFK_AccountTypes_Source_TransactionTemplates =
                        cbSourceAccountType.SelectedItem as MoneyDataSet.AccountTypesRow;
                    existingItem.ExactSourceAccountType = cbExactSourceAccountType.Checked;
                    if (cbIsIncome.CheckState == CheckState.Indeterminate)
                    {
                        existingItem.SetIsIncomeNull();
                    }
                    else
                    {
                        existingItem.IsIncome = cbIsIncome.Checked;
                    }
                    existingItem.HasDestinationAccount = cbHasDestinationAccount.Checked;
                    if (cbHasDestinationAccount.Checked)
                    {
                        existingItem.TransactionTypesRowByFK_TransactionTypes_Destination_TransactionTemplates =
                            cbDestinationTransactionType.SelectedItem as MoneyDataSet.TransactionTypesRow;
                        existingItem.AccountTypesRowByFK_AccountTypes_Destination_TransactionTemplates =
                            cbDestinationAccountType.SelectedItem as MoneyDataSet.AccountTypesRow;
                        existingItem.ExactDestinationAccountType = cbExactDestinationAccountType.Checked;
                        existingItem.IsAmountIdentical = cbIsAmountIdentical.Checked;
                    }
                }
                existingItem.IsVisible = cbIsVisible.Checked;
            }
            else
            {
                String ID = tbID.Text.Trim().ToUpper();
                if (keeper.DataSet.TransactionTemplates.FindByID(ID) != null)
                {
                    MessageBox.Show(String.Format(Resources.Labels.RecordExistFormat, ID),
                        Resources.Labels.ErrorSavingTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!ID.StartsWith(Consts.Keeper.UserMetadataPrefix))
                {
                    MessageBox.Show(String.Format(Resources.Labels.UserIDShouldHavePrefixFormat, Consts.Keeper.UserMetadataPrefix),
                        Resources.Labels.ErrorSavingTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MoneyDataSet.TransactionTemplatesRow template = keeper.DataSet.TransactionTemplates.NewTransactionTemplatesRow();
                template.ID = ID;
                template.Title = tbTitle.Text.Trim();
                template.Message = tbMessage.Text.Trim();
                template.TransactionDefaultTitle = tbTransactionDefaultTitle.Text.Trim();
                template.TransactionTypesRowByFK_TransactionTypes_Source_TransactionTemplates =
                    cbSourceTransactionType.SelectedItem as MoneyDataSet.TransactionTypesRow;
                template.AccountTypesRowByFK_AccountTypes_Source_TransactionTemplates =
                    cbSourceAccountType.SelectedItem as MoneyDataSet.AccountTypesRow;
                template.ExactSourceAccountType = cbExactSourceAccountType.Checked;
                template.IsVisible = cbIsVisible.Checked;
                if (cbIsIncome.CheckState == CheckState.Indeterminate)
                {
                    template.SetIsIncomeNull();
                }
                else
                {
                    template.IsIncome = cbIsIncome.Checked;
                }
                template.HasDestinationAccount = cbHasDestinationAccount.Checked;
                if (cbHasDestinationAccount.Checked)
                {
                    template.TransactionTypesRowByFK_TransactionTypes_Destination_TransactionTemplates =
                        cbDestinationTransactionType.SelectedItem as MoneyDataSet.TransactionTypesRow;
                    template.AccountTypesRowByFK_AccountTypes_Destination_TransactionTemplates =
                        cbDestinationAccountType.SelectedItem as MoneyDataSet.AccountTypesRow;
                    template.ExactDestinationAccountType = cbExactDestinationAccountType.Checked;
                    template.IsAmountIdentical = cbIsAmountIdentical.Checked;
                }

                keeper.DataSet.TransactionTemplates.AddTransactionTemplatesRow(template);
            }
            keeper.DataSet.AcceptChanges();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbHasDestinationAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHasDestinationAccount.Checked)
            {
                lblDestination.Enabled = true;
                lblDestinationAccountType.Enabled = true;
                lblDestinationTransactionType.Enabled = true;
                cbDestinationAccountType.Enabled = true;
                cbDestinationTransactionType.Enabled = true;
                cbExactDestinationAccountType.Enabled = true;
                cbIsAmountIdentical.Enabled = true;
            }
            else
            {
                lblDestination.Enabled = false;
                lblDestinationAccountType.Enabled = false;
                lblDestinationTransactionType.Enabled = false;
                cbDestinationAccountType.Enabled = false;
                cbDestinationTransactionType.Enabled = false;
                cbExactDestinationAccountType.Enabled = false;
                cbIsAmountIdentical.Enabled = false;
            }
        }

        #endregion

        #region Keyboard shortcuts

        private void TemplateForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (HotKeyHelper.GetShortcut(e))
            {
                case KeyShortcut.Save:
                    btnOk.PerformClick();
                    break;

                case KeyShortcut.Cancel:
                    btnCancel.PerformClick();
                    break;

                case KeyShortcut.Delete:
                    if (btnDelete.Enabled)
                    {
                        btnDelete.PerformClick();
                    }
                    break;
            }
        }

        #endregion
        
    }
}
