namespace easyMoney.Manager.Forms
{
    partial class TransactionListForm
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
            System.Windows.Forms.ToolStripSeparator tssSep1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionListForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.ToolStripSeparator tssSep2;
            System.Windows.Forms.ToolStripLabel tslTransactions;
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.dgvcDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsTransactions = new System.Windows.Forms.ToolStrip();
            this.tsddbNewPayment = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsddbNewIncome = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbTransactionsMonth = new System.Windows.Forms.ToolStripButton();
            this.tsbTransactionsYear = new System.Windows.Forms.ToolStripButton();
            this.tsbTransactionsAll = new System.Windows.Forms.ToolStripButton();
            tssSep1 = new System.Windows.Forms.ToolStripSeparator();
            tssSep2 = new System.Windows.Forms.ToolStripSeparator();
            tslTransactions = new System.Windows.Forms.ToolStripLabel();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.tsTransactions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tssSep1
            // 
            tssSep1.Name = "tssSep1";
            resources.ApplyResources(tssSep1, "tssSep1");
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dgvTransactions);
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsTransactions);
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.AllowUserToResizeColumns = false;
            this.dgvTransactions.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransactions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcDate,
            this.dgvcType,
            this.dgvcTitle,
            this.dgvcAmount,
            this.dgvcAccount});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransactions.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.dgvTransactions, "dgvTransactions");
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactions.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.ShowCellErrors = false;
            this.dgvTransactions.ShowEditingIcon = false;
            this.dgvTransactions.ShowRowErrors = false;
            this.dgvTransactions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactions_CellDoubleClick);
            this.dgvTransactions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTransactions_KeyDown);
            // 
            // dgvcDate
            // 
            this.dgvcDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dgvcDate.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.dgvcDate, "dgvcDate");
            this.dgvcDate.Name = "dgvcDate";
            this.dgvcDate.ReadOnly = true;
            // 
            // dgvcType
            // 
            this.dgvcType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.dgvcType, "dgvcType");
            this.dgvcType.Name = "dgvcType";
            this.dgvcType.ReadOnly = true;
            // 
            // dgvcTitle
            // 
            this.dgvcTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.dgvcTitle, "dgvcTitle");
            this.dgvcTitle.Name = "dgvcTitle";
            this.dgvcTitle.ReadOnly = true;
            // 
            // dgvcAmount
            // 
            this.dgvcAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.dgvcAmount, "dgvcAmount");
            this.dgvcAmount.Name = "dgvcAmount";
            this.dgvcAmount.ReadOnly = true;
            this.dgvcAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvcAccount
            // 
            this.dgvcAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.dgvcAccount, "dgvcAccount");
            this.dgvcAccount.Name = "dgvcAccount";
            this.dgvcAccount.ReadOnly = true;
            // 
            // tsTransactions
            // 
            resources.ApplyResources(this.tsTransactions, "tsTransactions");
            this.tsTransactions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTransactions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbNewPayment,
            this.tsddbNewIncome,
            tssSep1,
            this.tsbDelete,
            this.tsbClose,
            tssSep2,
            tslTransactions,
            this.tsbTransactionsMonth,
            this.tsbTransactionsYear,
            this.tsbTransactionsAll});
            this.tsTransactions.Name = "tsTransactions";
            this.tsTransactions.Stretch = true;
            // 
            // tsddbNewPayment
            // 
            this.tsddbNewPayment.Image = global::easyMoney.Manager.Properties.Resources.basket;
            resources.ApplyResources(this.tsddbNewPayment, "tsddbNewPayment");
            this.tsddbNewPayment.Name = "tsddbNewPayment";
            // 
            // tsddbNewIncome
            // 
            this.tsddbNewIncome.Image = global::easyMoney.Manager.Properties.Resources.coins;
            resources.ApplyResources(this.tsddbNewIncome, "tsddbNewIncome");
            this.tsddbNewIncome.Name = "tsddbNewIncome";
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::easyMoney.Manager.Properties.Resources.delete;
            resources.ApplyResources(this.tsbDelete, "tsbDelete");
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbClose.Image = global::easyMoney.Manager.Properties.Resources.tick;
            resources.ApplyResources(this.tsbClose, "tsbClose");
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSep2
            // 
            tssSep2.Name = "tssSep2";
            resources.ApplyResources(tssSep2, "tssSep2");
            // 
            // tslTransactions
            // 
            tslTransactions.Name = "tslTransactions";
            resources.ApplyResources(tslTransactions, "tslTransactions");
            // 
            // tsbTransactionsMonth
            // 
            this.tsbTransactionsMonth.Checked = true;
            this.tsbTransactionsMonth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbTransactionsMonth.Image = global::easyMoney.Manager.Properties.Resources.calendar_view_day;
            resources.ApplyResources(this.tsbTransactionsMonth, "tsbTransactionsMonth");
            this.tsbTransactionsMonth.Name = "tsbTransactionsMonth";
            this.tsbTransactionsMonth.Click += new System.EventHandler(this.tsbTransactionsMonth_Click);
            // 
            // tsbTransactionsYear
            // 
            this.tsbTransactionsYear.Image = global::easyMoney.Manager.Properties.Resources.calendar_view_day;
            resources.ApplyResources(this.tsbTransactionsYear, "tsbTransactionsYear");
            this.tsbTransactionsYear.Name = "tsbTransactionsYear";
            this.tsbTransactionsYear.Click += new System.EventHandler(this.tsbTransactionsYear_Click);
            // 
            // tsbTransactionsAll
            // 
            this.tsbTransactionsAll.Image = global::easyMoney.Manager.Properties.Resources.calendar_view_day;
            resources.ApplyResources(this.tsbTransactionsAll, "tsbTransactionsAll");
            this.tsbTransactionsAll.Name = "tsbTransactionsAll";
            this.tsbTransactionsAll.Click += new System.EventHandler(this.tsbTransactionsAll_Click);
            // 
            // TransactionListForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransactionListForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TransactionListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TransactionListForm_KeyDown);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.tsTransactions.ResumeLayout(false);
            this.tsTransactions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.ToolStripDropDownButton tsddbNewIncome;
        private System.Windows.Forms.ToolStripDropDownButton tsddbNewPayment;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip tsTransactions;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbTransactionsAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcAccount;
        private System.Windows.Forms.ToolStripButton tsbTransactionsMonth;
        private System.Windows.Forms.ToolStripButton tsbTransactionsYear;

    }
}