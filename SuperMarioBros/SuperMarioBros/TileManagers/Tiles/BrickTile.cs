using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros.TileManagers.Tiles
{
    class BrickTile : Tile
    {
        public BrickTile(Vector2 position)
            // The following Vector2 is the position of the tile on the sprite sheet.
            : base(position * 32, 32, 33, new Vector2(120, 33))
        {

        }
    }
}
