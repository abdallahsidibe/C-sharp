using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFI2TP1_SIDIBE_ABDOULAYE
{
    class Etudiant:Personne
    {
        string Nom_Institution;
        int Numero_TD;

        //les constructeurs

        public Etudiant() : base()
        {

        }
        public Etudiant(string N, string P, Date Date_de_naissance, string Nom_Inst, int Num_TD) : base(N, P, Date_de_naissance)
        {
            Nom_Institution = Nom_Inst;
            Numero_TD = Num_TD;
        }

        //Methode de saisir

        public override void Saisir()
        {
            string c;

            base.Saisir();
            Console.Write(" Nom de L'institution : ");
            Nom_Institution = Console.ReadLine();
            Console.Write(" Numero de TD : ");
            c = Console.ReadLine();
            Numero_TD = Convert.ToInt32(c);

        }

        public override string ToString()
        {
            return base.ToString() + " " + Nom_Institution + " appartenant au TD numero " + Numero_TD;
        }

        //Methode afficher
        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine("  " + Nom_Institution + " appartenant au TD numero " + Numero_TD);

        }
    }
}
