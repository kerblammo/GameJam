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
        public IceCream HeldIceCream { get; set; }
        public Cake HeldCake { get; set; }
        public Fingers HeldFingers { get; set; }
        public int HeldItem { get; set; }
        public int Score { get; set; }
        public int Strikes { get; set; }
        public int MaxStrikes { get; set; }
        public int OpenStation { get; set; }

        /// <summary>
        /// Create an instance of Player with initial values
        /// </summary>
        public Player()
        {
            HeldItem = (int)MyEnums.ItemIDs.Empty;
            OpenStation = (int)MyEnums.Station.None;
            Score = 0;
            Strikes = 0;
            MaxStrikes = 3;
            
        }
    }
}
