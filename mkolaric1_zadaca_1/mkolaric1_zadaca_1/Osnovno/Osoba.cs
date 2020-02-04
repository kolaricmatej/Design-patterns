using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkolaric1_zadaca_1.Osnovno
{
    class Osoba
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
