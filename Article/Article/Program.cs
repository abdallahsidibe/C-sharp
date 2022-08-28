using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Article
{
    class Program
    {
        static void Main(string[] args)
        {
            int Nb;
            Article a = new Article();
            Console.Write("donner la reference. ");
            a.Id = int.Parse(Console.ReadLine());
            Console.Write("donner la designation. ");
            a.Designation = Console.ReadLine();
            DAL_Examen.Add(a);

             Nb = DAL_Examen.GetQuantity(4,8);
            Console.WriteLine("La quantité est:" + Nb);

           // DAL_Examen.UpdateQuantity(4,8,10);
            //Nb = DAL_Examen.GetQuantity(4,8);
            //Console.WriteLine("La quantité est:" + Nb);
            DAL_Examen.ContrainedUpdateQuantity(4,8,-200);

            //Nb = DAL_Examen.GetQuantity(4, 8);
            //Console.WriteLine("La quantité est:" + Nb);

            Console.Read();

        }

        
    }
}
