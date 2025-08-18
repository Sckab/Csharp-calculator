using System.Windows;
using System.Windows.Controls;
using Calculator;
using Globals;

namespace OtherBtns;

public class Other_Class
{
    private MainWindow _window;

    public Other_Class(MainWindow window)
    {
        _window = window;
    }

    public static string FormatNumber(string number, bool hasComma = false)
    {
        if (string.IsNullOrEmpty(number))
            return "";

        bool isNegative = number.StartsWith("-");
        if (isNegative)
            number = number.Substring(1);

        string[] parts = number.Split('.');
        string integerPart = parts[0];
        string decimalPart = parts.Length > 1 ? parts[1] : "";

        string formattedInt = string.IsNullOrEmpty(integerPart) ? "0" : string.Format("{0:N0}", long.Parse(integerPart));

        string result;

        if (decimalPart.Length > 0)
            result = $"{formattedInt},{decimalPart}";
        else if (hasComma)
            result = $"{formattedInt},";
        else
            result = formattedInt;

        return isNegative ? "-" + result : result;
    }

    public void Comma(object sender, RoutedEventArgs e)
    {
        if (!GlobalVariables.IsSecondNumber)
        {
            if (GlobalVariables.FirstHasComma) return;

            GlobalVariables.FirstNumber += string.IsNullOrEmpty(GlobalVariables.FirstNumber) ? "0." : ".";
            GlobalVariables.FirstHasComma = true;
        }
        else
        {
            if (GlobalVariables.SecondHasComma) return;

            GlobalVariables.SecondNumber += string.IsNullOrEmpty(GlobalVariables.SecondNumber) ? "0." : ".";
            GlobalVariables.SecondHasComma = true;
        }

        string first = FormatNumber(GlobalVariables.FirstNumber, GlobalVariables.FirstHasComma);
        string second = FormatNumber(GlobalVariables.SecondNumber, GlobalVariables.SecondHasComma);

        string op = GlobalVariables.Operation == '\0' ? "" :
                    (GlobalVariables.Operation == '*' ? "×" :
                     GlobalVariables.Operation == '/' ? "÷" :
                     GlobalVariables.Operation.ToString());

        _window.Display.Content = string.IsNullOrEmpty(op) ? first : first + op + second;
    }

    public void PlusMinus(object sender, RoutedEventArgs e)
    {
        if (!GlobalVariables.IsSecondNumber)
        {
            if (string.IsNullOrEmpty(GlobalVariables.FirstNumber)) return;

            if (GlobalVariables.FirstNumber.StartsWith("-"))
                GlobalVariables.FirstNumber = GlobalVariables.FirstNumber.Substring(1);
            else
                GlobalVariables.FirstNumber = "-" + GlobalVariables.FirstNumber;

            _window.Display.Content = FormatNumber(GlobalVariables.FirstNumber, GlobalVariables.FirstHasComma) +
                                      (GlobalVariables.Operation != '\0' ? GlobalVariables.Operation.ToString() : "");
        }
        else
        {
            if (string.IsNullOrEmpty(GlobalVariables.SecondNumber)) return;

            if (GlobalVariables.Operation == '-')
                GlobalVariables.Operation = '+';
            else if (GlobalVariables.Operation == '+')
                GlobalVariables.Operation = '-';

            _window.Display.Content = FormatNumber(GlobalVariables.FirstNumber, GlobalVariables.FirstHasComma) +
                                      GlobalVariables.Operation +
                                      FormatNumber(GlobalVariables.SecondNumber, GlobalVariables.SecondHasComma);
        }
    }
}