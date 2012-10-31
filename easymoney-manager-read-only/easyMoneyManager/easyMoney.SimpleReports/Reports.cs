using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using easyMoney.Data;
using easyMoney.Utilities;
using System.Globalization;

namespace easyMoney.SimpleReports
{
    public static class Reports
    {

        #region Data classes

        public class AmountByTransactionTypeEntry
        {
            public const String TransactionTypeTitle = "TransactionType";
            public const String AmountTitle = "Amount";

            public AmountByTransactionTypeEntry(String transactionType, Double amount)
            {
                TransactionType = transactionType;
                Amount = amount;
            }

            public String TransactionType { get; set; }
            public double Amount { get; set; }
        }

        public class BalanceByDateEntry
        {
            public const String DateTitle = "Date";
            public const String AssetsTitle = "Assets";
            public const String DebtsTitle = "Debts";

            public BalanceByDateEntry(DateTime date, Double assets, Double debts)
            {
                Date = date;
                Assets = assets;
                Debts = debts;
            }

            public DateTime Date { get; set; }
            public double Assets { get; set; }
            public double Debts { get; set; }
        }

        public class AmountByTagEntry
        {
            public const String TagTitle = "Tag";
            public const String EarnedTitle = "Earned";
            public const String SpentTitle = "Spent";

            public AmountByTagEntry(String tag, Double spent, Double earned)
            {
                Tag = tag;
                Spent = spent;
                Earned = earned;
            }

            public String Tag { get; set; }
            public double Spent { get; set; }
            public double Earned { get; set; }
        }

        public class ReportEntry
        {
            public const String FieldID = "ID";
            public const String FieldTitle = "Title";

            public delegate void ReportHandler(Control parameters);
            public delegate Form RunReportHandler(Control parameters);

            public ReportEntry(int id, String title, String description, Control reportParameters, ReportHandler defaultsHandler, RunReportHandler runHandler)
            {
                ID = id;
                Title = title;
                Description = description;
                ReportParameters = reportParameters;
                DefaultsHandler = defaultsHandler;
                RunHandler = runHandler;
            }

            public int ID { get; set; }
            public String Title { get; set; }
            public String Description { get; set; }
            public Control ReportParameters { get; set; }
            public ReportHandler DefaultsHandler { get; set; }
            public RunReportHandler RunHandler { get; set; }

            public Form GetReport()
            {
                ReportLoadForm form = new ReportLoadForm(this);
                form.ShowDialog();
                return form.ReportForm;
            }
        }

        #endregion
        
        #region List of reports

        public static List<ReportEntry> GetAvailableReports()
        {
            List<Reports.ReportEntry> list = new List<Reports.ReportEntry>();
            int i = 0;
            
            // amount by tags grid
            list.Add(new Reports.ReportEntry(++i, Resources.Labels.AmountByTagsTitle,
                Resources.Labels.AmountByTagsDescription, new DateTypesTagsControl(), 
                Reports.AmountByTagsDefaults, Reports.AmountByTagsReport));

            // amount by tags chart
            list.Add(new Reports.ReportEntry(++i, Resources.Labels.AmountByTagsChartTitle,
                Resources.Labels.AmountByTagsChartDescription, new DateTypesTagsControl(), 
                Reports.AmountByTagsChartDefaults, Reports.AmountByTagsChartReport));

            // amount by transaction types
            list.Add(new Reports.ReportEntry(++i, Resources.Labels.AmountsByTransactionTypesTitle,
                Resources.Labels.AmountsByTransactionTypesDescription, new DateTypesTagsControl(), 
                Reports.AmountByTransactionTypesDefaults, Reports.AmountByTransactionTypesReport));

            // spending structure
            list.Add(new Reports.ReportEntry(++i, Resources.Labels.SpendingStructureTitle,
                Resources.Labels.SpendingStructureDescription, new DateOnlyControl(), 
                Reports.SpendingStructureDefaults, Reports.SpendingStructureReport));

            // transactions by account
            list.Add(new Reports.ReportEntry(++i, Resources.Labels.TransactionsByAccountTitle,
                Resources.Labels.TransactionsByAccountDescription, new DateAccountsTypesTags(),
                Reports.TransactionsByAccountDefaults, Reports.TransactionsByAccountReport));

            // balance changes report
            list.Add(new Reports.ReportEntry(++i, Resources.Labels.ActualBalanceChangesTitle,
                Resources.Labels.ActualBalanceChangesDescription, new DateOnlyControl(),
                Reports.ActualBalanceChangesDefaults, Reports.ActualBalanceChangesReport));

            // balance forecast
            list.Add(new Reports.ReportEntry(++i, Resources.Labels.PlannedBalanceChangesTitle,
                Resources.Labels.PlannedBalanceChangesDescription, new DateOnlyControl(),
                Reports.PlannedBalanceChangesDefaults, Reports.PlannedBalanceChangesReport));

            // month balance
            list.Add(new Reports.ReportEntry(++i, Resources.Labels.MonthBalanceTitle,
                Resources.Labels.MonthBalanceDescription, new MonthPickerControl(),
                Reports.MonthBalanceDefaults, Reports.MonthBalanceReport));

            return list;
        }

        #endregion

        #region Amounts By Tags report

        public static void AmountByTagsDefaults(Control parameters)
        {
            try
            {
                MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
                DateTypesTagsControl amountByTagsPars = parameters as DateTypesTagsControl;
                amountByTagsPars.Dock = DockStyle.Top;

                amountByTagsPars.dtpStartDate.Value = DateTime.Now.AddMonths(-1);
                amountByTagsPars.dtpEndDate.Value = DateTime.Now;

                amountByTagsPars.lbAccountTypes.DisplayMember = keeper.DataSet.AccountTypes.TitleColumn.ColumnName;
                amountByTagsPars.lbAccountTypes.ValueMember = keeper.DataSet.AccountTypes.IDColumn.ColumnName;
                //amountByTagsPars.lbAccountTypes.DataSource = keeper.GetAccountTypes();
                amountByTagsPars.lbAccountTypes.Items.Clear();
                foreach (var accType in keeper.GetAccountTypes())
                {
                    amountByTagsPars.lbAccountTypes.Items.Add(accType);
                }
                for (int i = 0; i < amountByTagsPars.lbAccountTypes.Items.Count; i++)
                {
                    amountByTagsPars.lbAccountTypes.SetSelected(i, true);
                }

                amountByTagsPars.lbTransactionTypes.DisplayMember = keeper.DataSet.TransactionTypes.TitleColumn.ColumnName;
                amountByTagsPars.lbTransactionTypes.ValueMember = keeper.DataSet.TransactionTypes.IDColumn.ColumnName;
                //amountByTagsPars.lbTransactionTypes.DataSource = keeper.GetTransactionTypes();
                amountByTagsPars.lbTransactionTypes.Items.Clear();
                foreach (var transType in keeper.GetTransactionTypes())
                {
                    amountByTagsPars.lbTransactionTypes.Items.Add(transType);
                }
                for (int i = 0; i < amountByTagsPars.lbTransactionTypes.Items.Count; i++)
                {
                    amountByTagsPars.lbTransactionTypes.SetSelected(i, true);
                }

                amountByTagsPars.lbTags.Items.Clear();
                amountByTagsPars.lbTags.Items.AddRange(keeper.Tags.ToArray());
                for (int i = 0; i < amountByTagsPars.lbTags.Items.Count; i++)
                {
                    amountByTagsPars.lbTags.SetSelected(i, true);
                }
            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(e: e);
            }
        }

