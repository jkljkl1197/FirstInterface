using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Interface_3fev
{
    /// <summary>
    /// Logique d'interaction pour Ajouter.xaml
    /// </summary>
    public partial class Ajouter : Window
    {
        public Ajouter()
        {
            InitializeComponent();
        }

        private void buttonAnnuler_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public int cpt1 = Fonction.Cpt;
        private void buttonAjouter_click(object sender, RoutedEventArgs e)
        {
            string name = TextBoxNom.Text;
            string prenom = TextBoxPrenom.Text;
            double depense = Convert.ToDouble(TextBoxDepense.Text);

            Fonction.tblPersonnes[cpt1] = new Personne(name, prenom, depense);
            cpt1++;
            this.Close();
        }
    }
}
