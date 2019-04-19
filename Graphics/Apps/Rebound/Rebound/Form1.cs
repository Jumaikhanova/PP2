using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rebound
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int dx = 10;
        int dy = 10;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point locationOfSphere = label1.Location;

            locationOfSphere.X += dx;
            locationOfSphere.Y += dy;

            if (locationOfSphere.X + label1.Width + 30 > this.Width)
                dx *= -1;

            if (locationOfSphere.X < 0)
                dx *= -1;

            if (locationOfSphere.Y + label1.Height + 50 > this.Height)
                dy *= -1;

            if (locationOfSphere.Y < 0)
                dy *= -1;

            if ((label1.Location.X > button1.Location.X && (label1.Location.X + label1.Width) < (button1.Location.X + button1.Width)) && (label1.Location.Y + label1.Height) > button1.Location.Y)

                dy *= -1;
            

            label1.Location = locationOfSphere;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            Point location = button1.Location;
            string pressed_btn = e.KeyCode.ToString();
            if (pressed_btn == "A")
            {
                location.X -= 10;
            }
            else if (pressed_btn == "D")
            {
                location.X += 10;
            }
            button1.Location = location;
        }
    }
}
