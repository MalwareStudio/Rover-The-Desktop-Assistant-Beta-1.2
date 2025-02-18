using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rover
{
    public class Animation
    {
        private static Image Rover_Char;
        private System.Threading.Timer t_sound_stop, t_sound_play, t_sound_play2, t_sound_play3;
        private Sound_Player c_player, c_player2, c_player3;
        private static Thread th_load, th_play, th_play2, th_play3, th_stop, th_paint;
        private Rover_Win main;
        public Animation(Rover_Win maininstance)
        {
            main = maininstance;
        }
        public void Animation_main()
        {
            th_paint = new Thread(Rover_Paint_Thread);
            th_paint.Start();
        }
        private void Create_Thread()
        {
            th_play = new Thread(new ParameterizedThreadStart(Play_Sound));
            th_play2 = new Thread(new ParameterizedThreadStart(Play_Sound));
            th_play3 = new Thread(new ParameterizedThreadStart(Play_Sound));
            th_stop = new Thread(Stop_Sound);
        }
        private static string base_folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\rover\";
        private enum GifName
        {
            blink,
            get_bone,
            look,
            tap,
            pose,
            rub,
            hmm,
            hyped,
            cook,
            draw,
            ashamed,
            come,
            eat,
            exit,
            attention,
            get_book,
            haf,
            lick,
            read,
            return_book,
            slap,
            sleep,
            tired,
            speak,
            start_speak,
            end_speak
        }
        private Dictionary<GifName, string> GifPath = new Dictionary<GifName, string>
        {
            //IDLE 
            { GifName.blink, base_folder + @"_1Idle\" },
            { GifName.get_bone, base_folder + @"_2Idle\" },
            { GifName.look, base_folder + @"_3Idle\" },
            { GifName.tap, base_folder + @"_4Idle\" },
            { GifName.pose, base_folder + @"_5Idle\" },
            { GifName.rub, base_folder + @"_6Idle\" },
            { GifName.hmm, base_folder + @"_7Idle\" },
            { GifName.hyped, base_folder + @"_8Idle\" },
            { GifName.cook, base_folder + @"_9Idle\" },
            { GifName.draw, base_folder + @"_10Idle\" },
            //SPECIFIED
            { GifName.ashamed, base_folder + @"Ashamed\" },
            { GifName.come, base_folder + @"Come\" },
            { GifName.eat, base_folder + @"Eat\" },
            { GifName.exit, base_folder + @"Exit\" },
            { GifName.attention, base_folder + @"GetAttention\" },
            { GifName.haf, base_folder + @"Haf\" },
            { GifName.lick, base_folder + @"Lick\" },
            { GifName.read, base_folder + @"Reading\" },
            { GifName.slap, base_folder + @"Slap\" },
            { GifName.sleep, base_folder + @"Sleep\" },
            { GifName.tired, base_folder + @"Tired\" },
            { GifName.speak, base_folder + @"Speak\" },
            { GifName.start_speak, base_folder + @"Start_Speak\" },
            { GifName.end_speak, base_folder + @"End_Speak\" },
        };
        List<string> get_frames = new List<string>();
        private enum WavName
        {
            sniff,
            aslip,
            attention,
            breath,
            haf,
            lick,
            rub,
            slip,
            snoring,
            stir,
            tap,
            whine,
            jump,
            slap
        }
        private static Dictionary<WavName, string> WavPath = new Dictionary<WavName, string>
        {
            { WavName.sniff, base_folder + "0001.wav" },
            { WavName.aslip, base_folder + "Aslip.wav" },
            { WavName.attention, base_folder + "Attention.wav" },
            { WavName.breath, base_folder + "Breath.wav" },
            { WavName.haf, base_folder + "Haf.wav" },
            { WavName.lick, base_folder + "Lick.wav" },
            { WavName.rub, base_folder + "Scrape.wav" },
            { WavName.slip, base_folder + "Slip.wav" },
            { WavName.snoring, base_folder + "Snoring.wav" },
            { WavName.stir, base_folder + "Stir.wav" },
            { WavName.tap, base_folder + "Tap.wav" },
            { WavName.whine, base_folder + "Whine.wav" },
            { WavName.jump, base_folder + "Jump.wav" },
            { WavName.slap, base_folder + "Slap.wav" }
        };
        private void Play_Sound(object obj)
        {
            Tuple<string, int, bool, int> pars = (Tuple<string, int, bool, int>)obj;
            switch (pars.Item4)
            {
                case 0:
                    c_player = new Sound_Player();
                    c_player.filePath = pars.Item1;
                    c_player.looping = pars.Item3;
                    t_sound_play = new System.Threading.Timer(c_player.PlayWav, null, pars.Item2, Timeout.Infinite);
                    break;
                case 1:
                    c_player2 = new Sound_Player();
                    c_player2.filePath = pars.Item1;
                    c_player2.looping = pars.Item3;
                    t_sound_play2 = new System.Threading.Timer(c_player2.PlayWav, null, pars.Item2, Timeout.Infinite);
                    break;
                case 2:
                    c_player3 = new Sound_Player();
                    c_player3.filePath = pars.Item1;
                    c_player3.looping = pars.Item3;
                    t_sound_play3 = new System.Threading.Timer(c_player3.PlayWav, null, pars.Item2, Timeout.Infinite);
                    break;
            }
        }
        private void Stop_Sound(object obj)
        {
            int delay = (int)obj;
            c_player = new Sound_Player();
            t_sound_stop = new System.Threading.Timer(c_player.StopWav, null, delay, Timeout.Infinite);
        }
        private void Rover_Paint_Thread(object obj)
        {
            while (true)
            {
                main.Invoke(new Action(() =>
                {
                    if (Rover_Char != null)
                    {
                        main.rover_box.Image = Rover_Char;
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }));
                Thread.Sleep(1);
            }
        }
        private void Image_Load(string dir_path, int interval, int times, int start_frame, int final_frame, int speed, int delay)
        {
            Task.Run(() => Wait(dir_path, interval, times, start_frame, final_frame, speed, delay));
        }
        private async Task Wait(string dir_path, int interval, int times, int start_frame, int final_frame, int speed, int delay)
        {
            await Task.Delay(delay);
            if (th_load != null && Rover_Char != null)
                th_load.Abort();
            th_load = new Thread(new ParameterizedThreadStart(Image_Process));
            th_load.Start(new Tuple<string, int, int, int, int, int>(dir_path, interval, times, start_frame, final_frame, speed));
        }
        private void Image_Process(object obj)
        {
            Tuple<string, int, int, int, int, int> pars = (Tuple<string, int, int, int, int, int>)obj;
            if (pars.Item6 > 0)
                Thread.Sleep(pars.Item6);
            get_frames = Directory.GetFiles(pars.Item1, "*.png").ToList();
            int steps = pars.Item4;
            int end_step = pars.Item5;
            int interval = pars.Item2;
            int times = pars.Item3;
            int speed = pars.Item6;
            for (int count = 0; count < times; count++)
            {
                if (steps == -1 && end_step == -1)
                {
                    foreach (string frame in get_frames)
                    {
                        Rover_Char = Image.FromFile(frame);
                        Thread.Sleep(speed);
                    }
                }
                else if (steps > end_step)
                {
                    for (int num = steps; num >= 0; num--)
                    {
                        Rover_Char = Image.FromFile(get_frames[num]);
                        Thread.Sleep(speed);
                    }
                }
                else
                {
                    for (int num = steps; num <= end_step; num++)
                    {
                        Rover_Char = Image.FromFile(get_frames[num]);
                        Thread.Sleep(speed);
                    }
                }
                Thread.Sleep(interval);
            }
        }
        public void Rover_Blink(int delay)
        {
            Image_Load(GifPath[GifName.blink], 3500, int.MaxValue, -1, -1, 100, delay);
        }
        public void Rover_Bone()
        {
            Create_Thread();
            string img = GifPath[GifName.get_bone];
            Image_Load(img, 0, 1, 0, 13, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.slip], 350, false, 0));
            th_play2.Start(new Tuple<string, int, bool, int>(WavPath[WavName.aslip], 8000, false, 1));
            Image_Load(img, 0, 20, 13, 14, 300, 1300);
            Image_Load(img, 0, 1, 12, 0, 100, 7200);
            Rover_Blink(8500);
        }
        public void Rover_Snif()
        {
            Create_Thread();
            string img = GifPath[GifName.look];
            Image_Load(img, 0, 1, -1, -1, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.breath], 50, true, 0));
            th_play2.Start(new Tuple<string, int, bool, int>(WavPath[WavName.sniff], 1550, true, 1));
            th_stop.Start(3000);
            Rover_Blink(3350);
        }
        public void Rover_Tap()
        {
            Create_Thread();
            string img = GifPath[GifName.tap];
            Image_Load(img, 0, 1, 0, 5, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.tap], 500, false, 0));
            Image_Load(img, 300, 1, 6, 6, 100, 500);
            Image_Load(img, 0, 1, 6, 12, 100, 900);
            Rover_Blink(1700);
        }
        public void Rover_Pose()
        {
            Create_Thread();
            string img = GifPath[GifName.pose];
            Image_Load(img, 0, 1, -1, -1, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.breath], 300, true, 0));
            th_stop.Start(1800);
            Rover_Blink(1800);
        }
        public void Rover_Rub()
        {
            Create_Thread();
            string img = GifPath[GifName.rub];
            Image_Load(img, 0, 1, -1, -1, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.rub], 400, false, 0));
            th_play2.Start(new Tuple<string, int, bool, int>(WavPath[WavName.rub], 800, false, 1));
            Rover_Blink(1200);
        }
        public void Rover_Look()
        {
            Create_Thread();
            string img = GifPath[GifName.hmm];
            Image_Load(img, 0, 1, -1, -1, 100, 0);
            Rover_Blink(2500);
        }
        public void Rover_Hyped()
        {
            Create_Thread();
            string img = GifPath[GifName.hyped];
            Image_Load(img, 0, 1, 0, 1, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.breath], 200, true, 0));
            th_stop.Start(5000);
            Image_Load(img, 0, 50, 2, 10, 100, 200);
            Image_Load(img, 0, 1, 1, 0, 50, 5000);
            Rover_Blink(5250);
        }
        public void Rover_Cook()
        {
            Create_Thread();
            string img = GifPath[GifName.cook];
            Image_Load(img, 0, 1, 0, 14, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.slip], 350, false, 0));
            th_play2.Start(new Tuple<string, int, bool, int>(WavPath[WavName.stir], 1800, true, 1));
            th_play3.Start(new Tuple<string, int, bool, int>(WavPath[WavName.aslip], 6000, false, 2));
            Image_Load(img, 0, 50, 15, 20, 100, 1600);
            Image_Load(img, 0, 1, 20, 35, 100, 5000);
            Rover_Blink(6600);
        }
        public void Rover_Paint()
        {
            Create_Thread();
            string img = GifPath[GifName.draw];
            Image_Load(img, 0, 1, 0, 20, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.slip], 500, false, 0));
            th_play2.Start(new Tuple<string, int, bool, int>(WavPath[WavName.breath], 2000, true, 1));
            th_play3.Start(new Tuple<string, int, bool, int>(WavPath[WavName.aslip], 7400, false, 2));
            Image_Load(img, 0, 50, 21, 25, 100, 2000);
            Image_Load(img, 0, 1, 26, 35, 100, 7400);
            Rover_Blink(9000);
        }
        public void Rover_Ashamed()
        {
            Create_Thread();
            string img = GifPath[GifName.ashamed];
            Image_Load(img, 0, 1, -1, -1, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int> (WavPath[WavName.whine], 600, false, 0));
            Rover_Blink(3000);
        }
        public void Rover_Come()
        {
            Image_Load(GifPath[GifName.come], 0, 1, -1, -1, 100, 0);
        }
        public void Rover_Eat()
        {
            Create_Thread();
            Image_Load(GifPath[GifName.eat], 0, 1, -1, -1, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.slip], 2500, false, 0));
            th_play2.Start(new Tuple<string, int, bool, int>(WavPath[WavName.lick], 4800, true, 1));
            th_play3.Start(new Tuple<string, int, bool, int>(WavPath[WavName.aslip], 7000, false, 2));
            Rover_Blink(8400);
        }
        public void Rover_Exit()
        {
            Create_Thread();
            Image_Load(GifPath[GifName.exit], 0, 1, -1, -1, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.jump], 2400, false, 0));
        }
        public void Rover_Get_Attention()
        {
            Create_Thread();
            Image_Load(GifPath[GifName.attention], 0, 1, -1, -1, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.attention], 200, false, 0));
            Rover_Blink(1100);
        }
        public void Rover_Haf()
        {
            Create_Thread();
            Image_Load(GifPath[GifName.haf], 0, 1, -1, -1, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.haf], 300, false, 0));
            Rover_Blink(800);
        }
        public void Rover_Lick()
        {
            Create_Thread();
            Image_Load(GifPath[GifName.lick], 0, 1, -1, -1, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.lick], 350, false, 0));
            Rover_Blink(1900);
        }
        public void Rover_Read()
        {
            Create_Thread();
            Image_Load(GifPath[GifName.read], 0, 1, 0, 6, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.slip], 0, false, 0));
            th_play2.Start(new Tuple<string, int, bool, int>(WavPath[WavName.aslip], 5800, false, 1));
            Image_Load(GifPath[GifName.read], 0, 5, 7, 17, 100, 700);
            Image_Load(GifPath[GifName.read], 0, 1, 18, 24, 100, 6100);
            Rover_Blink(7300);
        }
        public void Rover_Slap()
        {
            Create_Thread();
            Image_Load(GifPath[GifName.slap], 0, 1, 5, 0, 10, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.slap], 50, false, 0));
            Image_Load(GifPath[GifName.slap], 0, 1, -1, -1, 100, 60);
        }
        public void Rover_Sleep()
        {
            Image_Load(GifPath[GifName.sleep], 1200, int.MaxValue, -1, -1, 300, 0);
        }
        public void Rover_Speak()
        {
            Image_Load(GifPath[GifName.speak], 0, int.MaxValue, 3, 8, 100, 300);
        }
        public void Rover_Start_Speak()
        {
            Image_Load(GifPath[GifName.speak], 0, 1, 0, 2, 100, 0);
        }
        public void Rover_End_Speak()
        {
            Image_Load(GifPath[GifName.speak], 0, 1, 9, 14, 100, 200);
            Rover_Blink(600);
        }
        public void Rover_Tired()
        {
            Create_Thread();
            Image_Load(GifPath[GifName.tired], 0, 1, -1, -1, 100, 0);
            th_play.Start(new Tuple<string, int, bool, int>(WavPath[WavName.snoring], 1300, true, 0));
        }
        public void Rover_Wake()
        {
            Create_Thread();
            Image_Load(GifPath[GifName.tired], 0, 1, 12, 0, 100, 0);
            th_stop.Start(0);
            Rover_Blink(1300);
        }
    }
}
