using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Entiteti;

namespace mkolaric1_zadaca_3.Visitor
{
   public interface Visitable
   {
       void prihvati(Visitor visitor);
   }
}
