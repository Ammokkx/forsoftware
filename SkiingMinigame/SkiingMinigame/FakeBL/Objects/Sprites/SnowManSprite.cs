using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.FakeBL.Objects.Sprites
{
    public class SnowManSprite : ObstacleSprite
    {
        public SnowManSprite(Texture2D texture, Vector2 position) : base(texture, position)
        {
            HitLeftSideOfScreen = false;
            IsHit = false;
        }
        public bool HitLeftSideOfScreen { get; set; }
    }
}