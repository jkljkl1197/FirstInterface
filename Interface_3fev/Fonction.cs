using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Interface_3fev
{
    class Fonction
    {
        public static Personne[] tblPersonnes = new Personne[50];
        public static string nomFichier = @"../fichier.txt";
        public static int Cpt = 0;

        public static string lireFichier(bool type = true, string SelectedFile = "") // lecture du fichier et remisage dans le tableau tab et compte dans cpt
        {
            string texte = "";
            if (type == true)
            {
                try
                {
                    JArray jArray = JArray.Parse(File.ReadAllText(@"..\save.json"));

                    for (int i = 0; i < jArray.ToArray().Length; i++)
                    {
                        /*
                             "nas": "Test",
                             "nom": "Cote",
                             "prenom": "Frederic",
                             "dateDeNaissance": "Test1",
                             "depense": 2360.0,
                             "status": "Test2",
                             "sexe": "Test3"
                         */
                        JToken jPersonne = jArray[i];

                        string nas = (string)jPersonne["nas"];
                        string nom = (string)jPersonne["nom"];
                        string prenom = (string)jPersonne["prenom"];
                        string dateDeNaissance = (string)jPersonne["dateDeNaissance"];
                        double depense = (double)jPersonne["depense"];
                        string status = (string)jPersonne["status"];
                        string sexe = (string)jPersonne["sexe"];

                        if(nas != null && dateDeNaissance != null && status != null && sexe != null)
                        {
                            Fonction.tblPersonnes[i] = new Personne(nas, nom, prenom, dateDeNaissance, depense, status, sexe);
                        }
                        else
                        {
                            Fonction.tblPersonnes[i] = new Personne(nom, prenom, depense);
                        }
                        Cpt++;
                    }
                }
                catch
                {

                }
            }
            else
            {
                int CptTemp = 0;

                try
                {
                    StreamReader sr = new StreamReader(SelectedFile);
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        texte += line + "\n";
                        line = sr.ReadLine();
                        CptTemp++;
                    }
                    sr.Close();
                }
                catch
                {

                }
            }
            return texte;
        }

        public static string SelectFile(string defaultFileName = "Document", string defaultExt = ".txt", string filterExt = "Text documents (.txt)|*.txt")
        {
            string selectedFileName = "";

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = defaultFileName; // Default file name
            dlg.DefaultExt = defaultExt; // Default file extension
            dlg.Filter = filterExt; // Filter files by extension

            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                selectedFileName = dlg.FileName;
                //System.Windows.MessageBox.Show(selectedFileName);
            }

            return selectedFileName;
        }

        public static void ConvertTxtToJson(string SelectedFile)
        {
            Personne[] tblPersonnesTemp = new Personne[50];
            int CptTemp = 0;

            try
            {
                StreamReader sr = new StreamReader(SelectedFile);
                string line = sr.ReadLine();
                while (line != null)
                {
                    if(CptTemp < 50)
                    {
                        string[] boiteASplit = line.Split(' ');
                        if(boiteASplit.Length == 3)
                        {
                            tblPersonnesTemp[CptTemp] = new Personne(boiteASplit[0], boiteASplit[1], Convert.ToDouble(boiteASplit[2]));
                        }
                        else if (boiteASplit.Length == 7)
                        {
                            tblPersonnesTemp[CptTemp] = new Personne(boiteASplit[3], boiteASplit[0], boiteASplit[1], boiteASplit[4], Convert.ToDouble(boiteASplit[2]), boiteASplit[5], boiteASplit[6]);
                        }
                        line = sr.ReadLine();
                        CptTemp++;
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Il y a plus de 50 ligne dans le fichier [Limite du tableau depasser].");
                    }
                }
                sr.Close();
            }
            catch
            {

            }

            System.IO.File.WriteAllText(@"..\save.json", Newtonsoft.Json.JsonConvert.SerializeObject(tblPersonnesTemp, Newtonsoft.Json.Formatting.Indented));
            lireFichier();
        }

        public static string getJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(tblPersonnes, Newtonsoft.Json.Formatting.Indented);
        }

        public static void refreshTbl2Null()
        {
            for (int i = 0; i < tblPersonnes.Length; i++)
            {
                tblPersonnes[i] = null;
            }
        }

        public static void trierTableau(char AscDesc)
        {
            bool tableauEnOrdre;
            do
            {
                tableauEnOrdre = true;

                for (int i = 0; i < Cpt - 1; i++)
                    if (tblPersonnes[i].getNom().CompareTo(tblPersonnes[i + 1].getNom()) > 0 && AscDesc == 'A'
                    || tblPersonnes[i].getNom().CompareTo(tblPersonnes[i + 1].getNom()) < 0 && AscDesc == 'D')
                    {

                        Personne temp = tblPersonnes[i];

                        tblPersonnes[i] = tblPersonnes[i + 1];
                        tblPersonnes[i + 1] = temp;

                        tableauEnOrdre = false;
                    }
            }
            while (!tableauEnOrdre);
        }

        public static void enregistrerTableauDansFichier()
        {

            System.IO.File.WriteAllText(@"..\save.json", Fonction.getJson());

        }
    }
}
