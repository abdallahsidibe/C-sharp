using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LFI2TP2_SIDIDBE_ABDOULAYE
{
    class Database:IDisposable
    {
        public List<Article> LesArticles;
        string DbFilename;

        public Database(string Filename)
        {
            LesArticles = new List<Article>();
            DbFilename = Filename;
            GetArticlesFromFile(Filename);
        }

        public void GetArticlesFromFile(string Filename)
        {
            string line;
            int CurReference;
            string CurDesignation;
            float CurPrix;
            string[] ArticleFields;

            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(Filename);
                while ((line = file.ReadLine()) != null)
                {
                    ArticleFields = line.Split(new char[] { ',' });
                    CurReference = Int32.Parse(ArticleFields[0].Trim());
                    CurDesignation = ArticleFields[1].Trim();
                    CurPrix = Single.Parse(ArticleFields[2].Trim());
                    LesArticles.Add(new Article(CurReference, CurDesignation, CurPrix));
                }

                file.Close();
            }
            catch (FileNotFoundException e)
            {
                File.Create(e.FileName);
            }

        }


        public void SaveArticlesToFile()
        {

            string DataBaseContent = "";
            foreach (Article a in LesArticles)
                DataBaseContent += a.Reference.ToString() + "," + a.Designation + "," + a.Prix.ToString() + "\n";

            File.WriteAllText(DbFilename, DataBaseContent);
        }

        public void Dispose()
        {
            SaveArticlesToFile();
        }


    }
}
