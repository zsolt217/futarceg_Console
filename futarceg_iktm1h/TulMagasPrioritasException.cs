using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futarceg_iktm1h
{
    class TulMagasPrioritasException : ApplicationException
    {
        int prioritas;

        public int Prioritas
        {
            get { return prioritas; }
        }
        public TulMagasPrioritasException(int prio)
        {
            prioritas = prio;
        }
    }
}
