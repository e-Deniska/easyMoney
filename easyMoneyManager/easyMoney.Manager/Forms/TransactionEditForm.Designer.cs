namespace easyMoney.Manager.Forms
{
    partial class TransactionEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionEditForm));
            this.tlpTemplateTransaction = new System.Windows.Forms.TableLayoutPanel();
            this.gbTransactionMessage = new System.Windows.Forms.GroupBox();
            this.lblTransactionMessage = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.tlpSource = new System.Windows.Forms.TableLayoutPanel();
            this.lblSourceAccount = new System.Windows.Forms.Label();
            this.cbSourceAccount = new System.Windows.Forms.ComboBox();
            this.lblSourceAmount = new System.Windows.Forms.Label();
            this.numSourceAmount = new System.Windows.Forms.NumericUpDown();
            this.lblSourceCurrency = new System.Windows.Forms.Label();
            this.cbSourceImplementsPlan = new System.Windows.Forms.CheckBox();
            this.cbSourcePlan = new System.Windows.Forms.ComboBox();
            this.lblSourceBalance = new System.Windows.Forms.Label();
            this.gbDestination = new System.Windows.Forms.GroupBox();
            this.tlpDestination = new System.Windows.Forms.TableLayoutPanel();
            this.lblDestinationBalance = new System.Windows.Forms.Label();
            this.cbDestinationPlan = new System.Windows.Forms.ComboBox();
            this.lblDestinationAccount = new System.Windows.Forms.Label();
            this.cbDestinationAccount = new System.Windows.Forms.ComboBox();
            this.lblDestinationAmount = new System.Windows.Forms.Label();
            this.numDestinationAmount = new System.Windows.Forms.NumericUpDown();
            this.lblDestinationCurrency = new System.Windows.Forms.Label();
            this.cbDestinationImplementsPlan = new System.Windows.Forms.CheckBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblTags = new System.Windows.Forms.Label();
            this.ttbTags = new easyMoney.Controls.TagTextBox();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTransactionDate = new System.Windows.Forms.Label();
            this.dtpTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.tlpTemplateTransaction.SuspendLayout();
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
            // tlpTemplateTransaction
            // 
            resources.ApplyResources(this.tlpTemplateTransaction, "tlpTemplateTransaction");
            this.tlpTemplateTransaction.Controls.Add(this.gbTransactionMessage, 0, 1);
            this.tlpTemplateTransaction.Controls.Add(this.lblTitle, 0, 2);
            this.tlpTemplateTransaction.Controls.Add(this.tbTitle, 0, 3);
            this.tlpTemplateTransaction.Controls.Add(this.gbSource, 0, 4);
            this.tlpTemplateTransaction.Controls.Add(this.gbDestination, 1, 4);
            this.tlpTemplateTransaction.Controls.Add(this.lblDescription, 0, 5);
            this.tlpTemplateTransaction.Controls.Add(this.tbDescription, 0, 6);
            this.tlpTemplateTransaction.Controls.Add(this.lblTags, 0, 7);
            this.tlpTemplateTransaction.Controls.Add(this.ttbTags, 0, 8);
            this.tlpTemplateTransaction.Controls.Add(this.tlpButtons, 0, 9);
            this.tlpTemplateTransaction.Controls.Add(this.lblTransactionDate, 1, 2);
            this.tlpTemplateTransaction.Controls.Add(this.dtpTransactionDate, 1, 3);
            this.tlpTemplateTransaction.Name = "tlpTemplateTransaction";
            // 
            // gbTransactionMessage
            // 
            this.tlpTemplateTransaction.SetColumnSpan(this.gbTransactionMessage, 2);
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
            this.tlpSource.Controls.Add(this.lblSourceAccount, 0, 2);
            this.tlpSource.Controls.Add(this.cbSourceAccount, 0, 3);
            this.tlpSource.Controls.Add(this.lblSourceAmount, 0, 5);
            this.tlpSource.Controls.Add(this.numSourceAmount, 0, 6);
            this.tlpSource.Controls.Add(this.lblSourceCurrency, 2, 6);
            this.tlpSource.Controls.Add(this.cbSourceImplementsPlan, 0, 0);
            this.tlpSource.Controls.Add(this.cbSourcePlan, 0, 1);
            this.tlpSource.Controls.Add(this.lblSourceBalance, 0, 4);
            this.tlpSource.Name = "tlpSource";
            // 
            // lblSourceAccount
            // 
            resources.ApplyResources(this.lblSourceAccount, "lblSourceAccount");
            this.tlpSource.SetColumnSpan(this.lblSourceAccount, 3);
            this.lblSourceAccount.Name = "lblSourceAccount";
            // 
            // cbSourceAccount
            // 
            this.tlpSource.SetColumnSpan(this.cbSourceAccount, 3);
            resources.ApplyResources(this.cbSourceAccount, "cbSourceAccount");
            this.cbSourceAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceAccount.FormattingEnabled = true;
            this.cbSourceAccount.Name = "cbSourceAccount";
            this.cbSourceAccount.SelectionChangeCommitted += new System.EventHandler(this.cbSourceAccount_SelectionChangeCommitted);
            // 
            // lblSourceAmount
            // 
            resources.ApplyResources(this.lblSourceAmount, "lblSourceAmount");
            this.tlpSource.SetColumnSpan(this.lblSourceAmount, 3);
            this.lblSourceAmount.Name = "lblSourceAmount";
            // 
            // numSourceAmount
            // 
            this.tlpSource.SetColumnSpan(this.numSourceAmount, 2);
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
            // lblSourceCurrency
            // 
            resources.ApplyResources(this.lblSourceCurrency, "lblSourceCurrency");
            this.lblSourceCurrency.Name = "lblSourceCurrency";
            // 
            // cbSourceImplementsPlan
            // 
            resources.ApplyResources(this.cbSourceImplementsPlan, "cbSourceImplementsPlan");
            this.tlpSource.SetColumnSpan(this.cbSourceImplementsPlan, 3);
            this.cbSourceImplementsPlan.Name = "cbSourceImplementsPlan";
            this.cbSourceImplementsPlan.UseVisualStyleBackColor = true;
            this.cbSourceImplementsPlan.CheckedChanged += new System.EventHandler(this.cbSourceImplementsPlan_CheckedChanged);
            // 
            // cbSourcePlan
            // 
            this.tlpSource.SetColumnSpan(this.cbSourcePlan, 3);
            resources.ApplyResources(this.cbSourcePlan, "cbSourcePlan");
            this.cbSourcePlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourcePlan.FormattingEnabled = true;
            this.cbSourcePlan.Name = "cbSourcePlan";
            this.cbSourcePlan.SelectionChangeCommitted += new System.EventHandler(this.cbSourcePlan_SelectionChangeCommitted);
            // 
            // lblSourceBalance
            // 
            resources.ApplyResources(this.lblSourceBalance, "lblSourceBalance");
            this.tlpSource.SetColumnSpan(this.lblSourceBalance, 3);
            this.lblSourceBalance.Name = "lblSourceBalance";
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
            this.tlpDestination.Controls.Add(this.lblDestinationBalance, 0, 4);
            this.tlpDestination.Controls.Add(this.cbDestinationPlan, 0, 1);
            this.tlpDestination.Controls.Add(this.lblDestinationAccount, 0, 2);
            this.tlpDestination.Controls.Add(this.cbDestinationAccount, 0, 3);
            this.tlpDestination.Controls.Add(this.lblDestinationAmount, 0, 5);
            this.tlpDestination.Controls.Add(this.numDestinationAmount, 0, 6);
            this.tlpDestination.Controls.Add(this.lblDestinationCurrency, 2, 6);
            this.tlpDestination.Controls.Add(this.cbDestinationImplementsPlan, 0, 0);
            this.tlpDestination.Name = "tlpDestination";
            // 
            // lblDestinationBalance
            // 
            resources.ApplyResources(this.lblDestinationBalance, "lblDestinationBalance");
            this.tlpDestination.SetColumnSpan(this.lblDestinationBalance, 3);
            this.lblDestinationBalance.Name = "lblDestinationBalance";
            // 
            // cbDestinationPlan
            // 
            this.tlpDestination.SetColumnSpan(this.cbDestinationPlan, 3);
            resources.ApplyResources(this.cbDestinationPlan, "cbDestinationPlan");
            this.cbDestinationPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestinationPlan.FormattingEnabled = true;
            this.cbDestinationPlan.Name = "cbDestinationPlan";
            this.cbDestinationPlan.SelectionChangeCommitted += new System.EventHandler(this.cbDestinationPlan_SelectionChangeCommitted);
            // 
            // lblDestinationAccount
            // 
            resources.ApplyResources(this.lblDestinationAccount, "lblDestinationAccount");
            this.tlpDestination.SetColumnSpan(this.lblDestinationAccount, 3);
            this.lblDestinationAccount.Name = "lblDestinationAccount";
            // 
            // cbDestinationAccount
            // 
            this.tlpDestination.SetColumnSpan(this.cbDestinationAccount, 3);
            resources.ApplyResources(this.cbDestinationAccount, "cbDestinationAccount");
            this.cbDestinationAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestinationAccount.FormattingEnabled = true;
            this.cbDestinationAccount.Name = "cbDestinationAccount";
            this.cbDestinationAccount.SelectionChangeCommitted += new System.EventHandler(this.cbDestinationAccount_SelectionChangeCommitted);
            // 
            // lblDestinationAmount
            // 
            resources.ApplyResources(this.lblDestinationAmount, "lblDestinationAmount");
            this.tlpDestination.SetColumnSpan(this.lblDestinationAmount, 3);
            this.lblDestinationAmount.Name = "lblDestinationAmount";
            // 
            // numDestinationAmount
            // 
            this.tlpDestination.SetColumnSpan(this.numDestinationAmount, 2);
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
            // lblDestinationCurrency
            // 
            resources.ApplyResources(this.lblDestinationCurrency, "lblDestinationCurrency");
            this.lblDestinationCurrency.Name = "lblDestinationCurrency";
            // 
            // cbDestinationImplementsPlan
            // 
            resources.ApplyResources(this.cbDestinationImplementsPlan, "cbDestinationImplementsPlan");
            this.tlpDestination.SetColumnSpan(this.cbDestinationImplementsPlan, 3);
            this.cbDestinationImplementsPlan.Name = "cbDestinationImplementsPlan";
            this.cbDestinationImplementsPlan.UseVisualStyleBackColor = true;
            this.cbDestinationImplementsPlan.CheckedChanged += new System.EventHandler(this.cbDestinationImplementsPlan_CheckedChanged);
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.tlpTemplateTransaction.SetColumnSpan(this.lblDescription, 2);
            this.lblDescription.Name = "lblDescription";
            // 
            // tbDescription
            // 
            this.tlpTemplateTransaction.SetColumnSpan(this.tbDescription, 2);
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            // 
            // lblTags
            // 
            resources.ApplyResources(this.lblTags, "lblTags");
            this.tlpTemplateTransaction.SetColumnSpan(this.lblTags, 2);
            this.lblTags.Name = "lblTags";
            // 
            // ttbTags
            // 
            this.tlpTemplateTransaction.SetColumnSpan(this.ttbTags, 2);
            resources.ApplyResources(this.ttbTags, "ttbTags");
            this.ttbTags.Name = "ttbTags";
            this.ttbTags.PopupOpened = false;
            this.ttbTags.ReadOnly = false;
            this.ttbTags.Tags = ((System.Collections.Generic.IEnumerable<string>)(resources.GetObject("ttbTags.Tags")));
            // 
            // tlpButtons
            // 
            resources.ApplyResources(this.tlpButtons, "tlpButtons");
            this.tlpTemplateTransaction.SetColumnSpan(this.tlpButtons, 2);
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
            // lblTransactionDate
            // 
            resources.ApplyResources(this.lblTransactionDate, "lblTransactionDate");
            this.lblTransactionDate.Name = "lblTransactionDate";
            // 
            // dtpTransactionDate
            // 
            resources.ApplyResources(this.dtpTransactionDate, "dtpTransactionDate");
            this.dtpTransactionDate.Name = "dtpTransactionDate";
            // 
            // TransactionEditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpTemplateTransaction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransactionEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TransactionFromTemplateForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TransactionFromTemplateForm_KeyDown);
            this.tlpTemplateTransaction.ResumeLayout(false);
            this.tlpTemplateTransaction.PerformLayout();
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

        private System.Windows.Forms.TableLayoutPanel tlpTemplateTransaction;
        private System.Windows.Forms.GroupBox gbTransactionMessage;
        private System.Windows.Forms.Label lblTransactionMessage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.TableLayoutPanel tlpSource;
        private System.Windows.Forms.Label lblSourceAccount;
        private System.Windows.Forms.ComboBox cbSourceAccount;
        private System.Windows.Forms.Label lblSourceAmount;
        private System.Windows.Forms.NumericUpDown numSourceAmount;
        private System.Windows.Forms.Label lblSourceCurrency;
        private System.Windows.Forms.GroupBox gbDestination;
        private System.Windows.Forms.TableLayoutPanel tlpDestination;
        private System.Windows.Forms.Label lblDestinationAccount;
        private System.Windows.Forms.ComboBox cbDestinationAccount;
        private System.Windows.Forms.Label lblDestinationAmount;
        private System.Windows.Forms.NumericUpDown numDestinationAmount;
        private System.Windows.Forms.Label lblDestinationCurrency;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblTags;
        private Controls.TagTextBox ttbTags;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.CheckBox cbSourceImplementsPlan;
        private System.Windows.Forms.ComboBox cbSourcePlan;
        private System.Windows.Forms.ComboBox cbDestinationPlan;
        private System.Windows.Forms.CheckBox cbDestinationImplementsPlan;
        private System.Windows.Forms.Label lblSourceBalance;
        private System.Windows.Forms.Label lblDestinationBalance;
        private System.Windows.Forms.Label lblTransactionDate;
        private System.Windows.Forms.DateTimePicker dtpTransactionDate;
    }
}