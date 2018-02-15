using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Cake is an object that represents a cake the player may serve to a customer
/// </summary>
namespace CookThulhu
{
    class Cake
    {
        public int ItemID { get; set; }
        public bool Sigil { get; set; }
        public bool Skulls { get; set; }
        public bool Cherries { get; set; }

        /// <summary>
        /// Construct a cake with initial values
        /// </summary>
        public Cake()
        {
            ItemID = (int)MyEnums.ItemIDs.Cake;
            Sigil = false;
            Skulls = false;
            Cherries = false;
        }

        /// <summary>
        /// Construct a cake with specific values
        /// </summary>
        /// <param name="sigil">If the cake has a sigil</param>
        /// <param name="skulls">If the cake has skulls</param>
        /// <param name="cherries">If the cake has cherries</param>
        public Cake(bool sigil, bool skulls, bool cherries)
        {
            ItemID = (int)MyEnums.ItemIDs.Cake;
            Sigil = sigil;
            Skulls = skulls;
            Cherries = cherries;
        }

        
    }
}
