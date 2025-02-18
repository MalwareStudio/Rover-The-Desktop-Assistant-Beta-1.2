using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;

namespace rover
{
    public class Sound_Player
    {
        public string filePath;
        public bool looping = false;
        public static SoundPlayer soundPlayer;
        public void PlayWav(object state)
        {
            try
            {
                soundPlayer = new SoundPlayer(filePath);
                if (!looping)
                {
                    soundPlayer.Load();
                    soundPlayer.Play();
                    return;
                }
                soundPlayer.Load();
                soundPlayer.PlayLooping();
            }
            catch{ }
        }
        public void StopWav(object obj)
        {
            if (soundPlayer == null) return;
            soundPlayer.Stop();
            soundPlayer.Dispose();
        }
    }
}
