﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
        public int Height { get; set; }
        public int Width { get; set; }
        public int TileMapIndex { get; set; }
        public string TileMap { get; set; }
        public List<List<Tile>> RowList { get; set; }
        public bool IsBuilt { get; set; }
        public bool DoorNorth { get; set; }
        public bool DoorEast { get; set; }
        public bool DoorSouth { get; set; }
        public bool DoorWest { get; set; }
        public bool StartRoom { get; set; }
        public bool FinishRoom { get; set; }

        //constructor
        public Room()
        {
            //blank constructor
        }


        public Room(int x, int y)
        {

            IsBuilt = false;
            Height = 11;
            Width = 11;
            //value input is room's position on OverMap
            X = x;
            Y = y;
            ID = X.ToString() + Y.ToString();

            //Determine room layout
            Random rand = new Random();
            TileMapIndex = rand.Next(0, 10);

            //Determine door position
            DoorNorth = false;
            DoorSouth = false;
            DoorEast = false;
            DoorWest = false;
            
            //TODO: This method is a little too generous with the doors, consider tweaking some values
            //rolling a percentile might not be a bad idea
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

        public void PopulateTiles()
        {
            //If there is no tilemap, get one
            if (TileMap == null)
            {
                TileMap = Tilemaps.PopulateIDs(0);
            }

            //populate each tile, according to tilemap
            int characterCount = 0;
            List<Tile> row = new List<Tile>();
            RowList = new List<List<Tile>>();
            foreach (var c in TileMap)  //iterate through tilemap
            {
                if (characterCount % 11 == 0    //determine if a new row is needed
                    && characterCount != 0)
                {
                    RowList.Add(row);
                    row = new List<Tile>();
                }

                //determine which tileStyle to use based on character in tilemap
                MyEnums.TileCollisions tileStyle;
                switch (c)
                {
                    case 'W':
                        tileStyle = MyEnums.TileCollisions.Wall;
                        break;
                    case 'P':
                        tileStyle = MyEnums.TileCollisions.Pit;
                        break;
                    case 'O':
                        tileStyle = MyEnums.TileCollisions.Obstacle;
                        break;
                    case 'E':
                    default:
                        tileStyle = MyEnums.TileCollisions.Empty;
                        break;
                }
                //create the new tile and add it to the row
                Tile tile = new Tile(tileStyle);
                tile.X = tile.Width * (characterCount % 11);
                tile.Y = tile.Height * (characterCount / 11);
                tile.Origin = new Point(tile.X, tile.Y);
                row.Add(tile);
                characterCount++;
                
                if (characterCount >= TileMap.Length) //make sure to add the last row to the collection
                {
                    RowList.Add(row);
                }
            }



        }

        

        
    }
}
