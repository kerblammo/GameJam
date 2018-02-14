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

            //TODO: check if mixer is full, or if it needs to be started
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

            //TODO: check if mixer is full, or if it needs to be started
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

            //TODO: if player is holding an item, discard it
        }
    }
}
