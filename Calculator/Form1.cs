using System;
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

        private void button1_Click(object sender, EventArgs e) => PerformOperation(OperationType.Add);
        private void button2_Click(object sender, EventArgs e) => PerformOperation(OperationType.Subtract);
        private void button3_Click(object sender, EventArgs e) => PerformOperation(OperationType.Multiply);
        private void button4_Click(object sender, EventArgs e) => PerformOperation(OperationType.Divide);
        private void button5_Click(object sender, EventArgs e) => ClearFields();

        private void PerformOperation(OperationType operation)
        {
            try
            {
                // Parse inputs once to avoid redundancy
                double num1 = double.Parse(textBox1.Text);
                double num2 = double.Parse(textBox2.Text);

                // Initialize the calculator if it's null
                if (calculator == null)
                {
                    calculator = new Calculator(num1, num2);
                }

                // Perform the operation based on the selected button
                double result;
                switch (operation)
                {
                    case OperationType.Add:
                        result = calculator.Add();
                        break;
                    case OperationType.Subtract:
                        result = calculator.Subtract();
                        break;
                    case OperationType.Multiply:
                        result = calculator.Multiply();
                        break;
                    case OperationType.Divide:
                        result = calculator.Divide();
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operation");
                }

                // Display the result
                LBLHasil.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Please enter valid numbers.");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Division by zero is not allowed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ClearFields()
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

        public double Add() => num1 + num2;
        public double Subtract() => num1 - num2;
        public double Multiply() => num1 * num2;

        public double Divide()
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed");
            }
            return num1 / num2;
        }
    }

    // Enum to define operation types for readability
    public enum OperationType
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
}
