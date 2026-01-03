using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiingMinigameBL.Extensions
{
    public static class SpriteBatchExtensions
    {
        // not sure if i'm gonna use any of this right now but i'm not getting rid of it because it COULD be useful

        public static void Draw(this SpriteBatch spriteBatch, Texture2D texture, Vector2 position)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public static void DrawStringInTopLeft(this SpriteBatch spriteBatch, GraphicsDeviceManager graphics, SpriteFont spriteFont, string text)
        {
            DrawStringInTopLeft(spriteBatch, graphics, spriteFont, text, Color.Black);
        }

        public static void DrawStringInTopLeft(this SpriteBatch spriteBatch, GraphicsDeviceManager graphics, SpriteFont spriteFont, string text, Color textColor)
        {
            spriteBatch.DrawString(spriteFont, text, Vector2.Zero, textColor);
        }

        public static void DrawStringInCenter(this SpriteBatch spriteBatch, GraphicsDeviceManager graphics, SpriteFont spriteFont, string text)
        {
            DrawStringInCenter(spriteBatch, graphics, spriteFont, text, Color.Black);
        }

        public static void DrawStringInCenter(this SpriteBatch spriteBatch, GraphicsDeviceManager graphics, SpriteFont spriteFont, string text, Color textColor)
        {
            var position = CalculateCenterPosition(graphics, spriteFont, text);

            spriteBatch.DrawString(spriteFont, text, position, textColor);
        }

        private static Vector2 CalculateCenterPosition(GraphicsDeviceManager graphics, SpriteFont spriteFont, string text)
        {
            var textSize = spriteFont.MeasureString(text);
            return new Vector2((graphics.PreferredBackBufferWidth - textSize.X) * 0.5F,
                               (graphics.PreferredBackBufferHeight - textSize.Y) * 0.5F);
        }
        }
    }

