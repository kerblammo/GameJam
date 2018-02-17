using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Fingers represents the process for preparing the Lady Finger's dish
/// </summary>
namespace CookThulhu
{
    class Fingers
    {
        public bool HeldKnife { get; set; }
        public bool ChoppedKnife { get; set; }
        public bool DroppedKnife { get; set; }

        /// <summary>
        /// Create a new instance of Fingers with default values
        /// </summary>
        public Fingers()
        {
            HeldKnife = false;
            ChoppedKnife = false;
            DroppedKnife = false;
        }

    }
}
