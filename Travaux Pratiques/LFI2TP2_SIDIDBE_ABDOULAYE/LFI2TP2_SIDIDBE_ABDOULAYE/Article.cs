using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LFI2TP2_SIDIDBE_ABDOULAYE
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
