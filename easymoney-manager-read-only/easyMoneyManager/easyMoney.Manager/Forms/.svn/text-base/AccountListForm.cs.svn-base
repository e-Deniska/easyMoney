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

namespace easyMoney.Manager.Forms
{
    public partial class AccountListForm : Form
    {
        private MoneyDataKeeper keeper = MoneyDataKeeper.Instance;

        #region Form init/load

        public AccountListForm()
        {
            InitializeComponent();
        }

        private void AccountListForm_Load(object sender, EventArgs e)
        {
            refreshAccounts();
        }

        #endregion

        #region Refresh account list

        private void refreshAccounts()
        {
            dgvAccounts.Rows.Clear();
            foreach (MoneyDataSet.AccountsRow account in keeper.AccountsAll)
            {
                int rowID = dgvAccounts.Rows.Add(account.AccountTypesRow.Title, account.Title, 
                    account.Balance.ToString(Consts.UI.CurrencyFormat, account.CurrenciesRow.CurrencyCultureInfo),
                    account.IsHidden ? Resources.Labels.AccountHidden : String.Empty); 

                dgvAccounts.Rows[rowID].Tag = account;
            }

            if (dgvAccounts.SelectedRows.Count == 0)
            {
                tsbBalance.Enabled = false;
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
            }
            else
            {
                tsbBalance.Enabled = true;
                tsbEdit.Enabled = true;
                tsbDelete.Enabled = true;
            }
        }

        #endregion

        #region Toolstrip button handlers

        private void tsbNewAccount_Click(object sender, EventArgs e)
        {
            AccountEditForm form = new AccountEditForm((sender as ToolStripButton).Equals(tsbNewDebitAccount));
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                AccountCorrectionForm initialBalanceForm = new AccountCorrectionForm(form.UpdatedAccount);
                initialBalanceForm.ShowDialog(this);
                refreshAccounts();
                foreach (DataGridViewRow row in dgvAccounts.Rows)
                {
                    if (row.Tag == form.UpdatedAccount)
                    {
                        dgvAccounts.FirstDisplayedCell = dgvAccounts.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                MoneyDataSet.AccountsRow account = dgvAccounts.SelectedRows[0].Tag as MoneyDataSet.AccountsRow;
                AccountEditForm form = new AccountEditForm(account.AccountTypesRow.IsDebit, account: account);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    refreshAccounts();
                    foreach (DataGridViewRow row in dgvAccounts.Rows)
                    {
                        if (row.Tag == form.UpdatedAccount)
                        {
                            dgvAccounts.FirstDisplayedCell = dgvAccounts.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                }
            }
        }

        private void tsbBalance_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                MoneyDataSet.AccountsRow account = dgvAccounts.SelectedRows[0].Tag as MoneyDataSet.AccountsRow;
                AccountCorrectionForm form = new AccountCorrectionForm(account);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    refreshAccounts();
                    foreach (DataGridViewRow row in dgvAccounts.Rows)
                    {
                        if (row.Tag == form.UpdatedAccount)
                        {
                            dgvAccounts.FirstDisplayedCell = dgvAccounts.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                }
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                if (FormHelper.DeleteAccount(dgvAccounts.SelectedRows[0].Tag as MoneyDataSet.AccountsRow))
                {
                    refreshAccounts();
                }
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Data grid view handlers

        private void dgvAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvAccounts.SelectedRows.Count == 1)
                {
                    AccountViewForm form =
                        new AccountViewForm(dgvAccounts.SelectedRows[0].Tag as MoneyDataSet.AccountsRow);

                    if (form.ShowDialog() != DialogResult.Cancel)
                    {
                        refreshAccounts();
                    }
                }
            }
        }

        private void dgvAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AccountViewForm form = new AccountViewForm(dgvAccounts.Rows[e.RowIndex].Tag as MoneyDataSet.AccountsRow);
                if (form.ShowDialog() != DialogResult.Cancel)
                {
                    refreshAccounts();
                }
            }
        }

        #endregion

        private void AccountListForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (HotKeyHelper.GetShortcut(e))
            {
                case KeyShortcut.Cancel:
                    //this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
            }
        }

    }
}
