using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// Patron is an object that represents a customer
/// </summary>
namespace CookThulhu
{
    class Patron
    {
        //details for patron's ice cream order
        public IceCream DesiredIceCream { get; set; }
        public Cake DesiredCake { get; set; }
        public int DesiredMeal { get; set; }
        public int Value { get; set; }
        public PictureBox Pic { get; set; }
        public PictureBox PatienceBar { get; set; }
        public int Patience { get; set; }
        public int PatienceStep { get; set; }

        /// <summary>
        /// Creates a cake with random toppings
        /// </summary>
        /// <returns></returns>
        private Cake RandomCake()
        {
            bool cherries = false;
            bool skulls = false;
            bool sigil = false;
            Random rand = new Random();
            int roll = rand.Next(0, 2);
            if (roll == 1)
            {
                cherries = true;
            }
            roll = rand.Next(0, 2);
            if (roll == 1)
            {
                skulls = true;
            }
            roll = rand.Next(0, 2);
            if (roll == 1)
            {
                sigil = true;
            }
            return new Cake(sigil, skulls, cherries);
        }

        /// <summary>
        /// Creates an ice cream with random toppings
        /// </summary>
        /// <returns></returns>
        private IceCream RandomIceCream()
        {
            IceCream icecream = new IceCream();
            Random rand = new Random();
            int maxScoops = 3;
            
            for (int i = 0; i < maxScoops; i++)
            {
                int roll = rand.Next(1, 4); //range 1-3
                switch (roll)
                {
                    case 1:
                        icecream.ScoopsChocolate++;
                        break;
                    case 2:
                        icecream.ScoopsHazel++;
                        break;
                    case 3:
                        icecream.ScoopsMint++;
                        break;
                }
            }
            return icecream;

        }

        /// <summary>
        /// Called at each game step. The patron's patience slowly decreases over time
        /// </summary>
        public bool Step()
        {
            bool expired = false;
            Patience -= PatienceStep;
            if (Patience <= 0)  //if patron is out of patience
            {
                expired = true;
            }
            return expired;
        }

        /// <summary>
        /// Create a new patron 
        /// </summary>
        public Patron()
        {
            //empty constructor
        }

        /// <summary>
        /// Create a new patron
        /// </summary>
        /// <param name="pic"></param>
        public Patron(PictureBox pic, PictureBox bar)
        {
            //initial values
            Patience = 100;
            PatienceStep = 4;Random rand = new Random();
            

            //determine which patron to show
            int selection = rand.Next(1, 5);    //range 1-4
            switch (selection)
            {
                case 1:
                    pic.Image = Properties.Resources.PatronGreen;
                    break;
                case 2:
                    pic.Image = Properties.Resources.PatronRed;
                    break;
                case 3:
                    pic.Image = Properties.Resources.PatronPurple;
                    break;
                case 4:
                    pic.Image = Properties.Resources.PatronYellow;
                    break;
            }

            //show patience bar
            Pic = pic;
            PatienceBar = bar;
            bar.Image = Properties.Resources.ProgressBar100;

            //determine what meal the patron desires
            Value = 0;
            selection = rand.Next(1, 4);    //range 1-3
            switch (selection)
            {
                case 1: //ladyfingers
                    DesiredMeal = (int)MyEnums.ItemIDs.Fingers;
                    Value = 50;
                    MessageBox.Show("New Order: \nLady Fingers");
                    break;
                case 2: //cake
                    DesiredMeal = (int)MyEnums.ItemIDs.Cake;
                    DesiredCake = RandomCake();
                    Value = 100;
                    MessageBox.Show("New Order: \nDevil's Food Cake\n\nSkulls:" + DesiredCake.Skulls + "\nPentagram:" + DesiredCake.Sigil + "\nCherries:" + DesiredCake.Cherries);
                    break;
                case 3: //icecream
                    DesiredMeal = (int)MyEnums.ItemIDs.IceCream;
                    DesiredIceCream = RandomIceCream();
                    Value = 75;
                    MessageBox.Show("New Order: \nEye Scream\n\nChoc:" + DesiredIceCream.ScoopsChocolate + "\nMint" + DesiredIceCream.ScoopsMint + "\nHazel:" + DesiredIceCream.ScoopsHazel);
                    break;
            }

        }


        
    }
}
