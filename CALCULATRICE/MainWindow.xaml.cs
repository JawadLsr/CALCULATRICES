using System;
using System.Windows;

namespace CALCULATRICE
{
    public partial class MainWindow : Window
    {
        // Variables pour stocker les deux nombres et l'opération choisie
        double NB1 = 0;
        double NB2 = 0;
        char Oper = ' ';

        public MainWindow()
        {
            InitializeComponent();
        }

        // Effectue le calcul selon l'opération choisie
        public double Calcul(double a, double b, char operation)
        {
            switch (operation)
            {
                case '+':
                    return a + b;

                case '-':
                    return a - b;

                case '*':
                    return a * b;

                case '/':
                    // Vérifie si on essaie de diviser par zéro
                    if (b == 0)
                    {
                        MessageBox.Show("Division par zéro impossible.");
                        return 0;
                    }
                    return a / b;

                default:
                    return 0;
            }
        }

        // Récupère le nombre affiché à l'écran (0 si l'écran est vide)
        private double LireNombre()
        {
            if (TB_Display.Text == "")
                return 0;

            // Parse : convertit la chaîne en nombre
            return double.Parse(TB_Display.Text);
        }

        // Ajoute un chiffre à l'écran
        private void AjouterChiffre(string chiffre)
        {
            // Remplace le zéro de départ par le chiffre
            if (TB_Display.Text == "0" || TB_Display.Text == "")
                TB_Display.Text = chiffre;
            else
                TB_Display.Text = TB_Display.Text + chiffre;
        }

        // ----- Boutons des chiffres -----
        private void BTN_One_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("1");
        }

        private void BTN_Two_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("2");
        }

        private void BTN_Three_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("3");
        }

        private void BTN_Four_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("4");
        }

        private void BTN_Five_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("5");
        }

        private void BTN_Six_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("6");
        }

        private void BTN_Seven_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("7");
        }

        private void BTN_Eight_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("8");
        }

        private void BTN_Nine_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("9");
        }

        private void BTN_Zero_Click(object sender, RoutedEventArgs e)
        {
            AjouterChiffre("0");
        }

        // Enregistre le premier nombre et l'opération choisie
        private void ChoisirOperation(char operation)
        {
            NB1 = LireNombre();
            Oper = operation;

            // Vide l'écran pour saisir le deuxième nombre
            TB_Display.Text = "";
        }

        // ----- Boutons des opérations -----
        private void BTN_Add_Click(object sender, RoutedEventArgs e)
        {
            ChoisirOperation('+');
        }

        private void BTN_Subtract_Click(object sender, RoutedEventArgs e)
        {
            ChoisirOperation('-');
        }

        private void BTN_Multiply_Click(object sender, RoutedEventArgs e)
        {
            ChoisirOperation('*');
        }

        private void BTN_Divide_Click(object sender, RoutedEventArgs e)
        {
            ChoisirOperation('/');
        }

        // Effectue le calcul quand on appuie sur =
        private void BTN_Equals_Click(object sender, RoutedEventArgs e)
        {
            // Si aucune opération n'a été choisie, on ne fait rien
            if (Oper == ' ')
                return;

            NB2 = LireNombre();

            // Appelle la fonction Calcul pour obtenir le résultat
            double resultat = Calcul(NB1, NB2, Oper);

            // Affiche le résultat et le garde en mémoire
            TB_Display.Text = resultat.ToString();
            NB1 = resultat;
            Oper = ' ';
        }

        // Remet la calculatrice à zéro
        private void BTN_Clear_Click(object sender, RoutedEventArgs e)
        {
            TB_Display.Text = "0";
            NB1 = 0;
            NB2 = 0;
            Oper = ' ';
        }

        // Change le signe du nombre : positif <-> négatif
        private void BTN_Sign_Click(object sender, RoutedEventArgs e)
        {
            double nombre = LireNombre();
            TB_Display.Text = (-nombre).ToString();
        }

        // Calcule le cosinus (angle en degrés)
        private void BTN_Cos_Click(object sender, RoutedEventArgs e)
        {
            double nombre = LireNombre();

            // Math.Cos attend des radians : on convertit les degrés
            double resultat = Math.Cos(nombre * Math.PI / 180);

            // On arrondit pour éviter des résultats comme 6E-17 au lieu de 0
            TB_Display.Text = Math.Round(resultat, 10).ToString();
        }

        // Calcule le sinus (angle en degrés)
        private void BTN_Sin_Click(object sender, RoutedEventArgs e)
        {
            double nombre = LireNombre();

            double resultat = Math.Sin(nombre * Math.PI / 180);

            TB_Display.Text = Math.Round(resultat, 10).ToString();
        }

        // Calcule la tangente (angle en degrés)
        private void BTN_Tan_Click(object sender, RoutedEventArgs e)
        {
            double nombre = LireNombre();

            // La tangente n'existe pas pour 90°, 270°, -90°... (% = reste de la division)
            if (nombre % 180 == 90 || nombre % 180 == -90)
            {
                MessageBox.Show("Tangente impossible pour cet angle.");
                return;
            }

            double resultat = Math.Tan(nombre * Math.PI / 180);

            TB_Display.Text = Math.Round(resultat, 10).ToString();
        }

        // Calcule la racine carrée
        private void BTN_SquareRoot_Click(object sender, RoutedEventArgs e)
        {
            double nombre = LireNombre();

            // Pas de racine carrée pour un nombre négatif
            if (nombre < 0)
            {
                MessageBox.Show("Impossible de calculer la racine carrée d'un nombre négatif.");
                return;
            }

            TB_Display.Text = Math.Sqrt(nombre).ToString();
        }

        // Ajoute une virgule pour saisir un nombre décimal
        private void BTN_Comma_Click(object sender, RoutedEventArgs e)
        {
            // Si l'écran est vide, on commence par "0,"
            if (TB_Display.Text == "")
                TB_Display.Text = "0,";

            // On n'ajoute la virgule que s'il n'y en a pas déjà une
            else if (!TB_Display.Text.Contains(","))
                TB_Display.Text = TB_Display.Text + ",";
        }

        // Divise le nombre affiché par 100
        private void BTN_Percent_Click(object sender, RoutedEventArgs e)
        {
            double nombre = LireNombre();
            TB_Display.Text = (nombre / 100).ToString();
        }
    }
}