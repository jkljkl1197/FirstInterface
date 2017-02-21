using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_3fev
{
    public class Personne
    {
        public string nas { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string dateDeNaissance { get; set; }
        public double depense { get; set; }
        public string status { get; set; }
        public string sexe { get; set; }

        #region Set/Get
        public void setNas(string nas)
        {
            this.nas = nas;
        }
        public void setNom(string nom)
        {
            this.nom = nom;
        }
        public void setPrenom(string prenom)
        {
            this.prenom = prenom;
        }
        public void setDateDeNaissance(string dateDeNaissance)
        {
            this.dateDeNaissance = dateDeNaissance;
        }
        public void setDepense(double depense)
        {
            this.depense = depense;
        }
        public void setStatus(string status)
        {
            this.status = status;
        }
        public void setSexe(string sexe)
        {
            this.sexe = sexe;
        }

        public string getNas()
        {
            return nas;
        }
        public string getNom()
        {
            return nom;
        }
        public string getPrenom()
        {
            return prenom;
        }
        public string getDateNaissance()
        {
            return dateDeNaissance;
        }
        public double getDepense()
        {
            return depense;
        }
        public string getStatus()
        {
            return status;
        }
        public string getSexe()
        {
            return sexe;
        }
        #endregion

        #region Fonction/Constructeur
        public Personne(string nom, string prenom, double depense)
        {
            setNom(nom);
            setPrenom(prenom);
            setDepense(depense);
        }

        public Personne(string nas, string nom, string prenom, string dateDeNaissance, double depense, string status, string sexe)
        {
            setNas(nas);
            setNom(nom);
            setPrenom(prenom);
            setDateDeNaissance(dateDeNaissance);
            setDepense(depense);
            setStatus(status);
            setSexe(sexe);
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
