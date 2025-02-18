using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace rover
{
    public class Idle
    {
        private Rover_Win main;
        private Timer idle_tmr;
        private Animation anim;
        public Idle(Rover_Win maininstance)
        {
            main = maininstance;
        }
        public void Idle_main()
        {
            idle_tmr = new Timer(30000);
            idle_tmr.Elapsed += TimerElapsed;
            idle_tmr.AutoReset = true;
            idle_tmr.Start();
        }
        private void Idle_Thread()
        {
            if (!TTS_engine.is_speaking && !Rover_Win.is_click && !Rover_Win.is_destructive && !Rover_Win.is_haf &&
            !Rover_Win.is_eat && !Rover_Win.is_sleeping && !Rover_Win.is_lick && !Rover_Win.is_exit && !Rover_Win.is_slap)
            {
                Random rand;
                rand = new Random();
                anim = new Animation(main);
                switch (rand.Next(9))
                {
                    case 0:
                        anim.Rover_Bone();
                        break;
                    case 1:
                        anim.Rover_Cook();
                        break;
                    case 2:
                        anim.Rover_Hyped();
                        break;
                    case 3:
                        anim.Rover_Look();
                        break;
                    case 4:
                        anim.Rover_Paint();
                        break;
                    case 5:
                        anim.Rover_Pose();
                        break;
                    case 6:
                        anim.Rover_Rub();
                        break;
                    case 7:
                        anim.Rover_Snif();
                        break;
                    case 8:
                        anim.Rover_Tap();
                        break;
                }
            }
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Idle_Thread();
        }
    }
}
