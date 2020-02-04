using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_3.Prototype;

namespace mkolaric1_zadaca_1.Composite
{
    public class Dan:Prototype
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

        public Prototype clone()
        {
            return new Dan(this.Id,this.Naziv);
        }
    }
}
