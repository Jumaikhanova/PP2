using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RectangleMove
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x = 10;
        int y = 10;
        int dx = 10;
        int dy = 10;
        int width = 50;
        int height = 20;
        Rectangle rectangle;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            rectangle = new Rectangle(x, y, width, height);
            Pen pen = new Pen(Color.RoyalBlue);
            e.Graphics.FillRectangle(pen.Brush, rectangle);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point location = rectangle.Location;
            location.X += dx;
            location.Y += dy;
            if (location.X + rectangle.Width + 20 >= this.Width)
                dx *= -1;
            if (location.X < 0)
                dx *= -1;
            if (location.Y + rectangle.Height + 40 > this.Height)
                dy *= -1;
            if (location.Y < 0)
                dy *= -1;
            rectangle.Location = location;
            x = location.X;
            y = location.Y;
            Refresh();
        }
    }
}
