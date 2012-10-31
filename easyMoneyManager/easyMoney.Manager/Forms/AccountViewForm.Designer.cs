namespace easyMoney.Manager.Forms
{
    partial class AccountViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountViewForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tlpAccountCorrection = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblTags = new System.Windows.Forms.Label();
            this.ttbTags = new easyMoney.Controls.TagTextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.tbBalance = new System.Windows.Forms.TextBox();
            this.tsAccount = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbBalance = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tlpAccountCorrection.SuspendLayout();
            this.tsAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tlpAccountCorrection);
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsAccount);
            // 
            // tlpAccountCorrection
            // 
            resources.ApplyResources(this.tlpAccountCorrection, "tlpAccountCorrection");
            this.tlpAccountCorrection.Controls.Add(this.lblTitle, 0, 0);
            this.tlpAccountCorrection.Controls.Add(this.lblDescription, 0, 4);
            this.tlpAccountCorrection.Controls.Add(this.tbDescription, 0, 5);
            this.tlpAccountCorrection.Controls.Add(this.lblTags, 0, 6);
            this.tlpAccountCorrection.Controls.Add(this.ttbTags, 0, 7);
            this.tlpAccountCorrection.Controls.Add(this.tbTitle, 0, 1);
            this.tlpAccountCorrection.Controls.Add(this.lblBalance, 0, 2);
            this.tlpAccountCorrection.Controls.Add(this.tbBalance, 0, 3);
            this.tlpAccountCorrection.Name = "tlpAccountCorrection";
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.Name = "lblDescription";
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            // 
            // lblTags
            // 
            resources.ApplyResources(this.lblTags, "lblTags");
            this.lblTags.Name = "lblTags";
            // 
            // ttbTags
            // 
            resources.ApplyResources(this.ttbTags, "ttbTags");
            this.ttbTags.Name = "ttbTags";
            this.ttbTags.PopupOpened = false;
            this.ttbTags.ReadOnly = true;
            this.ttbTags.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("ttbTags.Tags")));
            // 
            // tbTitle
            // 
            this.tbTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.tbTitle, "tbTitle");
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            // 
            // lblBalance
            // 
            resources.ApplyResources(this.lblBalance, "lblBalance");
            this.lblBalance.Name = "lblBalance";
            // 
            // tbBalance
            // 
            resources.ApplyResources(this.tbBalance, "tbBalance");
            this.tbBalance.Name = "tbBalance";
            this.tbBalance.ReadOnly = true;
            // 
            // tsAccount
            // 
            resources.ApplyResources(this.tsAccount, "tsAccount");
            this.tsAccount.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsAccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tsbEdit,
            this.tsbBalance,
            this.tsbDelete});
            this.tsAccount.Name = "tsAccount";
            this.tsAccount.Stretch = true;
            // 
            // tsbClose
            // 
            this.tsbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbClose.Image = global::easyMoney.Manager.Properties.Resources.tick;
            resources.ApplyResources(this.tsbClose, "tsbClose");
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Image = global::easyMoney.Manager.Properties.Resources.pencil;
            resources.ApplyResources(this.tsbEdit, "tsbEdit");
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbBalance
            // 
            this.tsbBalance.Image = global::easyMoney.Manager.Properties.Resources.calculator;
            resources.ApplyResources(this.tsbBalance, "tsbBalance");
            this.tsbBalance.Name = "tsbBalance";
            this.tsbBalance.Click += new System.EventHandler(this.tsbBalance_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::easyMoney.Manager.Properties.Resources.delete;
            resources.ApplyResources(this.tsbDelete, "tsbDelete");
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // AccountViewForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountViewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tlpAccountCorrection.ResumeLayout(false);
            this.tlpAccountCorrection.PerformLayout();
            this.tsAccount.ResumeLayout(false);
            this.tsAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsAccount;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tlpAccountCorrection;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblTags;
        private Controls.TagTextBox ttbTags;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TextBox tbBalance;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbBalance;
        private System.Windows.Forms.ToolStripButton tsbDelete;
    }
}