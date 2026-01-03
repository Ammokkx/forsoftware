using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SkiingMinigame.Facades;
using SkiingMinigame.FakeBL.Objects.Sprites;
using SkiingMinigame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.States
{
    public class StartScreenState(Game1 context)
        : State(context)
    {
        
                    private bool _isInitialized = false;
        public override void Update(GameTime gameTime)
        {
            // Making sure we only reset the variables onces. Remember, this method will - ideally - run every 16.6ms
            if (!_isInitialized)
            {
                ResetContext();

                _isInitialized = true;
            }

            // TODO : Add the other 4 states
            if (InputFacade.IsKeyDown(Keys.D3))
            {
                const int NumberOfPlayers = 3;
                int Xposition = 0;
                for (int i = 0; i < NumberOfPlayers; i++)
                {
                    Context.Player.Add(new Player1Sprite(ContentService.Instance.GetTexture(ContentService.Player), new Vector2(Xposition, 0)));
                    Xposition += 100;
                }
                Context.ChangeState(new PlayingStateEnemies(Context));
               
            }
            if (InputFacade.IsKeyDown(Keys.D1))
            {
                // i actually did 3 players first, that's why all the other options are below it. i think its funny to keep it that way.
                const int NumberOfPlayers = 3;
                int Xposition = 0;
                for (int i = 0; i < NumberOfPlayers; i++)
                {
                    Context.Player.Add(new Player1Sprite(ContentService.Instance.GetTexture(ContentService.Player), new Vector2(Xposition, 0)));
                    Xposition += 100;
                }
                Context.ChangeState(new PlayingStateNoEnemies(Context));
            }
            if (InputFacade.IsKeyDown(Keys.D2))
            {
                    Context.Player.Add(new Player1Sprite(ContentService.Instance.GetTexture(ContentService.Player), new Vector2(0, 0)));
                Context.ChangeState(new PlayingStateEnemies(Context));
            }
            if (InputFacade.IsKeyDown(Keys.D4))
            {
                Context.Player.Add(new Player1Sprite(ContentService.Instance.GetTexture(ContentService.Player), new Vector2(0, 0)));
                Context.Player2.IsHit = false;
                Context.ChangeState(new PlayingStateEnemies(Context));
            }


        }

        private void ResetContext()
        {
            Context.Player = new List<Player1Sprite>();
            Context.Player2 = new Player2Sprite(ContentService.Instance.GetTexture(ContentService.Player), new Vector2(500, 0));
            Context.Player2.IsHit = true;

            Context.Background1 = new BackgroundSprite(ContentService.Instance.GetTexture(ContentService.Background), new Vector2(0, 0));
            Context.Background2 = new BackgroundSprite(ContentService.Instance.GetTexture(ContentService.Background), new Vector2(0, 1528));

            Context.Rock = new List<ObstacleSprite>();
            Context.Snowman = new List<ObstacleSprite>();
            Context.Treebottom = new List<ObstacleSprite>();


            //Context.Player = new PlayerSprite(ContentService.Instance.GetTexture(ContentService.Player),
            //                                  new Vector2(0, 100));

            //Context._backgroundPosition = new Vector2(0, -700);
            //Context._numberOfRemainLives = 3;
            //Context._sharkPositions = new List<Vector2>();
        }
        public override void Draw(GameTime gameTime)
        {
            Context.Background1.Draw(Context._spriteBatch);
            Context.Background2.Draw(Context._spriteBatch);

            Context._spriteBatch.DrawString(ContentService.Instance.GetSpriteFont(ContentService.GameFont), "Druk 1: 3 Skiieers", new Vector2(50, 200), Color.Black);
            Context._spriteBatch.DrawString(ContentService.Instance.GetSpriteFont(ContentService.GameFont), "Druk 2: Vijanden / 1 skieer", new Vector2(50, 300), Color.Black);
            Context._spriteBatch.DrawString(ContentService.Instance.GetSpriteFont(ContentService.GameFont), "Druk 3: Vijanden / 3 skieer", new Vector2(50, 400), Color.Black);
            Context._spriteBatch.DrawString(ContentService.Instance.GetSpriteFont(ContentService.GameFont), "Druk 4: Vijanden / 2 spelers", new Vector2(50, 500), Color.Black);

        }

        
    }
}
