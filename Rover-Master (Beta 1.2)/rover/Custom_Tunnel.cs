using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace rover
{
    public partial class Custom_Tunnel : Form
    {
        static bool normal, crazy, spiral, inverted;
        public static bool[] tunnel_styles = new bool[] { normal, crazy, spiral, inverted };
        static int reg_speed = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.tunnel_speed]);
        static int reg_dur = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.tunnel_duration]);
        public Custom_Tunnel()
        {
            InitializeComponent();
            track_speed.Value = reg_speed;
            track_dur.Value = reg_dur;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\rover"))
            {
                int regvalue;
                if (int.TryParse(key.GetValue("tunnel_mode").ToString(), out regvalue))
                {
                    switch (regvalue)
                    {
                        case 0:
                            tunnel_style(regvalue);
                            radioButton1.Checked = true;
                            break;
                        case 1:
                            tunnel_style(regvalue);
                            radioButton2.Checked = true;
                            break;
                        case 2:
                            tunnel_style(regvalue);
                            radioButton3.Checked = true;
                            break;
                        case 3:
                            tunnel_style(regvalue);
                            radioButton4.Checked = true;
                            break;
                    }
                }
            }
            if (!Language.russian_lang) return;
            label1.Text = Language.Lang_RU[Language.words.form_custom_tunnel_text];
            label2.Text = Language.Lang_RU[Language.words.form_custom_tunnel_speed];
            label3.Text = Language.Lang_RU[Language.words.form_custom_tunnel_duration];
            radioButton1.Text = Language.Lang_RU[Language.words.normal];
            radioButton2.Text = Language.Lang_RU[Language.words.form_custom_tunnel_crazy];
            radioButton3.Text = Language.Lang_RU[Language.words.form_custom_tunnel_spiral];
            radioButton4.Text = Language.Lang_RU[Language.words.form_custom_tunnel_inverted];
            button1.Text = Language.Lang_RU[Language.words.use_button];
            button2.Text = Language.Lang_RU[Language.words.clear_button];
            Text = Language.Lang_RU[Language.words.form_custom_tunnel_win];
        }
        public void tunnel_style(int index)
        {
            for (int i = 0; i < tunnel_styles.Length; i++)
            {
                tunnel_styles[i] = (i == index);
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tunnel_speed", track_speed.Value.ToString(), 1);
        }
        private void track_dur_Scroll(object sender, EventArgs e)
        {
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tunnel_duration", track_dur.Value.ToString(), 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Thread.Sleep(500);
            GDI c_gdi = new GDI();
            Thread th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_tunnel));
            th_gdi.Start(new Tuple<int, int>(track_speed.Value * 10, track_dur.Value * 10));
            reg_speed = track_speed.Value;
            reg_dur = track_dur.Value;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            track_speed.Value = 1;
            track_dur.Value = 5;
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tunnel_speed", track_speed.Value.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tunnel_duration", track_dur.Value.ToString(), 1);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tunnel_style(0);
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tunnel_mode", "0", 1);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tunnel_style(1);
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tunnel_mode", "1", 1);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            tunnel_style(2);
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tunnel_mode", "2", 1);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            tunnel_style(3);
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tunnel_mode", "3", 1);
        }
    }
}
