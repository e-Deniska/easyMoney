namespace easyMoney.Manager
{
    partial class TemplateSelectorForm
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
            System.Windows.Forms.TableLayoutPanel tlpTemplateSelector;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateSelectorForm));
            this.lbTemplates = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            tlpTemplateSelector = new System.Windows.Forms.TableLayoutPanel();
            tlpTemplateSelector.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTemplateSelector
            // 
            resources.ApplyResources(tlpTemplateSelector, "tlpTemplateSelector");
            tlpTemplateSelector.Controls.Add(this.lbTemplates, 0, 1);
            tlpTemplateSelector.Controls.Add(this.btnOk, 0, 2);
            tlpTemplateSelector.Controls.Add(this.btnCancel, 1, 2);
            tlpTemplateSelector.Name = "tlpTemplateSelector";
            // 
            // lbTemplates
            // 
            tlpTemplateSelector.SetColumnSpan(this.lbTemplates, 2);
            resources.ApplyResources(this.lbTemplates, "lbTemplates");
            this.lbTemplates.FormattingEnabled = true;
            this.lbTemplates.Name = "lbTemplates";
            this.lbTemplates.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbTemplates_MouseDoubleClick);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Image = global::easyMoney.Manager.Properties.Resources.tick;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Image = global::easyMoney.Manager.Properties.Resources.cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // TemplateSelectorForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(tlpTemplateSelector);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateSelectorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TemplateSelectorForm_Load);
            tlpTemplateSelector.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbTemplates;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}