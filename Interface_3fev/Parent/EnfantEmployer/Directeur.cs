using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_3fev.Parent.EnfantEmployer
{
    class Directeur : Employe
    {
        private double _bonus;

        public double Bonus
        {
            get { return _bonus; }
            set { _bonus = value; }
        }
    }
}
