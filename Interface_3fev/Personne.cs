using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_3fev
{

    public abstract class Personne
    {
        private string _nom;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public Personne() : this("Skywalker") { }

        public Personne(string nom)
        {
            this._nom = nom;
        }

        public abstract void SePresenter();

        public Personne(Personne p)
            : this(p._nom)
        {
            //constructeur de copy
        }

        public void AfficherDescription()
        {
            System.Windows.MessageBox.Show("je suis la class Personne");
        }
    }
}