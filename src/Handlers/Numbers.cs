using System.Windows;
using System.Windows.Controls;
using Calculator;
using Globals;
using UiHelper;
using OtherBtns;

namespace NumbersBtns;

public class Number_Class
{
    private MainWindow _window;

    public Number_Class(MainWindow window)
    {
        _window = window;
    }

    private void UpdateDisplay()
    {
        string first = Other_Class.FormatNumber(GlobalVariables.FirstNumber, GlobalVariables.FirstHasComma);
        string second = Other_Class.FormatNumber(GlobalVariables.SecondNumber, GlobalVariables.SecondHasComma);

        string opVis = GlobalVariables.Operation switch
        {
            '*' => "×",
            '/' => "÷",
            _ => GlobalVariables.Operation == '\0' ? "" : GlobalVariables.Operation.ToString()
        };

        _window.Display.Content = first + opVis + second;
    }


    private string FormatNumberForDisplay(string number)
    {
        if (string.IsNullOrEmpty(number))
            return "";

        string intPart = number;
        string decimalPart = "";

        if (number.Contains('.'))
        {
            var parts = number.Split('.');
            intPart = parts[0];
            decimalPart = parts[1];
        }

        var sb = new System.Text.StringBuilder();
        int count = 0;
        for (int i = intPart.Length - 1; i >= 0; i--)
        {
            sb.Insert(0, intPart[i]);
            count++;
            if (count % 3 == 0 && i != 0)
                sb.Insert(0, ".");
        }

        return decimalPart != "" ? sb.ToString() + "," + decimalPart : sb.ToString();
    }


    public void BtnNumberClick_0(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        string digit = btn?.Content.ToString() ?? "0";

        if (GlobalVariables.IsError)
        {
            GlobalVariables.FirstNumber = digit;
            GlobalVariables.SecondNumber = "";
            GlobalVariables.IsError = false;
            GlobalVariables.IsSecondNumber = false;
            GlobalVariables.Operation = '\0';
            UpdateDisplay();
            return;
        }

        if (!GlobalVariables.IsSecondNumber)
        {
            GlobalVariables.FirstNumber += digit;
        }
        else
        {
            GlobalVariables.SecondNumber += digit;
        }

        UpdateDisplay();
    }

    public void BtnNumberClick_1(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        string digit = btn?.Content.ToString() ?? "1";

        if (GlobalVariables.IsError)
        {
            GlobalVariables.FirstNumber = digit;
            GlobalVariables.SecondNumber = "";
            GlobalVariables.IsError = false;
            GlobalVariables.IsSecondNumber = false;
            GlobalVariables.Operation = '\0';
            UpdateDisplay();
            return;
        }

        if (!GlobalVariables.IsSecondNumber)
        {
            GlobalVariables.FirstNumber += digit;
        }
        else
        {
            GlobalVariables.SecondNumber += digit;
        }

        UpdateDisplay();
    }

    public void BtnNumberClick_2(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        string digit = btn?.Content.ToString() ?? "2";

        if (GlobalVariables.IsError)
        {
            GlobalVariables.FirstNumber = digit;
            GlobalVariables.SecondNumber = "";
            GlobalVariables.IsError = false;
            GlobalVariables.IsSecondNumber = false;
            GlobalVariables.Operation = '\0';
            UpdateDisplay();
            return;
        }

        if (!GlobalVariables.IsSecondNumber)
        {
            GlobalVariables.FirstNumber += digit;
        }
        else
        {
            GlobalVariables.SecondNumber += digit;
        }

        UpdateDisplay();
    }

    public void BtnNumberClick_3(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        string digit = btn?.Content.ToString() ?? "3";

        if (GlobalVariables.IsError)
        {
            GlobalVariables.FirstNumber = digit;
            GlobalVariables.SecondNumber = "";
            GlobalVariables.IsError = false;
            GlobalVariables.IsSecondNumber = false;
            GlobalVariables.Operation = '\0';
            UpdateDisplay();
            return;
        }

        if (!GlobalVariables.IsSecondNumber)
        {
            GlobalVariables.FirstNumber += digit;
        }
        else
        {
            GlobalVariables.SecondNumber += digit;
        }

        UpdateDisplay();
    }

