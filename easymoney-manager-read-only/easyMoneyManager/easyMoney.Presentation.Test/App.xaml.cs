using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using easyMoney.Data;

namespace easyMoney.Presentation.Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static MoneyDataKeeper keeper = MoneyDataKeeper.Instance;
        public static MoneyDataKeeper Keeper { get { return keeper; } }
    }
}
