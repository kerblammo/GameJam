using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EastBayFrontier
{
    /// <summary>
    /// Author: Peter Adam
    /// Start Date: March 16, 2018
    /// This is the form that the player will be interacting with. 
    /// </summary>
    public partial class frmMain : Form
    {
        /// <summary>
        /// Construct the form
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            
            //Create the Controller
            ScoreKeeper = new EBFController();
            ScoreKeeper.Display = this;

            //Create the Ninja object
            ScoreKeeper.Ninja = new FactionNinja();
            ScoreKeeper.Ninja.ScoreKeeper = ScoreKeeper;
            List<Image> tempSprite = new List<Image>();
            tempSprite.Add(Properties.Resources.Debug00);
            tempSprite.Add(Properties.Resources.Debug01);
            ScoreKeeper.Ninja.Animation.Sprite = tempSprite;
            ScoreKeeper.Ninja.Animation.PicBox = picNinja;
            picNinja.Image = ScoreKeeper.Ninja.Animation.Sprite[0];

            //Create the Pirate object
            ScoreKeeper.Pirate = new FactionPirate();
            ScoreKeeper.Pirate.ScoreKeeper = ScoreKeeper;
            tempSprite.Clear();
            tempSprite.Add(Properties.Resources.Debug00);
            tempSprite.Add(Properties.Resources.Debug01);
            ScoreKeeper.Pirate.Animation.Sprite = tempSprite;
            ScoreKeeper.Pirate.Animation.PicBox = picPirate;
            picPirate.Image = ScoreKeeper.Pirate.Animation.Sprite[0];

            //Create the Cowboy object
            ScoreKeeper.Cowboy = new FactionCowboy();
            ScoreKeeper.Cowboy.ScoreKeeper = ScoreKeeper;
            tempSprite.Clear();
            tempSprite.Add(Properties.Resources.Debug00);
            tempSprite.Add(Properties.Resources.Debug01);
            ScoreKeeper.Cowboy.Animation.Sprite = tempSprite;
            ScoreKeeper.Cowboy.Animation.PicBox = picCowboy;
            picCowboy.Image = ScoreKeeper.Cowboy.Animation.Sprite[0];

            //Set tooltips
            SetFormTooltips();

        }

        #region Attributes
        ///All form properties go here
        public EBFController ScoreKeeper { get; set; }
        #endregion



        /// <summary>
        /// Represents a game step
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrStep_Tick(object sender, EventArgs e)
        {
            ScoreKeeper.Step();
            lblGold.Text = ScoreKeeper.Gold.ToString();
            lblSake.Text = ScoreKeeper.Ninja.Hooch.ToString();
            lblRum.Text = ScoreKeeper.Pirate.Hooch.ToString();
            lblWhiskey.Text = ScoreKeeper.Cowboy.Hooch.ToString();
        }

       /// <summary>
       /// Determine what action to take when clicking on a faction
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void Faction_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            ScoreKeeper.ClickFaction(pic);
        }

        /// <summary>
        /// Initialize the values of form's tooltips
        /// </summary>
        public void SetFormTooltips()
        {
            tipButtons.SetToolTip(btnNinjaValue,
                    "Doubles the Earning value of Ninja.\nFrom " + ScoreKeeper.Ninja.Value +
                    " to " + ScoreKeeper.Ninja.EarningUpgrade.Value);
        }

        /// <summary>
        /// Purchase an upgrade for the Ninja which increases their value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// TODO: Make this more robust so it can be used on other buttons and their respective factions.
        /// EG: see the Faction_Click event
        private void btnNinjaValue_Click(object sender, EventArgs e)
        {
            
            if (ScoreKeeper.Ninja.PurchaseEarningUpgrade())
            {
                tipButtons.SetToolTip(btnNinjaValue,
                    "Doubles the Earning value of Ninja.\nFrom " + ScoreKeeper.Ninja.Value +
                    " to " + ScoreKeeper.Ninja.EarningUpgrade.Value);
                lblNinjaUpgradeValue.Text = "Cost: " + ScoreKeeper.Ninja.EarningUpgrade.Cost + "gp";
            }
        }
    }
}
