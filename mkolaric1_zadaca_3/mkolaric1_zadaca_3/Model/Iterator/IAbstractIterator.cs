using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;

namespace mkolaric1_zadaca_1.Iterator
{
   public interface IAbstractIterator
   {
       IRasporedEmisija First();
       IRasporedEmisija Next();
       bool IsDone { get; }
       IRasporedEmisija CurrentItem { get; }

       bool hasNext();
   }
}
