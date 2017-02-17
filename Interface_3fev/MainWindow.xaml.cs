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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Interface_3fev
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            char Order = 'A';
            InitializeComponent();
            labelDebug.Visibility = Visibility.Hidden;
            texteboxDebug.Visibility = Visibility.Hidden;
            buttomTxt2Json.Visibility = Visibility.Hidden;
            buttomDebugSaveLoad.Visibility = Visibility.Hidden;
            Fonction.lireFichier();
            Fonction.trierTableau(Order);
            if (Order == 'A')
                Ascendant.IsChecked = true;
            else if (Order == 'D')
                Descendant.IsChecked = true;
            transfererTableauDansListBox();
        }

        ///////////////////////////////////////////////////////////////////////////////////////

        public void transfererTableauDansListBox()
        {

            Fonction.Cpt = 0;
            foreach (Personne P in Fonction.tblPersonnes)
            {
                if (P != null)
                    Fonction.Cpt++;
            }
            listBox.Items.Clear();
            for (int i = 0; i < Fonction.Cpt; i++)
            {
                listBox.Items.Add(Fonction.tblPersonnes[i].getNom() + " " + Fonction.tblPersonnes[i].getPrenom() + " " + Fonction.tblPersonnes[i].getDepense().ToString());
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////

        private void boutonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Données triées et enregistrées...");
            MessageBox.Show("Json Power! clicker sur le bouton Debug pour en savoir plus. (File save)");
            transfererTableauDansListBox();
            Fonction.enregistrerTableauDansFichier();
        }

        private void bottomAjouter_click(object sender, RoutedEventArgs e)
        {
            int cptTemp = Fonction.Cpt +1;
            if (cptTemp < 50 - 1)
            {
                Ajouter subWindow = new Ajouter();
                subWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Impossible d'ajouter, car le logiciel est limiter a 50 items dans la liste.");
            }
        }

        private bool visible = false;
        private void buttonDebug_click(object sender, RoutedEventArgs e)
        {
            texteboxDebug.Text = File.ReadAllText(@"..\save.json");
            if(visible == false)
            {
                texteboxDebug.Visibility = Visibility.Visible;
                buttomTxt2Json.Visibility = Visibility.Visible;
                labelDebug.Visibility = Visibility.Visible;
                buttomDebugSaveLoad.Visibility = Visibility.Visible;
                visible = true;
            }
            else
            {
                texteboxDebug.Visibility = Visibility.Hidden;
                buttomTxt2Json.Visibility = Visibility.Hidden;
                labelDebug.Visibility = Visibility.Hidden;
                buttomDebugSaveLoad.Visibility = Visibility.Hidden;
                visible = false;
            }
        }

        private void buttonRefresh_click(object sender, RoutedEventArgs e)
        {
            transfererTableauDansListBox();
            texteboxDebug.Text = File.ReadAllText(@"..\save.json");
        }

        private void buttonEnlever_click(object sender, RoutedEventArgs e)
        {
            int select;
            if (listBox.SelectedIndex == -1)
            {
                select = 0;
            }
            else
            {
                select = listBox.SelectedIndex;
            }
            for (int i = select; i < Fonction.Cpt; i++)
            {
                Fonction.tblPersonnes[i] = Fonction.tblPersonnes[i + 1];
                Fonction.tblPersonnes[i + 1] = null;
            }
            Fonction.Cpt = Fonction.Cpt - 1;
            transfererTableauDansListBox();
        }

        private void buttonLireFichier_click(object sender, RoutedEventArgs e)
        {
            Fonction.refreshTbl2Null();
            Fonction.lireFichier();
            transfererTableauDansListBox();
        }

        private void Ascendant_Checked(object sender, RoutedEventArgs e)
        {
            Fonction.trierTableau('A');
            transfererTableauDansListBox();
        }

        private void Descendant_Checked(object sender, RoutedEventArgs e)
        {
            Fonction.trierTableau('D');
            transfererTableauDansListBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void buttomDebugSaveLoad_Click(object sender, RoutedEventArgs e)
        {
            System.IO.File.WriteAllText(@"..\save.json", texteboxDebug.Text);
            Fonction.refreshTbl2Null();
            Fonction.lireFichier();
            transfererTableauDansListBox();
        }

        private void Button_Minimise(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void buttomTxt2Json_Click(object sender, RoutedEventArgs e)
        {
            Fonction.ConvertTxtToJson(Fonction.SelectFile("donnees.txt"));
        }
    }
}
/*Fonction.tblPersonnes[0] = new Personne("Cote", "Frederic", 2360);
Fonction.tblPersonnes[1] = new Personne("Lavoie", "Celine", 5627);
Fonction.tblPersonnes[2] = new Personne("Bergeron", "Francis", 1229);
Fonction.tblPersonnes[3] = new Personne("Dumais", "Arnaud", 3268);
Fonction.tblPersonnes[4] = new Personne("Emond", "Maxime", 7560);
Fonction.tblPersonnes[5] = new Personne("Noel", "Paolo", 2588);
Fonction.tblPersonnes[6] = new Personne("Plourde", "Raphael", 1250);
Fonction.tblPersonnes[7] = new Personne("Poitras", "Bobby", 5216);
Fonction.tblPersonnes[8] = new Personne("Gagnon", "Morgan", 1234);
Fonction.tblPersonnes[9] = new Personne("Gelinas", "Herve", 6548);
Fonction.tblPersonnes[10] = new Personne("Nibo", "Forundel", 3256);
Fonction.tblPersonnes[11] = new Personne("Tremblay", "Maxime", 5000);
Fonction.tblPersonnes[12] = new Personne("Tremblay", "Julie", 9000);
Fonction.tblPersonnes[13] = new Personne("Gauthier", "Antoine", 7564);
Fonction.tblPersonnes[14] = new Personne("Brisson", "Celine", 6523);
Fonction.tblPersonnes[15] = new Personne("Page", "Ann-Chloe", 8975);
Fonction.tblPersonnes[16] = new Personne("Gauthier", "Jonathan", 5467);
Fonction.tblPersonnes[17] = new Personne("Young", "Roger", 5000);
Fonction.tblPersonnes[18] = new Personne("Simard", "Mathieu", 4700);
Fonction.tblPersonnes[19] = new Personne("Hilton", "Alex", 3250);
Fonction.tblPersonnes[20] = new Personne("Lacroix", "Sebastien", 6550);
Fonction.tblPersonnes[21] = new Personne("Gelinas", "Timothe", 4350);
Fonction.tblPersonnes[22] = new Personne("Caron", "Marc-Andre", 2650);
Fonction.tblPersonnes[23] = new Personne("Deschenes", "Renald", 3000);
Fonction.tblPersonnes[24] = new Personne("Blais", "Mathieu", 2500);
Fonction.tblPersonnes[25] = new Personne("Chamberland", "Pauline", 3500);
Fonction.tblPersonnes[26] = new Personne("Gaudreault", "Stephanie", 1500);
Fonction.tblPersonnes[27] = new Personne("Tremblay", "Dany", 1600);
Fonction.tblPersonnes[28] = new Personne("Gauthier", "Jeanne-Mance", 2556);
Fonction.tblPersonnes[29] = new Personne("Tremblay", "Michael", 1500);
Fonction.tblPersonnes[30] = new Personne("Hudon", "Pierre", 1000);
Fonction.tblPersonnes[31] = new Personne("Boivin", "Louise", 6000);
Fonction.tblPersonnes[32] = new Personne("Regis", "Roger", 5400);
Fonction.tblPersonnes[33] = new Personne("Lavoie", "Francis", 8000);
Fonction.tblPersonnes[34] = new Personne("Gagnon", "Jean", 4300);
Fonction.tblPersonnes[35] = new Personne("Rubio", "Ricky", 1200);*/