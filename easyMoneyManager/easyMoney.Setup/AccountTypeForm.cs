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
    public partial class AccountTypeForm : Form
    {

        #region Form members

        private MoneyDataSet.AccountTypesRow existingItem = null;
        private MoneyDataKeeper keeper = null;

        #endregion

        #region Form init/load

        public AccountTypeForm(MoneyDataSet.AccountTypesRow existingItem)
        {
            InitializeComponent();
            this.keeper = MoneyDataKeeper.Instance;
            this.existingItem = existingItem;
        }

        private void AccountTypeForm_Load(object sender, EventArgs e)
        {
            if (existingItem != null)
            {
                tbID.Text = existingItem.ID;
                tbTitle.Text = existingItem.Title;
                tbDescription.Text = existingItem.Description;
                numSortOrder.Value = (decimal)existingItem.SortOrder;
                cbIsDebit.Checked = existingItem.IsDebit;

                tbID.ReadOnly = true;

                if (!existingItem.ID.StartsWith(Consts.Keeper.UserMetadataPrefix))
                {
                    tbTitle.ReadOnly = true;
                    tbDescription.ReadOnly = true;
                    btnDelete.Enabled = false;
                    cbIsDebit.Enabled = false;
                }
            }
            else
            {
                tbID.Text = Consts.Keeper.UserMetadataPrefix + Guid.NewGuid().ToString().ToUpper();
                btnDelete.Enabled = false;
            }
            numSortOrder.Select(0, Int32.MaxValue);
        }

        #endregion

        #region Form button hanlders

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // some additional checks (we're deleting only user metadata)
            if ((existingItem != null) && (existingItem.ID.StartsWith(Consts.Keeper.UserMetadataPrefix)))
            {
                if (MessageBox.Show(Resources.Labels.DeleteAccountTypeText, Resources.Labels.DeleteItemTitle,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    keeper.DataSet.AccountTypes.RemoveAccountTypesRow(existingItem);
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
                    existingItem.IsDebit = cbIsDebit.Checked;
                }
                existingItem.SortOrder = (int)numSortOrder.Value;
            }
            else
            {
                String ID = tbID.Text.Trim().ToUpper();
                if (keeper.DataSet.AccountTypes.FindByID(ID) != null)
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

                MoneyDataSet.AccountTypesRow accountType = keeper.DataSet.AccountTypes.NewAccountTypesRow();
                accountType.ID = ID;
                accountType.Title = tbTitle.Text.Trim();
                accountType.Description = tbDescription.Text.Trim();
                accountType.SortOrder = (int)numSortOrder.Value;
                accountType.IsDebit = cbIsDebit.Checked;
                keeper.DataSet.AccountTypes.AddAccountTypesRow(accountType);
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

        private void AccountTypeForm_KeyDown(object sender, KeyEventArgs e)
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
