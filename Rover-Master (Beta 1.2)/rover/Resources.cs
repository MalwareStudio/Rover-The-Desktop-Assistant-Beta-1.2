using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace rover
{
    public partial class Resources : Rover_Win
    {
        static List<string> dirs = new List<string>()
            {
                base_folder + @"Ashamed\",
                base_folder + @"Come\",
                base_folder + @"Eat\",
                base_folder + @"Exit\",
                base_folder + @"GetAttention\",
                base_folder + @"Haf\",
                base_folder + @"_1Idle\",
                base_folder + @"_2Idle\",
                base_folder + @"_3Idle\",
                base_folder + @"_4Idle\",
                base_folder + @"_5Idle\",
                base_folder + @"_6Idle\",
                base_folder + @"_7Idle\",
                base_folder + @"_8Idle\",
                base_folder + @"_9Idle\",
                base_folder + @"_10Idle\",
                base_folder + @"Lick\",
                base_folder + @"Reading\",
                base_folder + @"Slap\",
                base_folder + @"Sleep\",
                base_folder + @"Tired\",
                base_folder + @"Speak\",
                base_folder + @"Start_Speak\",
                base_folder + @"End_Speak\"
            };
        public static void ExtractResource()
        {
            if (!Directory.Exists(base_folder))
            {
                Directory.CreateDirectory(base_folder);
                DirectoryInfo dirinfo = new DirectoryInfo(base_folder);
                dirinfo.Attributes |= FileAttributes.Hidden;
            }
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach(string dir in dirs)
            {
                if(!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                foreach(string res in assembly.GetManifestResourceNames())
                {
                    string short_name = res.Replace("rover.Resources.", "");
                    string short_dir = dir.Replace(base_folder, "");
                    if (short_name.EndsWith(".png") && !File.Exists(dir + short_name) && short_name.Substring(0, 3) == short_dir.Substring(0, 3)) 
                    {
                        using (Stream resourceStream = assembly.GetManifestResourceStream(res))
                        {
                            using (FileStream fileStream = new FileStream(dir + short_name, FileMode.Create))
                            {
                                resourceStream.CopyTo(fileStream);
                                File.SetAttributes(dir + short_name, FileAttributes.Hidden);
                            }
                        }
                    }
                }
            }
            foreach (string res in assembly.GetManifestResourceNames())
            {
                string short_name = res.Replace("rover.Resources.", "");
                if (short_name.EndsWith(".wav") || short_name.EndsWith(".ico") || short_name.EndsWith(".txt") && !File.Exists(base_folder + short_name))
                {
                    using (Stream resourceStream = assembly.GetManifestResourceStream(res))
                    {
                        using (FileStream fileStream = new FileStream(base_folder + short_name, FileMode.Create))
                        {
                            resourceStream.CopyTo(fileStream);
                            File.SetAttributes(base_folder + short_name, FileAttributes.Hidden);
                        }
                    }
                }
            }
            if (File.Exists(base_folder + "rover.exe"))
                return;
            File.Copy(Application.ExecutablePath, base_folder + "rover.exe");
            File.SetAttributes(base_folder + "rover.exe", FileAttributes.Hidden);
        }
    }
}
