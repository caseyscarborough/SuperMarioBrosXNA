using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;

namespace SuperMarioBros.LevelManagers
{
    class LevelOne : Level
    {
        public static ArrayList Map()
        {
            if (LevelOne._map == null) 
            {
                _map = new ArrayList();
                using (StreamReader reader = new StreamReader("Content/Levels/level_one.csv"))
                {
                    String line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        _map.Add(line.Split(','));
                    }
                }
            }
            return _map;
        }
    }
}
