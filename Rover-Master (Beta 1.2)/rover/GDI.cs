using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsharpGDI;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace rover
{
    public partial class GDI : gdi32
    {
        public static bool is_gdi = false;
        public void erase_tool()
        {
            InvalidateRect(NULL, NULL, true);
        }
        public void gdi_filter(int filter, int red, int green, int blue)
        {
            int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
            switch(filter)
            {
                case 0:
                    {
                        IntPtr hdc = GetDC(NULL);
                        IntPtr brush = CreateSolidBrush(ColorTranslator.ToWin32(Color.FromArgb(red, green, blue)));
                        SelectObject(hdc, brush);
                        BitBlt(hdc, 0, 0, x, y, hdc, 0, 0, TernaryRasterOperations.MERGECOPY);
                        DeleteObject(brush);
                        DeleteDC(hdc);
                    }
                    break;
                case 1:
                    {
                        IntPtr hdc = GetDC(NULL);
                        IntPtr mhdc = CreateCompatibleDC(hdc);
                        IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
                        SelectObject(mhdc, hbit);
                        BitBlt(mhdc, 0, 0, x, y, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                        BITMAPINFOHEADER bhead = new BITMAPINFOHEADER();
                        BITMAPINFO bitInfo = new BITMAPINFO();
                        bitInfo.bmiHeader.biSize = (uint)Marshal.SizeOf(bhead);
                        bitInfo.bmiHeader.biWidth = x;
                        bitInfo.bmiHeader.biHeight = -y;
                        bitInfo.bmiHeader.biPlanes = 1;
                        bitInfo.bmiHeader.biBitCount = 32;
                        bitInfo.bmiHeader.biCompression = 0;

                        int datasize = x * y * 4;
                        byte[] byte_table = new byte[datasize];
                        GetDIBits(mhdc, hbit, 0, (uint)y, byte_table, ref bitInfo, DIB_Color_Mode.DIB_RGB_COLORS);

                        for (int i = 0; i < datasize; i += 4)
                        {
                            byte_table[i + 1] = byte_table[i + 2] = byte_table[i];
                        }

                        IntPtr winDC = GetDC(NULL);
                        IntPtr grayscaleBitmap = CreateBitmap(x, y, 1, 32, byte_table);
                        SelectObject(mhdc, grayscaleBitmap);
                        BitBlt(winDC, 0, 0, x, y, mhdc, 0, 0, TernaryRasterOperations.SRCCOPY);

                        DeleteObject(grayscaleBitmap);
                        DeleteObject(hbit);
                        DeleteDC(mhdc);
                        ReleaseDC(IntPtr.Zero, hdc);
                        ReleaseDC(NULL, winDC);
                    }
                    break;
            }
        }
        public void gdi_blur(object obj)
        {
            Tuple<int, int, int, int, byte> pars = (Tuple<int, int, int, int, byte>)obj;
            int style = pars.Item1;
            int speed = pars.Item2;
            int dur = pars.Item3;
            int radius = pars.Item4;
            byte opacity = pars.Item5;
            Random rand;
            is_gdi = true;
            switch (style)
            {
                case 0:
                    {
                        for (int num = 0; num < dur; num++)
                        {
                            if (!is_gdi) return;
                            rand = new Random();
                            int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
                            IntPtr hdc = GetDC(NULL);
                            IntPtr mhdc = CreateCompatibleDC(hdc);
                            IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
                            IntPtr holdbit = SelectObject(mhdc, hbit);
                            BitBlt(mhdc, 0, 0, x, y, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                            AlphaBlend(hdc, rand.Next(-radius, radius), 0, x, y, mhdc, 0, 0, x, y, new BLENDFUNCTION(0, 0, opacity, 0));
                            SelectObject(mhdc, holdbit);
                            DeleteObject(holdbit);
                            DeleteObject(hbit);
                            DeleteDC(mhdc);
                            DeleteDC(hdc);
                            Thread.Sleep(speed);
                        }
                    }
                    break;
                case 1:
                    {
                        for (int num = 0; num < dur; num++)
                        {
                            if (!is_gdi) return;
                            rand = new Random();
                            int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
                            IntPtr hdc = GetDC(NULL);
                            IntPtr mhdc = CreateCompatibleDC(hdc);
                            IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
                            IntPtr holdbit = SelectObject(mhdc, hbit);
                            BitBlt(mhdc, 0, 0, x, y, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                            AlphaBlend(hdc, 0, rand.Next(-radius, radius), x, y, mhdc, 0, 0, x, y, new BLENDFUNCTION(0, 0, opacity, 0));
                            SelectObject(mhdc, holdbit);
                            DeleteObject(holdbit);
                            DeleteObject(hbit);
                            DeleteDC(mhdc);
                            DeleteDC(hdc);
                            Thread.Sleep(speed);
                        }
                    }
                    break;
                case 2:
                    {
                        for (int num = 0; num < dur; num++)
                        {
                            if (!is_gdi) return;
                            rand = new Random();
                            int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
                            IntPtr hdc = GetDC(NULL);
                            IntPtr mhdc = CreateCompatibleDC(hdc);
                            IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
                            IntPtr holdbit = SelectObject(mhdc, hbit);
                            BitBlt(mhdc, 0, 0, x, y, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                            AlphaBlend(hdc, rand.Next(-radius, radius), rand.Next(-radius, radius), x, y, mhdc, 0, 0, x, y, new BLENDFUNCTION(0, 0, opacity, 0));
                            SelectObject(mhdc, holdbit);
                            DeleteObject(holdbit);
                            DeleteObject(hbit);
                            DeleteDC(mhdc);
                            DeleteDC(hdc);
                            Thread.Sleep(speed);
                        }
                    }
                    break;
                case 3:
                    {
                        for (int num = 0; num < dur; num++)
                        {
                            if (!is_gdi) return;
                            rand = new Random();
                            int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
                            IntPtr hdc = GetDC(NULL);
                            IntPtr hwnd = GetDesktopWindow();
                            IntPtr mhdc = CreateCompatibleDC(hdc);
                            IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
                            IntPtr holdbit = SelectObject(mhdc, hbit);
                            POINT[] lppoint = new POINT[3];
                            RECT myRect;
                            GetWindowRect(hwnd, out myRect);
                            if(rand.Next(2) == 1)
                            {
                                lppoint[0].X = (myRect.Left + radius) + 0;
                                lppoint[0].Y = (myRect.Top - radius) + 0;
                                lppoint[1].X = (myRect.Right + radius) + 0;
                                lppoint[1].Y = (myRect.Top + radius) + 0;
                                lppoint[2].X = (myRect.Left - radius) + 0;
                                lppoint[2].Y = (myRect.Bottom - radius) + 0;
                            }
                            else
                            {
                                lppoint[0].X = (myRect.Left - radius) + 0;
                                lppoint[0].Y = (myRect.Top + radius) + 0;
                                lppoint[1].X = (myRect.Right - radius) + 0;
                                lppoint[1].Y = (myRect.Top - radius) + 0;
                                lppoint[2].X = (myRect.Left + radius) + 0;
                                lppoint[2].Y = (myRect.Bottom + radius) + 0;
                            }
                            PlgBlt(mhdc, lppoint, hdc, myRect.Left, myRect.Top, myRect.Right - myRect.Left,
                            myRect.Bottom - myRect.Top, NULL, 0, 0);
                            AlphaBlend(hdc, 0, 0, x, y, mhdc, 0, 0, x, y, new BLENDFUNCTION(0, 0, opacity, 0));
                            SelectObject(mhdc, holdbit);
                            DeleteObject(holdbit);
                            DeleteObject(hbit);
                            DeleteDC(mhdc);
                            DeleteDC(hdc);
                            Thread.Sleep(speed);
                        }
                    }
                    break;
                case 4:
                    {
                        for (int num = 0; num < dur; num++)
                        {
                            if (!is_gdi) return;
                            int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
                            IntPtr hdc = GetDC(NULL);
                            IntPtr mhdc = CreateCompatibleDC(hdc);
                            IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
                            IntPtr holdbit = SelectObject(mhdc, hbit);
                            StretchBlt(mhdc, -radius, -radius, x + (radius*2), y + (radius*2), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                            AlphaBlend(hdc, 0, 0, x, y, mhdc, 0, 0, x, y, new BLENDFUNCTION(0, 0, opacity, 0));
                            SelectObject(mhdc, holdbit);
                            DeleteObject(holdbit);
                            DeleteObject(hbit);
                            DeleteDC(mhdc);
                            DeleteDC(hdc);
                            Thread.Sleep(speed);
                        }
                    }
                    break;
            }
        }
        public void gdi_invert(int red, int green, int blue, int style)
        {
            switch(style)
            {
                case 0:
                    {
                        int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
                        IntPtr hdc = GetDC(NULL);
                        BitBlt(hdc, 0, 0, x, y, hdc, 0, 0, TernaryRasterOperations.NOTSRCCOPY);
                        DeleteDC(hdc);
                    }
                    break;
                case 1:
                    {
                        int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
                        IntPtr hdc = GetDC(NULL);
                        IntPtr brush = CreateSolidBrush(ColorTranslator.ToWin32(Color.FromArgb(red, green, blue)));
                        SelectObject(hdc, brush);
                        PatBlt(hdc, 0, 0, x, y, TernaryRasterOperations.PATINVERT);
                        DeleteObject(brush);
                        DeleteDC(hdc);
                    }
                    break;
            }
        }
        public void gdi_tunnel(object obj)
        {
            Random rand;
            Tuple<int, int> pars = (Tuple<int, int>)obj;
            int speed = pars.Item1;
            int duration = pars.Item2;
            int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
            is_gdi = true;
            for (int num = 0; num < duration; num++)
            {
                if (!is_gdi) return;
                rand = new Random();
                IntPtr hdc = GetDC(NULL);
                IntPtr hwnd = GetDesktopWindow();
                if(Custom_Tunnel.tunnel_styles[0])
                    StretchBlt(hdc, 50, 50, x - 100, y - 100, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                else if (Custom_Tunnel.tunnel_styles[1])
                    StretchBlt(hdc, rand.Next(20), rand.Next(20), x - rand.Next(40), y - rand.Next(40), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                else if (Custom_Tunnel.tunnel_styles[2])
                {
                    POINT[] lppoint = new POINT[3];
                    RECT myRect;
                    GetWindowRect(hwnd, out myRect);
                    lppoint[0].X = (myRect.Left + 100) + 0;
                    lppoint[0].Y = (myRect.Top - 100) + 0;
                    lppoint[1].X = (myRect.Right + 100) + 0;
                    lppoint[1].Y = (myRect.Top + 100) + 0;
                    lppoint[2].X = (myRect.Left - 100) + 0;
                    lppoint[2].Y = (myRect.Bottom - 100) + 0;
                    PlgBlt(hdc, lppoint, hdc, myRect.Left - 25, myRect.Top - 25, (myRect.Right - myRect.Left) + 50, 
                    (myRect.Bottom - myRect.Top) + 50, NULL, 0, 0);
                }
                else if (Custom_Tunnel.tunnel_styles[3])
                    StretchBlt(hdc, -10, -10, x + 20, y + 20, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                else
                    StretchBlt(hdc, 50, 50, x - 100, y - 100, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                DeleteDC(hdc);
                Thread.Sleep(speed);
            }
        }
        public void gdi_melting(object obj)
        {
            Tuple<int, int, int, int, int> pars = (Tuple<int, int, int, int, int>)obj;
            int style = pars.Item1;
            int speed = pars.Item2;
            int dur = pars.Item3;
            int size = pars.Item4;
            int length = pars.Item5;
            Random rand;
            int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
            is_gdi = true;
            switch(style)
            {
                case 0:
                    {
                        for (int num = 0; num < dur; num++)
                        {
                            if (!is_gdi) return;
                            rand = new Random();
                            int r = rand.Next(x);
                            IntPtr hdc = GetDC(NULL);
                            BitBlt(hdc, r, rand.Next(-length, length), size, y, hdc, r, 0, TernaryRasterOperations.SRCCOPY);
                            DeleteDC(hdc);
                            Thread.Sleep(speed);
                        }
                    }
                    break;
                case 1:
                    {
                        for (int num = 0; num < dur; num++)
                        {
                            if (!is_gdi) return;
                            rand = new Random();
                            int r = rand.Next(y);
                            IntPtr hdc = GetDC(NULL);
                            BitBlt(hdc, rand.Next(-length, length), r, x, size, hdc, 0, r, TernaryRasterOperations.SRCCOPY);
                            DeleteDC(hdc);
                            Thread.Sleep(speed);
                        }
                    }
                    break;
                case 2:
                    {
                        for (int num = 0; num < dur; num++)
                        {
                            if (!is_gdi) return;
                            rand = new Random();
                            int r = rand.Next(y), r2 = rand.Next(x);
                            IntPtr hdc = GetDC(NULL);
                            BitBlt(hdc, rand.Next(-length, length), r, x, size, hdc, 0, r, TernaryRasterOperations.SRCCOPY);
                            BitBlt(hdc, r2, rand.Next(-length, length), size, y, hdc, r2, 0, TernaryRasterOperations.SRCCOPY);
                            DeleteDC(hdc);
                            Thread.Sleep(speed);
                        }
                    }
                    break;
            }
        }
        public void gdi_mandela()
        {
            int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
            IntPtr hdc = GetDC(NULL);
            IntPtr mhdc = CreateCompatibleDC(hdc);
            IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
            SelectObject(mhdc, hbit);
            BitBlt(mhdc, 0, 0, x, y, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
            BITMAPINFOHEADER bhead = new BITMAPINFOHEADER();
            BITMAPINFO bitInfo = new BITMAPINFO();
            bitInfo.bmiHeader.biSize = (uint)Marshal.SizeOf(bhead);
            bitInfo.bmiHeader.biWidth = x;
            bitInfo.bmiHeader.biHeight = -y;
            bitInfo.bmiHeader.biPlanes = 1;
            bitInfo.bmiHeader.biBitCount = 1;
            bitInfo.bmiHeader.biCompression = 0;

            int datasize = x * y * 4;
            byte[] byte_table = new byte[datasize];
            GetDIBits(mhdc, hbit, 0, (uint)y, byte_table, ref bitInfo, DIB_Color_Mode.DIB_RGB_COLORS);
            IntPtr winDC = GetDC(NULL);
            IntPtr grayscaleBitmap = CreateBitmap(x, y, 1, 1, byte_table);
            SelectObject(mhdc, grayscaleBitmap);
            BitBlt(winDC, 0, 0, x, y, mhdc, 0, 0, TernaryRasterOperations.SRCCOPY);
            DeleteObject(grayscaleBitmap);
            DeleteObject(hbit);
            DeleteDC(mhdc);
            ReleaseDC(IntPtr.Zero, hdc);
            ReleaseDC(NULL, winDC);
        }
        public void gdi_rgbquad()
        {
            Random rand;
            rand = new Random();
            int rnd_value = rand.Next(5);
            int x = Screen.PrimaryScreen.Bounds.Width, y = Screen.PrimaryScreen.Bounds.Height;
            is_gdi = true;
            for (int num = 0; num < 300; num++)
            {
                if (!is_gdi) return;
                IntPtr hdc = GetDC(NULL);
                IntPtr mhdc = CreateCompatibleDC(hdc);
                IntPtr hbit = CreateCompatibleBitmap(hdc, x, y);
                SelectObject(mhdc, hbit);
                BitBlt(mhdc, 0, 0, x, y, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                BITMAPINFOHEADER bhead = new BITMAPINFOHEADER();
                BITMAPINFO bitInfo = new BITMAPINFO();
                bitInfo.bmiHeader.biSize = (uint)Marshal.SizeOf(bhead);
                bitInfo.bmiHeader.biWidth = x;
                bitInfo.bmiHeader.biHeight = -y;
                bitInfo.bmiHeader.biPlanes = 1;
                bitInfo.bmiHeader.biBitCount = 32;
                bitInfo.bmiHeader.biCompression = 0;

                int datasize = x * y * 4;
                byte[] byte_table = new byte[datasize];
                GetDIBits(mhdc, hbit, 0, (uint)y, byte_table, ref bitInfo, DIB_Color_Mode.DIB_RGB_COLORS);

                switch(rnd_value)
                {
                    case 0:
                        {
                            for (int i = 0; i < datasize; i += 4)
                            {
                                byte_table[i + 1] += byte_table[i] += byte_table[i] += 10;
                            }
                        }
                        break;
                    case 1:
                        {
                            for (int i = 0; i < datasize; i += 4)
                            {
                                byte_table[i] += byte_table[i + 1] += byte_table[i + 1] += 10;
                            }
                        }
                        break;
                    case 2:
                        {
                            for (int i = 0; i < datasize; i += 4)
                            {
                                byte_table[i] += byte_table[i] += byte_table[i + 2] += 10;
                            }
                        }
                        break;
                    case 3:
                        {
                            for (int i = 0; i < datasize; i += 4)
                            {
                                byte_table[i + 1] = byte_table[i + 1] += byte_table[i + 2] += 10;
                            }
                        }
                        break;
                    case 4:
                        {
                            for (int i = 0; i < datasize; i += 4)
                            {
                                byte_table[i] += byte_table[i + 1] += byte_table[x/2] += 10;
                            }
                        }
                        break;
                }
                IntPtr winDC = GetDC(NULL);
                IntPtr grayscaleBitmap = CreateBitmap(x, y, 1, 32, byte_table);
                SelectObject(mhdc, grayscaleBitmap);
                BitBlt(winDC, 0, 0, x, y, mhdc, 0, 0, TernaryRasterOperations.SRCCOPY);
                DeleteObject(grayscaleBitmap);
                DeleteObject(hbit);
                DeleteDC(mhdc);
                ReleaseDC(IntPtr.Zero, hdc);
                ReleaseDC(NULL, winDC);
                Thread.Sleep(10);
            }
        }
        public void Light(int x, int y, int w, int h)
        {
            IntPtr hdc = GetDC(NULL);
            BitBlt(hdc, x, y, w, h, hdc, 0, 0, TernaryRasterOperations.SRCPAINT);
            DeleteDC(hdc);
        }
        public void Light(object obj)
        {
            Random rand;
            rand = new Random();
            Tuple<int, int, int, int, int, bool, int> pars = (Tuple<int, int, int, int, int, bool, int>)obj;
            int x = pars.Item1;
            int y = pars.Item2;
            int w = pars.Item3;
            int h = pars.Item4;
            int count = pars.Item5;
            bool rnd = pars.Item6;
            int speed = pars.Item7;
            is_gdi = true;
            for (int i = 0; i < count; i++)
            {
                if (!is_gdi) return;
                IntPtr hdc = GetDC(NULL);
                if (!rnd)
                    BitBlt(hdc, x, y, w, h, hdc, 0, 0, TernaryRasterOperations.SRCPAINT);
                else
                    BitBlt(hdc, x + rand.Next(-5, 5), y + rand.Next(-5, 5), w, h, hdc, 0, 0, TernaryRasterOperations.SRCPAINT);
                DeleteDC(hdc);
                Thread.Sleep(speed);
            }
        }
        public void Dark(int x, int y, int w, int h)
        {
            IntPtr hdc = GetDC(NULL);
            StretchBlt(hdc, x, y, w, h, hdc, 0, 0, w, h, TernaryRasterOperations.SRCAND);
            DeleteDC(hdc);
        }
        public void Dark(object obj)
        {
            Random rand;
            rand = new Random();
            Tuple<int, int, int, int, int, bool, int> pars = (Tuple<int, int, int, int, int, bool, int>)obj;
            int x = pars.Item1;
            int y = pars.Item2;
            int w = pars.Item3;
            int h = pars.Item4;
            int count = pars.Item5;
            bool rnd = pars.Item6;
            int speed = pars.Item7;
            is_gdi = true;
            for (int i = 0; i < count; i++)
            {
                if (!is_gdi) return;
                IntPtr hdc = GetDC(NULL);
                if(!rnd)
                    StretchBlt(hdc, x, y, w, h, hdc, 0, 0, w, h, TernaryRasterOperations.SRCAND);
                else
                    StretchBlt(hdc, x + rand.Next(-5, 5), y + rand.Next(-5, 5), w, h, hdc, 0, 0, w, h, TernaryRasterOperations.SRCAND);
                DeleteDC(hdc);
                Thread.Sleep(speed);
            }
        }
        public void Pattern(int x, int y, int w, int h)
        {
            Random rand;
            rand = new Random();
            IntPtr hdc = GetDC(NULL);
            byte[] bits = { 0x0, 0x0, 0x3c, 0x24, 0x24, 0x3c, 0x0, 0x0 };
            IntPtr bitmap = CreateBitmap(rand.Next(32), rand.Next(32), 1, 1, bits);
            IntPtr brush = CreatePatternBrush(bitmap);
            SetBkColor(hdc, ColorTranslator.ToWin32(Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255))));
            SelectObject(hdc, brush);
            PatBlt(hdc, x, y, w, h, TernaryRasterOperations.PATINVERT);
            DeleteObject(bitmap);
            DeleteObject(brush);
            DeleteDC(hdc);
        }
        public void Pattern(Color clr, byte[] bits, int x, int y, int w, int h)
        {
            Random rand;
            rand = new Random();
            IntPtr hdc = GetDC(NULL);
            IntPtr bitmap = CreateBitmap(8, 8, 1, 1, bits);
            IntPtr brush = CreatePatternBrush(bitmap);
            SetBkColor(hdc, ColorTranslator.ToWin32(clr));
            SelectObject(hdc, brush);
            PatBlt(hdc, x, y, w, h, TernaryRasterOperations.PATINVERT);
            DeleteObject(bitmap);
            DeleteObject(brush);
            DeleteDC(hdc);
        }
        public void Hatch(Color back, Color hatch, int style, int x, int y, int w, int h)
        {
            IntPtr hdc = GetDC(NULL);
            IntPtr brush = CreateHatchBrush(style, ColorTranslator.ToWin32(hatch));
            SetBkColor(hdc, ColorTranslator.ToWin32(back));
            SelectObject(hdc, brush);
            PatBlt(hdc, x, y, w, h, TernaryRasterOperations.PATINVERT);
            DeleteObject(brush);
            DeleteDC(hdc);
        }
        public void Melt(int x, int y, int w, int h, int style)
        {
            Random rand;
            rand = new Random();
            IntPtr hdc;
            int r = rand.Next(w);
            int r2 = rand.Next(w);
            switch (style)
            {
                case 0:
                    hdc = GetDC(NULL);
                    BitBlt(hdc, r2, rand.Next(-25, 25), 100, h, hdc, r2, 0, TernaryRasterOperations.SRCCOPY);
                    DeleteDC(hdc);
                    break;
                case 1:
                    hdc = GetDC(NULL);
                    BitBlt(hdc, rand.Next(-25, 25), r, w, 100, hdc, 0, r, TernaryRasterOperations.SRCCOPY);
                    DeleteDC(hdc);
                    break;
                case 2:
                    hdc = GetDC(NULL);
                    BitBlt(hdc, r2, rand.Next(-25, 25), 100, h, hdc, r2, 0, TernaryRasterOperations.SRCCOPY);
                    BitBlt(hdc, rand.Next(-25, 25), r, w, 100, hdc, 0, r, TernaryRasterOperations.SRCCOPY);
                    DeleteDC(hdc);
                    break;
            }
        }
        public void Filter(int x, int y, int w, int h, Color clr, byte alpha)
        {
            IntPtr hdc = GetDC(NULL);
            IntPtr mhdc = CreateCompatibleDC(hdc);
            IntPtr hbit = CreateCompatibleBitmap(hdc, w, h);
            IntPtr holdbit = SelectObject(mhdc, hbit);
            IntPtr brush = CreateSolidBrush(ColorTranslator.ToWin32(clr));
            SelectObject(mhdc, brush);
            BitBlt(mhdc, x, y, w, h, hdc, 0, 0, TernaryRasterOperations.MERGECOPY);
            AlphaBlend(hdc, x, y, w, h, mhdc, 0, 0, w, h, new BLENDFUNCTION(0, 0, alpha, 0));
            SelectObject(mhdc, holdbit);
            DeleteObject(holdbit);
            DeleteObject(hbit);
            DeleteDC(mhdc);
            DeleteDC(hdc);
        }
        public void RQuad(int x, int y, int w, int h, int bits, byte alpha, int style)
        {
            Random rand;
            rand = new Random();
            IntPtr hdc = GetDC(NULL);
            IntPtr mhdc = CreateCompatibleDC(hdc);
            IntPtr hbit = CreateCompatibleBitmap(hdc, w, h);
            //IntPtr holdbit = SelectObject(mhdc, hbit);
            SelectObject(mhdc, hbit);
            BitBlt(mhdc, x, y, w, h, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
            BITMAPINFOHEADER bhead = new BITMAPINFOHEADER();
            BITMAPINFO bitInfo = new BITMAPINFO();
            bitInfo.bmiHeader.biSize = (uint)Marshal.SizeOf(bhead);
            bitInfo.bmiHeader.biWidth = w;
            bitInfo.bmiHeader.biHeight = -h;
            bitInfo.bmiHeader.biPlanes = 1;
            bitInfo.bmiHeader.biBitCount = (ushort)bits;
            bitInfo.bmiHeader.biCompression = 0;
            int datasize = w * h * 4;
            byte[] byte_table = new byte[datasize];
            GetDIBits(mhdc, hbit, 0, (uint)h, byte_table, ref bitInfo, DIB_Color_Mode.DIB_RGB_COLORS);
            switch (style)
            {
                case 0:
                    for (int i = 0; i < datasize; i += 4)
                    {
                        byte_table[i + 1] += byte_table[i] = byte_table[i] += 10;
                    }
                    break;
                case 1:
                    for (int i = 0; i < datasize; i += 4)
                    {
                        byte_table[i] += byte_table[i + 1] += byte_table[i + 1] += 10;
                    }
                    break;
                case 2:
                    for (int i = 0; i < datasize; i += 4)
                    {
                        byte_table[i] += byte_table[i] += byte_table[i + 2] += 10;
                    }
                    break;
                case 3:
                    for (int i = 0; i < datasize; i += 4)
                    {
                        byte_table[i + 1] += byte_table[w / 4] += byte_table[w / 2] += 10;
                    }
                    break;
                case 4:
                    for (int i = 0; i < datasize; i += 4)
                    {
                        byte_table[i] += byte_table[i + 1] += byte_table[w / 2] += 10;
                    }
                    break;
                case 5:
                    for (int i = 0; i < datasize; i += 4)
                    {
                        byte_table[i] = byte_table[i] += byte_table[i + 1] += 10;
                    }
                    break;
                case 6:
                    for (int i = 0; i < datasize; i += 4)
                    {
                        byte_table[i] = byte_table[w / 3] += byte_table[i] += 10;
                    }
                    break;
                default:
                    break;
            }
            IntPtr winDC = GetDC(NULL);
            IntPtr grayscaleBitmap = CreateBitmap(w, h, 1, (uint)bits, byte_table);
            SelectObject(mhdc, grayscaleBitmap);
            AlphaBlend(winDC, x, y, w, h, mhdc, 0, 0, w, h, new BLENDFUNCTION(0, 0, alpha, 0));
            DeleteObject(grayscaleBitmap);
            DeleteObject(hbit);
            DeleteDC(mhdc);
            ReleaseDC(IntPtr.Zero, hdc);
            ReleaseDC(NULL, winDC);
        }
        public void Blt(int x, int y, int w, int h)
        {
            IntPtr hdc = GetDC(NULL);
            BitBlt(hdc, x, y, w, h, hdc, 0, 0, TernaryRasterOperations.SRCCOPY);
            DeleteDC(hdc);
        }
        public void Plg()
        {
            Random rand;
            rand = new Random();
            IntPtr hdc = GetDC(NULL);
            IntPtr hwnd = GetDesktopWindow();
            POINT[] lppoint = new POINT[3];
            RECT myRect;
            GetWindowRect(hwnd, out myRect);
            if (rand.Next(2) == 1)
            {
                lppoint[0].X = (myRect.Left + 50) + 0;
                lppoint[0].Y = (myRect.Top - 50) + 0;
                lppoint[1].X = (myRect.Right + 50) + 0;
                lppoint[1].Y = (myRect.Top + 50) + 0;
                lppoint[2].X = (myRect.Left - 50) + 0;
                lppoint[2].Y = (myRect.Bottom - 50) + 0;
            }
            else
            {
                lppoint[0].X = (myRect.Left - 50) + 0;
                lppoint[0].Y = (myRect.Top + 50) + 0;
                lppoint[1].X = (myRect.Right - 50) + 0;
                lppoint[1].Y = (myRect.Top - 50) + 0;
                lppoint[2].X = (myRect.Left + 50) + 0;
                lppoint[2].Y = (myRect.Bottom + 50) + 0;
            }
            PlgBlt(hdc, lppoint, hdc, myRect.Left, myRect.Top, myRect.Right - myRect.Left,
            myRect.Bottom - myRect.Top, NULL, 0, 0);
            DeleteDC(hdc);
        }
    }
}
