using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using easyMoney.Utilities;
using easyMoney.Data;
using easyMoney.Setup;

namespace easyMoney.Manager.Forms
{
    public partial class SettingsForm : Form
    {

        #region Form init/load/close

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // set values from the parameters
            cbAllowAutoUpdate.Checked = Parameters.CheckForUpdates;
            cbShowFilenameInTitle.Checked = Parameters.ShowFilenameInTitle;
            cbShowOpenDialogEachStart.Checked = Parameters.ShowOpenDialogEachStart;
            numKeepArchivesDays.Value = (decimal)Parameters.KeepArchivesDays;

            if (Parameters.Language.Equals(Consts.Language.English))
            {
                rbLanguageEnglish.Checked = true;
            }
            else if (Parameters.Language.Equals(Consts.Language.Russian))
            {
                rbLanguageRussian.Checked = true;
            }
            else
            {
                rbLanguageSystemDefault.Checked = true;
            }            
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // set parameters from values
            Parameters.CheckForUpdates = cbAllowAutoUpdate.Checked;
            Parameters.ShowFilenameInTitle = cbShowFilenameInTitle.Checked;
            Parameters.ShowOpenDialogEachStart = cbShowOpenDialogEachStart.Checked;
            Parameters.KeepArchivesDays = (int)numKeepArchivesDays.Value;

            if (rbLanguageEnglish.Checked)
            {
                Parameters.Language = Consts.Language.English;
            }
            else if (rbLanguageRussian.Checked)
            {
                Parameters.Language = Consts.Language.Russian;
            }
            else
            {
                Parameters.Language = Consts.Language.SystemDefault;
            }
        }

        #endregion

        #region Button hanlders

        private void btnMetadata_Click(object sender, EventArgs e)
        {
            CustomMetadataForm form = new CustomMetadataForm();
            form.ShowDialog();
        }

        private void btnClearCustomMetadata_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.Labels.ClearCustomMetadataMessage, Resources.Labels.ClearCustomMetadataTitle,
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                MoneyDataKeeper.Instance.ClearUserMetadata();
            }
        }

        #endregion
    }
}
