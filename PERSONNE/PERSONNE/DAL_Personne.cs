using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace PERSONNE
{
    class DAL_Personne
    {
        
        public static void AjoutPersonne(int id, string nom, string prenom, string dat)
        {

            // Appel de l'objet de connexion
            OleDbConnection cnn = DBConnection.GetConnection();

            // Ouverture de la connexion
            cnn.Open();

            // Texte de la commande 
            string StrSql = "INSERT INTO Personne VALUES (?,?,?,?)";

            // Création de l'objet Command 
            OleDbCommand cmd = new OleDbCommand(StrSql, cnn);

            OleDbParameter P1 = new OleDbParameter("pId", id);
            cmd.Parameters.Add(P1);

            OleDbParameter P2 = new OleDbParameter("pnom", nom);
            cmd.Parameters.Add(P2);

            OleDbParameter P3 = new OleDbParameter("pprenom", prenom);
            cmd.Parameters.Add(P3);

            OleDbParameter P4 = new OleDbParameter("pdat", dat);
            cmd.Parameters.Add(P4);

            // Exécution de la commande 
            cmd.ExecuteNonQuery();
            // Fermeture de la connexion 

            cnn.Close();
        }

       

        public static void AfficherPersonne()
        {
            // Création de l'objet de connexion
            OleDbConnection cnn = DBConnection.GetConnection();

            // Ouverture de la connexion
            cnn.Open();

            // Texte de la commande 
            string StrSql = "SELECT * FROM Personne";

            // Création de l'objet Command 
            OleDbCommand cmd = new OleDbCommand(StrSql, cnn);

            // Execution de la commande et récupération des données dans un DataReader OleDbDataReader
            OleDbDataReader rd = cmd.ExecuteReader();

            // Parcours des enregistrements renvoyés
            string s,t, r;
            int inv;
            int i = 0;
            if (rd != null)
            {
                while (rd.Read())
                {
                    inv = Int32.Parse(rd[0].ToString());
                    s = (string)rd["nom"]; // (string)rd[1]
                    r = (string)rd["prenom"];
                    t = (string)rd["datenaiss"];
                    i += 1;
                    Console.WriteLine("Personne: " + inv + " Nom: " + s + " Prenom: " + r + " Date de Naissance: " + t);
                }
            }
            cnn.Close();

        }

        public static void AfficherOuvrage(int AE)
        {
            // Création de l'objet de connexion
            OleDbConnection cnn = DBConnection.GetConnection();

            // Ouverture de la connexion
            cnn.Open();

            // Texte de la commande 
            
            string StrSql = "SELECT * FROM Personne WHERE id > ? ";

            // Création de l'objet Command 
            OleDbCommand cmd = new OleDbCommand(StrSql, cnn);
            OleDbParameter Par = new OleDbParameter("pid", AE);
            cmd.Parameters.Add(Par);

            // Execution de la commande et récupération des données dans un DataReader OleDbDataReader
            OleDbDataReader rd = cmd.ExecuteReader();

            // Parcours des enregistrements renvoyés
            string s, t, r;
            int inv;
            int i = 0;
            if (rd != null)
            {
                while (rd.Read())
                {
                    inv = Int32.Parse(rd[0].ToString());
                    s = (string)rd["nom"]; // (string)rd[1]
                    r = (string)rd["prenom"];
                    t = (string)rd["dat"];
                    i += 1;
                    Console.WriteLine("Personne: " + inv + " Nom: " + s + "Prenom: " + r + " Date de Naissance: " + t);
                }
            }
            cnn.Close();

        }

    }
}

