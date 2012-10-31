namespace easyMoney.SimpleReports
{
    partial class DateAccountsTypesTags
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateAccountsTypesTags));
            this.lbTags = new System.Windows.Forms.ListBox();
            this.lblTags = new System.Windows.Forms.Label();
            this.lbTransactionTypes = new System.Windows.Forms.ListBox();
            this.lblTransactionTypes = new System.Windows.Forms.Label();
            this.lbAccounts = new System.Windows.Forms.ListBox();
            this.lblAccounts = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTags
            // 
            resources.ApplyResources(this.lbTags, "lbTags");
            this.lbTags.FormattingEnabled = true;
            this.lbTags.Name = "lbTags";
            this.lbTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // lblTags
            // 
            resources.ApplyResources(this.lblTags, "lblTags");
            this.lblTags.Name = "lblTags";
            // 
            // lbTransactionTypes
            // 
            resources.ApplyResources(this.lbTransactionTypes, "lbTransactionTypes");
            this.lbTransactionTypes.FormattingEnabled = true;
            this.lbTransactionTypes.Name = "lbTransactionTypes";
            this.lbTransactionTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // lblTransactionTypes
            // 
            resources.ApplyResources(this.lblTransactionTypes, "lblTransactionTypes");
            this.lblTransactionTypes.Name = "lblTransactionTypes";
            // 
            // lbAccounts
            // 
            resources.ApplyResources(this.lbAccounts, "lbAccounts");
            this.lbAccounts.FormattingEnabled = true;
            this.lbAccounts.Name = "lbAccounts";
            this.lbAccounts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // lblAccounts
            // 
            resources.ApplyResources(this.lblAccounts, "lblAccounts");
            this.lblAccounts.Name = "lblAccounts";
            // 
            // dtpEndDate
            // 
            resources.ApplyResources(this.dtpEndDate, "dtpEndDate");
            this.dtpEndDate.Name = "dtpEndDate";
            // 
            // lblEndDate
            // 
            resources.ApplyResources(this.lblEndDate, "lblEndDate");
            this.lblEndDate.Name = "lblEndDate";
            // 
            // dtpStartDate
            // 
            resources.ApplyResources(this.dtpStartDate, "dtpStartDate");
            this.dtpStartDate.Name = "dtpStartDate";
            // 
            // lblStartDate
            // 
            resources.ApplyResources(this.lblStartDate, "lblStartDate");
            this.lblStartDate.Name = "lblStartDate";
            // 
            // DateAccountsTypesTags
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbTags);
            this.Controls.Add(this.lblTags);
            this.Controls.Add(this.lbTransactionTypes);
            this.Controls.Add(this.lblTransactionTypes);
            this.Controls.Add(this.lbAccounts);
            this.Controls.Add(this.lblAccounts);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblStartDate);
            this.Name = "DateAccountsTypesTags";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox lbTags;
        private System.Windows.Forms.Label lblTags;
        public System.Windows.Forms.ListBox lbTransactionTypes;
        public System.Windows.Forms.Label lblTransactionTypes;
        public System.Windows.Forms.ListBox lbAccounts;
        public System.Windows.Forms.Label lblAccounts;
        public System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblEndDate;
        public System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblStartDate;
    }
}
