using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace rover
{
    public class Registry_Class
    {
        public enum Regval
        {
            filter_red,
            filter_green,
            filter_blue,
            tts_rate,
            tts_vol,
            tunnel_duration,
            tunnel_speed,
            username,
            lang,
            melting_style,
            melting_speed,
            melting_duration,
            melting_size,
            melting_length,
            blur_style,
            blur_speed,
            blur_duration,
            blur_radius,
            blur_opacity,
            pattern_red,
            pattern_green,
            pattern_blue,
            pattern_x,
            pattern_y,
            pattern_w,
            pattern_h,
            pattern_bytes
        }
        public static Dictionary<Regval, object> Regvalues { get; private set; } = new Dictionary<Regval, object>();
        public static void UpdateVals()
        {
            Regvalues.Clear();
            foreach(Regval reg in Enum.GetValues(typeof(Regval)))
            {
                Regvalues.Add(reg, Registry.GetValue(Registry.CurrentUser + @"\SOFTWARE\rover", reg.ToString(), null));
            }
        }
        public void regs(RegistryHive hive, string key_path, string subkey_path, string value, int index)
        {
            switch(index)
            {
                case 0:
                    {
                        using(RegistryKey base_path = RegistryKey.OpenBaseKey(hive, RegistryView.Default))
                        {
                            using(RegistryKey reg = base_path.CreateSubKey(key_path))
                            {
                                reg.SetValue(subkey_path, value, RegistryValueKind.String);
                            }
                        }
                    }
                    break;
                case 1:
                    {
                        using (RegistryKey base_path = RegistryKey.OpenBaseKey(hive, RegistryView.Default))
                        {
                            using (RegistryKey reg = base_path.CreateSubKey(key_path))
                            {
                                reg.SetValue(subkey_path, value, RegistryValueKind.DWord);
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        using (RegistryKey base_path = RegistryKey.OpenBaseKey(hive, RegistryView.Default))
                        {
                            using (RegistryKey reg = base_path.CreateSubKey(key_path))
                            {
                                Encoding encoding = Encoding.UTF8;
                                byte[] bytes = encoding.GetBytes(value);
                                reg.SetValue(subkey_path, bytes, RegistryValueKind.Binary);
                            }
                        }
                    }
                    break;
            }
        }
    }
}
