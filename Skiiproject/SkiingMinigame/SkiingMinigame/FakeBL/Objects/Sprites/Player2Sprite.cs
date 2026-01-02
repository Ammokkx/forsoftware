using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkiingMinigameBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigameBL.Objects.Sprites
{
    public class Player2Sprite : Sprite
    {
        public Player2Sprite(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public void Update(GameTime gameTime, int speed, IPlayerInputMovementService inputService)
        {
            if (inputService.Player2ShouldGoRight())
                ChangeXPosition(speed);

            if (inputService.Player2ShouldGoLeft())
                ChangeXPosition(-speed);

            if (inputService.Player2ShouldGoUp())
                ChangeYPosition(-speed);

            if (inputService.Player2ShouldGoDown())
                ChangeYPosition(speed);
        }
    }
}