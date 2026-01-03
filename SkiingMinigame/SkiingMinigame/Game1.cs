using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_Pikachu.Services;
using SkiingMinigame.Facades;
using SkiingMinigame.FakeBL.Objects.Sprites;
using SkiingMinigame.States;
using SkiingMinigameBL.Objects.Sprites;
using System.Collections.Generic;

namespace SkiingMinigame
{
    public class Game1 : Game
    {
        internal GraphicsDeviceManager _graphics;
        internal SpriteBatch _spriteBatch;

        internal const int PLAYER_STEP = 8;
        internal const int BACKGROUND_STEP = 8;
        internal const int OBSTACLE_STEP = 4;

        internal SpriteFont _font;

        internal int _numberOfRemainLives;

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

            // TODO: use this.Content to load your game content here
            _font = Content.Load<SpriteFont>("game-font");
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
