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
namespace CALCULATRICE
{
    public partial class MainWindow : Window
    {
        double NB1 = 0;
        double NB2 = 0;
        char Oper = ' ';

        public MainWindow()
        {
            InitializeComponent();
        }

        //test git 
        public double Calcul(double NB1, double NB2, char operation)
        {
            double Resultat = 0;

            switch (operation)
            {
                case '+':
                    Resultat = NB1 + NB2;
                    break;

                case '-':
                    Resultat = NB1 - NB2;
                    break;

                case '*':
                    Resultat = NB1 * NB2;
                    break;

                case '/':
                    if (NB2 == 0)
                    {
                        MessageBox.Show("Division par zéro impossible.");
                        return 0;
                    }

                    Resultat = NB1 / NB2;
                    break;
            }

            return Resultat;
        }

        private void BTN_One_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text == "0")
                TB_Display.Text = "1";
            else
                TB_Display.Text += "1";


        }

        private void BTN_Two_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text == "0")
                TB_Display.Text = "2";
            else
                TB_Display.Text += "2";


        }

        private void BTN_Three_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text == "0")
                TB_Display.Text = "3";
            else
                TB_Display.Text += "3";


        }

        private void BTN_Four_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text == "0")
                TB_Display.Text = "4";
            else
                TB_Display.Text += "4";


        }

        private void BTN_Five_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text == "0")
                TB_Display.Text = "5";
            else
                TB_Display.Text += "5";


        }

        private void BTN_Six_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text == "0")
                TB_Display.Text = "6";
            else
                TB_Display.Text += "6";


        }

        private void BTN_Seven_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text == "0")
                TB_Display.Text = "7";
            else
                TB_Display.Text += "7";


        }

        private void BTN_Eight_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text == "0")
                TB_Display.Text = "8";
            else
                TB_Display.Text += "8";


        }



        private void BTN_Nine_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text == "0")
                TB_Display.Text = "9";
            else
                TB_Display.Text += "9";


        }

        private void BTN_Zero_Click(object sender, RoutedEventArgs e)
        {
            if (TB_Display.Text == "0")
                TB_Display.Text = "0";
            else
                TB_Display.Text += "0";

        }


        private void BTN_Add_Click(object sender, RoutedEventArgs e)
        {
            NB1 = double.Parse(TB_Display.Text);
            Oper = '+';
            TB_Display.Text = "";
        }

        private void BTN_Subtract_Click(object sender, RoutedEventArgs e)
        {
            NB1 = double.Parse(TB_Display.Text);
            Oper = '-';
            TB_Display.Text = "";
        }

        private void BTN_Multiply_Click(object sender, RoutedEventArgs e)
        {
            NB1 = double.Parse(TB_Display.Text);
            Oper = '*';
            TB_Display.Text = "";
        }

        private void BTN_Divide_Click(object sender, RoutedEventArgs e)
        {
            NB1 = double.Parse(TB_Display.Text);
            Oper = '/';
            TB_Display.Text = "";
        }

        private void BTN_Equals_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TB_Display.Text))
                return;

            NB2 = double.Parse(TB_Display.Text);

            double resultat = Calcul(NB1, NB2, Oper);

            TB_Display.Text = resultat.ToString();

            NB1 = resultat;
        }

        private void BTN_Clear_Click(object sender, RoutedEventArgs e)
        {
            TB_Display.Text = "0";
            NB1 = 0;
            NB2 = 0;
            Oper = ' ';
        }
    }
}