using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFI2TP1_SIDIBE_ABDOULAYE
{
    class Date
    {
        public int Jour { get; set; }
        public int Mois { get; set; }
        public int Annee { get; set; }


        //declaration du constucteur par defaut pour les initialisation

        public Date()
        {
            Jour = 00;
            Mois = 00;
            Annee = 0000;
        }

        public Date(int j, int m, int a)
        {
            Jour = j;
            Mois = m;
            Annee = a;
        }

        //Methode de saisir

        public void Saisir()
        {
            string j;
            do
            {
                Console.WriteLine("donner le jour:");
                j = Console.ReadLine();
                Jour = Convert.ToInt32(j);

            } while (Jour > 31 || Jour < 0);

            string m;
            do
            {
                Console.WriteLine("donner le mois");
                m = Console.ReadLine();
                Mois = Convert.ToInt32(m);

            } while (Mois > 12 || Mois < 1);

            string a;
            do
            {
                Console.WriteLine("donner l'annee");
                a = Console.ReadLine();
                Annee = Convert.ToInt32(a);

            } while (Annee > 2020 || Annee < 1900);

        }


        public override string ToString()
        {
            return " la date est:" + Jour + " / " + Mois + " / " + Annee;
        }

        //Methode afficher

        public void Afficher()
        {
            Console.WriteLine(+Jour + "/" + Mois + "/" + Annee);
        }

        //Methode comparer
        public void Comparer(Date a, Date b)
        {
            if (a.Annee > b.Annee)
            {
                Console.WriteLine(a.Jour + "/" + a.Mois + "/" + a.Annee + " est superieur à " + b.Jour + "/" + b.Mois + "/" + b.Annee);
            }
            else if (a.Annee < b.Annee)
            {
                Console.WriteLine(a.Jour + "/" + a.Mois + "/" + a.Annee + " est inferieur à " + b.Jour + "/" + b.Mois + "/" + b.Annee);
            }
            else if (a.Annee == b.Annee && a.Mois > b.Mois)
            {
                Console.WriteLine(a.Jour + "/" + a.Mois + "/" + a.Annee + " est superieur à " + b.Jour + "/" + b.Mois + "/" + b.Annee);
            }
            else if (a.Annee == b.Annee && a.Mois < b.Mois)
            {
                Console.WriteLine(a.Jour + "/" + a.Mois + "/" + a.Annee + " est inferieur à " + b.Jour + "/" + b.Mois + "/" + b.Annee);
            }
            else if (a.Annee == b.Annee && a.Mois == b.Mois && a.Jour > b.Jour)
            {
                Console.WriteLine(a.Jour + "/" + a.Mois + "/" + a.Annee + " est superieur à " + b.Jour + "/" + b.Mois + "/" + b.Annee);
            }
            else if (a.Annee == b.Annee && a.Mois == b.Mois && a.Jour < b.Jour)
            {
                Console.WriteLine(a.Jour + "/" + a.Mois + "/" + a.Annee + " est inferieur à " + b.Jour + "/" + b.Mois + "/" + b.Annee);
            }

        }
    }

}