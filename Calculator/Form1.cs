using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private Calculator calculator;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(textBox1.Text);
                double num2 = double.Parse(textBox2.Text);
                calculator = new Calculator(num1, num2);
                LBLHasil.Text = calculator.Add().ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Please enter valid numbers.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(textBox1.Text);
                double num2 = double.Parse(textBox2.Text);
                calculator = new Calculator(num1, num2);
                LBLHasil.Text = calculator.Subtract().ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Please enter valid numbers.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(textBox1.Text);
                double num2 = double.Parse(textBox2.Text);
                calculator = new Calculator(num1, num2);
                LBLHasil.Text = calculator.Multiply().ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Please enter valid numbers.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(textBox1.Text);
                double num2 = double.Parse(textBox2.Text);
                calculator = new Calculator(num1, num2);
                LBLHasil.Text = calculator.Divide().ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Please enter valid numbers.");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Division by zero is not allowed.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            LBLHasil.Text = "";
            calculator = null; 
        }
    }

    public class Calculator
    {
        private double num1;
        private double num2;

        public Calculator(double number1, double number2)
        {
            this.num1 = number1;
            this.num2 = number2;
        }

        public double Add()
        {
            return num1 + num2;
        }

        public double Subtract()
        {
            return num1 - num2;
        }

        public double Multiply()
        {
            return num1 * num2;
        }

        public double Divide()
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed");
            }
            return num1 / num2;
        }
    }
}
