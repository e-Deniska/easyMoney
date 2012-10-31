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

namespace easyMoney.SimpleReports
{
    public partial class ReportLoadForm : Form
    {

        private Reports.ReportEntry report = null;
        private Form reportForm = null;

        public Form ReportForm { get { return reportForm; } }
        
        #region Form init/load

        public ReportLoadForm(Reports.ReportEntry entry)
        {
            InitializeComponent();
            report = entry;
        }

        private void ReportLoadForm_Load(object sender, EventArgs e)
        {
            bgwProcess.RunWorkerAsync();
        }

        #endregion

        #region Background worker code

        private void bgwProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            LocalizationHelper.SetThreadLocale();
            reportForm = report.RunHandler(report.ReportParameters);
        }

        private void bgwProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
