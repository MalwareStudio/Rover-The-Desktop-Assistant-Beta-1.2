using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Environment;
using System.Windows.Forms;
using System.Threading;

namespace rover
{
    public class Junk_Cleaner
    {
        private Rover_Win main;
        public Junk_Cleaner(Rover_Win maininstance)
        {
            main = maininstance;
        }
        string win_temp = @"C:\Windows\Temp";
        string user_temp = Environment.GetFolderPath(SpecialFolder.UserProfile) + @"\AppData\Local\Temp";
        int result = 0;
        int all_files = 0;
        long size = 0;
        long curent_size = 0;
        double final_size = 0;
        long drive_size = 0;
        long drive_free = 0;
        public void Junk_main()
        {
            DriveInfo drive = new DriveInfo(@"C:");
            Thread.Sleep(1000);
            while(TTS_engine.is_speaking) { Thread.Sleep(1); }
            string[] target_dirs = { win_temp, user_temp };
            foreach(string t_dirs in target_dirs)
            {
                string[] main_files = Directory.GetFiles(t_dirs);
                foreach (string file in main_files)
                {
                    try 
                    { 
                        FileInfo file_info = new FileInfo(file);
                        curent_size = file_info.Length;
                        size += curent_size;
                        result += 1;
                        all_files += 1;
                        File.Delete(file);
                    }
                    catch 
                    {
                        result -= 1;
                        size -= curent_size;
                    }
                }
                string[] get_dir = Directory.GetDirectories(t_dirs, "*", SearchOption.AllDirectories);
                foreach (string dir_path in get_dir)
                {
                    string[] get_files = Directory.GetFiles(dir_path);
                    foreach (string file in get_files)
                    {
                        try 
                        { 
                            FileInfo file_info = new FileInfo(file);
                            curent_size = file_info.Length;
                            size += curent_size;
                            result += 1;
                            all_files += 1;
                            File.Delete(file);
                        }
                        catch 
                        {
                            result -= 1;
                            size -= curent_size;
                        }
                        Thread.Sleep(1);
                    }
                }
            }
            final_size = Math.Round(size / Math.Pow(1024, 2), 1);
            drive_size = drive.TotalSize;
            drive_free = drive.AvailableFreeSpace;
            double size_round = Math.Round(drive_size / (Math.Pow(1024, 3)), 1);
            double free_round = Math.Round(drive_free / (Math.Pow(1024, 3)), 1);
            MessageBox.Show("Total Files " + all_files + Environment.NewLine +
            "Deleted Files " + result + Environment.NewLine +
            final_size + " MB Released" + Environment.NewLine +
            "Total Size Of Main Drive " + size_round + " GB" + Environment.NewLine +
            "Available Space On Main Drive " + free_round + " GB", "Junk Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
     }
}
