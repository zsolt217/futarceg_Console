using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futarceg_iktm1h
{
    class ListaElem<T>
    {
        T adat;

        public T Adat
        {
            get { return adat; }
            set { adat = value; }
        }
        bool kiosztva;

        public bool Kiosztva
        {
            get { return kiosztva; }
            set { kiosztva = value; }
        }
        
        ListaElem<T> kov;

        internal ListaElem<T> Kov
        {
            get { return kov; }
            set { kov = value; }
        }
        public ListaElem(T ujadat)
        {
            adat = ujadat;
            kov = null;// nem lenne kötelező mert a rendszer alapértelmezetten erre állítja
        }
        public override string ToString()
        {
            return adat.ToString();
        }
    }
}
