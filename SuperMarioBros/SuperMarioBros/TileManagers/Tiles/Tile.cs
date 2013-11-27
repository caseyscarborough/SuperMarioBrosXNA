using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.ScreenManagers;
using SuperMarioBros.LevelManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros.TileManagers.Tiles
{
    public abstract class Tile : DrawableGameComponent
    {
        protected int width;
        protected int height;
        protected Vector2 origin;
        protected Rectangle rect;
        protected Vector2 position;

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

        public Tile(Vector2 position, int width, int height, Vector2 origin) : base(LevelManager.Game)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.origin = origin;
            LoadContent();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            rect = new Rectangle((int)origin.X, (int)origin.Y, width, height);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(GameContentManager.GetInstance().GetTexture("sprite_sheet"), position, rect, Color.White);
            spriteBatch.End();
        }
    }
}
