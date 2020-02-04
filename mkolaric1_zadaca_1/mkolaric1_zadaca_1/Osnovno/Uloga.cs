using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkolaric1_zadaca_1.Osnovno
{
    class Uloga
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
