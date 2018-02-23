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
            Mixer1 = 142,
            Mixer2 = 142,
            Oven1 = 268,
            Oven2 = 339,
            Oven3 = 342,
            Oven4 = 408,
            Patron1 = 134,
            Patron2 = 291,
            Patron3 = 459,
            Patron4 = 609,
            StationCakes = 142,
            StationChopping = 464,
            StationIceCream = 602,
            Trash = 602

        }

        /// <summary>
        /// PlayerYPos is a collection of possible positions a player can move to
        /// Each entry corresponds to the Y value of a player's potential location
        /// </summary>
        public enum PlayerYPos
        {
            Mixer1 = 128,
            Mixer2 = 173,
            Oven1 = 334,
            Oven2 = 334,
            Oven3 = 398,
            Oven4 = 398,
            Patron1 = 153,
            Patron2 = 153,
            Patron3 = 153,
            Patron4 = 153,
            StationCakes = 310,
            StationChopping = 334,
            StationIceCream = 248,
            Trash = 346
        }

        /// <summary>
        /// Station is a collection of stations that the player may have open
        /// </summary>
        public enum Station
        {
            None, 
            Cake,
            IceCream,
            Fingers
            
        }

    }
}
