using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilledCircle
{
    public partial class Form1 : Form
    {
        public int x, y, r = 0;
        Random random = new Random();
        Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int index = random.Next(0, colors.Length - 1);
            Pen pen = new Pen(colors[index], 3);
            e.Graphics.FillEllipse(pen.Brush, x - r, y - r, 2 * r, 2 * r);
            //e.Graphics.DrawEllipse(pen, x - r, y - r, 2 * r, 2 * r);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            r += 7;
            Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.Location.X;
            y = e.Location.Y;
            timer1.Start();
        }
    }
}
