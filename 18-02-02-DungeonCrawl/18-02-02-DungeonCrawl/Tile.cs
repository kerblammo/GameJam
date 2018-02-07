using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

//The tile class defines an object which represents a space which makes up part of a room

namespace _18_02_02_DungeonCrawl
{
    class Tile
    {
        //attributes
        public Image Sprite { get; set; }
        public MyEnums.TileCollisions Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Point Origin { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        //Constructors
        public Tile()
        {
            //empty
        }

        public Tile(MyEnums.TileCollisions style)
        {
            //create a new tile with appropriate image and collision properties
            Type = style;
            switch (Type)
            {
                case MyEnums.TileCollisions.Empty:
                    Sprite = Properties.Resources.TileEmpty;
                    break;
                case MyEnums.TileCollisions.Obstacle:
                    Sprite = Properties.Resources.TileObstacle;
                    break;
                case MyEnums.TileCollisions.Pit:
                    Sprite = Properties.Resources.TilePit;
                    break;
                case MyEnums.TileCollisions.StairsDown:
                    Sprite = Properties.Resources.TileStairDown;
                    break;
                case MyEnums.TileCollisions.StairsUp:
                    Sprite = Properties.Resources.TileStairUp;
                    break;
                case MyEnums.TileCollisions.Wall:
                    Sprite = Properties.Resources.TileWall;
                    break;
            }
            Width = Sprite.Width;
            Height = Sprite.Height;

            
        }
    }
}
