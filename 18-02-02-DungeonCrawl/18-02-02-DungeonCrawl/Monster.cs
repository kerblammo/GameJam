using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_02_02_DungeonCrawl
{
    class Monster
    {
        //attributes
        public Image Sprite { get; set; }
        public Point Origin { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Rectangle PaintMask { get; set; }
        public Rectangle PaintMaskOld { get; set; }
        public Size PaintSize { get; set; }
        public Room CurrentRoom { get; set; }
        public Player Target { get; set; }
        public bool TargetHit { get; set; }

        //methods
        public void DetermineDirection()
        {
            //determine which direction will bring monster closer to target
            int xdir;
            int ydir;
            int xdistance;
            int ydistance;
            if (X > Target.X)
            {
                xdir = -1;
            }
            else
            {
                xdir = 1;
            }
            if (Y > Target.Y)
            {
                ydir = -1;
            }
            else
            {
                ydir = 1;
            }
            //determine which direction to try first
            xdistance = Math.Abs(X - Target.X);
            ydistance = Math.Abs(Y - Target.Y);
            if (ydistance > xdistance)
            {
                if (LegalMove(X, Y + Sprite.Height * ydir, this))
                {
                    Y += Sprite.Height * ydir;
                    Moved();
                    return;
                }
                if (TargetHit)
                {
                    TargetHit = false;
                    return;
                }
                if (LegalMove(X + Sprite.Width * xdir, Y, this))
                {
                    X += Sprite.Width * xdir;
                    Moved();
                }
            }
            else
            {
                if (LegalMove(X + Sprite.Width * xdir, Y, this))
                {
                    X += Sprite.Width * xdir;
                    Moved();
                    return;
                }
                if (TargetHit)
                {
                    TargetHit = false;
                    return;
                }
                if (LegalMove(X, Y + Sprite.Height * ydir, this))
                {
                    Y += Sprite.Height * ydir;
                    Moved();
                }
            }

        }

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
        public void Moved()
        {
            Origin = new Point(X, Y);
            PaintMaskOld = PaintMask;
            PaintMask = new Rectangle(Origin, PaintSize);
        }

        //checks if player can legally move
        private bool LegalMove(int x, int y, Monster monster)
        {
            bool isLegal = true;
            try
            {
                MyEnums.TileCollisions tileToCheck = monster.CurrentRoom.RowList[y / monster.Sprite.Height][x / monster.Sprite.Width].Type;
                if (tileToCheck == MyEnums.TileCollisions.Obstacle
                    || tileToCheck == MyEnums.TileCollisions.Pit
                    || tileToCheck == MyEnums.TileCollisions.Wall)
                {
                    isLegal = false;
                }

            }
            catch
            {
                isLegal = false;
                return isLegal;
            }
            if (Target.X == x && Target.Y == y)
            {
                isLegal = false;
                Target.Health--;
                TargetHit = true;
                return isLegal;
            }
            foreach (Monster otherMonsters in CurrentRoom.Monsters)
            {
                if (x == otherMonsters.X && y == otherMonsters.Y && otherMonsters != this)
                {
                    isLegal = false;
                    break;
                }
            }
            
            return isLegal;
        }

        public MyEnums.Cardinal DetermineDirection(Player player)
        {
            return MyEnums.Cardinal.Down;
        }



        //constructors
        public Monster()
        {
            
        }

        public Monster(int x, int y, Room room, Player player)
        {
            
            Sprite = Properties.Resources.Monster;
            X = x;
            Y = y;
            TargetHit = false;
            CurrentRoom = room;
            Origin = new Point(X, Y);
            Target = CurrentRoom.MainPlayer;
            PaintSize = new Size(Sprite.Width, Sprite.Height);
            PaintMask = new Rectangle(Origin, PaintSize);
        }

    }
}
