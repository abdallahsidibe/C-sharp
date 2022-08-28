using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace LFI2TP3_SIDIBE_ABDOULAYE
{
    class ArticleDAL
    {
        public static OleDbConnection cn;
        public static void ConnectTo(string database)
        {
            string db = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ETUDE\l2\Licence 2 FSM\SEMESTRE 2\Environnement de développement et SGBD\COURS\Database.accdb";
            cn = new OleDbConnection(db);
            try
            {
                cn.Open();
                cn.Close();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);


            }

        }
        public static void Add(Article a)
        {
            string acc = "insert into Article values(?,?,?)";
            OleDbCommand cmd = new OleDbCommand(acc, cn);
            OleDbParameter p = new OleDbParameter("Reference", a.Reference);
            cmd.Parameters.Add(p);
            OleDbParameter p1 = new OleDbParameter("Désignation", a.Designation);
            cmd.Parameters.Add(p1);
            OleDbParameter p2 = new OleDbParameter("Prix", a.Prix);
            cmd.Parameters.Add(p2);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Ajout avec succès!");
                cn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
        public static void Delete(int Ref)
        {
            string sup = "delete Article where Reference=?";
            OleDbCommand cmd = new OleDbCommand(sup, cn);
            OleDbParameter s = new OleDbParameter("Reference", Ref);
            cmd.Parameters.Add(s);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

        }
        public static void Update(int Ref, Article a)
        {
            try
            {
                cn.Open();

                string sql = " select count(*) from Article where Reference=?";
                OleDbCommand cmd = new OleDbCommand(sql, cn);
                OleDbParameter m = new OleDbParameter("Reference", Ref);
                cmd.Parameters.Add(m);
                long nbl = (long)cmd.ExecuteScalar();
                if (nbl != 0)
                {

                    string sqls = " update Article set Designation=" + a.Designation + ", Prix" + a.Prix;
                    OleDbCommand cmdq = new OleDbCommand(sqls, cn);
                    cmdq.ExecuteNonQuery();
                    Console.WriteLine("modification ok !");
                }
                else
                {
                    Console.WriteLine("numero de l'Article incorrect!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cn.Close();
        }
        public static Article SelectByRef(int Ref)
        {

            Article a = new Article();
            cn.Open();
            string sql = "select * from Article where Reference=?";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
           // OleDbParameter P1 = new OleDbParameter("Reference", Ref);
            cmd.Parameters.Add(new OleDbParameter("Reference", Ref));
            OleDbDataReader rd = cmd.ExecuteReader();
            if (rd != null)
            {
                if (rd.Read())
                {

                    a.Reference = (int)rd[0];
                    a.Designation = (string)rd[1];
                    a.Prix = (float)rd[2];
                }
                cn.Close();
            }
            return a;

            

        }
        public static List<Article> SelectAll()
        {

            List<Article> LesArticles = new List<Article>();
            Article ar = new Article();

            cn.Open();
            string sql = "select * from Article";
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            OleDbDataReader rd = cmd.ExecuteReader();
            if (rd != null)
            {
                while (rd.Read())
                {/*
                    ar = new Article();
                    ar.Reference = (int)rd[0];
                    ar.Designation = (string)rd[1];
                    //inv = Int32.Parse(rd[0].ToString());
                    ar.Prix = Int32.Parse(rd[2].ToString());
                    //ar.Prix = (float)rd[2];
                    LesArticles.Add(ar);
                    */

                    ar.Reference = (int)rd["Reference"];
                    ar.Designation = (string)rd["Designation"];
                    // ar.Prix = (float)rd["Prix"];
                    ar.Prix = Int32.Parse(rd[2].ToString());
                    LesArticles.Add(new Article(ar.Reference, ar.Designation, ar.Prix));
                }
            }
            return LesArticles;


        }
    }
}
