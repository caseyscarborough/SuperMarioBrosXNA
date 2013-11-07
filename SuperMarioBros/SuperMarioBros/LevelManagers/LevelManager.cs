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
        SpriteBatch spriteBatch;
        public static Game Game;
        public ContentManager Content;

        /// <summary>
        /// Provide an easy way to access the spriteBatch, so that all
        /// levels do not have to create a new spriteBatch.
        /// </summary>
        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }

        protected void LoadContent()
        {
            Content = Game.Content;
        }
    }
}
