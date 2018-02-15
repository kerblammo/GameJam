using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Author: Peter Adam
/// Date: Feb 13, 2018
/// Cookthulhu is a time management restaurant themed game, developed for Jam Session 2 - Lovecraft.
/// The player must prepare and serve food to patrons before time runs out
/// </summary>

namespace CookThulhu
{
    public partial class frmStage : Form
    {
        public frmStage()
        {
            InitializeComponent();
        }

        Player player = new Player();
        List<Oven> ovens = new List<Oven>();
        List<Mixer> mixers = new List<Mixer>();


        /// <summary>
        /// When the player clicks on a patron, the player moves to the nearest location to it
        /// If the player is carrying an order, they will deliver it to the customer to be evaluated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picPatron1_Click(object sender, EventArgs e)
        {
            //retrieve location information and move the player to the new location
            int x = (int)MyEnums.PlayerXPos.Patron1;
            int y = (int)MyEnums.PlayerYPos.Patron1;
            picPlayer.Location = new Point(x, y);
            picPlayer.Image = Properties.Resources.PlayerUp;
            
            //TODO: evaluate order 
        }

        /// <summary>
        /// When the player clicks on a patron, the player moves to the nearest location to it
        /// If the player is carrying an order, they will deliver it to the customer to be evaluated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picPatron2_Click(object sender, EventArgs e)
        {
            //retrieve location information and move the player to the new location
            int x = (int)MyEnums.PlayerXPos.Patron2;
            int y = (int)MyEnums.PlayerYPos.Patron2;
            picPlayer.Location = new Point(x, y);
            picPlayer.Image = Properties.Resources.PlayerUp;

            //TODO: evaluate order 
        }

        /// <summary>
        /// When the player clicks on a patron, the player moves to the nearest location to it
        /// If the player is carrying an order, they will deliver it to the customer to be evaluated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picPatron3_Click(object sender, EventArgs e)
        {
            //retrieve location information and move the player to the new location
            int x = (int)MyEnums.PlayerXPos.Patron3;
            int y = (int)MyEnums.PlayerYPos.Patron3;
            picPlayer.Location = new Point(x, y);
            picPlayer.Image = Properties.Resources.PlayerUp;

            //TODO: evaluate order
        }

        /// <summary>
        /// When the player clicks on a patron, the player moves to the nearest location to it
        /// If the player is carrying an order, they will deliver it to the customer to be evaluated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picPatron4_Click(object sender, EventArgs e)
        {
            //retrieve location information and move the player to the new location
            int x = (int)MyEnums.PlayerXPos.Patron4;
            int y = (int)MyEnums.PlayerYPos.Patron4;
            picPlayer.Location = new Point(x, y);
            picPlayer.Image = Properties.Resources.PlayerUp;

            //TODO: evaluate order
        }

        /// <summary>
        /// When the player clicks on a mixer, the player moves to the nearest location to it
        /// IF the mixer is full, the player takes the finished dough from it
        /// ELSE IF the mixer is empty, the player starts the mixer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picMixer1_Click(object sender, EventArgs e)
        {
            //retrieve location information and move the player to the new location
            int x = (int)MyEnums.PlayerXPos.Mixer1;
            int y = (int)MyEnums.PlayerYPos.Mixer1;
            picPlayer.Location = new Point(x, y);
            picPlayer.Image = Properties.Resources.PlayerLeft;

            //check state of mixer and act appropriately
            int iMixer = 0;
            UseMixer(iMixer);
        }

        /// <summary>
        /// When the player clicks on a mixer, the player moves to the nearest location to it
        /// IF the mixer is full, the player takes the finished dough from it
        /// ELSE IF the mixer is empty, the player starts the mixer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //retrieve location information and move the player to the new location
            int x = (int)MyEnums.PlayerXPos.Mixer2;
            int y = (int)MyEnums.PlayerYPos.Mixer2;
            picPlayer.Location = new Point(x, y);
            picPlayer.Image = Properties.Resources.PlayerLeft;

