using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Dodaci;
using mkolaric1_zadaca_2.Entiteti;

namespace mkolaric1_zadaca_1.Entiteti
{
    public class EmitiranjeEmisija
    {
        public Emisija Emisija { get; set; }
        public TimeSpan Pocetak { get; set; }
        public TimeSpan Kraj { get; set; }

        public EmitiranjeEmisija(Emisija emisija, TimeSpan pocetak)
        {
            Emisija = emisija;
            Pocetak = pocetak;
            if (pocetak != TimeSpan.Zero)
            {
                Kraj = pocetak + TimeSpan.FromMinutes(emisija.trajanje);
            }
        }

    }
}
