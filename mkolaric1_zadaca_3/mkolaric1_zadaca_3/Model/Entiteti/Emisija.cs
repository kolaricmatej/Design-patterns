using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_3.FactoryMethod;

namespace mkolaric1_zadaca_3.Entiteti
{
    public class Emisija: Product,Prototype.Prototype
    {
        public int Id { get; set; }
        public string naziv { get; set; }
        public int VrstaEmisije { get; set; }
        public int trajanje { get; set; }
        public List<int> OsobaUloga { get; set; }
        public VrstaEmisije vrsta { get; set; }=new VrstaEmisije();

        public Emisija()
        {
            
        }

        public Emisija(int id, string naziv, int vrstaEmisije, int trajanje, List<int> osobaUloga, VrstaEmisije vrstaEm)
        {
            Id = id;
            this.naziv = naziv;
            VrstaEmisije = vrstaEmisije;
            this.trajanje = trajanje;
            OsobaUloga = osobaUloga;
            vrsta = vrstaEm;
        }

        public Emisija(Emisija e)
        {
            Id = e.Id;
            this.naziv = e.naziv;
            VrstaEmisije = e.VrstaEmisije;
            this.trajanje = e.trajanje;
            OsobaUloga = e.OsobaUloga;
        }

        public Emisija(int id, string naziv, int vrstaEmisije, int trajanje, List<int> osobaUloga)
        {
            Id = id;
            this.naziv = naziv;
            VrstaEmisije = vrstaEmisije;
            this.trajanje = trajanje;
            OsobaUloga = osobaUloga;
        }
        public Emisija(int id, string naziv, int trajanje, List<int> osobaUloga)
        {
            Id = id;
            this.naziv = naziv;
            this.trajanje = trajanje;
            OsobaUloga = osobaUloga;
        }

        public Emisija(int id, string naziv, int trajanje)
        {
            Id = id;
            this.naziv = naziv;
            this.trajanje = trajanje;
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

        public override string ToString()
        {
            return $"{naziv} {VrstaEmisije}";
        }

        public Prototype.Prototype clone()
        {
            return new Emisija(this.Id,this.naziv,this.VrstaEmisije,this.trajanje,this.OsobaUloga,(VrstaEmisije) vrsta.clone());
        }
    }
}
