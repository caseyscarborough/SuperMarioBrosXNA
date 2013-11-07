using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.LevelManagers
{   
    public class LevelManager
    {
        SpriteBatch spriteBatch;
        Game game;

        /// <summary>
        /// Reference to the game instance.
        /// </summary>
        public Game Game
        {
            get { return game; }
        }

        /// <summary>
        /// Provide an easy way to access the spriteBatch, so that all
        /// levels do not have to create a new spriteBatch.
        /// </summary>
        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }

        public LevelManager(Game game)
        {
            this.game = game;
        }
    }
}
