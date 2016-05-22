using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futarceg_iktm1h
{
    class ListaEnumerator<T> : IEnumerator<T>
    {
        ListaElem<T> elso;
        ListaElem<T> akt;
        public ListaEnumerator(ListaElem<T> ujelso)
        {
            elso = ujelso;
            akt = null;
        }
        public T Current
        {
            get { return akt.Adat; }
        }

        public void Dispose()
        {
            akt = null;
            elso = null;
        }

        object System.Collections.IEnumerator.Current
        {
            get { return this.Current; }
        }

        public bool MoveNext()
        {
            if (akt == null)
            {
                akt = elso;
            }
            else
            {
                akt = akt.Kov;
            }
            return akt != null;
        }

        public void Reset()
        {
            akt = null;
        }
    }
}
