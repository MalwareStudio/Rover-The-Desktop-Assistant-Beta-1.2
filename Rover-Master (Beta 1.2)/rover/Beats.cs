using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;

namespace rover
{
    public class Beats
    {
        public static int style = 0;
        public static int speed = 60;
        private byte[] getBytes(string text) { byte[] bytes = Encoding.ASCII.GetBytes(text); return bytes; }
        public void beat()
        {
            Random rand;
            rand = new Random();
            int subChunk1size = 16;
            short autdio_format = 1;
            short bitspersample = 16;
            short numchannels = (short)2;
            int sampleRate = 24000;
            int numSamples = sampleRate * speed;
            int byterate = sampleRate * numchannels * (bitspersample / 8);
            short blockAlign = (short)(numchannels * (bitspersample / 8));
            int subChunk2Size = numSamples * numchannels * (bitspersample / 8);
            int chunksize = 4 + (8 + subChunk1size) + (8 + subChunk2Size);
            string path = Rover_Win.base_folder + "wave.wav";
            if (File.Exists(path))
                File.Delete(path);
            FileStream wave_file = new FileStream(path, FileMode.Create);
            using (BinaryWriter writter = new BinaryWriter(wave_file))
            {
                writter.Write(getBytes("RIFF"));
                writter.Write(chunksize);
                writter.Write(getBytes("WAVE"));
                writter.Write(getBytes("fmt"));
                writter.Write((byte)32);
                writter.Write(subChunk1size);
                writter.Write(autdio_format);
                writter.Write(numchannels);
                writter.Write(sampleRate);
                writter.Write(byterate);
                writter.Write(blockAlign);
                writter.Write(bitspersample);
                writter.Write(getBytes("data"));
                writter.Write(subChunk2Size);
                byte[] zero_byte = { 0, 0, 0, 0 };
                writter.Write(zero_byte);
                float freq = 0;
                for (int i = 0; i < 300; i++)
                {
                    if (style == 0)
                        freq = rand.Next(20, 220);
                    else if (style == 1)
                        freq = rand.Next(40, 400);
                    else
                        freq = rand.Next(10, 200);
                    for (int j = 0; j < numSamples / 300; j++)
                    {
                        writter.Write(Convert.ToInt16((short.MaxValue * Math.Sign(Math.Sin((Math.PI * 8 * freq) / sampleRate * j)))));
                        writter.Write(Convert.ToInt16((short.MaxValue * Math.Sign(Math.Sin((Math.PI * 10 * freq) / sampleRate * j)))));
                    }
                }
            }
            using(SoundPlayer player = new SoundPlayer(path))
                player.PlayLooping();
        }
    }
}
