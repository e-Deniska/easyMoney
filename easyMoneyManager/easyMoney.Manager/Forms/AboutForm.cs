using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using easyMoney.Utilities;

namespace easyMoney.Manager.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            lblVersionApplication.Text = String.Format(Consts.UI.FullVersionFormat, Consts.Application.Version,
                Consts.Application.VersionCodeName);
            lblVersionAssembly.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblBuildDate.Text = (new DateTime(2000, 1, 1)).AddDays(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build).ToShortDateString();
        }

        private void btnOpenDevelopmentSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Consts.Application.SiteURL);
        }

        private void btnCheckForUpdates_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateHelper helper = new UpdateHelper(Consts.Application.UpdateCheckURL, Consts.Application.Version);
                if (helper.IsUpdateAvailable())
                {
                    if (MessageBox.Show(String.Format(Resources.Labels.UpdateAvailableFormat, Consts.Application.Version, helper.AvailableVersion()),
                        Resources.Labels.UpdateAvailableTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        helper.StartUpdate(this);
                    }
                }
                else
                {
                    MessageBox.Show(String.Format(Resources.Labels.NoUpdatesFormat, Consts.Application.Version), Resources.Labels.NoUpdatesTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Parameters.LastUpdateDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Resources.Labels.UpdateErrorFormat, ex.Message), Resources.Labels.UpdateErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Write(ex);
            }
        }

        /// <summary>
        /// Link label click hanlder - open URL, which is stored in Text property
        /// </summary>
        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start((sender as LinkLabel).Text);
        }

    }
}
