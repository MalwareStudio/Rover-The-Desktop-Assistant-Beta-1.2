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
    public partial class Custom_Filter : Form
    {
        static string reg_red = Convert.ToString(Registry_Class.Regvalues[Registry_Class.Regval.filter_red]);
        static string reg_green = Convert.ToString(Registry_Class.Regvalues[Registry_Class.Regval.filter_green]);
        static string reg_blue = Convert.ToString(Registry_Class.Regvalues[Registry_Class.Regval.filter_blue]);
        public Custom_Filter()
        {
            InitializeComponent();
            r_box.Text = reg_red;
            g_box.Text = reg_green;
            b_box.Text = reg_blue;
            if (!Language.russian_lang) return;
            label1.Text = Language.Lang_RU[Language.words.form_custom_filter_subtitle];
            button1.Text = Language.Lang_RU[Language.words.use_button];
            button2.Text = Language.Lang_RU[Language.words.clear_button];
            Text = Language.Lang_RU[Language.words.form_custom_filter_win];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            if (r_box.Text == "" || g_box.Text == "" || b_box.Text == "")
            {
                MessageBox.Show("Please enter a number from 0 to 255", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Convert.ToInt32(r_box.Text) > 255 || Convert.ToInt32(g_box.Text) > 255 || Convert.ToInt32(b_box.Text) > 255)
            {
                MessageBox.Show("Number cannot be higher than 255!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Registry_Class c_reg = new Registry_Class();
            reg_red = r_box.Text;
            reg_green = g_box.Text;
            reg_blue = b_box.Text;
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "filter_red", r_box.Text, 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "filter_green", g_box.Text, 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "filter_blue", b_box.Text, 1);
            Thread.Sleep(500);
            GDI c_gdi = new GDI();
            if (!Rover_Win.is_invert)
                c_gdi.gdi_filter(0, Convert.ToInt32(r_box.Text), Convert.ToInt32(g_box.Text), Convert.ToInt32(b_box.Text));
            else
            {
                Rover_Win.is_invert = false;
                c_gdi.gdi_invert(Convert.ToInt32(r_box.Text), Convert.ToInt32(g_box.Text), Convert.ToInt32(b_box.Text), 1);
            }
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            r_box.Text = "0";
            g_box.Text = "0";
            b_box.Text = "0";
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "filter_red", r_box.Text, 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "filter_green", g_box.Text, 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "filter_blue", b_box.Text, 1);
        }
        private void r_box_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(r_box.Text, "[^0-9]")) return;
            MessageBox.Show("Please enter only numbers!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            r_box.Text = r_box.Text.Remove(r_box.Text.Length - 1);
        }
        private void g_box_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(g_box.Text, "[^0-9]")) return;
            MessageBox.Show("Please enter only numbers!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            g_box.Text = g_box.Text.Remove(g_box.Text.Length - 1);
        }
        private void b_box_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(b_box.Text, "[^0-9]")) return;
            MessageBox.Show("Please enter only numbers!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            b_box.Text = b_box.Text.Remove(b_box.Text.Length - 1);
        }
    }
}
