using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace PERSONNE
{
    class DBConnection
    {
        //Création de la chaîne de connexion
        static string StrCnn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ETUDE\Personne.accdb";
        // Création de l'objet de connexion
        public static OleDbConnection GetConnection()
        {
            OleDbConnection cnn = new OleDbConnection(StrCnn);
            return cnn;
        }
    }
}
