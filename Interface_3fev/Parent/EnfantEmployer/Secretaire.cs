﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_3fev.Parent.EnfantEmployer
{
    class Secretaire : Employe
    {
        private string _race;
        
        public string Race
        {
            get { return _race; }
            set { _race = value; }
        }
    }
}
