using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using Calculator;
using Globals;

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
        if (_window.Display != null && _window.Display.Content != null &&
            !string.IsNullOrEmpty(_window.Display.Content.ToString()))
        {
            if (GlobalVariables.IsSecondNumber == false)
            {
                _window.Display.Content += "-";
                GlobalVariables.Operation = '-';
                GlobalVariables.IsSecondNumber = true;
            }
            else if (GlobalVariables.IsSecondNumber == true)
            {

            }
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

    public void Equals(object sender, RoutedEventArgs e)
    {
        if (GlobalVariables.FirstNumber != "" || GlobalVariables.SecondNumber != "")
        {
            int FirstNumberInt = Int32.Parse(GlobalVariables.FirstNumber);
            int SecondNumberInt = Int32.Parse(GlobalVariables.SecondNumber);

            switch (GlobalVariables.Operation)
            {
                case '+':
                    int ResultAdd;

                    ResultAdd = FirstNumberInt + SecondNumberInt;
                    _window.Display.Content = ResultAdd;

                    string ResultStringAdd = ResultAdd.ToString();
                    GlobalVariables.IsSecondNumber = false;
                    GlobalVariables.FirstNumber = ResultStringAdd;
                    GlobalVariables.SecondNumber = "";
                    break;

                case '-':
                    int ResultSub;

                    ResultSub = FirstNumberInt - SecondNumberInt;
                    _window.Display.Content = ResultSub;

                    string ResultStringSub = ResultSub.ToString();
                    GlobalVariables.IsSecondNumber = false;
                    GlobalVariables.FirstNumber = ResultStringSub;
                    GlobalVariables.SecondNumber = "";
                    break;

                case '*':
                    int ResultMolt;

                    ResultMolt = FirstNumberInt * SecondNumberInt;
                    _window.Display.Content = ResultMolt;

                    string ResultStringMolt = ResultMolt.ToString();
                    GlobalVariables.IsSecondNumber = false;
                    GlobalVariables.FirstNumber = ResultStringMolt;
                    GlobalVariables.SecondNumber = "";
                    break;

                case '/':
                    if (SecondNumberInt != 0)
                    {
                        int ResultDiv;

                        ResultDiv = FirstNumberInt / SecondNumberInt;
                        _window.Display.Content = ResultDiv;

                        string ResultStringDiv = ResultDiv.ToString();
                        GlobalVariables.IsSecondNumber = false;
                        GlobalVariables.FirstNumber = ResultStringDiv;
                        GlobalVariables.SecondNumber = "";
                        break;
                    }
                    else
                    {
                        _window.Display.Content = "Cannot divide by 0";
                        break;
                    }

                default:
                    break;
            }
        }
    }
}