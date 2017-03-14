using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_3fev.Parent
{
    class Etudiant : Personne
    {
        private string _programme;

        public string Programme
        {
            get { return _programme; }
            set { _programme = value; }
        }

        public Etudiant(string nom, string programme)
            : base(nom)//Appel du constructeur "de base" c'est à dire le constructeur de la classe Personne
        {
            this._programme = programme;
        }

        public override void SePresenter()
        {

        }

        public Etudiant()
        {

        }
    }
}
