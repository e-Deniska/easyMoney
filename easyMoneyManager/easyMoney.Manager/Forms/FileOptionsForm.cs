using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace easyMoney.Manager.Forms
{
    public partial class FileOptionsForm : Form
    {

        #region Form init

        public FileOptionsForm()
        {
            InitializeComponent();
            lblPasswordStatus.Text = String.Empty;
            this.DialogResult = DialogResult.Cancel;
            cbProtectWithPassword_CheckedChanged(null, null);
        }

        #endregion

        #region Public properties

        public bool PasswordProtection
        {
            get { return cbProtectWithPassword.Checked; }
        }

        public String Password
        {
            get { return tbPassword1.Text; }
        }

        #endregion

        #region Button handlers

        private void btnOk_Click(object sender, EventArgs e)
        {
            if ((!cbProtectWithPassword.Checked) || ((tbPassword1.Text.Length > 0) && (tbPassword1.Text.Equals(tbPassword2.Text))))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region Password controls handlers

        private void cbProtectWithPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProtectWithPassword.Checked)
            {
                lblPassword1.Enabled = true;
                lblPassword2.Enabled = true;
                tbPassword1.Enabled = true;
                tbPassword2.Enabled = true;
                lblPasswordStatus.ForeColor = Color.Red;
                lblPasswordStatus.Text = Resources.Labels.PasswordInvalid;
                btnOk.Enabled = false;
            }
            else
            {
                tbPassword1.Text = String.Empty;
                tbPassword2.Text = String.Empty;
                lblPassword1.Enabled = false;
                lblPassword2.Enabled = false;
                tbPassword1.Enabled = false;
                tbPassword2.Enabled = false;
                lblPasswordStatus.Text = String.Empty;
                btnOk.Enabled = true;
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if (cbProtectWithPassword.Checked)
            {
                if ((tbPassword1.Text.Length > 0) && (tbPassword1.Text.Equals(tbPassword2.Text)))
                {
                    lblPasswordStatus.ForeColor = Color.Green;
                    lblPasswordStatus.Text = Resources.Labels.PasswordValid;
                    btnOk.Enabled = true;
                }
                else
                {
                    lblPasswordStatus.ForeColor = Color.Red;
                    lblPasswordStatus.Text = Resources.Labels.PasswordInvalid;
                    btnOk.Enabled = false;
                }
            }
        }

        #endregion
        
    }
}
