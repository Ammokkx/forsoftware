using Microsoft.Xna.Framework;
using SkiingMinigame.FakeBL.Objects.Sprites;
using SkiingMinigame.Services;
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
        private CollisionDetector collisionDetector = new CollisionDetector(context);
        public override void Update(GameTime gameTime)
        {
            foreach (Player1Sprite playersprite in Context.Player)
            {
                playersprite.Update(gameTime, Game1.PLAYER_STEP, InputService);

                collisionDetector.CheckCollisionWithWall(playersprite);
                
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
