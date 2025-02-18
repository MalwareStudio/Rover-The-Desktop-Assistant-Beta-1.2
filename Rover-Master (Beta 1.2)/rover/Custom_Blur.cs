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
    public partial class Custom_Blur : Form
    {
        static int reg_speed = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.blur_speed]);
        static int reg_dur = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.blur_duration]);
        static int reg_radius = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.blur_radius]);
        static int reg_opacity = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.blur_opacity]);
        static int reg_style = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.blur_style]);
        public Custom_Blur()
        {
            InitializeComponent();
            speed_bar.Value = reg_speed;
            dur_bar.Value = reg_dur;
            radius_bar.Value = reg_radius;
            opacity_bar.Value = reg_opacity;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\rover"))
            {
                int regvalue;
                if (int.TryParse(key.GetValue("blur_style").ToString(), out regvalue))
                {
                    switch (regvalue)
                    {
                        case 0:
                            r_horizontal.Checked = true;
                            break;
                        case 1:
                            r_vertical.Checked = true;
                            break;
                        case 2:
                            r_mix.Checked = true;
                            break;
                        case 3:
                            r_radial.Checked = true;
                            break;
                        case 4:
                            r_zoom.Checked = true;
                            break;
                    }
                }
            }
        }
        private int style = reg_style;
        private void speed_bar_Scroll(object sender, EventArgs e)
        {
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_speed", speed_bar.Value.ToString(), 1);
        }
        private void dur_bar_Scroll(object sender, EventArgs e)
        {
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_duration", dur_bar.Value.ToString(), 1);
        }
        private void radius_bar_Scroll(object sender, EventArgs e)
        {
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_radius", radius_bar.Value.ToString(), 1);
        }
        private void opacity_bar_Scroll(object sender, EventArgs e)
        {
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_opacity", opacity_bar.Value.ToString(), 1);
        }
        private void btn_use_Click(object sender, EventArgs e)
        {
            Hide();
            Thread.Sleep(500);
            GDI c_gdi = new GDI();
            Thread th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_blur));
            th_gdi.Start(new Tuple<int, int, int, int, byte>(style, speed_bar.Value * 10, dur_bar.Value * 1000, radius_bar.Value * 5, Convert.ToByte(opacity_bar.Value * 5)));
            reg_speed = speed_bar.Value;
            reg_dur = dur_bar.Value;
            reg_radius = radius_bar.Value;
            reg_opacity = opacity_bar.Value;
            reg_style = style;
            Close();
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            Registry_Class c_reg = new Registry_Class();
            speed_bar.Value = 1;
            dur_bar.Value = 5;
            radius_bar.Value = 2;
            opacity_bar.Value = 5;
            style = 1;
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_style", style.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_speed", speed_bar.Value.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_duration", dur_bar.Value.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_radius", radius_bar.Value.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_opacity", opacity_bar.Value.ToString(), 1);
        }
        private void r_vertical_CheckedChanged(object sender, EventArgs e)
        {
            style = 1;
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_style", style.ToString(), 1);
        }
        private void r_horizontal_CheckedChanged(object sender, EventArgs e)
        {
            style = 0;
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_style", style.ToString(), 1);
        }
        private void r_mix_CheckedChanged(object sender, EventArgs e)
        {
            style = 2;
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_style", style.ToString(), 1);
        }
        private void r_radial_CheckedChanged(object sender, EventArgs e)
        {
            style = 3;
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_style", style.ToString(), 1);
        }
        private void r_zoom_CheckedChanged(object sender, EventArgs e)
        {
            style = 4;
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_style", style.ToString(), 1);
        }
    }
}
