using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// MyEnums is a collection of enumerators to be used on the project
/// </summary>
namespace CookThulhu
{
    class MyEnums
    {
        /// <summary>
        /// CookerState is a collection of states that a cooker object may be in
        /// </summary>
        public enum CookerState
        {
            Empty,
            Working,
            Done
        }

        /// <summary>
        /// ItemIDs is a collection of items that the player may interact with
        /// </summary>
        public enum ItemIDs
        {
            Empty,
            RawCake,
            CookedCake,
            Cake,
            RawFingers,
            Fingers,
            IceCream

        }

        /// <summary>
        /// PlayerXPos is a collection of possible positions a player can move to
        /// Each entry corresponds to the X value of a player's potential location
        /// </summary>
        public enum PlayerXPos
        {
            Mixer1 = 138,
            Mixer2 = 138,
            Oven1 = 212,
            Oven2 = 277,
            Oven3 = 342,
            Oven4 = 408,
            Patron1 = 160,
            Patron2 = 256,
            Patron3 = 352,
            Patron4 = 448,
            StationCakes = 142,
            StationChopping = 562,
            StationIceCream = 586,
            Trash = 586

        }

        /// <summary>
        /// PlayerYPos is a collection of possible positions a player can move to
        /// Each entry corresponds to the Y value of a player's potential location
        /// </summary>
        public enum PlayerYPos
        {
            Mixer1 = 156,
            Mixer2 = 232,
            Oven1 = 398,
            Oven2 = 398,
            Oven3 = 398,
            Oven4 = 398,
            Patron1 = 128,
            Patron2 = 128,
            Patron3 = 128,
            Patron4 = 128,
            StationCakes = 381,
            StationChopping = 400,
            StationIceCream = 219,
            Trash = 381
        }

    }
}
