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
                //Note on TileMaps:
                //North Door is index [5]
                //West Door is index [55]
                //East Door is index [65]
                //South Door is index [116]
                case 0:    //empty room
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
                case 1:    //exit room
                    tilemap = "WWWWWWWWWWW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WEEEESEEEEW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WWWWWWWWWWW";
                    break;
                case 2:     //corner holes and middle obstacle
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
                case 3:     //corners block, open layout
                    tilemap =   "WWWWWWWWWWW" +
                                "WOOOEEEOOOW" +
                                "WOOEEEEEOOW" +
                                "WOEEEEEEEOW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WEEEEEEEEEW" +
                                "WOEEEEEEEOW" +
                                "WOOEEEEEOOW" +
                                "WOOOEEEOOOW" +
                                "WWWWWWWWWWW";
                    break;
                case 4:     //corners blocked, pit center
                    tilemap =   "WWWWWWWWWWW" +
                                "WOOOEEEOOOW" +
                                "WOOEEEEEOOW" +
                                "WOEEEPEEEOW" +
                                "WEEEPPPEEEW" +
                                "WEEPPPPPEEW" +
                                "WEEEPPPEEEW" +
                                "WOEEEPEEEOW" +
                                "WOOEEEEEOOW" +
                                "WOOOEEEOOOW" +
                                "WWWWWWWWWWW";
                    break;
                case 5:     //corners blocked, center blocked
                    tilemap =   "WWWWWWWWWWW" +
                                "WOOOEEEOOOW" +
                                "WOOOEEEOOOW" +
                                "WEEEEEEEEEW" +
                                "WEEEOOOEEEW" +
                                "WEEEOOOEEEW" +
                                "WEEEOOOEEEW" +
                                "WEEEEEEEEEW" +
                                "WOOOEEEOOOW" +
                                "WOOOEEEOOOW" +
                                "WWWWWWWWWWW";
                    break;
                case 6:     //bunker
                    tilemap =   "WWWWWWWWWWW" +
                                "WEEEEEEEEEW" +
                                "WEOOOOOOOEW" +
                                "WEOEEEEEOEW" +
                                "WEOEEEEEOEW" +
                                "WEEEEEEEEEW" +
                                "WEOEEEEEOEW" +
                                "WEOEEEEEOEW" +
                                "WEOOOOOOOEW" +
                                "WEEEEEEEEEW" +
                                "WWWWWWWWWWW";
                    break;
                case 7:     //bunker with pit
                    tilemap =   "WWWWWWWWWWW" +
                                "WEEEEEEEEEW" +
                                "WEOOOOOOOEW" +
                                "WEOEEEEEOEW" +
                                "WEOEPPPEOEW" +
                                "WEEEPPPEEEW" +
                                "WEOEPPPEOEW" +
                                "WEOEEEEEOEW" +
                                "WEOOOOOOOEW" +
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
