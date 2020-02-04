using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Decorator;
using mkolaric1_zadaca_1.Dodaci;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_1.Iterator;
using mkolaric1_zadaca_2.Entiteti;
using mkolaric1_zadaca_2.Singleton;

namespace mkolaric1_zadaca_1.Composite
{
    public class DanComposite: IRasporedEmisija, Aggregate, Component
    {
       public List<IRasporedEmisija> listaEmisija=new List<IRasporedEmisija>();
       public Dan Dan { get; set; }

       public DanComposite()
       {
           
       }
        public DanComposite(Dan dan)
        {
            Dan = dan;
        }
        public void Add(IRasporedEmisija i)
        {
            if (ProvjeriPreklapanje(i))
            {
                i.roditelj = this;
                listaEmisija.Add(i);
                listaEmisija = listaEmisija.OrderBy(a => ((EmisijaLeaf) a).Emisija.Pocetak).ToList();
            }
        }
        public void Remove(IRasporedEmisija i)
        {
            listaEmisija.Remove(i);
        }

        public void Display()
        {
            IAbstractIterator iterator = CreateIterator();
            Console.WriteLine("Prolazim kroz listu emisija:");
            for (IRasporedEmisija item=iterator.First();!iterator.IsDone;item=iterator.Next())
            {
                Console.WriteLine(((EmisijaLeaf)item).Emisija.Emisija.naziv);
            }
        }

        public IRasporedEmisija roditelj { get; set; }

        private bool ProvjeriPreklapanje(IRasporedEmisija emisijaZaDodat)
        {
            var emisijaDodati = ((EmisijaLeaf) emisijaZaDodat).Emisija;
                foreach (EmisijaLeaf emisija in listaEmisija)
                {
                    var postojecaEmisija = emisija.Emisija;
                    if (emisijaDodati.Pocetak == TimeSpan.Zero)
                    {
                        for (int i = 0; i < listaEmisija.Count; i++)
                        {
                            if (i == 0)
                            {
                                var kraj = ((EmisijaLeaf) listaEmisija[i]).Emisija.Pocetak - TvKucaSingleton.GetInstance().dohvatiPocetak();
                                if (kraj.TotalMinutes > emisijaDodati.Emisija.trajanje )
                                {
                                    emisijaDodati.Pocetak = TvKucaSingleton.GetInstance().dohvatiPocetak();
                                    emisijaDodati.Kraj =
                                        emisijaDodati.Pocetak + TimeSpan.FromMinutes(emisijaDodati.Emisija.trajanje);
                                    break;
                                }
                            }
                            else
                            {
                                var vrijeme = ((EmisijaLeaf) listaEmisija[i]).Emisija.Pocetak -
                                              ((EmisijaLeaf) listaEmisija[i - 1]).Emisija.Kraj;
                                if (vrijeme.TotalMinutes > emisijaDodati.Emisija.trajanje &&
                                    TvKucaSingleton.GetInstance().dohvatiKraj()> ((EmisijaLeaf) listaEmisija[i - 1]).Emisija.Kraj)
                                {
                                    emisijaDodati.Pocetak = ((EmisijaLeaf) listaEmisija[i - 1]).Emisija.Kraj;
                                    emisijaDodati.Kraj =
                                        emisijaDodati.Pocetak + TimeSpan.FromMinutes(emisijaDodati.Emisija.trajanje);
                                    break;
                                }
                            }
                        }
                    }
                    if (emisijaDodati.Pocetak > postojecaEmisija.Pocetak &&
                        emisijaDodati.Pocetak < postojecaEmisija.Kraj ||
                        emisijaDodati.Kraj > postojecaEmisija.Pocetak && emisijaDodati.Kraj < postojecaEmisija.Kraj ||emisijaDodati.Kraj>TvKucaSingleton.GetInstance().dohvatiKraj()||emisijaDodati.Pocetak<TvKucaSingleton.GetInstance().dohvatiPocetak())
                    {
                        Console.WriteLine("Preklapanje " + emisijaDodati.Emisija);
                        return false;
                    }
                }
                return true;
        }

        public IAbstractIterator CreateIterator()
        {
            return new ConcreateIterator(listaEmisija);
        }

        public IAbstractIterator getIteratorVrsta(int vrsta)
        {
            return new ConcreateIteratorVrsta(listaEmisija,vrsta);
        }


        public List<IRasporedEmisija> Ispisi()
        {
            return listaEmisija;

        }

        public int Prihod()
        {
            int zbrojPrihoda = 0;
            IAbstractIterator iterator = this.CreateIterator();
            while (iterator.hasNext())
            {
                IRasporedEmisija raspored = iterator.Next();
                var vrsta = ((EmisijaLeaf) raspored).Emisija.Emisija.VrstaEmisije;
                if ( vrsta!= null)
                {
                    if (((EmisijaLeaf)raspored).Emisija.Emisija.vrsta.Reklama==1)
                    {
                        zbrojPrihoda += ((EmisijaLeaf) raspored).Emisija.Emisija.vrsta.Trajanje;
                    }
                }
            }
            return zbrojPrihoda;
        }

        public List<IRasporedEmisija> IspisPremaVrsti(TvProgrami program, DanComposite dan,int vrsta)
        {
            return listaEmisija;
        }

    }
}
