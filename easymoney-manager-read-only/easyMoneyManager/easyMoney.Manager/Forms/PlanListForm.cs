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
    public partial class PlanListForm : Form
    {
        private MoneyDataKeeper keeper = MoneyDataKeeper.Instance;

        #region Form init/load

        public PlanListForm()
        {
            InitializeComponent();
        }

        private void PlanListForm_Load(object sender, EventArgs e)
        {
            // payment transactions
            foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.GetTransactionTemplates(false))
            {
                FormHelper.InsertTemplate(tsddbPlanPayment.DropDownItems, template, tsmiPlanFromTemplate_Click);
            }

            // income transactions
            foreach (MoneyDataSet.TransactionTemplatesRow template in keeper.GetTransactionTemplates(true))
            {
                FormHelper.InsertTemplate(tsddbPlanIncome.DropDownItems, template, tsmiPlanFromTemplate_Click);
            }

            refreshPlans();
        }

        #endregion

        #region New plan from template

        /// <summary>
        /// New plan based on template menu item click
        /// </summary>
        private void tsmiPlanFromTemplate_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            PlanEditForm form = new PlanEditForm(item.Tag as MoneyDataSet.TransactionTemplatesRow);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                refreshPlans();
            }
        }

        #endregion

        #region Refresh plan list

        private void refreshPlans()
        {
            dgvPlans.Rows.Clear();
            IEnumerable<MoneyDataSet.PlannedTransactionsRow> plans = keeper.PlannedTransactions.OrderBy(o => (o.TransactionTypeRow.Title));
            
            if (!tsbShowAll.Checked)
            {
                plans = keeper.GetRelevantPlannedTransactions().OrderBy(o => (o.TransactionTypeRow.Title));;
            }

            foreach (MoneyDataSet.PlannedTransactionsRow plan in plans)
            {
                int rowID = dgvPlans.Rows.Add(plan.DateRecurrency, plan.TransactionTypeRow.Title, plan.Title,
                    plan.Amount.ToString(Consts.UI.CurrencyFormat, plan.CurrenciesRow.CurrencyCultureInfo),
                    plan.AccountTypeRow.Title);
                dgvPlans.Rows[rowID].Tag = plan;
            }
            //dgvPlans.Sort(dgvPlans.Columns[0], ListSortDirection.Ascending);
            
            if (dgvPlans.Rows.Count == 0)
            {
                tsbEdit.Enabled = false;
                tsbCopy.Enabled = false;
                tsbImplement.Enabled = false;
                tsbDelete.Enabled = false;
            }
            else
            {
                tsbEdit.Enabled = true;
                tsbCopy.Enabled = true;
                tsbImplement.Enabled = true;
                tsbDelete.Enabled = true;
            }
        }

        #endregion
        
        #region Toolstrip button handlers

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbEditCopy_Click(object sender, EventArgs e)
        {
            if (dgvPlans.SelectedRows.Count == 1)
            {
                MoneyDataSet.PlannedTransactionsRow plan = dgvPlans.SelectedRows[0].Tag as MoneyDataSet.PlannedTransactionsRow;

                MoneyDataSet.PlannedTransactionsRow sourcePlan = null;
                MoneyDataSet.PlannedTransactionsRow destinationPlan = null;

                if (plan.TransactionTemplatesRow == null)
                {
                    ErrorHelper.ShowErrorBox(ErrorHelper.Errors.PlanWithoutTemplate);
                    Log.Write("Plan", plan);
                    return;
                }

                if (plan.TransactionTemplatesRow.HasDestinationAccount)
                {
                    sourcePlan = keeper.PlannedTransactions.SingleOrDefault(p => ((!p.IsPairReferenceIDNull()) &&
                        (p.PairReferenceID == plan.PairReferenceID) &&
                        (p.TransactionTypeID.Equals(plan.TransactionTemplatesRow.SourceTransactionTypeID))));

                    destinationPlan = keeper.PlannedTransactions.SingleOrDefault(p => ((!p.IsPairReferenceIDNull()) &&
                        (p.PairReferenceID == plan.PairReferenceID) &&
                        (p.TransactionTypeID.Equals(plan.TransactionTemplatesRow.DestinationTransactionTypeID))));
                }
                else
                {
                    sourcePlan = plan;
                }

                PlanEditForm form = new PlanEditForm(sourcePlan.TransactionTemplatesRow,
                    sourcePlan, destinationPlan, (sender as ToolStripButton).Equals(tsbCopy));

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    refreshPlans();
                    foreach (DataGridViewRow row in dgvPlans.Rows)
                    {
                        if (row.Tag == form.UpdatedPlan)
                        {
                            dgvPlans.FirstDisplayedCell = dgvPlans.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                }
            }
        }

        private void tsbImplement_Click(object sender, EventArgs e)
        {
            if (dgvPlans.SelectedRows.Count == 1)
            {
                MoneyDataSet.PlannedTransactionsRow plan = dgvPlans.SelectedRows[0].Tag as MoneyDataSet.PlannedTransactionsRow;

                TransactionEditForm form = new TransactionEditForm(plan.TransactionTemplatesRow, plan);

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    refreshPlans();

                    foreach (DataGridViewRow row in dgvPlans.Rows)
                    {
                        if (row.Tag == plan)
                        {
                            dgvPlans.FirstDisplayedCell = dgvPlans.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                }
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dgvPlans.SelectedRows.Count == 1)
            {
                if (FormHelper.DeletePlannedTransaction(dgvPlans.SelectedRows[0].Tag as MoneyDataSet.PlannedTransactionsRow))
                {
                    refreshPlans();
                }
            }
        }

        private void tsbShowAll_Click(object sender, EventArgs e)
        {
            refreshPlans();
        }

        #endregion

        #region Data grid view hanlders

        private void dgvPlans_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PlanViewForm form = new PlanViewForm(dgvPlans.Rows[e.RowIndex].Tag as MoneyDataSet.PlannedTransactionsRow);
                if (form.ShowDialog() != DialogResult.Cancel)
                {
                    refreshPlans();
                }
            }
        }

        private void dgvPlans_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvPlans.SelectedRows.Count == 1)
                {
                    PlanViewForm form =
                        new PlanViewForm(dgvPlans.SelectedRows[0].Tag as MoneyDataSet.PlannedTransactionsRow);

                    if (form.ShowDialog() != DialogResult.Cancel)
                    {
                        refreshPlans();
                    }
                }
            }
        }

        #endregion

        #region Form level handlers

        private void PlanListForm_KeyDown(object sender, KeyEventArgs e)
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
