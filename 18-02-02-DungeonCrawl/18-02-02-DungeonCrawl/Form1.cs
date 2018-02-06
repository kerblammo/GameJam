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

        bool isFormLoaded = false;
        bool paintRoom = false;
        bool paintPlayer = false;
        int currentRoom;
        OverMap map = new OverMap();
        Player player = new Player();

        private void Form1_Load(object sender, EventArgs e)
        {
            isFormLoaded = true;
            map = new OverMap(10);
            currentRoom = 0;
            player.CurrentRoom = map.Rooms[currentRoom];
            paintRoom = true;
            paintPlayer = true;
            
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
                if (paintPlayer)    //it is now time to paint the player
                {
                    e.Graphics.DrawImage(player.Sprite, player.Origin);
                }

            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //player controls
            bool playerMoved = false;
            switch (e.KeyChar.ToString().ToUpper())
            {
                case "W":
                    player.MoveUp();
                    playerMoved = true;
                    break;
                case "S":
                    player.MoveDown();
                    playerMoved = true;
                    break;
                case "A":
                    player.MoveLeft();
                    playerMoved = true;
                    break;
                case "D":
                    player.MoveRight();
                    playerMoved = true;
                    break;
            }
            if (playerMoved)    //if the player moved, repaint it
            {
                Invalidate(player.PaintMaskOld);
                Invalidate(player.PaintMask);
            }
            
        }
    }
}
