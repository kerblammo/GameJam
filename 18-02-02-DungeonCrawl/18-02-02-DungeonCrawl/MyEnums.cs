using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The MyEnums class is a collection of enumerators to be used in this project
/// </summary>

namespace _18_02_02_DungeonCrawl
{
    class MyEnums
    {
        public enum TileCollisions
        {
            //Determines what behaviours/image a tile has
            Empty = 0,
            Wall = 1,
            Obstacle = 2,
            Pit = 3,
            StairsUp = 4,
            StairsDown = 5
        }

        
    }
}
