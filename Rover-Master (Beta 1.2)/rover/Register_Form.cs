using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Speech.Synthesis;
using System.Globalization;

namespace rover
{
    public partial class Register_Form : Form
    {
        public Register_Form()
        {
            InitializeComponent();
        }

        private void Register_Form_Load(object sender, EventArgs e)
        {

        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }
        private void ok_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(name_textbox.Text))
            {
                MessageBox.Show("Please enter a valid name", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(combo_language.SelectedItem == null)
            {
                MessageBox.Show("Please enter the language", "Invalid Language", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Registry_Class c_reg = new Registry_Class();
            c_reg.regs(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", 
            "FilterAdministratorToken", "1", 1);
            c_reg.regs(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "EnableLUA", "0", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "username", "\"" + name_textbox.Text + "\"", 0);
            c_reg.regs(RegistryHive.LocalMachine, @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", 
            "Shell", "explorer.exe, " + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\rover\rover.exe", 0);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tts_vol", "50", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tts_rate", "0", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "filter_red", "0", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "filter_green", "0", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "filter_blue", "0", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tunnel_speed", "1", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tunnel_duration", "5", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "tunnel_mode", "0", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_style", "0", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_speed", "1", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_duration", "5", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_size", "3", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "melting_length", "2", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_style", "1", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_speed", "1", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_duration", "5", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_radius", "2", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "blur_opacity", "5", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_red", "0", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_green", "0", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_blue", "0", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_x", "0", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_y", "0", 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_w", Screen.PrimaryScreen.Bounds.Width.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_h", Screen.PrimaryScreen.Bounds.Height.ToString(), 1);
            c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "pattern_bytes", "0x0, 0x0, 0x3c, 0x24, 0x24, 0x3c, 0x0, 0x0", 2);
            Registry_Class.UpdateVals();
            Resources.ExtractResource();
            Hide();
            Rover_Win f_rover = new Rover_Win();
            f_rover.Show();
        }

        private void combo_language_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool lang_ru = false;
            bool lang_en = false;
            SpeechSynthesizer syn = new SpeechSynthesizer();
            if (combo_language.SelectedIndex == 1)
            {
                foreach (InstalledVoice voice in syn.GetInstalledVoices())
                {
                    if (voice.VoiceInfo.Culture.Name.StartsWith("ru"))
                    {
                        lang_ru = true;
                    }
                }
                if (!lang_ru)
                {
                    MessageBox.Show("В вашей системе не удалось найти русский текст в речь. " +
                    "Пожалуйста, установите его, чтобы ровер мог говорить по-русски.", "Голос не найден",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    combo_language.SelectedItem = null;
                }
            }
            else if (combo_language.SelectedIndex == 0)
            {
                foreach (InstalledVoice voice in syn.GetInstalledVoices())
                {
                    if (voice.VoiceInfo.Culture.Name.StartsWith("en"))
                        lang_en = true;
                }
                if (!lang_en)
                {
                    MessageBox.Show("English Text to speech voice was not found on your system. " +
                    "Please install it so rover can speak English.", "Voice not found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    combo_language.SelectedItem = null;
                }
            }
            if(combo_language.SelectedItem != null)
            {
                Registry_Class c_reg = new Registry_Class();
                string selected_lang = combo_language.SelectedItem.ToString();
                c_reg.regs(RegistryHive.CurrentUser, @"SOFTWARE\rover", "lang", selected_lang, 0);
            }
        }
    }
}
