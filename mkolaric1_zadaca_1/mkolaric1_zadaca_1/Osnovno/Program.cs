using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkolaric1_zadaca_1.Osnovno
{
    class Program
    {
        public int Id { get; set; }
        public string DaniUTjednu { get; set; }
        public TimeSpan Pocetak { get; set; }
        public string OsobaUloga { get; set; }

        public Program()
        {

        }
        public Program(int id, string daniUTjednu, TimeSpan pocetak, string osobaUloga, string osobaUloga2)
        {
            Id = id;
            DaniUTjednu = daniUTjednu;
            Pocetak = pocetak;
            OsobaUloga = osobaUloga;
            OsobaUloga = osobaUloga2;
        }
    }
}
