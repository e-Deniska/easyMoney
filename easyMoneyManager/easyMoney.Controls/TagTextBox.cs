using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace easyMoney.Controls
{
    /// <summary>
    /// Textbox with tags support control
    /// </summary>
    public partial class TagTextBox : UserControl
    {
        private const String Delimeters = ".,;";

        private List<String> tagsAvailable;
        private List<String> tags;

        private ListBox lbSuggestions;
        private Popup popup;
        private object lckUpdate = new object();
        private bool isUpdating = false;
             
        
        public TagTextBox()
        {
            tagsAvailable = new List<String>();
            tags = new List<String>();

            lbSuggestions = new ListBox();
            lbSuggestions.Dock = DockStyle.Fill;
            lbSuggestions.Margin = Padding.Empty;
            lbSuggestions.Padding = Padding.Empty;
            lbSuggestions.GotFocus += new EventHandler(lbSuggestions_GotFocus);
            lbSuggestions.MouseClick += new MouseEventHandler(lbSuggestions_MouseClick);
            
            popup = new Popup(lbSuggestions);
            popup.TopLevel = true;
            popup.AutoClose = false;

            InitializeComponent();
        }

        #region Tags management

        public IEnumerable<String> Tags
        {
            get
            {
                updateTags();
                return tags;
            }
            set
            {
                tbTags.Text = String.Join(", ", value);
            }
        }

        public override String Text
        {
            get
            {
                return tbTags.Text;
            }
            set
            {
                tbTags.Text = value;
            }
        }

        public void SetAvailableTags(IEnumerable<String> tags)
        {
            tagsAvailable.Clear();
            tagsAvailable.AddRange(tags);
        }

        private void updateTags()
        {
            tags.Clear();
            IEnumerable<String> words = tbTags.Text.Split(Delimeters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (String word in words)
            {
                String wrd = word.Trim();
                if ((wrd.Length > 0) && (!tags.Contains(wrd)))
                {
                    tags.Add(wrd);
                }
            }
        }

        #endregion

        #region Getting and replacing words in textbox

        private String getCurrentWord(String replacement)
        {
            int start = tbTags.SelectionStart;
            int end = tbTags.SelectionStart;
            while (start > 0)
            {
                if (Delimeters.Contains(tbTags.Text[start - 1])) break;
                start--;
            }

            while (end < tbTags.Text.Length)
            {
                if (Delimeters.Contains(tbTags.Text[end])) break;
                end++;
            }

            if (replacement != null)
            {
                String verified;
                if (start == 0)
                {
                    verified = replacement + ", ";
                }
                else
                {
                    verified = " " + replacement + ", ";
                }
                lock (lckUpdate)
                {
                    isUpdating = true;
                }
                tbTags.Text = tbTags.Text.Remove(start, end - start).Insert(start, verified);
                tbTags.SelectionStart = start + verified.Length;
                lock (lckUpdate)
                {
                    isUpdating = false;
                }
                PopupOpened = false;
                // showSuggestions();
                return replacement;
            }
            else
            {
                return tbTags.Text.Substring(start, end - start).Trim();
            }
        }

        private void replaceWithTag(String tag)
        {
            getCurrentWord(tag);
        }

        #endregion

        #region Show list of suggestions

        private void showSuggestions()
        {
            lock (lckUpdate)
            {
                if (isUpdating) return;
            }

            String word = getCurrentWord(null);

            if (String.IsNullOrEmpty(word))
            {
                PopupOpened = false;
                return;
            }

            if (!tbTags.Focused)
            {
                return;
            }

            IEnumerable<String> relevant = tagsAvailable.Where(s => ((s.StartsWith(word)) && (!tags.Contains(s))));

            //frmSuggestions.lbSuggestions.Items.Clear();
            lbSuggestions.Items.Clear();

            if (relevant.Any())
            {
                lbSuggestions.Items.AddRange(relevant.ToArray());
                lbSuggestions.SelectedIndex = 0;
                popup.Width = tbTags.Width;
                popup.Height = tbTags.Height * 3;
                popup.Show(this);
                tbTags.Focus();
            }
            else
            {
                popup.Close();
            }
        }

        public bool PopupOpened
        {
            get
            {
                return popup.Visible;
            }
            set
            {
                if (value)
                {
                    showSuggestions();
                }
                else
                {
                    popup.Close();
                }
            }
        }

        #endregion

        #region Textbox handlers

        public bool ReadOnly
        {
            get { return tbTags.ReadOnly; }
            set { tbTags.ReadOnly = value; }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            popup.Close();
            base.OnEnabledChanged(e);
        }

        private void tbTags_TextChanged(object sender, EventArgs e)
        {
            updateTags();
            if (this.Enabled)
            {
                showSuggestions();
            }
        }

        private void tbTags_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    if (lbSuggestions.SelectedIndex > 0)
                    {
                        lbSuggestions.SelectedIndex--;
                    }
                    break;

                case Keys.Down:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    if (lbSuggestions.SelectedIndex < (lbSuggestions.Items.Count - 1))
                    {
                        lbSuggestions.SelectedIndex++;
                    }
                    break;

                case Keys.Escape:
                    if (popup.Visible)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        popup.Close();
                    }
                    break;

                case Keys.Enter:
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    if ((PopupOpened) && (lbSuggestions.SelectedItem != null))
                    {
                        replaceWithTag(lbSuggestions.SelectedItem.ToString());
                    }
                    break;
            }
        }

        private void tbTags_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                case Keys.Enter:
                    if (popup.Visible)
                    {
                        e.IsInputKey = true;
                    }
                    break;
            }
        }

        private void tbTags_Leave(object sender, EventArgs e)
        {
            PopupOpened = false;
        }

        private void tbTags_Enter(object sender, EventArgs e)
        {
            //showSuggestions();
        }
        
        #endregion

        #region Listbox handlers

        void lbSuggestions_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int x = lbSuggestions.IndexFromPoint(e.Location);
                if (x >= 0)
                {
                    lbSuggestions.SelectedIndex = x;
                    replaceWithTag(lbSuggestions.SelectedItem.ToString());
                }
            }
        }

        void lbSuggestions_GotFocus(object sender, EventArgs e)
        {
            tbTags.Focus();
        }
        
        #endregion
    }
}
