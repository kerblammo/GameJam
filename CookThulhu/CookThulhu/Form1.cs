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
        List<Patron> patrons = new List<Patron>();
        int seconds;
        int patronCooldown;


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
            EvaluateOrder(picPatron1, picPatiencePatron1);
                
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

            //evaluate order
            EvaluateOrder(picPatron2, picPatiencePatron2);
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

            //evaluate order
            EvaluateOrder(picPatron3, picPatiencePatron3);
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

            //evaluate order
            EvaluateOrder(picPatron4, picPatiencePatron4);
        }


        /// <summary>
        /// Check if player is holding an item that matches the patron's order
        /// </summary>
        /// <param name="pic"></param>
        private void EvaluateOrder(PictureBox pic, PictureBox bar)
        {
            bool match = true;
            //determine which patron to use
            Patron patron = patrons[0];
            foreach (Patron pat in patrons)
            {
                if (pat.Pic == pic)
                {
                    patron = pat;
                    break;
                }
            }

            //check if given item is valid type of meal
            if (player.HeldItem != patron.DesiredMeal)
            {
                match = false;
            }
            //check if specifics of meal are valid
            if (match)
            {
                switch (player.HeldItem)
                {
                    case (int)MyEnums.ItemIDs.Fingers:  //lady fingers
                        //Lady fingers require no customization, so this is an automatic success
                        break;
                    case (int)MyEnums.ItemIDs.IceCream: //ice cream
                        //check if there are any discrepancies
                        if (player.HeldIceCream.ScoopsChocolate != patron.DesiredIceCream.ScoopsChocolate
                            || player.HeldIceCream.ScoopsHazel != patron.DesiredIceCream.ScoopsHazel
                            || player.HeldIceCream.ScoopsMint != patron.DesiredIceCream.ScoopsMint)
                        {
                            match = false;
                        }
                        break;
                    case (int)MyEnums.ItemIDs.Cake: //cake
                        //check if there are any discrepancies
                        if (player.HeldCake.Cherries != patron.DesiredCake.Cherries
                            || player.HeldCake.Skulls != patron.DesiredCake.Skulls
                            || player.HeldCake.Sigil != patron.DesiredCake.Sigil)
                        {
                            match = false;
                        }
                        break;
                }
            }
            //final rating: assign value or award strike
            if (match)
            {
                player.Score += patron.Value;
                MessageBox.Show("Success!");
            }
            else
            {
                MessageBox.Show("Strike!");
                player.Strikes++;
                if (player.Strikes >= player.MaxStrikes)
                {
                    MessageBox.Show("Game Over!");   //TODO: Dress this up a bit, option to reset game or quit
                    tmrStep.Stop();
                }
            }
            player.HeldItem = (int)MyEnums.ItemIDs.Empty;
            pic.Visible = false;
            bar.Visible = false;
            patrons.Remove(patron);

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

            //if player is holding a cooked cake, open the cake menu
            if (player.HeldItem == (int)MyEnums.ItemIDs.CookedCake)
            {
                //Show customization menu
                player.OpenStation = (int)MyEnums.Station.Cake;
                pnlCustomMenu.Show();
                lblCustomizationRecipe.Text = "Devils' Food Cake";
                lblCustomizationCommand1.Text = "Q: Sugar Skulls";
                lblCustomizationCommand2.Text = "W: Pentagram";
                lblCustomizationCommand3.Text = "E: Cherry Giblets";
                lblCustomizationCommand4.Text = "R: Return";

                //Make cake for player to hold
                player.HeldCake = new Cake();
                picCakeBase.Visible = true;

            }
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

            // if players hands are empty, open chopping menu
            if (player.HeldItem == (int)MyEnums.ItemIDs.Empty)
            {
                //show customization menu
                pnlCustomMenu.Show();
                player.OpenStation = (int)MyEnums.Station.Fingers;
                lblCustomizationRecipe.Text = "Lady Fingers";
                lblCustomizationCommand1.Text = "Q: Take Knife";
                lblCustomizationCommand2.Text = "W: Chop";
                lblCustomizationCommand3.Text = "E: Drop Knife";
                lblCustomizationCommand4.Text = "R: Return";

                //create fingers for player
                player.HeldFingers = new Fingers();
                picFingersHand.Image = Properties.Resources.FingersWhole;
                picFingersHand.Visible = true;
                picKnifeRest.Visible = true;
            }
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

            //if player's hands are empty, open icecream menu
            if (player.HeldItem == (int)MyEnums.ItemIDs.Empty)
            {
                //Show customization menu
                pnlCustomMenu.Show();
                player.OpenStation = (int)MyEnums.Station.IceCream;
                lblCustomizationRecipe.Text = "Eye Scream";
                lblCustomizationCommand1.Text = "Q: Chocolate";
                lblCustomizationCommand2.Text = "W: Mint";
                lblCustomizationCommand3.Text = "E: Hazel";
                lblCustomizationCommand4.Text = "R: Return";
                

                //create ice cream for player
                player.HeldIceCream = new IceCream();
                picIceCreamCone.Visible = true;


            }
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
            //Start clock over
            patronCooldown = 30;
            seconds = 25;   //intentionally set to 25: gives player 5 seconds before first patron spawns
            tmrStep.Start();
            //Create new player
            player = new Player();
            player.HeldItem = (int)MyEnums.ItemIDs.Empty;
            player.Score = 0;

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

        /// <summary>
        /// Perform operations that are time dependant. EG Mixer/Oven progress, Patron patience, and spawning patrons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrStep_Tick(object sender, EventArgs e)
        {
            //keep track of time
            seconds++;
            //check if patron needs to be spawned
            if (seconds % patronCooldown == 0)
            {
                //check where (and if it is legal to) to spawn patron
                bool spawn = false;
                PictureBox patronLocation = picPatron1;
                PictureBox patronBar = picPatiencePatron1;
                if (!picPatron1.Visible)
                {
                    patronLocation = picPatron1;
                    patronBar = picPatiencePatron1;
                    spawn = true;
                }
                else if (!picPatron2.Visible)
                {
                    patronLocation = picPatron2;
                    patronBar = picPatiencePatron2;
                    spawn = true;
                }
                else if (!picPatron3.Visible)
                {
                    patronLocation = picPatron3;
                    patronBar = picPatiencePatron3;
                    spawn = true; 
                }
                else if (!picPatron4.Visible)
                {
                    patronLocation = picPatron4;
                    patronBar = picPatiencePatron4;
                    spawn = true;
                }
                if (spawn)
                {
                    if (patronCooldown > 18)
                    {
                        patronCooldown--;
                    }
                    
                    patrons.Add(new Patron(patronLocation, patronBar));
                    patronLocation.Visible = true;
                    patronBar.Visible = true;
                    
                }
            }

            //call each patron's step event
            List<Patron> removePatrons = new List<Patron>();
            foreach (Patron patron in patrons)
            {
                if (patron.Step())
                {
                    removePatrons.Add(patron);
                    patron.Pic.Visible = false;
                    patron.PatienceBar.Visible = false;
                    player.Strikes++;
                    
                }
                if (patron.Patience > 80)
                {
                    patron.PatienceBar.Image = Properties.Resources.ProgressBar100;
                }
                else if (patron.Patience > 60)
                {
                    patron.PatienceBar.Image = Properties.Resources.ProgressBar80;
                }
                else if (patron.Patience > 40)
                {
                    patron.PatienceBar.Image = Properties.Resources.ProgressBar60;
                }
                else if (patron.Patience > 20)
                {
                    patron.PatienceBar.Image = Properties.Resources.ProgressBar40;
                }
                else if (patron.Patience > 0)
                {
                    patron.PatienceBar.Image = Properties.Resources.ProgressBar20;
                }
            }
            //remove patrons that should be removed
            for (int i = removePatrons.Count - 1; i >= 0; i--)
            {
                patrons.Remove(patrons[i]);
            }


            //call each mixer's step event
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

        private void frmStage_KeyDown(object sender, KeyEventArgs e)
        {
            //determine which control scheme to use based on which station is open
            switch (player.OpenStation)
            {
                case ((int)MyEnums.Station.IceCream):   //ice cream station
                    //see if more scoops are valid
                    int totalScoops = player.HeldIceCream.ScoopsHazel + player.HeldIceCream.ScoopsMint
                        + player.HeldIceCream.ScoopsChocolate;
                    int maxScoops = 3;
                    PictureBox currentScoop;

                    //determine which scoop to show
                    switch (totalScoops)
                    {
                        case 0:
                            currentScoop = picIceCreamScoop1;
                            break;
                        case 1:
                            currentScoop = picIceCreamScoop2;
                            break;
                        case 2:
                            currentScoop = picIceCreamScoop3;
                            break;
                        default:
                            currentScoop = picIceCreamScoop1;
                            break;
                    }

                    //keybindings
                    switch (e.KeyCode)
                    {
                        case Keys.Q:    //Chocolate
                            if (totalScoops < maxScoops)
                            {
                                player.HeldIceCream.ScoopsChocolate++;
                                currentScoop.Image = Properties.Resources.IceCreamScoopChocolate;
                                currentScoop.Visible = true;
                            }
                            break;
                        case Keys.W:    //Mint
                            if (totalScoops < maxScoops)
                            {
                                player.HeldIceCream.ScoopsMint++;
                                currentScoop.Image = Properties.Resources.IceCreamScoopMint;
                                currentScoop.Visible = true;
                            }
                            break;
                        case Keys.E:    //Hazel
                            if (totalScoops < maxScoops)
                            {
                                player.HeldIceCream.ScoopsHazel++;
                                currentScoop.Image = Properties.Resources.IceCreamScoopHazel;
                                currentScoop.Visible = true;
                            }
                            break;
                        case Keys.R:    //Close Menu
                            //hide images
                            picIceCreamScoop1.Visible = false;
                            picIceCreamScoop2.Visible = false;
                            picIceCreamScoop3.Visible = false;
                            picIceCreamCone.Visible = false;
                            pnlCustomMenu.Visible = false;

                            //give ice cream to player
                            player.HeldItem = (int)MyEnums.ItemIDs.IceCream;
                            break;
                    }
                    break;
                case ((int)MyEnums.Station.Fingers):    //fingers station

                    //keybinds
                    switch (e.KeyCode)
                    {
                        case Keys.Q:    //grab knife
                            if (!player.HeldFingers.HeldKnife)  //take the knife, if not holding it
                            {
                                player.HeldFingers.HeldKnife = true;
                                picKnifeRest.Visible = false;
                            }
                            break;
                        case Keys.W:    //chop
                            if (!player.HeldFingers.ChoppedKnife    //if player hasn't chopped
                                && player.HeldFingers.HeldKnife)    //and player is holding knife
                            {
                                player.HeldFingers.ChoppedKnife = true;
                                picKnifeChopping.Visible = true;
                                picFingersHand.Image = Properties.Resources.FingersChopped;
                            }
                            break;
                        case Keys.E:    //drop knife
                            if (player.HeldFingers.ChoppedKnife    //if player has chopped
                                && !player.HeldFingers.DroppedKnife)    //and player hasn't dropped knife
                            {
                                picKnifeChopping.Visible = false;
                                picKnifeRest.Visible = true;
                                player.HeldFingers.DroppedKnife = true;
                            }
                                break;
                        case Keys.R:    //close menu
                            if (player.HeldFingers.DroppedKnife)    //if player has dropped knife
                            {
                                picKnifeRest.Visible = false;
                                picFingersHand.Visible = false;
                                pnlCustomMenu.Visible = false;
                                player.HeldItem = (int)MyEnums.ItemIDs.RawFingers;
                            }
                            
                            break;
                    }
                    break;
                case ((int)MyEnums.Station.Cake):       //cake station

                    //keybinds
                    switch (e.KeyCode)
                    {
                        case Keys.Q:    //skulls
                            if (!player.HeldCake.Skulls)
                            {
                                picCakeSkulls.Visible = true;
                                player.HeldCake.Skulls = true;
                            }
                            break;
                        case Keys.W:    //sigil
                            if (!player.HeldCake.Sigil)
                            {
                                picCakeSigil.Visible = true;
                                player.HeldCake.Sigil = true;
                            }
                            break;
                        case Keys.E:    //cherries
                            if (!player.HeldCake.Cherries)
                            {
                                picCakeCherries.Visible = true;
                                player.HeldCake.Cherries = true;
                            }
                            break;
                        case Keys.R:    //close menu
                            //hide images
                            picCakeBase.Visible = false;
                            picCakeCherries.Visible = false;
                            picCakeSigil.Visible = false;
                            picCakeSkulls.Visible = false;
                            pnlCustomMenu.Visible = false;

                            //give cake to player
                            player.HeldItem = (int)MyEnums.ItemIDs.Cake;
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
