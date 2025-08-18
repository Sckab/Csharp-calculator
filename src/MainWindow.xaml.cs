using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Globals;
using NumbersBtns;
using OperationsBtns;
using OtherBtns;
using UiHelper;

namespace Calculator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Number_Class _numbers;

    private Operation_Class _operation;

    private Other_Class _other;

    public void BtnDelete1(object sender, RoutedEventArgs e)
    {
        if (!GlobalVariables.IsSecondNumber)
        {
            if (!string.IsNullOrEmpty(GlobalVariables.FirstNumber))
            {
                GlobalVariables.FirstNumber = GlobalVariables.FirstNumber.Remove(GlobalVariables.FirstNumber.Length - 1);
                GlobalVariables.FirstHasComma = GlobalVariables.FirstNumber.Contains(".");

                if (!string.IsNullOrEmpty(Display.Content.ToString()))
                {
                    char lastChar = Display.Content.ToString()[Display.Content.ToString().Length - 1];
                    if (lastChar == '-')
                        GlobalVariables.IsFirstNegative = false;
                }
            }

            string opVis = "";
            string displayText = Other_Class.FormatNumber(GlobalVariables.FirstNumber, GlobalVariables.FirstHasComma);
            this.Display.Content = displayText;
        }
        else
        {
            if (!string.IsNullOrEmpty(GlobalVariables.SecondNumber))
            {
                GlobalVariables.SecondNumber = GlobalVariables.SecondNumber.Remove(GlobalVariables.SecondNumber.Length - 1);
                GlobalVariables.SecondHasComma = GlobalVariables.SecondNumber.Contains(".");
            }
            else
            {
                GlobalVariables.Operation = '\0';
                GlobalVariables.IsSecondNumber = false;
            }

            string opVis = GlobalVariables.Operation switch
            {
                '*' => "×",
                '/' => "÷",
                _ => GlobalVariables.Operation == '\0' ? "" : GlobalVariables.Operation.ToString()
            };

            string displayText = Other_Class.FormatNumber(GlobalVariables.FirstNumber, GlobalVariables.FirstHasComma);

            if (!string.IsNullOrEmpty(opVis))
                displayText += opVis;

            displayText += Other_Class.FormatNumber(GlobalVariables.SecondNumber, GlobalVariables.SecondHasComma);

            this.Display.Content = displayText;
        }
    }

    public void BtnDeleteAll(object sender, RoutedEventArgs e)
    {
        if (Display != null && Display.Content != null &&
            !string.IsNullOrEmpty(Display.Content.ToString()))
        {
            Display.Content = "";
            GlobalVariables.IsSecondNumber = false;
            GlobalVariables.Operation = '\0';
            GlobalVariables.FirstNumber = "";
            GlobalVariables.SecondNumber = "";
            GlobalVariables.FirstHasComma = false;
            GlobalVariables.SecondHasComma = false;
            GlobalVariables.IsFirstNegative = false;
        }
    }

    private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            this.DragMove();
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void MainWindow_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            // NUMERI
            case Key.D0:
            case Key.NumPad0: _numbers.BtnNumberClick_0(null, null); break;
            case Key.D1:
            case Key.NumPad1: _numbers.BtnNumberClick_1(null, null); break;
            case Key.D2:
            case Key.NumPad2: _numbers.BtnNumberClick_2(null, null); break;
            case Key.D3:
            case Key.NumPad3: _numbers.BtnNumberClick_3(null, null); break;
            case Key.D4:
            case Key.NumPad4: _numbers.BtnNumberClick_4(null, null); break;
            case Key.D5:
            case Key.NumPad5: _numbers.BtnNumberClick_5(null, null); break;
            case Key.D6:
            case Key.NumPad6: _numbers.BtnNumberClick_6(null, null); break;
            case Key.D7:
            case Key.NumPad7: _numbers.BtnNumberClick_7(null, null); break;
            case Key.D8:
            case Key.NumPad8: _numbers.BtnNumberClick_8(null, null); break;
            case Key.D9:
            case Key.NumPad9: _numbers.BtnNumberClick_9(null, null); break;

            // OPERATORS
            case Key.Add:
            case Key.OemPlus: _operation.Addition(null, null); break;
            case Key.Subtract:
            case Key.OemMinus: _operation.Subtraction(null, null); break;
            case Key.Multiply: _operation.Moltiplication(null, null); break;
            case Key.Divide: _operation.Division(null, null); break;

            // ALTRE FUNZIONI
            case Key.Decimal:
            case Key.OemComma: _other.Comma(null, null); break;

            case Key.Enter: _operation.Equals(null, null); break;
            case Key.Tab: _other.PlusMinus(null, null); break;
            case Key.S: _operation.SquareRoot(null, null); break;
            case Key.Back: BtnDelete1(null, null); break;
        }
    }

    public MainWindow()
    {
        InitializeComponent();

        /*
         *  NUMBERS LOGIC
         */
        _numbers = new Number_Class(this);

        Number_0.Click += _numbers.BtnNumberClick_0;
        Number_1.Click += _numbers.BtnNumberClick_1;
        Number_2.Click += _numbers.BtnNumberClick_2;
        Number_3.Click += _numbers.BtnNumberClick_3;
        Number_4.Click += _numbers.BtnNumberClick_4;
        Number_5.Click += _numbers.BtnNumberClick_5;
        Number_6.Click += _numbers.BtnNumberClick_6;
        Number_7.Click += _numbers.BtnNumberClick_7;
        Number_8.Click += _numbers.BtnNumberClick_8;
        Number_9.Click += _numbers.BtnNumberClick_9;

        /*
         *  OPERATION LOGIC
         */
        _operation = new Operation_Class(this);

        Addition.Click += _operation.Addition;
        Subtraction.Click += _operation.Subtraction;
        Moltiplication.Click += _operation.Moltiplication;
        Division.Click += _operation.Division;
        SquareRoot.Click += _operation.SquareRoot;

        Equal.Click += _operation.Equals;

        /*
         *  OTHER BUTTNONS LOGIC
         */
        _other = new Other_Class(this);

        Comma.Click += _other.Comma;
        PlusMinus.Click += _other.PlusMinus;

        this.KeyDown += MainWindow_KeyDown;
    }
}