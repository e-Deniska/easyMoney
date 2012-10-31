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
    public partial class AccountCorrectionForm : Form
    {

        #region Form members

        private MoneyDataSet.AccountsRow existingAccount = null;
        private MoneyDataKeeper keeper = null;

        #endregion

        #region Form public properties

        public MoneyDataSet.AccountsRow UpdatedAccount
        {
            get { return existingAccount; }
        }

        #endregion

        #region Init/load

        public AccountCorrectionForm(MoneyDataSet.AccountsRow selectedAccount = null)
        {
            InitializeComponent();
            existingAccount = selectedAccount;
            keeper = MoneyDataKeeper.Instance;
        }

        private void AccountCorrectionForm_Load(object sender, EventArgs e)
        {
            ttbTags.SetAvailableTags(keeper.Tags);
            cbAccount.DisplayMember = MoneyDataSet.IDs.SpecialColumns.FullTitleColumnName;
            cbAccount.ValueMember = keeper.DataSet.Accounts.IDColumn.ColumnName;
            // cbAccount.DataSource = keeper.Accounts;
            foreach (var account in keeper.Accounts)
            {
                cbAccount.Items.Add(account);
            }

            if (existingAccount != null)
            {
                cbAccount.SelectedItem = existingAccount;
            }
            else
            {
                cbAccount.SelectedIndex = 0;
            }
            updateBalanceInfo();
        }

        #endregion

        #region Button click handlers

        private void btnOk_Click(object sender, EventArgs e)
        {
            MoneyDataSet.AccountsRow account = cbAccount.SelectedItem as MoneyDataSet.AccountsRow;

            double amount = account.Balance - ((double)numBalance.Value);

            MoneyDataSet.TransactionsRow preCreate =
                keeper.PreCreateTransaction(keeper.GetTransactionType(MoneyDataSet.IDs.TransactionTypes.Correction), 
                Resources.Labels.AccountCorrectionLabel, tbDescription.Text, DateTime.Now, account, amount);

            ValidationResult result = keeper.Validate(transaction: preCreate);
            if (!result.Success)
            {
                if (result.PreventAction)
                {
                    MessageBox.Show(String.Format(Resources.Labels.TransactionValidationErrorsFoundFormat, result.Message),
                        Resources.Labels.TransactionValidationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (MessageBox.Show(String.Format(Resources.Labels.TransactionValidationWarningsFoundFormat, result.Message),
                        Resources.Labels.TransactionValidationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }

            keeper.CreateTransaction(preCreate, ttbTags.Tags);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region Form information update

        private void cbAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateBalanceInfo();
        }

        private void updateBalanceInfo()
        {
            if (cbAccount.SelectedItem != null)
            {
                MoneyDataSet.AccountsRow account = cbAccount.SelectedItem as MoneyDataSet.AccountsRow;
                MoneyDataSet.CurrenciesRow currency = account.CurrenciesRow;
                lblCurrency.Visible = false;
                numBalance.Visible = false;
                lblCurrency.Text = CultureInfo.CreateSpecificCulture(currency.CurrencyCulture).NumberFormat.CurrencySymbol;
                if (currency.IsSymbolAfterAmount)
                {
                    tlpBalance.SetCellPosition(lblCurrency, new TableLayoutPanelCellPosition(2, 0));
                    tlpBalance.SetCellPosition(numBalance, new TableLayoutPanelCellPosition(0, 0));
                    lblCurrency.TextAlign = ContentAlignment.MiddleLeft;
                    lblCurrency.Dock = DockStyle.Left;
                }
                else
                {
                    tlpBalance.SetCellPosition(lblCurrency, new TableLayoutPanelCellPosition(0, 0));
                    tlpBalance.SetCellPosition(numBalance, new TableLayoutPanelCellPosition(1, 0));
                    lblCurrency.TextAlign = ContentAlignment.MiddleRight;
                    lblCurrency.Dock = DockStyle.Right;
                }

                numBalance.Value = (decimal)account.Balance;
                numBalance.Select(0, Int32.MaxValue);

                lblCurrency.Visible = true;
                numBalance.Visible = true;
            }
        }

        #endregion

        #region Key shortcuts handler
        
        private void AccountCorrectionForm_KeyDown(object sender, KeyEventArgs e)
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
                    else if (cbAccount.DroppedDown)
                    {
                        cbAccount.DroppedDown = false;
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
                
    }
}
