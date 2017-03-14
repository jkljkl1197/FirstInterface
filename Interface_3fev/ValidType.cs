using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Interface_3fev
{
    class ValidType
    {
        //##############Valide type##############\\

        public static char? charValide(string console)
        {
            console = console.Replace(" ", "");
            console = console.ToUpper(CultureInfo.InvariantCulture);
            char charValid;
            bool res = char.TryParse(console, out charValid);
            if (res)
            {
                return charValid;
            }
            else
            {
                //Console.WriteLine("invalide");
                System.Windows.MessageBox.Show("Caractere Invalide");
                return null;
            }
        }

        public static int? intValide(string console)
        {
            console = console.Replace(" ", "");
            int numero;
            bool res = int.TryParse(console, out numero);
            if (res)
            {
                return numero;
            }
            else
            {
                //Console.WriteLine("invalide");
                System.Windows.MessageBox.Show("Entier Invalide");
                return null;
            }
        }

        public static double? doubleValide(string console)
        {
            console = console.Replace(" ", "");
            double numero;
            bool res = double.TryParse(console, out numero);
            if (res)
            {
                return numero;
            }
            else
            {
                //Console.WriteLine("invalide");
                System.Windows.MessageBox.Show("Nombre réel Invalide");
                return null;
            }
        }
    }
}