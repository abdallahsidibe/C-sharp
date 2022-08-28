using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LFI2TP2_SIDIDBE_ABDOULAYE
{
    class ArticleDAL
    {
        
        static Database db;

        public static void ConnectTo(Database Db)
        {
            db = Db;
            // db = new Database(Db);
            Console.WriteLine("connexion réussi !");
        }

        public static void Add(Article a)
        {
            //verifier si ref existe
            Boolean exist = false;
            foreach (Article art in db.LesArticles)
            {
                if (art.Reference == a.Reference)
                {
                    exist = true;
                    Console.Write("Cette reference existe déjà, voulez vous modifiez l'article ? oui/non:");
                    string Oui = Console.ReadLine();
                    if (Oui == "non")
                    {
                    }
                    else
                    {
                        Update(a.Reference, a);
                    }

                    break;
                }

            }
            if (exist == false)
            {
                db.LesArticles.Add(a);
                Console.WriteLine("article ajouté.");
            }
            db.Dispose();
        }

        public static void Delete(int Ref)
        {
            Boolean exist = false;
            for (int i = 0; i < db.LesArticles.Count; i++)
            {
                if (db.LesArticles[i].Reference == Ref)
                {
                    exist = true;
                    db.LesArticles.RemoveAt(i);
                    Console.WriteLine("article de reference " + Ref + " a été supprimé");
                    break;
                }
            }
            if (exist == false)
                Console.WriteLine("Cette reference n'existe pas dans la base de données.");
            db.Dispose();
        }

        public static void Update(int Ref, Article a)
        {
            Boolean exist = false;
            for (int i = 0; i < db.LesArticles.Count; i++)
            {
                if (db.LesArticles[i].Reference == Ref)
                {
                    exist = true;
                    db.LesArticles.Insert(i, a);
                    Delete(Ref);
                    Console.WriteLine("puis mis a jour.");

                    break;
                }
            }
            if (exist == false)
                Console.WriteLine("Cette reference n'existe pas dans la base de données.");
            db.Dispose();
        }

        public static Article SelectByRef(int Ref)
        {

            foreach (Article art in db.LesArticles)
            {
                if (art.Reference == Ref)
                {
                    return art;
                }
            }

            return null;


        }

        public static List<Article> SelectAll()
        {
            return db.LesArticles;
        }
    }
}
