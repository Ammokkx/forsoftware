using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace SkiingMinigame.Facades
{
    // added being able to load sprite fonts because duh
    public static class ContentFacade
    {
        public static IEnumerable<Texture2D> LoadTexture2D(Game game, string[] names)
            => names?.Select(name => LoadTexture2D(game, name));

        public static Texture2D LoadTexture2D(Game game, string name)
         => game.Content.Load<Texture2D>(name);

        public static IEnumerable<SpriteFont> LoadSpriteFont(Game game, string[] names)
           => names?.Select(name => LoadSpriteFont(game, name));

        public static SpriteFont LoadSpriteFont(Game game, string name) => game.Content.Load<SpriteFont>(name);
    }
}
