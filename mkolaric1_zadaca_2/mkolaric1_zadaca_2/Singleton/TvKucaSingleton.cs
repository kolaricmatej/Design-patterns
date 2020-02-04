using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Decorator;
using mkolaric1_zadaca_1.Dodaci;
using mkolaric1_zadaca_1.Iterator;
using mkolaric1_zadaca_2.Entiteti;

namespace mkolaric1_zadaca_2.Singleton
{
    public class TvKucaSingleton:IRasporedEmisija
    {
        public List<IRasporedEmisija> rasporedPrograma = new List<IRasporedEmisija>();
        public List<TvProgrami> ListaPrograma { get; set; }

        private static TvKucaSingleton tvKuca;

        public int indexPrograma { get; set; }
        public static TvKucaSingleton GetInstance()
        {
            if (tvKuca == null)
            {
                tvKuca=new TvKucaSingleton();
            }

            return tvKuca;
        }

        private TvKucaSingleton()
        {
        }

        public List<TvProgrami> dohvatiListu()
        {
            return ListaPrograma;
        }

        public TimeSpan dohvatiPocetak()
        {
            return ListaPrograma[indexPrograma].Pocetak;
        }

        public TimeSpan dohvatiKraj()
        {
            return ListaPrograma[indexPrograma].Kraj;
        }

        public void Add(IRasporedEmisija i)
        {
            rasporedPrograma.Add(i);
        }

        public void Remove(IRasporedEmisija i)
        {
            rasporedPrograma.Remove(i);
        }

        public void Display()
        {
            foreach (var program in rasporedPrograma)
            {
                program.Display();
            }
        }

        public IAbstractIterator IspisEmisijaPoVrsti(int vrsta)
        {
            ConcreateIteratorVrsta iterator = CreateIterator(vrsta) as ConcreateIteratorVrsta;
            while (!iterator.IsDone)
            {
                Console.WriteLine(iterator.Next());
            }

            return iterator;
        }

        public IRasporedEmisija roditelj { get; set; }
        public IAbstractIterator CreateIterator(int vrsta)
        {
            return new ConcreateIteratorVrsta(rasporedPrograma, vrsta);
        }

    }
}
