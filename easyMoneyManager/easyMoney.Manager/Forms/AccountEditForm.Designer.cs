namespace easyMoney.Manager.Forms
{
    partial class AccountEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountEditForm));
            this.tlpAccountCorrection = new System.Windows.Forms.TableLayoutPanel();
            this.gbAccountInformationMessage = new System.Windows.Forms.GroupBox();
            this.lblAccountInformationMessage = new System.Windows.Forms.Label();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.cbAccountType = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblTags = new System.Windows.Forms.Label();
            this.ttbTags = new easyMoney.Controls.TagTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblAccountCurrency = new System.Windows.Forms.Label();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.cbHideAccount = new System.Windows.Forms.CheckBox();
            this.tlpAccountCorrection.SuspendLayout();
            this.gbAccountInformationMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAccountCorrection
            // 
            resources.ApplyResources(this.tlpAccountCorrection, "tlpAccountCorrection");
            this.tlpAccountCorrection.Controls.Add(this.gbAccountInformationMessage, 0, 1);
            this.tlpAccountCorrection.Controls.Add(this.lblAccountType, 0, 2);
            this.tlpAccountCorrection.Controls.Add(this.cbAccountType, 0, 3);
            this.tlpAccountCorrection.Controls.Add(this.lblTitle, 0, 4);
            this.tlpAccountCorrection.Controls.Add(this.lblDescription, 0, 7);
            this.tlpAccountCorrection.Controls.Add(this.tbDescription, 0, 8);
            this.tlpAccountCorrection.Controls.Add(this.lblTags, 0, 10);
            this.tlpAccountCorrection.Controls.Add(this.ttbTags, 0, 11);
            this.tlpAccountCorrection.Controls.Add(this.btnOk, 0, 12);
            this.tlpAccountCorrection.Controls.Add(this.btnCancel, 1, 12);
            this.tlpAccountCorrection.Controls.Add(this.tbTitle, 0, 5);
            this.tlpAccountCorrection.Controls.Add(this.lblBalance, 0, 6);
            this.tlpAccountCorrection.Controls.Add(this.lblAccountCurrency, 1, 2);
            this.tlpAccountCorrection.Controls.Add(this.cbCurrency, 1, 3);
            this.tlpAccountCorrection.Controls.Add(this.cbHideAccount, 0, 9);
            this.tlpAccountCorrection.Name = "tlpAccountCorrection";
            // 
            // gbAccountInformationMessage
            // 
            resources.ApplyResources(this.gbAccountInformationMessage, "gbAccountInformationMessage");
            this.tlpAccountCorrection.SetColumnSpan(this.gbAccountInformationMessage, 2);
            this.gbAccountInformationMessage.Controls.Add(this.lblAccountInformationMessage);
            this.gbAccountInformationMessage.Name = "gbAccountInformationMessage";
            this.gbAccountInformationMessage.TabStop = false;
            // 
            // lblAccountInformationMessage
            // 
            this.lblAccountInformationMessage.AutoEllipsis = true;
            resources.ApplyResources(this.lblAccountInformationMessage, "lblAccountInformationMessage");
            this.lblAccountInformationMessage.MinimumSize = new System.Drawing.Size(288, 31);
            this.lblAccountInformationMessage.Name = "lblAccountInformationMessage";
            // 
            // lblAccountType
            // 
            resources.ApplyResources(this.lblAccountType, "lblAccountType");
            this.lblAccountType.Name = "lblAccountType";
            // 
            // cbAccountType
            // 
            resources.ApplyResources(this.cbAccountType, "cbAccountType");
            this.cbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccountType.FormattingEnabled = true;
            this.cbAccountType.Name = "cbAccountType";
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.tlpAccountCorrection.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Name = "lblTitle";
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
            // tbTitle
            // 
            this.tbTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tlpAccountCorrection.SetColumnSpan(this.tbTitle, 2);
            resources.ApplyResources(this.tbTitle, "tbTitle");
            this.tbTitle.Name = "tbTitle";
            // 
            // lblBalance
            // 
            resources.ApplyResources(this.lblBalance, "lblBalance");
            this.tlpAccountCorrection.SetColumnSpan(this.lblBalance, 2);
            this.lblBalance.Name = "lblBalance";
            // 
            // lblAccountCurrency
            // 
            resources.ApplyResources(this.lblAccountCurrency, "lblAccountCurrency");
            this.lblAccountCurrency.Name = "lblAccountCurrency";
            // 
            // cbCurrency
            // 
            resources.ApplyResources(this.cbCurrency, "cbCurrency");
            this.cbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Name = "cbCurrency";
            // 
            // cbHideAccount
            // 
            resources.ApplyResources(this.cbHideAccount, "cbHideAccount");
            this.tlpAccountCorrection.SetColumnSpan(this.cbHideAccount, 2);
            this.cbHideAccount.Name = "cbHideAccount";
            this.cbHideAccount.UseVisualStyleBackColor = true;
            // 
            // AccountEditForm
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
            this.Name = "AccountEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.AccountEditForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountEditForm_KeyDown);
            this.tlpAccountCorrection.ResumeLayout(false);
            this.tlpAccountCorrection.PerformLayout();
            this.gbAccountInformationMessage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpAccountCorrection;
        private System.Windows.Forms.GroupBox gbAccountInformationMessage;
        private System.Windows.Forms.Label lblAccountInformationMessage;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.ComboBox cbAccountType;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblTags;
        private Controls.TagTextBox ttbTags;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblAccountCurrency;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.CheckBox cbHideAccount;
    }
}