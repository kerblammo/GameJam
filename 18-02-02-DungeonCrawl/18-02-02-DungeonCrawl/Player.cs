using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
/// <summary>
/// The player class defines the playable character
/// </summary>
namespace _18_02_02_DungeonCrawl
{
    class Player
    {

        //attributes
        public Image Sprite { get; set; }
        public Point Origin { get; set; }
        public Rectangle PaintMask { get; set; }
        public Rectangle PaintMaskOld { get; set; }
        public Size PaintSize { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        
        //methods
        //move methods move the player, and update its paintmask
        public void MoveUp()
        {
            Y -= Sprite.Height;
            Moved();
            
        }

        public void MoveDown()
        {
            Y += Sprite.Height;
            Moved();
        }

        public void MoveLeft()
        {
            X -= Sprite.Width;
            Moved();
        }

        public void MoveRight()
        {
            X += Sprite.Width;
            Moved();
        }

        //moved method updates the paintmask
        private void Moved()
        {
            Origin = new Point(X, Y);
            PaintMaskOld = PaintMask;
            PaintMask = new Rectangle(Origin, PaintSize);
        }
        
        //Constructor
        public Player()
        {
            Sprite = Properties.Resources.Player;
            X = 32 * 5;
            Y = 32 * 5;
            Origin = new Point(X, Y);
            PaintSize = new Size(Sprite.Width, Sprite.Height);
            PaintMask = new Rectangle(Origin, PaintSize);

        }

        

    }
}
