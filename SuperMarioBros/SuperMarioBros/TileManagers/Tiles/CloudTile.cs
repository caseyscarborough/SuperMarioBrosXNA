using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMarioBros.TileManagers.Tiles
{
    class CloudTile : Tile
    {
        // The Cloud on the SpriteSheet starts at 621, 37 and is 64px wide and 53px tall.
        public CloudTile(Vector2 position) : base(position, 65, 53, new Vector2(621, 37)) { }
    }
}
