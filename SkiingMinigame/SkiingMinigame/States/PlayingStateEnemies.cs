using Microsoft.Xna.Framework;
using SkiingMinigame.FakeBL.Objects.Scrollers;
using SkiingMinigame.Services.InputService;
using SkiingMinigame.Services.Spawners;
using SkiingMinigame.FakeBL.Objects.Sprites;
using Microsoft.Xna.Framework.Content;
using SkiingMinigame.Services;

namespace SkiingMinigame.States
{
    internal class PlayingStateEnemies(Game1 context)
        : State(context)
    {
        // did this one first since it had the most moving parts, i know i need a ton of stuff for this to work and its hella ugly
        // did you know i had 3 classes originally for 1 skiier, 3 skiiers and 2 players and somehow i managed to just... make it a single one 'cuz it was redundant otherwise 

        private PlayingStateInputService InputService { get; } = new PlayingStateInputService();
        private Spawner Rockspawner = new RockSpawner(context.Rock, context, Game1.RockMinSpawnTimeMs, Game1.RockMaxSpawnTimeMs);
        private Spawner snowmanspawner = new SnowmanSpawner(context.Snowman, context, Game1.SnowmanMinSpawnTimeMs, Game1.SnowmandMaxSpawnTimeMS);
        private Spawner Treespawner = new TreeSpawner(context.Treebottom, context, Game1.TreeMinSpawnTimeMs, Game1.TreeMaxSpawnTimeMs);
        private ObstacleScroller Rockscroller = new ObstacleScroller(context.Rock);
        private ObstacleScroller Treescroller = new ObstacleScroller(context.Treebottom);
        private SnowmanScroller Snowmanscroller = new SnowmanScroller(context.Snowman);
        private CollisionDetector collisionDetector = new CollisionDetector(context);

        public override void Update(GameTime gameTime)
        {
            foreach (Player1Sprite playersprite in Context.Player)
            {
                playersprite.Update(gameTime, Game1.PLAYER_STEP, InputService);
                // just making sure the player stays within bounds. this does cause the players to slide into eachother but uhhhhh hey is that a rat over there
                
                collisionDetector.CheckCollisionWithWall(playersprite);

                // more collision detection! 
                collisionDetector.CheckCollisionWithObjects(playersprite);
            }
            if (!Context.Player2.IsHit)
            {
                Context.Player2.Update(gameTime, Game1.PLAYER_STEP, InputService);
                collisionDetector.CheckCollisionWithWall(Context.Player2);

                // more collision detection! 
                collisionDetector.CheckCollisionWithObjects(Context.Player2);
            }


            // Check if the user wants to Pause the game
            if (InputService.ShouldPause())
                Context.ChangeState(new PausedState(Context, this));

            Context.Background1.ChangeYPosition(-Game1.BACKGROUND_STEP);
            Context.Background2.ChangeYPosition(-Game1.BACKGROUND_STEP);

            // give everythign their own little object that handles all the spawning for me
            Rockspawner.Spawn(gameTime.ElapsedGameTime.TotalMilliseconds);
            snowmanspawner.Spawn(gameTime.ElapsedGameTime.TotalMilliseconds);
            Treespawner.Spawn(gameTime.ElapsedGameTime.TotalMilliseconds);

            // and let another object handle how they slip across the screen. I didn't actually implement despawning if they got off the screen but I am, in one word, extremely lazy. I don't think its physically possible to keep playing before this would cause a crash anyway.
            Rockscroller.Scroll(-Game1.OBSTACLE_STEP, true, false);
            Treescroller.Scroll(-Game1.OBSTACLE_STEP, true, false);
            Snowmanscroller.Scroll(-Game1.OBSTACLE_STEP);

            //begone thot
            Context.Player.RemoveAll(x => x.IsHit == true);
            Context.Snowman.RemoveAll(x => x.IsHit == true);

             // game over condition
            if(Context.Player.Count <= 0 && Context.Player2.IsHit)
            {
                Context.ChangeState(new GameOverState(Context));
            }
        }

        public override void Draw(GameTime gameTime)
        {
            // did you know i had to ask a friend to tell me that the background should be drawn first because its been like 7 weeks since we saw that in class. did you also know that the background gave me the single most trouble out of anything in this program, besides, uh, deleting my game1 constructor and somehow having my entire project be a WPF anyway.
            Context.Background1.Draw(Context._spriteBatch);
            Context.Background2.Draw(Context._spriteBatch);
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
            if (!Context.Player2.IsHit)
            {
                Context.Player2.Draw(Context._spriteBatch);
            }
         

        }
    }
}
