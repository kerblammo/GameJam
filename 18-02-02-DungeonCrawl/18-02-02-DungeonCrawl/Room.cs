using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Room class is an object that defines a room the player may explore
/// </summary>

namespace _18_02_02_DungeonCrawl
{
    class Room
    {
        //attributes
        public string ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsBuilt { get; set; }
        public bool DoorNorth { get; set; }
        public bool DoorEast { get; set; }
        public bool DoorSouth { get; set; }
        public bool DoorWest { get; set; }

        //constructor
        public Room()
        {
            //blank constructor
        }


        public Room(int x, int y)
        {

            IsBuilt = false;
            //value input is room's position on OverMap
            X = x;
            Y = y;
            ID = X.ToString() + Y.ToString();

            //Determine door position
            DoorNorth = false;
            DoorSouth = false;
            DoorEast = false;
            DoorWest = false;
            Random rand = new Random();
            int doorIndex = rand.Next(0, 15);
            switch (doorIndex)
            {
                case 0:
                    DoorNorth = true;
                    break;
                case 1:
                    DoorWest = true;
                    break;
                case 2:
                    DoorSouth = true;
                    break;
                case 3:
                    DoorEast = true;
                    break;
                case 4:
                    DoorNorth = true;
                    DoorEast = true;
                    break;
                case 5:
                    DoorEast = true;
                    DoorSouth = true;
                    break;
                case 6:
                    DoorSouth = true;
                    DoorWest = true;
                    break;
                case 7:
                    DoorWest = true;
                    DoorNorth = true;
                    break;
                case 8:
                    DoorNorth = true;
                    DoorSouth = true;
                    break;
                case 9:
                    DoorWest = true;
                    DoorEast = true;
                    break;
                case 10:
                    DoorWest = true;
                    DoorNorth = true;
                    DoorEast = true;
                    break;
                case 11:
                    DoorNorth = true;
                    DoorEast = true;
                    DoorSouth = true;
                    break;
                case 12:
                    DoorEast = true;
                    DoorSouth = true;
                    DoorWest = true;
                    break;
                case 13:
                    DoorSouth = true;
                    DoorWest = true;
                    DoorNorth = true;
                    break;
                case 14:
                    DoorNorth = true;
                    DoorSouth = true;
                    DoorWest = true;
                    DoorEast = true;
                    break;
                default:
                    break;
            }
        }

        
    }
}
