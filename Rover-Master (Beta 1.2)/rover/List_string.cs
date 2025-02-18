using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace rover
{
    public class List_string
    {
        public static string username = " " + Registry_Class.Regvalues[Registry_Class.Regval.username].ToString() + ". ";
        public static string[] welcome_msg = File.ReadAllLines(Rover_Win.base_folder + "EN_welcome.txt");
        public static string[] gdi = File.ReadAllLines(Rover_Win.base_folder + "EN_gdi.txt");
        public static string draw = "Let's draw something";
        public static string[] jokes = File.ReadAllLines(Rover_Win.base_folder + "EN_jokes.txt");
        public static string[] facts = File.ReadAllLines(Rover_Win.base_folder + "EN_facts.txt");
        public static string[] warning = 
            {
            "You are about to launch a dangerous payload that is guaranteed to damage your system." 
            + Environment.NewLine + "Are you sure you want to continue?",

            "THIS IS THE LAST WARNING!" + Environment.NewLine +
            "IF YOU RUN THIS PAYLOAD, YOUR SYSTEM WILL BE " +
            "IRREVERSIBLY DAMAGED!" + Environment.NewLine + "ALL YOUR PERSONAL DATA WILL ALSO BE DESTROYED!" + Environment.NewLine +
            "REALLY THINK ABOUT WHAT YOU ARE DOING!" + Environment.NewLine + "" + Environment.NewLine +
            "THE AUTHOR OF THIS SOFTWARE IS NOT RESPONSIBLE FOR ANY DAMAGES!",

            "SYSTEM CORRUPTION WARNING",
            "LAST WARNING"
        };
        public static string[] kill = File.ReadAllLines(Rover_Win.base_folder + "EN_kill.txt");
        public static string[] other = File.ReadAllLines(Rover_Win.base_folder + "EN_other.txt");
        public static string[] slap = File.ReadAllLines(Rover_Win.base_folder + "EN_slap.txt");
    }
    public class List_string_RU
    {
        static string username = Registry_Class.Regvalues[Registry_Class.Regval.username].ToString();
        public static string[] welcome_msg = File.ReadAllLines(Rover_Win.base_folder + "RU_welcome.txt");
        public static string[] gdi = File.ReadAllLines(Rover_Win.base_folder + "RU_gdi.txt");
        public static string draw = "Давайте нарисуем что-нибудь";
        public static string[] jokes = File.ReadAllLines(Rover_Win.base_folder + "RU_jokes.txt");
        public static string[] facts = File.ReadAllLines(Rover_Win.base_folder + "RU_facts.txt");
        public static string[] warning =
            {
            "Вы собираетесь запустить опасную полезную нагрузку, которая гарантированно повредит вашу систему."
            + Environment.NewLine + "Вы уверены что хотите продолжить?",

            "ЭТО ПОСЛЕДНЕЕ ПРЕДУПРЕЖДЕНИЕ!" + Environment.NewLine +
            "ЕСЛИ ВЫ ЗАПУСТИТЕ ЭТУ ПОЛЕЗНУЮ НАГРУЗКУ, ВАША СИСТЕМА БУДЕТ " +
            "НЕОБРАТИМО ПОВРЕЖДЕНО!" + Environment.NewLine + "ВСЕ ВАШИ ЛИЧНЫЕ ДАННЫЕ ТАКЖЕ БУДУТ УНИЧТОЖЕНЫ!" + Environment.NewLine +
            "ДЕЙСТВИТЕЛЬНО ДУМАЙТЕ, ЧТО ДЕЛАЕТЕ!" + Environment.NewLine + "" + Environment.NewLine +
            "АВТОР ЭТОЙ ПРОГРАММЫ НЕ НЕСЕТ ОТВЕТСТВЕННОСТИ ЗА ЛЮБОЙ УЩЕРБ!",

            "ПРЕДУПРЕЖДЕНИЕ О ПОВРЕЖДЕНИИ СИСТЕМЫ",
            "ПОСЛЕДНЕЕ ПРЕДУПРЕЖДЕНИЕ"
        };
        public static string[] kill = File.ReadAllLines(Rover_Win.base_folder + "RU_kill.txt");
        public static string[] other = File.ReadAllLines(Rover_Win.base_folder + "RU_other.txt");
    }
}
