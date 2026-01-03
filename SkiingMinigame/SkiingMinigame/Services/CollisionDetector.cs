using SkiingMinigame.FakeBL.Objects.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.Services
{
    public class CollisionDetector(Game1 context)
    {
        protected Game1 Context = context;

        public void CheckCollisionWithWall(Player1Sprite playersprite)
        {
            if (playersprite.Position.X < Game1.PlayGroundBoundsLeft)
            {
                playersprite.ChangeXPosition(Game1.BoopRightOrDown);
            }
            if (playersprite.Position.Y < Game1.PlayGroundBoundsUp)
            {
                playersprite.ChangeYPosition(Game1.BoopRightOrDown);
            }
            if (playersprite.Position.X > Game1.PlayGroundBoundsRight)
            {
                playersprite.ChangeXPosition(Game1.BoopLeftOrUp);
            }
            if (playersprite.Position.Y > Game1.PlayGroundBoundsDown)
            {
                playersprite.ChangeYPosition(Game1.BoopLeftOrUp);
            }
        }
        public void CheckCollisionWithWall(Player2Sprite playersprite)
        {
            if (playersprite.Position.X < Game1.PlayGroundBoundsLeft)
            {
                playersprite.ChangeXPosition(Game1.BoopRightOrDown);
            }
            if (playersprite.Position.Y < Game1.PlayGroundBoundsUp)
            {
                playersprite.ChangeYPosition(Game1.BoopRightOrDown);
            }
            if (playersprite.Position.X > Game1.PlayGroundBoundsRight)
            {
                playersprite.ChangeXPosition(Game1.BoopLeftOrUp);
            }
            if (playersprite.Position.Y > Game1.PlayGroundBoundsDown)
            {
                playersprite.ChangeYPosition(Game1.BoopLeftOrUp);
            }
        }
        public void CheckCollisionWithObjects(Player1Sprite playersprite)
        {
            var playerBounds = playersprite.GetBounds();
            foreach (ObstacleSprite rocks in Context.Rock)
            {
                if (playerBounds.Intersects(rocks.GetBounds()))
                {
                    playersprite.ChangeYPosition(-10);
                }
            }
            foreach (ObstacleSprite snowmen in Context.Snowman)
            {
                if (playerBounds.Intersects(snowmen.GetBounds()))
                {
                    playersprite.IsHit = true;
                    snowmen.IsHit = true;
                }
            }
            foreach (ObstacleSprite tree in Context.Treebottom)
            {
                if (playerBounds.Intersects(tree.GetBounds()))
                {
                    playersprite.IsHit = true;
                }
            }
        }

        public void CheckCollisionWithObjects(Player2Sprite playersprite)
        {
            var playerBounds = playersprite.GetBounds();
            foreach (ObstacleSprite rocks in Context.Rock)
            {
                if (playerBounds.Intersects(rocks.GetBounds()))
                {
                    playersprite.ChangeYPosition(-10);
                }
            }
            foreach (ObstacleSprite snowmen in Context.Snowman)
            {
                if (playerBounds.Intersects(snowmen.GetBounds()))
                {
                    playersprite.IsHit = true;
                    snowmen.IsHit = true;
                }
            }
            foreach (ObstacleSprite tree in Context.Treebottom)
            {
                if (playerBounds.Intersects(tree.GetBounds()))
                {
                    playersprite.IsHit = true;
                }
            }
        }

    }
}
