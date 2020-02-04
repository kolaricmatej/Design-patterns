using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Ucitavanje;

namespace mkolaric1_zadaca_1.Osnovno
{
    class Emisija 
    {
        public int Id { get; set; }
        public string naziv { get; set; }
        public int trajanje { get; set; }
        public List<int> OsobaUloga1 { get; set; }
        public List<int> OsobaUloga2 { get; set; }

        public Emisija()
        {

        }
        public Emisija(int id, string naziv, int trajanje)
        {
            Id = id;
            this.naziv = naziv;
            this.trajanje = trajanje;
        }
        public Emisija(int id, string naziv, int trajanje, List<int> osobaUloga)
        {
            Id = id;
            this.naziv = naziv;
            this.trajanje = trajanje;
            OsobaUloga1 = osobaUloga;
        }
        public Emisija(int id, string naziv, int trajanje, List<int> osobaUloga, List<int> osoba)
        {
            Id = id;
            this.naziv = naziv;
            this.trajanje = trajanje;
            OsobaUloga1 = osobaUloga;
            OsobaUloga2 = osoba;
        }

        public List<int> kreirajOsobaUloga(string osoba)
        {
            List<int> lista = new List<int>();
            var raspon = osoba.Split(new string[] { "-" }, StringSplitOptions.None);
            foreach (var v in raspon)
            {
                lista.Add(int.Parse(v));
            }
            return lista;
        }

    }

}
