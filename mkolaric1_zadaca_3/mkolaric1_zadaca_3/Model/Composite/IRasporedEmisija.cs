using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkolaric1_zadaca_1.Composite
{
   public interface IRasporedEmisija
    {
        void Add(IRasporedEmisija i);
        void Remove(IRasporedEmisija i);
        void Display();
        IRasporedEmisija roditelj { get; set; }
    }
}
