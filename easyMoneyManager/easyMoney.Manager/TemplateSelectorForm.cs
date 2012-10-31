using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using easyMoney.Data;

namespace easyMoney.Manager
{
    public partial class TemplateSelectorForm : Form
    {
        private MoneyDataKeeper keeper = null;
        private IEnumerable<MoneyDataSet.TransactionTemplatesRow> templates = null;

        public MoneyDataSet.TransactionTemplatesRow SelectedTemplate
        {
            get
            {
                return lbTemplates.SelectedItem as MoneyDataSet.TransactionTemplatesRow;
            }
        }    

        public TemplateSelectorForm(IEnumerable<MoneyDataSet.TransactionTemplatesRow> templates)
        {
            InitializeComponent();
            this.keeper = MoneyDataKeeper.Instance;
            this.templates = templates;
        }

        private void lbTemplates_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnOk.PerformClick();
        }

        private void TemplateSelectorForm_Load(object sender, EventArgs e)
        {
            lbTemplates.DisplayMember = keeper.DataSet.TransactionTemplates.TitleColumn.ColumnName;
            lbTemplates.ValueMember = keeper.DataSet.TransactionTemplates.IDColumn.ColumnName;
            lbTemplates.DataSource = templates;
        }
    }
}
