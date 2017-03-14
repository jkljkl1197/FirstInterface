using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_3fev {
    public class Personne {
        public enum statusEnum {
            Celibataire,
            Marie,
            Veuf,
            Divorce
        };
        public enum sexeEnum {
            Homme,
            Femme
        };

        # region Get/Set
        public string Nas {
            get;
            set;
        }
        public string Nom {
            get;
            set;
        }
        public string Prenom {
            get;
            set;
        }
        public string DateDeNaissance {
            get;
            set;
        }
        public double ? Depense {
            get;
            set;
        }
        public statusEnum ? Status {
            get;
            set;
        }
        public sexeEnum ? Sexe {
            get;
            set;
        }
        # endregion

        # region Fonction / Constructeur
        public Personne(string nom, string prenom, double ? depense) {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Depense = depense;
        }

        public Personne(string nas, string nom, string prenom, string dateDeNaissance, double ? depense, statusEnum ? status, sexeEnum ? sexe) {
            this.Nas = nas;
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateDeNaissance = dateDeNaissance;
            this.Depense = depense;
            this.Status = status;
            this.Sexe = sexe;
        }

        public Personne(Personne p): this(p.Nom, p.Prenom, p.Depense) {
            //constructeur de copy
        }
        public Personne(): this("", "", 0) {
            //constructeur de copy
        }
        # endregion
    }


}