using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futarceg_iktm1h
{
    class TorolEventArgs:EventArgs
    {
        public object lenyeg;
        public TorolEventArgs( ref Kuldemeny vmi):base()
        {
            lenyeg = vmi;
        }
       
    }
}
