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

        private void Form1_Load(object sender, EventArgs e)
        {
            OverMap map = new OverMap(10);
            
            foreach(List<Tile> row in map.Rooms[0].RowList)
            {
                foreach (Tile tile in row)
                {
                    string tilename;
                    switch (tile.Type)
                    {
                        case MyEnums.TileCollisions.Wall:
                            tilename = "Wall";
                            break;
                        case MyEnums.TileCollisions.Empty:
                            tilename = "Empty";
                            break;
                        case MyEnums.TileCollisions.Obstacle:
                            tilename = "Obstacle";
                            break;
                        case MyEnums.TileCollisions.Pit:
                            tilename = "Pit";
                            break;
                        default:
                            tilename = "SOMETHING WENT WRONG";
                            break;
                    }
                    MessageBox.Show(tilename + "\nX:" + tile.X + "\nY:" + tile.Y);
                }
            }
        }
    }
}
