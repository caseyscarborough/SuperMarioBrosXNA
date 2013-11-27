using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros.TileManagers.Tiles
{
    class QuestionMarkTile : Tile
    {
        Boolean flashOn = true;
        Rectangle flash;
        int gameTimeTracker = 0;
        public QuestionMarkTile(Vector2 position)
            // The following Vector2 is the position of the tile on the sprite sheet.
            : base(position * 32, 32, 33, new Vector2(201, 93))
        {

        }

        protected override void LoadContent()
        {
            base.LoadContent();
            flash = new Rectangle((int)origin.X + 39, (int)origin.Y, width, height);
        }

        public void Flash()
        {
            if (gameTimeTracker >= 30)
            {
                Rectangle temp = rect;
                rect = flash;
                flash = temp;
                flashOn = !flashOn;

                gameTimeTracker = 0;
            }
            gameTimeTracker++;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.Flash();
            spriteBatch.Begin();
            spriteBatch.Draw(GameContentManager.GetInstance().GetTexture("sprite_sheet"), position, rect, Color.White);
            spriteBatch.End();
        }
    }
}
