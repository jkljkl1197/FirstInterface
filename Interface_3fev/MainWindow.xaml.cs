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
            InitializeComponent();
            SolidColorBrush myBrush = (SolidColorBrush)this.TryFindResource("buttomMinimise");

            if (myBrush != null)
            {
                myBrush.Color = Colors.Yellow;
            }
            Fonction.lireFichier();
            transfererTableauDansListBox();
        }

        #region Button
        private void Button_LireFichier_click(object sender, RoutedEventArgs e)
        {
            Fonction.refreshTbl2Null();
            Fonction.lireFichier();
            transfererTableauDansListBox();
            Ascendant.IsChecked = false;
            Descendant.IsChecked = false;
        }

        private void Button_Enlever_click(object sender, RoutedEventArgs e)
        {
            int select;
            if (listBox.SelectedIndex == -1)
                select = 0;
            else
                select = listBox.SelectedIndex;

            for (int i = select; i < Fonction.Cpt; i++)
            {
                Fonction.tblPersonnes[i] = Fonction.tblPersonnes[i + 1];
                Fonction.tblPersonnes[i + 1] = null;
            }
            Fonction.Cpt = Fonction.Cpt - 1;
            transfererTableauDansListBox();
        }

        private bool visible = false;
        private void Button_Debug_click(object sender, RoutedEventArgs e)
        {
            texteboxDebug.Text = File.ReadAllText(@"..\save.json");
            if (visible == false)
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

        private void Button_Refresh_click(object sender, RoutedEventArgs e)
        {
            transfererTableauDansListBox();
            texteboxDebug.Text = File.ReadAllText(@"..\save.json");
        }

        private void Button_Ajouter_click(object sender, RoutedEventArgs e)
        {
            int cptTemp = Fonction.Cpt + 1;
            if (cptTemp < 50 - 1)
            {
                Ajouter subWindow = new Ajouter();
                subWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Impossible d'ajouter, car le logiciel est limiter a 50 items dans la liste.");
            }
            Ascendant.IsChecked = false;
            Descendant.IsChecked = false;
        }

        private void Button_Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Json Power! clicker sur le bouton Debug pour en voir plus. (File save)");
            transfererTableauDansListBox();
            Fonction.enregistrerTableauDansFichier();
        }
        #endregion

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
                listBox.Items.Add(Fonction.tblPersonnes[i].getNas() + " " + Fonction.tblPersonnes[i].getNom() + " " + Fonction.tblPersonnes[i].getPrenom() + " " + Fonction.tblPersonnes[i].getDateNaissance() + " " + Fonction.tblPersonnes[i].getDepense().ToString() + " " + Fonction.tblPersonnes[i].getStatus() + " " + Fonction.tblPersonnes[i].getSexe());
            }
        }

        private void Ascendant_Checked(object sender, RoutedEventArgs e)
        {
            char Order = 'A';
            Fonction.trierTableau(Order);
            Ascendant.IsChecked = true;
            Descendant.IsChecked = false;
            transfererTableauDansListBox();
        }

        private void Descendant_Checked(object sender, RoutedEventArgs e)
        {
            char Order = 'D';
            Fonction.trierTableau(Order);
            Ascendant.IsChecked = false;
            Descendant.IsChecked = true;
            transfererTableauDansListBox();
        }

        #region HiddenButton
        private void Button_Txt2Json_Click(object sender, RoutedEventArgs e)
        {
            Fonction.refreshTbl2Null();
            Fonction.ConvertTxtToJson(Fonction.SelectFile("donnees.txt"));
            Ascendant.IsChecked = false;
            Descendant.IsChecked = false;
        }

        private void Button_DebugSaveLoad_Click(object sender, RoutedEventArgs e)
        {
            System.IO.File.WriteAllText(@"..\save.json", texteboxDebug.Text);
            Fonction.refreshTbl2Null();
            Fonction.lireFichier();
            transfererTableauDansListBox();
            Ascendant.IsChecked = false;
            Descendant.IsChecked = false;
        }
        #endregion

        #region NormalButton
        private void Button_Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Minimise(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Settings(object sender, RoutedEventArgs e)
        {
            About subWindow = new About();
            subWindow.ShowDialog();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        #endregion
    }
}