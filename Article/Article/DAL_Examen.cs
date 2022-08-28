using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace Article
{
    class DAL_Examen
    {
        public static bool Exists(int Id)
        {
            // Appel de l'objet de connexion
            OleDbConnection cnn = DBConnection.GetConnection();

            // Ouverture de la connexion
            cnn.Open();

            // Texte de la commande 
            string StrSql = "SELECT COUNT(*) FROM Article WHERE Id =?";

            // Création de l'objet Command 
            OleDbCommand cmd = new OleDbCommand(StrSql, cnn);

            //Création d'objet Parameter qui va servir pour faire passer Id
            OleDbParameter PId = new OleDbParameter("pId", Id);

            //Ajout du parametre à la liste des parametres de la commande
            cmd.Parameters.Add(PId);

            //Exécution de la commande
            int resultat = (int)cmd.ExecuteScalar();

            //Fermeture de la connexion
            cnn.Close();

            //Verification
            bool res = false;
            if (resultat == 1)
                res = true;
            return res;

        }

        public static void Add(Article a)
        {
            if(Exists(a.Id))//ou simplement DAL_Examen.Exists(a.Id)
            {
                Console.WriteLine("L'identifiant de l'article existe dans la base.");
            }
            else
            {
                // Appel de l'objet de connexion
                OleDbConnection cnn = DBConnection.GetConnection();

                // Ouverture de la connexion
                cnn.Open();

                // Texte de la commande 
                string StrSql = "INSERT INTO Article VALUES(?,?)";

                // Création de l'objet Command 
                OleDbCommand cmd = new OleDbCommand(StrSql, cnn);

                OleDbParameter P1 = new OleDbParameter("pI", a.Id);
                cmd.Parameters.Add(P1);

                OleDbParameter P2 = new OleDbParameter("pD", a.Designation);
                cmd.Parameters.Add(P2);

                // Exécution de la commande 
                cmd.ExecuteNonQuery();
                // Fermeture de la connexion 

                cnn.Close();
            }
        }

        public static int GetQuantity(int IdA, int IdS)
        {
            // Appel de l'objet de connexion
            OleDbConnection cnn = DBConnection.GetConnection();

            // Ouverture de la connexion
            cnn.Open();

            //Texte de la commande 
            string StrSql = "SELECT Quantite FROM StockArticleSite WHERE IdArticle=? AND IdSite=?";


            //// Texte de la commande car on n'a pas demander de compter
            //string StrSql = "SELECT COUNT(Quantite) FROM StockArticleSite WHERE IdArticle=? AND IdSite=?";

            // Création de l'objet Command 
            OleDbCommand cmd = new OleDbCommand(StrSql, cnn);

            //OleDbParameter P1 = new OleDbParameter("pA",IdA );
            //cmd.Parameters.Add(P1);

            //OleDbParameter P2 = new OleDbParameter("pD", IdS);
            //cmd.Parameters.Add(P2);

            cmd.Parameters.Add(new OleDbParameter("pA", IdA));
            cmd.Parameters.Add(new  OleDbParameter("pD", IdS));

            // Exécution de la commande 
            int Nb = (int)cmd.ExecuteScalar();

            // Fermeture de la connexion 
            cnn.Close();

            return Nb;
        }

        public static void UpdateQuantity(int IdA, int IdS, int N)
        {
            int quantite = GetQuantity(IdA, IdS) + N;

            // Appel de l'objet de connexion
            OleDbConnection cnn = DBConnection.GetConnection();

            // Ouverture de la connexion
            cnn.Open();

            //Texte de la commande 
            string StrSql = "UPDATE StockArticleSite Set Quantite=? WHERE IdArticle=? AND IdSite=?";

            // Création de l'objet Command 
            OleDbCommand cmd = new OleDbCommand(StrSql, cnn);

            cmd.Parameters.Add(new OleDbParameter("pQ", quantite));
            cmd.Parameters.Add(new OleDbParameter("pA", IdA));
            cmd.Parameters.Add(new OleDbParameter("pD", IdS));
          
           // Exécution de la commande 
            cmd.ExecuteNonQuery();

            // Fermeture de la connexion 
            cnn.Close();
        }

        public static void ContrainedUpdateQuantity(int IdA, int IdS, int N)
        {
            UpdateQuantity(IdA, IdS, N);
            int quantite = GetQuantity(IdA, IdS);
            if(quantite < 0)
            {
                Console.WriteLine("la mise à jour n'est pas possible");
                UpdateQuantity(IdA, IdS, - quantite);
            }
        }
    }
}
