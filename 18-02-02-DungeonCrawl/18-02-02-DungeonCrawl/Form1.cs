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
            OverMap map = new OverMap(6);
            foreach (var room in map.Rooms)
            {
                string coords = "X: " + room.X + "\nY: " + room.Y + "\nID: " + room.ID;
                MessageBox.Show(coords);
            }
        }
    }
}
