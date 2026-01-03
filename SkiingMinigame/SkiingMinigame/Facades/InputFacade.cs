using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.Facades
{
    public static class InputFacade
    {
        private static KeyboardState CurrentState { get; set; }
        private static KeyboardState PreviousState { get; set; }
        // i'm not touching this, i trust your code will not lead to the endless pause loop
        // IT DIDN'T WORK I'VE BEEN LIED TO

        public static void Update()
        {
            PreviousState = CurrentState;
            CurrentState = Keyboard.GetState();
        }

        public static bool IsKeyDown(IEnumerable<Keys> keys)
            => keys.Any(IsKeyDown);

        public static bool IsKeyDown(Keys key)
            => CurrentState.IsKeyDown(key);

        public static bool WasKeyJustPressed(Keys key)
            => PreviousState.IsKeyUp(key) && CurrentState.IsKeyDown(key);
    }
}
