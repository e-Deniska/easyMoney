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
    public partial class PlanViewForm : Form
    {

        private MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
        private MoneyDataSet.PlannedTransactionsRow sourcePlan = null;
        private MoneyDataSet.PlannedTransactionsRow destinationPlan = null;

        #region Form init/load

        public PlanViewForm(MoneyDataSet.PlannedTransactionsRow plan)
        {
            InitializeComponent();

            // locate source and destination plans
            if ((!plan.IsPairReferenceIDNull()) && (plan.PairReferenceID != 0))
            {
                foreach (MoneyDataSet.PlannedTransactionsRow p in
                    keeper.PlannedTransactions.Where(p => ((!p.IsPairReferenceIDNull()) &&
                        (p.PairReferenceID == plan.PairReferenceID))))
                    // setting source and destination
                    if (p.TransactionTypeID.Equals(plan.TransactionTemplatesRow.SourceTransactionTypeID))
                    {
                        sourcePlan = p;
                    }
                    else if (p.TransactionTypeID.Equals(plan.TransactionTemplatesRow.DestinationTransactionTypeID))
                    {
                        destinationPlan = p;
                    }

                if ((sourcePlan == null) || (destinationPlan == null))
                {
                    ErrorHelper.ShowErrorBox(ErrorHelper.Errors.InvalidTransaction);
                    return;
                }

                tbDestinationAccountType.Text = destinationPlan.AccountTypeRow.Title;
                tbDestinationAmount.Text = destinationPlan.Amount.ToString(Consts.UI.CurrencyFormat,
                    destinationPlan.CurrenciesRow.CurrencyCultureInfo);
            }
            else
            {
                sourcePlan = plan;
                // only one planned transaction, removing second column
                tlpTemplatePlan.Controls.Remove(gbDestination);
                tlpTemplatePlan.SetColumnSpan(gbSource, 2);
            }


            tbTitle.Text = sourcePlan.FullTitle;
            tbSourceAccountType.Text = sourcePlan.AccountTypeRow.Title;
            tbSourceAmount.Text = sourcePlan.Amount.ToString(Consts.UI.CurrencyFormat,
                sourcePlan.CurrenciesRow.CurrencyCultureInfo);
            tbDescription.Text = sourcePlan.Description;
            ttbTags.Tags = keeper.GetPlannedTransactionTagStrings(sourcePlan);

            this.DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region Toolstrip button handlers

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (FormHelper.DeletePlannedTransaction(sourcePlan))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void tsbEditCopy_Click(object sender, EventArgs e)
        {
            PlanEditForm form = new PlanEditForm(sourcePlan.TransactionTemplatesRow,
                sourcePlan, destinationPlan, (sender as ToolStripButton).Equals(tsbCopy));

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void tsbImplement_Click(object sender, EventArgs e)
        {
            TransactionEditForm form = 
                new TransactionEditForm(sourcePlan.TransactionTemplatesRow, sourcePlan);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #endregion
        
    }
}
