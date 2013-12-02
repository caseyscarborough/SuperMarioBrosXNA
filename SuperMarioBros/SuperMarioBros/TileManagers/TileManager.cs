using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.TileManagers.Tiles;

namespace SuperMarioBros.TileManagers
{
    class TileManager
    {
        ArrayList _tiles;
        private static TileManager _instance;

        private TileManager()
        {
            _tiles = new ArrayList();
        }

        public static TileManager GetInstance()
        {
            if (_instance == null)
                _instance = new TileManager();
            return _instance;
        }

        public void AddTile(Tile tile)
        {
            _tiles.Add(tile);
        }

        public void RemoveTile(Tile tile)
        {
            _tiles.Remove(tile);
        }

        public void RemoveAllTiles()
        {
            foreach (Tile tile in _tiles)
            {
                _tiles.Remove(tile);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in _tiles) {
                tile.Draw(spriteBatch);
            }
        }
    }
}
