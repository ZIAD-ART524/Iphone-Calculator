using System;
using System.Windows;
using System.Windows.Controls;

namespace UA1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double firstNumber = 0, secondNumber = 0;
        private string operation = "";
        private bool isResultDisplayed = false;
            public MainWindow()
        {
            InitializeComponent();
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (Display.Text == "0")
            {
                if (button.Content.ToString() == ".")
                {
                    Display.Text = "0";
                }
                else
                {
                    Display.Text = "";
                }
            }

            Display.Text += button.Content.ToString();
        }
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            firstNumber = double.Parse(Display.Text);
            operation = button.Content.ToString();
            Display.Text = "0";
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            firstNumber = 0;
            secondNumber = 0;
            operation = "";
        }
        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Display.Text, out var number))
            {
                Display.Text = (number * 0.01).ToString(); 
            }
        }
        private void ChangeSign_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text != "0" && Display.Text != "Erreur")
            {
                double number;
                if (double.TryParse(Display.Text, out number))
                {
                    Display.Text = (-number).ToString();
                }
            }
        }
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (double.TryParse(Display.Text, out secondNumber))
                {
                    switch (operation)
                    {
                        case "+":
                            Display.Text = (firstNumber + secondNumber).ToString();
                            break;
                        case "-":
                            Display.Text = (firstNumber - secondNumber).ToString();
                            break;
                        case "x":
                            Display.Text = (firstNumber * secondNumber).ToString();
                            break;
                        case "÷":
                            if (secondNumber == 0)
                                Display.Text = "Erreur";
                            else
                                Display.Text = (firstNumber / secondNumber).ToString();
                            break;
                    }
                    isResultDisplayed = true;
                }
            }
            catch (Exception)
            {
                Display.Text = "Erreur";
            }
        }

    }
}

