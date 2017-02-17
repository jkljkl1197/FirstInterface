using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_3fev
{
    public class Personne
    {
        public string nom { get; set; }
        public string prenom { get; set; }
        public double depense { get; set; }

        #region Set/Get
        public void setNom(string nom)
        {
            this.nom = nom;
        }
        public void setPrenom(string prenom)
        {
            this.prenom = prenom;
        }
        public void setDepense(double depense)
        {
            this.depense = depense;
        }

        public string getNom()
        {
            return nom;
        }
        public string getPrenom()
        {
            return prenom;
        }
        public double getDepense()
        {
            return depense;
        }
        #endregion

        #region Fonction/Constructeur
        public Personne(string nom, string prenom, double depense)
        {
            setNom(nom);
            setPrenom(prenom);
            setDepense(depense);
        }

        public Personne(Personne p)
            : this(p.getNom(), p.getPrenom(), p.getDepense())
        { 
            //constructeur de copy
        }
        public Personne()
            : this("", "", 0)
        {
            //constructeur de copy
        }
        #endregion
    }


}
