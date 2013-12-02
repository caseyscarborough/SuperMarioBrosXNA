using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;

namespace SuperMarioBros.LevelManagers
{
    public abstract class Level
    {
        protected static ArrayList _map;
        protected static String contentPath;

        public static ArrayList Map()
        {
            if (_map == null)
            {
                _map = new ArrayList();
                using (StreamReader reader = new StreamReader(contentPath))
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
