using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_3fev
{
    class Validation
    {
        //##############Validation###############\\
        public static string nasValide(string assSocial)
        {
            //xxx xxx xxx
            assSocial = assSocial.Replace(" ", "");
            if (assSocial.Length == 9)
            {
                int numero;
                bool res = int.TryParse(assSocial, out numero);
                if (!res)
                {
                    assSocial = Convert.ToString(numero);
                    return assSocial;
                }
            }
            else
            {
                assSocial = null;
                //Console.WriteLine("Verifier le format");
            }
            return assSocial;
        }

        public static string telephoneValide(string telephone)
        {
            //+1 418 540 0949 // 1 418 540 0949 // 418 540 0949
            telephone = telephone.Replace(" ", "");
            telephone = telephone.Replace("+", "");
            if (telephone.Length == 9 || telephone.Length == 10)
            {
                int numero;
                bool res = int.TryParse(telephone, out numero);
                if (!res)
                {
                    telephone = Convert.ToString(numero);
                    return telephone;
                }
            }
            else
            {
                telephone = null;
                //Console.WriteLine("Verifier le format");
            }
            return telephone;
        }

        public static string dateValide(string jour, string mois, string annee, int minAns = 1000, int maxAns = 3000, int valid = 1)
        {
            string date = null;
            int panne = 0;
            int? error = null;

            if (int.TryParse(jour + mois + annee, out panne))
            {
                if (int.Parse(annee) >= minAns && int.Parse(annee) <= maxAns)
                {
                    string[] formats = {
                        "dd/MM/yyyy"
                    };
                    DateTime parsedTime;
                    if (valid == 0)
                    {
                        if (DateTime.TryParseExact(jour + "/" + mois + "/" + annee, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedTime))
                        {
                            date = Convert.ToString(parsedTime);
                            return date;
                        }
                        else { error = 0; }

                    }
                    if (valid == 1)
                    {
                        //Verification que la date est ultérieur a la date actuel

                        if (DateTime.TryParseExact(jour + "/" + mois + "/" + annee, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedTime))
                        {
                            DateTime now = DateTime.Now;
                            if (now < parsedTime)
                            {
                                date = Convert.ToString(parsedTime);
                                return date;
                            }
                            else { error = 1; }
                        }
                    }
                    if (valid == 2)
                    {
                        //Verification que la date est superieur a la date actuel

                        if (DateTime.TryParseExact(jour + "/" + mois + "/" + annee, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedTime))
                        {
                            DateTime now = DateTime.Now;
                            if (now > parsedTime)
                            {
                                date = Convert.ToString(parsedTime);
                                return date;
                            }
                            else { error = 2; }
                        }
                    }
                }
                else { error = 3; }
            }
            else { error = 0; }

            switch(error)
            {
                case 0:
                    {
                        System.Windows.MessageBox.Show("Verifier le format");
                        return date;
                    }
                case 1:
                    {
                        System.Windows.MessageBox.Show("Merci d'entrée une date ulterieur a la date actuel");
                        return date;
                    }
                case 2:
                    {
                        System.Windows.MessageBox.Show("Merci d'entrée une date superieur a la date actuel");
                        return date;
                    }
                case 3:
                    {
                        System.Windows.MessageBox.Show("Année invalide");
                        return date;
                    }
                default:
                    {
                        return date;
                    }
            }
        }
    }
}