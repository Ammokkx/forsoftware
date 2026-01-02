using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SkiingMinigame.Facades;
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
        internal const int BACKGROUND_STEP = 2;
        internal const int OBSTACLE_STEP = 4;

        internal SpriteFont _font;

        internal int _numberOfRemainLives;

        internal Player1Sprite Player;
        internal Player2Sprite Player2;

        internal Texture2D _background;
        internal Vector2 _backgroundPosition;

        internal double _elapsedTimeSinceLastRockInMs;
        internal double _elapsedTimeSinceLastSnowmanInMs;
        internal double _elapsedTimeSinceLastTreeBottomInMs;

        internal double _rockSpawnTimer;
        internal double _snowmanSpawnTimer;
        internal double _treeBottomSpawnTimer;


        internal Texture2D _skiier;
        internal Texture2D _rock;
        internal Texture2D _snowman;
        internal Texture2D _treebottom;
        internal List<Vector2> _sharkPositions;

        private State _currentState;

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

            ChangeState(new StartScreenState(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _background = Content.Load<Texture2D>("background");
            _rock = Content.Load<Texture2D>("rock");
            _treebottom = Content.Load<Texture2D>("tree-bottom");
            _snowman = Content.Load<Texture2D>("snowman");
            _skiier = Content.Load<Texture2D>("skiier");
            _font = Content.Load<SpriteFont>("game-font");
        }

        protected override void Update(GameTime gameTime)
        {
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
