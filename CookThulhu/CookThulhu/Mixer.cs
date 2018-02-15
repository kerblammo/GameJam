using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public PictureBox ProgressBar { get; set; } //the progress bar that corresponds to this mixer
        

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

        /// <summary>
        /// Called when user clicks on an oven. Checks what state the oven is in, and determines what to do from there
        /// </summary>
        public bool Interact(int playerItem)
        {
            //determines if player will receive an item
            bool receiveItem = false;
            switch (State)
            {
                case (int)MyEnums.CookerState.Empty:
                    //Start cooking
                    State = (int)MyEnums.CookerState.Working;
                    break;
                case (int)MyEnums.CookerState.Working:
                    //Nothing happens
                    break;
                case (int)MyEnums.CookerState.Done:
                    //Remove cooked item
                    if (playerItem == (int)MyEnums.ItemIDs.Empty)
                    {
                        receiveItem = true;
                        State = (int)MyEnums.CookerState.Empty;
                        Progress = 0;
                    }
                    break;
            }
            return receiveItem;
        }

        /// <summary>
        /// Called at each game step. If the mixer is currently working, progress is made on it
        /// </summary>
        public void Step()
        {
            //only perform action if mixer is working
            if (State == (int)MyEnums.CookerState.Working)
            {
                if (this.Progress < ProgressThreshold)  //if not at max, make progress
                {
                    Progress += ProgressStep;
                }
                if (Progress >= ProgressThreshold)  //if after we make progress, we're at max
                {
                    State = (int)MyEnums.CookerState.Done;
                }  
            }
        }

    }
}
