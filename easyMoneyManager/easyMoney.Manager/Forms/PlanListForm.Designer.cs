namespace easyMoney.Manager.Forms
{
    partial class PlanListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanListForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.ToolStripSeparator tssSep1;
            System.Windows.Forms.ToolStripSeparator tssSep2;
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dgvPlans = new System.Windows.Forms.DataGridView();
            this.PlannedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsPlans = new System.Windows.Forms.ToolStrip();
            this.tsddbPlanPayment = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsddbPlanIncome = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbImplement = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbShowAll = new System.Windows.Forms.ToolStripButton();
            tssSep1 = new System.Windows.Forms.ToolStripSeparator();
            tssSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).BeginInit();
            this.tsPlans.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.BottomToolStripPanel, "toolStripContainer1.BottomToolStripPanel");
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dgvPlans);
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.LeftToolStripPanel, "toolStripContainer1.LeftToolStripPanel");
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.RightToolStripPanel, "toolStripContainer1.RightToolStripPanel");
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.TopToolStripPanel, "toolStripContainer1.TopToolStripPanel");
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsPlans);
            // 
            // dgvPlans
            // 
            resources.ApplyResources(this.dgvPlans, "dgvPlans");
            this.dgvPlans.AllowUserToAddRows = false;
            this.dgvPlans.AllowUserToDeleteRows = false;
            this.dgvPlans.AllowUserToResizeColumns = false;
            this.dgvPlans.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPlans.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPlans.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlans.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPlans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlannedDate,
            this.Type,
            this.Title,
            this.Amount,
            this.AccountType});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlans.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvPlans.MultiSelect = false;
            this.dgvPlans.Name = "dgvPlans";
            this.dgvPlans.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlans.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPlans.RowHeadersVisible = false;
            this.dgvPlans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlans.ShowCellErrors = false;
            this.dgvPlans.ShowEditingIcon = false;
            this.dgvPlans.ShowRowErrors = false;
            this.dgvPlans.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlans_CellDoubleClick);
            this.dgvPlans.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPlans_KeyDown);
            // 
            // PlannedDate
            // 
            this.PlannedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.PlannedDate, "PlannedDate");
            this.PlannedDate.Name = "PlannedDate";
            this.PlannedDate.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.Type, "Type");
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Title, "Title");
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.Amount, "Amount");
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // AccountType
            // 
            this.AccountType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            resources.ApplyResources(this.AccountType, "AccountType");
            this.AccountType.Name = "AccountType";
            this.AccountType.ReadOnly = true;
            // 
            // tsPlans
            // 
            resources.ApplyResources(this.tsPlans, "tsPlans");
            this.tsPlans.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPlans.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbPlanPayment,
            this.tsddbPlanIncome,
            tssSep1,
            this.tsbEdit,
            this.tsbCopy,
            this.tsbImplement,
            this.tsbDelete,
            this.tsbClose,
            tssSep2,
            this.tsbShowAll});
            this.tsPlans.Name = "tsPlans";
            this.tsPlans.Stretch = true;
            // 
            // tsddbPlanPayment
            // 
            resources.ApplyResources(this.tsddbPlanPayment, "tsddbPlanPayment");
            this.tsddbPlanPayment.Image = global::easyMoney.Manager.Properties.Resources.basket;
            this.tsddbPlanPayment.Name = "tsddbPlanPayment";
            // 
            // tsddbPlanIncome
            // 
            resources.ApplyResources(this.tsddbPlanIncome, "tsddbPlanIncome");
            this.tsddbPlanIncome.Image = global::easyMoney.Manager.Properties.Resources.coins;
            this.tsddbPlanIncome.Name = "tsddbPlanIncome";
            // 
            // tssSep1
            // 
            resources.ApplyResources(tssSep1, "tssSep1");
            tssSep1.Name = "tssSep1";
            // 
            // tsbEdit
            // 
            resources.ApplyResources(this.tsbEdit, "tsbEdit");
            this.tsbEdit.Image = global::easyMoney.Manager.Properties.Resources.pencil;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEditCopy_Click);
            // 
            // tsbCopy
            // 
            resources.ApplyResources(this.tsbCopy, "tsbCopy");
            this.tsbCopy.Image = global::easyMoney.Manager.Properties.Resources.page_copy;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Click += new System.EventHandler(this.tsbEditCopy_Click);
            // 
            // tsbImplement
            // 
            resources.ApplyResources(this.tsbImplement, "tsbImplement");
            this.tsbImplement.Image = global::easyMoney.Manager.Properties.Resources.table;
            this.tsbImplement.Name = "tsbImplement";
            this.tsbImplement.Click += new System.EventHandler(this.tsbImplement_Click);
            // 
            // tsbDelete
            // 
            resources.ApplyResources(this.tsbDelete, "tsbDelete");
            this.tsbDelete.Image = global::easyMoney.Manager.Properties.Resources.delete;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbClose
            // 
            resources.ApplyResources(this.tsbClose, "tsbClose");
            this.tsbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbClose.Image = global::easyMoney.Manager.Properties.Resources.tick;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSep2
            // 
            resources.ApplyResources(tssSep2, "tssSep2");
            tssSep2.Name = "tssSep2";
            // 
            // tsbShowAll
            // 
            resources.ApplyResources(this.tsbShowAll, "tsbShowAll");
            this.tsbShowAll.CheckOnClick = true;
            this.tsbShowAll.Image = global::easyMoney.Manager.Properties.Resources.calendar_view_day;
            this.tsbShowAll.Name = "tsbShowAll";
            this.tsbShowAll.Click += new System.EventHandler(this.tsbShowAll_Click);
            // 
            // PlanListForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlanListForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.PlanListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlanListForm_KeyDown);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlans)).EndInit();
            this.tsPlans.ResumeLayout(false);
            this.tsPlans.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPlans;
        private System.Windows.Forms.ToolStripDropDownButton tsddbPlanPayment;
        private System.Windows.Forms.ToolStripDropDownButton tsddbPlanIncome;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbImplement;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.DataGridView dgvPlans;
        private System.Windows.Forms.ToolStripButton tsbShowAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlannedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountType;


    }
}