        public static Form AmountByTagsReport(Control parameters)
        {
            const String columnTag = "tag";
            const String columnSpent = "spent";
            const String columnEarned = "earned";
            const String columnDelta = "delta";
            const String columnTransactions = "transactions";
            try
            {
                MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
                DateTypesTagsControl pars = parameters as DateTypesTagsControl;
                DateTime StartDate = DateTime.Now;
                DateTime EndDate = DateTime.Now;
                IEnumerable<MoneyDataSet.AccountTypesRow> AccountTypes = null;
                IEnumerable<MoneyDataSet.TransactionTypesRow> TransactionTypes = null;
                IEnumerable<String> Tags = null;
                if (pars != null)
                {
                    MethodInvoker inv = delegate()
                    {
                        StartDate = pars.dtpStartDate.Value;
                        EndDate = pars.dtpEndDate.Value;
                        AccountTypes = pars.lbAccountTypes.SelectedItems.Cast<MoneyDataSet.AccountTypesRow>().ToArray();
                        TransactionTypes = pars.lbTransactionTypes.SelectedItems.Cast<MoneyDataSet.TransactionTypesRow>().ToArray();
                        Tags = pars.lbTags.SelectedItems.Cast<String>().ToArray();
                    };
                    pars.Invoke(inv);

                    ReportGridForm form = new ReportGridForm();
                    form.Text = String.Format(Resources.Labels.AmountByTagsFormTitleFormat, StartDate.ToShortDateString(), EndDate.ToShortDateString());

                    form.Grid.Columns.Add(columnTag, Resources.Labels.TagTitle);
                    form.Grid.Columns.Add(columnSpent, Resources.Labels.SpentTitle);
                    form.Grid.Columns.Add(columnEarned, Resources.Labels.EarnedTitle);
                    form.Grid.Columns.Add(columnDelta, Resources.Labels.DeltaTitle);
                    form.Grid.Columns.Add(columnTransactions, Resources.Labels.TransactionsTitle);

                    form.Grid.Columns[columnSpent].CellTemplate.Style.Format = Consts.UI.NumericFormat;
                    form.Grid.Columns[columnEarned].CellTemplate.Style.Format = Consts.UI.NumericFormat;
                    form.Grid.Columns[columnDelta].CellTemplate.Style.Format = Consts.UI.NumericFormat;
                    form.Grid.Columns[columnTransactions].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    form.Grid.Columns[columnTag].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    form.Grid.Columns[columnSpent].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    form.Grid.Columns[columnEarned].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    form.Grid.Columns[columnDelta].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                    form.Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                    // preparing data
                    foreach (MoneyDataSet.TagsRow tag in keeper.DataSet.Tags.Where(t => (Tags.Contains(t.Title))))
                    {
                        double spent = 0;
                        double earned = 0;
                        StringBuilder transactions = new StringBuilder();

                        IEnumerable<MoneyDataSet.TransactionsRow> transactionList = keeper.Transactions.Where(t =>
                            ((t.IsActive) && (!t.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.Correction)) &&
                            (TransactionTypes.Contains(t.TransactionTypesRow)) &&
                            (AccountTypes.Contains(t.AccountRow.AccountTypesRow)) &&
                            (t.EntryTime >= StartDate.Date) &&
                            (t.EntryTime < EndDate.Date.AddDays(1)) &&
                            (t.GetTransactionTagsRows().Where(tt => (tt.TagID == tag.ID)).Any())));

                        foreach (MoneyDataSet.TransactionsRow transaction in transactionList)
                        {

                            if (transaction.TransactionTypesRow.IsIncome)
                            {
                                earned += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                            }
                            else
                            {
                                spent += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                            }
                            if (transactions.Length > 0)
                            {
                                transactions.Append(", ");
                            }
                            transactions.Append(transaction.Title);
                        }
                        if ((spent != 0) || (earned != 0))
                        {
                            form.Grid.Rows.Add(tag.Title, spent, earned, (earned - spent), transactions.ToString());
                        }
                    }

                    form.Grid.Columns[columnTag].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    form.Grid.Columns[columnSpent].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    form.Grid.Columns[columnEarned].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    form.Grid.Columns[columnDelta].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    form.Grid.Sort(form.Grid.Columns[columnTag], ListSortDirection.Ascending);

                    form.Grid.Refresh();

                    return form;
                }
            }
            catch (Exception e)
            {
                Log.Write(e);
            }
            return null;
        }

        #endregion

        #region Amounts By Tags Chart report

        public static void AmountByTagsChartDefaults(Control parameters)
        {
            try
            {
                MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
                DateTypesTagsControl amountByTagsChartPars = parameters as DateTypesTagsControl;
                amountByTagsChartPars.Dock = DockStyle.Top;
                
                amountByTagsChartPars.dtpStartDate.Value = DateTime.Now.AddMonths(-1);
                amountByTagsChartPars.dtpEndDate.Value = DateTime.Now;
                amountByTagsChartPars.lbAccountTypes.DisplayMember = keeper.DataSet.AccountTypes.TitleColumn.ColumnName;
                amountByTagsChartPars.lbAccountTypes.ValueMember = keeper.DataSet.AccountTypes.IDColumn.ColumnName;
                //amountByTagsChartPars.lbAccountTypes.DataSource = keeper.GetAccountTypes();
                amountByTagsChartPars.lbAccountTypes.Items.Clear();
                foreach (var accType in keeper.GetAccountTypes())
                {
                    amountByTagsChartPars.lbAccountTypes.Items.Add(accType);
                }
                for (int i = 0; i < amountByTagsChartPars.lbAccountTypes.Items.Count; i++)
                {
                    amountByTagsChartPars.lbAccountTypes.SetSelected(i, true);
                }

                amountByTagsChartPars.lbTransactionTypes.DisplayMember = keeper.DataSet.TransactionTypes.TitleColumn.ColumnName;
                amountByTagsChartPars.lbTransactionTypes.ValueMember = keeper.DataSet.TransactionTypes.IDColumn.ColumnName;
                //amountByTagsChartPars.lbTransactionTypes.DataSource = keeper.GetTransactionTypes();
                amountByTagsChartPars.lbTransactionTypes.Items.Clear();
                foreach (var transType in keeper.GetTransactionTypes())
                {
                    amountByTagsChartPars.lbTransactionTypes.Items.Add(transType);
                }
                for (int i = 0; i < amountByTagsChartPars.lbTransactionTypes.Items.Count; i++)
                {
                    amountByTagsChartPars.lbTransactionTypes.SetSelected(i, true);
                }

                amountByTagsChartPars.lbTags.Items.Clear();
                amountByTagsChartPars.lbTags.Items.AddRange(keeper.Tags.ToArray());
                for (int i = 0; i < amountByTagsChartPars.lbTags.Items.Count; i++)
                {
                    amountByTagsChartPars.lbTags.SetSelected(i, true);
                }
            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(e: e);
            }
        }

