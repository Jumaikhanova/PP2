using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bitmap;
        Graphics gBitmap;
        bool mouseclicked, itWasEllipse, itWasRectangle, okPoint;
        public Tool tool;
        public Point prevPoint, curPoint, prevCursorPoint, curCursorPoint;
        Pen pen = new Pen(Color.Black, 3);

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseclicked == true)
            {
                if (tool == Tool.rectangle || tool == Tool.ellipse) 
                {
                    curPoint = e.Location;
                    pictureBox1.Refresh();
                }
                if (tool == Tool.cursor)
                {
                    if (okPoint == true)
                    {                       
                        curCursorPoint = e.Location;
                        pictureBox1.Refresh();
                        prevCursorPoint = curCursorPoint;  
                    }
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (tool == Tool.rectangle)
                DrawRectangle(e.Graphics);
            if (tool == Tool.ellipse)
                DrawEllipse(e.Graphics);
            if (tool == Tool.cursor)
                MovePicture(e.Graphics);
        }

        public enum Tool
        {
            rectangle,
            ellipse, 
            cursor
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseclicked = false;
            if (tool == Tool.rectangle)
            {
                DrawRectangle(gBitmap);
                itWasRectangle = true;
            }
            if (tool == Tool.ellipse)
            {
                DrawEllipse(gBitmap);
                itWasEllipse = true;
            }
            if (tool == Tool.cursor)
            {
                if (itWasRectangle == true)
                    DrawRectangle(gBitmap);
                if (itWasEllipse == true)
                    DrawEllipse(gBitmap);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tool = Tool.rectangle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tool = Tool.ellipse;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gBitmap = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
            mouseclicked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tool = Tool.cursor;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tool == Tool.rectangle || tool == Tool.ellipse) 
            {
                mouseclicked = true;
                prevPoint = e.Location;
                itWasEllipse = false;
                itWasRectangle = false;
            }
            if (tool == Tool.cursor)
            {
                prevCursorPoint = e.Location;
                if (prevCursorPoint.X >= prevPoint.X && prevCursorPoint.X <= curPoint.X && prevCursorPoint.Y >= prevPoint.Y && prevCursorPoint.Y <= curPoint.Y)
                {
                    mouseclicked = true;
                    okPoint = true;
                    if(itWasRectangle==true)
                        gBitmap.DrawRectangle(new Pen(Color.White, 3), prevPoint.X, prevPoint.Y, curPoint.X - prevPoint.X, curPoint.Y - prevPoint.Y);
                    if (itWasEllipse == true)
                        gBitmap.DrawEllipse(new Pen(Color.White, 3), prevPoint.X, prevPoint.Y, curPoint.X - prevPoint.X, curPoint.Y - prevPoint.Y);
                }
            }
        }
        public void DrawRectangle(Graphics g)
        {
            g.DrawRectangle(pen, prevPoint.X, prevPoint.Y, curPoint.X - prevPoint.X, curPoint.Y - prevPoint.Y);
        }
        public void DrawEllipse(Graphics g)
        {
            g.DrawEllipse(pen, prevPoint.X, prevPoint.Y, curPoint.X - prevPoint.X, curPoint.Y - prevPoint.Y);
        }
        int c = 0, k = 0;
        public void MovePicture(Graphics g)
        {
            c = curCursorPoint.X - prevCursorPoint.X;
            k = curCursorPoint.Y - prevCursorPoint.Y;
            prevPoint.X = prevPoint.X + c;
            prevPoint.Y = prevPoint.Y + k;
            curPoint.X = curPoint.X + c;
            curPoint.Y = curPoint.Y + k;

            if (itWasRectangle == true)
                g.DrawRectangle(pen, prevPoint.X, prevPoint.Y, curPoint.X - prevPoint.X, curPoint.Y - prevPoint.Y);

            if (itWasEllipse == true)
                g.DrawEllipse(pen, prevPoint.X, prevPoint.Y, curPoint.X - prevPoint.X, curPoint.Y - prevPoint.Y);

        }
    }
}
