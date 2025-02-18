using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Input;

namespace rover
{
    public partial class Mouse_Input : input
    {
        public void mouse_main(int x, int y, int style)
        {
            switch(style)
            {
                case 0:
                    SetCursorPos(x, y);
                    mouse_event(MouseEventFlags.LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                    mouse_event(MouseEventFlags.LEFTUP, 0, 0, 0, UIntPtr.Zero);
                    break;
                case 1:
                    SetCursorPos(x, y);
                    mouse_event(MouseEventFlags.RIGHTDOWN, 0, 0, 0, UIntPtr.Zero);
                    mouse_event(MouseEventFlags.RIGHTUP, 0, 0, 0, UIntPtr.Zero);
                    break;
            }
        }
    }
}
