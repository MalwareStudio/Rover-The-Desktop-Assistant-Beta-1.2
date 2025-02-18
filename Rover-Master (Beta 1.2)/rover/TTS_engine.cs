using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Globalization;

namespace rover
{
    public class TTS_engine
    {
        private Rover_Win main;
        private SynchronizationContext synchronizationContext;
        public TTS_engine(Rover_Win maininstance)
        {
            main = maininstance;
            synchronizationContext = SynchronizationContext.Current;
            Language.choosen_lang();
        }
        public static SpeechSynthesizer synthesizer;
        public static bool is_speaking = false;
        public void speach(object obj)
        {
            form_change(0);
            is_speaking = true;
            Animation anim = new Animation(main);
            anim.Rover_Start_Speak();
            Tuple<string, int, int> pars = (Tuple<string, int, int>)obj;
            synthesizer = new SpeechSynthesizer();
            synthesizer.StateChanged += Synthesizer_Changed;
            synthesizer.SpeakProgress += Synthesizer_SpeakProgress;
            if(Language.russian_lang)
                synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult, 0, new CultureInfo("ru-RU"));
            else
                synthesizer.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult, 0, new CultureInfo("en-US"));
            synthesizer.Volume = pars.Item2;
            synthesizer.Rate = pars.Item3;
            synthesizer.Speak(pars.Item1);
        }
        public void Synthesizer_Changed(object sender, StateChangedEventArgs e)
        {
            Animation anim = new Animation(main);
            if (e.State == SynthesizerState.Speaking)
            {
                anim.Rover_Speak();
            }
            else
            {
                form_change(1);
                is_speaking = false;
                anim.Rover_End_Speak();
            }
        }
        public void Synthesizer_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            synchronizationContext.Post(new SendOrPostCallback((state) =>
            {
                string spokentext = e.Text;
                main.bubble_box.AppendText(spokentext + " ");
                if (main.bubble_box.TextLength > 160)
                {
                    main.bubble_box.Clear();
                    main.bubble_box.AppendText(spokentext + " ");
                }
            }), null);
        }
        public void form_change(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        main.Invoke(new Action(() =>
                        {
                            main.contextMenuStrip1.Enabled = false;
                            main.bubble_box.Visible = true;
                        }));
                    }
                    break;
                case 1:
                    {
                        main.Invoke(new Action(() =>
                        {
                            if (!Rover_Win.is_destructive)
                                main.contextMenuStrip1.Enabled = true;
                            main.bubble_box.Clear();
                            main.bubble_box.Visible = false;
                        }));
                    }
                    break;
            }
        }
    }
}
