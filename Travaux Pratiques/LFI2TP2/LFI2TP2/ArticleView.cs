using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LFI2TP2
{
    class ArticleView
    {
        public static void Show(Article a)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("reference:" + a.Reference);
            Console.WriteLine("designation:" + a.Designation);
            Console.WriteLine("prix:" + a.Prix);

        }

        public static void Show(List<Article> LesArticles)
        {

            foreach (Article a in LesArticles)

                Show(a);

        }
        public static Article GetArticleFromUser()
        {
            Console.Write(" Donner la reference:");
            int Ref = Int32.Parse(Console.ReadLine());
            Console.Write(" Donner la designation:");
            string des = Console.ReadLine();
            Console.Write(" Donner le prix:");
            float prix = Single.Parse(Console.ReadLine());

            return (new Article(Ref, des, prix));
        }
        public static void CommandeAjouter()
        {
            ArticleDAL.Add(GetArticleFromUser());
        }
        public static void CommandeSupprimer()
        {
            Console.Write(" Donner la reference:");
            int Ref = Int32.Parse(Console.ReadLine());
            ArticleDAL.Delete(Ref);
        }
        public static void CommandeMofdifier()
        {
            Console.Write(" Donner la reference:");
            int Ref = Int32.Parse(Console.ReadLine());
            ArticleDAL.Update(Ref, GetArticleFromUser());
        }
        public static void CommandeChercherParReference()
        {
            Console.Write(" Donner la reference:");
            int Ref = Int32.Parse(Console.ReadLine());
            Article a = ArticleDAL.SelectByRef(Ref);
            if (a != null)
                Show(a);
            else
                Console.WriteLine(" Cette reference n'existe pas dans la base de donnée");

        }
        public static void CommandeAfficherTout()
        {
            List<Article> list = ArticleDAL.SelectAll();
            if (list.Count != 0)
                Show(list);
            else
                Console.WriteLine(" La base de donnée est vide");

        }
        public static void Menu()
        {
            Boolean nostop = true;
            Database db = new Database("Article.txt");
            ArticleDAL.ConnectTo(db);
            do
            {
                Console.WriteLine("----------------------************ MENU *************------------------------------");
                Console.WriteLine("1-AJOUTER UN ARTICLE");
                Console.WriteLine("2-SUPPRIMER UN ARTICLE");
                Console.WriteLine("3-MODIFIER UN ARTICLE");
                Console.WriteLine("4-AFFICHER UN ARTICLE");
                Console.WriteLine("5-AFFICHER TOUS LES ARTICLES");
                Console.WriteLine("6-QUITTER LE MENU ET L'APPLICATION");
                Console.Write("VOTRE REPONSE:");
                string rep = Console.ReadLine();
                string touch;
                switch (rep)
                {
                    case "1":
                        CommandeAjouter();
                        Console.Write(" Taper la touche entrée pour revenir au menu...");
                        touch = Console.ReadLine();
                        break;
                    case "2":
                        CommandeSupprimer();
                        Console.Write(" Taper la touche entrée pour revenir au menu...");
                        touch = Console.ReadLine();
                        break;
                    case "3":
                        CommandeMofdifier();
                        Console.Write(" Taper la touche entrée pour revenir au menu...");
                        touch = Console.ReadLine();
                        break;
                    case "4":
                        CommandeChercherParReference();
                        Console.Write(" Taper la touche entrée pour revenir au menu...");
                        touch = Console.ReadLine();
                        break;
                    case "5":
                        CommandeAfficherTout();
                        Console.Write(" Taper la touche entrée pour revenir au menu...");
                        touch = Console.ReadLine();
                        break;
                    case "6":
                        nostop = false;
                        Console.WriteLine(" Fermeture de l'application...");

                        break;
                    default:
                        nostop = true;
                        break;
                }
                if (rep != "6")
                    Console.Clear();

            } while (nostop == true);

        }


    }
}
