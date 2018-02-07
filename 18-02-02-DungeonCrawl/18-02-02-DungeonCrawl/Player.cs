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
        public Rectangle PaintMaskKill { get; set; }
        public Size PaintSize { get; set; }
        public Room CurrentRoom { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool KillMonster { get; set; }
        public int Health { get; set; }
        
        //methods
        //move methods move the player, and update its paintmask
        public void MoveUp()
        {
            if (LegalMove(X, Y - Sprite.Height, this))
            {
                Y -= Sprite.Height;
                Moved();
            }
            
            
        }

        public void MoveDown()
        {
            if (LegalMove(X, Y + Sprite.Height, this))
            {
                Y += Sprite.Height;
                Moved();
            }
            
        }

        public void MoveLeft()
        {
            if (LegalMove(X - Sprite.Width, Y, this))
            {
                X -= Sprite.Width;
                Moved();
            }
        }

        public void MoveRight()
        {
            if (LegalMove(X + Sprite.Width, Y, this))
            {
                X += Sprite.Width;
                Moved();
            }
            
        }

        //moved method updates the paintmask
        public void Moved()
        {
            Origin = new Point(X, Y);
            PaintMaskOld = PaintMask;
            PaintMask = new Rectangle(Origin, PaintSize);
        }

        //checks if player can legally move
        private bool LegalMove(int x, int y, Player player)
        {
            bool isLegal = true;
            try
            {

                MyEnums.TileCollisions tileToCheck = player.CurrentRoom.RowList[y / player.Sprite.Height][x / player.Sprite.Width].Type;
                if (tileToCheck == MyEnums.TileCollisions.Obstacle
                    || tileToCheck == MyEnums.TileCollisions.Pit
                    || tileToCheck == MyEnums.TileCollisions.Wall)
                {
                    isLegal = false;
                    return isLegal;
                }
            }
            catch
            {
                isLegal = false;
                return isLegal;
            }
            //check if monster exists, and if it does, remove it
            int monsterIndex = 0;
            bool removeMonster = false;
            foreach (Monster monster in CurrentRoom.Monsters)
            {
                if (monster.X == x && monster.Y == y)
                {
                    isLegal = false;
                    removeMonster = true;
                    PaintMaskKill = monster.PaintMask;
                    KillMonster = true;
                    break;
                }
                monsterIndex++;
            }
            if (removeMonster)
            {
                CurrentRoom.Monsters.RemoveAt(monsterIndex);
            }
            return isLegal;
        }
        
        //Constructor
        public Player()
        {
            Health = 3;
            Sprite = Properties.Resources.Player;
            X = Sprite.Width * 5;
            Y = Sprite.Height * 5;
            Origin = new Point(X, Y);
            PaintSize = new Size(Sprite.Width, Sprite.Height);
            PaintMask = new Rectangle(Origin, PaintSize);

        }

        

    }
}
