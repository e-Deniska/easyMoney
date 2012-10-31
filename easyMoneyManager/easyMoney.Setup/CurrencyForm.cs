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
    public partial class CurrencyForm : Form
    {

        #region Form members

        private MoneyDataSet.CurrenciesRow existingItem = null;
        private MoneyDataKeeper keeper = null;

        #endregion

        #region Form init/load

        public CurrencyForm(MoneyDataSet.CurrenciesRow existingItem)
        {
            InitializeComponent();
            this.keeper = MoneyDataKeeper.Instance;
            this.existingItem = existingItem;
        }

        private void CurrencyForm_Load(object sender, EventArgs e)
        {
            if (existingItem != null)
            {
                tbID.Text = existingItem.ID;
                tbTitle.Text = existingItem.Title;
                tbCulture.Text = existingItem.CurrencyCulture;
                numExchangeRate.Value = (decimal)existingItem.ExchangeRate;
                numSortOrder.Value = (decimal)existingItem.SortOrder;
                cbIsSymbolAfterAmount.Checked = existingItem.IsSymbolAfterAmount;

                tbID.ReadOnly = true;

                if (!existingItem.ID.StartsWith(Consts.Keeper.UserMetadataPrefix))
                {
                    tbTitle.ReadOnly = true;
                    tbCulture.ReadOnly = true;
                    btnDelete.Enabled = false;
                    cbIsSymbolAfterAmount.Enabled = false;
                }
            }
            else
            {
                tbID.Text = Consts.Keeper.UserMetadataPrefix + Guid.NewGuid().ToString().ToUpper();
                btnDelete.Enabled = false;
                numExchangeRate.Value = (decimal)Consts.Keeper.DefaultExchangeRate;
            }
            numExchangeRate.Select(0, Int32.MaxValue);
            numSortOrder.Select(0, Int32.MaxValue);
        }

        #endregion

        #region Form buttons handlers

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (numExchangeRate.Value == 0)
            {
                MessageBox.Show(Resources.Labels.NonZeroExchangeRateText, Resources.Labels.ErrorSavingTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (existingItem != null)
            {
                if (existingItem.ID.StartsWith(Consts.Keeper.UserMetadataPrefix))
                {
                    existingItem.Title = tbTitle.Text.Trim();
                    existingItem.CurrencyCulture = tbCulture.Text.Trim();
                    existingItem.IsSymbolAfterAmount = cbIsSymbolAfterAmount.Checked;
                }
                existingItem.ExchangeRate = (double)numExchangeRate.Value;
                existingItem.SortOrder = (int)numSortOrder.Value;
            }
            else
            {
                String ID = tbID.Text.Trim().ToUpper();
                if (keeper.DataSet.Currencies.FindByID(ID) != null)
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

                MoneyDataSet.CurrenciesRow currency = keeper.DataSet.Currencies.NewCurrenciesRow();
                currency.ID = ID;
                currency.Title = tbTitle.Text.Trim();
                currency.CurrencyCulture = tbCulture.Text.Trim();
                currency.ExchangeRate = (double)numExchangeRate.Value;
                currency.SortOrder = (int)numSortOrder.Value;
                currency.IsSymbolAfterAmount = cbIsSymbolAfterAmount.Checked;
                keeper.DataSet.Currencies.AddCurrenciesRow(currency);
            }
            keeper.DataSet.AcceptChanges();

            if (keeper.GetDefaultCurrency() == null)
            {
                MessageBox.Show(Resources.Labels.NoDefaultCurrencyText, Resources.Labels.NoDefaultCurrencyTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // some additional checks (we're deleting only user metadata)
            if ((existingItem != null) && (existingItem.ID.StartsWith(Consts.Keeper.UserMetadataPrefix)))
            {
                if (MessageBox.Show(Resources.Labels.DeleteCurrencyText, Resources.Labels.DeleteItemTitle,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    keeper.DataSet.Currencies.RemoveCurrenciesRow(existingItem);
                    keeper.DataSet.AcceptChanges();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        #endregion

        #region Keyboard hotkeys

        private void CurrencyForm_KeyDown(object sender, KeyEventArgs e)
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
