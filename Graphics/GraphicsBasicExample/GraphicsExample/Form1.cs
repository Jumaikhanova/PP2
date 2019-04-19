using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.Red, 4);//цвет, толщина
            //graphics.DrawLine(pen, 10, 10, 200, 200);//начальная точка, конечная точка
            //graphics.DrawRectangle(pen, 10, 10, 200, 100);//координаты левой верхней точки, длина и высота
            //graphics.DrawEllipse(pen, 10, 10, 200, 100);//фактически прямоугольник, в который вписан эллипс
            HatchBrush hBrush = new HatchBrush(HatchStyle.Cross, Color.Red, Color.FromArgb(255, 128, 255, 255));
            graphics.FillEllipse(hBrush, 10, 10, 200, 100);
        }
    }
}
