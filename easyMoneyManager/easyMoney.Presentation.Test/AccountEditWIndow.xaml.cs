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
using System.Windows.Shapes;
using easyMoney.Data;
using easyMoney.Utilities;

namespace easyMoney.Presentation.Test
{
    /// <summary>
    /// Interaction logic for AccountEditWIndow.xaml
    /// </summary>
    public partial class AccountEditWindow : Window
    {
        public AccountEditWindow()
        {
            
            
            //System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = Consts.Language.RussianCulture;
            App.Keeper.FilePreLoad();
            App.Keeper.FileActivate();
            this.DataContext = App.Keeper;
            InitializeComponent();
            //keeper.Accounts;
            if (cbAccountType.Items.Count > 0)
            {
                cbAccountType.SelectedIndex = 0;
            }
            if (cbCurrency.Items.Count > 0)
            {
                cbCurrency.SelectedIndex = 0;
            }
            tbInformation.Text = "This is really long and interesting description for the account type being created or edited.";
        }
    }
}
