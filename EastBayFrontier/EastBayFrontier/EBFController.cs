using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EastBayFrontier
{
    /// <summary>
    /// Author: Peter Adam
    /// Start Date: March 16, 2018
    /// This class controls the game flow and keeps track of the player's score
    /// </summary>
    public class EBFController
    {
        #region Attributes
        public int Gold { get; set; }
        public FactionNinja Ninja { get; set; }
        public FactionPirate Pirate { get; set; }
        public FactionCowboy Cowboy { get; set; }
        public frmMain Display { get; set; }
        #endregion

        /// <summary>
        /// Perform gamestep operations
        /// </summary>
        public void Step()
        {
            Ninja.Tick();
            Pirate.Tick();
            Cowboy.Tick();
        }

        /// <summary>
        /// Determine what happens when the player selects a faction
        /// </summary>
        /// <param name="sender"></param>
        public void ClickFaction(PictureBox pic)
        {
            switch (pic.Name)
            {
                case "picNinja":
                    Ninja.Active = true;
                    Pirate.Pause();
                    Cowboy.Pause();
                    break;
                case "picPirate":
                    Pirate.Active = true;
                    Ninja.Pause();
                    Cowboy.Pause();
                    break;
                case "picCowboy":
                    Cowboy.Active = true;
                    Ninja.Pause();
                    Pirate.Pause();
                    break;
            }
        }

        /// <summary>
        /// Default constructor. Create a new instance of EBFController with initial values.
        /// </summary>
        public EBFController()
        {
            Gold = 0;
        }
    }
}
