using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EastBayFrontier
{
    /// <summary>
    /// Author: Peter Adam
    /// Start Date: March 19, 2018
    /// This class keeps track of information regarding a faction's upgrades
    /// </summary>
    public class UpgradeData
    {
        #region Attributes
        public int Value { get; set; }
        public int Cost { get; set; }
        public int Level { get; set; }
        #endregion

        /// <summary>
        /// Create a new instance of the UpgradeData object with initial values
        /// </summary>
        public UpgradeData()
        {
            Level = 0;
        }
    }
}
