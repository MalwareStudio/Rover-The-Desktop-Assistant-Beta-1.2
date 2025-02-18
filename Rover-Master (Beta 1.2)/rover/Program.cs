using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace rover
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static bool is_new = false;
        [STAThread]
        static void Main()
        {
            using(RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\rover"))
            {
                if(key != null && key.GetValue("come") != null)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Rover_Win());
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Register_Form());
                }
            }
        }
    }
}
