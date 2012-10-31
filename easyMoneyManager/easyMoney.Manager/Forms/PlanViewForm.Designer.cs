namespace easyMoney.Manager.Forms
{
    partial class PlanViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanViewForm));
            System.Windows.Forms.Label lblDescription;
            System.Windows.Forms.Label lblTags;
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tlpTemplatePlan = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.tlpSource = new System.Windows.Forms.TableLayoutPanel();
            this.lblSourceAccountType = new System.Windows.Forms.Label();
            this.lblSourceAmount = new System.Windows.Forms.Label();
            this.tbSourceAccountType = new System.Windows.Forms.TextBox();
            this.tbSourceAmount = new System.Windows.Forms.TextBox();
            this.gbDestination = new System.Windows.Forms.GroupBox();
            this.tlpDestination = new System.Windows.Forms.TableLayoutPanel();
            this.lblDestinationAccountType = new System.Windows.Forms.Label();
            this.lblDestinationAmount = new System.Windows.Forms.Label();
            this.tbDestinationAccountType = new System.Windows.Forms.TextBox();
            this.tbDestinationAmount = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.ttbTags = new easyMoney.Controls.TagTextBox();
            this.tsPlans = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbImplement = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            lblDescription = new System.Windows.Forms.Label();
            lblTags = new System.Windows.Forms.Label();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tlpTemplatePlan.SuspendLayout();
            this.gbSource.SuspendLayout();
            this.tlpSource.SuspendLayout();
            this.gbDestination.SuspendLayout();
            this.tlpDestination.SuspendLayout();
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tlpTemplatePlan);
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
            // tlpTemplatePlan
            // 
            resources.ApplyResources(this.tlpTemplatePlan, "tlpTemplatePlan");
            this.tlpTemplatePlan.Controls.Add(this.lblTitle, 0, 0);
            this.tlpTemplatePlan.Controls.Add(this.tbTitle, 0, 1);
            this.tlpTemplatePlan.Controls.Add(this.gbSource, 0, 2);
            this.tlpTemplatePlan.Controls.Add(this.gbDestination, 1, 2);
            this.tlpTemplatePlan.Controls.Add(lblDescription, 0, 3);
            this.tlpTemplatePlan.Controls.Add(this.tbDescription, 0, 4);
            this.tlpTemplatePlan.Controls.Add(lblTags, 0, 5);
            this.tlpTemplatePlan.Controls.Add(this.ttbTags, 0, 6);
            this.tlpTemplatePlan.Name = "tlpTemplatePlan";
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.tlpTemplatePlan.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Name = "lblTitle";
            // 
            // tbTitle
            // 
            resources.ApplyResources(this.tbTitle, "tbTitle");
            this.tbTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tlpTemplatePlan.SetColumnSpan(this.tbTitle, 2);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            // 
            // gbSource
            // 
            resources.ApplyResources(this.gbSource, "gbSource");
            this.gbSource.Controls.Add(this.tlpSource);
            this.gbSource.Name = "gbSource";
            this.gbSource.TabStop = false;
            // 
            // tlpSource
            // 
            resources.ApplyResources(this.tlpSource, "tlpSource");
            this.tlpSource.Controls.Add(this.lblSourceAccountType, 0, 0);
            this.tlpSource.Controls.Add(this.lblSourceAmount, 0, 2);
            this.tlpSource.Controls.Add(this.tbSourceAccountType, 0, 1);
            this.tlpSource.Controls.Add(this.tbSourceAmount, 0, 3);
            this.tlpSource.Name = "tlpSource";
            // 
            // lblSourceAccountType
            // 
            resources.ApplyResources(this.lblSourceAccountType, "lblSourceAccountType");
            this.lblSourceAccountType.Name = "lblSourceAccountType";
            // 
            // lblSourceAmount
            // 
            resources.ApplyResources(this.lblSourceAmount, "lblSourceAmount");
            this.lblSourceAmount.Name = "lblSourceAmount";
            // 
            // tbSourceAccountType
            // 
            resources.ApplyResources(this.tbSourceAccountType, "tbSourceAccountType");
            this.tbSourceAccountType.Name = "tbSourceAccountType";
            this.tbSourceAccountType.ReadOnly = true;
            // 
            // tbSourceAmount
            // 
            resources.ApplyResources(this.tbSourceAmount, "tbSourceAmount");
            this.tbSourceAmount.Name = "tbSourceAmount";
            this.tbSourceAmount.ReadOnly = true;
            // 
            // gbDestination
            // 
            resources.ApplyResources(this.gbDestination, "gbDestination");
            this.gbDestination.Controls.Add(this.tlpDestination);
            this.gbDestination.Name = "gbDestination";
            this.gbDestination.TabStop = false;
            // 
            // tlpDestination
            // 
            resources.ApplyResources(this.tlpDestination, "tlpDestination");
            this.tlpDestination.Controls.Add(this.lblDestinationAccountType, 0, 0);
            this.tlpDestination.Controls.Add(this.lblDestinationAmount, 0, 2);
            this.tlpDestination.Controls.Add(this.tbDestinationAccountType, 0, 1);
            this.tlpDestination.Controls.Add(this.tbDestinationAmount, 0, 3);
            this.tlpDestination.Name = "tlpDestination";
            // 
            // lblDestinationAccountType
            // 
            resources.ApplyResources(this.lblDestinationAccountType, "lblDestinationAccountType");
            this.lblDestinationAccountType.Name = "lblDestinationAccountType";
            // 
            // lblDestinationAmount
            // 
            resources.ApplyResources(this.lblDestinationAmount, "lblDestinationAmount");
            this.lblDestinationAmount.Name = "lblDestinationAmount";
            // 
            // tbDestinationAccountType
            // 
            resources.ApplyResources(this.tbDestinationAccountType, "tbDestinationAccountType");
            this.tbDestinationAccountType.Name = "tbDestinationAccountType";
            this.tbDestinationAccountType.ReadOnly = true;
            // 
            // tbDestinationAmount
            // 
            resources.ApplyResources(this.tbDestinationAmount, "tbDestinationAmount");
            this.tbDestinationAmount.Name = "tbDestinationAmount";
            this.tbDestinationAmount.ReadOnly = true;
            // 
            // lblDescription
            // 
            resources.ApplyResources(lblDescription, "lblDescription");
            this.tlpTemplatePlan.SetColumnSpan(lblDescription, 2);
            lblDescription.Name = "lblDescription";
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tlpTemplatePlan.SetColumnSpan(this.tbDescription, 2);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            // 
            // lblTags
            // 
            resources.ApplyResources(lblTags, "lblTags");
            this.tlpTemplatePlan.SetColumnSpan(lblTags, 2);
            lblTags.Name = "lblTags";
            // 
            // ttbTags
            // 
            resources.ApplyResources(this.ttbTags, "ttbTags");
            this.tlpTemplatePlan.SetColumnSpan(this.ttbTags, 2);
            this.ttbTags.Name = "ttbTags";
            this.ttbTags.PopupOpened = false;
            this.ttbTags.ReadOnly = true;
            this.ttbTags.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("ttbTags.Tags")));
            // 
            // tsPlans
            // 
            resources.ApplyResources(this.tsPlans, "tsPlans");
            this.tsPlans.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPlans.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tsbEdit,
            this.tsbCopy,
            this.tsbImplement,
            this.tsbDelete});
            this.tsPlans.Name = "tsPlans";
            this.tsPlans.Stretch = true;
            // 
            // tsbClose
            // 
            resources.ApplyResources(this.tsbClose, "tsbClose");
            this.tsbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbClose.Image = global::easyMoney.Manager.Properties.Resources.tick;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
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
            // PlanViewForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlanViewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tlpTemplatePlan.ResumeLayout(false);
            this.tlpTemplatePlan.PerformLayout();
            this.gbSource.ResumeLayout(false);
            this.tlpSource.ResumeLayout(false);
            this.tlpSource.PerformLayout();
            this.gbDestination.ResumeLayout(false);
            this.tlpDestination.ResumeLayout(false);
            this.tlpDestination.PerformLayout();
            this.tsPlans.ResumeLayout(false);
            this.tsPlans.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPlans;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tlpTemplatePlan;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.TableLayoutPanel tlpSource;
        private System.Windows.Forms.Label lblSourceAccountType;
        private System.Windows.Forms.Label lblSourceAmount;
        private System.Windows.Forms.GroupBox gbDestination;
        private System.Windows.Forms.TableLayoutPanel tlpDestination;
        private System.Windows.Forms.Label lblDestinationAccountType;
        private System.Windows.Forms.Label lblDestinationAmount;
        private System.Windows.Forms.TextBox tbDescription;
        private Controls.TagTextBox ttbTags;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.TextBox tbSourceAccountType;
        private System.Windows.Forms.TextBox tbSourceAmount;
        private System.Windows.Forms.TextBox tbDestinationAccountType;
        private System.Windows.Forms.TextBox tbDestinationAmount;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbImplement;
        private System.Windows.Forms.ToolStripButton tsbCopy;
    }
}