        public static Form AmountByTagsChartReport(Control parameters)
        {
            try
            {
                MoneyDataKeeper keeper = MoneyDataKeeper.Instance;

                DateTypesTagsControl pars = parameters as DateTypesTagsControl;
                DateTime StartDate = DateTime.Now;
                DateTime EndDate = DateTime.Now;
                IEnumerable<MoneyDataSet.AccountTypesRow> AccountTypes = null;
                IEnumerable<MoneyDataSet.TransactionTypesRow> TransactionTypes = null;
                IEnumerable<String> Tags = null;
                int AccountTypeCount = 0;
                int TransactionTypeCount = 0;
                int TagCount = 0;

                if (pars != null)
                {
                    MethodInvoker inv = delegate()
                    {
                        StartDate = pars.dtpStartDate.Value;
                        EndDate = pars.dtpEndDate.Value;
                        AccountTypes = pars.lbAccountTypes.SelectedItems.Cast<MoneyDataSet.AccountTypesRow>().ToArray();
                        AccountTypeCount = pars.lbAccountTypes.Items.Count;
                        TransactionTypes = pars.lbTransactionTypes.SelectedItems.Cast<MoneyDataSet.TransactionTypesRow>().ToArray();
                        TransactionTypeCount = pars.lbTransactionTypes.Items.Count;
                        Tags = pars.lbTags.SelectedItems.Cast<String>().ToArray();
                        TagCount = pars.lbTags.Items.Count;
                    };
                    pars.Invoke(inv);

                    ReportChartForm form = new ReportChartForm();
                    form.Text = String.Format(Resources.Labels.AmountByTagsFormTitleFormat,
                        StartDate.ToShortDateString(), EndDate.ToShortDateString());

                    List<AmountByTagEntry> entries = new List<AmountByTagEntry>();

                    foreach (MoneyDataSet.TagsRow tag in keeper.DataSet.Tags.Where(t => (Tags.Contains(t.Title))))
                    {
                        double spent = 0;
                        double earned = 0;

                        IEnumerable<MoneyDataSet.TransactionsRow> transactionList = keeper.Transactions.Where(t =>
                            ((t.IsActive) && (!t.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.Correction)) &&
                            (TransactionTypes.Contains(t.TransactionTypesRow)) &&
                            (AccountTypes.Contains(t.AccountRow.AccountTypesRow)) &&
                            (t.EntryTime >= StartDate.Date) &&
                            (t.EntryTime < EndDate.Date.AddDays(1)) &&
                            (t.GetTransactionTagsRows().Where(tt => (tt.TagID == tag.ID)).Any())));

                        foreach (MoneyDataSet.TransactionsRow transaction in transactionList)
                        {

                            if (transaction.TransactionTypesRow.IsIncome)
                            {
                                earned += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                            }
                            else
                            {
                                spent += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                            }
                        }
                        if ((spent != 0) || (earned != 0))
                        {
                            entries.Add(new AmountByTagEntry(tag.Title, spent, earned));
                        }
                    }

                    StringBuilder title = new StringBuilder();
                    
                    if (AccountTypes.Count() != AccountTypeCount)
                    {
                        title.AppendLine(String.Format(Resources.Labels.OnlyAccountTypes,
                            String.Join(Consts.UI.EnumerableSeparator, AccountTypes.Select(a => (a.Title)))));
                    }

                    if (TransactionTypes.Count() != TransactionTypeCount)
                    {
                        title.AppendLine(String.Format(Resources.Labels.OnlyTransactionTypesTypes,
                            String.Join(Consts.UI.EnumerableSeparator,TransactionTypes.Select(a => (a.Title)))));
                    }

                    if (Tags.Count() != TagCount)
                    {
                        title.AppendLine(String.Format(Resources.Labels.OnlyTags, String.Join(Consts.UI.EnumerableSeparator, Tags)));
                    }

                    if (!String.IsNullOrWhiteSpace(title.ToString()))
                    {
                        form.Chart.Titles.Add(title.ToString());
                    }
                    
                    form.Chart.DataSource = entries;

                    Legend legend = new Legend();

                    form.Chart.Legends.Add(legend);

                    form.Chart.ChartAreas[0].AxisY.LabelStyle.Format = Consts.UI.NumericFormat;

                    form.Chart.Series[0].XValueType = ChartValueType.String;
                    form.Chart.Series[0].YValueType = ChartValueType.Double;
                    form.Chart.Series[0].YValuesPerPoint = 1;
                    form.Chart.Series[0].ShadowOffset = 1;
                    form.Chart.Series[0].ToolTip = String.Format(Consts.UI.DefaultChartToolTipFormat, Resources.Labels.SpentTitle);
                    form.Chart.Series[0].Color = Color.DarkSalmon;
                    form.Chart.Series[0].XValueMember = AmountByTagEntry.TagTitle;
                    form.Chart.Series[0].YValueMembers = AmountByTagEntry.SpentTitle;
                    form.Chart.Series[0].Legend = legend.Name;
                    form.Chart.Series[0].LegendText = Resources.Labels.SpentTitle;

                    form.Chart.Series.Add(new Series());
                    form.Chart.Series[1].XValueType = ChartValueType.String;
                    form.Chart.Series[1].YValueType = ChartValueType.Double;
                    form.Chart.Series[1].YValuesPerPoint = 1;
                    form.Chart.Series[1].ShadowOffset = 1;
                    form.Chart.Series[1].XValueMember = AmountByTagEntry.TagTitle;
                    form.Chart.Series[1].YValueMembers = AmountByTagEntry.EarnedTitle;
                    form.Chart.Series[1].ToolTip = String.Format(Consts.UI.DefaultChartToolTipFormat, Resources.Labels.EarnedTitle);
                    form.Chart.Series[1].Color = Color.SteelBlue;
                    form.Chart.Series[1].Legend = legend.Name;
                    form.Chart.Series[1].LegendText = Resources.Labels.EarnedTitle;
                    
                    form.Chart.DataBind();

                    return form;

                }
            }
            catch (Exception e)
            {
                Log.Write(e);
            }
            return null;
        }
        
        #endregion

        #region Amounts By Transaction Types report

        public static void AmountByTransactionTypesDefaults(Control parameters)
        {
            try
            {
                MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
                DateTypesTagsControl amountByTransactionTypesPars = parameters as DateTypesTagsControl;
                amountByTransactionTypesPars.Dock = DockStyle.Top;

                amountByTransactionTypesPars.dtpStartDate.Value = DateTime.Now.AddMonths(-1);
                amountByTransactionTypesPars.dtpEndDate.Value = DateTime.Now;

                amountByTransactionTypesPars.lbAccountTypes.DisplayMember = keeper.DataSet.AccountTypes.TitleColumn.ColumnName;
                amountByTransactionTypesPars.lbAccountTypes.ValueMember = keeper.DataSet.AccountTypes.IDColumn.ColumnName;
                //amountByTransactionTypesPars.lbAccountTypes.DataSource = keeper.GetAccountTypes();
                amountByTransactionTypesPars.lbAccountTypes.Items.Clear();
                foreach (var accType in keeper.GetAccountTypes())
                {
                    amountByTransactionTypesPars.lbAccountTypes.Items.Add(accType);
                }
                for (int i = 0; i < amountByTransactionTypesPars.lbAccountTypes.Items.Count; i++)
                {
                    amountByTransactionTypesPars.lbAccountTypes.SetSelected(i, true);
                }

                amountByTransactionTypesPars.lbTransactionTypes.DisplayMember = keeper.DataSet.TransactionTypes.TitleColumn.ColumnName;
                amountByTransactionTypesPars.lbTransactionTypes.ValueMember = keeper.DataSet.TransactionTypes.IDColumn.ColumnName;
                //amountByTransactionTypesPars.lbTransactionTypes.DataSource = keeper.GetTransactionTypes();
                amountByTransactionTypesPars.lbTransactionTypes.Items.Clear();
                foreach (var transType in keeper.GetTransactionTypes())
                {
                    amountByTransactionTypesPars.lbTransactionTypes.Items.Add(transType);
                }
                for (int i = 0; i < amountByTransactionTypesPars.lbTransactionTypes.Items.Count; i++)
                {
                    amountByTransactionTypesPars.lbTransactionTypes.SetSelected(i, true);
                }

                amountByTransactionTypesPars.lbTags.Items.Clear();
                amountByTransactionTypesPars.lbTags.Items.AddRange(keeper.Tags.ToArray());
                for (int i = 0; i < amountByTransactionTypesPars.lbTags.Items.Count; i++)
                {
                    amountByTransactionTypesPars.lbTags.SetSelected(i, true);
                }
            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(e: e);
            }
        }

        public static Form AmountByTransactionTypesReport(Control parameters)
        {
            try
            {
                DateTypesTagsControl pars = parameters as DateTypesTagsControl;
                DateTime StartDate = DateTime.Now;
                DateTime EndDate = DateTime.Now;
                IEnumerable<MoneyDataSet.AccountTypesRow> AccountTypes = null;
                IEnumerable<MoneyDataSet.TransactionTypesRow> TransactionTypes = null;
                IEnumerable<String> Tags = null;
                int AccountTypeCount = 0;
                int TransactionTypeCount = 0;
                int TagCount = 0; 
                
                if (pars != null)
                {
                    MethodInvoker inv = delegate()
                    {
                        StartDate = pars.dtpStartDate.Value;
                        EndDate = pars.dtpEndDate.Value;
                        AccountTypes = pars.lbAccountTypes.SelectedItems.Cast<MoneyDataSet.AccountTypesRow>().ToArray();
                        AccountTypeCount = pars.lbAccountTypes.Items.Count;
                        TransactionTypes = pars.lbTransactionTypes.SelectedItems.Cast<MoneyDataSet.TransactionTypesRow>().ToArray();
                        TransactionTypeCount = pars.lbTransactionTypes.Items.Count;
                        Tags = pars.lbTags.SelectedItems.Cast<String>().ToArray();
                        TagCount = pars.lbTags.Items.Count;
                    };
                    pars.Invoke(inv);

                    ReportChartForm form = new ReportChartForm();
                    form.Text = String.Format(Resources.Labels.AmountsByTransactionTypesFormTitleFormat, StartDate.ToShortDateString(), EndDate.ToShortDateString());

                    List<AmountByTransactionTypeEntry> entries = new List<AmountByTransactionTypeEntry>();

                    foreach (MoneyDataSet.TransactionTypesRow tt in TransactionTypes)
                    {
                        double amount = 0;
                        foreach (MoneyDataSet.TransactionsRow t in MoneyDataKeeper.Instance.Transactions.Where(tr =>
                            ((tr.IsActive) && (tr.TypeID == tt.ID) &&
                            (AccountTypes.Contains(tr.AccountRow.AccountTypesRow)) &&
                            (tr.TransactionTime >= StartDate.Date) &&
                            ((!tr.GetTransactionTagsRows().Any()) ||
                            (tr.GetTransactionTagsRows().Select(tags => (tags.TagRow.Title)).Intersect(Tags).Any())) &&
                            (tr.TransactionTime < EndDate.Date.AddDays(1)))))
                        {
                            amount += Math.Abs(t.Amount * t.AccountRow.CurrenciesRow.ExchangeRate);
                        }
                        if (amount > 0)
                        {
                            entries.Add(new AmountByTransactionTypeEntry(tt.Title, amount));
                        }
                    }

                    StringBuilder title = new StringBuilder();

                    if (AccountTypes.Count() != AccountTypeCount)
                    {
                        title.AppendLine(String.Format(Resources.Labels.OnlyAccountTypes,
                            String.Join(Consts.UI.EnumerableSeparator, AccountTypes.Select(a => (a.Title)))));
                    }

                    if (TransactionTypes.Count() != TransactionTypeCount)
                    {
                        title.AppendLine(String.Format(Resources.Labels.OnlyTransactionTypesTypes,
                            String.Join(Consts.UI.EnumerableSeparator, TransactionTypes.Select(a => (a.Title)))));
                    }

                    if (Tags.Count() != TagCount)
                    {
                        title.AppendLine(String.Format(Resources.Labels.OnlyTags, String.Join(Consts.UI.EnumerableSeparator, Tags)));
                    }

                    if (!String.IsNullOrWhiteSpace(title.ToString()))
                    {
                        form.Chart.Titles.Add(title.ToString());
                    }

                    // form.Chart.Series[0].ChartType = SeriesChartType.Pie;

                    form.Chart.DataSource = entries;

                    form.Chart.ChartAreas[0].AxisY.LabelStyle.Format = Consts.UI.NumericFormat;
                    
                    form.Chart.Series[0].XValueType = ChartValueType.String;
                    form.Chart.Series[0].YValueType = ChartValueType.Double;
                    form.Chart.Series[0].YValuesPerPoint = 1;
                    form.Chart.Series[0].ShadowOffset = 1;
                    form.Chart.Series[0].ToolTip = Consts.UI.SmallChartToolTip;
                    form.Chart.Series[0].Palette = ChartColorPalette.Pastel;
                    form.Chart.Series[0].XValueMember = AmountByTransactionTypeEntry.TransactionTypeTitle;
                    form.Chart.Series[0].YValueMembers = AmountByTransactionTypeEntry.AmountTitle;

                    form.Chart.DataBind();

                    return form;

                }
            }
            catch (Exception e)
            {
                Log.Write(e);
            }
            return null;
        }

        #endregion

        #region Spending structure report

        public static void SpendingStructureDefaults(Control parameters)
        {
            try
            {
                DateOnlyControl spendingStructurePars = parameters as DateOnlyControl;
                spendingStructurePars.Dock = DockStyle.Top;

                spendingStructurePars.dtpStartDate.Value = DateTime.Now;
                spendingStructurePars.dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(e: e);
            }
        }

        public static Form SpendingStructureReport(Control parameters)
        {
            const String PieLabelStyle = "PieLabelStyle";
            const String PieLabelStyleValue = "Outside";

            try
            {
                DateOnlyControl pars = parameters as DateOnlyControl;
                DateTime StartDate = DateTime.Now;
                DateTime EndDate = DateTime.Now; 
                
                if (pars != null)
                {
                    MethodInvoker inv = delegate()
                    {
                        StartDate = pars.dtpStartDate.Value;
                        EndDate = pars.dtpEndDate.Value;
                    };
                    pars.Invoke(inv); 
                    
                    ReportChartForm form = new ReportChartForm();
                    form.Text = String.Format(Resources.Labels.SpendingStructureFormTitleFormat,
                        StartDate.ToShortDateString(), EndDate.ToShortDateString());

                    List<AmountByTransactionTypeEntry> entries = new List<AmountByTransactionTypeEntry>();

                    foreach (MoneyDataSet.TransactionTypesRow tt in MoneyDataKeeper.Instance.GetTransactionTypes(false))
                    {
                        // excluding irrelevant transaction types
                        if ((tt.ID.Equals(MoneyDataSet.IDs.TransactionTypes.Correction)) ||
                            (tt.ID.Equals(MoneyDataSet.IDs.TransactionTypes.TransferOut))) continue;                        

                        double amount = 0;
                        foreach (MoneyDataSet.TransactionsRow t in MoneyDataKeeper.Instance.Transactions.Where(tr =>
                            ((tr.IsActive) && (tr.TypeID == tt.ID) &&
                            (tr.TransactionTime >= StartDate.Date) &&
                            (tr.TransactionTime < EndDate.Date.AddDays(1)))))
                        {
                            amount += Math.Abs(t.Amount * t.AccountRow.CurrenciesRow.ExchangeRate);
                        }
                        if (amount > 0)
                        {
                            entries.Add(new AmountByTransactionTypeEntry(tt.Title, amount));
                        }
                    }

                    form.Chart.Series[0].ChartType = SeriesChartType.Doughnut;

                    form.Chart.DataSource = entries;

                    form.Chart.Series[0].XValueType = ChartValueType.String;
                    form.Chart.Series[0].YValueType = ChartValueType.Double;
                    form.Chart.Series[0].YValuesPerPoint = 1;
                    form.Chart.Series[0].ShadowOffset = 1;
                    form.Chart.Series[0].ToolTip = Consts.UI.ChartWithPercentageToolTip;
                    form.Chart.Series[0].XValueMember = AmountByTransactionTypeEntry.TransactionTypeTitle;
                    form.Chart.Series[0].YValueMembers = AmountByTransactionTypeEntry.AmountTitle;

                    form.Chart.Series[0].Label = Consts.UI.ChartWithPercentageToolTip;

                    form.Chart.Series[0].SmartLabelStyle.Enabled = true;
                    form.Chart.Series[0].SmartLabelStyle.CalloutStyle = LabelCalloutStyle.Underlined;
                    form.Chart.Series[0].SmartLabelStyle.CalloutLineDashStyle = ChartDashStyle.Solid;
                    form.Chart.Series[0].SmartLabelStyle.CalloutLineAnchorCapStyle = LineAnchorCapStyle.Arrow;
                    form.Chart.Series[0].SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
                    form.Chart.Series[0].SmartLabelStyle.CalloutLineWidth = 1;

                    form.Chart.Series[0][PieLabelStyle] = PieLabelStyleValue;
                    form.Chart.ChartAreas[0].Area3DStyle.Enable3D = true;

                    //form.Chart.ChartAreas[0].Area3DStyle.Rotation = 10;
                    //form.Chart.Series[0].Palette = ChartColorPalette.Pastel;

                    form.Chart.DataBind();

                    return form;
                }
            }
            catch (Exception e)
            {
                Log.Write(e);
            }
            return null;
        }

        #endregion

        #region Planned Balance Changes Report

        public static void PlannedBalanceChangesDefaults(Control parameters)
        {
            try
            {
                DateOnlyControl plannedBalanceChangesPars = parameters as DateOnlyControl;
                plannedBalanceChangesPars.Dock = DockStyle.Top;
                
                plannedBalanceChangesPars.dtpStartDate.Value = DateTime.Now;
                plannedBalanceChangesPars.dtpEndDate.Value = DateTime.Now.AddMonths(1);
            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(e: e);
            }
        }

        public static Form PlannedBalanceChangesReport(Control parameters)
        {
            try
            {
                MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
                DateOnlyControl pars = parameters as DateOnlyControl;
                DateTime StartDate = DateTime.Now;
                DateTime EndDate = DateTime.Now; 
                
                if (pars != null)
                {
                    MethodInvoker inv = delegate()
                    {
                        StartDate = pars.dtpStartDate.Value;
                        EndDate = pars.dtpEndDate.Value;
                    };
                    pars.Invoke(inv);
                    
                    ReportChartForm form = new ReportChartForm();
                    form.Text = String.Format(Resources.Labels.PlannedBalanceChangesFormTitleFormat,
                        StartDate.ToShortDateString(), EndDate.ToShortDateString());

                    List<BalanceByDateEntry> entries = new List<BalanceByDateEntry>();

                    double assets = 0;
                    double debts = 0;

                    foreach (MoneyDataSet.AccountsRow account in keeper.Accounts)
                    {
                        if (account.AccountTypesRow.IsDebit)
                        {
                            assets += keeper.GetAccountBalace(account, StartDate) * account.CurrenciesRow.ExchangeRate;
                        }
                        else
                        {
                            debts += Math.Abs(keeper.GetAccountBalace(account, StartDate) * account.CurrenciesRow.ExchangeRate);
                        }
                    }


                    entries.Add(new BalanceByDateEntry(StartDate.Date, assets, debts));

                    foreach (MoneyDataKeeper.ActivePlannedTransactionEntry plan in keeper.GetActivePlannedTransactions(StartDate, EndDate).OrderBy(o => (o.Date)))
                    {

                        // skipping plans without date
                        if (plan.Date.Equals(DateTime.MaxValue)) continue;

                        if (plan.PlannedTransaction.AccountTypeRow.IsDebit)
                        {
                            if (plan.PlannedTransaction.TransactionTypeRow.IsIncome)
                            {
                                assets += plan.PlannedTransaction.Amount * plan.PlannedTransaction.CurrenciesRow.ExchangeRate;
                            }
                            else
                            {
                                assets -= plan.PlannedTransaction.Amount * plan.PlannedTransaction.CurrenciesRow.ExchangeRate;
                            }
                        }
                        else
                        {
                            if (plan.PlannedTransaction.TransactionTypeRow.IsIncome)
                            {
                                debts -= plan.PlannedTransaction.Amount * plan.PlannedTransaction.CurrenciesRow.ExchangeRate;
                            }
                            else
                            {
                                debts += plan.PlannedTransaction.Amount * plan.PlannedTransaction.CurrenciesRow.ExchangeRate;
                            }
                        }
                        entries.Add(new BalanceByDateEntry(plan.Date, assets, debts));
                    }

                    entries.Add(new BalanceByDateEntry(EndDate.Date.AddDays(1), assets, debts));

                    form.Chart.DataSource = entries;

                    Legend legend = new Legend();

                    form.Chart.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
                    form.Chart.ChartAreas[0].AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 1;
                    form.Chart.ChartAreas[0].AxisY.LabelStyle.Format = Consts.UI.NumericFormat;

                    form.Chart.Legends.Add(legend);
                    form.Chart.Series[0].ChartType = SeriesChartType.Line;
                    form.Chart.Series[0].BorderWidth = 3;
                    form.Chart.Series[0].XValueType = ChartValueType.Date;
                    form.Chart.Series[0].YValueType = ChartValueType.Double;
                    form.Chart.Series[0].YValuesPerPoint = 1;
                    form.Chart.Series[0].ToolTip = String.Format(Consts.UI.DefaultChartToolTipFormat, Resources.Labels.AssetsTitle);
                    //form.Chart.Series[0].Color = Color.DarkSalmon;
                    form.Chart.Series[0].XValueMember = BalanceByDateEntry.DateTitle;
                    form.Chart.Series[0].YValueMembers = BalanceByDateEntry.AssetsTitle;
                    form.Chart.Series[0].Legend = legend.Name;
                    form.Chart.Series[0].LegendText = Resources.Labels.AssetsTitle;

                    form.Chart.Series.Add(new Series());
                    form.Chart.Series[1].ChartType = SeriesChartType.Line;
                    form.Chart.Series[1].BorderWidth = 3;
                    form.Chart.Series[1].XValueType = ChartValueType.Date;
                    form.Chart.Series[1].YValueType = ChartValueType.Double;
                    form.Chart.Series[1].YValuesPerPoint = 1;
                    form.Chart.Series[1].XValueMember = BalanceByDateEntry.DateTitle;
                    form.Chart.Series[1].YValueMembers = BalanceByDateEntry.DebtsTitle;
                    form.Chart.Series[1].ToolTip = String.Format(Consts.UI.DefaultChartToolTipFormat, Resources.Labels.DebtsTitle);
                    //form.Chart.Series[1].Color = Color.SteelBlue;
                    form.Chart.Series[1].Legend = legend.Name;
                    form.Chart.Series[1].LegendText = Resources.Labels.DebtsTitle;

                    form.Chart.DataBind();

                    return form;

                }
            }
            catch (Exception e)
            {
                Log.Write(e);
            }
            return null;
        }

        #endregion

        #region Actual Balance Changes Report

        public static void ActualBalanceChangesDefaults(Control parameters)
        {
            try
            {
                DateOnlyControl actualBalanceChangesPars = parameters as DateOnlyControl;
                actualBalanceChangesPars.Dock = DockStyle.Top;
                
                actualBalanceChangesPars.dtpEndDate.Value = DateTime.Now;
                actualBalanceChangesPars.dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(e: e);
            }
        }
        
        public static Form ActualBalanceChangesReport(Control parameters)
        {
            try
            {
                MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
                DateOnlyControl pars = parameters as DateOnlyControl;
                DateTime StartDate = DateTime.Now;
                DateTime EndDate = DateTime.Now;

                if (pars != null)
                {
                    MethodInvoker inv = delegate()
                    {
                        StartDate = pars.dtpStartDate.Value;
                        EndDate = pars.dtpEndDate.Value;
                    };
                    pars.Invoke(inv);

                    ReportChartForm form = new ReportChartForm();
                    form.Text = String.Format(Resources.Labels.ActualBalanceChangesFormTitleFormat,
                        StartDate.ToShortDateString(), EndDate.ToShortDateString());

                    List<BalanceByDateEntry> entries = new List<BalanceByDateEntry>();
                    
                    DateTime current = StartDate.Date;

                    while (current < EndDate)
                    {
                        double assets = 0;
                        double debts = 0;
                        foreach (MoneyDataSet.AccountsRow account in keeper.Accounts)
                        {
                            if (account.AccountTypesRow.IsDebit)
                            {
                                assets += keeper.GetAccountBalace(account, current) * account.CurrenciesRow.ExchangeRate;
                            }
                            else
                            {
                                debts += Math.Abs(keeper.GetAccountBalace(account, current) * account.CurrenciesRow.ExchangeRate);
                            }
                        }
                        entries.Add(new BalanceByDateEntry(current, assets, debts));
                        current = current.AddDays(1);
                    }



                    List<BalanceByDateEntry> entriesForecast = new List<BalanceByDateEntry>();

                    double assetsForecast = 0;
                    double debtsForecast = 0;

                    foreach (MoneyDataSet.AccountsRow account in keeper.Accounts)
                    {
                        if (account.AccountTypesRow.IsDebit)
                        {
                            assetsForecast += keeper.GetAccountBalace(account, StartDate) * account.CurrenciesRow.ExchangeRate;
                        }
                        else
                        {
                            debtsForecast += Math.Abs(keeper.GetAccountBalace(account, StartDate) * account.CurrenciesRow.ExchangeRate);
                        }
                    }


                    entriesForecast.Add(new BalanceByDateEntry(StartDate.Date, assetsForecast, debtsForecast));

                    foreach (MoneyDataKeeper.ActivePlannedTransactionEntry plan in keeper.GetActivePlannedTransactions(StartDate, EndDate).OrderBy(o => (o.Date)))
                    {
                        // skipping plans without date
                        if (plan.Date.Equals(DateTime.MaxValue)) continue;

                        if (plan.PlannedTransaction.AccountTypeRow.IsDebit)
                        {
                            if (plan.PlannedTransaction.TransactionTypeRow.IsIncome)
                            {
                                assetsForecast += plan.PlannedTransaction.Amount * plan.PlannedTransaction.CurrenciesRow.ExchangeRate;
                            }
                            else
                            {
                                assetsForecast -= plan.PlannedTransaction.Amount * plan.PlannedTransaction.CurrenciesRow.ExchangeRate;
                            }
                        }
                        else
                        {
                            if (plan.PlannedTransaction.TransactionTypeRow.IsIncome)
                            {
                                debtsForecast -= plan.PlannedTransaction.Amount * plan.PlannedTransaction.CurrenciesRow.ExchangeRate;
                            }
                            else
                            {
                                debtsForecast += plan.PlannedTransaction.Amount * plan.PlannedTransaction.CurrenciesRow.ExchangeRate;
                            }
                        }
                        entriesForecast.Add(new BalanceByDateEntry(plan.Date, assetsForecast, debtsForecast));
                    }

                    entriesForecast.Add(new BalanceByDateEntry(EndDate.Date.AddDays(1), assetsForecast, debtsForecast));
                    
                    Legend legend = new Legend();

                    form.Chart.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
                    form.Chart.ChartAreas[0].AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 1;
                    form.Chart.ChartAreas[0].AxisY.LabelStyle.Format = Consts.UI.NumericFormat;
                    form.Chart.Legends.Add(legend);

                    form.Chart.Series[0].ChartType = SeriesChartType.Line;
                    form.Chart.Series[0].BorderWidth = 3;
                    form.Chart.Series[0].XValueType = ChartValueType.Date;
                    form.Chart.Series[0].YValueType = ChartValueType.Double;
                    form.Chart.Series[0].YValuesPerPoint = 1;
                    form.Chart.Series[0].ToolTip = String.Format(Consts.UI.DefaultChartToolTipFormat, Resources.Labels.AssetsPlannedTitle);
                    form.Chart.Series[0].Color = Color.Blue;
                    form.Chart.Series[0].Points.DataBind(entriesForecast, BalanceByDateEntry.DateTitle, BalanceByDateEntry.AssetsTitle, String.Empty);
                    form.Chart.Series[0].Legend = legend.Name;
                    form.Chart.Series[0].LegendText = Resources.Labels.AssetsPlannedTitle;

                    form.Chart.Series.Add(new Series());
                    form.Chart.Series[1].ChartType = SeriesChartType.Line;
                    form.Chart.Series[1].BorderWidth = 3;
                    form.Chart.Series[1].XValueType = ChartValueType.DateTime;
                    form.Chart.Series[1].YValueType = ChartValueType.Double;
                    form.Chart.Series[1].YValuesPerPoint = 1;
                    form.Chart.Series[1].ToolTip = String.Format(Consts.UI.DefaultChartToolTipFormat, Resources.Labels.AssetsTitle);
                    form.Chart.Series[1].Color = Color.Green;
                    form.Chart.Series[1].Points.DataBind(entries, BalanceByDateEntry.DateTitle, BalanceByDateEntry.AssetsTitle, String.Empty);
                    form.Chart.Series[1].Legend = legend.Name;
                    form.Chart.Series[1].LegendText = Resources.Labels.AssetsTitle;

                    form.Chart.Series.Add(new Series());
                    form.Chart.Series[2].ChartType = SeriesChartType.Line;
                    form.Chart.Series[2].BorderWidth = 3;
                    form.Chart.Series[2].XValueType = ChartValueType.Date;
                    form.Chart.Series[2].YValueType = ChartValueType.Double;
                    form.Chart.Series[2].YValuesPerPoint = 1;
                    form.Chart.Series[2].Points.DataBind(entriesForecast, BalanceByDateEntry.DateTitle, BalanceByDateEntry.DebtsTitle, String.Empty);
                    form.Chart.Series[2].ToolTip = String.Format(Consts.UI.DefaultChartToolTipFormat, Resources.Labels.DebtsPlannedTitle);
                    form.Chart.Series[2].Color = Color.Orange;
                    form.Chart.Series[2].Legend = legend.Name;
                    form.Chart.Series[2].LegendText = Resources.Labels.DebtsPlannedTitle;
                    
                    form.Chart.Series.Add(new Series());
                    form.Chart.Series[3].ChartType = SeriesChartType.Line;
                    form.Chart.Series[3].BorderWidth = 3;
                    form.Chart.Series[3].XValueType = ChartValueType.DateTime;
                    form.Chart.Series[3].YValueType = ChartValueType.Double;
                    form.Chart.Series[3].YValuesPerPoint = 1;
                    form.Chart.Series[3].Points.DataBind(entries, BalanceByDateEntry.DateTitle, BalanceByDateEntry.DebtsTitle, String.Empty);
                    form.Chart.Series[3].ToolTip = String.Format(Consts.UI.DefaultChartToolTipFormat, Resources.Labels.DebtsTitle);
                    form.Chart.Series[3].Color = Color.Red;
                    form.Chart.Series[3].Legend = legend.Name;
                    form.Chart.Series[3].LegendText = Resources.Labels.DebtsTitle;
                    
                    form.Chart.DataBind();

                    return form;

                }
            }
            catch (Exception e)
            {
                Log.Write(e);
            }
            return null;
        }

        #endregion

        #region Transactions by account report

        public static void TransactionsByAccountDefaults(Control parameters)
        {
            try
            {
                MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
                DateAccountsTypesTags transactionsByAccountPars = parameters as DateAccountsTypesTags;
                transactionsByAccountPars.Dock = DockStyle.Top;

                transactionsByAccountPars.dtpStartDate.Value = DateTime.Now.AddMonths(-1);
                transactionsByAccountPars.dtpEndDate.Value = DateTime.Now;

                transactionsByAccountPars.lbAccounts.DisplayMember = MoneyDataSet.IDs.SpecialColumns.FullTitleColumnName;
                transactionsByAccountPars.lbAccounts.ValueMember = keeper.DataSet.Accounts.IDColumn.ColumnName;
                //transactionsByAccountPars.lbAccounts.DataSource = keeper.Accounts;
                transactionsByAccountPars.lbAccounts.Items.Clear();
                foreach (var acc in keeper.Accounts)
                {
                    transactionsByAccountPars.lbAccounts.Items.Add(acc);
                }
                for (int i = 0; i < transactionsByAccountPars.lbAccounts.Items.Count; i++)
                {
                    transactionsByAccountPars.lbAccounts.SetSelected(i, true);
                }
                
                transactionsByAccountPars.lbTransactionTypes.DisplayMember = keeper.DataSet.TransactionTypes.TitleColumn.ColumnName;
                transactionsByAccountPars.lbTransactionTypes.ValueMember = keeper.DataSet.TransactionTypes.IDColumn.ColumnName;
                //transactionsByAccountPars.lbTransactionTypes.DataSource = keeper.GetTransactionTypes();
                transactionsByAccountPars.lbTransactionTypes.Items.Clear();
                foreach (var transType in keeper.GetTransactionTypes())
                {
                    transactionsByAccountPars.lbTransactionTypes.Items.Add(transType);
                }
                for (int i = 0; i < transactionsByAccountPars.lbTransactionTypes.Items.Count; i++)
                {
                    transactionsByAccountPars.lbTransactionTypes.SetSelected(i, true);
                }

                transactionsByAccountPars.lbTags.Items.Clear();
                transactionsByAccountPars.lbTags.Items.AddRange(keeper.Tags.ToArray());
                for (int i = 0; i < transactionsByAccountPars.lbTags.Items.Count; i++)
                {
                    transactionsByAccountPars.lbTags.SetSelected(i, true);
                }
            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(e: e);
            }
        }
        
        public static Form TransactionsByAccountReport(Control parameters)
        {
            const String columnDateTime = "datetime";
            const String columnType = "type";
            const String columnTitle = "title";
            const String columnAmount = "amount";
            const String columnAccount = "account";
            const String columnTags = "tags";

            try
            {
                DateAccountsTypesTags pars = parameters as DateAccountsTypesTags;

                DateTime StartDate = DateTime.Now;
                DateTime EndDate = DateTime.Now;
                IEnumerable<MoneyDataSet.AccountsRow> Accounts = null;
                IEnumerable<MoneyDataSet.TransactionTypesRow> TransactionTypes = null;
                IEnumerable<String> Tags = null;

                if (pars != null)
                {
                    MethodInvoker inv = delegate()
                    {
                        StartDate = pars.dtpStartDate.Value;
                        EndDate = pars.dtpEndDate.Value;
                        Accounts = pars.lbAccounts.SelectedItems.Cast<MoneyDataSet.AccountsRow>().ToArray();
                        TransactionTypes = pars.lbTransactionTypes.SelectedItems.Cast<MoneyDataSet.TransactionTypesRow>().ToArray();
                        Tags = pars.lbTags.SelectedItems.Cast<String>().ToArray();
                    };
                    pars.Invoke(inv); 
                    
                    String accounts = String.Join(Consts.UI.EnumerableSeparator, Accounts.Select(a => (a.Title)));
                    ReportGridForm form = new ReportGridForm();

                    form.Text = String.Format(Resources.Labels.TransactionsByAccountFormTitleFormat, accounts,
                        StartDate.ToShortDateString(), EndDate.ToShortDateString());

                    form.Grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                    form.Grid.Columns.Add(columnDateTime, Resources.Labels.DateTimeTitle);
                    form.Grid.Columns.Add(columnType, Resources.Labels.TypeTitle);
                    form.Grid.Columns.Add(columnTitle, Resources.Labels.Title);
                    form.Grid.Columns.Add(columnAmount, Resources.Labels.AmountTitle);
                    form.Grid.Columns.Add(columnAccount, Resources.Labels.AccountTitle);
                    form.Grid.Columns.Add(columnTags, Resources.Labels.TagsTitle);

                    form.Grid.Columns[columnDateTime].CellTemplate.Style.Format = Consts.UI.DateTimeFormat;
                    form.Grid.Columns[columnAmount].CellTemplate.Style.Format = Consts.UI.NumericFormat;
                    form.Grid.Columns[columnTags].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    form.Grid.Columns[columnDateTime].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    form.Grid.Columns[columnAmount].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                    form.Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    form.Grid.RowHeadersVisible = false;
                                        
                    form.Grid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                    IEnumerable<MoneyDataSet.TransactionsRow> transactions = MoneyDataKeeper.Instance.Transactions.Where(t =>
                        ((Accounts.Contains(t.AccountRow)) &&
                        (TransactionTypes.Contains(t.TransactionTypesRow)) &&
                        ((!t.GetTransactionTagsRows().Any()) ||
                        (t.GetTransactionTagsRows().Select(tt => (tt.TagRow.Title)).Intersect(Tags).Any()))
                        ));

                    foreach (MoneyDataSet.TransactionsRow transaction in transactions)
                    {
                        String accountInfo = String.Format(Consts.UI.CurrencyWithAccountFormat, transaction.AccountRow.CurrenciesRow.Title, transaction.AccountRow.FullTitle);
                        form.Grid.Rows.Add(transaction.TransactionTime, transaction.TransactionTypesRow.Title, transaction.Title,
                            transaction.Amount, accountInfo, String.Join(Consts.UI.EnumerableSeparator, transaction.GetTransactionTagsRows().Select(tt => (tt.TagRow.Title))));
                    }

                    form.Grid.Columns[columnDateTime].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    form.Grid.Columns[columnType].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    form.Grid.Columns[columnTitle].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    form.Grid.Columns[columnAmount].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    form.Grid.Columns[columnAccount].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    form.Grid.Sort(form.Grid.Columns[columnDateTime], ListSortDirection.Ascending);

                    form.Grid.Refresh();

                    return form;
                }
            }
            catch (Exception e)
            {
                Log.Write(e);
            }
            return null;
        }

        #endregion

        #region Month balance report

        public static void MonthBalanceDefaults(Control parameters)
        {
            try
            {
                MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
                MonthPickerControl monthBalancePars = parameters as MonthPickerControl;
                monthBalancePars.Dock = DockStyle.Top;
                
                monthBalancePars.cbMonth.Items.Clear();
                DateTime start = DateTime.Now;
                if (keeper.Transactions.Any())
                {
                    start = keeper.Transactions.Min(t => (t.TransactionTime));
                }
                DateTime end = DateTime.Now.AddMonths(Consts.UI.MonthBalanceForecastPeriod);
                DateTime iterator = new DateTime(start.Year, start.Month, 1);
                monthBalancePars.cbMonth.FormatString = Consts.UI.YearMonthFormat;
                monthBalancePars.cbMonth.Items.Clear();
                while (iterator < end)
                {
                    monthBalancePars.cbMonth.Items.Add(iterator);
                    iterator = iterator.AddMonths(1);
                }
                monthBalancePars.cbMonth.SelectedItem = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            }
            catch (Exception e)
            {
                ErrorHelper.ShowErrorBox(e: e);
            }
        }

        public static Form MonthBalanceReport(Control parameters)
        {
            const String columnDate = "date";
            const String columnType = "type";
            const String columnTypeIcon = "typeIcon";
            const String columnStatus = "status";
            const String columnTransaction = "transaction";
            const String columnAmountEarned = "amountearned";
            const String columnAmountSpent = "amountspent";
            const String columnPlannedAmountEarn = "plannedamountearn";
            const String columnPlannedAmountSpend = "plannedamountspend";
            const String columnAccount = "account";
            const String columnDifferenceIcon = "differenceicon";
            const String columnDifference = "difference";
            const String columnTags = "tags";

            try
            {
                MoneyDataKeeper keeper = MoneyDataKeeper.Instance;

                DateTime current = DateTime.Now;
                if (parameters != null)
                {
                    ComboBox cbMonth = (parameters as MonthPickerControl).cbMonth;
                    MethodInvoker inv = delegate() { current = (DateTime)cbMonth.SelectedItem; };
                    cbMonth.Invoke(inv);
                }
                else
                {
                    current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                }
                ReportGridForm form = new ReportGridForm();
                form.Text = String.Format(Resources.Labels.MonthBalanceFormTitleFormat, current);

                form.Grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                form.Grid.Columns.Add(columnDate, Resources.Labels.DateTitle);
                form.Grid.Columns.Add(columnStatus, Resources.Labels.StatusTitle);

                DataGridViewImageColumn columnIcon = new DataGridViewImageColumn();
                columnIcon.Name = columnDifferenceIcon;
                columnIcon.HeaderText = Resources.Labels.DifferenceIconTitle;

                form.Grid.Columns.Add(columnIcon);

                form.Grid.Columns.Add(columnType, Resources.Labels.TypeTitle);
                DataGridViewImageColumn columnIconType = new DataGridViewImageColumn();
                columnIconType.Name = columnTypeIcon;
                columnIconType.HeaderText = Resources.Labels.TypeIconTitle;

                form.Grid.Columns.Add(columnIconType);

                form.Grid.Columns.Add(columnTransaction, Resources.Labels.TransactionTitle);
                form.Grid.Columns.Add(columnAmountEarned, Resources.Labels.EarnedTitle);
                form.Grid.Columns.Add(columnAmountSpent, Resources.Labels.SpentTitle);
                form.Grid.Columns.Add(columnPlannedAmountEarn, Resources.Labels.EarnTitle);
                form.Grid.Columns.Add(columnPlannedAmountSpend, Resources.Labels.SpendTitle);

                form.Grid.Columns.Add(columnDifference, Resources.Labels.DifferenceTitle);
                form.Grid.Columns.Add(columnAccount, Resources.Labels.AccountTitle);
                form.Grid.Columns.Add(columnTags, Resources.Labels.TagsTitle);

                form.Grid.Columns[columnDate].CellTemplate.Style.Format = Consts.UI.DateFormat;
                form.Grid.Columns[columnTags].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                form.Grid.Columns[columnType].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                form.Grid.Columns[columnStatus].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                form.Grid.Columns[columnDate].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                form.Grid.Columns[columnAmountEarned].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                form.Grid.Columns[columnPlannedAmountEarn].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                form.Grid.Columns[columnAmountSpent].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                form.Grid.Columns[columnPlannedAmountSpend].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                form.Grid.Columns[columnDifference].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                form.Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                form.Grid.RowHeadersVisible = false;

                form.Grid.AllowUserToOrderColumns = false;

                form.Grid.Columns[columnDate].DividerWidth = 1;
                form.Grid.Columns[columnDifferenceIcon].DividerWidth = 1;
                form.Grid.Columns[columnTransaction].DividerWidth = 1;
                form.Grid.Columns[columnAmountSpent].DividerWidth = 1;
                form.Grid.Columns[columnPlannedAmountSpend].DividerWidth = 1;
                form.Grid.Columns[columnAccount].DividerWidth = 1;
                form.Grid.Columns[columnDifference].DividerWidth = 1;

                form.Grid.Columns[columnDate].SortMode = DataGridViewColumnSortMode.NotSortable;
                form.Grid.Columns[columnStatus].SortMode = DataGridViewColumnSortMode.NotSortable;
                form.Grid.Columns[columnType].SortMode = DataGridViewColumnSortMode.NotSortable;
                form.Grid.Columns[columnTransaction].SortMode = DataGridViewColumnSortMode.NotSortable;
                form.Grid.Columns[columnAmountEarned].SortMode = DataGridViewColumnSortMode.NotSortable;
                form.Grid.Columns[columnAmountSpent].SortMode = DataGridViewColumnSortMode.NotSortable;
                form.Grid.Columns[columnPlannedAmountSpend].SortMode = DataGridViewColumnSortMode.NotSortable;
                form.Grid.Columns[columnPlannedAmountEarn].SortMode = DataGridViewColumnSortMode.NotSortable;
                form.Grid.Columns[columnDifferenceIcon].SortMode = DataGridViewColumnSortMode.NotSortable;
                form.Grid.Columns[columnAccount].SortMode = DataGridViewColumnSortMode.NotSortable;
                form.Grid.Columns[columnDifference].SortMode = DataGridViewColumnSortMode.NotSortable;
                form.Grid.Columns[columnTags].SortMode = DataGridViewColumnSortMode.NotSortable;

                DateTime end = current.AddMonths(1);

                // getting default currency
                CultureInfo defaultCurrencyCulture = keeper.GetDefaultCurrency().CurrencyCultureInfo;

                double monthTotalEarned = 0;
                double monthTotalSpent = 0;
                double monthTotalPlannedEarn = 0;
                double monthTotalPlannedSpend = 0;
                double monthTotalDifference = 0;

                int lastRow = -1;

                while (current < end)
                {
                    lastRow = -1;

                    double dayTotalEarned = 0;
                    double dayTotalSpent = 0;
                    double dayTotalPlannedEarn = 0;
                    double dayTotalPlannedSpend = 0;
                    double dayTotalDifference = 0;

                    DateTime nextDay = current.AddDays(1);

                    // getting active plans for this day
                    foreach (MoneyDataSet.PlannedTransactionsRow plan in
                        keeper.GetActivePlannedTransactions(current, current, false).Select(s => (s.PlannedTransaction)))
                    {
                        Image differenceIcon = Properties.Resources.bullet_black;
                        String status = String.Empty;
                        String difference = String.Empty;
                        String plannedAmountEarn = String.Empty;
                        String plannedAmountSpend = String.Empty;
                        String actualAmountEarned = String.Empty;
                        String actualAmountSpent = String.Empty;


                        IEnumerable<MoneyDataSet.TransactionsRow> implementations = keeper.GetPlannedTransactionImplementations(plan, current);

                        double implementationEarned = 0;
                        double implementationSpent = 0;

                        foreach (MoneyDataSet.TransactionsRow transaction in implementations)
                        {
                            if (transaction.TransactionTypesRow.IsIncome)
                            {
                                implementationEarned += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                            }
                            else
                            {
                                implementationSpent += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                            }
                        }

                        if (implementationEarned != 0)
                        {
                            actualAmountEarned = implementationEarned.ToString(Consts.UI.CurrencyFormat, defaultCurrencyCulture);
                        }
                        if (implementationSpent != 0)
                        {
                            actualAmountSpent = implementationSpent.ToString(Consts.UI.CurrencyFormat, defaultCurrencyCulture);
                        }

                        double diff = 0;

                        if (plan.TransactionTypeRow.IsIncome)
                        {
                            dayTotalPlannedEarn += plan.Amount * plan.CurrenciesRow.ExchangeRate;

                            diff += Math.Abs(implementationEarned - (plan.Amount * plan.CurrenciesRow.ExchangeRate));

                            if (plan.Amount != 0)
                            {
                                plannedAmountEarn = plan.Amount.ToString(Consts.UI.CurrencyFormat,
                                    CultureInfo.CreateSpecificCulture(plan.CurrenciesRow.CurrencyCulture));
                            }
                        }
                        else
                        {
                            dayTotalPlannedSpend += plan.Amount * plan.CurrenciesRow.ExchangeRate;

                            diff += Math.Abs(implementationSpent - (plan.Amount * plan.CurrenciesRow.ExchangeRate));

                            if (plan.Amount != 0)
                            {
                                plannedAmountSpend = plan.Amount.ToString(Consts.UI.CurrencyFormat,
                                    plan.CurrenciesRow.CurrencyCultureInfo);
                            }
                        }

                        if (implementations.Where(t => (t.TransactionTime.Date.Equals(current))).Any())
                        {
                            dayTotalDifference += diff;
                            if (diff != 0)
                            {
                                difference = diff.ToString(Consts.UI.CurrencyFormat, defaultCurrencyCulture);
                            } if (diff > Math.Abs(plan.Amount * plan.CurrenciesRow.ExchangeRate * Consts.Reports.DifferenceErrorThreshold))
                            {
                                differenceIcon = Properties.Resources.exclamation;
                                status = Resources.Labels.SignificantDifferenceTitle;
                            }
                            else if (diff > Math.Abs(plan.Amount * plan.CurrenciesRow.ExchangeRate * Consts.Reports.DifferenceWarningThreshold))
                            {
                                differenceIcon = Properties.Resources.error;
                                status = Resources.Labels.DeviationFromPlanTitle;
                            }
                            else
                            {
                                differenceIcon = Properties.Resources.tick;
                                status = Resources.Labels.ImplementedTitle;
                            }
                        }
                        else if (implementations.Any())
                        {
                            dayTotalDifference += diff;
                            if (diff != 0)
                            {
                                difference = diff.ToString(Consts.UI.CurrencyFormat, defaultCurrencyCulture);
                            }

                            if (diff > Math.Abs(plan.Amount * plan.CurrenciesRow.ExchangeRate * Consts.Reports.DifferenceErrorThreshold))
                            {
                                differenceIcon = Properties.Resources.exclamation;
                                status = Resources.Labels.SignificantDifferenceTitle;
                            }
                            if (diff > Math.Abs(plan.Amount * plan.CurrenciesRow.ExchangeRate * Consts.Reports.DifferenceWarningThreshold))
                            {
                                differenceIcon = Properties.Resources.error;
                                if (plan.IsAggregated)
                                {
                                    status = Resources.Labels.DeviationFromPlanTitle;
                                }
                                else
                                {
                                    status = Resources.Labels.DeviationAnotherDayTitle;
                                }
                            }
                            else if (plan.IsAggregated)
                            {
                                status = Resources.Labels.ImplementedTitle;
                                differenceIcon = Properties.Resources.tick;
                            }
                            else
                            {
                                status = Resources.Labels.ImplementedOnAnotherDayTitle;
                                differenceIcon = Properties.Resources.date_go;
                            }
                        }
                        else
                        {
                            if (current < DateTime.Now)
                            {
                                status = Resources.Labels.NotImplementedTitle;
                                dayTotalDifference += Math.Abs(plan.Amount) * plan.CurrenciesRow.ExchangeRate;

                                difference = Math.Abs(plan.Amount).ToString(Consts.UI.CurrencyFormat,
                                    plan.CurrenciesRow.CurrencyCultureInfo);

                                differenceIcon = Properties.Resources.exclamation;
                            }
                            else
                            {
                                status = Resources.Labels.NotImplementedYetTitle;
                                differenceIcon = Properties.Resources.flag_blue;
                            }
                        }

                        int i = form.Grid.Rows.Add(current, status, differenceIcon, plan.TransactionTypeRow.Title, Properties.Resources.date, plan.Title,
                            actualAmountEarned, actualAmountSpent, plannedAmountEarn, plannedAmountSpend,
                            difference, plan.AccountTypeRow.Title, String.Join(Consts.UI.EnumerableSeparator,
                            plan.GetPlannedTransactionTagsRows().Select(tt => (tt.TagRow.Title))));
                        lastRow = i;

                        if (implementations.Any())
                        {
                            // this plan is implemented
                            if (diff > Math.Abs(plan.Amount * plan.CurrenciesRow.ExchangeRate * Consts.Reports.DifferenceErrorThreshold))
                            {
                                form.Grid.Rows[i].DefaultCellStyle.BackColor = Color.Coral;
                            }
                            else if (diff > Math.Abs(plan.Amount * plan.CurrenciesRow.ExchangeRate * Consts.Reports.DifferenceWarningThreshold))
                            {
                                form.Grid.Rows[i].DefaultCellStyle.BackColor = Color.Moccasin;
                            }
                            else
                            {
                                form.Grid.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                            }
                        }
                        else if (current < DateTime.Now)
                        {
                            form.Grid.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                        }
                        else
                        {
                            form.Grid.Rows[i].DefaultCellStyle.BackColor = Color.PowderBlue;
                        }
                    }

                    // getting transactions for this day
                    foreach (MoneyDataSet.TransactionsRow transaction in keeper.Transactions.Where(t =>
                        (t.TransactionTime >= current) && (t.TransactionTime < nextDay)).OrderBy(o => (o.TransactionTime)))
                    {
                        String status = String.Empty;
                        String planAmountSpend = String.Empty;
                        String planAmountEarn = String.Empty;
                        String difference = String.Empty;
                        bool isPlanned = false;

                        Image differenceIcon = Properties.Resources.bullet_black;

                        if (transaction.IsPlannedTransactionIDNull())
                        {
                            differenceIcon = Properties.Resources.error;
                            status = Resources.Labels.NotPlannedTitle;
                            isPlanned = false;

                            if (((!transaction.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.TransferIn)) &&
                                (!transaction.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.TransferOut))) ||
                                (transaction.IsPairReferenceIDNull()) || (transaction.PairReferenceID == 0))
                            {
                                dayTotalDifference += Math.Abs(transaction.Amount) * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                                difference = Math.Abs(transaction.Amount).ToString(Consts.UI.CurrencyFormat,
                                    transaction.AccountRow.CurrenciesRow.CurrencyCultureInfo);
                            }
                        }
                        else
                        {
                            status = Resources.Labels.ImplementsTitle;
                            differenceIcon = Properties.Resources.tick;
                            isPlanned = true;
                        }

                        String amountSpent = String.Empty;
                        String amountEarned = String.Empty;

                        if (transaction.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.Correction))
                        {
                            if (transaction.Amount > 0)
                            {
                                dayTotalSpent += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                                amountSpent = transaction.Amount.ToString(Consts.UI.CurrencyFormat,
                                    transaction.AccountRow.CurrenciesRow.CurrencyCultureInfo);
                            }
                            else
                            {
                                dayTotalEarned += Math.Abs(transaction.Amount) * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                                amountEarned = Math.Abs(transaction.Amount).ToString(Consts.UI.CurrencyFormat,
                                    transaction.AccountRow.CurrenciesRow.CurrencyCultureInfo);
                            }
                        }
                        else if (transaction.TransactionTypesRow.IsIncome)
                        {
                            if (((!transaction.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.TransferIn)) &&
                               (!transaction.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.TransferOut))) ||
                               (transaction.IsPairReferenceIDNull()) || (transaction.PairReferenceID == 0))
                            {
                                dayTotalEarned += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                            }
                            amountEarned = transaction.Amount.ToString(Consts.UI.CurrencyFormat,
                                transaction.AccountRow.CurrenciesRow.CurrencyCultureInfo);
                        }
                        else
                        {
                            if (((!transaction.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.TransferIn)) &&
                               (!transaction.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.TransferOut))) ||
                               (transaction.IsPairReferenceIDNull()) || (transaction.PairReferenceID == 0))
                            {
                                dayTotalSpent += transaction.Amount * transaction.AccountRow.CurrenciesRow.ExchangeRate;
                            }
                            amountSpent = transaction.Amount.ToString(Consts.UI.CurrencyFormat,
                                transaction.AccountRow.CurrenciesRow.CurrencyCultureInfo);
                        }

                        Image typeIcon = null;

                        if (transaction.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.Correction))
                        {
                            typeIcon = Properties.Resources.error;
                        } 
                        else if (transaction.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.TransferIn))
                        {
                            typeIcon = Properties.Resources.arrow_in;
                        }
                        else if (transaction.TypeID.Equals(MoneyDataSet.IDs.TransactionTypes.TransferOut))
                        {
                            typeIcon = Properties.Resources.arrow_out;
                        }
                        else
                        {
                            typeIcon = Properties.Resources.application_form;
                        }

                        int i = form.Grid.Rows.Add(current, status, differenceIcon, transaction.TransactionTypesRow.Title, typeIcon, 
                            transaction.Title, amountEarned, amountSpent, planAmountEarn, planAmountSpend,
                            difference, transaction.AccountRow.FullTitle,
                            String.Join(Consts.UI.EnumerableSeparator, transaction.GetTransactionTagsRows().Select(tt => (tt.TagRow.Title))));

                        lastRow = i;
                        if (isPlanned)
                        {
                            form.Grid.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            form.Grid.Rows[i].DefaultCellStyle.BackColor = Color.Wheat;
                        }
                    }

                    if (lastRow >= 0)
                    {
                        monthTotalDifference += dayTotalDifference;
                        monthTotalEarned += dayTotalEarned;
                        monthTotalPlannedEarn += dayTotalPlannedEarn;
                        monthTotalPlannedSpend += dayTotalPlannedSpend;
                        monthTotalSpent += dayTotalSpent;

                        String DTE = String.Empty;
                        String DTS = String.Empty;
                        String DTPE = String.Empty;
                        String DTPS = String.Empty;
                        String DTD = String.Empty;

                        if ((dayTotalEarned != 0) || (dayTotalSpent != 0))
                        {
                            DTE = dayTotalEarned.ToString(Consts.UI.CurrencyFormat, defaultCurrencyCulture);
                            DTS = dayTotalSpent.ToString(Consts.UI.CurrencyFormat, defaultCurrencyCulture);
                        }

                        if ((dayTotalPlannedEarn != 0) || (dayTotalPlannedSpend != 0))
                        {
                            DTPE = dayTotalPlannedEarn.ToString(Consts.UI.CurrencyFormat, defaultCurrencyCulture);
                            DTPS = dayTotalPlannedSpend.ToString(Consts.UI.CurrencyFormat, defaultCurrencyCulture);
                        }

                        if (dayTotalDifference != 0)
                        {
                            DTD = dayTotalDifference.ToString(Consts.UI.CurrencyFormat, defaultCurrencyCulture);
                        }

                        Image dayIcon;
                        if ((dayTotalDifference > (dayTotalEarned * Consts.Reports.DifferenceErrorThreshold)) &&
                            (dayTotalDifference > (dayTotalSpent * Consts.Reports.DifferenceErrorThreshold)))
                        {
                            dayIcon = Properties.Resources.exclamation;
                        }
                        else if ((dayTotalDifference > (dayTotalEarned * Consts.Reports.DifferenceErrorThreshold)) &&
                                (dayTotalDifference > (dayTotalSpent * Consts.Reports.DifferenceErrorThreshold)))
                        {
                            dayIcon = Properties.Resources.error;
                        }
                        else
                        {
                            dayIcon = Properties.Resources.tick;
                        }

                        lastRow = form.Grid.Rows.Add(current, String.Empty, dayIcon, String.Empty, Properties.Resources.calculator,
                            Resources.Labels.DayTotalsTitle, DTE, DTS, DTPE, DTPS, DTD, String.Empty, String.Empty);

                        form.Grid.Rows[lastRow].DefaultCellStyle.Font = new Font(form.Grid.DefaultCellStyle.Font, FontStyle.Bold);
                        form.Grid.Rows[lastRow].DividerHeight = 3;
                    }
                    current = nextDay;
                }
                if (lastRow >= 0)
                {
                    form.Grid.Rows[lastRow].DividerHeight = 6;
                }

                Image monthIcon;
                if ((monthTotalDifference > (monthTotalEarned * Consts.Reports.DifferenceErrorThreshold)) &&
                    (monthTotalDifference > (monthTotalSpent * Consts.Reports.DifferenceErrorThreshold)))
                {
                    monthIcon = Properties.Resources.exclamation;
                }
                else if ((monthTotalDifference > (monthTotalEarned * Consts.Reports.DifferenceErrorThreshold)) &&
                        (monthTotalDifference > (monthTotalSpent * Consts.Reports.DifferenceErrorThreshold)))
                {
                    monthIcon = Properties.Resources.error;
                }
                else
                {
                    monthIcon = new Bitmap(1, 1);
                } 
                int j = form.Grid.Rows.Add(null, String.Empty, monthIcon, String.Empty, Properties.Resources.calculator, Resources.Labels.MonthTotalsTitle, 
                    monthTotalEarned.ToString(Consts.UI.CurrencyFormat, defaultCurrencyCulture),
                    monthTotalSpent.ToString(Consts.UI.CurrencyFormat, defaultCurrencyCulture),
                    monthTotalPlannedEarn.ToString(Consts.UI.CurrencyFormat, defaultCurrencyCulture),
                    monthTotalPlannedSpend.ToString(Consts.UI.CurrencyFormat, defaultCurrencyCulture),
                    monthTotalDifference.ToString(Consts.UI.CurrencyFormat, defaultCurrencyCulture),
                    String.Empty, String.Empty);

                form.Grid.Rows[j].DefaultCellStyle.BackColor = Color.LightGray;
                form.Grid.Rows[j].DefaultCellStyle.Font = new Font(form.Grid.DefaultCellStyle.Font.FontFamily, form.Grid.DefaultCellStyle.Font.Size + 2, FontStyle.Bold);

                form.Grid.Columns[columnDate].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                form.Grid.Columns[columnStatus].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                form.Grid.Columns[columnType].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                form.Grid.Columns[columnTypeIcon].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                form.Grid.Columns[columnTransaction].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                form.Grid.Columns[columnAmountSpent].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                form.Grid.Columns[columnAmountEarned].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                form.Grid.Columns[columnPlannedAmountSpend].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                form.Grid.Columns[columnPlannedAmountEarn].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                form.Grid.Columns[columnAccount].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                form.Grid.Columns[columnDifferenceIcon].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                form.Grid.Columns[columnDifference].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                form.Grid.Refresh();
                form.WindowState = FormWindowState.Maximized;

                return form;
            }
            catch (Exception e)
            {
                Log.Write(e);
            }
            return null;
        }

        #endregion

    }
}
