using SkiingMinigame.FakeBL.Objects.Sprites;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.FakeBL.Objects.Scrollers
{
    public class SnowmanScroller
    {


        public List<ObstacleSprite> obstacles;

        public SnowmanScroller(List<ObstacleSprite> obstacles)
        {
            this.obstacles = obstacles;
        }

        public void Scroll(int step)
        {
                foreach (SnowManSprite sprite in obstacles)
                {

                if (!sprite.HitLeftSideOfScreen)
                {
                    sprite.ChangeXPosition(step);
                }
                else
                {
                    sprite.ChangeXPosition(-step);
                }

                if (sprite.Position.X < Game1.PlayGroundBoundsLeft)
                {
                    sprite.HitLeftSideOfScreen = true;
                }

              if (sprite.Position.X > Game1.PlayGroundBoundsRight)
                {
                    sprite.HitLeftSideOfScreen = false;
                }  
            
            
            
            }
                


        }
    }
}