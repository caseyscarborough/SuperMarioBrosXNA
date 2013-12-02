using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.TileManagers.Tiles;
using SuperMarioBros.LevelManagers;

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

        public void BuildMap(Type type)
        {
            ArrayList map = (ArrayList) type.GetMethod("Map").Invoke(type, new object[]{});
            for (int i = 0; i < LevelOne.Map().Count; i++)
            {
                for (int j = 0; j < ((String[])LevelOne.Map()[i]).Length; j++)
                {
                    String value = ((String[])((ArrayList)LevelOne.Map())[i])[j];
                    HandleTile(value, i, j);
                }
            }
        }

        public void HandleTile(String value, int i, int j)
        {
            Tile tile = null;
            switch (value)
            {
                case "1":
                    tile = new FloorTile(new Vector2(j, i));
                    break;
                case "2":
                    tile = new LargeTreeTile(new Vector2(j * 33, i * 29));
                    break;
                case "3":
                    tile = new BrickTile(new Vector2(j, i));
                    break;
                case "4":
                    tile = new QuestionMarkTile(new Vector2(j, i));
                    break;
                case "5":
                    tile = new BushTile(new Vector2(j * 33, i * 32));
                    break;
                case "6":
                    tile = new CloudTile(new Vector2(j * 33, i * 33));
                    break;
            }

            if (tile != null) AddTile(tile);
        }
    }
}
