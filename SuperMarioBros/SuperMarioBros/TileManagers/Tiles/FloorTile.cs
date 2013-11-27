using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros.TileManagers.Tiles
{
    class FloorTile : Tile
    {
        // Our Floor tile is 33 pixels wide, so we pass the value given to our constructor
        // to the superclass * 33, so that way we don't have to do any math when calculating
        // where the tiles go. They are just 1, 2, 3, etc.
        public FloorTile(Vector2 position)
            // The following Vector2 is the position of the tile on the sprite sheet.
            : base(position * 32, 32, 33, new Vector2(244, 137))
        {

        }
    }
}
