using System;
using Microsoft.Maui.Controls;

namespace CalculadoraMAUI
{
    public partial class MainPage : ContentPage
    {
        private string _currentInput = "";
        private double _firstNumber = 0;
        private string _activeOperator = "";
        private bool _isOperatorClicked = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnNumberClicked(object? sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            if (_isOperatorClicked || resultLabel.Text == "0")
            {
                resultLabel.Text = "";
                _isOperatorClicked = false;
            }

            resultLabel.Text += button.Text;
            _currentInput = resultLabel.Text;
        }

        private void OnOperatorClicked(object? sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            if (double.TryParse(resultLabel.Text, out double number))
            {
                _firstNumber = number;
                _activeOperator = button.Text;
                _isOperatorClicked = true;
            }
        }

        private void OnClearClicked(object? sender, EventArgs e)
        {
            resultLabel.Text = "0";
            _currentInput = "";
            _firstNumber = 0;
            _activeOperator = "";
            _isOperatorClicked = false;
        }

        private void OnCalculateClicked(object? sender, EventArgs e)
        {
            if (double.TryParse(resultLabel.Text, out double secondNumber))
            {
                double result = 0;

                switch (_activeOperator)
                {
                    case "+":
                        result = _firstNumber + secondNumber;
                        break;
                    case "-":
                        result = _firstNumber - secondNumber;
                        break;
                    case "×":
                        result = _firstNumber * secondNumber;
                        break;
                    case "÷":
                        if (secondNumber != 0)
                        {
                            result = _firstNumber / secondNumber;
                        }
                        else
                        {
                            DisplayAlert("Error", "No se puede dividir por cero, no sea bestia", "OK");
                            OnClearClicked(sender, e);
                            return;
                        }
                        break;
                }

                resultLabel.Text = result.ToString();
                _currentInput = result.ToString();
                _isOperatorClicked = true;
            }
        }
    }
}