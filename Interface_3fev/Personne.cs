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

        public string nas { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string dateDeNaissance { get; set; }
        public double depense { get; set; }
        public statusEnum? status { get; set; }
        public sexeEnum? sexe { get; set; }


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
        public void setStatus(statusEnum? status)
        {
            this.status = status;
        }
        public void setSexe(sexeEnum? sexe)
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
            return status.ToString();
        }
        public string getSexe()
        {
            return sexe.ToString();
        }
        #endregion

        #region Fonction/Constructeur
        public Personne(string nom, string prenom, double depense)
        {
            setNom(nom);
            setPrenom(prenom);
            setDepense(depense);
        }

        public Personne(string nas, string nom, string prenom, string dateDeNaissance, double depense, statusEnum? status, sexeEnum? sexe)
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
