using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkiingMinigameBL.Objects.Sprites;
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

        internal override void ChangeYPosition(float yChange)
        {
            if (Position.Y > -1528) 
            {
                Position = Position with { Y = Position.Y + yChange };
            }
            else
            {
                Position = Position with { Y = 1528 };
            }
        }
    }
}
