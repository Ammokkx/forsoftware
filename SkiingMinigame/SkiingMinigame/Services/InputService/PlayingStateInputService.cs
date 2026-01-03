using Microsoft.Xna.Framework.Input;
using SkiingMinigame.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiingMinigame.FakeBL.Interfaces;

namespace SkiingMinigame.Services.InputService
{
    public class PlayingStateInputService : IPlayerInputMovementService // if i understood this right, then it makes sense to split the controls into two players. i also put down Z/W and A/Q because i have qwerty keyboard but also wanted to make sure it was compliant with the assignment
    {
        public bool Player1ShouldGoRight()
        {
            if (InputFacade.IsKeyDown([Keys.D]))
                return true;

            return false;
        }

        public bool Player1ShouldGoLeft()
        {
            if (InputFacade.IsKeyDown([Keys.Q, Keys.A]))
                return true;

            return false;
        }

        public bool Player1ShouldGoUp()
        {
            if (InputFacade.IsKeyDown([Keys.Z, Keys.W]))
                return true;

            return false;
        }

        public bool Player1ShouldGoDown()
        {
            if (InputFacade.IsKeyDown([Keys.S]))
                return true;

            return false;
        }

        public bool Player2ShouldGoRight()
        {
            if (InputFacade.IsKeyDown([Keys.Right]))
                return true;

            return false;
        }

        public bool Player2ShouldGoLeft()
        {
            if (InputFacade.IsKeyDown([Keys.Left]))
                return true;

            return false;
        }

        public bool Player2ShouldGoUp()
        {
            if (InputFacade.IsKeyDown([Keys.Up]))
                return true;

            return false;
        }

        public bool Player2ShouldGoDown()
        {
            if (InputFacade.IsKeyDown([Keys.Down]))
                return true;

            return false;
        }

        public bool ShouldPause()
        {
            if (InputFacade.WasKeyJustPressed(Keys.P) && InputFacade.IsKeyDown(Keys.P))
                return true;

            return false;
        }
    }
}