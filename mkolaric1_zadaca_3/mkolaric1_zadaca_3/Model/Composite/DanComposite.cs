using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Decorator;
using mkolaric1_zadaca_1.Dodaci;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_1.Iterator;
using mkolaric1_zadaca_3.CoR;
using mkolaric1_zadaca_3.Entiteti;
using mkolaric1_zadaca_3.Prototype;
using mkolaric1_zadaca_3.Singleton;
using mkolaric1_zadaca_3.Visitor;

namespace mkolaric1_zadaca_1.Composite
{
    public class DanComposite:IRasporedEmisija, Aggregate, Component,Prototype,AggregateVrsta
    {
       public List<IRasporedEmisija> listaEmisija=new List<IRasporedEmisija>();
       public Dan Dan { get; set; }
       private static int broj = 1;
       public DanComposite(Dan dan)
        {
            Dan = dan;
        }
        public void Add(IRasporedEmisija i)
        {
            if (ProvjeriPreklapanje(i))
            {
                i.roditelj = this;
                var tmp = (EmitiranjeEmisija)i;
                var emisija1 = new Emisija(tmp.Emisija);
                VrstaEmisije vrstaTMP = new VrstaEmisije();
                vrstaTMP = tmp.Emisija.vrsta;
                emisija1.vrsta = vrstaTMP;
                var prototype = new EmitiranjeEmisija(emisija1, tmp.Pocetak);
                prototype.RedniBroj = broj;
                listaEmisija.Add((EmitiranjeEmisija)prototype.clone());
                broj++;
                listaEmisija = listaEmisija.OrderBy(a => ((EmitiranjeEmisija) a).Pocetak).ToList();
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
                Console.WriteLine(((EmitiranjeEmisija)item).Emisija.naziv);
            }
        }

        public IRasporedEmisija roditelj { get; set; }

        private bool ProvjeriPreklapanje(IRasporedEmisija emisijaZaDodat)
        {
            var emisijaDodati = ((EmitiranjeEmisija) emisijaZaDodat);

                foreach (EmitiranjeEmisija emisija in listaEmisija)
                {
                    var postojecaEmisija = emisija;
                    if (emisijaDodati.Pocetak == TimeSpan.Zero)
                    {
                        for (int i = 0; i < listaEmisija.Count; i++)
                        {
                            if (i == 0)
                            {
                                var kraj = ((EmitiranjeEmisija) listaEmisija[i]).Pocetak - TvKucaSingleton.GetInstance().dohvatiPocetak();
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
                                var vrijeme = ((EmitiranjeEmisija) listaEmisija[i]).Pocetak -
                                              ((EmitiranjeEmisija) listaEmisija[i - 1]).Kraj;
                                if (vrijeme.TotalMinutes > emisijaDodati.Emisija.trajanje &&
                                    TvKucaSingleton.GetInstance().dohvatiKraj()> ((EmitiranjeEmisija) listaEmisija[i - 1]).Kraj)
                                {
                                    emisijaDodati.Pocetak = ((EmitiranjeEmisija) listaEmisija[i - 1]).Kraj;
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

        public List<IRasporedEmisija> Ispisi()
        {
            return listaEmisija;

        }

        public int Prihod()
        {
            IzracunPrihoda izracun=new IzracunPrihoda();
            IAbstractIterator iterator = this.CreateIterator();
            IRasporedEmisija raspored = iterator.First();
            while (!iterator.IsDone)
            {
                var vrsta = ((EmitiranjeEmisija)raspored).Emisija.VrstaEmisije;
                if (vrsta != null)
                {
                    if (((EmitiranjeEmisija)raspored).Emisija.vrsta.Reklama == 1)
                    {
                        izracun.posjeti(((EmitiranjeEmisija)raspored).Emisija.vrsta);
                    }
                }
                raspored = iterator.Next();
            }
            return izracun.getUkupanPrihod();
        }

        public List<IRasporedEmisija> IspisPremaVrsti(TvProgrami program, DanComposite dan,int vrsta)
        {
            return listaEmisija;
        }

        public List<IRasporedEmisija> IspisCijelogRasporeda(TvProgrami program, DanComposite dan)
        {
            return listaEmisija;
        }

        public Prototype clone()
        {
            DanComposite dan= new DanComposite((Dan)this.Dan.clone());
            foreach (EmitiranjeEmisija emisija in this.listaEmisija)
            {
                dan.listaEmisija.Add((EmitiranjeEmisija)emisija.clone());
            }

            return dan;
        }

        public IAbstractIterator CreateIterator(int vrsta)
        {
            return  new ConcreateIteratorVrsta(listaEmisija);
        }
    }
}
