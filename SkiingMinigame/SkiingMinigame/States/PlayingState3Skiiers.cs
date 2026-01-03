using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SkiingMinigame.FakeBL.Objects;
using SkiingMinigame.Services.InputService;
using SkiingMinigame.Services.Spawners;
using SkiingMinigameBL.Extensions;
using SkiingMinigameBL.Objects.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.States
{
    internal class PlayingState3Skiiers(Game1 context)
        : State(context)
    {
        private PlayingStateInputService InputService { get; } = new PlayingStateInputService();
        private Spawner Rockspawner = new Spawner(context.Rock, context, Game1.RockMinSpawnTimeMs, Game1.RockMaxSpawnTimeMs);
        private Spawner snowmanspawner = new Spawner(context.Snowman, context, Game1.SnowmanMinSpawnTimeMs, Game1.SnowmandMaxSpawnTimeMS);
        private Spawner Treespawner = new Spawner(context.Treebottom, context, Game1.TreeMinSpawnTimeMs, Game1.TreeMaxSpawnTimeMs);
        private ObstacleScroller Rockscroller = new ObstacleScroller(context.Rock);
        private ObstacleScroller Treescroller = new ObstacleScroller(context.Treebottom);
        private ObstacleScroller Snowmanscroller = new ObstacleScroller(context.Snowman);


        public override void Update(GameTime gameTime)
        {
            foreach (Player1Sprite playersprite in Context.Player)
            {
               playersprite.Update(gameTime, Game1.PLAYER_STEP, InputService);
            }
            // Check if the user wants to Pause the game
            if (InputService.ShouldPause())
                Context.ChangeState(new PausedState(Context, this));

            Context.Background1.ChangeYPosition(-Game1.BACKGROUND_STEP);
            Context.Background2.ChangeYPosition(-Game1.BACKGROUND_STEP);

            Rockspawner.Spawn(gameTime.ElapsedGameTime.TotalMilliseconds);
            snowmanspawner.Spawn(gameTime.ElapsedGameTime.TotalMilliseconds);
            Treespawner.Spawn(gameTime.ElapsedGameTime.TotalMilliseconds);

            Rockscroller.Scroll(-Game1.OBSTACLE_STEP, true, false);
            Treescroller.Scroll(-Game1.OBSTACLE_STEP, true, false);
            Snowmanscroller.Scroll(-Game1.OBSTACLE_STEP, true, true);

        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var rockSprites in Context.Rock) 
            {
                rockSprites.Draw(Context._spriteBatch);
            }
            foreach (var snowmanSprites in Context.Snowman)
            {
                snowmanSprites.Draw(Context._spriteBatch);
            }
            foreach (var treeSprites in Context.Treebottom)
            {
                treeSprites.Draw(Context._spriteBatch);
            }
            foreach (var player in Context.Player)
            {
                player.Draw(Context._spriteBatch);
            }

            Context.Background1.Draw(Context._spriteBatch);
            Context.Background2.Draw(Context._spriteBatch);

        }
    }
}
