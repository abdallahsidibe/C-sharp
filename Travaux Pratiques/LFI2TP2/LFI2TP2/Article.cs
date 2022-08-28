using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFI2TP2
{
    class Article
    {
        public int Reference;
        public string Designation;
        public float Prix;

        public Article()
        {

        }
        public Article(int refs, string des, float pr)
        {
            Reference = refs;
            Designation = des;
            Prix = pr;
        }
    }
}
