using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace starMove
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x = 10;
        int y = 100;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Point[] tr1 = new Point[3]
            {
                new Point(x, y),
                new Point(x+50, y-50),
                new Point(x+100, y)
            };
            Point[] tr2 = new Point[3]
            {
                new Point(x, y-35),
                new Point(x+50, y+15),
                new Point(x+100, y-35)
            };
            e.Graphics.FillPolygon(new Pen(Color.Red).Brush, tr1);
            e.Graphics.FillPolygon(new Pen(Color.Red).Brush, tr2);
            //timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 5;
            Refresh();          
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "D")
            {
                x += 5;
                Refresh();
            }
            if (e.KeyCode.ToString() == "A")
            {
                x -= 5;
                Refresh();
            }
        }
    }
}
