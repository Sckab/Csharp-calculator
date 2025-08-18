using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using Calculator;
using Globals;

namespace UiHelper;

public class UiHelper_Class
{
    private MainWindow _window;

    public UiHelper_Class(MainWindow window)
    {
        _window = window;
    }

    public static void SetDisplayAndVariable(MainWindow window, string rawNumber, bool isSecondNumber)
    {
        if (window == null) throw new ArgumentNullException(nameof(window));
        rawNumber ??= "";

        string internalText = rawNumber.Replace(',', '.');
        string displayText = string.IsNullOrEmpty(internalText) ? "" : internalText.Replace('.', ',');

        if (isSecondNumber)
        {
            GlobalVariables.SecondNumber = internalText;
            window.Display.Content = displayText;
        }
        else
        {
            GlobalVariables.FirstNumber = internalText;
            window.Display.Content = displayText;
        }
    }
}
