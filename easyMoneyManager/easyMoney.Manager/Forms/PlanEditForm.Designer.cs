namespace easyMoney.Manager.Forms
{
    partial class PlanEditForm
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
            System.Windows.Forms.GroupBox gbDateRecurrency;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlanEditForm));
            this.tlpPlannedDateRecurrency = new System.Windows.Forms.TableLayoutPanel();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblRecurrency = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cbRecurrency = new System.Windows.Forms.ComboBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.tlpTemplatePlan = new System.Windows.Forms.TableLayoutPanel();
            this.gbTransactionMessage = new System.Windows.Forms.GroupBox();
            this.lblTransactionMessage = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.tlpSource = new System.Windows.Forms.TableLayoutPanel();
            this.lblSourceAccountType = new System.Windows.Forms.Label();
            this.cbSourceAccountType = new System.Windows.Forms.ComboBox();
            this.lblSourceAmount = new System.Windows.Forms.Label();
            this.numSourceAmount = new System.Windows.Forms.NumericUpDown();
            this.cbSourceCurrency = new System.Windows.Forms.ComboBox();
            this.gbDestination = new System.Windows.Forms.GroupBox();
            this.tlpDestination = new System.Windows.Forms.TableLayoutPanel();
            this.lblDestinationAccountType = new System.Windows.Forms.Label();
            this.cbDestinationAccountType = new System.Windows.Forms.ComboBox();
            this.lblDestinationAmount = new System.Windows.Forms.Label();
            this.numDestinationAmount = new System.Windows.Forms.NumericUpDown();
            this.cbDestinationCurrency = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblTags = new System.Windows.Forms.Label();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbIsAggregated = new System.Windows.Forms.CheckBox();
            this.ttbTags = new easyMoney.Controls.TagTextBox();
            gbDateRecurrency = new System.Windows.Forms.GroupBox();
            gbDateRecurrency.SuspendLayout();
            this.tlpPlannedDateRecurrency.SuspendLayout();
            this.tlpTemplatePlan.SuspendLayout();
            this.gbTransactionMessage.SuspendLayout();
            this.gbSource.SuspendLayout();
            this.tlpSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSourceAmount)).BeginInit();
            this.gbDestination.SuspendLayout();
            this.tlpDestination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDestinationAmount)).BeginInit();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDateRecurrency
            // 
            this.tlpTemplatePlan.SetColumnSpan(gbDateRecurrency, 2);
            gbDateRecurrency.Controls.Add(this.tlpPlannedDateRecurrency);
            resources.ApplyResources(gbDateRecurrency, "gbDateRecurrency");
            gbDateRecurrency.Name = "gbDateRecurrency";
            gbDateRecurrency.TabStop = false;
            // 
            // tlpPlannedDateRecurrency
            // 
            resources.ApplyResources(this.tlpPlannedDateRecurrency, "tlpPlannedDateRecurrency");
            this.tlpPlannedDateRecurrency.Controls.Add(this.lblStartDate, 0, 0);
            this.tlpPlannedDateRecurrency.Controls.Add(this.lblRecurrency, 1, 0);
            this.tlpPlannedDateRecurrency.Controls.Add(this.lblEndDate, 2, 0);
            this.tlpPlannedDateRecurrency.Controls.Add(this.dtpStartDate, 0, 1);
            this.tlpPlannedDateRecurrency.Controls.Add(this.cbRecurrency, 1, 1);
            this.tlpPlannedDateRecurrency.Controls.Add(this.dtpEndDate, 2, 1);
            this.tlpPlannedDateRecurrency.Name = "tlpPlannedDateRecurrency";
            // 
            // lblStartDate
            // 
            resources.ApplyResources(this.lblStartDate, "lblStartDate");
            this.lblStartDate.Name = "lblStartDate";
            // 
            // lblRecurrency
            // 
            resources.ApplyResources(this.lblRecurrency, "lblRecurrency");
            this.lblRecurrency.Name = "lblRecurrency";
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
            this.dtpStartDate.ShowCheckBox = true;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // cbRecurrency
            // 
            resources.ApplyResources(this.cbRecurrency, "cbRecurrency");
            this.cbRecurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecurrency.FormattingEnabled = true;
            this.cbRecurrency.Name = "cbRecurrency";
            this.cbRecurrency.SelectionChangeCommitted += new System.EventHandler(this.cbRecurrency_SelectionChangeCommitted);
            // 
            // dtpEndDate
            // 
            resources.ApplyResources(this.dtpEndDate, "dtpEndDate");
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowCheckBox = true;
            // 
            // tlpTemplatePlan
            // 
            resources.ApplyResources(this.tlpTemplatePlan, "tlpTemplatePlan");
            this.tlpTemplatePlan.Controls.Add(this.gbTransactionMessage, 0, 1);
            this.tlpTemplatePlan.Controls.Add(this.lblTitle, 0, 2);
            this.tlpTemplatePlan.Controls.Add(this.tbTitle, 0, 3);
            this.tlpTemplatePlan.Controls.Add(this.gbSource, 0, 4);
            this.tlpTemplatePlan.Controls.Add(this.gbDestination, 1, 4);
            this.tlpTemplatePlan.Controls.Add(this.lblDescription, 0, 6);
            this.tlpTemplatePlan.Controls.Add(this.tbDescription, 0, 7);
            this.tlpTemplatePlan.Controls.Add(this.lblTags, 0, 8);
            this.tlpTemplatePlan.Controls.Add(this.ttbTags, 0, 9);
            this.tlpTemplatePlan.Controls.Add(this.tlpButtons, 0, 10);
            this.tlpTemplatePlan.Controls.Add(gbDateRecurrency, 0, 5);
            this.tlpTemplatePlan.Controls.Add(this.cbIsAggregated, 1, 3);
            this.tlpTemplatePlan.Name = "tlpTemplatePlan";
            // 
            // gbTransactionMessage
            // 
            this.tlpTemplatePlan.SetColumnSpan(this.gbTransactionMessage, 2);
            this.gbTransactionMessage.Controls.Add(this.lblTransactionMessage);
            resources.ApplyResources(this.gbTransactionMessage, "gbTransactionMessage");
            this.gbTransactionMessage.Name = "gbTransactionMessage";
            this.gbTransactionMessage.TabStop = false;
            // 
            // lblTransactionMessage
            // 
            this.lblTransactionMessage.AutoEllipsis = true;
            resources.ApplyResources(this.lblTransactionMessage, "lblTransactionMessage");
            this.lblTransactionMessage.Name = "lblTransactionMessage";
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // tbTitle
            // 
            this.tbTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.tbTitle, "tbTitle");
            this.tbTitle.Name = "tbTitle";
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
            this.tlpSource.Controls.Add(this.lblSourceAccountType, 0, 0);
            this.tlpSource.Controls.Add(this.cbSourceAccountType, 0, 1);
            this.tlpSource.Controls.Add(this.lblSourceAmount, 0, 2);
            this.tlpSource.Controls.Add(this.numSourceAmount, 0, 3);
            this.tlpSource.Controls.Add(this.cbSourceCurrency, 1, 3);
            this.tlpSource.Name = "tlpSource";
            // 
            // lblSourceAccountType
            // 
            resources.ApplyResources(this.lblSourceAccountType, "lblSourceAccountType");
            this.tlpSource.SetColumnSpan(this.lblSourceAccountType, 2);
            this.lblSourceAccountType.Name = "lblSourceAccountType";
            // 
            // cbSourceAccountType
            // 
            this.tlpSource.SetColumnSpan(this.cbSourceAccountType, 2);
            resources.ApplyResources(this.cbSourceAccountType, "cbSourceAccountType");
            this.cbSourceAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceAccountType.FormattingEnabled = true;
            this.cbSourceAccountType.Name = "cbSourceAccountType";
            // 
            // lblSourceAmount
            // 
            resources.ApplyResources(this.lblSourceAmount, "lblSourceAmount");
            this.tlpSource.SetColumnSpan(this.lblSourceAmount, 2);
            this.lblSourceAmount.Name = "lblSourceAmount";
            // 
            // numSourceAmount
            // 
            this.numSourceAmount.DecimalPlaces = 2;
            resources.ApplyResources(this.numSourceAmount, "numSourceAmount");
            this.numSourceAmount.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.numSourceAmount.Minimum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            -2147483648});
            this.numSourceAmount.Name = "numSourceAmount";
            this.numSourceAmount.ValueChanged += new System.EventHandler(this.numSourceAmount_ValueChanged);
            // 
            // cbSourceCurrency
            // 
            resources.ApplyResources(this.cbSourceCurrency, "cbSourceCurrency");
            this.cbSourceCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceCurrency.FormattingEnabled = true;
            this.cbSourceCurrency.Name = "cbSourceCurrency";
            this.cbSourceCurrency.SelectionChangeCommitted += new System.EventHandler(this.cbSourceCurrency_SelectionChangeCommitted);
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
            this.tlpDestination.Controls.Add(this.lblDestinationAccountType, 0, 0);
            this.tlpDestination.Controls.Add(this.cbDestinationAccountType, 0, 1);
            this.tlpDestination.Controls.Add(this.lblDestinationAmount, 0, 2);
            this.tlpDestination.Controls.Add(this.numDestinationAmount, 0, 3);
            this.tlpDestination.Controls.Add(this.cbDestinationCurrency, 1, 3);
            this.tlpDestination.Name = "tlpDestination";
            // 
            // lblDestinationAccountType
            // 
            resources.ApplyResources(this.lblDestinationAccountType, "lblDestinationAccountType");
            this.tlpDestination.SetColumnSpan(this.lblDestinationAccountType, 2);
            this.lblDestinationAccountType.Name = "lblDestinationAccountType";
            // 
            // cbDestinationAccountType
            // 
            this.tlpDestination.SetColumnSpan(this.cbDestinationAccountType, 2);
            resources.ApplyResources(this.cbDestinationAccountType, "cbDestinationAccountType");
            this.cbDestinationAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestinationAccountType.FormattingEnabled = true;
            this.cbDestinationAccountType.Name = "cbDestinationAccountType";
            // 
            // lblDestinationAmount
            // 
            resources.ApplyResources(this.lblDestinationAmount, "lblDestinationAmount");
            this.tlpDestination.SetColumnSpan(this.lblDestinationAmount, 2);
            this.lblDestinationAmount.Name = "lblDestinationAmount";
            // 
            // numDestinationAmount
            // 
            this.numDestinationAmount.DecimalPlaces = 2;
            resources.ApplyResources(this.numDestinationAmount, "numDestinationAmount");
            this.numDestinationAmount.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.numDestinationAmount.Minimum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            -2147483648});
            this.numDestinationAmount.Name = "numDestinationAmount";
            // 
            // cbDestinationCurrency
            // 
            resources.ApplyResources(this.cbDestinationCurrency, "cbDestinationCurrency");
            this.cbDestinationCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestinationCurrency.FormattingEnabled = true;
            this.cbDestinationCurrency.Name = "cbDestinationCurrency";
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.tlpTemplatePlan.SetColumnSpan(this.lblDescription, 2);
            this.lblDescription.Name = "lblDescription";
            // 
            // tbDescription
            // 
            this.tlpTemplatePlan.SetColumnSpan(this.tbDescription, 2);
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            // 
            // lblTags
            // 
            resources.ApplyResources(this.lblTags, "lblTags");
            this.tlpTemplatePlan.SetColumnSpan(this.lblTags, 2);
            this.lblTags.Name = "lblTags";
            // 
            // tlpButtons
            // 
            resources.ApplyResources(this.tlpButtons, "tlpButtons");
            this.tlpTemplatePlan.SetColumnSpan(this.tlpButtons, 2);
            this.tlpButtons.Controls.Add(this.btnOk, 0, 0);
            this.tlpButtons.Controls.Add(this.btnCancel, 1, 0);
            this.tlpButtons.Name = "tlpButtons";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Image = global::easyMoney.Manager.Properties.Resources.tick;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Image = global::easyMoney.Manager.Properties.Resources.cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbIsAggregated
            // 
            resources.ApplyResources(this.cbIsAggregated, "cbIsAggregated");
            this.cbIsAggregated.Name = "cbIsAggregated";
            this.cbIsAggregated.UseVisualStyleBackColor = true;
            // 
            // ttbTags
            // 
            this.tlpTemplatePlan.SetColumnSpan(this.ttbTags, 2);
            resources.ApplyResources(this.ttbTags, "ttbTags");
            this.ttbTags.Name = "ttbTags";
            this.ttbTags.PopupOpened = false;
            this.ttbTags.ReadOnly = false;
            this.ttbTags.Tags = ((System.Collections.Generic.IEnumerable<string>)(resources.GetObject("ttbTags.Tags")));
            // 
            // PlanEditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpTemplatePlan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlanEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.PlanFromTemplateForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TransactionFromTemplateForm_KeyDown);
            gbDateRecurrency.ResumeLayout(false);
            this.tlpPlannedDateRecurrency.ResumeLayout(false);
            this.tlpPlannedDateRecurrency.PerformLayout();
            this.tlpTemplatePlan.ResumeLayout(false);
            this.tlpTemplatePlan.PerformLayout();
            this.gbTransactionMessage.ResumeLayout(false);
            this.gbSource.ResumeLayout(false);
            this.tlpSource.ResumeLayout(false);
            this.tlpSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSourceAmount)).EndInit();
            this.gbDestination.ResumeLayout(false);
            this.tlpDestination.ResumeLayout(false);
            this.tlpDestination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDestinationAmount)).EndInit();
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTemplatePlan;
        private System.Windows.Forms.GroupBox gbTransactionMessage;
        private System.Windows.Forms.Label lblTransactionMessage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.TableLayoutPanel tlpSource;
        private System.Windows.Forms.Label lblSourceAccountType;
        private System.Windows.Forms.ComboBox cbSourceAccountType;
        private System.Windows.Forms.Label lblSourceAmount;
        private System.Windows.Forms.NumericUpDown numSourceAmount;
        private System.Windows.Forms.GroupBox gbDestination;
        private System.Windows.Forms.TableLayoutPanel tlpDestination;
        private System.Windows.Forms.Label lblDestinationAccountType;
        private System.Windows.Forms.ComboBox cbDestinationAccountType;
        private System.Windows.Forms.Label lblDestinationAmount;
        private System.Windows.Forms.NumericUpDown numDestinationAmount;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblTags;
        private Controls.TagTextBox ttbTags;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.ComboBox cbSourceCurrency;
        private System.Windows.Forms.ComboBox cbDestinationCurrency;
        private System.Windows.Forms.TableLayoutPanel tlpPlannedDateRecurrency;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblRecurrency;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cbRecurrency;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.CheckBox cbIsAggregated;
    }
}