    public void BtnNumberClick_4(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        string digit = btn?.Content.ToString() ?? "4";

        if (GlobalVariables.IsError)
        {
            GlobalVariables.FirstNumber = digit;
            GlobalVariables.SecondNumber = "";
            GlobalVariables.IsError = false;
            GlobalVariables.IsSecondNumber = false;
            GlobalVariables.Operation = '\0';
            UpdateDisplay();
            return;
        }

        if (!GlobalVariables.IsSecondNumber)
        {
            GlobalVariables.FirstNumber += digit;
        }
        else
        {
            GlobalVariables.SecondNumber += digit;
        }

        UpdateDisplay();
    }

    public void BtnNumberClick_5(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        string digit = btn?.Content.ToString() ?? "5";

        if (GlobalVariables.IsError)
        {
            GlobalVariables.FirstNumber = digit;
            GlobalVariables.SecondNumber = "";
            GlobalVariables.IsError = false;
            GlobalVariables.IsSecondNumber = false;
            GlobalVariables.Operation = '\0';
            UpdateDisplay();
            return;
        }

        if (!GlobalVariables.IsSecondNumber)
        {
            GlobalVariables.FirstNumber += digit;
        }
        else
        {
            GlobalVariables.SecondNumber += digit;
        }

        UpdateDisplay();
    }

    public void BtnNumberClick_6(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        string digit = btn?.Content.ToString() ?? "6";

        if (GlobalVariables.IsError)
        {
            GlobalVariables.FirstNumber = digit;
            GlobalVariables.SecondNumber = "";
            GlobalVariables.IsError = false;
            GlobalVariables.IsSecondNumber = false;
            GlobalVariables.Operation = '\0';
            UpdateDisplay();
            return;
        }

        if (!GlobalVariables.IsSecondNumber)
        {
            GlobalVariables.FirstNumber += digit;
        }
        else
        {
            GlobalVariables.SecondNumber += digit;
        }

        UpdateDisplay();
    }

    public void BtnNumberClick_7(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        string digit = btn?.Content.ToString() ?? "7";

        if (GlobalVariables.IsError)
        {
            GlobalVariables.FirstNumber = digit;
            GlobalVariables.SecondNumber = "";
            GlobalVariables.IsError = false;
            GlobalVariables.IsSecondNumber = false;
            GlobalVariables.Operation = '\0';
            UpdateDisplay();
            return;
        }

        if (!GlobalVariables.IsSecondNumber)
        {
            GlobalVariables.FirstNumber += digit;
        }
        else
        {
            GlobalVariables.SecondNumber += digit;
        }

        UpdateDisplay();
    }

    public void BtnNumberClick_8(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        string digit = btn?.Content.ToString() ?? "8";

        if (GlobalVariables.IsError)
        {
            GlobalVariables.FirstNumber = digit;
            GlobalVariables.SecondNumber = "";
            GlobalVariables.IsError = false;
            GlobalVariables.IsSecondNumber = false;
            GlobalVariables.Operation = '\0';
            UpdateDisplay();
            return;
        }

        if (!GlobalVariables.IsSecondNumber)
        {
            GlobalVariables.FirstNumber += digit;
        }
        else
        {
            GlobalVariables.SecondNumber += digit;
        }

        UpdateDisplay();
    }

    public void BtnNumberClick_9(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        string digit = btn?.Content.ToString() ?? "9";

        if (GlobalVariables.IsError)
        {
            GlobalVariables.FirstNumber = digit;
            GlobalVariables.SecondNumber = "";
            GlobalVariables.IsError = false;
            GlobalVariables.IsSecondNumber = false;
            GlobalVariables.Operation = '\0';
            UpdateDisplay();
            return;
        }

        if (!GlobalVariables.IsSecondNumber)
        {
            GlobalVariables.FirstNumber += digit;
        }
        else
        {
            GlobalVariables.SecondNumber += digit;
        }

        UpdateDisplay();
    }
}