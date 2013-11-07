using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros.LevelManagers
{
    class FloorTile : Tile
    {
        public FloorTile(Vector2 position)
            : base(position, 32, 33, new Vector2(244, 137))
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}
