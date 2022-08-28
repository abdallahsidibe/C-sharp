using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace PERSONNE
{
    class Program
    {
        static void Main(string[] args)
        {
            int Inv;
            string nom, prenom, dat;
            Console.WriteLine("Donner l'identifiant : ");
            Inv = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Donner le nom: ");
            nom = Console.ReadLine();

            Console.WriteLine("Donner le  prenom: ");
            prenom = Console.ReadLine();

            Console.WriteLine("Donner la date naissance : ");
            dat = Console.ReadLine();
            DAL_Personne.AjoutPersonne(Inv, nom, prenom, dat);
           
            DAL_Personne.AfficherPersonne();

            Console.Read();

        }
    }
}
