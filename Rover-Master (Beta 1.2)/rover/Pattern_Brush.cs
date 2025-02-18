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
    public partial class Pattern_Brush : Form
    {
        static int reg_red = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.pattern_red]);
        static int reg_green = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.pattern_green]);
        static int reg_blue = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.pattern_blue]);
        static int reg_x = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.pattern_x]);
        static int reg_y = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.pattern_y]);
        static int reg_w = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.pattern_w]);
        static int reg_h = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.pattern_h]);
        static byte[] reg_bytes;

        static int red = reg_red;
        static int green = reg_green;
        static int blue = reg_blue;
        static int x = reg_x;
        static int y = reg_y;
        static int w = reg_w;
        static int h = reg_h;
        static byte[] bytes;
        private Rover_Win main;
        public Pattern_Brush(Rover_Win maininstance)
        {
            InitializeComponent();
            r_box.Text = red.ToString();
            g_box.Text = green.ToString();
            b_box.Text = blue.ToString();
            x_box.Text = x.ToString();
            y_box.Text = y.ToString();
            w_box.Text = w.ToString();
            h_box.Text = h.ToString();
            Encoding encoding = Encoding.UTF8;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\rover"))
            {
                if (key != null)
                {
                    reg_bytes = (byte[])key.GetValue("pattern_bytes");
                    string stringValue = encoding.GetString(reg_bytes);
                    bytes_box.Text = stringValue;
                    bytes = reg_bytes;
                }
            }
            main = maininstance;
        }
        private void btn_use_Click(object sender, EventArgs e)
        {
            if(r_box.Text == "" || g_box.Text == "" || b_box.Text == "" || bytes_box.Text == "" || x_box.Text == ""
            || y_box.Text == "" || w_box.Text == "" || h_box.Text == "")
            {
                main.say_smth("Aaaa. Sorry, but the box cannot be empty.");
                Close();
                return;
            }
            Update_Vals();
            Hide();
            Thread.Sleep(500);
            GDI c_gdi = new GDI();
            try
            {
                c_gdi.Pattern(Color.FromArgb(red, green, blue), bytes, x, y, w, h);
            }
            catch 
            {
                main.say_smth("Aaaa. The number you selected is either too long or in an invalid format. Please try again.");
                Close();
            }
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_red", red.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_green", green.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_blue", blue.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_x", x.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_y", y.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_w", w.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_h", h.ToString(), 1);
            Encoding encoding = Encoding.UTF8;
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_bytes", encoding.GetString(bytes), 2);
            Close();
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            Registry_Class c_reg = new Registry_Class();
            r_box.Text = "0";
            g_box.Text = "0";
            b_box.Text = "0";
            x_box.Text = "0";
            y_box.Text = "0";
            w_box.Text = Screen.PrimaryScreen.Bounds.Width.ToString();
            h_box.Text = Screen.PrimaryScreen.Bounds.Height.ToString();
            bytes_box.Text = "0x0, 0x0, 0x3c, 0x24, 0x24, 0x3c, 0x0, 0x0";
            Update_Vals();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_red", red.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_green", green.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_blue", blue.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_x", x.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_y", y.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_w", w.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_h", h.ToString(), 1);
            Encoding encoding = Encoding.UTF8;
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_bytes", encoding.GetString(bytes), 2);
        }
        private void Update_Vals()
        {
            red = Convert.ToInt32(r_box.Text);
            green = Convert.ToInt32(g_box.Text);
            blue = Convert.ToInt32(b_box.Text);
            x = Convert.ToInt32(x_box.Text);
            y = Convert.ToInt32(y_box.Text);
            w = Convert.ToInt32(w_box.Text);
            h = Convert.ToInt32(h_box.Text);
            Encoding encoding = Encoding.UTF8;
            bytes = encoding.GetBytes(bytes_box.Text);
        }
        private void r_box_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(r_box.Text, "[^0-9]")) return;
            main.say_smth("Aaaa. Please enter only numbers!");
            r_box.Text = r_box.Text.Remove(r_box.Text.Length - 1);
            Close();
        }
        private void g_box_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(g_box.Text, "[^0-9]")) return;
            main.say_smth("Aaaa. Please enter only numbers!");
            g_box.Text = g_box.Text.Remove(g_box.Text.Length - 1);
            Close();
        }
        private void b_box_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(b_box.Text, "[^0-9]")) return;
            main.say_smth("Aaaa. Please enter only numbers!");
            b_box.Text = b_box.Text.Remove(b_box.Text.Length - 1);
            Close();
        }
        private void bytes_box_TextChanged(object sender, EventArgs e)
        {

        }
        private void x_box_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(x_box.Text, "[^0-9]")) return;
            main.say_smth("Aaaa. Please enter only numbers!");
            x_box.Text = x_box.Text.Remove(x_box.Text.Length - 1);
            Close();
        }
        private void y_box_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(y_box.Text, "[^0-9]")) return;
            main.say_smth("Aaaa. Please enter only numbers!");
            y_box.Text = y_box.Text.Remove(y_box.Text.Length - 1);
            Close();
        }
        private void w_box_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(w_box.Text, "[^0-9]")) return;
            main.say_smth("Aaaa. Please enter only numbers!");
            w_box.Text = w_box.Text.Remove(w_box.Text.Length - 1);
            Close();
        }
        private void h_box_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(h_box.Text, "[^0-9]")) return;
            main.say_smth("Aaaa. Please enter only numbers!");
            h_box.Text = h_box.Text.Remove(h_box.Text.Length - 1);
            Close();
        }
    }
}
