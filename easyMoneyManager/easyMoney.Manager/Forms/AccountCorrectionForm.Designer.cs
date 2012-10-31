namespace easyMoney.Manager.Forms
{
    partial class AccountCorrectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountCorrectionForm));
            this.tlpAccountCorrection = new System.Windows.Forms.TableLayoutPanel();
            this.gbTransactionMessage = new System.Windows.Forms.GroupBox();
            this.lblTransactionMessage = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.cbAccount = new System.Windows.Forms.ComboBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.tlpBalance = new System.Windows.Forms.TableLayoutPanel();
            this.numBalance = new System.Windows.Forms.NumericUpDown();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblTags = new System.Windows.Forms.Label();
            this.ttbTags = new easyMoney.Controls.TagTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpAccountCorrection.SuspendLayout();
            this.gbTransactionMessage.SuspendLayout();
            this.tlpBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpAccountCorrection
            // 
            resources.ApplyResources(this.tlpAccountCorrection, "tlpAccountCorrection");
            this.tlpAccountCorrection.Controls.Add(this.gbTransactionMessage, 0, 1);
            this.tlpAccountCorrection.Controls.Add(this.lblAccount, 0, 2);
            this.tlpAccountCorrection.Controls.Add(this.cbAccount, 0, 3);
            this.tlpAccountCorrection.Controls.Add(this.lblBalance, 0, 4);
            this.tlpAccountCorrection.Controls.Add(this.tlpBalance, 0, 5);
            this.tlpAccountCorrection.Controls.Add(this.lblDescription, 0, 6);
            this.tlpAccountCorrection.Controls.Add(this.tbDescription, 0, 7);
            this.tlpAccountCorrection.Controls.Add(this.lblTags, 0, 8);
            this.tlpAccountCorrection.Controls.Add(this.ttbTags, 0, 9);
            this.tlpAccountCorrection.Controls.Add(this.btnOk, 0, 10);
            this.tlpAccountCorrection.Controls.Add(this.btnCancel, 1, 10);
            this.tlpAccountCorrection.Name = "tlpAccountCorrection";
            // 
            // gbTransactionMessage
            // 
            resources.ApplyResources(this.gbTransactionMessage, "gbTransactionMessage");
            this.tlpAccountCorrection.SetColumnSpan(this.gbTransactionMessage, 2);
            this.gbTransactionMessage.Controls.Add(this.lblTransactionMessage);
            this.gbTransactionMessage.Name = "gbTransactionMessage";
            this.gbTransactionMessage.TabStop = false;
            // 
            // lblTransactionMessage
            // 
            this.lblTransactionMessage.AutoEllipsis = true;
            resources.ApplyResources(this.lblTransactionMessage, "lblTransactionMessage");
            this.lblTransactionMessage.MinimumSize = new System.Drawing.Size(288, 31);
            this.lblTransactionMessage.Name = "lblTransactionMessage";
            // 
            // lblAccount
            // 
            resources.ApplyResources(this.lblAccount, "lblAccount");
            this.tlpAccountCorrection.SetColumnSpan(this.lblAccount, 2);
            this.lblAccount.Name = "lblAccount";
            // 
            // cbAccount
            // 
            this.tlpAccountCorrection.SetColumnSpan(this.cbAccount, 2);
            resources.ApplyResources(this.cbAccount, "cbAccount");
            this.cbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccount.FormattingEnabled = true;
            this.cbAccount.Name = "cbAccount";
            this.cbAccount.SelectionChangeCommitted += new System.EventHandler(this.cbAccount_SelectionChangeCommitted);
            // 
            // lblBalance
            // 
            resources.ApplyResources(this.lblBalance, "lblBalance");
            this.tlpAccountCorrection.SetColumnSpan(this.lblBalance, 2);
            this.lblBalance.Name = "lblBalance";
            // 
            // tlpBalance
            // 
            resources.ApplyResources(this.tlpBalance, "tlpBalance");
            this.tlpAccountCorrection.SetColumnSpan(this.tlpBalance, 2);
            this.tlpBalance.Controls.Add(this.numBalance, 0, 0);
            this.tlpBalance.Controls.Add(this.lblCurrency, 2, 0);
            this.tlpBalance.Name = "tlpBalance";
            // 
            // numBalance
            // 
            this.tlpBalance.SetColumnSpan(this.numBalance, 2);
            this.numBalance.DecimalPlaces = 2;
            resources.ApplyResources(this.numBalance, "numBalance");
            this.numBalance.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.numBalance.Minimum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            -2147483648});
            this.numBalance.Name = "numBalance";
            // 
            // lblCurrency
            // 
            resources.ApplyResources(this.lblCurrency, "lblCurrency");
            this.lblCurrency.Name = "lblCurrency";
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.tlpAccountCorrection.SetColumnSpan(this.lblDescription, 2);
            this.lblDescription.Name = "lblDescription";
            // 
            // tbDescription
            // 
            this.tlpAccountCorrection.SetColumnSpan(this.tbDescription, 2);
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            // 
            // lblTags
            // 
            resources.ApplyResources(this.lblTags, "lblTags");
            this.tlpAccountCorrection.SetColumnSpan(this.lblTags, 2);
            this.lblTags.Name = "lblTags";
            // 
            // ttbTags
            // 
            this.tlpAccountCorrection.SetColumnSpan(this.ttbTags, 2);
            resources.ApplyResources(this.ttbTags, "ttbTags");
            this.ttbTags.Name = "ttbTags";
            this.ttbTags.PopupOpened = false;
            this.ttbTags.ReadOnly = false;
            this.ttbTags.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("ttbTags.Tags")));
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
            // AccountCorrectionForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tlpAccountCorrection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountCorrectionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.AccountCorrectionForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountCorrectionForm_KeyDown);
            this.tlpAccountCorrection.ResumeLayout(false);
            this.tlpAccountCorrection.PerformLayout();
            this.gbTransactionMessage.ResumeLayout(false);
            this.tlpBalance.ResumeLayout(false);
            this.tlpBalance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBalance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpAccountCorrection;
        private System.Windows.Forms.GroupBox gbTransactionMessage;
        private System.Windows.Forms.Label lblTransactionMessage;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox cbAccount;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TableLayoutPanel tlpBalance;
        private System.Windows.Forms.NumericUpDown numBalance;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblTags;
        private Controls.TagTextBox ttbTags;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}