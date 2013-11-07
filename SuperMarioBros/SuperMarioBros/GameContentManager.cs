using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros
{
    public class GameContentManager
    {
        public static Texture2D SpritesTexture;
        public static Texture2D MainMenuLogo;
        public static Texture2D Mario;
        public static Song MainTheme;

        public static void Initialize(Game game) {
            SpritesTexture = game.Content.Load<Texture2D>("Sprites/supermariobros");
            MainMenuLogo = game.Content.Load<Texture2D>("Sprites/main_menu_logo");
            MainTheme = game.Content.Load<Song>("Sounds/main_theme");
        }
    }
}
