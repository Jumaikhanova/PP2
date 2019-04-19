using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintRectangle
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics gBitmap;
        bool mouseClicked = false;
        public Point prevPoint, curPoint;
        public Tool tool;
        public enum Tool
        {
            pen,
            rectangle
        }
        Pen pen = new Pen(Color.Black, 3);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gBitmap = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
            mouseClicked = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClicked = false;
            if (tool == Tool.rectangle)
            {
                DrawRectangle(gBitmap);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseClicked == true)
            {
                if (tool == Tool.pen)
                {
                    curPoint = e.Location;
                    gBitmap.DrawLine(pen, prevPoint, curPoint);
                    prevPoint = curPoint;
                }
                else if (tool == Tool.rectangle) 
                {
                    curPoint = e.Location;
                    //e.Graphics.DrawRectangle(pen, prevPoint.X, prevPoint.Y, curPoint.X - prevPoint.X, curPoint.Y - prevPoint.Y);
                    //отрисовка всех промежуточных прямоугольников (на битмапе)
                }
                pictureBox1.Refresh();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tool = Tool.pen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tool = Tool.rectangle;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawRectangle(e.Graphics);
        }
        public void DrawRectangle(Graphics g)
        {
            int minX = Math.Min(prevPoint.X, curPoint.X);
            int maxX = Math.Max(prevPoint.X, curPoint.X);
            int minY = Math.Min(prevPoint.Y, curPoint.Y);
            int maxY = Math.Max(prevPoint.Y, curPoint.Y);
            g.DrawRectangle(pen, minX, minY, maxX - minX, maxY - minY);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClicked = true;
            prevPoint = e.Location;
        }
    }
}
