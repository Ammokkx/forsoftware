using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.FakeBL.Objects.Sprites
{
    public class BackgroundSprite : Sprite
    {
        public BackgroundSprite(Texture2D texture, Vector2 position) : base(texture, position)
        {

        }


        //i know this isn't meant to be here okay but out of all the things to struggle the most on i didn't expect it to be making the background loop
        internal override void ChangeYPosition(float yChange)
        {
            if (Position.Y > Game1.MagicNumberThatSomehowMakesTheBackgroundWorkProperlyNegative) 
            {
                Position = Position with { Y = Position.Y + yChange };
            }
            else
            {
                Position = Position with { Y = Game1.MagicNumberThatSomehowMakesTheBackgroundWorkProperlyPositive };
            }
        }
    }
}
