namespace easyMoney.Controls
{
    partial class TagTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbTags = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbTags
            // 
            this.tbTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTags.Location = new System.Drawing.Point(0, 0);
            this.tbTags.MaxLength = 0;
            this.tbTags.Name = "tbTags";
            this.tbTags.Size = new System.Drawing.Size(140, 20);
            this.tbTags.TabIndex = 0;
            this.tbTags.TextChanged += new System.EventHandler(this.tbTags_TextChanged);
            this.tbTags.Enter += new System.EventHandler(this.tbTags_Enter);
            this.tbTags.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTags_KeyDown);
            this.tbTags.Leave += new System.EventHandler(this.tbTags_Leave);
            this.tbTags.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbTags_PreviewKeyDown);
            // 
            // TagTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbTags);
            this.Name = "TagTextBox";
            this.Size = new System.Drawing.Size(140, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTags;


    }
}
