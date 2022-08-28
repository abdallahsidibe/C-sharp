using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class Article
    {
        public int Reference { get; set; }
        public string Designation { get; set; }
        public float Prix { get; set; }
        public Article() { }
        public Article(int refe, string desig, float pri)
        {
            Reference = refe;
            Designation = desig;
            Prix = pri;
        }
    }
}
