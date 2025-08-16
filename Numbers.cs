using System.Windows;
using System.Windows.Controls;
using Calculator;

namespace NumbersBtn;

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
    }

    public void BtnNumberClick_1(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "1";
    }

    public void BtnNumberClick_2(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "2";
    }

    public void BtnNumberClick_3(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "3";
    }

    public void BtnNumberClick_4(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "4";
    }

    public void BtnNumberClick_5(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "5";
    }

    public void BtnNumberClick_6(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "6";
    }

    public void BtnNumberClick_7(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "7";
    }

    public void BtnNumberClick_8(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "8";
    }

    public void BtnNumberClick_9(object sender, RoutedEventArgs e)
    {
        _window.Display.Content += "9";
    }
}