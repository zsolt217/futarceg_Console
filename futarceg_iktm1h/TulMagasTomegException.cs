using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futarceg_iktm1h
{
    class TulMagasTomegException:ApplicationException
    {
       
            int tomeg;

            public int Tomeg
            {
                get { return tomeg; }
            }
            public TulMagasTomegException(int prio)
            {
                tomeg = prio;
            }
        
    }
}
