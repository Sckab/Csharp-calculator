using System.Windows;
using System.Windows.Controls;
using Calculator;
using Globals;
using UiHelper;

namespace OtherBtns;

public class Other_Class
{
    private MainWindow _window;

    public Other_Class(MainWindow window)
    {
        _window = window;
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

        // Ricostruisci la label completa
        string first = GlobalVariables.FirstNumber.Replace('.', ',');
        string second = GlobalVariables.SecondNumber.Replace('.', ',');
        string op = GlobalVariables.Operation == '\0' ? "" :
                    (GlobalVariables.Operation == '*' ? "×" :
                     GlobalVariables.Operation == '/' ? "÷" :
                     GlobalVariables.Operation.ToString());

        _window.Display.Content = string.IsNullOrEmpty(op) ? first : first + op + second;
    }

}