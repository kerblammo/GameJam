using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Player is the object which represents the player in game
/// </summary>
namespace CookThulhu
{
    class Player
    {
        public Meal HeldMeal { get; set; }
        public int HeldItem { get; set; }
        public int Score { get; set; }

        /// <summary>
        /// Create an instance of Player with initial values
        /// </summary>
        public Player()
        {
            HeldItem = (int)MyEnums.ItemIDs.Empty;
            Score = 0;
        }
    }
}
