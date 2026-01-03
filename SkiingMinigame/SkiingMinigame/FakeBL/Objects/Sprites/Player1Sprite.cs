using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkiingMinigame.FakeBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigame.FakeBL.Objects.Sprites
{
    public class Player1Sprite : Sprite
    {
        public Player1Sprite(Texture2D texture, Vector2 position) : base(texture, position)
        {
            IsHit = false;
        }

        public void Update(GameTime gameTime, int speed, IPlayerInputMovementService inputService)
        {
            if (inputService.Player1ShouldGoRight())
                ChangeXPosition(speed);

            if (inputService.Player1ShouldGoLeft())
                ChangeXPosition(-speed);

            if (inputService.Player1ShouldGoUp())
                ChangeYPosition(-speed);

            if (inputService.Player1ShouldGoDown())
                ChangeYPosition(speed);
        }
    }
}
