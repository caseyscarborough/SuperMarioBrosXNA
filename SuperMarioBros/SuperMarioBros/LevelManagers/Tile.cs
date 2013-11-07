using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.ScreenManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros.LevelManagers
{
    public abstract class Tile : DrawableGameComponent
    {
        int width;
        int height;
        Vector2 origin;
        Rectangle rect;

        // Accessor method for getting the width of the tile.
        public int Width
        {
            get { return width; }
        }

        // Accessor method for getting the height of the tile.
        public int Height
        {
            get { return height; }
        }

        public Tile(int width, int height, Vector2 origin) : base(LevelManager.Game)
        {
            this.width = width;
            this.height = height;
            this.origin = origin;
            LoadContent();
        }

        public void LoadContent()
        {
            rect = new Rectangle((int)origin.X, (int)origin.Y, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(GameContentManager.SpritesTexture, rect, Color.White);
            spriteBatch.End();
        }
    }
}
