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

            string nas = TextBoxNas.Text;
            string nom = TextBoxNom.Text;
            string prenom = TextBoxPrenom.Text;
            string dateDeNaissance = TextBoxDateDeNaissance.Text;
            double depense = Convert.ToDouble(TextBoxDepense.Text);
            string status = null;
            string sexe = null;

            if (Celibataire.IsChecked == true)
            {
                status = Fonction.RemoveDiacritics(Celibataire.Content.ToString());
            }
            else if (Marie.IsChecked == true)
            {
                status = Fonction.RemoveDiacritics(Marie.Content.ToString());
            }
            else if (Veuf.IsChecked == true)
            {
                status = Fonction.RemoveDiacritics(Veuf.Content.ToString());
            }
            else if (Divorce.IsChecked == true)
            {
                status = Fonction.RemoveDiacritics(Divorce.Content.ToString());
            }

            if (Homme.IsChecked == true)
            {
                sexe = Fonction.RemoveDiacritics(Homme.Content.ToString());
            }
            else if (Femme.IsChecked == true)
            {
                sexe = Fonction.RemoveDiacritics(Femme.Content.ToString());
            }

            if (nom != null && prenom != null)
            {
                Fonction.tblPersonnes[cpt1] = new Personne(nom, prenom, depense);
            }

            if (nas != null && dateDeNaissance != null && status != null && sexe != null)
            {
                Personne.statusEnum? statusEnum = null;
                Personne.sexeEnum? sexeEnum = null;

                if (status.Equals(Personne.statusEnum.Celibataire.ToString()))
                {
                    statusEnum = Personne.statusEnum.Celibataire;
                }
                else if (status.Equals(Personne.statusEnum.Marie.ToString()))
                {
                    statusEnum = Personne.statusEnum.Marie;
                }
                else if (status.Equals(Personne.statusEnum.Veuf.ToString()))
                {
                    statusEnum = Personne.statusEnum.Veuf;
                }
                else if (status.Equals(Personne.statusEnum.Divorce.ToString()))
                {
                    statusEnum = Personne.statusEnum.Divorce;
                }

                if (sexe.Equals(Personne.sexeEnum.Homme.ToString()))
                {
                    sexeEnum = Personne.sexeEnum.Homme;
                }
                else if (sexe.Equals(Personne.sexeEnum.Femme.ToString()))
                {
                    sexeEnum = Personne.sexeEnum.Femme;
                }

                Fonction.tblPersonnes[cpt1] = new Personne(nas, nom, prenom, dateDeNaissance, depense, statusEnum, sexeEnum);
            }
            cpt1++;
            this.Close();
        }
    }
}
