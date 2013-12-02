using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        private Dictionary<String, Texture2D> _textures = new Dictionary<String, Texture2D>();
        private Dictionary<String, SoundEffect> _sounds = new Dictionary<String, SoundEffect>();
        private Dictionary<String, Song> _songs = new Dictionary<String, Song>();
        private static GameContentManager _instance;

        // Lazily instantiate the GameContentManager class when the instance is called the first time.
        public static GameContentManager GetInstance() {
            if (_instance == null)
                _instance = new GameContentManager();

            return _instance;
        }

        private GameContentManager() { }
        
        // Used to retrieve a texture from the _textures Dictionary.
        public Texture2D GetTexture(String name)
        {
            return _textures[name];
        }

        // Used to retrieve a sound effect from the _sounds Dictionary.
        public SoundEffect GetSound(String name)
        {
            return _sounds[name];
        }

        // Used to retrieve a sound effect from the _sounds Dictionary.
        public Song GetSong(String name)
        {
            return _songs[name];
        }

        // 
        public void Initialize(ContentManager c) {
            try
            {
                _textures["sprite_sheet"] = c.Load<Texture2D>("Sprites/supermariobros");
                _textures["main_menu_logo"] = c.Load<Texture2D>("Sprites/main_menu_logo");
                _songs["main_theme"] = c.Load<Song>("Sounds/main_theme");
                _sounds["jump"] = c.Load<SoundEffect>("Sounds/jump");
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
