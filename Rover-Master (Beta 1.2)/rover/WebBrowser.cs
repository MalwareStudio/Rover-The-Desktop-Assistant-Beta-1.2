using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rover
{
    public partial class WebBrowser : Form
    {
        public WebBrowser()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
        private void search_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(search_box.Text)) return;
            webBrowser1.Navigate(search_box.Text);
        }
        private void forward_btn_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }
        private void search_box_TextChanged(object sender, EventArgs e)
        {
            webBrowser1.Navigate(search_box.Text);
        }
        private void backward_btn_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }
        private void search_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13) return;
            webBrowser1.Navigate(search_box.Text);
        }
    }
}
