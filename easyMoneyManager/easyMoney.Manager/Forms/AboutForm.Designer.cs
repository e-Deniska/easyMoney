namespace easyMoney.Manager.Forms
{
    partial class AboutForm
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
            System.Windows.Forms.TableLayoutPanel tlpAbout;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            System.Windows.Forms.GroupBox gbLogo;
            System.Windows.Forms.GroupBox gbThirdPartyComponents;
            System.Windows.Forms.TableLayoutPanel tlpThirdPartyComponents;
            System.Windows.Forms.LinkLabel llblSilkHomepage;
            System.Windows.Forms.Label lblSilkIconSetAuthor;
            System.Windows.Forms.LinkLabel llblIconsLink;
            System.Windows.Forms.Label lblPopupAuthor;
            System.Windows.Forms.Label lblIconsAuthor;
            System.Windows.Forms.LinkLabel llblPopupLink;
            System.Windows.Forms.LinkLabel llblToolStripLink;
            System.Windows.Forms.Label lblToolStripAuthor;
            System.Windows.Forms.GroupBox gbVersionInfo;
            System.Windows.Forms.TableLayoutPanel tlpVersions;
            System.Windows.Forms.Label lblBuildDateLabel;
            System.Windows.Forms.Label lblAssemblyVersion;
            System.Windows.Forms.Label lblApplicationVersion;
            System.Windows.Forms.Label lblAboutApplication;
            System.Windows.Forms.GroupBox gbActions;
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblBuildDate = new System.Windows.Forms.Label();
            this.lblVersionAssembly = new System.Windows.Forms.Label();
            this.lblVersionApplication = new System.Windows.Forms.Label();
            this.tlpMaintenanceActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnCheckForUpdates = new System.Windows.Forms.Button();
            this.lblMaintenanceActions = new System.Windows.Forms.Label();
            this.btnOpenDevelopmentSite = new System.Windows.Forms.Button();
            tlpAbout = new System.Windows.Forms.TableLayoutPanel();
            gbLogo = new System.Windows.Forms.GroupBox();
            gbThirdPartyComponents = new System.Windows.Forms.GroupBox();
            tlpThirdPartyComponents = new System.Windows.Forms.TableLayoutPanel();
            llblSilkHomepage = new System.Windows.Forms.LinkLabel();
            lblSilkIconSetAuthor = new System.Windows.Forms.Label();
            llblIconsLink = new System.Windows.Forms.LinkLabel();
            lblPopupAuthor = new System.Windows.Forms.Label();
            lblIconsAuthor = new System.Windows.Forms.Label();
            llblPopupLink = new System.Windows.Forms.LinkLabel();
            llblToolStripLink = new System.Windows.Forms.LinkLabel();
            lblToolStripAuthor = new System.Windows.Forms.Label();
            gbVersionInfo = new System.Windows.Forms.GroupBox();
            tlpVersions = new System.Windows.Forms.TableLayoutPanel();
            lblBuildDateLabel = new System.Windows.Forms.Label();
            lblAssemblyVersion = new System.Windows.Forms.Label();
            lblApplicationVersion = new System.Windows.Forms.Label();
            lblAboutApplication = new System.Windows.Forms.Label();
            gbActions = new System.Windows.Forms.GroupBox();
            tlpAbout.SuspendLayout();
            gbLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            gbThirdPartyComponents.SuspendLayout();
            tlpThirdPartyComponents.SuspendLayout();
            gbVersionInfo.SuspendLayout();
            tlpVersions.SuspendLayout();
            gbActions.SuspendLayout();
            this.tlpMaintenanceActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAbout
            // 
            resources.ApplyResources(tlpAbout, "tlpAbout");
            tlpAbout.Controls.Add(gbLogo, 0, 0);
            tlpAbout.Controls.Add(gbThirdPartyComponents, 0, 1);
            tlpAbout.Controls.Add(gbVersionInfo, 1, 0);
            tlpAbout.Controls.Add(gbActions, 1, 1);
            tlpAbout.Name = "tlpAbout";
            // 
            // gbLogo
            // 
            gbLogo.Controls.Add(this.pictureBox1);
            resources.ApplyResources(gbLogo, "gbLogo");
            gbLogo.Name = "gbLogo";
            gbLogo.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::easyMoney.Manager.Properties.Resources.Coins_256x256;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // gbThirdPartyComponents
            // 
            gbThirdPartyComponents.Controls.Add(tlpThirdPartyComponents);
            resources.ApplyResources(gbThirdPartyComponents, "gbThirdPartyComponents");
            gbThirdPartyComponents.Name = "gbThirdPartyComponents";
            gbThirdPartyComponents.TabStop = false;
            // 
            // tlpThirdPartyComponents
            // 
            resources.ApplyResources(tlpThirdPartyComponents, "tlpThirdPartyComponents");
            tlpThirdPartyComponents.Controls.Add(llblSilkHomepage, 0, 10);
            tlpThirdPartyComponents.Controls.Add(lblSilkIconSetAuthor, 0, 9);
            tlpThirdPartyComponents.Controls.Add(llblIconsLink, 0, 7);
            tlpThirdPartyComponents.Controls.Add(lblPopupAuthor, 0, 0);
            tlpThirdPartyComponents.Controls.Add(lblIconsAuthor, 0, 6);
            tlpThirdPartyComponents.Controls.Add(llblPopupLink, 0, 1);
            tlpThirdPartyComponents.Controls.Add(llblToolStripLink, 0, 4);
            tlpThirdPartyComponents.Controls.Add(lblToolStripAuthor, 0, 3);
            tlpThirdPartyComponents.Name = "tlpThirdPartyComponents";
            // 
            // llblSilkHomepage
            // 
            resources.ApplyResources(llblSilkHomepage, "llblSilkHomepage");
            llblSilkHomepage.Name = "llblSilkHomepage";
            llblSilkHomepage.TabStop = true;
            llblSilkHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // lblSilkIconSetAuthor
            // 
            resources.ApplyResources(lblSilkIconSetAuthor, "lblSilkIconSetAuthor");
            lblSilkIconSetAuthor.Name = "lblSilkIconSetAuthor";
            // 
            // llblIconsLink
            // 
            resources.ApplyResources(llblIconsLink, "llblIconsLink");
            llblIconsLink.Name = "llblIconsLink";
            llblIconsLink.TabStop = true;
            llblIconsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // lblPopupAuthor
            // 
            resources.ApplyResources(lblPopupAuthor, "lblPopupAuthor");
            lblPopupAuthor.Name = "lblPopupAuthor";
            // 
            // lblIconsAuthor
            // 
            resources.ApplyResources(lblIconsAuthor, "lblIconsAuthor");
            lblIconsAuthor.Name = "lblIconsAuthor";
            // 
            // llblPopupLink
            // 
            resources.ApplyResources(llblPopupLink, "llblPopupLink");
            llblPopupLink.Name = "llblPopupLink";
            llblPopupLink.TabStop = true;
            llblPopupLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // llblToolStripLink
            // 
            resources.ApplyResources(llblToolStripLink, "llblToolStripLink");
            llblToolStripLink.Name = "llblToolStripLink";
            llblToolStripLink.TabStop = true;
            llblToolStripLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // lblToolStripAuthor
            // 
            resources.ApplyResources(lblToolStripAuthor, "lblToolStripAuthor");
            lblToolStripAuthor.Name = "lblToolStripAuthor";
            // 
            // gbVersionInfo
            // 
            gbVersionInfo.Controls.Add(tlpVersions);
            resources.ApplyResources(gbVersionInfo, "gbVersionInfo");
            gbVersionInfo.Name = "gbVersionInfo";
            gbVersionInfo.TabStop = false;
            // 
            // tlpVersions
            // 
            resources.ApplyResources(tlpVersions, "tlpVersions");
            tlpVersions.Controls.Add(this.lblBuildDate, 1, 2);
            tlpVersions.Controls.Add(this.lblVersionAssembly, 1, 1);
            tlpVersions.Controls.Add(lblBuildDateLabel, 0, 2);
            tlpVersions.Controls.Add(lblAssemblyVersion, 0, 1);
            tlpVersions.Controls.Add(lblApplicationVersion, 0, 0);
            tlpVersions.Controls.Add(this.lblVersionApplication, 1, 0);
            tlpVersions.Controls.Add(lblAboutApplication, 0, 3);
            tlpVersions.Name = "tlpVersions";
            // 
            // lblBuildDate
            // 
            resources.ApplyResources(this.lblBuildDate, "lblBuildDate");
            this.lblBuildDate.Name = "lblBuildDate";
            // 
            // lblVersionAssembly
            // 
            resources.ApplyResources(this.lblVersionAssembly, "lblVersionAssembly");
            this.lblVersionAssembly.Name = "lblVersionAssembly";
            // 
            // lblBuildDateLabel
            // 
            resources.ApplyResources(lblBuildDateLabel, "lblBuildDateLabel");
            lblBuildDateLabel.Name = "lblBuildDateLabel";
            // 
            // lblAssemblyVersion
            // 
            resources.ApplyResources(lblAssemblyVersion, "lblAssemblyVersion");
            lblAssemblyVersion.Name = "lblAssemblyVersion";
            // 
            // lblApplicationVersion
            // 
            resources.ApplyResources(lblApplicationVersion, "lblApplicationVersion");
            lblApplicationVersion.Name = "lblApplicationVersion";
            // 
            // lblVersionApplication
            // 
            resources.ApplyResources(this.lblVersionApplication, "lblVersionApplication");
            this.lblVersionApplication.Name = "lblVersionApplication";
            // 
            // lblAboutApplication
            // 
            resources.ApplyResources(lblAboutApplication, "lblAboutApplication");
            tlpVersions.SetColumnSpan(lblAboutApplication, 2);
            lblAboutApplication.Name = "lblAboutApplication";
            // 
            // gbActions
            // 
            gbActions.Controls.Add(this.tlpMaintenanceActions);
            resources.ApplyResources(gbActions, "gbActions");
            gbActions.Name = "gbActions";
            gbActions.TabStop = false;
            // 
            // tlpMaintenanceActions
            // 
            resources.ApplyResources(this.tlpMaintenanceActions, "tlpMaintenanceActions");
            this.tlpMaintenanceActions.Controls.Add(this.btnCheckForUpdates, 1, 1);
            this.tlpMaintenanceActions.Controls.Add(this.lblMaintenanceActions, 0, 0);
            this.tlpMaintenanceActions.Controls.Add(this.btnOpenDevelopmentSite, 0, 1);
            this.tlpMaintenanceActions.Name = "tlpMaintenanceActions";
            // 
            // btnCheckForUpdates
            // 
            resources.ApplyResources(this.btnCheckForUpdates, "btnCheckForUpdates");
            this.btnCheckForUpdates.Image = global::easyMoney.Manager.Properties.Resources.lightbulb;
            this.btnCheckForUpdates.Name = "btnCheckForUpdates";
            this.btnCheckForUpdates.UseVisualStyleBackColor = true;
            this.btnCheckForUpdates.Click += new System.EventHandler(this.btnCheckForUpdates_Click);
            // 
            // lblMaintenanceActions
            // 
            resources.ApplyResources(this.lblMaintenanceActions, "lblMaintenanceActions");
            this.tlpMaintenanceActions.SetColumnSpan(this.lblMaintenanceActions, 2);
            this.lblMaintenanceActions.Name = "lblMaintenanceActions";
            // 
            // btnOpenDevelopmentSite
            // 
            resources.ApplyResources(this.btnOpenDevelopmentSite, "btnOpenDevelopmentSite");
            this.btnOpenDevelopmentSite.Image = global::easyMoney.Manager.Properties.Resources.world;
            this.btnOpenDevelopmentSite.Name = "btnOpenDevelopmentSite";
            this.btnOpenDevelopmentSite.UseVisualStyleBackColor = true;
            this.btnOpenDevelopmentSite.Click += new System.EventHandler(this.btnOpenDevelopmentSite_Click);
            // 
            // AboutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(tlpAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            tlpAbout.ResumeLayout(false);
            gbLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            gbThirdPartyComponents.ResumeLayout(false);
            tlpThirdPartyComponents.ResumeLayout(false);
            tlpThirdPartyComponents.PerformLayout();
            gbVersionInfo.ResumeLayout(false);
            tlpVersions.ResumeLayout(false);
            tlpVersions.PerformLayout();
            gbActions.ResumeLayout(false);
            this.tlpMaintenanceActions.ResumeLayout(false);
            this.tlpMaintenanceActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblBuildDate;
        private System.Windows.Forms.Label lblVersionAssembly;
        private System.Windows.Forms.Label lblVersionApplication;
        private System.Windows.Forms.TableLayoutPanel tlpMaintenanceActions;
        private System.Windows.Forms.Button btnCheckForUpdates;
        private System.Windows.Forms.Label lblMaintenanceActions;
        private System.Windows.Forms.Button btnOpenDevelopmentSite;
    }
}