namespace easyMoney.Manager.Forms
{
    partial class TransactionViewForm
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
            System.Windows.Forms.ToolStripContainer tscTransactionView;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionViewForm));
            System.Windows.Forms.Label lblTitle;
            System.Windows.Forms.Label lblSourceAccount;
            System.Windows.Forms.Label lblSourceAmount;
            System.Windows.Forms.Label lblDestinationAccount;
            System.Windows.Forms.Label lblDestinationAmount;
            System.Windows.Forms.Label lblDescription;
            System.Windows.Forms.Label lblTags;
            System.Windows.Forms.Label lblImplementsPlan;
            this.tlpTemplateTransaction = new System.Windows.Forms.TableLayoutPanel();
            this.tbImplementsPlan = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.tlpSource = new System.Windows.Forms.TableLayoutPanel();
            this.tbSourceAmount = new System.Windows.Forms.TextBox();
            this.tbSourceAccount = new System.Windows.Forms.TextBox();
            this.gbDestination = new System.Windows.Forms.GroupBox();
            this.tlpDestination = new System.Windows.Forms.TableLayoutPanel();
            this.tbDestinationAccount = new System.Windows.Forms.TextBox();
            this.tbDestinationAmount = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.ttbTags = new easyMoney.Controls.TagTextBox();
            this.tsTransactionView = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            tscTransactionView = new System.Windows.Forms.ToolStripContainer();
            lblTitle = new System.Windows.Forms.Label();
            lblSourceAccount = new System.Windows.Forms.Label();
            lblSourceAmount = new System.Windows.Forms.Label();
            lblDestinationAccount = new System.Windows.Forms.Label();
            lblDestinationAmount = new System.Windows.Forms.Label();
            lblDescription = new System.Windows.Forms.Label();
            lblTags = new System.Windows.Forms.Label();
            lblImplementsPlan = new System.Windows.Forms.Label();
            tscTransactionView.ContentPanel.SuspendLayout();
            tscTransactionView.TopToolStripPanel.SuspendLayout();
            tscTransactionView.SuspendLayout();
            this.tlpTemplateTransaction.SuspendLayout();
            this.gbSource.SuspendLayout();
            this.tlpSource.SuspendLayout();
            this.gbDestination.SuspendLayout();
            this.tlpDestination.SuspendLayout();
            this.tsTransactionView.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscTransactionView
            // 
            tscTransactionView.BottomToolStripPanelVisible = false;
            // 
            // tscTransactionView.ContentPanel
            // 
            tscTransactionView.ContentPanel.Controls.Add(this.tlpTemplateTransaction);
            resources.ApplyResources(tscTransactionView.ContentPanel, "tscTransactionView.ContentPanel");
            resources.ApplyResources(tscTransactionView, "tscTransactionView");
            tscTransactionView.LeftToolStripPanelVisible = false;
            tscTransactionView.Name = "tscTransactionView";
            tscTransactionView.RightToolStripPanelVisible = false;
            // 
            // tscTransactionView.TopToolStripPanel
            // 
            tscTransactionView.TopToolStripPanel.Controls.Add(this.tsTransactionView);
            // 
            // tlpTemplateTransaction
            // 
            resources.ApplyResources(this.tlpTemplateTransaction, "tlpTemplateTransaction");
            this.tlpTemplateTransaction.Controls.Add(this.tbImplementsPlan, 0, 8);
            this.tlpTemplateTransaction.Controls.Add(lblTitle, 0, 0);
            this.tlpTemplateTransaction.Controls.Add(this.tbTitle, 0, 1);
            this.tlpTemplateTransaction.Controls.Add(this.gbSource, 0, 2);
            this.tlpTemplateTransaction.Controls.Add(this.gbDestination, 1, 2);
            this.tlpTemplateTransaction.Controls.Add(lblDescription, 0, 3);
            this.tlpTemplateTransaction.Controls.Add(this.tbDescription, 0, 4);
            this.tlpTemplateTransaction.Controls.Add(lblTags, 0, 5);
            this.tlpTemplateTransaction.Controls.Add(this.ttbTags, 0, 6);
            this.tlpTemplateTransaction.Controls.Add(lblImplementsPlan, 0, 7);
            this.tlpTemplateTransaction.Name = "tlpTemplateTransaction";
            // 
            // tbImplementsPlan
            // 
            this.tbImplementsPlan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbImplementsPlan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tlpTemplateTransaction.SetColumnSpan(this.tbImplementsPlan, 2);
            resources.ApplyResources(this.tbImplementsPlan, "tbImplementsPlan");
            this.tbImplementsPlan.Name = "tbImplementsPlan";
            this.tbImplementsPlan.ReadOnly = true;
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            this.tlpTemplateTransaction.SetColumnSpan(lblTitle, 2);
            lblTitle.Name = "lblTitle";
            // 
            // tbTitle
            // 
            this.tbTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tlpTemplateTransaction.SetColumnSpan(this.tbTitle, 2);
            resources.ApplyResources(this.tbTitle, "tbTitle");
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.tlpSource);
            resources.ApplyResources(this.gbSource, "gbSource");
            this.gbSource.Name = "gbSource";
            this.gbSource.TabStop = false;
            // 
            // tlpSource
            // 
            resources.ApplyResources(this.tlpSource, "tlpSource");
            this.tlpSource.Controls.Add(this.tbSourceAmount, 0, 3);
            this.tlpSource.Controls.Add(this.tbSourceAccount, 0, 1);
            this.tlpSource.Controls.Add(lblSourceAccount, 0, 0);
            this.tlpSource.Controls.Add(lblSourceAmount, 0, 2);
            this.tlpSource.Name = "tlpSource";
            // 
            // tbSourceAmount
            // 
            resources.ApplyResources(this.tbSourceAmount, "tbSourceAmount");
            this.tbSourceAmount.Name = "tbSourceAmount";
            this.tbSourceAmount.ReadOnly = true;
            // 
            // tbSourceAccount
            // 
            resources.ApplyResources(this.tbSourceAccount, "tbSourceAccount");
            this.tbSourceAccount.Name = "tbSourceAccount";
            this.tbSourceAccount.ReadOnly = true;
            // 
            // lblSourceAccount
            // 
            resources.ApplyResources(lblSourceAccount, "lblSourceAccount");
            lblSourceAccount.Name = "lblSourceAccount";
            // 
            // lblSourceAmount
            // 
            resources.ApplyResources(lblSourceAmount, "lblSourceAmount");
            lblSourceAmount.Name = "lblSourceAmount";
            // 
            // gbDestination
            // 
            this.gbDestination.Controls.Add(this.tlpDestination);
            resources.ApplyResources(this.gbDestination, "gbDestination");
            this.gbDestination.Name = "gbDestination";
            this.gbDestination.TabStop = false;
            // 
            // tlpDestination
            // 
            resources.ApplyResources(this.tlpDestination, "tlpDestination");
            this.tlpDestination.Controls.Add(this.tbDestinationAccount, 0, 1);
            this.tlpDestination.Controls.Add(this.tbDestinationAmount, 0, 3);
            this.tlpDestination.Controls.Add(lblDestinationAccount, 0, 0);
            this.tlpDestination.Controls.Add(lblDestinationAmount, 0, 2);
            this.tlpDestination.Name = "tlpDestination";
            // 
            // tbDestinationAccount
            // 
            resources.ApplyResources(this.tbDestinationAccount, "tbDestinationAccount");
            this.tbDestinationAccount.Name = "tbDestinationAccount";
            this.tbDestinationAccount.ReadOnly = true;
            // 
            // tbDestinationAmount
            // 
            resources.ApplyResources(this.tbDestinationAmount, "tbDestinationAmount");
            this.tbDestinationAmount.Name = "tbDestinationAmount";
            this.tbDestinationAmount.ReadOnly = true;
            // 
            // lblDestinationAccount
            // 
            resources.ApplyResources(lblDestinationAccount, "lblDestinationAccount");
            lblDestinationAccount.Name = "lblDestinationAccount";
            // 
            // lblDestinationAmount
            // 
            resources.ApplyResources(lblDestinationAmount, "lblDestinationAmount");
            lblDestinationAmount.Name = "lblDestinationAmount";
            // 
            // lblDescription
            // 
            resources.ApplyResources(lblDescription, "lblDescription");
            this.tlpTemplateTransaction.SetColumnSpan(lblDescription, 2);
            lblDescription.Name = "lblDescription";
            // 
            // tbDescription
            // 
            this.tlpTemplateTransaction.SetColumnSpan(this.tbDescription, 2);
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            // 
            // lblTags
            // 
            resources.ApplyResources(lblTags, "lblTags");
            this.tlpTemplateTransaction.SetColumnSpan(lblTags, 2);
            lblTags.Name = "lblTags";
            // 
            // ttbTags
            // 
            this.tlpTemplateTransaction.SetColumnSpan(this.ttbTags, 2);
            resources.ApplyResources(this.ttbTags, "ttbTags");
            this.ttbTags.Name = "ttbTags";
            this.ttbTags.PopupOpened = false;
            this.ttbTags.ReadOnly = true;
            this.ttbTags.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("ttbTags.Tags")));
            // 
            // lblImplementsPlan
            // 
            resources.ApplyResources(lblImplementsPlan, "lblImplementsPlan");
            this.tlpTemplateTransaction.SetColumnSpan(lblImplementsPlan, 2);
            lblImplementsPlan.Name = "lblImplementsPlan";
            // 
            // tsTransactionView
            // 
            resources.ApplyResources(this.tsTransactionView, "tsTransactionView");
            this.tsTransactionView.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTransactionView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tsbDelete});
            this.tsTransactionView.Name = "tsTransactionView";
            this.tsTransactionView.Stretch = true;
            // 
            // tsbClose
            // 
            this.tsbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbClose.Image = global::easyMoney.Manager.Properties.Resources.tick;
            resources.ApplyResources(this.tsbClose, "tsbClose");
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::easyMoney.Manager.Properties.Resources.delete;
            resources.ApplyResources(this.tsbDelete, "tsbDelete");
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // TransactionViewForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(tscTransactionView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransactionViewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            tscTransactionView.ContentPanel.ResumeLayout(false);
            tscTransactionView.TopToolStripPanel.ResumeLayout(false);
            tscTransactionView.TopToolStripPanel.PerformLayout();
            tscTransactionView.ResumeLayout(false);
            tscTransactionView.PerformLayout();
            this.tlpTemplateTransaction.ResumeLayout(false);
            this.tlpTemplateTransaction.PerformLayout();
            this.gbSource.ResumeLayout(false);
            this.tlpSource.ResumeLayout(false);
            this.tlpSource.PerformLayout();
            this.gbDestination.ResumeLayout(false);
            this.tlpDestination.ResumeLayout(false);
            this.tlpDestination.PerformLayout();
            this.tsTransactionView.ResumeLayout(false);
            this.tsTransactionView.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTransactionView;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.TableLayoutPanel tlpTemplateTransaction;
        private System.Windows.Forms.TextBox tbImplementsPlan;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.TableLayoutPanel tlpSource;
        private System.Windows.Forms.TextBox tbSourceAmount;
        private System.Windows.Forms.TextBox tbSourceAccount;
        private System.Windows.Forms.GroupBox gbDestination;
        private System.Windows.Forms.TableLayoutPanel tlpDestination;
        private System.Windows.Forms.TextBox tbDestinationAccount;
        private System.Windows.Forms.TextBox tbDestinationAmount;
        private System.Windows.Forms.TextBox tbDescription;
        private Controls.TagTextBox ttbTags;
        private System.Windows.Forms.ToolStripButton tsbDelete;
    }
}