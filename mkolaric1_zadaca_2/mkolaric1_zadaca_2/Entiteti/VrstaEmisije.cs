using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_2.FactoryMethod;

namespace mkolaric1_zadaca_1.Entiteti
{
    public class VrstaEmisije:Product
    {
        public int Id { get; set; }
        public string Vrsta { get; set; }
        public int Reklama { get; set; }
        public int Trajanje { get; set; }

        public VrstaEmisije()
        {
            
        }

        public VrstaEmisije(int id, string vrsta, int reklama, int trajanje)
        {
            Id = id;
            Vrsta = vrsta;
            Reklama = reklama;
            Trajanje = trajanje;
        }
    }
}
