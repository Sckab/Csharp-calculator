using System.Windows;
using System.Windows.Controls;
using Calculator;
using Globals;
using System.Globalization;
using UiHelper;

namespace OperationsBtns;

public class Operation_Class
{
    private MainWindow _window;

    public Operation_Class(MainWindow window)
    {
        _window = window;
    }

    public void Addition(object sender, RoutedEventArgs e)
    {
        if (_window.Display != null && _window.Display.Content != null &&
            !string.IsNullOrEmpty(_window.Display.Content.ToString()))
        {
            if (GlobalVariables.IsSecondNumber == false)
            {
                _window.Display.Content += "+";
                GlobalVariables.Operation = '+';
                GlobalVariables.IsSecondNumber = true;
            }
            else if (GlobalVariables.IsSecondNumber == true)
            {

            }
        }
    }

    public void Subtraction(object sender, RoutedEventArgs e)
    {
        var disp = _window.Display?.Content?.ToString() ?? "";

        if (!GlobalVariables.IsSecondNumber)
        {
            if (string.IsNullOrEmpty(GlobalVariables.FirstNumber) && !GlobalVariables.IsFirstNegative)
            {
                _window.Display.Content += "-";
                GlobalVariables.FirstNumber += "-";
                GlobalVariables.IsFirstNegative = true;
            }
            else if (!string.IsNullOrEmpty(GlobalVariables.FirstNumber))
            {
                _window.Display.Content += "-";
                GlobalVariables.Operation = '-';
                GlobalVariables.IsSecondNumber = true;
            }
        }
        else if (GlobalVariables.IsSecondNumber)
        {
            if (GlobalVariables.Operation == '+')
                GlobalVariables.Operation = '-';
            else if (GlobalVariables.Operation == '-')
                GlobalVariables.Operation = '+';

            string text = GlobalVariables.FirstNumber + GlobalVariables.Operation + GlobalVariables.SecondNumber.Replace('.', ',');
            _window.Display.Content = text;
        }
    }



    public void Moltiplication(object sender, RoutedEventArgs e)
    {
        if (_window.Display != null && _window.Display.Content != null &&
            !string.IsNullOrEmpty(_window.Display.Content.ToString()))
        {
            if (GlobalVariables.IsSecondNumber == false)
            {
                _window.Display.Content += "×";
                GlobalVariables.Operation = '*';
                GlobalVariables.IsSecondNumber = true;
            }
            else if (GlobalVariables.IsSecondNumber == true)
            {

            }
        }
    }

    public void Division(object sender, RoutedEventArgs e)
    {
        if (_window.Display != null && _window.Display.Content != null &&
            !string.IsNullOrEmpty(_window.Display.Content.ToString()))
        {
            if (GlobalVariables.IsSecondNumber == false)
            {
                _window.Display.Content += "÷";
                GlobalVariables.Operation = '/';
                GlobalVariables.IsSecondNumber = true;
            }
            else if (GlobalVariables.IsSecondNumber == true)
            {

            }
        }
    }

    public void SquareRoot(object sender, RoutedEventArgs e)
    {
        if (_window.Display != null && _window.Display.Content != null &&
            !string.IsNullOrEmpty(_window.Display.Content.ToString()))
        {
            if (GlobalVariables.IsSecondNumber == false)
            {
                if (!double.TryParse(GlobalVariables.FirstNumber, out double FirstNumberDouble))
                {
                    _window.Display.Content = "Invalid input";
                    GlobalVariables.IsError = true;
                    return;
                }

                double ResultSqr;

                ResultSqr = Math.Sqrt(FirstNumberDouble);
                string ResultStringSqr = ResultSqr.ToString("0.###");

                _window.Display.Content = ResultStringSqr;
                GlobalVariables.IsSecondNumber = false;
                GlobalVariables.FirstNumber = ResultStringSqr;
                GlobalVariables.SecondNumber = "";
                GlobalVariables.Operation = '\0';
            }
            else if (GlobalVariables.IsSecondNumber == true)
            {

            }
        }
    }

    public void Equals(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(GlobalVariables.FirstNumber) || GlobalVariables.Operation == '\0')
            return;

        if (string.IsNullOrEmpty(GlobalVariables.SecondNumber))
        {
            _window.Display.Content = GlobalVariables.FirstNumber.Replace('.', ',');
            return;
        }

        if (!double.TryParse(GlobalVariables.FirstNumber, NumberStyles.Float, CultureInfo.InvariantCulture, out double first) ||
            !double.TryParse(GlobalVariables.SecondNumber, NumberStyles.Float, CultureInfo.InvariantCulture, out double second))
        {
            _window.Display.Content = "Invalid input";
            GlobalVariables.IsError = true;
            return;
        }

        double result = 0;
        switch (GlobalVariables.Operation)
        {
            case '+':
                result = first + second;
                break;

            case '-':
                result = first - second;
                break;

            case '*':
                result = first * second;
                break;

            case '/':
                if (Math.Abs(second) < double.Epsilon)
                {
                    _window.Display.Content = "Cannot divide by 0";
                    GlobalVariables.IsError = true;
                    return;
                }
                result = first / second;
                break;

            default:
                return;
        }

        string resultInternal = result.ToString(CultureInfo.InvariantCulture);
        UiHelper_Class.SetDisplayAndVariable(_window, resultInternal, false);

        GlobalVariables.IsSecondNumber = false;
        GlobalVariables.SecondNumber = "";
        GlobalVariables.Operation = '\0';
        GlobalVariables.FirstHasComma = resultInternal.Contains('.');
        GlobalVariables.SecondHasComma = false;
        GlobalVariables.IsError = false;
    }
}