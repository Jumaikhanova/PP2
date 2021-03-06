﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsExample2
{
    public partial class Form1 : Form
    {
        bool mouseClicked = false;
        Bitmap bitmap;//виртуальный image
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);//создаем графику от image(bitmap), т к мы рисуем на bitmap
            pictureBox1.Image = bitmap;//image(picture) для pictureBox является bitmap
        }
        
        public int x, y, r = 0;
        Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Gold, Color.Gray };
        Random random = new Random();

        private void timer1_Tick(object sender, EventArgs e)
        {
            r += 5;
            int index = random.Next(0, colors.Length - 1);
            Pen pen = new Pen(colors[index], 3);
            g.DrawEllipse(pen, x - r, y - r, 2 * r, 2 * r);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!mouseClicked)
            {
                x = e.Location.X;
                y = e.Location.Y;
                r = 1;
                timer1.Start();
                mouseClicked = true;
            }
            else
            {
                mouseClicked = false;
                timer1.Stop();
            }
        }        
    }
}
