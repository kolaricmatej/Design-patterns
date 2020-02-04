using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkolaric1_zadaca_1.Iterator
{
    public interface Aggregate
    {
        IAbstractIterator CreateIterator();
    }
}
