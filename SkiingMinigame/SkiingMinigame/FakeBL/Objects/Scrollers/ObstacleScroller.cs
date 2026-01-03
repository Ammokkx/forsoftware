using SkiingMinigame.FakeBL.Objects.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.FakeBL.Objects.Scrollers
{
    public class ObstacleScroller
    {
        public List<ObstacleSprite> obstacles;

        public ObstacleScroller(List<ObstacleSprite> obstacles)
        {
            this.obstacles = obstacles;
        }

        public void Scroll(int step, bool isVerticalscroll, bool isHorizontalscroll)
        {
            if (isVerticalscroll)
            {
                foreach (var sprite in obstacles)
                {
                    sprite.ChangeYPosition(step);
                }
            }
            if (isHorizontalscroll)
            {
                foreach (var sprite in obstacles)
                {
                    sprite.ChangeXPosition(step);
                }
            }
            if (isVerticalscroll && isHorizontalscroll) 
            {
                foreach (var sprite in obstacles)
                {
                    sprite.ChangeYPosition(step);
                    sprite.ChangeXPosition(step);
                }
            }
        }
    }
}
