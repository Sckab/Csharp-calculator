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

    }

    public void BtnDelete1(object sender, RoutedEventArgs e)
    {
        string disp = this.Display?.Content?.ToString() ?? "";
        if (string.IsNullOrEmpty(disp)) return;

        if (GlobalVariables.IsSecondNumber)
        {
            if (string.IsNullOrEmpty(GlobalVariables.SecondNumber))
            {
                // se non c'è secondo numero, potresti voler rimuovere l'operatore invece
                return;
            }

            GlobalVariables.SecondNumber = GlobalVariables.SecondNumber.Remove(GlobalVariables.SecondNumber.Length - 1);
            GlobalVariables.SecondHasComma = GlobalVariables.SecondNumber.Contains(".");
            // aggiorna display usando il metodo d'istanza
            UiHelper_Class.SetDisplayAndVariable(this, GlobalVariables.SecondNumber.Replace('.', ','), true);
        }
        else
        {
            if (string.IsNullOrEmpty(GlobalVariables.FirstNumber))
            {
                this.Display.Content = "0";
                return;
            }

            GlobalVariables.FirstNumber = GlobalVariables.FirstNumber.Remove(GlobalVariables.FirstNumber.Length - 1);
            GlobalVariables.FirstHasComma = GlobalVariables.FirstNumber.Contains(".");
            UiHelper_Class.SetDisplayAndVariable(this, GlobalVariables.FirstNumber.Replace('.', ','), false);
        }

        // se è tutto vuoto, mostra 0
        if (!GlobalVariables.IsSecondNumber && string.IsNullOrEmpty(GlobalVariables.FirstNumber))
            this.Display.Content = "0";
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
            GlobalVariables.FirstHasComma = false;
            GlobalVariables.SecondHasComma = false;
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

}