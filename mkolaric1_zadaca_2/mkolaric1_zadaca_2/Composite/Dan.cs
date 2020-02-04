using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkolaric1_zadaca_1.Composite
{
    public class Dan
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public Dan()
        {
        }

        public Dan(int id, string naziv)
        {
            Id = id;
            Naziv = naziv;
        }

        public int dohvatiDanBroj()
        {
            return Id;
        }
        public string dohvatiNazivDana()
        {
            return Naziv;
        }

    }
}
