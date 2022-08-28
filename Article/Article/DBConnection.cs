using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Article
{
    class DBConnection
    {
        //Création de la chaîne de connexion
        static string StrCnn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ETUDE\l2\Licence 2 FSM\SEMESTRE 2\Environnement de développement et SGBD\EXERCICES\StockMultiSites.accdb";
        // Création de l'objet de connexion
        public static OleDbConnection GetConnection()
        {
            OleDbConnection cnn = new OleDbConnection(StrCnn);
            return cnn;
        }
    }
}
