using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// The Tilemaps class contains a collection of strings which define the contents of a room
/// </summary>
namespace _18_02_02_DungeonCrawl
{
    static class Tilemaps
    {
        public static string PopulateIDs(int index)
        {
            //send in an integer, and return its matching string
            string tilemap;
            switch (index)
            {
                case 0:     //corner holes and middle obstacle
                    tilemap =   "WWWWWWWWWWW" +
                                "WEEEEEEEEEW" +
                                "WEPPEEEPPEW" +
                                "WEPPEEEPPEW" +
                                "WEEEEOEEEEW" +
                                "WEEEOOOEEEW" +
                                "WEEEEOEEEEW" +
                                "WEPPEEEPPEW" +
                                "WEPPEEEPPEW" +
                                "WEEEEEEEEEW" +
                                "WWWWWWWWWWW";
                    break;
                default:    //empty room
                    tilemap =   "WWWWWWWWWWW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WWWWWWWWWWW";
                    break;
            }
            return tilemap;
        }
    }
}
