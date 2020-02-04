using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_3.FactoryMethod;

namespace mkolaric1_zadaca_3.Entiteti
{
    public class Osoba: Product
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public Osoba()
        {
            
        }
        public Osoba(int id, string naziv)
        {
            Id = id;
            Naziv = naziv;
        }
    }
}

