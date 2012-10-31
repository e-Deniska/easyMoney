using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using easyMoney.Utilities;
using easyMoney.Data;

namespace easyMoney.Manager.Forms
{
    public partial class SearchForm : Form
    {
        MoneyDataKeeper keeper = MoneyDataKeeper.Instance;

        #region Form init/load/close

        public SearchForm(String searchString = null)
        {
            InitializeComponent();
            if (Parameters.SearchTabSplitterPosition != -1)
            {
                scSearchSplitContainer.SplitterDistance = Parameters.SearchTabSplitterPosition;
            }
            tsstbSearchText.Text = searchString;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            updateTagCloud();

            if (!String.IsNullOrWhiteSpace(tsstbSearchText.Text))
            {
                tsbDisplaySearchResults.PerformClick();
            }
        }

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Parameters.SearchTabSplitterPosition = scSearchSplitContainer.SplitterDistance;
        }

        #endregion

        #region Tag clould

        private void updateTagCloud()
        {
            flpTagFlow.Controls.Clear();
            IEnumerable<MoneyDataKeeper.TagUsagesEntry> tags = keeper.TagUsages;

            if (tags.Any())
            {
                int maxUsages = tags.Max(t => (t.Usages));

                foreach (MoneyDataKeeper.TagUsagesEntry tag in tags.OrderBy(o => (o.Title)))
                {
                    LinkLabel linkTag = new LinkLabel();
                    linkTag.Text = tag.Title;

                    linkTag.ContextMenuStrip = cmsTag;

                    int sizeIncrease = tag.Usages * Consts.UI.TagsMaxFontIncrease / maxUsages;

                    Font font = new System.Drawing.Font(linkTag.Font.FontFamily, linkTag.Font.Size + sizeIncrease);

                    linkTag.Font = font;
                    linkTag.AutoSize = true;
                    linkTag.LinkClicked += linkTag_LinkClicked;

                    // TODO: consider adding tooltips
                    // toolTipMain.SetToolTip(linkTag, String.Format(Resources.Labels.TagToolTipFormat, tag.Title));
                    flpTagFlow.Controls.Add(linkTag);
                }
            }
        }

