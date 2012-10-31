using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using easyMoney.Data;

namespace easyMoney.Setup
{
    public partial class CustomMetadataForm : Form
    {

        #region Custom list item classes

        private class MetadataListItem
        {
            public MetadataListItem(object listItem)
            {
                Item = listItem;
            }

            public object Item { get; set; }

            public override string ToString()
            {
                if (Item == null)
                {
                    return Resources.Labels.NewItem;
                }
                else if (Item is MoneyDataSet.CurrenciesRow)
                {
                    return (Item as MoneyDataSet.CurrenciesRow).Title;
                }
                else if (Item is MoneyDataSet.AccountTypesRow)
                {
                    return (Item as MoneyDataSet.AccountTypesRow).Title;
                }
                else if (Item is MoneyDataSet.TransactionTypesRow)
                {
                    return (Item as MoneyDataSet.TransactionTypesRow).Title;
                }
                else if (Item is MoneyDataSet.TransactionTemplatesRow)
                {
                    return (Item as MoneyDataSet.TransactionTemplatesRow).Title;
                }
                else
                {
                    return base.ToString();
                }
            }
        }

        #endregion

        #region Members

        private MoneyDataKeeper keeper = null;

        #endregion

        #region Form init/load

        public CustomMetadataForm()
        {
            InitializeComponent();

            this.keeper = MoneyDataKeeper.Instance;
        }

        private void CustomMetadataForm_Load(object sender, EventArgs e)
        {
            // loading currencies
            fillCurrencies();

            // loading account types
            fillAccountTypes();

            // loading transaction types
            fillTransactionTypes();

            // loading templates
            fillTemplates();

            lbCurrencies.Select();
        }

        private void fillCurrencies()
        {
            lbCurrencies.Items.Clear();
            foreach (MoneyDataSet.CurrenciesRow currency in keeper.DataSet.Currencies.OrderBy(o => (o.SortOrder)))
            {
                lbCurrencies.Items.Add(new MetadataListItem(currency));
            }
            lbCurrencies.Items.Add(new MetadataListItem(null));
            lbCurrencies.SelectedIndex = 0;
        }

        private void fillAccountTypes()
        {
            lbAccountTypes.Items.Clear();
            foreach (MoneyDataSet.AccountTypesRow accountType in keeper.DataSet.AccountTypes.OrderBy(o => (o.SortOrder)))
            {
                lbAccountTypes.Items.Add(new MetadataListItem(accountType));
            }
            lbAccountTypes.Items.Add(new MetadataListItem(null));
            lbAccountTypes.SelectedIndex = 0;
        }

        private void fillTransactionTypes()
        {
            lbTransactionTypes.Items.Clear();
            foreach (MoneyDataSet.TransactionTypesRow transactionType in keeper.DataSet.TransactionTypes)
            {
                lbTransactionTypes.Items.Add(new MetadataListItem(transactionType));
            }
            lbTransactionTypes.Items.Add(new MetadataListItem(null));
            lbTransactionTypes.SelectedIndex = 0;
        }

        private void fillTemplates()
        {
            lbTemplates.Items.Clear();
            foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.DataSet.TransactionTemplates)
            {
                lbTemplates.Items.Add(new MetadataListItem(template));
            }
            lbTemplates.Items.Add(new MetadataListItem(null));
            lbTemplates.SelectedIndex = 0;
        }

        #endregion

        #region Currencies

        private void lbCurrencies_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (lbCurrencies.SelectedItem != null))
            {
                openCurrency((lbCurrencies.SelectedItem as MetadataListItem).Item as MoneyDataSet.CurrenciesRow);
            }
        }

        private void lbCurrencies_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = lbCurrencies.IndexFromPoint(e.Location);
                if (index >= 0)
                {
                    openCurrency((lbCurrencies.Items[index] as MetadataListItem).Item as MoneyDataSet.CurrenciesRow);
                }
            }
        }

        private void openCurrency(MoneyDataSet.CurrenciesRow currency)
        {
            CurrencyForm form = new CurrencyForm(currency);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                fillCurrencies();
            }
        }

        #endregion

        #region Account types

        private void lbAccountTypes_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (lbAccountTypes.SelectedItem != null))
            {
                openAccountType((lbAccountTypes.SelectedItem as MetadataListItem).Item as MoneyDataSet.AccountTypesRow);
            }
        }

        private void lbAccountTypes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = lbAccountTypes.IndexFromPoint(e.Location);
                if (index >= 0)
                {
                    openAccountType((lbAccountTypes.Items[index] as MetadataListItem).Item as MoneyDataSet.AccountTypesRow);
                }
            }
        }


        private void openAccountType(MoneyDataSet.AccountTypesRow accountType)
        {
            AccountTypeForm form = new AccountTypeForm(accountType);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                fillAccountTypes();
            }
        }
        
        #endregion

        #region Transaction types

        private void lbTransactionTypes_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter)  && (lbTransactionTypes.SelectedItem != null))
            {
                openTransactionType((lbTransactionTypes.SelectedItem as MetadataListItem).Item as MoneyDataSet.TransactionTypesRow);
            }
        }

        private void lbTransactionTypes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = lbTransactionTypes.IndexFromPoint(e.Location);
                if (index >= 0)
                {
                    openTransactionType((lbTransactionTypes.Items[index] as MetadataListItem).Item as MoneyDataSet.TransactionTypesRow);
                }
            }
        }

        private void openTransactionType(MoneyDataSet.TransactionTypesRow transactionType)
        {
            TransactionTypeForm form = new TransactionTypeForm(transactionType);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                fillTransactionTypes();
            }
        }
        
        #endregion

        #region Templates

        private void lbTemplates_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (lbTemplates.SelectedItem != null))
            {
                openTemplate((lbTemplates.SelectedItem as MetadataListItem).Item as MoneyDataSet.TransactionTemplatesRow);
            }
        }

        private void lbTemplates_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = lbTemplates.IndexFromPoint(e.Location);
                if (index >= 0)
                {
                    openTemplate((lbTemplates.Items[index] as MetadataListItem).Item as MoneyDataSet.TransactionTemplatesRow);
                }
            }
        }

        private void openTemplate(MoneyDataSet.TransactionTemplatesRow template)
        {
            TemplateForm form = new TemplateForm(template);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                fillTemplates();
            }
        }
        
        #endregion

        #region Toolstrip button hanlder

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbAddCurrency_Click(object sender, EventArgs e)
        {
            openCurrency(null);
        }

        private void tsbAddAccountType_Click(object sender, EventArgs e)
        {
            openAccountType(null);
        }

        private void tsbAddTransactionType_Click(object sender, EventArgs e)
        {
            openTransactionType(null);
        }

        private void tsbAddTemplate_Click(object sender, EventArgs e)
        {
            openTemplate(null);
        }

        #endregion

    }
}
