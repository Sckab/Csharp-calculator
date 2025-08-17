using System.Windows;
using System.Windows.Controls;
using Calculator;
using Globals;

namespace NumbersBtns;

public class Number
{
    private MainWindow _window;

    public Number(MainWindow window)
    {
        _window = window;
    }
    public void BtnNumberClick_0(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "0";

        if (GlobalVariables.IsSecondNumber == false)
        {
            GlobalVariables.FirstNumber += "0";
        }
        else
        {
            GlobalVariables.SecondNumber += "0";
        }
    }

    public void BtnNumberClick_1(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "1";

        if (GlobalVariables.IsSecondNumber == false)
        {
            GlobalVariables.FirstNumber += "1";
        }
        else
        {
            GlobalVariables.SecondNumber += "1";
        }
    }

    public void BtnNumberClick_2(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "2";

        if (GlobalVariables.IsSecondNumber == false)
        {
            GlobalVariables.FirstNumber += "2";
        }
        else
        {
            GlobalVariables.SecondNumber += "2";
        }
    }

    public void BtnNumberClick_3(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "3";

        if (GlobalVariables.IsSecondNumber == false)
        {
            GlobalVariables.FirstNumber += "3";
        }
        else
        {
            GlobalVariables.SecondNumber += "3";
        }
    }

    public void BtnNumberClick_4(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "4";

        if (GlobalVariables.IsSecondNumber == false)
        {
            GlobalVariables.FirstNumber += "4";
        }
        else
        {
            GlobalVariables.SecondNumber += "4";
        }
    }

    public void BtnNumberClick_5(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "5";
        if (GlobalVariables.IsSecondNumber == false)
        {
            GlobalVariables.FirstNumber += "5";
        }
        else
        {
            GlobalVariables.SecondNumber += "5";
        }
    }

    public void BtnNumberClick_6(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "6";

        if (GlobalVariables.IsSecondNumber == false)
        {
            GlobalVariables.FirstNumber += "6";
        }
        else
        {
            GlobalVariables.SecondNumber += "6";
        }
    }

    public void BtnNumberClick_7(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "7";

        if (GlobalVariables.IsSecondNumber == false)
        {
            GlobalVariables.FirstNumber += "7";
        }
        else
        {
            GlobalVariables.SecondNumber += "7";
        }
    }

    public void BtnNumberClick_8(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "8";

        if (GlobalVariables.IsSecondNumber == false)
        {
            GlobalVariables.FirstNumber += "8";
        }
        else
        {
            GlobalVariables.SecondNumber += "8";
        }
    }

    public void BtnNumberClick_9(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "9";

        if (GlobalVariables.IsSecondNumber == false)
        {
            GlobalVariables.FirstNumber += "9";
        }
        else
        {
            GlobalVariables.SecondNumber += "9";
        }
    }
}