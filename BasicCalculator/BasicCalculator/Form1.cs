using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void numbers_clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            textBox1.Text += btn.Text;
        }
        public double a, b, c;
        public string operation, complex_operation;

        private void operation_clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            a = double.Parse(textBox1.Text);
            operation = btn.Text;
            textBox1.Text = "";
        }
        private void complex_operation_clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "%")
            {
                b = double.Parse(textBox1.Text);
                complex_operation = btn.Text;
                calculate_complex();
            }
            else
            {
                a = double.Parse(textBox1.Text);
                complex_operation = btn.Text;
                calculate_complex();
            }
        }
        public void equalBtn_clicked(object sender, EventArgs e)
        {
            b = double.Parse(textBox1.Text);
            calculate();
            textBox1.Text = c.ToString();
        }
        public void calculate_complex()
        {
            switch (complex_operation)
            {
                case "x²":
                    c = a * a;
                    break;
                case "√":
                    c = Math.Sqrt(a);
                    break;
                case "cosx":
                    c = Math.Cos(a*Math.PI/180);
                    break;
                case "%":
                    c = a * b / 100;
                    break;
            }
            textBox1.Text = c.ToString();
        }
        public void calculate()
        {
            
            switch (operation)
            {
                case "+":
                    c = a + b;
                    break;
                case "-":
                    c = a - b;
                    break;
                case "×":
                    c = a * b;
                    break;
                case "÷":
                    c = a / b;
                    break;
            }
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = (double.Parse(textBox1.Text) * -1).ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
        }
        string number_in_memory;
        private void memory_operations(object sender, EventArgs e)
        {            
            Button btn = sender as Button;
            string memory_operation = btn.Text;
            if (memory_operation == "MS")
                number_in_memory = textBox1.Text;
            if (memory_operation == "MR")
                textBox1.Text = number_in_memory;
            if (memory_operation == "M+")
                number_in_memory = (double.Parse(number_in_memory) + double.Parse(textBox1.Text)).ToString();
            if (memory_operation == "M-")
                number_in_memory = (double.Parse(number_in_memory) - double.Parse(textBox1.Text)).ToString();
            if (memory_operation == "MC")
                number_in_memory = "0";
        }

        int k = 0;
        private void separator_clicked(object sender, EventArgs e)
        {
           for(int i=0; i<textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] == ',')
                {
                    k++;
                }
            }
            if (k == 0)
                textBox1.Text += ",";
        }

    }
}
