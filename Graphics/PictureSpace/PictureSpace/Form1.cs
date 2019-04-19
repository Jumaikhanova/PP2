using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace PictureSpace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Point[] points = new Point[6]

        {
            new Point(180, 80),
            new Point(220, 60),
            new Point(260, 80),
            new Point(260, 110),
            new Point(220, 130),
            new Point(180, 110)
        };
        Point[] TrPoints = new Point[7]
        {
            new Point(210, 90),
            new Point(220, 80),
            new Point(230, 90),
            new Point(225, 90),
            new Point(225, 110),
            new Point(215, 110),
            new Point(215, 90)
        };
        Point[] StPoints1 = new Point[3]
        {
            new Point(60, 100),
            new Point(80, 70),
            new Point(100, 100)
        };
        Point[] StPoints2 = new Point[3]
        {
            new Point(60, 80),
            new Point(100, 80),
            new Point(80, 110)
        };
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Level: 1 Score: 200 Live: ***";
            
                       
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.FillRectangle(new Pen(Color.RoyalBlue).Brush, 0, 0, this.Width, this.Height);
            
            e.Graphics.FillEllipse(new Pen(Color.AliceBlue).Brush, 20, 30, 20, 20);
            
            e.Graphics.FillEllipse(new Pen(Color.AliceBlue).Brush, 20, 220, 20, 20);
            
            e.Graphics.FillEllipse(new Pen(Color.AliceBlue).Brush, 150, 20, 20, 20);
            
            e.Graphics.FillEllipse(new Pen(Color.AliceBlue).Brush, 280, 40, 20, 20);
            
            e.Graphics.FillEllipse(new Pen(Color.AliceBlue).Brush, 420, 70, 20, 20);
            
            e.Graphics.FillEllipse(new Pen(Color.AliceBlue).Brush, 360, 120, 20, 20);
            
            e.Graphics.FillEllipse(new Pen(Color.AliceBlue).Brush, 420, 250, 20, 20);
            
            e.Graphics.FillEllipse(new Pen(Color.AliceBlue).Brush, 150, 200, 20, 20);

            e.Graphics.FillPolygon(new Pen(Color.Yellow).Brush, points);

            e.Graphics.FillPolygon(new Pen(Color.Green).Brush, TrPoints);

            e.Graphics.FillPolygon(new Pen(Color.Red).Brush, StPoints1);
            e.Graphics.FillPolygon(new Pen(Color.Red).Brush, StPoints2);

        }
    }
}
