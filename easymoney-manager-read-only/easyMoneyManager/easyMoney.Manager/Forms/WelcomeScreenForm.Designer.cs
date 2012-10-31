namespace easyMoney.Manager.Forms
{
    partial class WelcomeScreenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TableLayoutPanel tlpWelcome;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeScreenForm));
            System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
            System.Windows.Forms.GroupBox gbAccounts;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.Label lblAssetsTitle;
            System.Windows.Forms.Label lblDebtsTitle;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.GroupBox gbOverview;
            System.Windows.Forms.TableLayoutPanel tlpTransactions;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label lblPlansTitle;
            System.Windows.Forms.Label lblStatisticsTitle;
            this.tscContainer = new System.Windows.Forms.ToolStripContainer();
            this.msMenuMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTransactionList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewIncome = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlans = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlanList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlanPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlanIncome = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAccountList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewDebitAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewCreditAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReports = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReportList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMonthBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowIntroduction = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsstbSearch = new easyMoney.Controls.ToolStripSpringTextBox();
            this.tsmiStartSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpAccounts = new System.Windows.Forms.TableLayoutPanel();
            this.chartDebts = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblAssets = new System.Windows.Forms.Label();
            this.lblDebts = new System.Windows.Forms.Label();
            this.chartAssets = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblStatsYearSpent = new System.Windows.Forms.Label();
            this.lblStatsYearEarned = new System.Windows.Forms.Label();
            this.lblStatsYear = new System.Windows.Forms.Label();
            this.lblStatsMonthSpent = new System.Windows.Forms.Label();
            this.lblStatsMonthEarned = new System.Windows.Forms.Label();
            this.lblStatsDay = new System.Windows.Forms.Label();
            this.lblStatsDayEarned = new System.Windows.Forms.Label();
            this.btnNextYear = new System.Windows.Forms.Button();
            this.btnPrevYear = new System.Windows.Forms.Button();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.btnPrevMonth = new System.Windows.Forms.Button();
            this.btnNextDay = new System.Windows.Forms.Button();
            this.btnPrevDay = new System.Windows.Forms.Button();
            this.dgvPlans = new System.Windows.Forms.DataGridView();
            this.dgvcPlansDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcPlansTransactionType = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvcPlansAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcPlansTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStatsDaySpent = new System.Windows.Forms.Label();
            this.lblStatsMonth = new System.Windows.Forms.Label();
            this.bgwUpdateCheck = new System.ComponentModel.BackgroundWorker();
            this.fdOpenData = new System.Windows.Forms.OpenFileDialog();
            this.fdSaveData = new System.Windows.Forms.SaveFileDialog();
            tlpWelcome = new System.Windows.Forms.TableLayoutPanel();
            toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            gbAccounts = new System.Windows.Forms.GroupBox();
            lblAssetsTitle = new System.Windows.Forms.Label();
            lblDebtsTitle = new System.Windows.Forms.Label();
            gbOverview = new System.Windows.Forms.GroupBox();
            tlpTransactions = new System.Windows.Forms.TableLayoutPanel();
            lblPlansTitle = new System.Windows.Forms.Label();
            lblStatisticsTitle = new System.Windows.Forms.Label();
            tlpWelcome.SuspendLayout();
            this.tscContainer.ContentPanel.SuspendLayout();
            this.tscContainer.TopToolStripPanel.SuspendLayout();
            this.tscContainer.SuspendLayout();
            this.msMenuMain.SuspendLayout();
            gbAccounts.SuspendLayout();
            this.tlpAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDebts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAssets)).BeginInit();
            gbOverview.SuspendLayout();
            tlpTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpWelcome
            // 
            resources.ApplyResources(tlpWelcome, "tlpWelcome");
            tlpWelcome.Controls.Add(gbAccounts, 0, 0);
            tlpWelcome.Controls.Add(gbOverview, 1, 0);
            tlpWelcome.Name = "tlpWelcome";
            // 
            // tscContainer
            // 
            resources.ApplyResources(this.tscContainer, "tscContainer");
            // 
            // tscContainer.BottomToolStripPanel
            // 
            resources.ApplyResources(this.tscContainer.BottomToolStripPanel, "tscContainer.BottomToolStripPanel");
            this.tscContainer.BottomToolStripPanelVisible = false;
            // 
            // tscContainer.ContentPanel
            // 
            resources.ApplyResources(this.tscContainer.ContentPanel, "tscContainer.ContentPanel");
            this.tscContainer.ContentPanel.Controls.Add(tlpWelcome);
            // 
            // tscContainer.LeftToolStripPanel
            // 
            resources.ApplyResources(this.tscContainer.LeftToolStripPanel, "tscContainer.LeftToolStripPanel");
            this.tscContainer.LeftToolStripPanelVisible = false;
            this.tscContainer.Name = "tscContainer";
            // 
            // tscContainer.RightToolStripPanel
            // 
            resources.ApplyResources(this.tscContainer.RightToolStripPanel, "tscContainer.RightToolStripPanel");
            // 
            // tscContainer.TopToolStripPanel
            // 
            resources.ApplyResources(this.tscContainer.TopToolStripPanel, "tscContainer.TopToolStripPanel");
            this.tscContainer.TopToolStripPanel.Controls.Add(this.msMenuMain);
            // 
            // msMenuMain
            // 
            resources.ApplyResources(this.msMenuMain, "msMenuMain");
            this.msMenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiTransactions,
            this.tsmiPlans,
            this.tsmiAccounts,
            this.tsmiReports,
            this.tsmiHelp,
            this.tsstbSearch,
            this.tsmiStartSearch});
            this.msMenuMain.Name = "msMenuMain";
            // 
            // tsmiFile
            // 
            resources.ApplyResources(this.tsmiFile, "tsmiFile");
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.tsmiSave,
            this.tsmiSaveAs,
            toolStripSeparator8,
            this.tsmiImport,
            toolStripSeparator1,
            this.tsmiSearch,
            this.tsmiSettings,
            toolStripSeparator2,
            this.tsmiExit});
            this.tsmiFile.Image = global::easyMoney.Manager.Properties.Resources.page;
            this.tsmiFile.Name = "tsmiFile";
            // 
            // tsmiOpen
            // 
            resources.ApplyResources(this.tsmiOpen, "tsmiOpen");
            this.tsmiOpen.Image = global::easyMoney.Manager.Properties.Resources.folder_table;
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiSave
            // 
            resources.ApplyResources(this.tsmiSave, "tsmiSave");
            this.tsmiSave.Image = global::easyMoney.Manager.Properties.Resources.disk;
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiSaveAs
            // 
            resources.ApplyResources(this.tsmiSaveAs, "tsmiSaveAs");
            this.tsmiSaveAs.Name = "tsmiSaveAs";
            this.tsmiSaveAs.Click += new System.EventHandler(this.tsmiSaveAs_Click);
            // 
            // toolStripSeparator8
            // 
            resources.ApplyResources(toolStripSeparator8, "toolStripSeparator8");
            toolStripSeparator8.Name = "toolStripSeparator8";
            // 
            // tsmiImport
            // 
            resources.ApplyResources(this.tsmiImport, "tsmiImport");
            this.tsmiImport.Image = global::easyMoney.Manager.Properties.Resources.page_copy;
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Click += new System.EventHandler(this.tsmiImport_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // tsmiSearch
            // 
            resources.ApplyResources(this.tsmiSearch, "tsmiSearch");
            this.tsmiSearch.Image = global::easyMoney.Manager.Properties.Resources.magnifier;
            this.tsmiSearch.Name = "tsmiSearch";
            this.tsmiSearch.Click += new System.EventHandler(this.tsmiSearch_Click);
            // 
            // tsmiSettings
            // 
            resources.ApplyResources(this.tsmiSettings, "tsmiSettings");
            this.tsmiSettings.Image = global::easyMoney.Manager.Properties.Resources.cog;
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // tsmiExit
            // 
            resources.ApplyResources(this.tsmiExit, "tsmiExit");
            this.tsmiExit.Image = global::easyMoney.Manager.Properties.Resources.cross;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiTransactions
            // 
            resources.ApplyResources(this.tsmiTransactions, "tsmiTransactions");
            this.tsmiTransactions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTransactionList,
            toolStripSeparator3,
            this.tsmiNewPayment,
            this.tsmiNewIncome});
            this.tsmiTransactions.Image = global::easyMoney.Manager.Properties.Resources.table_multiple;
            this.tsmiTransactions.Name = "tsmiTransactions";
            // 
            // tsmiTransactionList
            // 
            resources.ApplyResources(this.tsmiTransactionList, "tsmiTransactionList");
            this.tsmiTransactionList.Image = global::easyMoney.Manager.Properties.Resources.application_form;
            this.tsmiTransactionList.Name = "tsmiTransactionList";
            this.tsmiTransactionList.Click += new System.EventHandler(this.tsmiTransactionList_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // tsmiNewPayment
            // 
            resources.ApplyResources(this.tsmiNewPayment, "tsmiNewPayment");
            this.tsmiNewPayment.Image = global::easyMoney.Manager.Properties.Resources.basket;
            this.tsmiNewPayment.Name = "tsmiNewPayment";
            // 
            // tsmiNewIncome
            // 
            resources.ApplyResources(this.tsmiNewIncome, "tsmiNewIncome");
            this.tsmiNewIncome.Image = global::easyMoney.Manager.Properties.Resources.coins;
            this.tsmiNewIncome.Name = "tsmiNewIncome";
            // 
            // tsmiPlans
            // 
            resources.ApplyResources(this.tsmiPlans, "tsmiPlans");
            this.tsmiPlans.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPlanList,
            toolStripSeparator4,
            this.tsmiPlanPayment,
            this.tsmiPlanIncome});
            this.tsmiPlans.Image = global::easyMoney.Manager.Properties.Resources.date;
            this.tsmiPlans.Name = "tsmiPlans";
            // 
            // tsmiPlanList
            // 
            resources.ApplyResources(this.tsmiPlanList, "tsmiPlanList");
            this.tsmiPlanList.Image = global::easyMoney.Manager.Properties.Resources.note;
            this.tsmiPlanList.Name = "tsmiPlanList";
            this.tsmiPlanList.Click += new System.EventHandler(this.tsmiPlanList_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(toolStripSeparator4, "toolStripSeparator4");
            toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // tsmiPlanPayment
            // 
            resources.ApplyResources(this.tsmiPlanPayment, "tsmiPlanPayment");
            this.tsmiPlanPayment.Image = global::easyMoney.Manager.Properties.Resources.basket_add;
            this.tsmiPlanPayment.Name = "tsmiPlanPayment";
            // 
            // tsmiPlanIncome
            // 
            resources.ApplyResources(this.tsmiPlanIncome, "tsmiPlanIncome");
            this.tsmiPlanIncome.Image = global::easyMoney.Manager.Properties.Resources.coins_add;
            this.tsmiPlanIncome.Name = "tsmiPlanIncome";
            // 
            // tsmiAccounts
            // 
            resources.ApplyResources(this.tsmiAccounts, "tsmiAccounts");
            this.tsmiAccounts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAccountList,
            toolStripSeparator5,
            this.tsmiNewDebitAccount,
            this.tsmiNewCreditAccount});
            this.tsmiAccounts.Image = global::easyMoney.Manager.Properties.Resources.book;
            this.tsmiAccounts.Name = "tsmiAccounts";
            // 
            // tsmiAccountList
            // 
            resources.ApplyResources(this.tsmiAccountList, "tsmiAccountList");
            this.tsmiAccountList.Image = global::easyMoney.Manager.Properties.Resources.book_open;
            this.tsmiAccountList.Name = "tsmiAccountList";
            this.tsmiAccountList.Click += new System.EventHandler(this.tsmiAccountList_Click);
            // 
            // toolStripSeparator5
            // 
            resources.ApplyResources(toolStripSeparator5, "toolStripSeparator5");
            toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // tsmiNewDebitAccount
            // 
            resources.ApplyResources(this.tsmiNewDebitAccount, "tsmiNewDebitAccount");
            this.tsmiNewDebitAccount.Image = global::easyMoney.Manager.Properties.Resources.money;
            this.tsmiNewDebitAccount.Name = "tsmiNewDebitAccount";
            this.tsmiNewDebitAccount.Click += new System.EventHandler(this.tsmiNewAccount_Click);
            // 
            // tsmiNewCreditAccount
            // 
            resources.ApplyResources(this.tsmiNewCreditAccount, "tsmiNewCreditAccount");
            this.tsmiNewCreditAccount.Image = global::easyMoney.Manager.Properties.Resources.creditcards;
            this.tsmiNewCreditAccount.Name = "tsmiNewCreditAccount";
            this.tsmiNewCreditAccount.Click += new System.EventHandler(this.tsmiNewAccount_Click);
            // 
            // tsmiReports
            // 
            resources.ApplyResources(this.tsmiReports, "tsmiReports");
            this.tsmiReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReportList,
            toolStripSeparator6,
            this.tsmiMonthBalance});
            this.tsmiReports.Image = global::easyMoney.Manager.Properties.Resources.chart_bar;
            this.tsmiReports.Name = "tsmiReports";
            // 
            // tsmiReportList
            // 
            resources.ApplyResources(this.tsmiReportList, "tsmiReportList");
            this.tsmiReportList.Image = global::easyMoney.Manager.Properties.Resources.report;
            this.tsmiReportList.Name = "tsmiReportList";
            this.tsmiReportList.Click += new System.EventHandler(this.tsmiReportList_Click);
            // 
            // toolStripSeparator6
            // 
            resources.ApplyResources(toolStripSeparator6, "toolStripSeparator6");
            toolStripSeparator6.Name = "toolStripSeparator6";
            // 
            // tsmiMonthBalance
            // 
            resources.ApplyResources(this.tsmiMonthBalance, "tsmiMonthBalance");
            this.tsmiMonthBalance.Image = global::easyMoney.Manager.Properties.Resources.calendar;
            this.tsmiMonthBalance.Name = "tsmiMonthBalance";
            this.tsmiMonthBalance.Click += new System.EventHandler(this.tsmiMonthBalance_Click);
            // 
            // tsmiHelp
            // 
            resources.ApplyResources(this.tsmiHelp, "tsmiHelp");
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowIntroduction,
            toolStripSeparator7,
            this.tsmiAbout});
            this.tsmiHelp.Image = global::easyMoney.Manager.Properties.Resources.help;
            this.tsmiHelp.Name = "tsmiHelp";
            // 
            // tsmiShowIntroduction
            // 
            resources.ApplyResources(this.tsmiShowIntroduction, "tsmiShowIntroduction");
            this.tsmiShowIntroduction.Image = global::easyMoney.Manager.Properties.Resources.information;
            this.tsmiShowIntroduction.Name = "tsmiShowIntroduction";
            this.tsmiShowIntroduction.Click += new System.EventHandler(this.tsmiShowIntroduction_Click);
            // 
            // toolStripSeparator7
            // 
            resources.ApplyResources(toolStripSeparator7, "toolStripSeparator7");
            toolStripSeparator7.Name = "toolStripSeparator7";
            // 
            // tsmiAbout
            // 
            resources.ApplyResources(this.tsmiAbout, "tsmiAbout");
            this.tsmiAbout.Image = global::easyMoney.Manager.Properties.Resources.lightbulb;
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // tsstbSearch
            // 
            resources.ApplyResources(this.tsstbSearch, "tsstbSearch");
            this.tsstbSearch.Name = "tsstbSearch";
            // 
            // tsmiStartSearch
            // 
            resources.ApplyResources(this.tsmiStartSearch, "tsmiStartSearch");
            this.tsmiStartSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmiStartSearch.Image = global::easyMoney.Manager.Properties.Resources.magnifier;
            this.tsmiStartSearch.Name = "tsmiStartSearch";
            this.tsmiStartSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // gbAccounts
            // 
            resources.ApplyResources(gbAccounts, "gbAccounts");
            gbAccounts.Controls.Add(this.tlpAccounts);
            gbAccounts.Name = "gbAccounts";
            gbAccounts.TabStop = false;
            // 
            // tlpAccounts
            // 
            resources.ApplyResources(this.tlpAccounts, "tlpAccounts");
            this.tlpAccounts.Controls.Add(this.chartDebts, 0, 3);
            this.tlpAccounts.Controls.Add(this.lblAssets, 1, 0);
            this.tlpAccounts.Controls.Add(this.lblDebts, 1, 2);
            this.tlpAccounts.Controls.Add(lblAssetsTitle, 0, 0);
            this.tlpAccounts.Controls.Add(lblDebtsTitle, 0, 2);
            this.tlpAccounts.Controls.Add(this.chartAssets, 0, 1);
            this.tlpAccounts.Name = "tlpAccounts";
            // 
            // chartDebts
            // 
            resources.ApplyResources(this.chartDebts, "chartDebts");
            this.chartDebts.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.MaximumAutoSize = 100F;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 8;
            chartArea1.AxisY.LabelStyle.Format = "N2";
            chartArea1.AxisY.LabelStyle.Interval = 0D;
            chartArea1.AxisY.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisY.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.MaximumAutoSize = 100F;
            chartArea1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "MainChartArea";
            this.chartDebts.ChartAreas.Add(chartArea1);
            this.tlpAccounts.SetColumnSpan(this.chartDebts, 2);
            this.chartDebts.Name = "chartDebts";
            this.chartDebts.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series1.ChartArea = "MainChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.LabelToolTip = "#LABEL";
            series1.Legend = "Legend1";
            series1.Name = "Assets";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series1.ShadowOffset = 1;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartDebts.Series.Add(series1);
            this.chartDebts.TabStop = false;
            // 
            // lblAssets
            // 
            resources.ApplyResources(this.lblAssets, "lblAssets");
            this.lblAssets.ForeColor = System.Drawing.Color.Green;
            this.lblAssets.Name = "lblAssets";
            // 
            // lblDebts
            // 
            resources.ApplyResources(this.lblDebts, "lblDebts");
            this.lblDebts.ForeColor = System.Drawing.Color.Blue;
            this.lblDebts.Name = "lblDebts";
            // 
            // lblAssetsTitle
            // 
            resources.ApplyResources(lblAssetsTitle, "lblAssetsTitle");
            lblAssetsTitle.Name = "lblAssetsTitle";
            // 
            // lblDebtsTitle
            // 
            resources.ApplyResources(lblDebtsTitle, "lblDebtsTitle");
            lblDebtsTitle.Name = "lblDebtsTitle";
            // 
            // chartAssets
            // 
            resources.ApplyResources(this.chartAssets, "chartAssets");
            this.chartAssets.BackColor = System.Drawing.SystemColors.Control;
            chartArea2.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)
                        | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisX.MaximumAutoSize = 100F;
            chartArea2.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisY.LabelAutoFitMinFontSize = 8;
            chartArea2.AxisY.LabelStyle.Format = "N2";
            chartArea2.AxisY.LabelStyle.Interval = 0D;
            chartArea2.AxisY.LabelStyle.IntervalOffset = 0D;
            chartArea2.AxisY.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisY.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisY.MaximumAutoSize = 100F;
            chartArea2.BackColor = System.Drawing.SystemColors.Control;
            chartArea2.Name = "MainChartArea";
            this.chartAssets.ChartAreas.Add(chartArea2);
            this.tlpAccounts.SetColumnSpan(this.chartAssets, 2);
            this.chartAssets.Name = "chartAssets";
            this.chartAssets.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series2.ChartArea = "MainChartArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.LabelToolTip = "#LABEL";
            series2.Legend = "Legend1";
            series2.Name = "Assets";
            series2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series2.ShadowOffset = 1;
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartAssets.Series.Add(series2);
            this.chartAssets.TabStop = false;
            // 
            // gbOverview
            // 
            resources.ApplyResources(gbOverview, "gbOverview");
            gbOverview.Controls.Add(tlpTransactions);
            gbOverview.Name = "gbOverview";
            gbOverview.TabStop = false;
            // 
            // tlpTransactions
            // 
            resources.ApplyResources(tlpTransactions, "tlpTransactions");
            tlpTransactions.Controls.Add(this.lblStatsYearSpent, 3, 5);
            tlpTransactions.Controls.Add(this.lblStatsYearEarned, 2, 5);
            tlpTransactions.Controls.Add(this.lblStatsYear, 1, 5);
            tlpTransactions.Controls.Add(this.lblStatsMonthSpent, 3, 3);
            tlpTransactions.Controls.Add(this.lblStatsMonthEarned, 2, 3);
            tlpTransactions.Controls.Add(this.lblStatsDay, 1, 1);
            tlpTransactions.Controls.Add(this.lblStatsDayEarned, 2, 1);
            tlpTransactions.Controls.Add(this.btnNextYear, 4, 5);
            tlpTransactions.Controls.Add(this.btnPrevYear, 0, 5);
            tlpTransactions.Controls.Add(this.btnNextMonth, 4, 3);
            tlpTransactions.Controls.Add(this.btnPrevMonth, 0, 3);
            tlpTransactions.Controls.Add(this.btnNextDay, 4, 1);
            tlpTransactions.Controls.Add(this.btnPrevDay, 0, 1);
            tlpTransactions.Controls.Add(this.dgvPlans, 0, 8);
            tlpTransactions.Controls.Add(lblPlansTitle, 0, 7);
            tlpTransactions.Controls.Add(this.lblStatsDaySpent, 3, 1);
            tlpTransactions.Controls.Add(this.lblStatsMonth, 1, 3);
            tlpTransactions.Controls.Add(lblStatisticsTitle, 0, 0);
            tlpTransactions.Name = "tlpTransactions";
            // 
            // lblStatsYearSpent
            // 
            resources.ApplyResources(this.lblStatsYearSpent, "lblStatsYearSpent");
            this.lblStatsYearSpent.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatsYearSpent.Name = "lblStatsYearSpent";
            // 
            // lblStatsYearEarned
            // 
            resources.ApplyResources(this.lblStatsYearEarned, "lblStatsYearEarned");
            this.lblStatsYearEarned.ForeColor = System.Drawing.Color.Green;
            this.lblStatsYearEarned.Name = "lblStatsYearEarned";
            // 
            // lblStatsYear
            // 
            resources.ApplyResources(this.lblStatsYear, "lblStatsYear");
            this.lblStatsYear.Name = "lblStatsYear";
            // 
            // lblStatsMonthSpent
            // 
            resources.ApplyResources(this.lblStatsMonthSpent, "lblStatsMonthSpent");
            this.lblStatsMonthSpent.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatsMonthSpent.Name = "lblStatsMonthSpent";
            // 
            // lblStatsMonthEarned
            // 
            resources.ApplyResources(this.lblStatsMonthEarned, "lblStatsMonthEarned");
            this.lblStatsMonthEarned.ForeColor = System.Drawing.Color.Green;
            this.lblStatsMonthEarned.Name = "lblStatsMonthEarned";
            // 
            // lblStatsDay
            // 
            resources.ApplyResources(this.lblStatsDay, "lblStatsDay");
            this.lblStatsDay.Name = "lblStatsDay";
            // 
            // lblStatsDayEarned
            // 
            resources.ApplyResources(this.lblStatsDayEarned, "lblStatsDayEarned");
            this.lblStatsDayEarned.ForeColor = System.Drawing.Color.Green;
            this.lblStatsDayEarned.Name = "lblStatsDayEarned";
            // 
            // btnNextYear
            // 
            resources.ApplyResources(this.btnNextYear, "btnNextYear");
            this.btnNextYear.Name = "btnNextYear";
            this.btnNextYear.UseVisualStyleBackColor = true;
            this.btnNextYear.Click += new System.EventHandler(this.btnNextYear_Click);
            // 
            // btnPrevYear
            // 
            resources.ApplyResources(this.btnPrevYear, "btnPrevYear");
            this.btnPrevYear.Name = "btnPrevYear";
            this.btnPrevYear.UseVisualStyleBackColor = true;
            this.btnPrevYear.Click += new System.EventHandler(this.btnPrevYear_Click);
            // 
            // btnNextMonth
            // 
            resources.ApplyResources(this.btnNextMonth, "btnNextMonth");
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // btnPrevMonth
            // 
            resources.ApplyResources(this.btnPrevMonth, "btnPrevMonth");
            this.btnPrevMonth.Name = "btnPrevMonth";
            this.btnPrevMonth.UseVisualStyleBackColor = true;
            this.btnPrevMonth.Click += new System.EventHandler(this.btnPrevMonth_Click);
            // 
            // btnNextDay
            // 
            resources.ApplyResources(this.btnNextDay, "btnNextDay");
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.UseVisualStyleBackColor = true;
            this.btnNextDay.Click += new System.EventHandler(this.btnNextDay_Click);
            // 
            // btnPrevDay
            // 
            resources.ApplyResources(this.btnPrevDay, "btnPrevDay");
            this.btnPrevDay.Name = "btnPrevDay";
            this.btnPrevDay.UseVisualStyleBackColor = true;
            this.btnPrevDay.Click += new System.EventHandler(this.btnPrevDay_Click);
            // 
            // dgvPlans
            // 
            resources.ApplyResources(this.dgvPlans, "dgvPlans");
            this.dgvPlans.AllowUserToAddRows = false;
            this.dgvPlans.AllowUserToDeleteRows = false;
            this.dgvPlans.AllowUserToResizeColumns = false;
            this.dgvPlans.AllowUserToResizeRows = false;
            this.dgvPlans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlans.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPlans.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlans.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcPlansDate,
            this.dgvcPlansTransactionType,
            this.dgvcPlansAmount,
            this.dgvcPlansTitle});
            tlpTransactions.SetColumnSpan(this.dgvPlans, 5);
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlans.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPlans.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPlans.Name = "dgvPlans";
            this.dgvPlans.ReadOnly = true;
            this.dgvPlans.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlans.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPlans.RowHeadersVisible = false;
            this.dgvPlans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlans.ShowEditingIcon = false;
            this.dgvPlans.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlans_CellDoubleClick);
            this.dgvPlans.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPlans_KeyDown);
            // 
            // dgvcPlansDate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.Format = "d";
            this.dgvcPlansDate.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dgvcPlansDate, "dgvcPlansDate");
            this.dgvcPlansDate.Name = "dgvcPlansDate";
            this.dgvcPlansDate.ReadOnly = true;
            // 
            // dgvcPlansTransactionType
            // 
            resources.ApplyResources(this.dgvcPlansTransactionType, "dgvcPlansTransactionType");
            this.dgvcPlansTransactionType.Name = "dgvcPlansTransactionType";
            this.dgvcPlansTransactionType.ReadOnly = true;
            // 
            // dgvcPlansAmount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.dgvcPlansAmount.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.dgvcPlansAmount, "dgvcPlansAmount");
            this.dgvcPlansAmount.Name = "dgvcPlansAmount";
            this.dgvcPlansAmount.ReadOnly = true;
            // 
            // dgvcPlansTitle
            // 
            this.dgvcPlansTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgvcPlansTitle.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.dgvcPlansTitle, "dgvcPlansTitle");
            this.dgvcPlansTitle.Name = "dgvcPlansTitle";
            this.dgvcPlansTitle.ReadOnly = true;
            // 
            // lblPlansTitle
            // 
            resources.ApplyResources(lblPlansTitle, "lblPlansTitle");
            tlpTransactions.SetColumnSpan(lblPlansTitle, 4);
            lblPlansTitle.Name = "lblPlansTitle";
            // 
            // lblStatsDaySpent
            // 
            resources.ApplyResources(this.lblStatsDaySpent, "lblStatsDaySpent");
            this.lblStatsDaySpent.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatsDaySpent.Name = "lblStatsDaySpent";
            // 
            // lblStatsMonth
            // 
            resources.ApplyResources(this.lblStatsMonth, "lblStatsMonth");
            this.lblStatsMonth.Name = "lblStatsMonth";
            // 
            // lblStatisticsTitle
            // 
            resources.ApplyResources(lblStatisticsTitle, "lblStatisticsTitle");
            tlpTransactions.SetColumnSpan(lblStatisticsTitle, 4);
            lblStatisticsTitle.Name = "lblStatisticsTitle";
            // 
            // bgwUpdateCheck
            // 
            this.bgwUpdateCheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUpdateCheck_DoWork);
            this.bgwUpdateCheck.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwUpdateCheck_RunWorkerCompleted);
            // 
            // fdOpenData
            // 
            resources.ApplyResources(this.fdOpenData, "fdOpenData");
            // 
            // fdSaveData
            // 
            resources.ApplyResources(this.fdSaveData, "fdSaveData");
            // 
            // WelcomeScreenForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tscContainer);
            this.KeyPreview = true;
            this.MainMenuStrip = this.msMenuMain;
            this.Name = "WelcomeScreenForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WelcomeScreenForm_FormClosing);
            this.Load += new System.EventHandler(this.WelcomeScreenForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WelcomeScreenForm_KeyDown);
            tlpWelcome.ResumeLayout(false);
            this.tscContainer.ContentPanel.ResumeLayout(false);
            this.tscContainer.TopToolStripPanel.ResumeLayout(false);
            this.tscContainer.TopToolStripPanel.PerformLayout();
            this.tscContainer.ResumeLayout(false);
            this.tscContainer.PerformLayout();
            this.msMenuMain.ResumeLayout(false);
            this.msMenuMain.PerformLayout();
            gbAccounts.ResumeLayout(false);
            this.tlpAccounts.ResumeLayout(false);
            this.tlpAccounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDebts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAssets)).EndInit();
            gbOverview.ResumeLayout(false);
            tlpTransactions.ResumeLayout(false);
            tlpTransactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAssets;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAssets;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDebts;
        private System.Windows.Forms.Label lblDebts;
        private System.Windows.Forms.DataGridView dgvPlans;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPlansDate;
        private System.Windows.Forms.DataGridViewImageColumn dgvcPlansTransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPlansAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcPlansTitle;
        private System.ComponentModel.BackgroundWorker bgwUpdateCheck;
        private System.Windows.Forms.OpenFileDialog fdOpenData;
        private System.Windows.Forms.SaveFileDialog fdSaveData;
        private System.Windows.Forms.MenuStrip msMenuMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiTransactions;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlans;
        private System.Windows.Forms.ToolStripMenuItem tsmiAccounts;
        private System.Windows.Forms.ToolStripMenuItem tsmiReports;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private Controls.ToolStripSpringTextBox tsstbSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiStartSearch;
        private System.Windows.Forms.ToolStripContainer tscContainer;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiTransactionList;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewPayment;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewIncome;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlanList;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlanPayment;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlanIncome;
        private System.Windows.Forms.ToolStripMenuItem tsmiAccountList;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewDebitAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewCreditAccount;
        private System.Windows.Forms.ToolStripMenuItem tsmiReportList;
        private System.Windows.Forms.ToolStripMenuItem tsmiMonthBalance;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowIntroduction;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.Label lblStatsYearSpent;
        private System.Windows.Forms.Label lblStatsYearEarned;
        private System.Windows.Forms.Label lblStatsYear;
        private System.Windows.Forms.Label lblStatsMonthSpent;
        private System.Windows.Forms.Label lblStatsMonthEarned;
        private System.Windows.Forms.Label lblStatsDay;
        private System.Windows.Forms.Label lblStatsDayEarned;
        private System.Windows.Forms.Button btnNextYear;
        private System.Windows.Forms.Button btnPrevYear;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Button btnPrevMonth;
        private System.Windows.Forms.Button btnNextDay;
        private System.Windows.Forms.Button btnPrevDay;
        private System.Windows.Forms.Label lblStatsDaySpent;
        private System.Windows.Forms.Label lblStatsMonth;
        private System.Windows.Forms.TableLayoutPanel tlpAccounts;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;

    }
}