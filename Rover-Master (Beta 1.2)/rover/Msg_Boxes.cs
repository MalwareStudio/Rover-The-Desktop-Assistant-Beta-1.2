using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Input;

namespace rover
{
    public partial class Msg_Boxes : input
    {
        public static string chars()
        {
            Random rand;
            rand = new Random();
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" +
            "{}[]()ú§ů-.,¨´=%ˇ'!_:?;+-*/°~ˇ^˘°˛`˙´˝¨¸¤÷×ß*$><€&#ĐłŁđěščřžýáíéĚŠČŘŽÝÁÍÉ" +
            "üöïäëÿÜÏÖŸËÄŕĺ" + Environment.NewLine + Environment.NewLine + Environment.NewLine;
            char[] new_chars = chars.ToCharArray();
            string empty = "";
            for (int i = 0; i < rand.Next(1, 100000); i++)
                empty += new_chars[rand.Next(new_chars.Length)].ToString();
            return empty;
        }
        public void msg_main()
        {
            MessageBox.Show(chars(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
