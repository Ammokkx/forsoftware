using Microsoft.Xna.Framework;
using SkiingMinigame.FakeBL.Objects.Sprites;
using SkiingMinigame.Services.InputService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.States
{
    internal class PlayingStateNoEnemies(Game1 context)
        : State(context)
    {
        private PlayingStateInputService InputService { get; } = new PlayingStateInputService();

        public override void Update(GameTime gameTime)
        {
            foreach (Player1Sprite playersprite in Context.Player)
            {
                //mostly just copy paste from the enemy variant but without all the... well, enemies.
                playersprite.Update(gameTime, Game1.PLAYER_STEP, InputService);


              
                if (playersprite.Position.X < Game1.PlayGroundBoundsLeft)
                {
                    playersprite.ChangeXPosition(Game1.BoopRightOrDown);
                }
                if (playersprite.Position.Y < Game1.PlayGroundBoundsUp)
                {
                    playersprite.ChangeYPosition(Game1.BoopRightOrDown);
                }
                if (playersprite.Position.X > Game1.PlayGroundBoundsRight)
                {
                    playersprite.ChangeXPosition(Game1.BoopLeftOrUp);
                }
                if (playersprite.Position.Y > Game1.PlayGroundBoundsDown)
                {
                    playersprite.ChangeYPosition(Game1.BoopLeftOrUp);
                }
            }
            if (InputService.ShouldPause())
                Context.ChangeState(new PausedState(Context, this));

            Context.Background1.ChangeYPosition(-Game1.BACKGROUND_STEP);
            Context.Background2.ChangeYPosition(-Game1.BACKGROUND_STEP);
        }

        public override void Draw(GameTime gameTime)
        {
            Context.Background1.Draw(Context._spriteBatch);
            Context.Background2.Draw(Context._spriteBatch);

            foreach (var player in Context.Player)
            {
                player.Draw(Context._spriteBatch);
            }
        }
    }
}
