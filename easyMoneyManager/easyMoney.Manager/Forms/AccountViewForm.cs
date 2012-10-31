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
    public partial class AccountViewForm : Form
    {
        MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
        MoneyDataSet.AccountsRow account = null;

        #region Form init/load

        public AccountViewForm(MoneyDataSet.AccountsRow account)
        {
            InitializeComponent();
            this.account = account;

            tbTitle.Text = account.FullTitle;
            tbBalance.Text = account.Balance.ToString(Consts.UI.CurrencyFormat, account.CurrenciesRow.CurrencyCultureInfo);
            tbDescription.Text = account.Description;
            ttbTags.Tags = keeper.GetAccountTagStrings(account);
            DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region Toolstrip button hanlders

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            AccountEditForm form = new AccountEditForm(account.AccountTypesRow.IsDebit, account: account);
            if (form.ShowDialog() == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void tsbBalance_Click(object sender, EventArgs e)
        {
            AccountCorrectionForm form = new AccountCorrectionForm(account);
            if (form.ShowDialog() == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (FormHelper.DeleteAccount(account))
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #endregion

    }
}
