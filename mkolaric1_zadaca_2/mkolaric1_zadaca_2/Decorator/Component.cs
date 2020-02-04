using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_2.Entiteti;

namespace mkolaric1_zadaca_1.Decorator
{
   public interface Component
   {
       List<IRasporedEmisija> Ispisi();
       int Prihod();

       List<IRasporedEmisija> IspisPremaVrsti(TvProgrami program, DanComposite dan,int vrsta);
    }
}
