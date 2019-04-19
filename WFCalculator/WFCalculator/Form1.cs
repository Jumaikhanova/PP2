using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFCalculator
{
    public partial class Form1 : Form
    {
        Calculator calculator;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calculator = new Calculator(new ChangeTextDelegate(ChangeText));
            int x = textBox1.Location.X;
            int y = textBox1.Location.Y + textBox1.Height + 10;
            int k = 0;
            int l = 30;
            int sz1 = 55;
            int sz2 = 58;//размер кнопки
            int d = 10;//расстояние между кнопками
            Button btn;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    k++;
                    btn = new Button();
                    if ((k > 8 && k < 12) || (k > 12 && k < 16) || (k > 16 && k < 20) || (k == 22))
                        btn.BackColor = Color.White;
                    btn.Font = new Font("Microsoft Sans Serif", 14F);
                    btn.Text = BtnText(k);
                    btn.Size = new Size(sz2, sz1);
                    btn.Location = new Point(j * sz2 + x + d, i * sz1 + y + d + 40);
                    btn.Click += Btn_Clicked;
                    Controls.Add(btn);//Controls-ссылка на форму
                }
            }
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    l++;
                    btn = new Button();
                    btn.Font = new Font("Microsoft Sans Serif", 10F);
                    btn.Text = BtnText(l);
                    btn.Size = new Size(50, 37);
                    btn.Location = new Point(j * 50 + x, i * 37 + y + d);
                    btn.Click += Btn_Clicked;
                    Controls.Add(btn);//Controls-ссылка на форму
                }
            }
        }
        public string BtnText(int k)
        {
            if (k == 31)
                return "MC";
            if (k == 32)
                return "MR";
            if (k == 33)
                return "M+";
            if (k == 34)
                return "M-";
            if (k == 35)
                return "MS";

            if (k > 8 && k < 12)
                return (k - 2).ToString();
            if (k > 12 && k < 16)
                return (k - 9).ToString();
            if (k > 16 && k < 20)
                return (k - 16).ToString();
            if (k == 23)
                return ",";
            if (k == 21)
                return "±";
            if (k == 22)
                return "0";
            if (k == 1)
                return "%";
            if (k == 2)
                return "√";
            if (k == 3)
                return "x²";
            if (k == 4)
                return "sinx";
            if (k == 5)
                return "CE";
            if (k == 6)
                return "C";
            if (k == 7)
                return "<-";
            if (k == 8)
                return "÷";
            if (k == 12)
                return "×";
            if (k == 20)
                return "+";
            if (k == 24)
                return "=";
            if (k == 16)
                return "-";
            return "";
        }
        public void ChangeText(string text)
        {
            textBox1.Text = text;
        }
        public void Btn_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            calculator.Process(btn.Text);
        }
    }
}
