namespace easyMoney.Manager.Forms
{
    partial class FileOptionsForm
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
            System.Windows.Forms.TableLayoutPanel tlpFileOptions;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileOptionsForm));
            this.tbPassword2 = new System.Windows.Forms.TextBox();
            this.lblPassword2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbProtectWithPassword = new System.Windows.Forms.CheckBox();
            this.lblPassword1 = new System.Windows.Forms.Label();
            this.tbPassword1 = new System.Windows.Forms.TextBox();
            this.lblPasswordStatus = new System.Windows.Forms.Label();
            tlpFileOptions = new System.Windows.Forms.TableLayoutPanel();
            tlpFileOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpFileOptions
            // 
            resources.ApplyResources(tlpFileOptions, "tlpFileOptions");
            tlpFileOptions.Controls.Add(this.tbPassword2, 1, 3);
            tlpFileOptions.Controls.Add(this.lblPassword2, 0, 3);
            tlpFileOptions.Controls.Add(this.btnOk, 0, 5);
            tlpFileOptions.Controls.Add(this.btnCancel, 1, 5);
            tlpFileOptions.Controls.Add(this.cbProtectWithPassword, 0, 1);
            tlpFileOptions.Controls.Add(this.lblPassword1, 0, 2);
            tlpFileOptions.Controls.Add(this.tbPassword1, 1, 2);
            tlpFileOptions.Controls.Add(this.lblPasswordStatus, 1, 1);
            tlpFileOptions.Name = "tlpFileOptions";
            // 
            // tbPassword2
            // 
            resources.ApplyResources(this.tbPassword2, "tbPassword2");
            this.tbPassword2.Name = "tbPassword2";
            this.tbPassword2.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // lblPassword2
            // 
            resources.ApplyResources(this.lblPassword2, "lblPassword2");
            this.lblPassword2.Name = "lblPassword2";
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
            // cbProtectWithPassword
            // 
            resources.ApplyResources(this.cbProtectWithPassword, "cbProtectWithPassword");
            this.cbProtectWithPassword.Name = "cbProtectWithPassword";
            this.cbProtectWithPassword.UseVisualStyleBackColor = true;
            this.cbProtectWithPassword.CheckedChanged += new System.EventHandler(this.cbProtectWithPassword_CheckedChanged);
            // 
            // lblPassword1
            // 
            resources.ApplyResources(this.lblPassword1, "lblPassword1");
            this.lblPassword1.Name = "lblPassword1";
            // 
            // tbPassword1
            // 
            resources.ApplyResources(this.tbPassword1, "tbPassword1");
            this.tbPassword1.Name = "tbPassword1";
            this.tbPassword1.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // lblPasswordStatus
            // 
            resources.ApplyResources(this.lblPasswordStatus, "lblPasswordStatus");
            this.lblPasswordStatus.Name = "lblPasswordStatus";
            // 
            // FileOptionsForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(tlpFileOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileOptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            tlpFileOptions.ResumeLayout(false);
            tlpFileOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbProtectWithPassword;
        private System.Windows.Forms.TextBox tbPassword2;
        private System.Windows.Forms.TextBox tbPassword1;
        private System.Windows.Forms.Label lblPasswordStatus;
        private System.Windows.Forms.Label lblPassword2;
        private System.Windows.Forms.Label lblPassword1;
    }
}