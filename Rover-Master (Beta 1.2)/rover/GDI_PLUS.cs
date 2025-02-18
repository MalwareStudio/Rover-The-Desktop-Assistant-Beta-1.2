using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDI_plus;
using CsharpGDI;
using System.Drawing;
using System.Threading;

namespace rover
{
    public partial class GDI_PLUS : gdi32_plus
    {
        public void Contrast(int x, int y, float val)
        {
            IntPtr hdc = gdi32.GetDC(gdi32.NULL);
            Bitmap bmp = CaptureScreen(hdc);
            Bitmap bmp2 = bmp;
            bmp2 = gdi32_plus.AdjustContrast(bmp, val);
            paint(bmp2, x, y);
            bmp2.Dispose();
            bmp.Dispose();
        }
        public void Hue(object obj)
        {
            Tuple<int, int, int, int, float> pars = (Tuple<int, int, int, int, float>)obj;
            int x = pars.Item1;
            int y = pars.Item2;
            int count = pars.Item3;
            int speed = pars.Item4;
            float val = pars.Item5;
            for(int i = 0; i < count; i++)
            {
                IntPtr hdc = gdi32.GetDC(gdi32.NULL);
                Bitmap bmp = CaptureScreen(hdc);
                Bitmap bmp2 = bmp;
                bmp2 = gdi32_plus.AdjustHue(bmp, val);
                paint(bmp2, x, y);
                bmp2.Dispose();
                bmp.Dispose();
                Thread.Sleep(speed);
            }
        }
        public void Saturation(int x, int y, float val)
        {
            IntPtr hdc = gdi32.GetDC(gdi32.NULL);
            Bitmap bmp = CaptureScreen(hdc);
            Bitmap bmp2 = bmp;
            bmp2 = gdi32_plus.AdjustSaturation(bmp, val);
            paint(bmp2, x, y);
            bmp2.Dispose();
            bmp.Dispose();
        }
        public void Pixelate(int x, int y)
        {
            IntPtr hdc = gdi32.GetDC(gdi32.NULL);
            Bitmap bmp = CaptureScreen(hdc);
            int pixelSize = 4;
            int newWidth = bmp.Width / pixelSize;
            int newHeight = bmp.Height / pixelSize;
            Bitmap pixelatedBitmap = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(pixelatedBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(bmp, new Rectangle(0, 0, newWidth, newHeight));
            }
            paint(pixelatedBitmap, x, y);
        }
        private IntPtr memoryDC;
        private IntPtr hBitmap;
        public Bitmap CaptureScreen(IntPtr hdc)
        {
            // Get the screen size
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Create a compatible memory DC and bitmap
            memoryDC = gdi32.CreateCompatibleDC(hdc);
            hBitmap = gdi32.CreateCompatibleBitmap(hdc, screenWidth, screenHeight);
            gdi32.SelectObject(memoryDC, hBitmap);

            // Use BitBlt to capture the screen into the memory DC
            gdi32.BitBlt(memoryDC, 0, 0, screenWidth, screenHeight, hdc, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
            gdi32.DeleteDC(hdc);

            // Create a new Bitmap from the captured memory DC
            Bitmap bitmap = Bitmap.FromHbitmap(hBitmap);
            return bitmap;
        }
        public void paint(Bitmap bmp, int x, int y)
        {
            IntPtr hdc = gdi32.GetDC(IntPtr.Zero);
            IntPtr mhdc = gdi32.CreateCompatibleDC(hdc);
            IntPtr hbit = gdi32.CreateCompatibleBitmap(hdc, x, y);
            IntPtr holdbit = gdi32.SelectObject(mhdc, hbit);
            using (Graphics g = Graphics.FromHdc(mhdc))
            {
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(bmp, 0, 0, x, y);
            }
            gdi32.BitBlt(hdc, 0, 0, x, y, mhdc, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
            gdi32.SelectObject(mhdc, holdbit);
            gdi32.DeleteObject(holdbit);
            gdi32.DeleteObject(hbit);
            gdi32.DeleteDC(mhdc);
            gdi32.DeleteDC(hdc);
            gdi32.ReleaseDC(IntPtr.Zero, hdc);
        }
    }
}
