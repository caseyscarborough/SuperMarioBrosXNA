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
        public static Game Game;
        public ContentManager Content;

        protected void LoadContent()
        {
            Content = Game.Content;
        }
    }
}
