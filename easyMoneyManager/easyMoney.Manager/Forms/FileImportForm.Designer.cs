namespace easyMoney.Manager.Forms
{
    partial class FileImportForm
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
            System.Windows.Forms.ToolStripContainer tscFileImport;
            System.Windows.Forms.TableLayoutPanel tlpFileImport;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileImportForm));
            System.Windows.Forms.GroupBox gbImportedTransactionList;
            System.Windows.Forms.GroupBox gbTransactionDetails;
            System.Windows.Forms.TableLayoutPanel tlpDetails;
            System.Windows.Forms.Label lblDate;
            System.Windows.Forms.Label lblTitle;
            System.Windows.Forms.Label lblAccount;
            System.Windows.Forms.Label lblAmount;
            System.Windows.Forms.Label lblTags;
            System.Windows.Forms.ToolStrip tsFileImport;
            this.lbImportedTransactions = new System.Windows.Forms.ListBox();
            this.cbImport = new System.Windows.Forms.CheckBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.cbImplementsPlan = new System.Windows.Forms.CheckBox();
            this.cbPlan = new System.Windows.Forms.ComboBox();
            this.cbAccount = new System.Windows.Forms.ComboBox();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.ttbTags = new easyMoney.Controls.TagTextBox();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.fdFileOpen = new System.Windows.Forms.OpenFileDialog();
            tscFileImport = new System.Windows.Forms.ToolStripContainer();
            tlpFileImport = new System.Windows.Forms.TableLayoutPanel();
            gbImportedTransactionList = new System.Windows.Forms.GroupBox();
            gbTransactionDetails = new System.Windows.Forms.GroupBox();
            tlpDetails = new System.Windows.Forms.TableLayoutPanel();
            lblDate = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            lblAccount = new System.Windows.Forms.Label();
            lblAmount = new System.Windows.Forms.Label();
            lblTags = new System.Windows.Forms.Label();
            tsFileImport = new System.Windows.Forms.ToolStrip();
            tscFileImport.ContentPanel.SuspendLayout();
            tscFileImport.TopToolStripPanel.SuspendLayout();
            tscFileImport.SuspendLayout();
            tlpFileImport.SuspendLayout();
            gbImportedTransactionList.SuspendLayout();
            gbTransactionDetails.SuspendLayout();
            tlpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            tsFileImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscFileImport
            // 
            tscFileImport.BottomToolStripPanelVisible = false;
            // 
            // tscFileImport.ContentPanel
            // 
            tscFileImport.ContentPanel.Controls.Add(tlpFileImport);
            resources.ApplyResources(tscFileImport.ContentPanel, "tscFileImport.ContentPanel");
            resources.ApplyResources(tscFileImport, "tscFileImport");
            tscFileImport.LeftToolStripPanelVisible = false;
            tscFileImport.Name = "tscFileImport";
            tscFileImport.RightToolStripPanelVisible = false;
            // 
            // tscFileImport.TopToolStripPanel
            // 
            tscFileImport.TopToolStripPanel.Controls.Add(tsFileImport);
            // 
            // tlpFileImport
            // 
            resources.ApplyResources(tlpFileImport, "tlpFileImport");
            tlpFileImport.Controls.Add(gbImportedTransactionList, 0, 0);
            tlpFileImport.Controls.Add(gbTransactionDetails, 1, 0);
            tlpFileImport.Name = "tlpFileImport";
            // 
            // gbImportedTransactionList
            // 
            gbImportedTransactionList.Controls.Add(this.lbImportedTransactions);
            resources.ApplyResources(gbImportedTransactionList, "gbImportedTransactionList");
            gbImportedTransactionList.Name = "gbImportedTransactionList";
            gbImportedTransactionList.TabStop = false;
            // 
            // lbImportedTransactions
            // 
            resources.ApplyResources(this.lbImportedTransactions, "lbImportedTransactions");
            this.lbImportedTransactions.FormattingEnabled = true;
            this.lbImportedTransactions.Name = "lbImportedTransactions";
            this.lbImportedTransactions.SelectedIndexChanged += new System.EventHandler(this.lbImportedTransactions_SelectedIndexChanged);
            // 
            // gbTransactionDetails
            // 
            gbTransactionDetails.Controls.Add(tlpDetails);
            resources.ApplyResources(gbTransactionDetails, "gbTransactionDetails");
            gbTransactionDetails.Name = "gbTransactionDetails";
            gbTransactionDetails.TabStop = false;
            // 
            // tlpDetails
            // 
            resources.ApplyResources(tlpDetails, "tlpDetails");
            tlpDetails.Controls.Add(this.cbImport, 0, 0);
            tlpDetails.Controls.Add(lblDate, 0, 1);
            tlpDetails.Controls.Add(this.dtpDate, 0, 2);
            tlpDetails.Controls.Add(lblTitle, 0, 3);
            tlpDetails.Controls.Add(this.tbTitle, 0, 4);
            tlpDetails.Controls.Add(this.cbImplementsPlan, 0, 5);
            tlpDetails.Controls.Add(this.cbPlan, 0, 6);
            tlpDetails.Controls.Add(lblAccount, 0, 7);
            tlpDetails.Controls.Add(this.cbAccount, 0, 8);
            tlpDetails.Controls.Add(lblAmount, 0, 9);
            tlpDetails.Controls.Add(this.numAmount, 0, 10);
            tlpDetails.Controls.Add(this.lblCurrency, 2, 10);
            tlpDetails.Controls.Add(lblTags, 0, 11);
            tlpDetails.Controls.Add(this.ttbTags, 0, 12);
            tlpDetails.Name = "tlpDetails";
            // 
            // cbImport
            // 
            resources.ApplyResources(this.cbImport, "cbImport");
            tlpDetails.SetColumnSpan(this.cbImport, 3);
            this.cbImport.Name = "cbImport";
            this.cbImport.UseVisualStyleBackColor = true;
            // 
            // lblDate
            // 
            resources.ApplyResources(lblDate, "lblDate");
            tlpDetails.SetColumnSpan(lblDate, 3);
            lblDate.Name = "lblDate";
            // 
            // dtpDate
            // 
            tlpDetails.SetColumnSpan(this.dtpDate, 3);
            resources.ApplyResources(this.dtpDate, "dtpDate");
            this.dtpDate.Name = "dtpDate";
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            tlpDetails.SetColumnSpan(lblTitle, 3);
            lblTitle.Name = "lblTitle";
            // 
            // tbTitle
            // 
            this.tbTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            tlpDetails.SetColumnSpan(this.tbTitle, 3);
            resources.ApplyResources(this.tbTitle, "tbTitle");
            this.tbTitle.Name = "tbTitle";
            // 
            // cbImplementsPlan
            // 
            resources.ApplyResources(this.cbImplementsPlan, "cbImplementsPlan");
            tlpDetails.SetColumnSpan(this.cbImplementsPlan, 3);
            this.cbImplementsPlan.Name = "cbImplementsPlan";
            this.cbImplementsPlan.UseVisualStyleBackColor = true;
            // 
            // cbPlan
            // 
            tlpDetails.SetColumnSpan(this.cbPlan, 3);
            resources.ApplyResources(this.cbPlan, "cbPlan");
            this.cbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlan.FormattingEnabled = true;
            this.cbPlan.Name = "cbPlan";
            // 
            // lblAccount
            // 
            resources.ApplyResources(lblAccount, "lblAccount");
            tlpDetails.SetColumnSpan(lblAccount, 3);
            lblAccount.Name = "lblAccount";
            // 
            // cbAccount
            // 
            tlpDetails.SetColumnSpan(this.cbAccount, 3);
            resources.ApplyResources(this.cbAccount, "cbAccount");
            this.cbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccount.FormattingEnabled = true;
            this.cbAccount.Name = "cbAccount";
            // 
            // lblAmount
            // 
            resources.ApplyResources(lblAmount, "lblAmount");
            tlpDetails.SetColumnSpan(lblAmount, 3);
            lblAmount.Name = "lblAmount";
            // 
            // numAmount
            // 
            tlpDetails.SetColumnSpan(this.numAmount, 2);
            this.numAmount.DecimalPlaces = 2;
            resources.ApplyResources(this.numAmount, "numAmount");
            this.numAmount.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.numAmount.Name = "numAmount";
            // 
            // lblCurrency
            // 
            resources.ApplyResources(this.lblCurrency, "lblCurrency");
            this.lblCurrency.Name = "lblCurrency";
            // 
            // lblTags
            // 
            resources.ApplyResources(lblTags, "lblTags");
            tlpDetails.SetColumnSpan(lblTags, 3);
            lblTags.Name = "lblTags";
            // 
            // ttbTags
            // 
            tlpDetails.SetColumnSpan(this.ttbTags, 3);
            resources.ApplyResources(this.ttbTags, "ttbTags");
            this.ttbTags.Name = "ttbTags";
            this.ttbTags.PopupOpened = false;
            this.ttbTags.ReadOnly = false;
            this.ttbTags.Tags = ((System.Collections.Generic.IEnumerable<string>)(resources.GetObject("ttbTags.Tags")));
            // 
            // tsFileImport
            // 
            resources.ApplyResources(tsFileImport, "tsFileImport");
            tsFileImport.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            tsFileImport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbClose,
            this.tsbImport});
            tsFileImport.Name = "tsFileImport";
            tsFileImport.Stretch = true;
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = global::easyMoney.Manager.Properties.Resources.folder_page;
            resources.ApplyResources(this.tsbOpen, "tsbOpen");
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbClose.Image = global::easyMoney.Manager.Properties.Resources.tick;
            resources.ApplyResources(this.tsbClose, "tsbClose");
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tsbImport
            // 
            this.tsbImport.Image = global::easyMoney.Manager.Properties.Resources.table_multiple;
            resources.ApplyResources(this.tsbImport, "tsbImport");
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Click += new System.EventHandler(this.tsbImport_Click);
            // 
            // fdFileOpen
            // 
            this.fdFileOpen.DefaultExt = "*.xml";
            resources.ApplyResources(this.fdFileOpen, "fdFileOpen");
            // 
            // FileImportForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(tscFileImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FileImportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FileImportForm_Load);
            tscFileImport.ContentPanel.ResumeLayout(false);
            tscFileImport.TopToolStripPanel.ResumeLayout(false);
            tscFileImport.TopToolStripPanel.PerformLayout();
            tscFileImport.ResumeLayout(false);
            tscFileImport.PerformLayout();
            tlpFileImport.ResumeLayout(false);
            gbImportedTransactionList.ResumeLayout(false);
            gbTransactionDetails.ResumeLayout(false);
            tlpDetails.ResumeLayout(false);
            tlpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            tsFileImport.ResumeLayout(false);
            tsFileImport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbImport;
        private System.Windows.Forms.OpenFileDialog fdFileOpen;
        private System.Windows.Forms.ListBox lbImportedTransactions;
        private System.Windows.Forms.CheckBox cbImport;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.CheckBox cbImplementsPlan;
        private System.Windows.Forms.ComboBox cbPlan;
        private System.Windows.Forms.ComboBox cbAccount;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label lblCurrency;
        private Controls.TagTextBox ttbTags;
    }
}

