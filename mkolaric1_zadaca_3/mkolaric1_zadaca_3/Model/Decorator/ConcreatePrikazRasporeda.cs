using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Decorator;
using mkolaric1_zadaca_1.Entiteti;

namespace mkolaric1_zadaca_3.Model.Decorator
{
    public class ConcreatePrikazRasporeda: Component
    {
        public EmitiranjeEmisija Emisija { get; set; }
        private bool zaglavlje=true;
        public ConcreatePrikazRasporeda(EmitiranjeEmisija emisija)
        {
            this.Emisija = emisija;
        }
        public string Ispisi()
        {
            if (zaglavlje == true)
            {
                this.zaglavlje = false;
                return HeaderIspisEmisija();
            }
            else
            {
                return prikazRasporeda();
            }
        }

        public string HeaderIspisEmisija()
        {
            string ispis = "";
            ispis+=new string('-', 105) + "\n";
            ispis+=$"|{"Naziv programa",-40}|{"Pocetak",25}|{"Kraj",25}|{"Redni broj",10}|\n";
            ispis+=new string('-', 105) + "\n";
            return ispis;
        }

        public string prikazRasporeda()
        {
            string ispis = "";
            ispis+=$"|{Emisija.Emisija.naziv,-40}|{Emisija.Pocetak,25}|{Emisija.Kraj,25}|{Emisija.RedniBroj,10}|\n";
            ispis+=new string('-', 105)+"\n";
            return ispis;
        }
    }
}
