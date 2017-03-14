using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_3fev.Parent
{
    class Employe : Personne
    {

        private double _salaireBase;
        private string _dateEmbauche;


        public double SalaireBase
        {

            get { return _salaireBase; }

            set { _salaireBase = Convert.ToDouble(value); }

        }

        public string DateEmbauche
        {

            get { return _dateEmbauche; }

            set { _dateEmbauche = value; }

        }

        
        public Employe(string nom, double salaireBase, string dateEmbauche)

            : base(nom)//Appel du constructeur "de base" c'est à dire le constructeur de la classe Personne
        {

            this._salaireBase = salaireBase;
            this._dateEmbauche = dateEmbauche;

        }

        public double AugmenterSalaire(double pourcentage)
        {
            return (((100 * _salaireBase) / pourcentage) + _salaireBase);
        }

        public override void SePresenter()
        {

        }

        public Employe()
        {

        }

    }
}
