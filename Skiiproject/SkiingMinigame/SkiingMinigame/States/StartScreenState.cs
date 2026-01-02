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
                Context.ChangeState(new PlayingState3Skiiers(Context));
        }

        private void ResetContext()
        {
          

            //Context.Player = new PlayerSprite(ContentService.Instance.GetTexture(ContentService.Player),
            //                                  new Vector2(0, 100));

            //Context._backgroundPosition = new Vector2(0, -700);
            //Context._numberOfRemainLives = 3;
            //Context._sharkPositions = new List<Vector2>();
        }
        public override void Draw(GameTime gameTime)
        {
            Context._spriteBatch.DrawStringInCenter(
           Context._graphics,
           Context._font,
           "Druk 1: 3 Skiieers\tDruk 2: Vijanden / 1 skieer\t Druk 3: Vijanden / 3 skieer\t Druk 4: Vijanden / 2 spelers");
        }

        
    }
}
