using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SkiingMinigame.Facades;
using SkiingMinigameBL.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.States
{
    public class GameOverState(Game1 context)
        : State(context)
    {
        public override void Update(GameTime gameTime)
        {
            // If we press enter we will return to the start screen. 
            // In this method we used 'IsKeyUp', instead of 'IsKeyDown'. The Update method runs every 16.6ms, this means that when we would check 'IsKeyDown' and enter is pressed,
            // it would change the state to 'StartScreenState', but in that state we again check 'enter' to start the game. Since we aren't fast enough to only press the key for 16.6ms
            // it would also trigger the IsKeyDown in that state, which again changes the state to playing. Checking for 'KeyUp' here stops that chain since it would only trigger once
            if (InputFacade.IsKeyDown(Keys.Enter))
                Context.ChangeState(new StartScreenState(Context));
        }

        public override void Draw(GameTime gameTime)
        {
            Context._spriteBatch.DrawStringInCenter(
                Context._graphics,
                Context._font,
                "Game Over. Press enter to go back to the startscreen.");
        }
    }
}