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
            bool error = false;
            bool lastError = false;
            string message = "";

            string nas = TextBoxNas.Text;
            string nom = TextBoxNom.Text;
            string prenom = TextBoxPrenom.Text;
            double? depense = ValidType.doubleValide(TextBoxDepense.Text);
            string status = null;
            string sexe = null;
            DateTime now = DateTime.Now;
            Personne.statusEnum? statusEnum = null;
            Personne.sexeEnum? sexeEnum = null;

            string dateDeNaissance = "";
            string[] splitDate = {"0" ,"0" , "0"};
            try
            {
                dateDeNaissance = DatePickerDateDeNaissance.SelectedDate.Value.Date.ToShortDateString();
                splitDate = dateDeNaissance.Split('-');
            }
            catch { }

            {

            if (Validation.dateValide(splitDate[2], splitDate[1], splitDate[0], (now.Year - 120), (now.Year), 2) == "0")
            {
                message += "Date Invalide, ";
                error = true;
            }
            else { error = false; }

            if (nom.Any(char.IsDigit) || prenom.Any(char.IsDigit) || nom == "" || prenom == "")
            {
                message += "Nom ou Prenom Invalide, ";
                error = true;
            }
            else { error = false; }

            if (depense == null)
            {
                message += "Depense Invalide, ";
                error = true;
            }
            else { error = false; }

            if (Validation.nasValide(nas) == null)
            {
                message += "Nas Invalide, ";
                error = true;
            }
            else { error = false; }

            
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

                if (status != null && sexe != null) 
                {
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
                }
                else
                {
                    message += "Auccun status ou sexe selectionné.";
                    error = true;
                }

                if (error == true)
                {
                    MessageBoxResult result = MessageBox.Show("" + message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (result == MessageBoxResult.OK)
                    {
                        lastError = true;
                        error = false;
                    }
                }
            } while (error == true);
            error = false;
            if (lastError == false)
            {
                Fonction.tblPersonnes[cpt1] = new Personne(nas, nom, prenom, dateDeNaissance, depense, statusEnum, sexeEnum);
                cpt1++;
                this.Close();
            }
      }
    }
}
