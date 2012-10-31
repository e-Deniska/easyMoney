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
    public partial class TransactionTypeForm : Form
    {

        #region Form members

        private MoneyDataSet.TransactionTypesRow existingItem = null;
        private MoneyDataKeeper keeper = null;

        #endregion

        #region Form init/load

        public TransactionTypeForm(MoneyDataSet.TransactionTypesRow existingItem)
        {
            InitializeComponent();
            this.keeper = MoneyDataKeeper.Instance;
            this.existingItem = existingItem;
        }

        private void TransactionTypeForm_Load(object sender, EventArgs e)
        {
            if (existingItem != null)
            {
                tbID.Text = existingItem.ID;
                tbTitle.Text = existingItem.Title;
                tbDescription.Text = existingItem.Description;
                cbIsIncome.Checked = existingItem.IsIncome;
                tbID.ReadOnly = true;

                if (!existingItem.ID.StartsWith(Consts.Keeper.UserMetadataPrefix))
                {
                    tbTitle.ReadOnly = true;
                    tbDescription.ReadOnly = true;
                    btnDelete.Enabled = false;
                    cbIsIncome.Enabled = false;
                }
            }
            else
            {
                tbID.Text = Consts.Keeper.UserMetadataPrefix + Guid.NewGuid().ToString().ToUpper();
                btnDelete.Enabled = false;
            }
        }

        #endregion

        #region Form button hanlders

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // some additional checks (we're deleting only user metadata)
            if ((existingItem != null) && (existingItem.ID.StartsWith(Consts.Keeper.UserMetadataPrefix)))
            {
                if (MessageBox.Show(Resources.Labels.DeleteTransactionTypeText, Resources.Labels.DeleteItemTitle,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    keeper.DataSet.TransactionTypes.RemoveTransactionTypesRow(existingItem);
                    keeper.DataSet.AcceptChanges();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (existingItem != null)
            {
                if (existingItem.ID.StartsWith(Consts.Keeper.UserMetadataPrefix))
                {
                    existingItem.Title = tbTitle.Text.Trim();
                    existingItem.Description = tbDescription.Text.Trim();
                    existingItem.IsIncome = cbIsIncome.Checked;
                }
            }
            else
            {
                String ID = tbID.Text.Trim().ToUpper();
                if (keeper.DataSet.TransactionTypes.FindByID(ID) != null)
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

                MoneyDataSet.TransactionTypesRow transactionType = keeper.DataSet.TransactionTypes.NewTransactionTypesRow();
                transactionType.ID = ID;
                transactionType.Title = tbTitle.Text.Trim();
                transactionType.Description = tbDescription.Text.Trim();
                transactionType.IsIncome = cbIsIncome.Checked;
                keeper.DataSet.TransactionTypes.AddTransactionTypesRow(transactionType);
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

        #endregion

        #region Keyboard hotkeys

        private void TransactionTypeForm_KeyDown(object sender, KeyEventArgs e)
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
