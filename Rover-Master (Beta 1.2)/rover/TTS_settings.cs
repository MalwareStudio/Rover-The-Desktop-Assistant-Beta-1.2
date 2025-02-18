using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace rover
{
    public partial class TTS_settings : Form
    {
        public static int volume = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.tts_vol]), 
            rate = Convert.ToInt32(Registry_Class.Regvalues[Registry_Class.Regval.tts_rate]);
        public TTS_settings()
        {
            InitializeComponent();
            track_vol.Value = volume;
            track_rate.Value = rate;
            if (!Language.russian_lang) return;
            label1.Text = Language.Lang_RU[Language.words.form_speak_settings_rate];
            label2.Text = Language.Lang_RU[Language.words.form_speak_settings_vol];
            Text = Language.Lang_RU[Language.words.form_speak_settings_win];
        }
        private void track_vol_Scroll(object sender, EventArgs e)
        {
            volume = track_vol.Value;
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tts_vol", track_vol.Value.ToString(), 1);
        }
        private void track_rate_Scroll(object sender, EventArgs e)
        {
            rate = track_rate.Value;
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tts_rate", track_rate.Value.ToString(), 1);
        }
    }
}
