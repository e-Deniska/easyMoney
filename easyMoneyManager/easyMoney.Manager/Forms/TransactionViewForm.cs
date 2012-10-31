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
    public partial class TransactionViewForm : Form
    {

        private MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
        private MoneyDataSet.TransactionsRow transaction = null;

        #region Form init/load

        public TransactionViewForm(MoneyDataSet.TransactionsRow transaction)
        {
            InitializeComponent();
            this.transaction = transaction;

            MoneyDataSet.TransactionsRow sourceTransaction = null;
            MoneyDataSet.TransactionsRow destinationTransaction = null;

            // lookup paired transaciton
            if ((!transaction.IsPairReferenceIDNull()) && (transaction.PairReferenceID != 0))
            {
                foreach (MoneyDataSet.TransactionsRow t in
                    keeper.Transactions.Where(t => ((!t.IsPairReferenceIDNull()) && (t.PairReferenceID == transaction.PairReferenceID))))
                    // setting source and destination
                    if (t.TypeID.Equals(transaction.TransactionTemplatesRow.SourceTransactionTypeID))
                    {
                        sourceTransaction = t;
                    }
                    else if (t.TypeID.Equals(transaction.TransactionTemplatesRow.DestinationTransactionTypeID))
                    {
                        destinationTransaction = t;
                    }

                if ((sourceTransaction == null) || (destinationTransaction == null))
                {
                    ErrorHelper.ShowErrorBox(ErrorHelper.Errors.InvalidTransaction);
                    return;
                }

                tbDestinationAccount.Text = destinationTransaction.AccountRow.FullTitle;
                tbDestinationAmount.Text = destinationTransaction.Amount.ToString(Consts.UI.CurrencyFormat,
                    destinationTransaction.AccountRow.CurrenciesRow.CurrencyCultureInfo);
            }
            else
            {
                sourceTransaction = transaction;
                // only one transaction, removing second column
                tlpTemplateTransaction.Controls.Remove(gbDestination);
                tlpTemplateTransaction.SetColumnSpan(gbSource, 2);
            }
            tbTitle.Text = sourceTransaction.FullTitle;
            tbSourceAccount.Text = sourceTransaction.AccountRow.FullTitle;
            tbSourceAmount.Text = sourceTransaction.Amount.ToString(Consts.UI.CurrencyFormat,
                sourceTransaction.AccountRow.CurrenciesRow.CurrencyCultureInfo);
            tbDescription.Text = sourceTransaction.Description;
            ttbTags.Tags = keeper.GetTransactionTagStrings(sourceTransaction);
            if (sourceTransaction.PlannedTransactionsRow != null)
            {
                tbImplementsPlan.Text = sourceTransaction.PlannedTransactionsRow.FullTitle;
            }
            else
            {
                tbImplementsPlan.Text = Resources.Labels.TransactionNotPlanned;
            }
            this.DialogResult = DialogResult.Cancel;
        }
        
        #endregion

        #region Toolstrip button handlers

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (FormHelper.DeleteTransaction(transaction))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #endregion

    }
}
