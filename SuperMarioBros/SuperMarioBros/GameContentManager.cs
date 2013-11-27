using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        private Dictionary<String, Texture2D> _textures;
        private static GameContentManager _instance;
        public Song MainTheme;

        // Lazily instantiate the GameContentManager class when the instance is called the first time.
        public static GameContentManager GetInstance() {
            if (_instance == null)
            {
                _instance = new GameContentManager();
            }

            return _instance;
        }
        
        // Used to retrieve a texture from the _textures Dict.
        public Texture2D GetTexture(String name)
        {
            return _textures[name];
        }

        // 
        public void Initialize(ContentManager c) {
            _textures["sprite_sheet"] = c.Load<Texture2D>("Sprites/supermariobros");
            _textures["main_menu_logo"] = c.Load<Texture2D>("Sprites/main_menu_logo");
            MainTheme = c.Load<Song>("Sounds/main_theme");
        }
    }
}
