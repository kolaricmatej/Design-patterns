using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_3.FactoryMethod;

namespace mkolaric1_zadaca_3.Entiteti
{
    public class Program: Product,Prototype.Prototype
    {
        public int Id { get; set; }
        public List<int> DaniUTjednu { get; set; } = new List<int>();
        public TimeSpan Pocetak { get; set; }
        public List<int> OsobaUloga { get; set; }

        private List<EmitiranjeEmisija> listaEmitiranja=new List<EmitiranjeEmisija>();

        public Program()
        {
            
        }
        public Program(int id, List<int> daniUTjednu, TimeSpan pocetak, List<int> osobaUloga)
        {
            Id = id;
            DaniUTjednu = daniUTjednu;
            Pocetak = pocetak;
            OsobaUloga = osobaUloga;
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

        public List<int> VratiDane(string dani)
        {
            List<int> Dani = new List<int>();
            var raspon = dani.Split(new string[] { "-" }, StringSplitOptions.None);
            if (raspon.Count() == 2)
            {
                for (int i = Convert.ToInt32(raspon[0]); i <= Convert.ToInt32(raspon[1]); i++)
                {
                    Dani.Add(i);
                }
                return Dani;
            }

            raspon = dani.Split(new string[] { "," }, StringSplitOptions.None);
            if (raspon.Count() > 1)
            {
                foreach (string d in raspon)
                {
                    Dani.Add(Convert.ToInt32(d));
                }
            }

            if (int.TryParse(dani, out int dan))
            {
                Dani.Add(dan);
            }

            return Dani;
        }

        public Prototype.Prototype clone()
        {
            return new Program(this.Id,this.DaniUTjednu,this.Pocetak,this.OsobaUloga);
        }
    }
}
