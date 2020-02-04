using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_2.FactoryMethod;

namespace mkolaric1_zadaca_2.Entiteti
{
    public class Uloga : Product
    {
        public int Id { get; set; }
        public string Opis { get; set; }

        public Uloga()
        {
            
        }
        public Uloga(int id, string opis)
        {
            Id = id;
            Opis = opis;
        }
    }
}
