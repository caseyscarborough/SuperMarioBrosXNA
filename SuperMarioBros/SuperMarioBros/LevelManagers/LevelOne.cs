using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;

namespace SuperMarioBros.LevelManagers
{
    class LevelOne : Level
    {
        // Not sure of a better way to do this, tried a static initializer, but
        // did not work as expected. Will look at this again later.
        new public static ArrayList Map() {
            contentPath = "Content/Levels/level_one.csv";
            return Level.Map();
        }
    }
}
