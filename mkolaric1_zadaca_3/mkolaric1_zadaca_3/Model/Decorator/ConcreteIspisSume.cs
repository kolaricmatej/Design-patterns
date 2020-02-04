using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Decorator;
using mkolaric1_zadaca_1.Entiteti;

namespace mkolaric1_zadaca_3.Model.Decorator
{
    class ConcreteIspisSume:Component
    {

        public EmitiranjeEmisija Emisija { get; set; }
        public int Prihod { get; set; }
        public ConcreteIspisSume(EmitiranjeEmisija emisija,int prihod)
        {
            this.Emisija = emisija;
            this.Prihod = prihod;
        }
        public string Ispisi()
        {
            if (Emisija == null)
            {
                return HeaderIspisEmisija();
            }
            else if(Emisija!=null)
            {
                return prikazRasporeda();
            }

            return prikazPrihoda();
        }

        public string HeaderIspisEmisija()
        {
            string ispis = "";
            ispis += new string('-', 105) + "\n";
            ispis += $"|{"Naziv programa",-40}|{"Vrsta emisije",-25}|{"Trajanje",25}|\n";
            ispis += new string('-', 105) + "\n";
            return ispis;
        }

        public string prikazRasporeda()
        {
            string ispis = "";
            ispis +=
                $"|{Emisija.Emisija.naziv,-40}|{Emisija.Emisija.vrsta.Vrsta,-25}|{Emisija.Emisija.vrsta.Trajanje,25}|\n";
            ispis += new string('-', 105);
            return ispis;
        }

        public string prikazPrihoda()
        {
            return $"|{"Prihodi u minutama",-40}|{"",-40}{Prihod,11}|\n";
        }
    }
}
