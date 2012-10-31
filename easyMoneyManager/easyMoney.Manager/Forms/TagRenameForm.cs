using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using easyMoney.Data;

namespace easyMoney.Manager.Forms
{
    public partial class TagRenameForm : Form
    {
        private String tag = String.Empty;
        private MoneyDataKeeper keeper = MoneyDataKeeper.Instance;

        public TagRenameForm(String tag)
        {
            InitializeComponent();
            this.tag = tag;
            tbTag.Text = tag;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            String newTag = tbTag.Text.Trim().ToLower();
            if (String.IsNullOrEmpty(newTag))
            {
                MessageBox.Show(Resources.Labels.EmptyTagNotAllowed, Resources.Labels.TagRenameErrorTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if ((!tag.Equals(newTag)) && (!keeper.RenameTag(tag, newTag)))
                {
                    MessageBox.Show(String.Format(Resources.Labels.TagAlreadyExistFormat, newTag), Resources.Labels.TagRenameErrorTitle, 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
