using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkolaric1_zadaca_1.Osnovno
{
    class TvPregled 
    {
        public string Naziv { get; set; }
        public TimeSpan Pocetak { get; set; }
        public TimeSpan Zavrsetak { get; set; }
        public int Trajanje { get; set; }
        public string Ime1 { get; set; }
        public string Uloga1 { get; set; }
        public string Ime2 { get; set; }
        public string Uloga2 { get; set; }

        public TvPregled()
        {

        }

        public TvPregled(string naziv, TimeSpan pocetak, TimeSpan zavrsetak, int trajanje)
        {
            Naziv = naziv;
            Pocetak = pocetak;
            Zavrsetak = zavrsetak;
            Trajanje = trajanje;
        }

        public TvPregled(string naziv, TimeSpan pocetak, TimeSpan zavrsetak, int trajanje, string ime, string uloga)
        {
            Naziv = naziv;
            Pocetak = pocetak;
            Zavrsetak = zavrsetak;
            Trajanje = trajanje;
            Ime1 = ime;
            Uloga1 = uloga;
        }

        public TvPregled(string naziv, TimeSpan pocetak, TimeSpan zavrsetak, int trajanje, string ime1, string uloga1, string ime2, string uloga2)
        {
            Naziv = naziv;
            Pocetak = pocetak;
            Zavrsetak = zavrsetak;
            Trajanje = trajanje;
            Ime1 = ime1;
            Uloga1 = uloga1;
            Ime2 = ime2;
            Uloga2 = uloga2;
        }

    }
}
