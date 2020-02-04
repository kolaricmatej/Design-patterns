using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Dodaci;
using mkolaric1_zadaca_3.Entiteti;
using mkolaric1_zadaca_3.Prototype;

namespace mkolaric1_zadaca_1.Entiteti
{
    public class EmitiranjeEmisija:IRasporedEmisija,Prototype
    {
        public Emisija Emisija { get; set; }
        public TimeSpan Pocetak { get; set; }
        public TimeSpan Kraj { get; set; }
        public int RedniBroj { get; set; }

        public EmitiranjeEmisija()
        {
            
        }

        public EmitiranjeEmisija(Emisija emisija, TimeSpan pocetak, TimeSpan kraj, int redniBroj)
        {
            Emisija = emisija;
            Pocetak = pocetak;
            Kraj = kraj;
            RedniBroj = redniBroj;
        }
        public EmitiranjeEmisija(Emisija emisija, TimeSpan pocetak)
        {
            Emisija = emisija;
            Pocetak = pocetak;
            if (pocetak != TimeSpan.Zero)
            {
                Kraj = pocetak + TimeSpan.FromMinutes(emisija.trajanje);
            }
        }

        public void Add(IRasporedEmisija i)
        {
            Console.WriteLine("Ne možete dodati element");
        }

        public void Remove(IRasporedEmisija i)
        {
            Console.WriteLine("Ne možete obrisati element");
        }

        public void Display()
        {
            throw new NotImplementedException();
        }

        public IRasporedEmisija roditelj { get; set; }
        public Prototype clone()
        {
            EmitiranjeEmisija emitiranje=new EmitiranjeEmisija((Emisija)this.Emisija.clone(), this.Pocetak, this.Kraj, this.RedniBroj);
            return emitiranje;
        }
    }
}
