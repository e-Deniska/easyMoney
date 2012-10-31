namespace easyMoney.Setup
{
    partial class CustomMetadataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMetadataForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tlpCustomMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbAccountTypes = new System.Windows.Forms.GroupBox();
            this.lbAccountTypes = new System.Windows.Forms.ListBox();
            this.gbTransactionTypes = new System.Windows.Forms.GroupBox();
            this.lbTransactionTypes = new System.Windows.Forms.ListBox();
            this.gbTemplates = new System.Windows.Forms.GroupBox();
            this.lbTemplates = new System.Windows.Forms.ListBox();
            this.gbCurrencies = new System.Windows.Forms.GroupBox();
            this.lbCurrencies = new System.Windows.Forms.ListBox();
            this.tsMetadata = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbAddCurrency = new System.Windows.Forms.ToolStripButton();
            this.tsbAddAccountType = new System.Windows.Forms.ToolStripButton();
            this.tsbAddTransactionType = new System.Windows.Forms.ToolStripButton();
            this.tsbAddTemplate = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tlpCustomMain.SuspendLayout();
            this.gbAccountTypes.SuspendLayout();
            this.gbTransactionTypes.SuspendLayout();
            this.gbTemplates.SuspendLayout();
            this.gbCurrencies.SuspendLayout();
            this.tsMetadata.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.BottomToolStripPanel, "toolStripContainer1.BottomToolStripPanel");
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tlpCustomMain);
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.LeftToolStripPanel, "toolStripContainer1.LeftToolStripPanel");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.RightToolStripPanel, "toolStripContainer1.RightToolStripPanel");
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.TopToolStripPanel, "toolStripContainer1.TopToolStripPanel");
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsMetadata);
            // 
            // tlpCustomMain
            // 
            resources.ApplyResources(this.tlpCustomMain, "tlpCustomMain");
            this.tlpCustomMain.Controls.Add(this.gbAccountTypes, 1, 0);
            this.tlpCustomMain.Controls.Add(this.gbTransactionTypes, 2, 0);
            this.tlpCustomMain.Controls.Add(this.gbTemplates, 3, 0);
            this.tlpCustomMain.Controls.Add(this.gbCurrencies, 0, 0);
            this.tlpCustomMain.Name = "tlpCustomMain";
            // 
            // gbAccountTypes
            // 
            resources.ApplyResources(this.gbAccountTypes, "gbAccountTypes");
            this.gbAccountTypes.Controls.Add(this.lbAccountTypes);
            this.gbAccountTypes.Name = "gbAccountTypes";
            this.gbAccountTypes.TabStop = false;
            // 
            // lbAccountTypes
            // 
            resources.ApplyResources(this.lbAccountTypes, "lbAccountTypes");
            this.lbAccountTypes.FormattingEnabled = true;
            this.lbAccountTypes.Name = "lbAccountTypes";
            this.lbAccountTypes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbAccountTypes_KeyDown);
            this.lbAccountTypes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbAccountTypes_MouseDoubleClick);
            // 
            // gbTransactionTypes
            // 
            resources.ApplyResources(this.gbTransactionTypes, "gbTransactionTypes");
            this.gbTransactionTypes.Controls.Add(this.lbTransactionTypes);
            this.gbTransactionTypes.Name = "gbTransactionTypes";
            this.gbTransactionTypes.TabStop = false;
            // 
            // lbTransactionTypes
            // 
            resources.ApplyResources(this.lbTransactionTypes, "lbTransactionTypes");
            this.lbTransactionTypes.FormattingEnabled = true;
            this.lbTransactionTypes.Name = "lbTransactionTypes";
            this.lbTransactionTypes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbTransactionTypes_KeyDown);
            this.lbTransactionTypes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbTransactionTypes_MouseDoubleClick);
            // 
            // gbTemplates
            // 
            resources.ApplyResources(this.gbTemplates, "gbTemplates");
            this.gbTemplates.Controls.Add(this.lbTemplates);
            this.gbTemplates.Name = "gbTemplates";
            this.gbTemplates.TabStop = false;
            // 
            // lbTemplates
            // 
            resources.ApplyResources(this.lbTemplates, "lbTemplates");
            this.lbTemplates.FormattingEnabled = true;
            this.lbTemplates.Name = "lbTemplates";
            this.lbTemplates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbTemplates_KeyDown);
            this.lbTemplates.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbTemplates_MouseDoubleClick);
            // 
            // gbCurrencies
            // 
            resources.ApplyResources(this.gbCurrencies, "gbCurrencies");
            this.gbCurrencies.Controls.Add(this.lbCurrencies);
            this.gbCurrencies.Name = "gbCurrencies";
            this.gbCurrencies.TabStop = false;
            // 
            // lbCurrencies
            // 
            resources.ApplyResources(this.lbCurrencies, "lbCurrencies");
            this.lbCurrencies.FormattingEnabled = true;
            this.lbCurrencies.Name = "lbCurrencies";
            this.lbCurrencies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbCurrencies_KeyDown);
            this.lbCurrencies.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCurrencies_MouseDoubleClick);
            // 
            // tsMetadata
            // 
            resources.ApplyResources(this.tsMetadata, "tsMetadata");
            this.tsMetadata.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMetadata.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tsbAddCurrency,
            this.tsbAddAccountType,
            this.tsbAddTransactionType,
            this.tsbAddTemplate});
            this.tsMetadata.Name = "tsMetadata";
            this.tsMetadata.Stretch = true;
            // 
            // tsbClose
            // 
            resources.ApplyResources(this.tsbClose, "tsbClose");
            this.tsbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbClose.Image = global::easyMoney.Setup.Properties.Resources.tick;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tsbAddCurrency
            // 
            resources.ApplyResources(this.tsbAddCurrency, "tsbAddCurrency");
            this.tsbAddCurrency.Image = global::easyMoney.Setup.Properties.Resources.money_dollar;
            this.tsbAddCurrency.Name = "tsbAddCurrency";
            this.tsbAddCurrency.Click += new System.EventHandler(this.tsbAddCurrency_Click);
            // 
            // tsbAddAccountType
            // 
            resources.ApplyResources(this.tsbAddAccountType, "tsbAddAccountType");
            this.tsbAddAccountType.Image = global::easyMoney.Setup.Properties.Resources.book;
            this.tsbAddAccountType.Name = "tsbAddAccountType";
            this.tsbAddAccountType.Click += new System.EventHandler(this.tsbAddAccountType_Click);
            // 
            // tsbAddTransactionType
            // 
            resources.ApplyResources(this.tsbAddTransactionType, "tsbAddTransactionType");
            this.tsbAddTransactionType.Image = global::easyMoney.Setup.Properties.Resources.application_form;
            this.tsbAddTransactionType.Name = "tsbAddTransactionType";
            this.tsbAddTransactionType.Click += new System.EventHandler(this.tsbAddTransactionType_Click);
            // 
            // tsbAddTemplate
            // 
            resources.ApplyResources(this.tsbAddTemplate, "tsbAddTemplate");
            this.tsbAddTemplate.Image = global::easyMoney.Setup.Properties.Resources.page;
            this.tsbAddTemplate.Name = "tsbAddTemplate";
            this.tsbAddTemplate.Click += new System.EventHandler(this.tsbAddTemplate_Click);
            // 
            // CustomMetadataForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomMetadataForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.CustomMetadataForm_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tlpCustomMain.ResumeLayout(false);
            this.gbAccountTypes.ResumeLayout(false);
            this.gbTransactionTypes.ResumeLayout(false);
            this.gbTemplates.ResumeLayout(false);
            this.gbCurrencies.ResumeLayout(false);
            this.tsMetadata.ResumeLayout(false);
            this.tsMetadata.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCustomMain;
        private System.Windows.Forms.GroupBox gbAccountTypes;
        private System.Windows.Forms.ListBox lbAccountTypes;
        private System.Windows.Forms.GroupBox gbTransactionTypes;
        private System.Windows.Forms.ListBox lbTransactionTypes;
        private System.Windows.Forms.GroupBox gbTemplates;
        private System.Windows.Forms.ListBox lbTemplates;
        private System.Windows.Forms.GroupBox gbCurrencies;
        private System.Windows.Forms.ListBox lbCurrencies;
        private System.Windows.Forms.ToolStrip tsMetadata;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripButton tsbAddCurrency;
        private System.Windows.Forms.ToolStripButton tsbAddAccountType;
        private System.Windows.Forms.ToolStripButton tsbAddTransactionType;
        private System.Windows.Forms.ToolStripButton tsbAddTemplate;
    }
}