            //check state of mixer and act appropriately
            int iMixer = 1;
            UseMixer(iMixer);
            
        }

        /// <summary>
        /// Use Mixer receives the index of the mixer to interact with.
        /// It checks the state of the mixer and determines if a player should receive an item
        /// </summary>
        /// <param name="iMixer"></param>
        public void UseMixer(int iMixer)
        {
            if (mixers[iMixer].Interact(player.HeldItem))
            {
                player.HeldItem = (int)MyEnums.ItemIDs.RawCake;
                //TODO: Display held item via picture box
                MessageBox.Show("Holding batter");
            }
        }

        /// <summary>
        /// When the player clicks on the station, the player moves to the nearest location to it
        /// IF the player is holding an undecorated cake, open the decorating menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picStationCakes_Click(object sender, EventArgs e)
        {
            //retrieve location information and move the player to the new location
            int x = (int)MyEnums.PlayerXPos.StationCakes;
            int y = (int)MyEnums.PlayerYPos.StationCakes;
            picPlayer.Location = new Point(x, y);
            picPlayer.Image = Properties.Resources.PlayerLeft;

            //TODO: if player is holding a cooked cake, open the cake menu
        }

        /// <summary>
        /// When the player clicks on the oven, the player moves to the nearest location to it
        /// IF the oven is completed, take the item out
        /// ELSE IF the oven is empty and the player is holding a cookable item, cook it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picOven1_Click(object sender, EventArgs e)
        {
            //retrieve location information and move the player to the new location
            int x = (int)MyEnums.PlayerXPos.Oven1;
            int y = (int)MyEnums.PlayerYPos.Oven1;
            picPlayer.Location = new Point(x, y);
            picPlayer.Image = Properties.Resources.PlayerDown;

            //TODO: check state of oven and decide what to do from there
            //check state of oven and act appropriately
            int iOven = 0;
            UseOven(iOven);
        }

        /// <summary>
        /// When the player clicks on the oven, the player moves to the nearest location to it
        /// IF the oven is completed, take the item out
        /// ELSE IF the oven is empty and the player is holding a cookable item, cook it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picOven2_Click(object sender, EventArgs e)
        {
            //retrieve location information and move the player to the new location
            int x = (int)MyEnums.PlayerXPos.Oven2;
            int y = (int)MyEnums.PlayerYPos.Oven2;
            picPlayer.Location = new Point(x, y);
            picPlayer.Image = Properties.Resources.PlayerDown;

            //TODO: check state of oven and decide what to do from there
            //check state of oven and act appropriately
            int iOven = 1;
            UseOven(iOven);
        }

        /// <summary>
        /// When the player clicks on the oven, the player moves to the nearest location to it
        /// IF the oven is completed, take the item out
        /// ELSE IF the oven is empty and the player is holding a cookable item, cook it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picOven3_Click(object sender, EventArgs e)
        {
            //retrieve location information and move the player to the new location
            int x = (int)MyEnums.PlayerXPos.Oven3;
            int y = (int)MyEnums.PlayerYPos.Oven3;
            picPlayer.Location = new Point(x, y);
            picPlayer.Image = Properties.Resources.PlayerDown;

            //TODO: check state of oven and decide what to do from there
            //check state of oven and act appropriately
            int iOven = 2;
            UseOven(iOven);
            
        }

        /// <summary>
        /// When the player clicks on the oven, the player moves to the nearest location to it
        /// IF the oven is completed, take the item out
        /// ELSE IF the oven is empty and the player is holding a cookable item, cook it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picOven4_Click(object sender, EventArgs e)
        {
            //retrieve location information and move the player to the new location
            int x = (int)MyEnums.PlayerXPos.Oven4;
            int y = (int)MyEnums.PlayerYPos.Oven4;
            picPlayer.Location = new Point(x, y);
            picPlayer.Image = Properties.Resources.PlayerDown;

            //TODO: check state of oven and decide what to do from there
            //check state of oven and act appropriately
            int iOven = 3;
            UseOven(iOven);
            
        }

