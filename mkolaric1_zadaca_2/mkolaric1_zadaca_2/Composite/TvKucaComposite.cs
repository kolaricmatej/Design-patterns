using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Iterator;
using mkolaric1_zadaca_2.Entiteti;

namespace mkolaric1_zadaca_1.Composite
{
    class TvKucaComposite:IRasporedEmisija,AggregateVrsta
    {
        public List<IRasporedEmisija> listaPrograma = new List<IRasporedEmisija>();
        public TvProgrami TvProgrami { get; set; }

        public TvKucaComposite(TvProgrami tvProgrami)
        {
            TvProgrami = tvProgrami;
        }

        public void Add(IRasporedEmisija i)
        {
            listaPrograma.Add(i);
        }

        public void Remove(IRasporedEmisija i)
        {
            listaPrograma.Remove(i);
        }

        public void Display()
        {
            foreach (var program in listaPrograma)
            {
                program.Display();
            }
        }

        public void IspisEmisijaPoVrsti(int vrsta)
        {
            ConcreateIteratorVrsta iterator=CreateIterator(vrsta) as ConcreateIteratorVrsta;
            while (!iterator.IsDone)
            {
                Console.WriteLine(iterator.Next());
            }

        }

        public IRasporedEmisija roditelj { get; set; }
        public IAbstractIterator CreateIterator(int vrsta)
        {
            return  new ConcreateIteratorVrsta(listaPrograma,vrsta);
        }
    }
}
