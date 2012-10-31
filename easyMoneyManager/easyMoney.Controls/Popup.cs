using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;

namespace easyMoney.Controls
{
    /// <summary>
    /// Based (well, simplified) on Popup class by Lukasz Swiatkowski 
    /// More info on: http://lukesw.net/articles/SimplePopup.aspx
    /// </summary>
    public class Popup : ToolStripDropDown
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Content != null)
                {
                    Control _content = Content;
                    Content = null;
                    _content.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public Control Content
        {
            get;
            private set;
        }

        private Control opener;
        private Popup ownerPopup;
        private Popup childPopup;
        private ToolStripControlHost host;

        public Popup(Control content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("Content control could not be null");
            }
            Content = content;
            AutoSize = false;
            DoubleBuffered = true;
            ResizeRedraw = true;
            host = new ToolStripControlHost(Content);

            Padding = Padding.Empty;
            Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.Margin = Padding.Empty;

            MinimumSize = content.MinimumSize;
            content.MinimumSize = content.Size;
            MaximumSize = content.MaximumSize;
            content.MaximumSize = content.Size;
            Size = content.Size;

            TabStop = true;
            content.TabStop = true;
            content.Location = Point.Empty;
            Items.Add(host);

            content.Disposed += delegate(object sender, EventArgs e)
            {
                content = null;
                Dispose(true);
            };

            content.RegionChanged += delegate(object sender, EventArgs e)
            {
                UpdateRegion();
            };

            UpdateRegion();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            bool processed = base.ProcessDialogKey(keyData);
            if (!processed && (keyData == Keys.Tab || keyData == (Keys.Tab | Keys.Shift)))
            {
                bool backward = (keyData & Keys.Shift) == Keys.Shift;
                this.Content.SelectNextControl(null, !backward, true, true, true);
            }
            return processed;
        }

        protected void UpdateRegion()
        {
            if (this.Region != null)
            {
                this.Region.Dispose();
                this.Region = null;
            }
            if (Content.Region != null)
            {
                this.Region = Content.Region.Clone();
            }
        }

        public void Show(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("Parent control could not be null");
            }
            Show(control, control.ClientRectangle);
        }

        public void Show(Control control, Rectangle area)
        {
            if (control == null)
            {
                throw new ArgumentNullException("Parent control could not be null");
            }
            SetOwnerItem(control);

            Point location = control.PointToScreen(new Point(area.Left, area.Top + area.Height));
            Rectangle screen = Screen.FromControl(control).WorkingArea;
            if (location.X + Size.Width > (screen.Left + screen.Width))
            {
                location.X = (screen.Left + screen.Width) - Size.Width;
            }
            if (location.Y + Size.Height > (screen.Top + screen.Height))
            {
                location.Y -= Size.Height + area.Height;
            }
            location = control.PointToClient(location);
            Show(control, location, ToolStripDropDownDirection.BelowRight);
        }

        private void SetOwnerItem(Control control)
        {
            if (control == null)
            {
                return;
            }
            if (control is Popup)
            {
                Popup popupControl = control as Popup;
                ownerPopup = popupControl;
                ownerPopup.childPopup = this;
                OwnerItem = popupControl.Items[0];
                return;
            }
            else if (opener == null)
            {
                opener = control;
            }

            if (control.Parent != null)
            {
                SetOwnerItem(control.Parent);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Content.MinimumSize = Size;
            Content.MaximumSize = Size;
            Content.Size = Size;
            Content.Location = Point.Empty;
            base.OnSizeChanged(e);
        }

        protected override void OnOpening(CancelEventArgs e)
        {
            if ((Content.IsDisposed) || (Content.Disposing))
            {
                e.Cancel = true;
                return;
            }
            UpdateRegion();
            base.OnOpening(e);
        }
    }
}