        /// <summary>
        /// Use Oven receives the index of the oven to perform operation on.
        /// It checks the state of the oven, and determines if a player may take or insert an item into it
        /// </summary>
        /// <param name="iOven"></param>
        public void UseOven(int iOven)
        {
            //check if player must empty hands
            bool dropItem = false;
            if ((player.HeldItem == (int)MyEnums.ItemIDs.RawFingers || player.HeldItem == (int)MyEnums.ItemIDs.RawCake)
                && ovens[iOven].State == (int)MyEnums.CookerState.Empty)
            {
                dropItem = true;
            }
            if (ovens[iOven].Interact(player.HeldItem))
            {
                if (ovens[iOven].CurrentItem == (int)MyEnums.ItemIDs.RawCake)
                {
                    player.HeldItem = (int)MyEnums.ItemIDs.CookedCake;
                    MessageBox.Show("Holding cake");
                }
                else if (ovens[iOven].CurrentItem == (int)MyEnums.ItemIDs.RawFingers)
                {
                    player.HeldItem = (int)MyEnums.ItemIDs.Fingers;
                    MessageBox.Show("Holding fingers");
                }

                //TODO: Display held item via picture box

            }
            if (dropItem)
            {
                player.HeldItem = (int)MyEnums.ItemIDs.Empty;
            }
        }

        /// <summary>
        /// When the player clicks on the station, the player moves to the nearest location to it
        /// IF the player's hands are empty, open the chopping menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picStationChopping_Click(object sender, EventArgs e)
        {
            //retrieve location information and move the player to the new location
            int x = (int)MyEnums.PlayerXPos.StationChopping;
            int y = (int)MyEnums.PlayerYPos.StationChopping;
            picPlayer.Location = new Point(x, y);
            picPlayer.Image = Properties.Resources.PlayerDown;

            //TODO: if players hands are empty, open chopping menu
        }

        /// <summary>
        /// When the player clicks on the station, the player moves to the nearest location to it
        /// IF the player's hands are empty, open the ice cream menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picStationIceCream_Click(object sender, EventArgs e)
        {
            //retrieve location information and move the player to the new location
            int x = (int)MyEnums.PlayerXPos.StationIceCream;
            int y = (int)MyEnums.PlayerYPos.StationIceCream;
            picPlayer.Location = new Point(x, y);
            picPlayer.Image = Properties.Resources.PlayerRight;

            //TODO: if player's hands are empty, open icecream menu
        }

        /// <summary>
        /// When the player clicks on the trash, the player moves to the nearest location to it
        /// IF the player's hands are full, empty them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //retrieve location information and move the player to the new location
            int x = (int)MyEnums.PlayerXPos.Trash;
            int y = (int)MyEnums.PlayerYPos.Trash;
            picPlayer.Location = new Point(x, y);
            picPlayer.Image = Properties.Resources.PlayerRight;

