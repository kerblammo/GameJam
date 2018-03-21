using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace EastBayFrontier
{
    /// <summary>
    /// Author: Peter Adam
    /// Start Date: March 16, 2018
    /// The Faction class contains the basic functionality that each faction will require.
    /// Therefore, it is the parent of the Cowboy, Pirate, and Ninja classes.
    /// It includes functionality for tracking its current hooch level,
    /// as well as gold gained (both when and how much),
    /// and controls its animation
    /// </summary>
    public class Faction
    {
        #region Attributes
        public bool Active { get; set; }                //Determines if faction is currently earning gold
        public int MaxHooch { get; set; }               //Determines the maximum amount of hooch that can be obtained
        public int Hooch { get; set; }                  //The current amount of hooch
        public int Speed { get; set; }                  //How much progress is made with each tick
        public int Progress { get; set; }               //Current progress made to earning gold
        public int Threshold { get; set; }              //How much progress is needed to earn gold
        public int Value { get; set; }                  //How much gold is earned with each cash-in
        public int RecoverSpeed { get; set; }          //How quickly hooch drains
        public int RecoverProgress { get; set; }       //How much progress made to next cooloff 
        public int RecoverThreshold { get; set; }      //When cooldown happens
        public int RecoverValue { get; set; }          //How much hooch drains
        public EBFController ScoreKeeper { get; set; }  //Controller that keeps track of score
        public Animator Animation { get; set; }         //Faction's animation controller
        public UpgradeData EarningUpgrade { get; set;}  //Data re: earnings' upgrades
        public UpgradeData HoochUpgrade { get; set; }   //Data re: hooch upgrades
        #endregion

        /// <summary>
        /// Actions to be performed each game step
        /// Increment progress by speed, and if it's greater than the threshold, call Earn
        /// </summary>
        public void Tick()
        {
            if (Active) //faction is currently working
            {
                Animation.Play(); //run animation
                if (Hooch <= 0)   //do not perform after certain limit
                {
                    Progress = 0;
                }
                else
                {
                    Progress += Speed;
                    if (Progress >= Threshold)  //too much progress made
                    {
                        Earn();
                    }
                }
            }
            else    //faction is currently resting
            {
                RecoverProgress += RecoverSpeed;
                if (RecoverProgress >= RecoverThreshold)
                {
                    RecoverProgress -= RecoverThreshold;
                    
                    //increase hooch, but not over maximum
                    if (Hooch + RecoverValue >= MaxHooch)
                    {
                        Hooch = MaxHooch;
                    }
                    else
                    {
                        Hooch += RecoverValue;
                    }
                    
                }
            }


        }

        /// <summary>
        /// Call this method when you wish to pause the faction
        /// </summary>
        public void Pause()
        {
            Active = false;
            Progress = 0;
            RecoverProgress = 0;
            Animation.Stop();

        }

        /// <summary>
        /// Accumulate gold after progress is complete
        /// </summary>
        public void Earn()
        {
            //reset current progress
            Progress -= Threshold;

            //add gold to scorekeeper
            ScoreKeeper.Gold += Value;

            //decrement hooch
            Hooch--;

        }

        /// <summary>
        /// Purchase an upgrade for the earning power
        /// </summary>
        public bool PurchaseEarningUpgrade()
        {
            bool purchaseMade = false;
            if (ScoreKeeper.Gold >= EarningUpgrade.Cost)
            {
                purchaseMade = true;
                ScoreKeeper.Gold -= EarningUpgrade.Cost;
                Value = EarningUpgrade.Value;
                EarningUpgrade.Value *= 2;
                EarningUpgrade.Cost *= 2;
            }
            return purchaseMade;
        }

        

        /// <summary>
        /// Initialize a new instance of Faction with default values
        /// </summary>
        public Faction()
        {
            Active = false;
            MaxHooch = 10;
            Hooch = MaxHooch;
            Speed = 10;
            Progress = 0;
            Threshold = 100;
            Value = 1;
            RecoverProgress = 0;
            RecoverSpeed = 5;
            RecoverThreshold = 100;
            RecoverValue = 1;
            Animation = new Animator();

            //upgrade info
            EarningUpgrade = new UpgradeData();
            EarningUpgrade.Cost = 30;
            EarningUpgrade.Value = 2;
            HoochUpgrade = new UpgradeData();
            HoochUpgrade.Cost = 30;
            HoochUpgrade.Value = 20;
        }
    }
}
