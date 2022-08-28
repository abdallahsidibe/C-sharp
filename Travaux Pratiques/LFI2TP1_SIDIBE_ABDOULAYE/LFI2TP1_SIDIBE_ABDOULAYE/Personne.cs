using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFI2TP1_SIDIBE_ABDOULAYE
{
    class Personne
    {
        string Nom;
        string Prenom;
        public Date Date_de_naissance;

        //les constructeurs

        public Personne()
        {
            Date_de_naissance = new Date();
        }

        public Personne(string N, string P, Date D)
        {
            Nom = N;
            Prenom = P;
            Date_de_naissance = new Date(Date_de_naissance.Jour, Date_de_naissance.Mois, Date_de_naissance.Annee);

        }

        //Methode de saisir

        public virtual void Saisir()
        {
            Console.Write(" Nom : ");
            Nom = Console.ReadLine();
            Console.Write(" Prenom : ");
            Prenom = Console.ReadLine();
            Console.WriteLine("\n\t Date de naissance \n");
            Date_de_naissance.Saisir();

        }

        public override string ToString()
        {
            return " la Date est:" + Nom + " " + Prenom + " Né le " + Date_de_naissance;
        }

       // Methode afficher
        public virtual void Afficher()
        {
            Console.Write("la personne est: " + Nom + " " + Prenom + " Né le ");
            Date_de_naissance.Afficher();

        }
    }
}
