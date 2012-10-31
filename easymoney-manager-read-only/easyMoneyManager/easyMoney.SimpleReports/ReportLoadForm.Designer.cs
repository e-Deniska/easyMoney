namespace easyMoney.SimpleReports
{
    partial class ReportLoadForm
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
            System.Windows.Forms.Label lblMain;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportLoadForm));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.bgwProcess = new System.ComponentModel.BackgroundWorker();
            lblMain = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMain
            // 
            resources.ApplyResources(lblMain, "lblMain");
            this.tlpMain.SetColumnSpan(lblMain, 2);
            lblMain.Name = "lblMain";
            // 
            // tlpMain
            // 
            resources.ApplyResources(this.tlpMain, "tlpMain");
            this.tlpMain.Controls.Add(this.pbMain, 1, 3);
            this.tlpMain.Controls.Add(lblMain, 1, 1);
            this.tlpMain.Name = "tlpMain";
            // 
            // pbMain
            // 
            resources.ApplyResources(this.pbMain, "pbMain");
            this.tlpMain.SetColumnSpan(this.pbMain, 2);
            this.pbMain.MarqueeAnimationSpeed = 30;
            this.pbMain.Name = "pbMain";
            this.pbMain.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // bgwProcess
            // 
            this.bgwProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProcess_DoWork);
            this.bgwProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProcess_RunWorkerCompleted);
            // 
            // ReportLoadForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportLoadForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.ReportLoadForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        public System.Windows.Forms.ProgressBar pbMain;
        private System.ComponentModel.BackgroundWorker bgwProcess;
    }
}