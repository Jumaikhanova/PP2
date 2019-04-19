using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rotation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.RoyalBlue);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.FillEllipse(pen.Brush, (int)a, (int)b, 50, 50);
            
        }
        public double a=200, b=150, x=90;
        private void timer1_Tick(object sender, EventArgs e)
        {
            a += (5 * Math.Cos(x));
            b += (5 * Math.Sin(x));
            x += 0.1;
            Refresh();
        }
    }
}
