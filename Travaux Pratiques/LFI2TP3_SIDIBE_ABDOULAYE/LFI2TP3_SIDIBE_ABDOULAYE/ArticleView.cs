using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace LFI2TP3_SIDIBE_ABDOULAYE
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
            string Db = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ETUDE\l2\Licence 2 FSM\SEMESTRE 2\Environnement de développement et SGBD\COURS\Database.accdb";

            bool Quit = false;


            ArticleDAL.ConnectTo(Db);
            do
            {
                int Reponse;
                Console.WriteLine("\n\n.............");
                Console.WriteLine("********** Menu principal*******");
                Console.WriteLine(".................");
                Console.WriteLine("1-Afficher tous les  articles");
                Console.WriteLine("2-Ajouter un Article");
                Console.WriteLine("3-Supprimer un Article ");
                Console.WriteLine("4-Modifier un Article");
                Console.WriteLine("5-Rechercher par Reference");
                Console.WriteLine("6-Quitter");
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
