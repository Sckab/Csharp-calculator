using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using Calculator;
using Globals;
using OtherBtns;

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

        if (internalText == ".") internalText = "0.";
        if (internalText == "-.") internalText = "-0.";

        if (isSecondNumber)
        {
            GlobalVariables.SecondNumber = internalText;
            GlobalVariables.SecondHasComma = internalText.Contains(".");
        }
        else
        {
            GlobalVariables.FirstNumber = internalText;
            GlobalVariables.FirstHasComma = internalText.Contains(".");
        }

        string opVis =
            GlobalVariables.Operation == '\0' ? "" :
            GlobalVariables.Operation == '*' ? "×" :
            GlobalVariables.Operation == '/' ? "÷" :
            GlobalVariables.Operation.ToString();

        string firstDisp = Other_Class.FormatNumber(GlobalVariables.FirstNumber, GlobalVariables.FirstHasComma);
        string secondDisp = Other_Class.FormatNumber(GlobalVariables.SecondNumber, GlobalVariables.SecondHasComma);

        string displayExpr = firstDisp + (string.IsNullOrEmpty(opVis) ? "" : opVis) + secondDisp;

        window.Display.Content = displayExpr;
    }

}
