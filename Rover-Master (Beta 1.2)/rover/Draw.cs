using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsharpGDI;
using System.Threading;

namespace rover
{
    public class Draw : gdi32
    {
        private Rover_Win main;
        public Draw(Rover_Win maininstance)
        {
            main = maininstance;
        }
        public static Icon Extract(string file, int number, bool largeIcon)
        {
            IntPtr large;
            IntPtr small;
            ExtractIconEx(file, number, out large, out small, 1);
            try
            {
                return Icon.FromHandle(largeIcon ? large : small);
            }
            catch
            {
                return null;
            }
        }
        public void draw_icon(object obj)
        {
            int index = (int)obj;
            Icon ico = Extract(@"C:\Windows\System32\user32.dll", index, true);
            Icon ico_rover = new Icon(Rover_Win.base_folder + "dag.ico");
            while (!Rover_Win.stop_drawing)
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                using (Graphics g = Graphics.FromHdc(hdc))
                {
                    if(index != 2)
                        g.DrawIcon(ico, Cursor.Position.X, Cursor.Position.Y);
                    else
                        g.DrawIcon(ico_rover, Cursor.Position.X, Cursor.Position.Y);
                }
                DeleteDC(hdc);
                Thread.Sleep(1);
            }
        }
        public void draw_custom_ico(object obj)
        {
            string file = (string)obj;
            try
            {
                Icon ico = new Icon(file);
                while (!Rover_Win.stop_drawing)
                {
                    IntPtr hdc = GetDC(IntPtr.Zero);
                    using (Graphics g = Graphics.FromHdc(hdc))
                    {
                        g.DrawIcon(ico, Cursor.Position.X, Cursor.Position.Y);
                    }
                    DeleteDC(hdc);
                    Thread.Sleep(1);
                }
            }
            catch 
            {
                main.Invoke(new Action(() => 
                {
                    if (!Language.russian_lang)
                        main.say_smth("Aaaa. Oops, something went wrong. The file you selected is either damaged or not in a suitable format. Please select another file or try again.");
                    else
                        main.say_smth("Аааа. Упс! Что-то пошло не так. Выбранный файл либо поврежден, либо имеет неподходящий формат. Выберите другой файл или повторите попытку.");
                }));
            }
        }
    }
}
