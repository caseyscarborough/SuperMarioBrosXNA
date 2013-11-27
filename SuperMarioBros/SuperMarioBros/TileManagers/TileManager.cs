using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.LevelManagers
{
    class TileManager
    {
        ArrayList _tiles;

        public TileManager()
        {
            _tiles = new ArrayList();
        }

        public void AddTile(Tile tile)
        {
            _tiles.Add(tile);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in _tiles) {
                tile.Draw(spriteBatch);
            }
        }
    }
}
