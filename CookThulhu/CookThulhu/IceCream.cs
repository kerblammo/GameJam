using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// IceCream is an object representing an ice cream that the player may serve to a patron
/// </summary>
namespace CookThulhu
{
    class IceCream
    {
        public int ItemID { get; set; }
        public int ScoopsHazel { get; set; }
        public int ScoopsMint { get; set; }
        public int ScoopsStrawberry { get; set; }

        /// <summary>
        /// Construct an empty ice cream cone
        /// </summary>
        public IceCream()
        {
            ItemID = (int)MyEnums.ItemIDs.IceCream;
            ScoopsHazel = 0;
            ScoopsMint = 0;
            ScoopsStrawberry = 0;
        }

        /// <summary>
        /// Construct an ice cream cone with defined number of scoops
        /// </summary>
        /// <param name="hazel">Number of hazel scoops</param>
        /// <param name="mint">Number of mint scoops</param>
        /// <param name="strawberry">Number of strawberry scoops</param>
        public IceCream(int hazel, int mint, int strawberry)
        {
            ItemID = (int)MyEnums.ItemIDs.IceCream;
            ScoopsHazel = hazel;
            ScoopsMint = mint;
            ScoopsStrawberry = strawberry;
        }
    }
}
