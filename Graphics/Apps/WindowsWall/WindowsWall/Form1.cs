using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsWall
{
    public partial class Form1 : Form
    {
        public int dx = 10, dy = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point location = button1.Location;
            location.X += dx;
            location.Y += dy;
            if (location.X + button1.Width + 20 >= this.Width)
                dx *= -1;            
            if (location.X < 0) 
                dx *= -1;
            if (location.Y + button1.Height + 40 > this.Height)
                dy *= -1;
            if (location.Y < 0)
                dy *= -1;
            button1.Location = location;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
