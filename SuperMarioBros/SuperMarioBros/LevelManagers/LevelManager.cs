using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SuperMarioBros.LevelManagers
{   
    public class LevelManager
    {
        public Game Game;
        public ContentManager Content;
        private static LevelManager _instance;

        private LevelManager() { }

        public LevelManager GetInstance()
        {
            if (_instance == null)
                _instance = new LevelManager();
            return _instance;
        }

        protected void LoadContent()
        {
            Content = _instance.Game.Content;
        }
    }
}
