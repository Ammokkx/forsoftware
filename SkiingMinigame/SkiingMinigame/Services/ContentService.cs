using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkiingMinigame.Facades;
using System;
using System.Collections.Generic;

namespace SkiingMinigame.Services
{
    public class ContentService
    {
        private static ContentService _instance = null;

        /// <summary>
        /// Makes sure that the Con,tentService has access to the Content class via Game
        /// </summary>
        /// <param name="game"></param> - i don't know what this is and i'm too scared to touch it
        public static void Initialize(Game game)
        {
            _instance = new ContentService(game);
        }

      
        public static ContentService Instance
            => _instance ?? throw new Exception("Initialize was not called."); // Property met alleen een getter. Indien instance == null dan zal uitgevoerd worden wat na ?? komt, in dit geval een exception gethrowed - i ain't touching this explanation you know your stuff better than i do, clearly

        // every texture!
        public const string Player = "skiier";
        public const string Rock = "rock";
        public const string Snowman = "snowman";
        public const string TreeBottom = "tree-bottom";
        public const string GameFont = "game-font";
        public const string Background = "background";

        // two dictionaries for textures and spritefont
        private readonly Dictionary<string, Texture2D> _textures;
        private readonly Dictionary<string, SpriteFont> _spriteFont;

        // loafing them all in
        //that was meant to be loading, but coming back like a day later and seeing loafing instead is sending me into orbit
        private ContentService(Game game)
        {
            _textures = new Dictionary<string, Texture2D>();

            _spriteFont = new Dictionary<string, SpriteFont>();
            
            _textures.Add(Player, ContentFacade.LoadTexture2D(game, Player));
            _textures.Add(Rock, ContentFacade.LoadTexture2D(game, Rock));
            _textures.Add(Snowman, ContentFacade.LoadTexture2D(game, Snowman));
            _textures.Add(TreeBottom, ContentFacade.LoadTexture2D(game, TreeBottom));
            _textures.Add(Background, ContentFacade.LoadTexture2D(game, Background));
            _spriteFont.Add(GameFont, ContentFacade.LoadSpriteFont(game, GameFont));

        }

        public Texture2D GetTexture(string name)
        {
            return _textures[name];
        }

        public SpriteFont GetSpriteFont(string name) { return _spriteFont[name]; }
    }
}