        private void linkTag_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    showResults((sender as LinkLabel).Text);
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.ShowErrorBox(e: ex);
            } 
        }

        #endregion

        #region Tag context menu

        private void tsmiShowTagUsages_Click(object sender, EventArgs e)
        {
            try
            {
                showResults((cmsTag.SourceControl as LinkLabel).Text);
            }
            catch (Exception ex)
            {
                ErrorHelper.ShowErrorBox(e: ex);
            }
        }

        private void tsmiRenameTag_Click(object sender, EventArgs e)
        {
            try
            {
                TagRenameForm form = new TagRenameForm((cmsTag.SourceControl as LinkLabel).Text);
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    updateTagCloud();
                    dgvSearchResults.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.ShowErrorBox(e: ex);
            }
        }

        private void tsmiDeleteTag_Click(object sender, EventArgs e)
        {
            try
            {
                String tag = (cmsTag.SourceControl as LinkLabel).Text;
                if (MessageBox.Show(String.Format(Resources.Labels.DeleteTagFormat, tag), Resources.Labels.DeleteTagTitle,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    keeper.DeleteTag(tag);
                    updateTagCloud();
                    dgvSearchResults.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                ErrorHelper.ShowErrorBox(e: ex);
            }
        }

        #endregion

        #region Search results

        private void showResults(String tag = null)
        {
            dgvSearchResults.Rows.Clear();

            IEnumerable<MoneyDataSet.AccountsRow> accounts = null;
            IEnumerable<MoneyDataSet.TransactionsRow> transactions = null;
            IEnumerable<MoneyDataSet.PlannedTransactionsRow> plans = null;

            if (String.IsNullOrEmpty(tag))
            {
                keeper.AddTextHistory(Consts.Keeper.HistorySearchID, tsstbSearchText.Text);
                updateSearchSuggestions();

                String searchString = tsstbSearchText.Text.ToLower().Trim();

                accounts = keeper.Accounts;
                transactions = keeper.Transactions;
                plans = keeper.PlannedTransactions;

                foreach (String word in searchString.Split(Consts.UI.WordDividers, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (String.IsNullOrEmpty(word))
                    {
                        continue;
                    }

                    accounts = accounts.Where(a => ((a.Title.ToLower().Contains(word)) ||
                        (a.Description.ToLower().Contains(word)) || (a.AccountTypesRow.Title.ToLower().Contains(word)) ||
                        (a.GetAccountTagsRows().Where(at => (at.TagRow.Title.ToLower().Contains(word))).Any())
                        ));

                    transactions = transactions.Where(t => ((t.Title.ToLower().Contains(word)) ||
                        (t.Description.ToLower().Contains(word)) || (t.TransactionTypesRow.Title.ToLower().Contains(word)) ||
                        (t.GetTransactionTagsRows().Where(tt => (tt.TagRow.Title.ToLower().Contains(word))).Any())
                        ));

                    plans = plans.Where(p => ((p.Title.ToLower().Contains(word)) ||
                        (p.Description.ToLower().Contains(word)) || (p.TransactionTypeRow.Title.ToLower().Contains(word)) ||
                        (p.AccountTypeRow.Title.ToLower().Contains(word)) ||
                        (p.GetPlannedTransactionTagsRows().Where(pt => (pt.TagRow.Title.ToLower().Contains(word))).Any())
                        ));

                    if (!((accounts.Any()) || (transactions.Any()) || (plans.Any())))
                    {
                        // nothing found, no need to look further
                        break;
                    }
                }
            }
            else
            {
                accounts = keeper.Accounts.Where(a =>
                    (a.GetAccountTagsRows().Where(at => (at.TagRow.Title.Equals(tag))).Any()));

                transactions = keeper.Transactions.Where(t =>
                    (t.GetTransactionTagsRows().Where(tt => (tt.TagRow.Title.Equals(tag))).Any()));

                plans = keeper.PlannedTransactions.Where(p =>
                    (p.GetPlannedTransactionTagsRows().Where(pt => (pt.TagRow.Title.Equals(tag))).Any()));
            }

            // accounts
            foreach (MoneyDataSet.AccountsRow a in accounts)
            {
                int i = dgvSearchResults.Rows.Add(Properties.Resources.book_open, a.FullTitle, a.EntryTime,
                    a.Balance.ToString(Consts.UI.CurrencyFormat, a.CurrenciesRow.CurrencyCultureInfo),
                    String.Join(Consts.UI.EnumerableSeparator, keeper.GetAccountTagStrings(a)));

                dgvSearchResults.Rows[i].Tag = a;
            }

            // transactions
            foreach (MoneyDataSet.TransactionsRow t in transactions)
            {
                int i = dgvSearchResults.Rows.Add(Properties.Resources.application_form, t.FullTitle, t.TransactionTime,
                    t.Amount.ToString(Consts.UI.CurrencyFormat, t.AccountRow.CurrenciesRow.CurrencyCultureInfo),
                    String.Join(Consts.UI.EnumerableSeparator, keeper.GetTransactionTagStrings(t)));

                dgvSearchResults.Rows[i].Tag = t;
            }

            // plans
            foreach (MoneyDataSet.PlannedTransactionsRow p in plans)
            {
                
                DateTime? startTime = null;
                if (!p.IsStartTimeNull())
                {
                    startTime = p.StartTime;
                }
                int i = dgvSearchResults.Rows.Add(Properties.Resources.date, p.FullTitle, startTime,
                    p.Amount.ToString(Consts.UI.CurrencyFormat, p.CurrenciesRow.CurrencyCultureInfo),
                    String.Join(Consts.UI.EnumerableSeparator, keeper.GetPlannedTransactionTagStrings(p)));

                dgvSearchResults.Rows[i].Tag = p;
            }

            dgvcSearchResultsAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvcSearchResultsTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvcSearchResultsDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSearchResults.Sort(dgvcSearchResultsDate, ListSortDirection.Descending);
        }

        private void openSearchResult(bool editMode = false)
        {
            object tag = dgvSearchResults.CurrentRow.Tag;

            if (tag is MoneyDataSet.AccountsRow)
            {
                MoneyDataSet.AccountsRow account = tag as MoneyDataSet.AccountsRow;
                if (editMode)
                {
                    AccountEditForm form = new AccountEditForm(account.AccountTypesRow.IsDebit, account: account);
                    if (form.ShowDialog() != DialogResult.Cancel)
                    {
                        updateTagCloud();
                        dgvSearchResults.Rows.Clear();
                    }
                }
                else
                {
                    AccountViewForm form = new AccountViewForm(account);
                    if (form.ShowDialog() != DialogResult.Cancel)
                    {
                        updateTagCloud();
                        dgvSearchResults.Rows.Clear();
                    }
                }
            }
            else if (tag is MoneyDataSet.TransactionsRow)
            {
                MoneyDataSet.TransactionsRow transaction = tag as MoneyDataSet.TransactionsRow;
                TransactionViewForm form = new TransactionViewForm(transaction);
                if (form.ShowDialog() != DialogResult.Cancel)
                {
                    dgvSearchResults.Rows.Remove(dgvSearchResults.CurrentRow);
                }
            }
            else if (tag is MoneyDataSet.PlannedTransactionsRow)
            {
                MoneyDataSet.PlannedTransactionsRow plan = tag as MoneyDataSet.PlannedTransactionsRow;
                if (editMode)
                {
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
                        sourcePlan, destinationPlan);

                    if (form.ShowDialog(this) != DialogResult.Cancel)
                    {
                        updateTagCloud();
                        dgvSearchResults.Rows.Clear();
                    }
                }
                else
                {
                    PlanViewForm form = new PlanViewForm(plan);
                    if (form.ShowDialog(this) != DialogResult.Cancel)
                    {
                        updateTagCloud();
                        dgvSearchResults.Rows.Clear();
                    }
                }
            }
            else
            {
                ErrorHelper.ShowErrorBox(ErrorHelper.Errors.UnknownSearchResult);
                Log.Write("Found in search", tag);
            }

            //updateTagCloud();
            //dgvSearchResults.Rows.Clear();
        }

        private void dgvSearchResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                openSearchResult(false);
            }
        }

        private void dgvSearchResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                openSearchResult(false);
            }
        }

        #endregion

        #region Search results context menu

        private void tsmiOpenEditResult_Click(object sender, EventArgs e)
        {
            openSearchResult((sender as ToolStripMenuItem) == tsmiEditResult);
        }

        private void tsmiAccountBalanceCorrection_Click(object sender, EventArgs e)
        {
            MoneyDataSet.AccountsRow selected = dgvSearchResults.CurrentRow.Tag as MoneyDataSet.AccountsRow;
            AccountCorrectionForm form = new AccountCorrectionForm(selected);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                updateTagCloud();
                dgvSearchResults.CurrentRow.Cells[2].Value = selected.EntryTime;
                dgvSearchResults.CurrentRow.Cells[3].Value = selected.Balance.ToString(Consts.UI.CurrencyFormat,
                    selected.CurrenciesRow.CurrencyCultureInfo);
            }
        }

        private void tsmiSubmitPlanTransaction_Click(object sender, EventArgs e)
        {
            TransactionEditForm form = new TransactionEditForm(
                (dgvSearchResults.CurrentRow.Tag as MoneyDataSet.PlannedTransactionsRow).TransactionTemplatesRow,
                dgvSearchResults.CurrentRow.Tag as MoneyDataSet.PlannedTransactionsRow);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                updateTagCloud();
            }
        }

        private void tsmiDeleteResult_Click(object sender, EventArgs e)
        {
            object tag = dgvSearchResults.CurrentRow.Tag;

            if (tag is MoneyDataSet.AccountsRow)
            {
                if (FormHelper.DeleteAccount(tag as MoneyDataSet.AccountsRow))
                {
                    updateTagCloud();
                    dgvSearchResults.Rows.Remove(dgvSearchResults.CurrentRow);
                }
            }
            else if (tag is MoneyDataSet.TransactionsRow)
            {
                if (FormHelper.DeleteTransaction(tag as MoneyDataSet.TransactionsRow))
                {
                    updateTagCloud();
                    dgvSearchResults.Rows.Remove(dgvSearchResults.CurrentRow);
                }
            }
            else if (tag is MoneyDataSet.PlannedTransactionsRow)
            {
                if (FormHelper.DeletePlannedTransaction(tag as MoneyDataSet.PlannedTransactionsRow))
                {
                    updateTagCloud();
                    dgvSearchResults.Rows.Remove(dgvSearchResults.CurrentRow);
                }
            }
            else
            {
                ErrorHelper.ShowErrorBox(ErrorHelper.Errors.UnknownSearchResult);
                Log.Write("Found in search", tag);
            }
        }

        private void dgvSearchResults_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo hti = dgvSearchResults.HitTest(e.X, e.Y);

                if (hti.Type == DataGridViewHitTestType.Cell)
                {
                    dgvSearchResults.CurrentCell = dgvSearchResults[hti.ColumnIndex, hti.RowIndex];
                    cmsSearchResults.Show(dgvSearchResults, e.Location);
                }
            }
        }

        private void cmsSearchResults_Opening(object sender, CancelEventArgs e)
        {
            object tag = dgvSearchResults.CurrentRow.Tag;

            tsmiOpenResult.Font = new Font(tsmiOpenResult.Font, FontStyle.Bold);
            if (tag is MoneyDataSet.AccountsRow)
            {
                tsmiOpenResult.Image = Properties.Resources.book_open;
                tsmiAccountBalanceCorrection.Visible = true;
                tsmiSubmitPlanTransaction.Visible = false;
                tsmiEditResult.Visible = true;
            }
            else if (tag is MoneyDataSet.TransactionsRow)
            {
                tsmiOpenResult.Image = Properties.Resources.application_form;
                tsmiAccountBalanceCorrection.Visible = false;
                tsmiSubmitPlanTransaction.Visible = false;
                tsmiEditResult.Visible = false;
            }
            else if (tag is MoneyDataSet.PlannedTransactionsRow)
            {
                tsmiOpenResult.Image = Properties.Resources.date;
                tsmiAccountBalanceCorrection.Visible = false;
                tsmiSubmitPlanTransaction.Visible = true;
                tsmiEditResult.Visible = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region Button handlers

        private void tsbDisplaySearchResults_Click(object sender, EventArgs e)
        {
            showResults();
        }

        #endregion

        #region Search suggestions

        private void updateSearchSuggestions()
        {
            tsstbSearchText.AutoCompleteCustomSource.Clear();
            tsstbSearchText.AutoCompleteCustomSource.AddRange(keeper.GetTextHistory(Consts.Keeper.HistorySearchID));
        }

        #endregion
             
    }
}
