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
    public partial class TransactionListForm : Form
    {
        private MoneyDataKeeper keeper = MoneyDataKeeper.Instance;

        #region Form init/load

        public TransactionListForm()
        {
            InitializeComponent();
        }

        private void TransactionListForm_Load(object sender, EventArgs e)
        {
            if (!keeper.Accounts.Any())
            {
                tsddbNewIncome.Enabled = false;
                tsddbNewPayment.Enabled = false;
                return;
            }
            else
            {
                // payment transactions
                foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.GetTransactionTemplates(false))
                {
                    FormHelper.InsertTemplate(tsddbNewPayment.DropDownItems, template, tsmiTransactionFromTemplate_Click);
                }

                // income transactions
                foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.GetTransactionTemplates(true))
                {
                    FormHelper.InsertTemplate(tsddbNewIncome.DropDownItems, template, tsmiTransactionFromTemplate_Click);
                }

                // undefined transactions are out of scope for this form, only in welcome screen
            }

            refreshTransactions();            
        }

        #endregion

        #region Refresh transaction list

        /// <summary>
        /// Refresh list of transactions in data grid view
        /// </summary>
        private void refreshTransactions()
        {
            dgvTransactions.Rows.Clear();
            IEnumerable<MoneyDataSet.TransactionsRow> transactions = keeper.Transactions;

            if (tsbTransactionsMonth.Checked)
            {
                transactions = transactions.Where(s => ((s.TransactionTime.Year == DateTime.Now.Year) && (s.TransactionTime.Month == DateTime.Now.Month)));
            }
            else if (tsbTransactionsYear.Checked)
            {
                transactions = transactions.Where(s => (s.TransactionTime.Year == DateTime.Now.Year));
            }

            foreach (MoneyDataSet.TransactionsRow transaction in transactions)
            {
                int rowID = dgvTransactions.Rows.Add(transaction.TransactionTime, transaction.TransactionTypesRow.Title, transaction.Title,
                    transaction.Amount.ToString(Consts.UI.CurrencyFormat, transaction.AccountRow.CurrenciesRow.CurrencyCultureInfo),
                    transaction.AccountRow.FullTitle);
                dgvTransactions.Rows[rowID].Tag = transaction;
            }
            dgvTransactions.Sort(dgvTransactions.Columns[0], ListSortDirection.Descending);

            tsbDelete.Enabled = transactions.Any();
        }

        #endregion
        
        #region Create new transaction from template

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
                    refreshTransactions();
                }
            }
        }

        #endregion

        #region Toolstrip button handlers

        /// <summary>
        /// Delete selected transaction (with confirmation)
        /// </summary>
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 1)
            {
                if (FormHelper.DeleteTransaction(dgvTransactions.SelectedRows[0].Tag as MoneyDataSet.TransactionsRow))
                {
                    refreshTransactions();
                }
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Update transaction list depending on Show All button state
        /// </summary>
        private void tsbTransactionsAll_Click(object sender, EventArgs e)
        {
            tsbTransactionsMonth.Checked = false;
            tsbTransactionsYear.Checked = false;
            tsbTransactionsAll.Checked = true;
            refreshTransactions();
        }

        private void tsbTransactionsMonth_Click(object sender, EventArgs e)
        {
            tsbTransactionsMonth.Checked = true;
            tsbTransactionsYear.Checked = false;
            tsbTransactionsAll.Checked = false;
            refreshTransactions();
        }

        private void tsbTransactionsYear_Click(object sender, EventArgs e)
        {
            tsbTransactionsMonth.Checked = false;
            tsbTransactionsYear.Checked = true;
            tsbTransactionsAll.Checked = false;
            refreshTransactions();
        }

        #endregion

        #region Data grid view hanlders

        private void dgvTransactions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TransactionViewForm form =
                    new TransactionViewForm(dgvTransactions.Rows[e.RowIndex].Tag as MoneyDataSet.TransactionsRow);
                if (form.ShowDialog() != DialogResult.Cancel)
                {
                    refreshTransactions();
                }
            }
        }

        private void dgvTransactions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvTransactions.SelectedRows.Count == 1)
                {
                    TransactionViewForm form =
                        new TransactionViewForm(dgvTransactions.SelectedRows[0].Tag as MoneyDataSet.TransactionsRow);

                    if (form.ShowDialog() != DialogResult.Cancel)
                    {
                        refreshTransactions();
                    }
                }
            }
        }
        #endregion

        #region Form level handlers

        private void TransactionListForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (HotKeyHelper.GetShortcut(e))
            {
                case KeyShortcut.Cancel:
                    //this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
            }
        }
        
        #endregion
        
    }
}
