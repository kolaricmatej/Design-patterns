using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkolaric1_zadaca_1.Ucitavanje
{
    abstract class Ucitavanje
    {
        internal TvHouseManagement TvHouseManagement
        {
            get => default;
            set
            {
            }
        }

        public abstract void UcitajZapise(string filePath);
       
    }
}
