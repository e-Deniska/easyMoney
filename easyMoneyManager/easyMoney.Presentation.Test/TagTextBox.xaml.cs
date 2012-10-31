using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace easyMoney.Presentation.Test
{
    /// <summary>
    /// Interaction logic for TagTextBox.xaml
    /// </summary>
    public partial class TagTextBox : UserControl
    {
        public TagTextBox()
        {
            InitializeComponent();
            popupTags.AllowsTransparency = true;
            popupTags.PopupAnimation = PopupAnimation.Slide;

            AddHandler(Window.SizeChangedEvent/*GotFocusEvent*/, new RoutedEventHandler(tbTags_LostFocus), true);
            //SetBinding(
            //AddHandler(Window.SizeChangedEvent/*GotFocusEvent*/, new RoutedEventHandler(tbTags_LostFocus), true);
        }

        private void tbTags_GotFocus(object sender, RoutedEventArgs e)
        {
            //lbTags.Width = tbTags.Width;
            popupTags.IsOpen = true;
            e.Handled = true;
        }

        private void tbTags_LostFocus(object sender, RoutedEventArgs e)
        {
            //popupTags.IsOpen = false;
            
        }

        private void tbTags_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tbTags_PreviewKeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tbTags_KeyDown(object sender, KeyEventArgs e)
        {/*
            if (e.Key == Key.Up)
            {
                if (lbTags.SelectedIndex > 0)
                {
                    lbTags.SelectedIndex--;
                }
            }
            else if (e.Key == Key.Down)
            {
                if (lbTags.SelectedIndex < (lbTags.Items.Count - 1))
                {
                    lbTags.SelectedIndex++;
                }
            }*/
        }

        private void tbTags_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                if (lbTags.SelectedIndex > 0)
                {
                    lbTags.SelectedIndex--;
                }
                e.Handled = true;
            }
            else if (e.Key == Key.Down)
            {
                if (lbTags.SelectedIndex < (lbTags.Items.Count - 1))
                {
                    lbTags.SelectedIndex++;
                }
                e.Handled = true;
            }
            else if (e.Key == Key.Escape)
            {
                if (popupTags.IsOpen)
                {
                    popupTags.IsOpen = false;
                    e.Handled = true;
                }
            }
        }

        private void lbTags_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ;
        }

        private void lbTags_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            ;
        }

    }
}
