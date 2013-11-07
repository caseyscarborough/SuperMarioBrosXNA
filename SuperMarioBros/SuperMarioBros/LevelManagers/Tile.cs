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
    public abstract class Tile
    {
        String texturePath;
        Texture2D texture;
        int width;
        int height;
        Vector2 origin;
        Rectangle rect;
        ContentManager content;

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

        public LevelManager LevelManager
        {
            get { return levelManager; }
            internal set { levelManager = value;  }
        }

        LevelManager levelManager;

        public Tile(String texturePath, int width, int height, Vector2 origin)
        {
            this.texturePath = texturePath;
            this.width = width;
            this.height = height;
            this.origin = origin;
        }

        public void LoadContent()
        {
            if (content == null) // Lazily instantiate the content manager.
                content = new ContentManager(LevelManager.Game.Services, "Content");
            texture = content.Load<Texture2D>(texturePath);
            rect = new Rectangle((int)origin.X, (int)origin.Y, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {   
       
            spriteBatch.Begin();
            spriteBatch.Draw(texture, rect, Color.White);
            spriteBatch.End();
        }
    }
}
