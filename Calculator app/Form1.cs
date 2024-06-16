using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_app
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            if (buttonText == "C")
            {
               
                Clear();
            }
            else if (buttonText == "=")
            {
              
                Calculate();
                
            }
            else if (IsOperator(buttonText))
            {
                SetOperation(buttonText);
            }
            else
            {
                AppendNumber(buttonText);
            }
        }

        private void AppendNumber(string number)
        {
            if (_isNewNumber)
            {
                _currentNumber = number;
                _isNewNumber = false;
            }
            else
            {
                _currentNumber += number;
            }

            textBox1.Text = _currentNumber;
        }

        private void SetOperation(string operation)
        {
            _previousNumber = _currentNumber;
            _operation = operation;
            _isNewNumber = true;
        }
        private void Calculate()

        {
            
            double result = 0;


            switch (_operation)

            {

                case "+":

                    result = double.Parse(_previousNumber) + double.Parse(_currentNumber);

                    break;


                case "-":

                    result = double.Parse(_previousNumber) - double.Parse(_currentNumber);

                    break;


                case "*":

                    result = double.Parse(_previousNumber) * double.Parse(_currentNumber);

                    break;


                case "/":

                    result = double.Parse(_previousNumber) / double.Parse(_currentNumber);

                    break;

            }

            _currentNumber2 = _currentNumber;
            _currentNumber = result.ToString();

            textBox1.Text = _currentNumber; // update textBox1 with the result

            listBox1.Items.Add(_previousNumber + " " + _operation + " " + _currentNumber2 + " = " + result);

            _isNewNumber = true;

        }

        private void Clear()
        {
            _currentNumber2 = "";
            _currentNumber = "";
            _previousNumber = "";
            _operation = "";
            _isNewNumber = true;
            textBox1.Text = "";
            listBox1.Items.Clear();
        }

        private bool IsOperator(string buttonText)
        {
            return buttonText == "+" || buttonText == "-" || buttonText == "*" || buttonText == "/";
        }

        // You need to declare the following fields:
        private string _currentNumber;
        private string _currentNumber2;
        private string _previousNumber;
        private string _operation;
        private bool _isNewNumber;

        
    }
}