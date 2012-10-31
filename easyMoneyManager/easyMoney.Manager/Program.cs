using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using easyMoney.Utilities;
using easyMoney.Controls;
using easyMoney.Manager.Forms;

namespace easyMoney.Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Log.Write(String.Format("Starting easyMoney, commandline: [{0}]", Environment.CommandLine));
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new MainApplicationForm());
                Application.Run(new WelcomeScreenForm());
            }
            catch (Exception e)
            {
                // something happened, nothing could be done here
                ErrorHelper.ShowErrorBox(ErrorHelper.Errors.UnhandledApplicationError, e, true);
            }
        }
    }
}
