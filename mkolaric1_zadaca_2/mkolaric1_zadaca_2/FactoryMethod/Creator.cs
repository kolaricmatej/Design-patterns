using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkolaric1_zadaca_2.FactoryMethod
{
    public abstract class Creator
    {
        protected string putanja;
        public List<Product> ListaEntiteta { get; set; } = new List<Product>();
        public void DodajPutanju(string putanja)
        {
            this.putanja = putanja;
            DodajPodatke();
        }

        protected abstract void DodajPodatke();


    }
}
