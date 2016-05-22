using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futarceg_iktm1h
{
    abstract class Gepjarmu
    {
        int szallithatosuly;

        public int Szallithatosuly
        {
            get { return szallithatosuly; }
            //set { szallithatosuly = value; }
        }

        public Gepjarmu(int szallithatosuly)
        {
            this.szallithatosuly = szallithatosuly;
        }
    }
}