            //discard held item
            player.HeldItem = (int)MyEnums.ItemIDs.Empty;
        }
        /// <summary>
        /// Events to perform when the form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStage_Load(object sender, EventArgs e)
        {
            ResetStage();
        }

        /// <summary>
        /// Resets stage to initial settings
        /// </summary>
        private void ResetStage()
        {
            //Create new player
            player = new Player();
            player.HeldItem = (int)MyEnums.ItemIDs.RawFingers;

            //Create mixers
            for (int i = 0; i < 2; i++)
            {
                Mixer mixer = new Mixer();
                PictureBox pic;
                switch (i)
                {
                    case 0:
                        pic = picProgressMixer1;
                        break;
                    case 1:
                    default:
                        pic = picProgressMixer2;
                        break;
                }
                mixer.ProgressBar = pic;
                mixers.Add(mixer);
            }

            //Create ovens
            for (int i = 0; i < 4; i++)
            {
                Oven oven = new Oven();
                PictureBox pic;
                switch (i)
                {
                    case 0:
                        pic = picProgressOven1;
                        break;
                    case 1:
                        pic = picProgressOven2;
                        break;
                    case 2:
                        pic = picProgressOven3;
                        break;
                    case 3:
                    default:
                        pic = picProgressOven4;
                        break;
                }
                oven.ProgressBar = pic;
                ovens.Add(oven);
            }
        }

        private void tmrStep_Tick(object sender, EventArgs e)
        {
            foreach (Mixer mixer in mixers)
            {
                //call step event
                mixer.Step();
                //check mixer state and update progress bar 
                switch (mixer.State)
                {
                    case (int)MyEnums.CookerState.Empty:    //ensure progress bar is empty
                        if (mixer.ProgressBar.Image != Properties.Resources.ProgressBar0)
                        {
                            mixer.ProgressBar.Image = Properties.Resources.ProgressBar0;
                        }
                        break;
                    case (int)MyEnums.CookerState.Working:  //display current progress
                        double progress = Convert.ToDouble(mixer.Progress);
                        double threshold = Convert.ToDouble(mixer.ProgressThreshold);
                        progress /= threshold;
                        //update progress bar
                        if (progress < 0.2)
                        {
                            mixer.ProgressBar.Image = Properties.Resources.ProgressBar0;
                        }
                        else if (progress < 0.4)
                        {
                            mixer.ProgressBar.Image = Properties.Resources.ProgressBar20;
                        }
                        else if (progress < 0.6)
                        {
                            mixer.ProgressBar.Image = Properties.Resources.ProgressBar40;
                        }
                        else if (progress < 0.8)
                        {
                            mixer.ProgressBar.Image = Properties.Resources.ProgressBar60;
                        }
                        else if (progress < 1)
                        {
                            mixer.ProgressBar.Image = Properties.Resources.ProgressBar80;
                        }
                        else
                        {
                            mixer.ProgressBar.Image = Properties.Resources.ProgressBar100;
                        }
                        break;
                    case (int)MyEnums.CookerState.Done: //ensure progress bar is now full
                        if (mixer.ProgressBar.Image != Properties.Resources.ProgressBar100)
                        {
                            mixer.ProgressBar.Image = Properties.Resources.ProgressBar100;
                        }
                        break;
                }
            }

            //check oven state and update progress bar
            foreach (Oven oven in ovens)
            {
                //call step event
                oven.Step();
                //check mixer state and update progress bar 
                switch (oven.State)
                {
                    case (int)MyEnums.CookerState.Empty:    //ensure progress bar is empty
                        if (oven.ProgressBar.Image != Properties.Resources.ProgressBar0)
                        {
                            oven.ProgressBar.Image = Properties.Resources.ProgressBar0;
                        }
                        break;
                    case (int)MyEnums.CookerState.Working:  //display current progress
                        double progress = Convert.ToDouble(oven.Progress);
                        double threshold = Convert.ToDouble(oven.ProgressThreshold);
                        progress /= threshold;
                        //update progress bar
                        if (progress < 0.2)
                        {
                            oven.ProgressBar.Image = Properties.Resources.ProgressBar0;
                        }
                        else if (progress < 0.4)
                        {
                            oven.ProgressBar.Image = Properties.Resources.ProgressBar20;
                        }
                        else if (progress < 0.6)
                        {
                            oven.ProgressBar.Image = Properties.Resources.ProgressBar40;
                        }
                        else if (progress < 0.8)
                        {
                            oven.ProgressBar.Image = Properties.Resources.ProgressBar60;
                        }
                        else if (progress < 1)
                        {
                            oven.ProgressBar.Image = Properties.Resources.ProgressBar80;
                        }
                        else
                        {
                            oven.ProgressBar.Image = Properties.Resources.ProgressBar100;
                        }
                        break;
                    case (int)MyEnums.CookerState.Done: //ensure progress bar is now full
                        if (oven.ProgressBar.Image != Properties.Resources.ProgressBar100)
                        {
                            oven.ProgressBar.Image = Properties.Resources.ProgressBar100;
                        }
                        break;
                }
            }
        }
    }
}
