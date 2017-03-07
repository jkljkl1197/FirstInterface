using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_3fev
{
    public class Personne
    {
        public enum statusEnum { Celibataire, Marie, Veuf, Divorce };
        public enum sexeEnum { Homme, Femme };

        public string Nas { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DateDeNaissance { get; set; }
        public double? Depense { get; set; }
        public statusEnum? Status { get; set; }
        public sexeEnum? Sexe { get; set; }


        #region Set/Get
        public void setNas(string nas)
        {
            this.Nas = nas;
        }
        public void setNom(string nom)
        {
            this.Nom = nom;
        }
        public void setPrenom(string prenom)
        {
            this.Prenom = prenom;
        }
        public void setDateDeNaissance(string dateDeNaissance)
        {
            this.DateDeNaissance = dateDeNaissance;
        }
        public void setDepense(double? depense)
        {
            this.Depense = depense;
        }
        public void setStatus(statusEnum? status)
        {
            this.Status = status;
        }
        public void setSexe(sexeEnum? sexe)
        {
            this.Sexe = sexe;
        }

        public string getNas()
        {
            return Nas;
        }
        public string getNom()
        {
            return Nom;
        }
        public string getPrenom()
        {
            return Prenom;
        }
        public string getDateNaissance()
        {
            return DateDeNaissance;
        }
        public double? getDepense()
        {
            return Depense;
        }
        public string getStatus()
        {
            return Status.ToString();
        }
        public string getSexe()
        {
            return Sexe.ToString();
        }
        #endregion

        #region Fonction/Constructeur
        public Personne(string nom, string prenom, double? depense)
        {
            setNom(nom);
            setPrenom(prenom);
            setDepense(depense);
        }

        public Personne(string nas, string nom, string prenom, string dateDeNaissance, double? depense, statusEnum? status, sexeEnum? sexe)
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
