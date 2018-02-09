using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18_02_02_DungeonCrawl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool displayFloor = false;
        bool isFormLoaded = false;
        bool paintRoom = false;
        bool repaintRoom = false;
        bool paintPlayer = false;
        int currentRoom;
        Player player = new Player();
        OverMap map = new OverMap();
        int floor = 0;
        

        private void Form1_Load(object sender, EventArgs e)
        {

            ChangeFloor();
            MessageBox.Show("Use WASD to move. Move into an enemy to destroy them\nWatch out, they can do the same to you!\n\nHow deep can you go?", "Instructions");
            
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (isFormLoaded)   //nothing happens until form is loaded
            {
                
                if (paintRoom)  //it is now time to paint the room
                {
                    //draw each tile in the room
                    foreach (List<Tile> row in map.Rooms[currentRoom].RowList)
                    {
                        foreach (Tile tile in row)
                        {
                            e.Graphics.DrawImage(tile.Sprite, tile.Origin);
                        }
                    }
                }
                
                if (repaintRoom)
                {
                    repaintRoom = false; //happens only once
                    
                    foreach(List<Tile> row in map.Rooms[currentRoom].RowList)
                    {
                        foreach(Tile tile in row)
                        {
                            e.Graphics.DrawImage(tile.Sprite, tile.Origin);
                            
                        }
                    }
                    if (displayFloor && map.Rooms[currentRoom].StartRoom)
                    {
                        displayFloor = false;
                        MessageBox.Show("Floor: " + floor);
                    }

                }
                if (paintPlayer)    //it is now time to paint the player
                {
                    e.Graphics.DrawImage(player.Sprite, player.Origin);
                }
                foreach (Monster monster in map.Rooms[currentRoom].Monsters)
                {
                    e.Graphics.DrawImage(monster.Sprite, monster.Origin);
                }

            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //player controls
            bool playerMoved = false;
            bool roomChanged = false;
            MyEnums.Cardinal direction = 0;
            switch (e.KeyChar.ToString().ToUpper())
            {
                case "W":
                    if (player.Y <= 0)
                    {
                        roomChanged = true;
                        direction = MyEnums.Cardinal.Up;
                    }
                    player.MoveUp();
                    playerMoved = true;
                    
                    break;
                case "S":
                    if (player.Y >= 640)
                    {
                        roomChanged = true;
                        direction = MyEnums.Cardinal.Down;
                    }
                    player.MoveDown();
                    playerMoved = true;
                    break;
                case "A":
                    if (player.X <= 0)
                    {
                        roomChanged = true;
                        direction = MyEnums.Cardinal.Left;
                    }
                    player.MoveLeft();
                    playerMoved = true;
                    break;
                case "D":
                    if (player.X >= 640)
                    {
                        roomChanged = true;
                        direction = MyEnums.Cardinal.Right;
                    }
                    player.MoveRight();
                    playerMoved = true;
                    break;
            }
            if (playerMoved)    //if the player moved, repaint it
            {
                //check if player has moved to another room, then move them
                if (roomChanged)
                {
                    ChangeRoom(direction);
                    player.Origin = new Point(player.X, player.Y);


                }
                else if (map.Rooms[currentRoom].FinishRoom
                        && player.X == 320 && player.Y == 320)
                {
                    ChangeFloor();
                }

                
                else //check if monsters must move
                {
                    
                    foreach (Monster monster in map.Rooms[currentRoom].Monsters)
                    {
                        
                        Invalidate(monster.PaintMask);
                        if (monster.X == player.X && monster.Y == player.Y)
                        {

                        }
                        monster.DetermineDirection();
                        Invalidate(monster.PaintMask);
                        if (player.Health <= 0)
                        {
                            break;
                        }
                    }
                }

                
                Invalidate(player.PaintMaskOld);
                Invalidate(player.PaintMask);
                if (player.KillMonster)
                {
                    Invalidate(player.PaintMaskKill);
                    player.KillMonster = false;
                }
                if (player.Health <= 0)
                {
                    lblHealth.Text = "x " + player.Health;
                    MessageBox.Show("You have run out of hitpoints and died! \nYou have reached floor " + floor + "\nYou will now be returned to a new dungeon", "GAME OVER");
                    player = new Player();
                    floor = 0;
                    ChangeFloor();
                }
                lblHealth.Text = "x " + player.Health;
                
                
            }
            
        }

        private void ChangeRoom(MyEnums.Cardinal dir)
        {
            int x = map.Rooms[currentRoom].X;
            int y = map.Rooms[currentRoom].Y;
            switch (dir)
            {
                case MyEnums.Cardinal.Up:
                    y--;
                    player.Y = 640;
                    break;
                case MyEnums.Cardinal.Down:
                    y++;
                    player.Y = 0;
                    break;
                case MyEnums.Cardinal.Left:
                    x--;
                    player.X = 640;
                    break;
                case MyEnums.Cardinal.Right:
                    x++;
                    player.X = 0;
                    break;
            }
            //check each room and see if it's the correct one to transition to
            foreach (Room rm in map.Rooms)
            {
                if (rm.X == x && rm.Y == y)
                {
                    currentRoom = map.Rooms.IndexOf(rm);
                    repaintRoom = true;
                    player.Moved();
                    Invalidate();
                    break;
                }
            }
            player.CurrentRoom = map.Rooms[currentRoom];
        }

        public void ChangeFloor()
        {
            floor++;
            if (floor > 1)
            {
                displayFloor = true;
            }
            isFormLoaded = true;
            map = new OverMap(20, player);
            //determine starting room
            foreach (Room room in map.Rooms)
            {
                if (room.StartRoom)
                {
                    currentRoom = map.Rooms.IndexOf(room);
                    Invalidate();
                    break;
                }
            }
            player.CurrentRoom = map.Rooms[currentRoom];
            paintRoom = true;
            repaintRoom = true;
            paintPlayer = true;
        }
    }
}
