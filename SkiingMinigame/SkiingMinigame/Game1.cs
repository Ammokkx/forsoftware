using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SkiingMinigame.Facades;
using SkiingMinigame.FakeBL.Objects.Sprites;
using SkiingMinigame.Services;
using SkiingMinigame.States;
using System.Collections.Generic;

namespace SkiingMinigame
{
    public class Game1 : Game
    {
        internal GraphicsDeviceManager _graphics;
        internal SpriteBatch _spriteBatch;

        internal const int PLAYER_STEP = 5;
        internal const int BACKGROUND_STEP = 4;
        internal const int OBSTACLE_STEP = 4;

        internal const int PlayGroundBoundsLeft = 0;
        internal const int PlayGroundBoundsRight = 585;
        internal const int PlayGroundBoundsUp = 0;
        internal const int PlayGroundBoundsDown = 785;
        internal const int BoopRightOrDown = 5;
        internal const int BoopLeftOrUp = -5;

        // can you guess why i called it this
        internal const int MagicNumberThatSomehowMakesTheBackgroundWorkProperlyPositive = 1528;
        internal const int MagicNumberThatSomehowMakesTheBackgroundWorkProperlyNegative = -1528;

        // player 1 is a list because that makes it easier to track multiple objects, while player 2 is only ever 1 guy in the game so i just made it its own object. they're also separate objects because of the separate control schemes, easier to do this way as i hella did not know how to make p1 and p2 have different buttons within the same object
        internal List<Player1Sprite> Player;
        internal Player2Sprite Player2;

        internal List<ObstacleSprite> Rock;
        internal List<ObstacleSprite> Snowman;
        internal List<ObstacleSprite> Treebottom;
        internal BackgroundSprite Background1;
        internal BackgroundSprite Background2;

        internal const double RockMinSpawnTimeMs = 500;
        internal const double RockMaxSpawnTimeMs = 2000;
        internal const double TreeMinSpawnTimeMs = 1500;
        internal const double TreeMaxSpawnTimeMs = 5000;
        internal const double SnowmanMinSpawnTimeMs = 3000;
        internal const double SnowmandMaxSpawnTimeMS = 10000;

        private State _currentState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        internal void ChangeState(State newState)
        {
            // Trust that the state that is setting the new state knows what it is doing, so no validation. They know more than the context (Game1.cs)
            _currentState = newState;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 600;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();

            ContentService.Initialize(this);
            ChangeState(new StartScreenState(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

           
        }

        protected override void Update(GameTime gameTime)
        {
            InputFacade.Update();

            if (InputFacade.WasKeyJustPressed(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _currentState?.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // There is only 1 draw method to call: the one for the active state and Game1 doesn't care what is behind it
            _currentState?.Draw(gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
