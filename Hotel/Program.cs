using Hotel.Items;
using Hotel.Login;
using Hotel.MainMenu;
using Hotel.People;
using System;
using System.Windows.Forms;

namespace Hotel
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLoginScreen());
            //Application.Run(new frmShowItemInfo(11));
        }
    }
}
