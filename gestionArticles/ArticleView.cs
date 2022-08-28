using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class ArticleView
    {
        public static void Show(Article a)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Reference=" + a.Reference);
            Console.WriteLine("la désignation=" + a.Designation);
            Console.WriteLine("le prix=" + a.Prix);
        }
        public static void Show(List<Article> LesArticles)
        {
            foreach (Article a in LesArticles)
                Show(a);
        }
        public static Article GetArticleFormUser()
        {
            Console.Write("donner la reference. ");
            int Reference = int.Parse(Console.ReadLine());
            Console.Write("donner la designation. ");
            string designation = Console.ReadLine();
            Console.Write("donner le prix. ");
            float prix = Single.Parse(Console.ReadLine());

            return (new Article(Reference, designation, prix));
        }
        public static void CommandeAjouter()
        {
            ArticleDAL.Add(GetArticleFormUser());
        }
        public static void CommandeSupprimer()
        {
            Console.Write("donner la reference. ");
            int Ref = int.Parse(Console.ReadLine());
            ArticleDAL.Delete(Ref);
        }
        public static void CommandeModifier()
        {
            Console.Write("donner la reference. ");
            int Ref = int.Parse(Console.ReadLine());
            ArticleDAL.Update(Ref, GetArticleFormUser());
        }
        public static void CommandeChercherParReference()
        {
            Console.Write("donner la reference. ");
            int Ref = int.Parse(Console.ReadLine());
            Article a = ArticleDAL.SelectByRef(Ref);
            if (a != null)
                 Show(a);
            else
                Console.WriteLine("reference incorrect");

        }
        public static void CommandeAfficherTout()
        {
            List<Article> l = ArticleDAL.SelectAll();
            if (l != null)
                Show(l);
            else
                Console.WriteLine("base vide");

        }
        public static void Menu()
        {
            string Db = @"C:\Users\De Bouaki\Documents\Database3.accdb";
           
            bool Quit = false;
            
            
                ArticleDAL.ConnectTo(Db);
                do
                {
                    int Reponse;
                    Console.WriteLine("\n\n.............");
                    Console.WriteLine(" Menu principal");
                    Console.WriteLine(".................");
                    Console.WriteLine("Tapez 1 pour afficher tout");
                    Console.WriteLine("Tapez 2 pour ajouter un Article");
                    Console.WriteLine("Tapez 3 pour Supprimer un Article ");
                    Console.WriteLine("Tapez 4 pour Modifier un Article");
                    Console.WriteLine("Tapez 5 pour Rechercher par Reference");
                    Console.WriteLine("Tapez  pour Quitter");
                    Reponse = Int32.Parse(Console.ReadLine());
                    switch (Reponse)
                    {
                        case 1:
                            CommandeAfficherTout();
                            break;
                        case 2:
                            CommandeAjouter();
                            break;
                        case 3:
                           CommandeSupprimer();
                            break;
                        case 4:
                            CommandeModifier();
                            break;
                        case 5:
                            CommandeChercherParReference();
                            break;


                        case 6:
                            Quit = true;
                            break;

                    }
                } while (Quit != true);
            
        }
    }
}
