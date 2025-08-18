using System.Windows;
using System.Windows.Controls;
using Calculator;
using Globals;
using System.Globalization;
using UiHelper;
using OtherBtns;

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
        if (_window.Display == null || _window.Display.Content == null)
            return;

        if (!GlobalVariables.IsSecondNumber)
        {
            _window.Display.Content += "+";
            GlobalVariables.Operation = '+';
            GlobalVariables.IsSecondNumber = true;
        }
        else
        {
            if (!string.IsNullOrEmpty(GlobalVariables.SecondNumber))
                Equals(sender, e);

            GlobalVariables.Operation = '+';
            GlobalVariables.SecondNumber = "";
            GlobalVariables.IsSecondNumber = true;

            _window.Display.Content = Other_Class.FormatNumber(GlobalVariables.FirstNumber, GlobalVariables.FirstHasComma) + "+";
        }
    }

    public void Subtraction(object sender, RoutedEventArgs e)
    {
        if (_window.Display == null || _window.Display.Content == null)
            return;

        if (!GlobalVariables.IsSecondNumber && string.IsNullOrEmpty(GlobalVariables.FirstNumber))
        {
            _window.Display.Content += "-";
            GlobalVariables.FirstNumber = "-";
            GlobalVariables.IsFirstNegative = true;
            return;
        }

        if (!GlobalVariables.IsSecondNumber)
        {
            _window.Display.Content += "-";
            GlobalVariables.Operation = '-';
            GlobalVariables.IsSecondNumber = true;
        }
        else
        {
            if (!string.IsNullOrEmpty(GlobalVariables.SecondNumber))
                Equals(sender, e);

            GlobalVariables.Operation = '-';
            GlobalVariables.SecondNumber = "";
            GlobalVariables.IsSecondNumber = true;

            _window.Display.Content = Other_Class.FormatNumber(GlobalVariables.FirstNumber, GlobalVariables.FirstHasComma) + "-";
        }
    }

    public void Moltiplication(object sender, RoutedEventArgs e)
    {
        if (_window.Display == null || _window.Display.Content == null)
            return;

        if (!GlobalVariables.IsSecondNumber)
        {
            _window.Display.Content += "×";
            GlobalVariables.Operation = '*';
            GlobalVariables.IsSecondNumber = true;
        }
        else
        {
            if (!string.IsNullOrEmpty(GlobalVariables.SecondNumber))
                Equals(sender, e);

            GlobalVariables.Operation = '*';
            GlobalVariables.SecondNumber = "";
            GlobalVariables.IsSecondNumber = true;

            _window.Display.Content = Other_Class.FormatNumber(GlobalVariables.FirstNumber, GlobalVariables.FirstHasComma) + "×";
        }
    }

    public void Division(object sender, RoutedEventArgs e)
    {
        if (_window.Display == null || _window.Display.Content == null)
            return;

        if (!GlobalVariables.IsSecondNumber)
        {
            _window.Display.Content += "÷";
            GlobalVariables.Operation = '/';
            GlobalVariables.IsSecondNumber = true;
        }
        else
        {
            if (!string.IsNullOrEmpty(GlobalVariables.SecondNumber))
                Equals(sender, e);

            GlobalVariables.Operation = '/';
            GlobalVariables.SecondNumber = "";
            GlobalVariables.IsSecondNumber = true;

            _window.Display.Content = Other_Class.FormatNumber(GlobalVariables.FirstNumber, GlobalVariables.FirstHasComma) + "÷";
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
            _window.Display.Content = Other_Class.FormatNumber(GlobalVariables.FirstNumber, GlobalVariables.FirstHasComma);
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
            case '+': result = first + second; break;
            case '-': result = first - second; break;
            case '*': result = first * second; break;
            case '/':
                if (Math.Abs(second) < double.Epsilon)
                {
                    _window.Display.Content = "Cannot divide by 0";
                    GlobalVariables.IsError = true;
                    return;
                }
                result = first / second;
                break;
            default: return;
        }

        string resultInternal = result.ToString(CultureInfo.InvariantCulture);

        GlobalVariables.FirstNumber = resultInternal;
        GlobalVariables.FirstHasComma = resultInternal.Contains('.');
        GlobalVariables.SecondNumber = "";
        GlobalVariables.SecondHasComma = false;
        GlobalVariables.Operation = '\0';
        GlobalVariables.IsSecondNumber = false;
        GlobalVariables.IsError = false;

        _window.Display.Content = Other_Class.FormatNumber(GlobalVariables.FirstNumber, GlobalVariables.FirstHasComma);
    }

}