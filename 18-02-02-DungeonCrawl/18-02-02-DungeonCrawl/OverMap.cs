using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_02_02_DungeonCrawl
{
    /// <summary>
    /// OverMap is a class that generates a map which defines the dungeon
    /// </summary>

    class OverMap
    {
        //attributes
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Room> Rooms { get; set; }
        public Player MainPlayer { get; set; }

        //constructor
        public OverMap()
        {
            //I was told to always leave a blank constructor
        }

        public OverMap(int roomBudget, Player player)
        {


            //define size of map
            Width = 10;
            Height = 10;
            MainPlayer = player;
            Random rand = new Random();
            int roomX = rand.Next(2, Width - 1);
            int roomY = rand.Next(2, Height - 1);

            //add a new room to the list of rooms
            Rooms = new List<Room>();
            Rooms.Add(new Room(roomX, roomY, this));


            while (roomBudget >= 1)  //as long as there are rooms remaining (first room counts against budget)
            {
                bool noMoreRooms = true;
                for (int i = Rooms.Count - 1; i >= 0; i--)
                {


                    if (!Rooms[i].IsBuilt)  //if it's not built yet
                    {
                        //this is the location of the room
                        roomX = Rooms[i].X;
                        roomY = Rooms[i].Y;

                        //create rooms adjacent to each door, if there's space on the map
                        if (Rooms[i].DoorNorth
                            && Rooms[i].Y > 1)
                        {
                            Room checkRoom = new Room(roomX, roomY - 1, this);
                            int index = Rooms.FindIndex(f => f.ID == checkRoom.ID);
                            if (index < 0)
                            {
                                Room north = new Room(roomX, roomY - 1, this);
                                north.DoorSouth = true;
                                Rooms.Add(north);
                                roomBudget--;
                                noMoreRooms = false;
                            }

                        }
                        //see above. Similar code, consider refactoring if deadline permits
                        if (Rooms[i].DoorSouth
                            && Rooms[i].Y < Height - 1)
                        {
                            Room checkRoom = new Room(roomX, roomY + 1, this);
                            int index = Rooms.FindIndex(f => f.ID == checkRoom.ID);
                            if (index < 0)
                            {
                                Room south = new Room(roomX, roomY + 1, this);
                                south.DoorNorth = true;
                                Rooms.Add(south);
                                roomBudget--;
                                noMoreRooms = false;
                            }
                        }
                        //see above. Similar code, consider refactoring if deadline permits
                        if (Rooms[i].DoorWest
                            && Rooms[i].X > 1)
                        {
                            Room checkRoom = new Room(roomX - 1, roomY, this);
                            int index = Rooms.FindIndex(f => f.ID == checkRoom.ID);
                            if (index < 0)
                            {
                                Room west = new Room(roomX - 1, roomY, this);
                                west.DoorEast = true;
                                Rooms.Add(west);
                                roomBudget--;
                                noMoreRooms = false;
                            }

                        }
                        //see above. Similar code, consider refactoring if deadline permits
                        if (Rooms[i].DoorEast
                            && Rooms[i].X < Width - 1)
                        {
                            Room checkRoom = new Room(roomX + 1, roomY, this);
                            int index = Rooms.FindIndex(f => f.ID == checkRoom.ID);
                            if (index < 0)
                            {
                                Room east = new Room(roomX + 1, roomY, this);
                                east.DoorWest = true;
                                Rooms.Add(east);
                                roomBudget--;
                                noMoreRooms = false;
                            }

                        }
                        //declare room to be built, decrement room budget
                        Rooms[i].IsBuilt = true;
                    }
                }
                if (noMoreRooms)
                {
                    break;
                }
            }

            //Finished creating map, must now determine starting/ending rooms
            int roomFirst = rand.Next(0, Rooms.Count);
            int roomLast = rand.Next(0, Rooms.Count);
            while (roomLast == roomFirst) //ensure these rooms don't match
            {
                roomLast = rand.Next(0, Rooms.Count);
            }
            Rooms[roomFirst].StartRoom = true;
            Rooms[roomLast].FinishRoom = true;
            

            

            //determine tilemaps for each room, invalidate extra doors
            foreach (Room rm in Rooms)
            {
                rm.DoorNorth = false;
                rm.DoorSouth = false;
                rm.DoorWest = false;
                rm.DoorEast = false;
                foreach (Room rmchk in Rooms)
                {
                    if (rmchk.X == rm.X && rmchk.Y == rm.Y - 1)
                    {
                        rm.DoorNorth = true;
                    }
                    else if (rmchk.X == rm.X && rmchk.Y == rm.Y + 1)
                    {
                        rm.DoorSouth = true;
                    }
                    else if (rmchk.X == rm.X - 1 && rmchk.Y == rm.Y)
                    {
                        rm.DoorWest = true;
                    }
                    else if (rmchk.X == rm.X + 1 && rmchk.Y == rm.Y)
                    {
                        rm.DoorEast = true;
                    }
                }
                rm.PopulateTiles();  
            }
        



        }
    }
}
