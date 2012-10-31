using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace easyMoney.Controls
{
    public partial class IntroductionForm : Form
    {
        #region Introduction page class

        public class Page
        {
            public Page(String title, String text)
            {
                Title = title;
                Text = text;
            }

            public String Title { get; set; }
            public String Text { get; set; }
        }

        #endregion

        #region Introduction pages property

        public List<Page> Pages { get; set; }

        #endregion

        #region Private members

        private int pageIndex = 0;

        #endregion

        #region Form init/load

        public IntroductionForm(List<Page> pages)
        {
            InitializeComponent();
            this.Pages = pages;
        }
        
        private void ManualWizardForm_Load(object sender, EventArgs e)
        {
            showPage(pageIndex);
        }

        #endregion

        #region Button click handlers

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (pageIndex > 0)
            {
                pageIndex--;
            }
            showPage(pageIndex);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageIndex < (Pages.Count - 1))
            {
                pageIndex++;
            }
            showPage(pageIndex);
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Show specific page

        private void showPage(int index)
        {
            if ((index >= 0) && (index < Pages.Count))
            {
                lblPageTitle.Text = Pages[index].Title;
                rtbPageText.Rtf = Pages[index].Text;
                rtbPageText.WordWrap = true;
                if (index > 0)
                {
                    btnPrevious.Enabled = true;
                }
                else
                {
                    btnPrevious.Enabled = false;
                }

                if (index < (Pages.Count - 1))
                {
                    btnNext.Enabled = true;
                    this.AcceptButton = btnNext;
                }
                else
                {
                    btnNext.Enabled = false;
                    this.AcceptButton = btnFinish;
                }
            }
        }

        #endregion
    }
}
