using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkolaric1_zadaca_1
{
    class TvRaspored : TvHouseManagement
    {
        public int Id { get; set; }
        public List<int> Dani { get; set; }
        public TimeSpan Pocetak { get; set; }

        public TvRaspored()
        {

        }

        public TvRaspored(int id, List<int> dani, TimeSpan pocetak)
        {
            Id = id;
            Dani = dani;
            Pocetak = pocetak;
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
    }
}
