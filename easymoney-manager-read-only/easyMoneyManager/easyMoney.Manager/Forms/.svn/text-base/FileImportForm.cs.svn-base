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
    public partial class FileImportForm : Form
    {
        private class ImportedTransaction
        {
            public MoneyDataImporter.ImportedRecord Record { get; set; }
            public MoneyDataSet.TransactionsRow Transaction { get; set; }
            public bool Selected { get; set; }

            public ImportedTransaction(MoneyDataImporter.ImportedRecord record, MoneyDataSet.TransactionsRow transaction)
            {
                Record = record;
                Transaction = transaction;
                Selected = false;
            }

            public override string ToString()
            {
                return String.Format(Consts.UI.ImportedTransactionsListFormat, Selected ? "+ " : String.Empty, Record.Date, Record.Title);
            }
        }

        private List<ImportedTransaction> transactions = new List<ImportedTransaction>();
        private int selectedIndex = -1;
        private MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
        private MoneyDataImporter importer = null;

        public FileImportForm()
        {
            InitializeComponent();
        }

        private void FileImportForm_Load(object sender, EventArgs e)
        {
            //dgvcTransactionsAccount
            //DataGridViewComboBoxCell cell;


            //dgvcTransactionsAccount.DataSource = keeper.Accounts;
            //dgvcTransactionsPlan.DataSource = keeper.PlannedTransactions;

            /*
            foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.DataSet.TransactionTemplates)
            {
                .Items.Add(template)
            }
            */
        }


        private void tsbOpen_Click(object sender, EventArgs e)
        {
            if (fdFileOpen.ShowDialog() == DialogResult.OK)
            {
                importer = new MoneyDataImporter(fdFileOpen.FileName);

                transactions.Clear();

                foreach (MoneyDataImporter.ImportedRecord record in importer.Records)
                {
                    transactions.Add(new ImportedTransaction(record, null));
                }
                lbImportedTransactions.DataSource = transactions;                
            }
        }

        private void tsbImport_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshDetails()
        {
            if (lbImportedTransactions.SelectedIndex > -1)
            {
                if ((selectedIndex != lbImportedTransactions.SelectedIndex) && (selectedIndex != -1))
                {
                    // there is previous transaction shown, gather all changes from form
                    ImportedTransaction impTranGet = lbImportedTransactions.Items[selectedIndex] as ImportedTransaction;
                    getTransactionDetails(impTranGet);
                }
                ImportedTransaction impTran = lbImportedTransactions.SelectedItem as ImportedTransaction;
                putTransactionDetails(impTran);
                selectedIndex = lbImportedTransactions.SelectedIndex;
            }
        }

        private void getTransactionDetails(ImportedTransaction impTran)
        {
        }

        private void putTransactionDetails(ImportedTransaction impTran)
        {
            cbImport.Checked = impTran.Selected;
            dtpDate.Value = impTran.Transaction.TransactionTime;
            tbTitle.Text = impTran.Transaction.Title;
            cbImplementsPlan.Checked = (impTran.Transaction.PlannedTransactionsRow != null);
            cbPlan.SelectedItem = impTran.Transaction.PlannedTransactionsRow;
            cbAccount.SelectedItem = impTran.Transaction.AccountRow;
            numAmount.Value = (decimal)impTran.Transaction.Amount;
            ttbTags.Tags = keeper.GetTransactionTagStrings(impTran.Transaction);
        }

        private void lbImportedTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDetails();
        }

    }
}
