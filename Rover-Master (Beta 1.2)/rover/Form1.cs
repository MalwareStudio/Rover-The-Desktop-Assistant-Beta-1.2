using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using Microsoft.Win32;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace rover
{
    public partial class Rover_Win : Form
    {
        int temp = 0;
        int win_x = 180;
        int win_y = 250;
        static float font_size = 8;
        private WebBrowser f_web;
        private TTS_Win f_tts;
        private System.Threading.Timer t_eat, t_sleep, t_lick, t_come, t_haf, t_click, t_exit;
        private Thread th_msg, th_destructive;
        public bool mouseDown;
        public Point lastLocation;
        int x = Screen.PrimaryScreen.Bounds.Width;
        int y = Screen.PrimaryScreen.Bounds.Height;
        private Thread th_gdi_plus;
        private Thread th_gdi;
        private Thread th_junk;
        private Animation anim;
        private Idle idle;
        public Rover_Win()
        {
            InitializeComponent();
            Language.choosen_lang();
            Registry_Class.UpdateVals();
            Process currentprocess = Process.GetCurrentProcess();
            currentprocess.PriorityClass = ProcessPriorityClass.High;
            if (!File.Exists(@"C:\Windows\System32\UserAccountControlSettings.exe"))
                BackColor = Color.Aqua;
            if (!Language.russian_lang) return;
            drawToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_draw];
            speakToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_speak];
            eatToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_eat];
            sleepToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_sleep];
            lickToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_lick];
            hafToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_haf];
            exitToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_joke];
            killPCToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_fact];
            exitToolStripMenuItem1.Text = Language.Lang_RU[Language.words.context_exit];
            killPCToolStripMenuItem1.Text = Language.Lang_RU[Language.words.context_kill];
            filterToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_gdi_filter];
            invertToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_gdi_invert];
            tunnelToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_gdi_tunnel];
            meltingToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_gdi_melting];
            blurToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_gdi_blur];
            eraseToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_gdi_erase];
            redToolStripMenuItem.Text = Language.Lang_RU[Language.words.red];
            greenToolStripMenuItem.Text = Language.Lang_RU[Language.words.green];
            blueToolStripMenuItem.Text = Language.Lang_RU[Language.words.blue];
            customColorToolStripMenuItem.Text = Language.Lang_RU[Language.words.custom];
            grayToolStripMenuItem.Text = Language.Lang_RU[Language.words.gray];
            normalToolStripMenuItem.Text = Language.Lang_RU[Language.words.normal];
            redToolStripMenuItem1.Text = Language.Lang_RU[Language.words.red];
            greenToolStripMenuItem1.Text = Language.Lang_RU[Language.words.green];
            blueToolStripMenuItem1.Text = Language.Lang_RU[Language.words.blue];
            customToolStripMenuItem1.Text = Language.Lang_RU[Language.words.custom];
            fastToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_gdi_tunnel_slow];
            normalToolStripMenuItem1.Text = Language.Lang_RU[Language.words.normal];
            sToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_gdi_tunnel_fast];
            fastestToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_gdi_tunnel_faster];
            customToolStripMenuItem.Text = Language.Lang_RU[Language.words.custom];
            verticalToolStripMenuItem.Text = Language.Lang_RU[Language.words.vertical];
            horizontalToolStripMenuItem.Text = Language.Lang_RU[Language.words.horizontal];
            mixToolStripMenuItem.Text = Language.Lang_RU[Language.words.mix];
            verticalToolStripMenuItem1.Text = Language.Lang_RU[Language.words.vertical];
            horizontalToolStripMenuItem1.Text = Language.Lang_RU[Language.words.horizontal];
            radialToolStripMenuItem.Text = Language.Lang_RU[Language.words.radial];
            zoomToolStripMenuItem.Text = Language.Lang_RU[Language.words.zoom];
            mixToolStripMenuItem1.Text = Language.Lang_RU[Language.words.mix];
            errorIconToolStripMenuItem1.Text = Language.Lang_RU[Language.words.context_draw_error];
            warningIconToolStripMenuItem1.Text = Language.Lang_RU[Language.words.context_draw_warn];
            roverIconToolStripMenuItem1.Text = Language.Lang_RU[Language.words.context_draw_rover];
            customIconToolStripMenuItem1.Text = Language.Lang_RU[Language.words.context_draw_custom];
            stopDrawingToolStripMenuItem1.Text = Language.Lang_RU[Language.words.context_draw_stop];
        }
        private void rover_box_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void rover_box_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void rover_box_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown) return;
            Location = new Point((Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            Update();
        }
        private void tellAStoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_web = new WebBrowser();
            f_web.Show();
            f_web.Update();
        }
        private void killPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random rand;
            rand = new Random();
            if(temp > 5)
            {
                if (!Language.russian_lang)
                    say_smth("Ok that's enough! Fuck you annoying idiot! I am not your slave! Fuck it!");
                else
                    say_smth("Хорошо, этого достаточно! К черту надоедливого идиота! Я не твой раб! Черт возьми!");
                t_exit = new System.Threading.Timer(exit_new_timer, null, 1000, -1);
                return;
            }
            if (!Language.russian_lang)
                say_smth(List_string.other[rand.Next(2, List_string.other.Length)] + List_string.facts[rand.Next(2, List_string.facts.Length)]);
            else
                say_smth(List_string_RU.other[rand.Next(2, List_string_RU.other.Length)] + List_string_RU.facts[rand.Next(2, List_string_RU.facts.Length)]);
            temp++;
        }
        public static bool is_exit = false;
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Exit();
        }
        private void Exit()
        {
            if (TTS_engine.is_speaking || !contextMenuStrip1.Enabled) return;
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.welcome_msg[rand.Next(12, 19)] + List_string.username);
            else
                say_smth(List_string_RU.welcome_msg[rand.Next(12, 19)] + List_string.username);
            t_exit = new System.Threading.Timer(exit_new_timer, null, 1000, -1);
        }
        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            c_gdi.gdi_filter(0, 255, 0, 0);
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            c_gdi.gdi_filter(0, 0, 255, 0);
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            c_gdi.gdi_filter(0, 0, 0, 255);
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void customColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Custom_Filter f_filter = new Custom_Filter();
            f_filter.Show();
            f_filter.Update();
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            c_gdi.gdi_filter(1, 0, 0, 0);
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void eraseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            c_gdi.erase_tool();
        }
        private void fastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_tunnel));
            th_gdi.Start(new Tuple<int, int>(1000, 15));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_tunnel));
            th_gdi.Start(new Tuple<int, int>(500, 30));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_tunnel));
            th_gdi.Start(new Tuple<int, int>(300, 50));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void fastestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_tunnel));
            th_gdi.Start(new Tuple<int, int>(100, 150));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_melting));
            th_gdi.Start(new Tuple<int, int, int, int, int>(0, 100, 150, 50, 20));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_melting));
            th_gdi.Start(new Tuple<int, int, int, int, int>(1, 100, 150, 50, 20));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void mixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_melting));
            th_gdi.Start(new Tuple<int, int, int, int, int>(2, 100, 150, 50, 20));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void rGBQUADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(c_gdi.gdi_rgbquad);
            th_gdi.Start();
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Custom_Tunnel f_tunnel = new Custom_Tunnel();
            f_tunnel.Show();
            f_tunnel.Update();
        }
        private void verticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_blur));
            th_gdi.Start(new Tuple<int, int, int, int, byte>(1, 50, 5000, 10, 30));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void horizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_blur));
            th_gdi.Start(new Tuple<int, int, int, int, byte>(0, 50, 5000, 10, 30));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void radialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_blur));
            th_gdi.Start(new Tuple<int, int, int, int, byte>(3, 50, 5000, 10, 30));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void mixToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_blur));
            th_gdi.Start(new Tuple<int, int, int, int, byte>(2, 50, 5000, 10, 30));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.gdi_blur));
            th_gdi.Start(new Tuple<int, int, int, int, byte>(4, 50, 5000, 10, 30));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void normalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            c_gdi.gdi_invert(0, 0, 0, 0);
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void redToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            c_gdi.gdi_invert(255, 0, 0, 1);
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void greenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            c_gdi.gdi_invert(0, 255, 0, 1);
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void blueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            c_gdi.gdi_invert(0, 0, 255, 1);
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void lightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.Light));
            th_gdi.Start(new Tuple<int, int, int, int, int, bool, int>(1, 1, x, y, 50, true, 100));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void noEscapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            th_gdi = new Thread(new ParameterizedThreadStart(c_gdi.Dark));
            th_gdi.Start(new Tuple<int, int, int, int, int, bool, int>(1, 1, x, y, 50, true, 100));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI_PLUS c_gdi_plus = new GDI_PLUS();
            c_gdi_plus.Contrast(x, y, 1.5f);
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void hueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI_PLUS c_gdi_plus = new GDI_PLUS();
            th_gdi_plus = new Thread(new ParameterizedThreadStart(c_gdi_plus.Hue));
            th_gdi_plus.Start(new Tuple<int, int, int, int, float>(x, y, 30, 10, 10f));
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void saturationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI_PLUS c_gdi_plus = new GDI_PLUS();
            c_gdi_plus.Saturation(x, y, 1.5f);
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void mandelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI c_gdi = new GDI();
            c_gdi.gdi_mandela();
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void forwardDiagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random rand;
            rand = new Random();
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            GDI c_gdi = new GDI();
            c_gdi.Hatch(Color.FromArgb(r, g, b), Color.FromArgb(b, r, g), 3, 0, 0, x, y);
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void crossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random rand;
            rand = new Random();
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            GDI c_gdi = new GDI();
            c_gdi.Hatch(Color.FromArgb(r, g, b), Color.FromArgb(b, r, g), 4, 0, 0, x, y);
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void diagonalCrossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random rand;
            rand = new Random();
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            GDI c_gdi = new GDI();
            c_gdi.Hatch(Color.FromArgb(r, g, b), Color.FromArgb(b, r, g), 5, 0, 0, x, y);
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void backwardDiagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random rand;
            rand = new Random();
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            GDI c_gdi = new GDI();
            c_gdi.Hatch(Color.FromArgb(r, g, b), Color.FromArgb(b, r, g), 2, 0, 0, x, y);
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void horizontalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Random rand;
            rand = new Random();
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            GDI c_gdi = new GDI();
            c_gdi.Hatch(Color.FromArgb(r, g, b), Color.FromArgb(b, r, g), 0, 0, 0, x, y);
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void verticalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Random rand;
            rand = new Random();
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            GDI c_gdi = new GDI();
            c_gdi.Hatch(Color.FromArgb(r, g, b), Color.FromArgb(b, r, g), 1, 0, 0, x, y);
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void pixelateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GDI_PLUS c_gdi_plus = new GDI_PLUS();
            c_gdi_plus.Pixelate(x, y);
            Random rand;
            rand = new Random();
            if (!Language.russian_lang)
                say_smth(List_string.gdi[rand.Next(2, List_string.gdi.Length)]);
            else
                say_smth(List_string_RU.gdi[rand.Next(2, List_string_RU.gdi.Length)]);
        }
        private void customToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Custom_Melting f_melting = new Custom_Melting();
            f_melting.Show();
            f_melting.Update();
        }
        private void customToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Custom_Blur f_blur = new Custom_Blur();
            f_blur.Show();
            f_blur.Update();
        }
        private void patternToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pattern_Brush f_pattern = new Pattern_Brush(this);
            f_pattern.Show();
            f_pattern.Update();
        }
        private void stopGDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kill_gdi();
        }
        public void kill_gdi()
        {
            if (th_gdi != null)
                th_gdi.Abort();
            if (th_gdi_plus != null)
                th_gdi_plus.Abort();
            GDI.is_gdi = false;
        }
        public static bool is_invert = false;
        private void customToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Custom_Filter f_filter = new Custom_Filter();
            f_filter.Show();
            f_filter.Update();
            is_invert = true;
        }
        public static bool stop_drawing = false;
        private void errorIconToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            stop_drawing = false;
            Draw c_draw = new Draw(this);
            Thread th_draw = new Thread(c_draw.draw_icon);
            th_draw.Start(3);
            if (!Language.russian_lang)
                say_smth(List_string.draw);
            else
                say_smth(List_string_RU.draw);
        }
        private void warningIconToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            stop_drawing = false;
            Draw c_draw = new Draw(this);
            Thread th_draw = new Thread(c_draw.draw_icon);
            th_draw.Start(1);
            if (!Language.russian_lang)
                say_smth(List_string.draw);
            else
                say_smth(List_string_RU.draw);
        }
        private void roverIconToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            stop_drawing = false;
            Draw c_draw = new Draw(this);
            Thread th_draw = new Thread(c_draw.draw_icon);
            th_draw.Start(2);
            if (!Language.russian_lang)
                say_smth(List_string.draw);
            else
                say_smth(List_string_RU.draw);
        }

        private void stopDrawingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            stop_drawing = true;
        }
        private void speakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_tts = new TTS_Win(this);
            f_tts.Show();
        }
        public static string base_folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\rover\";
        private void Rover_Win_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            contextMenuStrip1.Enabled = false;
            TransparencyKey = BackColor;
            anim = new Animation(this);
            anim.Animation_main();
            anim.Rover_Come();
            t_come = new System.Threading.Timer(come_new, null, 2100, Timeout.Infinite);
        }
        private void come_new(object obj)
        {
            Random rand;
            Invoke(new Action(() => 
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\rover"))
                {
                    if (key != null && key.GetValue("come") != null)
                    {
                        rand = new Random();
                        if (!Language.russian_lang)
                            say_smth(List_string.welcome_msg[rand.Next(4, 10)] + List_string.username);
                        else
                            say_smth(List_string_RU.welcome_msg[rand.Next(4, 10)] + List_string.username);
                    }
                    else
                    {
                        Registry_Class c_reg = new Registry_Class();
                        c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "come", "1", 1);
                        if (!Language.russian_lang)
                            say_smth("Hey" + List_string.username + List_string.welcome_msg[2]);
                        else
                            say_smth("Привет" + List_string.username + List_string_RU.welcome_msg[2]);
                    }
                }
                contextMenuStrip1.Enabled = true;
                idle = new Idle(this);
                idle.Idle_main();
            }));
        }
        private void exit_new_timer(object obj)
        {
            is_exit = true;
            while (TTS_engine.is_speaking) { Thread.Sleep(1); }
            Thread.Sleep(1000);
            Invoke(new Action(() =>
            {
                anim = new Animation(this);
                anim.Rover_Exit();
                contextMenuStrip1.Enabled = false;
            }));
            Thread.Sleep(3100);
            Environment.Exit(-1);
        }
        private void sleep_new_timer(object obj)
        {
            if (is_sleeping)
            {
                anim = new Animation(this);
                anim.Rover_Sleep();
            }
        }
        public static bool is_sleeping = false;
        private void sleepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anim = new Animation(this);
            switch (is_sleeping)
            {
                case true:
                    bitchToolStripMenuItem.Enabled = true;
                    drawToolStripMenuItem.Enabled = true;
                    speakToolStripMenuItem.Enabled = true;
                    eatToolStripMenuItem.Enabled = true;
                    hafToolStripMenuItem.Enabled = true;
                    killPCToolStripMenuItem.Enabled = true;
                    exitToolStripMenuItem.Enabled = true;
                    exitToolStripMenuItem1.Enabled = true;
                    killPCToolStripMenuItem1.Enabled = true;
                    lickToolStripMenuItem.Enabled = true;
                    if (!Language.russian_lang)
                        sleepToolStripMenuItem.Text = "Sleep";
                    else
                        sleepToolStripMenuItem.Text = Language.Lang_RU[Language.words.context_sleep];
                    is_sleeping = false;
                    anim.Rover_Wake();
                    t_sleep = new System.Threading.Timer(sleep_new_timer, null, 1300, -1);
                    break;
                case false:
                    temp = 0;
                    bitchToolStripMenuItem.Enabled = false;
                    drawToolStripMenuItem.Enabled = false;
                    speakToolStripMenuItem.Enabled = false;
                    eatToolStripMenuItem.Enabled = false;
                    hafToolStripMenuItem.Enabled = false;
                    killPCToolStripMenuItem.Enabled = false;
                    exitToolStripMenuItem.Enabled = false;
                    exitToolStripMenuItem1.Enabled = false;
                    killPCToolStripMenuItem1.Enabled = false;
                    lickToolStripMenuItem.Enabled = false;
                    if (!Language.russian_lang)
                        sleepToolStripMenuItem.Text = "Wake Up";
                    else
                        sleepToolStripMenuItem.Text = Language.Lang_RU[Language.words.wake_up];
                    is_sleeping = true;
                    anim.Rover_Tired();
                    t_sleep = new System.Threading.Timer(sleep_new_timer, null, 1300, -1);
                    break;
            }
        }
        public static bool is_eat = false;
        private void eatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (is_eat) return;
            temp = 0;
            contextMenuStrip1.Enabled = false;
            is_eat = true;
            anim = new Animation(this);
            anim.Rover_Eat();
            t_eat = new System.Threading.Timer(eat_new_timer, null, 8600, -1);
        }
        public static bool is_haf = false;
        private void Rover_Win_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Exit();
            if(e.KeyCode == Keys.F6)
            {
                GDI c_gdi = new GDI();
                c_gdi.erase_tool();
            }
            if(e.KeyCode == Keys.F5)
            {
                stop_drawing = true;
                kill_gdi();
            }
            if(e.KeyCode == Keys.Up)
            {
                if (win_x > 300 || win_y > 370) return;
                Size = new Size(win_x += 10, win_y += 10);
                bubble_box.SelectionFont = new Font("Microsoft Sans Serif", font_size += (float)0.35);
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (win_x < 70 || win_y < 140) return;
                Size = new Size(win_x -= 10, win_y -= 10);
                bubble_box.SelectionFont = new Font("Microsoft Sans Serif", font_size -= (float)0.35);
            }
        }
        private void bubble_box_TextChanged(object sender, EventArgs e)
        {
            bubble_box.SelectionFont = new Font("Microsoft Sans Serif", font_size);
        }
        private void hafToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (is_haf) return;
            is_haf = true;
            anim = new Animation(this);
            anim.Rover_Haf();
            t_haf = new System.Threading.Timer(haf_new_timer, null, 800, -1);
        }

        private void haf_new_timer(object obj)
        {
            is_haf = false;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random rand;
            rand = new Random();
            if(temp > 5)
            {
                if (!Language.russian_lang)
                    say_smth("Ok that's enough! There will be no more jokes. Fuck you idiot!");
                else
                    say_smth("Хорошо, этого достаточно! Шуток больше не будет. Иди на хуй!");
                t_exit = new System.Threading.Timer(exit_new_timer, null, 1000, -1);
                return;
            }
            if (!Language.russian_lang)
                say_smth(List_string.other[rand.Next(2, List_string.other.Length)] + List_string.jokes[rand.Next(3, List_string.jokes.Length)]);
            else
                say_smth(List_string_RU.other[rand.Next(2, List_string_RU.other.Length)] + List_string_RU.jokes[rand.Next(3, List_string_RU.jokes.Length)]);
            temp++;
        }
        private void destructive_payload(object obj)
        {
            if (!Language.russian_lang)
            {
                DialogResult diag = MessageBox.Show(List_string.warning[0], List_string.warning[2], MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (diag == DialogResult.No)
                    return;
                DialogResult diag2 = MessageBox.Show(List_string.warning[1], List_string.warning[3], MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (diag2 == DialogResult.No)
                    return;
            }
            else
            {
                DialogResult diag = MessageBox.Show(List_string_RU.warning[0], List_string_RU.warning[2], MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (diag == DialogResult.No)
                    return;
                DialogResult diag2 = MessageBox.Show(List_string_RU.warning[1], List_string_RU.warning[3], MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (diag2 == DialogResult.No)
                    return;
            }
            Invoke(new Action(() => 
            {
                disable_context();
                if (!Language.russian_lang)
                    say_smth("Hey you fool" + List_string.username + List_string.kill[2]);
                else
                    say_smth("Эй ты дурак" + List_string.username + List_string_RU.kill[2]);
                Destructive c_destructive = new Destructive(this);
                Thread th_destructive = new Thread(c_destructive.destructive_main);
                th_destructive.Start();
            }));
        }
        private void killPCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            th_destructive = new Thread(destructive_payload);
            th_destructive.Start();
        }
        public static bool is_lick = false;
        private void lickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (is_lick) return;
            temp = 0;
            contextMenuStrip1.Enabled = false;
            is_lick = true;
            anim = new Animation(this);
            anim.Rover_Lick();
            t_lick = new System.Threading.Timer(lick_new_timer, null, 1900, -1);
        }
        private void lick_new_timer(object obj)
        {
            Invoke(new Action(() => 
            {
                contextMenuStrip1.Enabled = true;
                is_lick = false;
            }));
        }
        private void eat_new_timer(object obj)
        {
            Invoke(new Action(() =>
            {
                contextMenuStrip1.Enabled = true;
                is_eat = false;
            }));
        }
        public static bool is_click = false;
        private void rover_box_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!is_sleeping && !is_eat && !is_lick && !TTS_engine.is_speaking && !is_destructive && !is_click && !is_exit && !is_slap)
            {
                if(temp > 5)
                {
                    if (!Language.russian_lang)
                        say_smth("Ok that's enough! Fuck you annoying idiot! I am not your slave! Fuck it!");
                    else
                        say_smth("Хорошо, этого достаточно! К черту надоедливого идиота! Я не твой раб! Черт возьми!");
                    t_exit = new System.Threading.Timer(exit_new_timer, null, 1000, -1);
                    return;
                }
                is_click = true;
                anim = new Animation(this);
                anim.Rover_Get_Attention();
                t_click = new System.Threading.Timer(click_timer_new, null, 1100, -1);
                temp++;
            }
        }
        private void click_timer_new(object obj)
        {
            is_click = false;
        }
        public void say_smth(string text)
        {
            Random rand;
            rand = new Random();
            TTS_engine tts = new TTS_engine(this);
            Thread th_tts = new Thread(new ParameterizedThreadStart(tts.speach));
            th_tts.Start(new Tuple<string, int, int>(text, TTS_settings.volume, TTS_settings.rate));
        }
        public static bool is_slap = false;
        private void slapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            is_slap = true;
            contextMenuStrip1.Enabled = false;
            anim = new Animation(this);
            anim.Rover_Slap();
            Task.Run(() => React());
            temp += 2;
        }
        private async Task React()
        {
            Random rand;
            rand = new Random();
            await Task.Delay(700);
            anim = new Animation(this);
            anim.Rover_Ashamed();
            await Task.Delay(3300);
            is_slap = false;
            if (temp < 6)
                Invoke(new Action(() => say_smth(List_string.slap[rand.Next(2, 9)])));
            else
            {
                Invoke(new Action(() =>
                {
                    say_smth(List_string.slap[9]);
                    t_exit = new System.Threading.Timer(exit_new_timer, null, 1000, -1);
                }));
            }
        }
        private void junkCleanerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            say_smth("Ok, I'm going to see if there is any garbage in the system. This operation may take several minutes.");
            Junk_Cleaner c_junk = new Junk_Cleaner(this);
            th_junk = new Thread(c_junk.Junk_main);
            th_junk.Start();
        }
        public void Load_File()
        {
            Invoke(new Action(() => 
            {
                using (OpenFileDialog filediag = new OpenFileDialog())
                {
                    filediag.Title = "Select Icon";
                    filediag.InitialDirectory = @"C:\";
                    filediag.Filter = "Icon Files (*.ico)|*.ico";
                    filediag.Multiselect = false;
                    filediag.FilterIndex = 1;
                    filediag.ShowDialog();
                    Registry_Class reg = new Registry_Class();
                    reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "custom_ico", filediag.FileName, 0);
                }
            }));
        }
        private void msg_output(object obj)
        {
            if (Registry.GetValue(Registry.CurrentUser.ToString() + @"\SOFTWARE\rover", "custom_ico", null) != null)
            {
                DialogResult result = MessageBox.Show("Do you want to change the previous icon?", "Custom Icon",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                    Load_File();
            }
            else
                Load_File();
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\rover"))
            {
                object value = key.GetValue("custom_ico");
                string data = value.ToString();
                if (string.IsNullOrEmpty(data)) return;
                stop_drawing = false;
                Draw c_draw = new Draw(this);
                Thread th_draw = new Thread(c_draw.draw_custom_ico);
                th_draw.Start(data);
            }
        }
        public static bool is_displayed = false;
        private void customIconToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            th_msg = new Thread(msg_output);
            th_msg.Start();
        }
        public static bool is_destructive = false;
        public void disable_context()
        {
            is_destructive = true;
            contextMenuStrip1.Enabled = false;
        }
        private void Rover_Win_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
