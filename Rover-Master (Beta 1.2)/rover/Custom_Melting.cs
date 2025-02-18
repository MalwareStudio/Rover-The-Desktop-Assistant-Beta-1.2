using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rover
{
    public partial class Custom_Melting : Form
    {
        static int reg_speed = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.melting_speed]);
        static int reg_duration = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.melting_duration]);
        static int reg_size = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.melting_size]);
        static int reg_length = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.melting_length]);
        static int reg_style = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.melting_style]);
        public Custom_Melting()
        {
            InitializeComponent();
            speed_bar.Value = reg_speed;
            dur_bar.Value = reg_duration;
            size_bar.Value = reg_size;
            length_bar.Value = reg_length;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\rover"))
            {
                int regvalue;
                if (int.TryParse(key.GetValue("melting_style").ToString(), out regvalue))
                {
                    switch (regvalue)
                    {
                        case 0:
                            r_vertical.Checked = true;
                            break;
                        case 1:
                            r_horizontal.Checked = true;
                            break;
                        case 2:
                            r_mix.Checked = true;
                            break;
                    }
                }
            }
        }
        private int style = reg_style;
        private void btn_use_Click(object sender, EventArgs e)
        {
            Hide();
            Thread.Sleep(500);
            GDI c_gdi = new GDI();
            Thread th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_melting));
            th_gdi.Start(new Tuple<int, int, int, int, int>(style, speed_bar.Value * 2, dur_bar.Value * 1000, size_bar.Value * 10, length_bar.Value * 5));
            reg_speed = speed_bar.Value;
            reg_duration = dur_bar.Value;
            reg_size = size_bar.Value;
            reg_length = length_bar.Value;
            reg_style = style;
            Close();
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            Registry_Class c_reg = new Registry_Class();
            speed_bar.Value = 1;
            dur_bar.Value = 5;
            size_bar.Value = 3;
            length_bar.Value = 2;
            style = 0;
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_style", style.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_speed", speed_bar.Value.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_duration", dur_bar.Value.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_size", size_bar.Value.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_length", length_bar.Value.ToString(), 1);
        }
        private void speed_bar_Scroll(object sender, EventArgs e)
        {
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_speed", speed_bar.Value.ToString(), 1);
        }

        private void dur_bar_Scroll(object sender, EventArgs e)
        {
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_duration", dur_bar.Value.ToString(), 1);
        }
        private void size_bar_Scroll(object sender, EventArgs e)
        {
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_size", size_bar.Value.ToString(), 1);
        }
        private void length_bar_Scroll(object sender, EventArgs e)
        {
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_length", length_bar.Value.ToString(), 1);
        }
        private void r_vertical_CheckedChanged(object sender, EventArgs e)
        {
            style = 0;
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_style", style.ToString(), 1);
        }
        private void r_mix_CheckedChanged(object sender, EventArgs e)
        {
            style = 2;
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_style", style.ToString(), 1);
        }
        private void r_horizontal_CheckedChanged(object sender, EventArgs e)
        {
            style = 1;
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_style", style.ToString(), 1);
        }
    }
}
