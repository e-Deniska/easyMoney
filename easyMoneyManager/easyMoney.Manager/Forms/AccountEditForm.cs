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
using System.Globalization;

namespace easyMoney.Manager.Forms
{
    public partial class AccountEditForm : Form
    {

        #region Class members

        private MoneyDataKeeper keeper = null;
        private MoneyDataSet.AccountTypesRow accountType = null;
        private MoneyDataSet.AccountsRow account = null;
        private bool isDebit = true;

        #endregion

        #region Form public properties

        public MoneyDataSet.AccountsRow UpdatedAccount
        {
            get { return account; }
        }
        
        #endregion

        #region Form init/load

        public AccountEditForm(bool isDebit, MoneyDataSet.AccountTypesRow accountType = null, MoneyDataSet.AccountsRow account = null)
        {
            InitializeComponent();
            this.keeper = MoneyDataKeeper.Instance;
            this.isDebit = isDebit;
            this.accountType = accountType;
            this.account = account;
            
        }

        private void AccountEditForm_Load(object sender, EventArgs e)
        {
            tbTitle.AutoCompleteCustomSource.AddRange(keeper.GetTextHistory(Consts.Keeper.AccountTitleHistoryID));
            cbAccountType.DisplayMember = keeper.DataSet.AccountTypes.TitleColumn.ColumnName;
            cbAccountType.ValueMember = keeper.DataSet.AccountTypes.IDColumn.ColumnName;
            // cbAccountType.DataSource = keeper.GetAccountTypes(isDebit);
            foreach (var accountTtype in keeper.GetAccountTypes(isDebit))
            {
                cbAccountType.Items.Add(accountTtype);
            }
            cbAccountType.SelectedIndex = 0;

            cbCurrency.DisplayMember = keeper.DataSet.Currencies.TitleColumn.ColumnName;
            cbCurrency.ValueMember = keeper.DataSet.Currencies.IDColumn.ColumnName;

            // cbCurrency.DataSource = keeper.Currencies;
            foreach (var currency in keeper.Currencies)
            {
                cbCurrency.Items.Add(currency);
            }
            cbCurrency.SelectedIndex = 0;

            ttbTags.SetAvailableTags(keeper.Tags);

            if (account != null)
            {
                cbAccountType.SelectedItem = account.AccountTypesRow;
                cbCurrency.SelectedItem = account.CurrenciesRow;
                cbAccountType.Enabled = false;
                cbCurrency.Enabled = false;
                tbTitle.Text = account.Title;
                lblBalance.Text = String.Format(account.CurrenciesRow.CurrencyCultureInfo, Resources.Labels.BalanceFormat, account.Balance);
                tbDescription.Text = account.Description;
                cbHideAccount.Checked = account.IsHidden;
                ttbTags.Tags = keeper.GetAccountTagStrings(account);
            }
            else
            {
                if (accountType != null)
                {
                    cbAccountType.SelectedItem = accountType;
                }
                lblBalance.Text = Resources.Labels.BalanceLaterHint;
                cbHideAccount.Enabled = false;
            }
        }

        #endregion

        #region Button handlers

        private void btnOk_Click(object sender, EventArgs e)
        {
            tbTitle.Text = tbTitle.Text.Trim();

            if (account != null)
            {
                // updating existing account
                account = keeper.UpdateAccount(account.ID, tbTitle.Text, tbDescription.Text, cbHideAccount.Checked, ttbTags.Tags);
            }
            else
            {
                // creating new account
                account = keeper.PreCreateAccount(cbAccountType.SelectedItem as MoneyDataSet.AccountTypesRow, tbTitle.Text, tbDescription.Text,
                    cbCurrency.SelectedItem as MoneyDataSet.CurrenciesRow, 0);
                ValidationResult result = keeper.Validate(account: account);
                if (!result.Success)
                {
                    if (result.PreventAction)
                    {
                        MessageBox.Show(String.Format(Resources.Labels.AccountValidationErrorsFoundFormat, result.Message),
                            Resources.Labels.AccountValidationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show(String.Format(Resources.Labels.AccountValidationWarningsFoundFormat, result.Message),
                            Resources.Labels.AccountValidationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                }
                account = keeper.CreateAccount(account, ttbTags.Tags);
            }
            keeper.AddTextHistory(Consts.Keeper.AccountTitleHistoryID, tbTitle.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region Key shortcuts handler

        private void AccountEditForm_KeyDown(object sender, KeyEventArgs e)
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
                    else if (cbAccountType.DroppedDown)
                    {
                        cbAccountType.DroppedDown = false;
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
