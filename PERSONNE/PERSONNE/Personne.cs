using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERSONNE
{
    class Personne
    {
        public int id { get; set; }
        public string nom { get; set; }

        public string prenom { get; set; }

        public string datenaiss { get; set; }
        public Personne(int i, string n, string p, string d)
        {
            id = i;
            nom = n;
            prenom = p;
            datenaiss = d;
        }
        public Personne()
        {
        }
    }
}
