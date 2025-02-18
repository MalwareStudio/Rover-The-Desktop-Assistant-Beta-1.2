using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace rover
{
    public partial class TTS_Win : Form
    {
        private Rover_Win main;
        public TTS_Win(Rover_Win maininstance)
        {
            InitializeComponent();
            main = maininstance;
            if (!Language.russian_lang) return;
            settingsToolStripMenuItem.Text = Language.Lang_RU[Language.words.form_speak_settings];
            label1.Text = Language.Lang_RU[Language.words.form_speak_text];
            text_input.Text = Language.Lang_RU[Language.words.form_speak_text_inside];
            button1.Text = Language.Lang_RU[Language.words.form_speak_button];
            Text = Language.Lang_RU[Language.words.fomr_speak_win];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TTS_engine.is_speaking) return;
            //main.Stop_Sound(0);
            main.say_smth(text_input.Text);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TTS_settings settings = new TTS_settings();
            settings.Show();
            settings.Update();
        }

        private void text_input_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
