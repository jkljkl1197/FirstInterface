using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Globalization;

namespace Interface_3fev
{
    class Fonction
    {
        public static Personne[] tblPersonnes = new Personne[50];
        public static int Cpt = 0;

        public static string lireFichier(string SelectedFile = @"..\save.json") // lecture du fichier et remisage dans le tableau tab et compte dans cpt
        {
            string texte = "";
                try
                {
                    JArray jArray = JArray.Parse(File.ReadAllText(SelectedFile));

                    for (int i = 0; i < jArray.ToArray().Length; i++)
                    {
                        JToken jPersonne = jArray[i];

                        string nas = (string)jPersonne["Nas"];
                        string nom = (string)jPersonne["Nom"];
                        string prenom = (string)jPersonne["Prenom"];
                        string dateDeNaissance = (string)jPersonne["DateDeNaissance"];
                        double depense = (double)jPersonne["Depense"];
                        string status = (string)jPersonne["Status"];
                        string sexe = (string)jPersonne["Sexe"];

                        Personne.statusEnum? statusEnum = null;
                        Personne.sexeEnum? sexeEnum = null;

                        if (status.Equals(Personne.statusEnum.Celibataire) || status == "0")
                        {
                            statusEnum = Personne.statusEnum.Celibataire;
                        }
                        else if (status.Equals(Personne.statusEnum.Marie) || status == "1")
                        {
                            statusEnum = Personne.statusEnum.Marie;
                        }
                        else if (status.Equals(Personne.statusEnum.Veuf) || status == "2")
                        {
                            statusEnum = Personne.statusEnum.Veuf;
                        }
                        else if (status.Equals(Personne.statusEnum.Divorce) || status == "3")
                        {
                            statusEnum = Personne.statusEnum.Divorce;
                        }

                        if (sexe.Equals(Personne.sexeEnum.Homme) || status == "0")
                        {
                            sexeEnum = Personne.sexeEnum.Homme;
                        }
                        else if (sexe.Equals(Personne.sexeEnum.Femme) || status == "1")
                        {
                            sexeEnum = Personne.sexeEnum.Femme;
                        }

                        if (nom != null && prenom != null)
                        {
                            if(nas != null && dateDeNaissance != null && status != null && sexe != null)
                            {
                                Fonction.tblPersonnes[i] = new Personne(nas, nom, prenom, dateDeNaissance, depense, statusEnum, sexeEnum);
                            }
                            else
                            {
                                Fonction.tblPersonnes[i] = new Personne(nom, prenom, depense);
                            }
                        }
                        Cpt++;
                    }
                }
                catch
                {

                }
            return texte;
        }

        public static string SelectFile(string defaultFileName = "Document", string defaultExt = ".txt", string filterExt = "Text documents (.txt)|*.txt", string InitialDirectory = null)
        {
            string selectedFileName = null;

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            if (InitialDirectory == null)
            {
                InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            }
            dlg.InitialDirectory = InitialDirectory;
            dlg.FileName = defaultFileName; // Default file name
            dlg.DefaultExt = defaultExt; // Default file extension
            dlg.Filter = filterExt; // Filter files by extension

            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                selectedFileName = dlg.FileName;
            }

            return selectedFileName;
        }

        public static string SaveFile(string defaultFileName = "Document", string defaultExt = ".txt", string filterExt = "Text documents (.txt)|*.txt", string InitialDirectory = null)
        {
            string selectedFileName = null;
            
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            if (InitialDirectory == null)
            {
                InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            }
            dlg.InitialDirectory = InitialDirectory;
            dlg.FileName = defaultFileName; // Default file name
            dlg.DefaultExt = defaultExt; // Default file extension
            dlg.Filter = filterExt; // Filter files by extension

            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Save document
                selectedFileName = dlg.FileName;
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
                        if (boiteASplit.Length == 7)
                        {
                            Personne.statusEnum? statusEnum = null;
                            Personne.sexeEnum? sexeEnum = null;

                            if (boiteASplit[5].Equals(Personne.statusEnum.Celibataire) || boiteASplit[5] == "0")
                            {
                                statusEnum = Personne.statusEnum.Celibataire;
                            }
                            else if (boiteASplit[5].Equals(Personne.statusEnum.Marie) || boiteASplit[5] == "1")
                            {
                                statusEnum = Personne.statusEnum.Marie;
                            }
                            else if (boiteASplit[5].Equals(Personne.statusEnum.Veuf) || boiteASplit[5] == "2")
                            {
                                statusEnum = Personne.statusEnum.Veuf;
                            }
                            else if (boiteASplit[5].Equals(Personne.statusEnum.Divorce) || boiteASplit[5] == "3")
                            {
                                statusEnum = Personne.statusEnum.Divorce;
                            }

                            if (boiteASplit[6].Equals(Personne.sexeEnum.Homme) || boiteASplit[6] == "0")
                            {
                                sexeEnum = Personne.sexeEnum.Homme;
                            }
                            else if (boiteASplit[6].Equals(Personne.sexeEnum.Femme) || boiteASplit[5] == "1")
                            {
                                sexeEnum = Personne.sexeEnum.Femme;
                            }

                            tblPersonnesTemp[CptTemp] = new Personne(boiteASplit[3], boiteASplit[0], boiteASplit[1], boiteASplit[4], Convert.ToDouble(boiteASplit[2]), statusEnum, sexeEnum);
                        }
                        else if (boiteASplit.Length == 3)
                        {
                            tblPersonnesTemp[CptTemp] = new Personne(boiteASplit[0], boiteASplit[1], Convert.ToDouble(boiteASplit[2]));
                        }
                        line = sr.ReadLine();
                        CptTemp++;
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Il y a plus de 50 ligne dans le fichier [Limite du tableau depasser].");
                    }

                    tblPersonnes = tblPersonnesTemp;
                }
                sr.Close();
            }
            catch
            {

            }
        }

        public static string RemoveDiacritics(String s)
        {
            String normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                Char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
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

        public static void enregistrerTableauDansFichier(string selectSave = @"..\save.json")
        {

            System.IO.File.WriteAllText(selectSave, Fonction.getJson());

        }
    }
}
