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
namespace Car
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int x = 10;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen pen = new Pen(Color.RoyalBlue);
            e.Graphics.FillRectangle(pen.Brush, x, 10, 50, 20);
            e.Graphics.FillRectangle(pen.Brush, x, 30, 100, 20);
            e.Graphics.FillEllipse(pen.Brush, x, 35, 30, 30);
            e.Graphics.FillEllipse(pen.Brush, x+65, 35, 30, 30);
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 10;
            Refresh();
            
        }
    }
}
