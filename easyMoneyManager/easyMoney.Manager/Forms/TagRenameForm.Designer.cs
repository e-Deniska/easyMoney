namespace easyMoney.Manager.Forms
{
    partial class TagRenameForm
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
            System.Windows.Forms.TableLayoutPanel tlpRenameTag;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagRenameForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbTag = new System.Windows.Forms.TextBox();
            tlpRenameTag = new System.Windows.Forms.TableLayoutPanel();
            tlpRenameTag.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRenameTag
            // 
            resources.ApplyResources(tlpRenameTag, "tlpRenameTag");
            tlpRenameTag.Controls.Add(this.btnOk, 0, 3);
            tlpRenameTag.Controls.Add(this.btnCancel, 1, 3);
            tlpRenameTag.Controls.Add(this.tbTag, 0, 1);
            tlpRenameTag.Name = "tlpRenameTag";
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
            // tbTag
            // 
            tlpRenameTag.SetColumnSpan(this.tbTag, 2);
            resources.ApplyResources(this.tbTag, "tbTag");
            this.tbTag.Name = "tbTag";
            // 
            // TagRenameForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(tlpRenameTag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagRenameForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            tlpRenameTag.ResumeLayout(false);
            tlpRenameTag.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbTag;
    }
}