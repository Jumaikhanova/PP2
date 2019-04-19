using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Board
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        Random random = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point locationOfZero = label1.Location;
            locationOfZero.Y += 5;
            label1.Location = locationOfZero;
            if ((label1.Location.X>=button1.Location.X && (label1.Location.X+label1.Width) <= (button1.Location.X+button1.Width)) && (label1.Location.Y + label1.Height) >= button1.Location.Y)
            {
                int x = random.Next(0, this.Width);
                label1.Location = new Point(x, 0);
            }
            if((label1.Location.Y+label1.Height) > this.Height)
            {
                int x = random.Next(0, this.Width);
                label1.Location = new Point(x, 0);
            }
        }
        
    }
}
