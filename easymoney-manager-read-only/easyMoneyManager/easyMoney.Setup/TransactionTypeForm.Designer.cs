namespace easyMoney.Setup
{
    partial class TransactionTypeForm
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
            System.Windows.Forms.Label lblID;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionTypeForm));
            System.Windows.Forms.Label lblTitle;
            System.Windows.Forms.Label lblCulture;
            this.tlpTransactionType = new System.Windows.Forms.TableLayoutPanel();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.cbIsIncome = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            lblID = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            lblCulture = new System.Windows.Forms.Label();
            this.tlpTransactionType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblID
            // 
            resources.ApplyResources(lblID, "lblID");
            lblID.Name = "lblID";
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            lblTitle.Name = "lblTitle";
            // 
            // lblCulture
            // 
            resources.ApplyResources(lblCulture, "lblCulture");
            lblCulture.Name = "lblCulture";
            // 
            // tlpTransactionType
            // 
            resources.ApplyResources(this.tlpTransactionType, "tlpTransactionType");
            this.tlpTransactionType.Controls.Add(lblID, 0, 0);
            this.tlpTransactionType.Controls.Add(lblTitle, 0, 1);
            this.tlpTransactionType.Controls.Add(lblCulture, 0, 2);
            this.tlpTransactionType.Controls.Add(this.tbID, 1, 0);
            this.tlpTransactionType.Controls.Add(this.tbTitle, 1, 1);
            this.tlpTransactionType.Controls.Add(this.tbDescription, 1, 2);
            this.tlpTransactionType.Controls.Add(this.cbIsIncome, 1, 3);
            this.tlpTransactionType.Controls.Add(this.btnDelete, 0, 5);
            this.tlpTransactionType.Controls.Add(this.btnOk, 2, 5);
            this.tlpTransactionType.Controls.Add(this.btnCancel, 3, 5);
            this.tlpTransactionType.Name = "tlpTransactionType";
            // 
            // tbID
            // 
            this.tlpTransactionType.SetColumnSpan(this.tbID, 3);
            resources.ApplyResources(this.tbID, "tbID");
            this.tbID.Name = "tbID";
            // 
            // tbTitle
            // 
            this.tlpTransactionType.SetColumnSpan(this.tbTitle, 3);
            resources.ApplyResources(this.tbTitle, "tbTitle");
            this.tbTitle.Name = "tbTitle";
            // 
            // tbDescription
            // 
            this.tlpTransactionType.SetColumnSpan(this.tbDescription, 3);
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            // 
            // cbIsIncome
            // 
            resources.ApplyResources(this.cbIsIncome, "cbIsIncome");
            this.tlpTransactionType.SetColumnSpan(this.cbIsIncome, 3);
            this.cbIsIncome.Name = "cbIsIncome";
            this.cbIsIncome.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Image = global::easyMoney.Setup.Properties.Resources.delete;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Image = global::easyMoney.Setup.Properties.Resources.tick;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Image = global::easyMoney.Setup.Properties.Resources.cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TransactionTypeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpTransactionType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransactionTypeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TransactionTypeForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TransactionTypeForm_KeyDown);
            this.tlpTransactionType.ResumeLayout(false);
            this.tlpTransactionType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTransactionType;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.CheckBox cbIsIncome;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}