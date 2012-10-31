using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using easyMoney.Data;
using easyMoney.Controls;
using easyMoney.Utilities;

namespace easyMoney.Manager
{
    public partial class FileLoadForm : Form
    {

        #region Form constants and members

        private const int HeightShift = 114;
        private const int HeightStep = 10;
        private const int HeightStepDelay = 10;

        private enum LoadingState
        {
            Load,
            Decrypt,
            Redecrypt,
            Activate
        };
        
        private LoadingState state;
        private bool closeOnCancel = false;

        #endregion
        
        #region Form init/load

        public FileLoadForm(String loadingMessage, bool closeOnCancel)
        {
            InitializeComponent();
            this.closeOnCancel = closeOnCancel;
            lblMain.Text = loadingMessage;
            this.Height -= HeightShift;
            this.Text = Resources.Labels.PleaseWaitMessage;
        }

        private void PleaseWaitForm_Load(object sender, EventArgs e)
        {
            state = LoadingState.Load; 
            bgwProcess.RunWorkerAsync();
        }

        #endregion

        #region Background worker code

        private void bgwProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            LocalizationHelper.SetThreadLocale(); 
            if (state == LoadingState.Load)
            {
                MoneyDataKeeper.Instance.FilePreLoad();
            }
            else if (state == LoadingState.Activate)
            {
                MoneyDataKeeper.Instance.FileActivate();
            }
            else if (state == LoadingState.Decrypt)
            {
                if (!MoneyDataKeeper.Instance.FileTryDecrypt())
                {
                    state = LoadingState.Redecrypt;
                }
            }
        }

        private void bgwProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (state == LoadingState.Load)
            {
                if (MoneyDataKeeper.Instance.FileIsEncrypted())
                {
                    showPasswordControls();
                }
                else
                {
                    state = LoadingState.Activate;
                    bgwProcess.RunWorkerAsync();
                }
            }
            else if (state == LoadingState.Decrypt)
            {
                state = LoadingState.Activate;
                bgwProcess.RunWorkerAsync();
            }
            else if (state == LoadingState.Redecrypt)
            {
                showPasswordControls();
                lblPleaseEnterPassword.ForeColor = Color.Red;
                lblPleaseEnterPassword.Text = Resources.Labels.PasswordIncorrect;
            }
            else if (state == LoadingState.Activate)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #endregion

        #region Showing/hiding controls

        private void showPasswordControls()
        {
            pbMain.Style = ProgressBarStyle.Blocks;
            int steps = HeightShift / HeightStep;
            int leftover = HeightShift % HeightStep;
            for (int i = 0; i < steps; i++)
            {
                this.Height += HeightStep;
                this.Update();
                Thread.Sleep(HeightStepDelay);
            }
            this.Height += leftover;
            this.Update();
            this.Text = Resources.Labels.ActionNeededMessage;
            tbFilename.Enabled = true;
            lblPleaseEnterPassword.Enabled = true;
            btnOk.Enabled = true;
            btnCancel.Enabled = true;
            tbPassword.Enabled = true;
            tbFilename.Visible = true;
            lblPleaseEnterPassword.Visible = true;
            btnOk.Visible = true;
            btnCancel.Visible = true;
            tbPassword.Visible = true;
            tbFilename.Text = MoneyDataKeeper.Instance.Filename;
            tbPassword.Focus();
        }

        private void hidePasswordControls()
        {
            tbFilename.Enabled = false;
            lblPleaseEnterPassword.Enabled = false;
            btnOk.Enabled = false;
            btnCancel.Enabled = false;
            tbPassword.Enabled = false;
            tbFilename.Visible = false;
            lblPleaseEnterPassword.Visible = false;
            btnOk.Visible = false;
            btnCancel.Visible = false;
            tbPassword.Visible = false;
            tbPassword.Text = String.Empty;
            tbFilename.Text = String.Empty;
            pbMain.Style = ProgressBarStyle.Marquee;
            int steps = HeightShift / HeightStep;
            int leftover = HeightShift % HeightStep;
            for (int i = 0; i < steps; i++)
            {
                this.Height -= HeightStep;
                this.Update();
                Thread.Sleep(HeightStepDelay);
            }
            this.Height -= leftover;
            this.Update();
            this.Text = Resources.Labels.PleaseWaitMessage;
        }

        #endregion

        #region Button handlers

        private void btnOk_Click(object sender, EventArgs e)
        {
            if ((state == LoadingState.Load) || (state == LoadingState.Redecrypt))
            {
                MoneyDataKeeper.Instance.Password = tbPassword.Text;
                state = LoadingState.Decrypt;
                hidePasswordControls();
                bgwProcess.RunWorkerAsync();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (closeOnCancel)
            {
                Application.Exit();
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

    }
}
