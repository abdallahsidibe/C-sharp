using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFI2TP1_SIDIBE_ABDOULAYE
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int choix;
            string ch, t;

            Date d1 = new Date();
            Date d2 = new Date();
            Date d3 = new Date();
            Personne P = new Personne();
            Etudiant E = new Etudiant();
            Groupe G = new Groupe();

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("..........MENU...........");
                Console.WriteLine("\t 1. Date de naissance ");
                Console.WriteLine("\t 2. Personne ");
                Console.WriteLine("\t 3. Etudiant ");
                Console.WriteLine("\t 4. Groupe Etudiant ");
                Console.WriteLine("\t 5. Quitter");
                t = Console.ReadLine();
                choix = Convert.ToInt32(t);

                switch (choix)
                {
                    case 1:
                        {
                            int ds = 0;
                            
                            do
                            {
                                Console.WriteLine("\n \t \" DATE DE NAISSANCE \"  ");
                                Console.WriteLine("\t\t  1. Saisie simple et affichage ");
                                Console.WriteLine("\t\t  2. Saisie et comparaison ");
                                Console.WriteLine("\t\t  3. Retour au menu ");
                                ch = Console.ReadLine();
                                ds = Convert.ToInt32(ch);

                                switch (ds)
                                {
                                    case 1:
                                        d1.Saisir();
                                        Console.Write(" La date de naissance est : ");
                                        d1.Afficher();
                                        break;
                                    case 2:
                                        Console.WriteLine(" Saisir la premiere date : ");
                                        d1.Saisir();
                                        Console.WriteLine();
                                        Console.WriteLine(" Saisir la deuxieme date : ");
                                        d2.Saisir();
                                        Console.Write(" La premiere date est : ");
                                        d1.Afficher();
                                        Console.Write(" La deuxieme date est : ");
                                        d2.Afficher();
                                        Console.WriteLine();
                                        d3.Comparer(d1, d2);
                                        break;
                                    default:
                                        break;
                                }

                            } while (ds != 3);

                        }
                        break;

                    case 2:
                        {
                           
                            Console.WriteLine("\n\t  \" PERSONNE \"  \n ");
                            P.Saisir();
                            Console.WriteLine();
                            P.Afficher();
                        }
                        break;
                    case 3:
                        {
                            
                            Console.WriteLine("\n\t  \" ETUDIANT  \"  \n");
                            E.Saisir();
                            Console.WriteLine();
                            E.Afficher();

                            break;
                        }
                    case 4:
                        {
                            
                            Console.WriteLine("\n\t \" GROUPE ETUDIANT  \"  \n ");
                            G.Saisir();
                            Console.WriteLine();
                            G.Trier();
                            G.Affichage();
                        }
                        break;
                    case 5:
                        Console.WriteLine("\n\tFIN DU PROGRAMME AU REVOIR!!!\n ");
                        break;
                }

            } while (choix != 5);

        }
    }
}
