using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookThulhu
{
    /// <summary>
    /// Mixer is an object that the player may interact with.
    /// </summary>
    class Mixer
    {
        public int State { get; set; }      //determines which actions can be performed by player
        public int Progress { get; set; }   //determines how complete action is
        public int ProgressStep { get; set; }   //determines how quickly progress is achieved
        public int ProgressThreshold { get; set; }  //maximum amount of progress
        public List<int> ProducedItems { get; set; }    //list of items that may be produced
        

        /// <summary>
        /// Create an instance of Oven with default initial values
        /// </summary>
        public Mixer()
        {
            //Create an empty mixer with 0 progress (since it's empty)
            State = (int)MyEnums.CookerState.Empty;
            Progress = 0;

            //determine speed that item will cook
            ProgressStep = 20;
            ProgressThreshold = 100;

            //determine items that may be produced by this cooker
            ProducedItems = new List<int>();
            ProducedItems.Add((int)MyEnums.ItemIDs.RawCake);


        }


    }
}
