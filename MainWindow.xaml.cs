using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += AcButton_Click;

            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;

            equalsButton.Click += EqualsButton_Click;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double newInt;

            if (double.TryParse(resultLabel.Content.ToString(), out newInt))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newInt);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newInt);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newInt);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newInt);
                        break;
                }

                resultLabel.Content = result.ToString();
            }

  
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(),out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }

            if (sender == addButton)
            {
                selectedOperator = SelectedOperator.Addition;
            }
            if (sender == subractButton)
            {
                selectedOperator = SelectedOperator.Subtraction;
            }
            if (sender == multiplyButton)
            {
                selectedOperator = SelectedOperator.Multiplication;
            }
            if (sender == divideButton)
            {
                selectedOperator = SelectedOperator.Division;
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {

            if (resultLabel.Content.ToString().Contains("."))
            {
               //Do nothing
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {

            int selectedValue = 0;

            if (sender == oneButton)
            {
                selectedValue = 1;
            }
            if (sender == twoButton)
            {
                selectedValue = 2;
            }
            if (sender == threeButton)
            {
                selectedValue = 3;
            }
            if (sender == fourButton)
            {
                selectedValue = 4;
            }
            if (sender == fiveButton)
            {
                selectedValue = 5;
            }
            if (sender == sixButton)
            {
                selectedValue = 6;
            }
            if (sender == sevenButton)
            {
                selectedValue = 7;
            }
            if (sender == eightButton)
            {
                selectedValue = 8;
            }
            if (sender == nineButton)
            {
                selectedValue = 9;
            }
   

            if (resultLabel.Content.ToString()=="0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public static class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Divide(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Division by zero is not supported!", "Invalid Operation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return 0;
            }
            return n1 / n2;
        }
    }
}
