using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookThulhu
{
    /// <summary>
    /// Oven is an object that the player may interact with.
    /// </summary>
    class Oven
    {
        public int State { get; set; }      //determines which actions can be performed by player
        public int Progress { get; set; }   //determines how complete action is
        public int ProgressStep { get; set; }   //determines how quickly progress is achieved
        public int ProgressThreshold { get; set; }  //maximum amount of progress
        public List<int> ProducedItems { get; set; }    //list of items that may be produced
        public List<int> AcceptedItems { get; set; }    //list of items that can be cooked
        public int CurrentItem { get; set; }    //item currently inside oven

        /// <summary>
        /// Create an instance of Oven with default initial values
        /// </summary>
        public Oven()
        {
            //Create an empty oven with 0 progress (since it's empty)
            State = (int)MyEnums.CookerState.Empty;
            CurrentItem = (int)MyEnums.ItemIDs.Empty;
            Progress = 0;

            //determine speed that item will cook
            ProgressStep = 10;
            ProgressThreshold = 100;

            //determine items that may be accepted by this cooker
            AcceptedItems = new List<int>();
            AcceptedItems.Add((int)MyEnums.ItemIDs.RawCake);
            AcceptedItems.Add((int)MyEnums.ItemIDs.RawFingers);

            //determine items that may be produced by this cooker
            ProducedItems = new List<int>();
            ProducedItems.Add((int)MyEnums.ItemIDs.CookedCake);
            ProducedItems.Add((int)MyEnums.ItemIDs.Fingers);
            
            
        }


    }
}
