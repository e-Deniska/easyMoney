namespace easyMoney.Manager.Forms
{
    partial class SettingsForm
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
            System.Windows.Forms.TableLayoutPanel tlpSettings;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            System.Windows.Forms.GroupBox gbUISettings;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.Label lblUISettingAppliedAfterRestart;
            System.Windows.Forms.GroupBox gbCustomMetadata;
            System.Windows.Forms.TableLayoutPanel tlpCustomMetadata;
            System.Windows.Forms.GroupBox gbFileSettings;
            System.Windows.Forms.TableLayoutPanel tlpPortabilitySettings;
            System.Windows.Forms.Label lblPortabilityInfo;
            System.Windows.Forms.Label lblKeepArchivesDays;
            System.Windows.Forms.GroupBox gbConnectivity;
            System.Windows.Forms.TableLayoutPanel tlpConnectivityOptions;
            System.Windows.Forms.Label lblConnectivitySettingsAppliedAfterRestart;
            this.lblInterfaceLanguage = new System.Windows.Forms.Label();
            this.rbLanguageSystemDefault = new System.Windows.Forms.RadioButton();
            this.rbLanguageEnglish = new System.Windows.Forms.RadioButton();
            this.rbLanguageRussian = new System.Windows.Forms.RadioButton();
            this.cbShowFilenameInTitle = new System.Windows.Forms.CheckBox();
            this.btnMetadata = new System.Windows.Forms.Button();
            this.lblMetadataDescription = new System.Windows.Forms.Label();
            this.btnClearCustomMetadata = new System.Windows.Forms.Button();
            this.cbShowOpenDialogEachStart = new System.Windows.Forms.CheckBox();
            this.numKeepArchivesDays = new System.Windows.Forms.NumericUpDown();
            this.cbAllowAutoUpdate = new System.Windows.Forms.CheckBox();
            tlpSettings = new System.Windows.Forms.TableLayoutPanel();
            gbUISettings = new System.Windows.Forms.GroupBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            lblUISettingAppliedAfterRestart = new System.Windows.Forms.Label();
            gbCustomMetadata = new System.Windows.Forms.GroupBox();
            tlpCustomMetadata = new System.Windows.Forms.TableLayoutPanel();
            gbFileSettings = new System.Windows.Forms.GroupBox();
            tlpPortabilitySettings = new System.Windows.Forms.TableLayoutPanel();
            lblPortabilityInfo = new System.Windows.Forms.Label();
            lblKeepArchivesDays = new System.Windows.Forms.Label();
            gbConnectivity = new System.Windows.Forms.GroupBox();
            tlpConnectivityOptions = new System.Windows.Forms.TableLayoutPanel();
            lblConnectivitySettingsAppliedAfterRestart = new System.Windows.Forms.Label();
            tlpSettings.SuspendLayout();
            gbUISettings.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            gbCustomMetadata.SuspendLayout();
            tlpCustomMetadata.SuspendLayout();
            gbFileSettings.SuspendLayout();
            tlpPortabilitySettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKeepArchivesDays)).BeginInit();
            gbConnectivity.SuspendLayout();
            tlpConnectivityOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSettings
            // 
            resources.ApplyResources(tlpSettings, "tlpSettings");
            tlpSettings.Controls.Add(gbUISettings, 0, 0);
            tlpSettings.Controls.Add(gbCustomMetadata, 1, 0);
            tlpSettings.Controls.Add(gbFileSettings, 0, 1);
            tlpSettings.Controls.Add(gbConnectivity, 1, 1);
            tlpSettings.Name = "tlpSettings";
            // 
            // gbUISettings
            // 
            resources.ApplyResources(gbUISettings, "gbUISettings");
            gbUISettings.Controls.Add(tableLayoutPanel1);
            gbUISettings.Name = "gbUISettings";
            gbUISettings.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(this.lblInterfaceLanguage, 0, 0);
            tableLayoutPanel1.Controls.Add(this.rbLanguageSystemDefault, 0, 1);
            tableLayoutPanel1.Controls.Add(this.rbLanguageEnglish, 0, 2);
            tableLayoutPanel1.Controls.Add(this.rbLanguageRussian, 0, 3);
            tableLayoutPanel1.Controls.Add(this.cbShowFilenameInTitle, 0, 4);
            tableLayoutPanel1.Controls.Add(lblUISettingAppliedAfterRestart, 0, 8);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // lblInterfaceLanguage
            // 
            resources.ApplyResources(this.lblInterfaceLanguage, "lblInterfaceLanguage");
            this.lblInterfaceLanguage.Name = "lblInterfaceLanguage";
            // 
            // rbLanguageSystemDefault
            // 
            resources.ApplyResources(this.rbLanguageSystemDefault, "rbLanguageSystemDefault");
            this.rbLanguageSystemDefault.Name = "rbLanguageSystemDefault";
            this.rbLanguageSystemDefault.TabStop = true;
            this.rbLanguageSystemDefault.UseVisualStyleBackColor = true;
            // 
            // rbLanguageEnglish
            // 
            resources.ApplyResources(this.rbLanguageEnglish, "rbLanguageEnglish");
            this.rbLanguageEnglish.Name = "rbLanguageEnglish";
            this.rbLanguageEnglish.TabStop = true;
            this.rbLanguageEnglish.UseVisualStyleBackColor = true;
            // 
            // rbLanguageRussian
            // 
            resources.ApplyResources(this.rbLanguageRussian, "rbLanguageRussian");
            this.rbLanguageRussian.Name = "rbLanguageRussian";
            this.rbLanguageRussian.TabStop = true;
            this.rbLanguageRussian.UseVisualStyleBackColor = true;
            // 
            // cbShowFilenameInTitle
            // 
            resources.ApplyResources(this.cbShowFilenameInTitle, "cbShowFilenameInTitle");
            this.cbShowFilenameInTitle.Name = "cbShowFilenameInTitle";
            this.cbShowFilenameInTitle.UseVisualStyleBackColor = true;
            // 
            // lblUISettingAppliedAfterRestart
            // 
            resources.ApplyResources(lblUISettingAppliedAfterRestart, "lblUISettingAppliedAfterRestart");
            lblUISettingAppliedAfterRestart.Name = "lblUISettingAppliedAfterRestart";
            // 
            // gbCustomMetadata
            // 
            resources.ApplyResources(gbCustomMetadata, "gbCustomMetadata");
            gbCustomMetadata.Controls.Add(tlpCustomMetadata);
            gbCustomMetadata.Name = "gbCustomMetadata";
            gbCustomMetadata.TabStop = false;
            // 
            // tlpCustomMetadata
            // 
            resources.ApplyResources(tlpCustomMetadata, "tlpCustomMetadata");
            tlpCustomMetadata.Controls.Add(this.btnMetadata, 0, 1);
            tlpCustomMetadata.Controls.Add(this.lblMetadataDescription, 0, 0);
            tlpCustomMetadata.Controls.Add(this.btnClearCustomMetadata, 1, 1);
            tlpCustomMetadata.Name = "tlpCustomMetadata";
            // 
            // btnMetadata
            // 
            resources.ApplyResources(this.btnMetadata, "btnMetadata");
            this.btnMetadata.Image = global::easyMoney.Manager.Properties.Resources.page;
            this.btnMetadata.Name = "btnMetadata";
            this.btnMetadata.UseVisualStyleBackColor = true;
            this.btnMetadata.Click += new System.EventHandler(this.btnMetadata_Click);
            // 
            // lblMetadataDescription
            // 
            resources.ApplyResources(this.lblMetadataDescription, "lblMetadataDescription");
            tlpCustomMetadata.SetColumnSpan(this.lblMetadataDescription, 2);
            this.lblMetadataDescription.Name = "lblMetadataDescription";
            // 
            // btnClearCustomMetadata
            // 
            resources.ApplyResources(this.btnClearCustomMetadata, "btnClearCustomMetadata");
            this.btnClearCustomMetadata.Image = global::easyMoney.Manager.Properties.Resources.exclamation;
            this.btnClearCustomMetadata.Name = "btnClearCustomMetadata";
            this.btnClearCustomMetadata.UseVisualStyleBackColor = true;
            this.btnClearCustomMetadata.Click += new System.EventHandler(this.btnClearCustomMetadata_Click);
            // 
            // gbFileSettings
            // 
            resources.ApplyResources(gbFileSettings, "gbFileSettings");
            gbFileSettings.Controls.Add(tlpPortabilitySettings);
            gbFileSettings.Name = "gbFileSettings";
            gbFileSettings.TabStop = false;
            // 
            // tlpPortabilitySettings
            // 
            resources.ApplyResources(tlpPortabilitySettings, "tlpPortabilitySettings");
            tlpPortabilitySettings.Controls.Add(this.cbShowOpenDialogEachStart, 0, 2);
            tlpPortabilitySettings.Controls.Add(lblPortabilityInfo, 0, 3);
            tlpPortabilitySettings.Controls.Add(this.numKeepArchivesDays, 1, 0);
            tlpPortabilitySettings.Controls.Add(lblKeepArchivesDays, 0, 0);
            tlpPortabilitySettings.Name = "tlpPortabilitySettings";
            // 
            // cbShowOpenDialogEachStart
            // 
            resources.ApplyResources(this.cbShowOpenDialogEachStart, "cbShowOpenDialogEachStart");
            tlpPortabilitySettings.SetColumnSpan(this.cbShowOpenDialogEachStart, 2);
            this.cbShowOpenDialogEachStart.Name = "cbShowOpenDialogEachStart";
            this.cbShowOpenDialogEachStart.UseVisualStyleBackColor = true;
            // 
            // lblPortabilityInfo
            // 
            resources.ApplyResources(lblPortabilityInfo, "lblPortabilityInfo");
            tlpPortabilitySettings.SetColumnSpan(lblPortabilityInfo, 2);
            lblPortabilityInfo.Name = "lblPortabilityInfo";
            // 
            // numKeepArchivesDays
            // 
            resources.ApplyResources(this.numKeepArchivesDays, "numKeepArchivesDays");
            this.numKeepArchivesDays.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numKeepArchivesDays.Name = "numKeepArchivesDays";
            // 
            // lblKeepArchivesDays
            // 
            resources.ApplyResources(lblKeepArchivesDays, "lblKeepArchivesDays");
            lblKeepArchivesDays.Name = "lblKeepArchivesDays";
            // 
            // gbConnectivity
            // 
            resources.ApplyResources(gbConnectivity, "gbConnectivity");
            gbConnectivity.Controls.Add(tlpConnectivityOptions);
            gbConnectivity.Name = "gbConnectivity";
            gbConnectivity.TabStop = false;
            // 
            // tlpConnectivityOptions
            // 
            resources.ApplyResources(tlpConnectivityOptions, "tlpConnectivityOptions");
            tlpConnectivityOptions.Controls.Add(lblConnectivitySettingsAppliedAfterRestart, 0, 6);
            tlpConnectivityOptions.Controls.Add(this.cbAllowAutoUpdate, 0, 0);
            tlpConnectivityOptions.Name = "tlpConnectivityOptions";
            // 
            // lblConnectivitySettingsAppliedAfterRestart
            // 
            resources.ApplyResources(lblConnectivitySettingsAppliedAfterRestart, "lblConnectivitySettingsAppliedAfterRestart");
            lblConnectivitySettingsAppliedAfterRestart.Name = "lblConnectivitySettingsAppliedAfterRestart";
            // 
            // cbAllowAutoUpdate
            // 
            resources.ApplyResources(this.cbAllowAutoUpdate, "cbAllowAutoUpdate");
            this.cbAllowAutoUpdate.Name = "cbAllowAutoUpdate";
            this.cbAllowAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(tlpSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            tlpSettings.ResumeLayout(false);
            gbUISettings.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            gbCustomMetadata.ResumeLayout(false);
            tlpCustomMetadata.ResumeLayout(false);
            tlpCustomMetadata.PerformLayout();
            gbFileSettings.ResumeLayout(false);
            tlpPortabilitySettings.ResumeLayout(false);
            tlpPortabilitySettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKeepArchivesDays)).EndInit();
            gbConnectivity.ResumeLayout(false);
            tlpConnectivityOptions.ResumeLayout(false);
            tlpConnectivityOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInterfaceLanguage;
        private System.Windows.Forms.RadioButton rbLanguageSystemDefault;
        private System.Windows.Forms.RadioButton rbLanguageEnglish;
        private System.Windows.Forms.RadioButton rbLanguageRussian;
        private System.Windows.Forms.CheckBox cbShowFilenameInTitle;
        private System.Windows.Forms.Button btnMetadata;
        private System.Windows.Forms.Label lblMetadataDescription;
        private System.Windows.Forms.Button btnClearCustomMetadata;
        private System.Windows.Forms.CheckBox cbShowOpenDialogEachStart;
        private System.Windows.Forms.CheckBox cbAllowAutoUpdate;
        private System.Windows.Forms.NumericUpDown numKeepArchivesDays;
    }
}