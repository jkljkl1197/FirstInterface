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
                telephone = "0";
                //Console.WriteLine("Verifier le format");
            }
            return telephone;
        }

        public static string dateValide(string jour, string mois, string annee, int minAns = 1000, int maxAns = 3000, int valid = 1)
        {
            string date;
            int panne = 0;
            if (int.TryParse(jour + mois + annee, out panne))
            {
                if (int.Parse(annee) >= minAns && int.Parse(annee) <= maxAns)
                {
                    string[] formats = { "dd/MM/yyyy" };
                    DateTime parsedTime;
                    if (valid == 0)
                    {
                        if (DateTime.TryParseExact(jour + "/" + mois + "/" + annee, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedTime))
                        {
                            date = Convert.ToString(parsedTime);
                            return date;
                        }
                        else
                        {
                            date = "0";
                            //Console.WriteLine("Verifier le format");
                        }
                    }
                    if (valid == 1)
                    {
                        //Verification de la date ulterieur a la date actuel

                        if (DateTime.TryParseExact(jour + "/" + mois + "/" + annee, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedTime))
                        {
                            DateTime now = DateTime.Now;
                            if (now < parsedTime)
                            {
                                date = Convert.ToString(parsedTime);
                                return date;
                            }
                            else
                            {
                                date = "0";
                                //Console.WriteLine("Merci d'entrée une date ulterieur");
                            }
                        }
                    }
                    if (valid == 2)
                    {
                        //Verification de la date ulterieur a la date actuel

                        if (DateTime.TryParseExact(jour + "/" + mois + "/" + annee, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedTime))
                        {
                            DateTime now = DateTime.Now;
                            if (now > parsedTime)
                            {
                                date = Convert.ToString(parsedTime);
                                return date;
                            }
                            else
                            {
                                date = "0";
                                //Console.WriteLine("Merci d'entrée une date ulterieur");
                            }
                        }
                    }
                }
                else
                {
                    date = "0";
                    //Console.WriteLine("année invalide");
                }
            }
            else
            {
                date = "0";
                //Console.WriteLine("Verifier le format");
            }
            return "0";
        }
    }
}
