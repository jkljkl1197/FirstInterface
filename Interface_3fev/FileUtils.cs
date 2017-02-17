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

namespace Interface_3fev
{
    class FileUtils
    {

        public static int FileRead(string MyFile = @"..\fichier.txt")
        {
            string line;
            int NbWords = 0;
            string[] lineSplit = { "0" };
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(MyFile);

                while ((line = sr.ReadLine()) != null)
                {
                    lineSplit = line.Split(';');
                }
                
                foreach (string test in lineSplit)
                {
                    NbWords++;
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("On ne peut pas lire le fichier.");
                Console.WriteLine(e.Message);
            }
            return NbWords;
        }

        public static void FileWrite(string write, string MyFile = @"..\fichier.txt")
        {
            System.IO.StreamWriter sr = new System.IO.StreamWriter(MyFile);
            try
            {

                sr.WriteLine(write, false);

                sr.Close();
            }
            catch (Exception e)
            {
                sr.Close();
                MessageBox.Show("impossible d'écrire dans le fichier.: " + e.Message);
            }
        }

        public static bool FileCheck(string MyFile = @"..\fichier.txt", bool write = true)
        {
            bool FileExist = System.IO.File.Exists(MyFile);
            if (write == true)
            {
                Console.WriteLine(FileExist ? "File exists." : "File does not exist.");
            }
            return FileExist;
        }
    }
}
