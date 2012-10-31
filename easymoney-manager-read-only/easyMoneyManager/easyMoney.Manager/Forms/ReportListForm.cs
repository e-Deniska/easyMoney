using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using easyMoney.Data;
using easyMoney.SimpleReports;
using easyMoney.Utilities;

namespace easyMoney.Manager.Forms
{
    public partial class ReportListForm : Form
    {
        MoneyDataKeeper keeper = MoneyDataKeeper.Instance;

        #region Form init/load

        public ReportListForm()
        {
            InitializeComponent();
        }

        private void ReportListForm_Load(object sender, EventArgs e)
        {
            lbReports.DisplayMember = Reports.ReportEntry.FieldTitle;
            lbReports.ValueMember = Reports.ReportEntry.FieldID;
            lbReports.DataSource = Reports.GetAvailableReports();
        }

        #endregion

        #region Listbox and button handlers

        private void lbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelReportParameters.Controls.Clear();
            if (lbReports.SelectedItem != null)
            {
                Reports.ReportEntry entry = lbReports.SelectedItem as Reports.ReportEntry;
                entry.DefaultsHandler(entry.ReportParameters);

                panelReportParameters.Visible = false;
                Label description = new Label();
                if (entry.ReportParameters != null)
                {
                    panelReportParameters.Controls.Add(entry.ReportParameters);
                }
                panelReportParameters.Controls.Add(description);
                description.Text = entry.Description;
                description.Dock = DockStyle.Top;
                description.Padding = new Padding(0, 0, 0, 6);
                //description.AutoSize = true;
                description.Size = description.GetPreferredSize(description.Size);
                panelReportParameters.Visible = true;
                btnRunReport.Enabled = true;
            }
            else
            {
                btnRunReport.Enabled = false;
            }
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            if (lbReports.SelectedItem != null)
            {
                Reports.ReportEntry entry = lbReports.SelectedItem as Reports.ReportEntry;
                //entry.RunHandler(entry.ReportParameters);
                Form report = entry.GetReport();
                report.Show();
            }
        }

        #endregion

        private void ReportListForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (HotKeyHelper.GetShortcut(e))
            {
                case KeyShortcut.Cancel:
                    //this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
            }
        }

    }
}
