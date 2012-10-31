namespace easyMoney.Controls
{
    partial class IntroductionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroductionForm));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.rtbPageText = new System.Windows.Forms.RichTextBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            resources.ApplyResources(this.tlpMain, "tlpMain");
            this.tlpMain.Controls.Add(this.lblPageTitle, 1, 1);
            this.tlpMain.Controls.Add(this.rtbPageText, 1, 3);
            this.tlpMain.Controls.Add(this.btnPrevious, 2, 5);
            this.tlpMain.Controls.Add(this.btnNext, 4, 5);
            this.tlpMain.Controls.Add(this.btnFinish, 6, 5);
            this.tlpMain.Name = "tlpMain";
            // 
            // lblPageTitle
            // 
            resources.ApplyResources(this.lblPageTitle, "lblPageTitle");
            this.tlpMain.SetColumnSpan(this.lblPageTitle, 6);
            this.lblPageTitle.Name = "lblPageTitle";
            // 
            // rtbPageText
            // 
            this.tlpMain.SetColumnSpan(this.rtbPageText, 6);
            resources.ApplyResources(this.rtbPageText, "rtbPageText");
            this.rtbPageText.Name = "rtbPageText";
            this.rtbPageText.ReadOnly = true;
            // 
            // btnPrevious
            // 
            resources.ApplyResources(this.btnPrevious, "btnPrevious");
            this.btnPrevious.Image = global::easyMoney.Controls.Properties.Resources.arrow_left;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Image = global::easyMoney.Controls.Properties.Resources.arrow_right;
            this.btnNext.Name = "btnNext";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnFinish, "btnFinish");
            this.btnFinish.Image = global::easyMoney.Controls.Properties.Resources.tick;
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // IntroductionForm
            // 
            this.AcceptButton = this.btnNext;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnFinish;
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "IntroductionForm";
            this.Load += new System.EventHandler(this.ManualWizardForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.RichTextBox rtbPageText;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFinish;
    }
}