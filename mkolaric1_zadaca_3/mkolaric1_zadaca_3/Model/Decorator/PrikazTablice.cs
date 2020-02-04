using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Decorator;

namespace mkolaric1_zadaca_3.Model.Decorator
{
    class PrikazTablice:Component
    {
        public string Tablica { get; set; }

        private List<Component> raspored;

        public PrikazTablice(List<Component> raspored)
        {
            this.raspored = raspored;
        }

        public PrikazTablice(Component raspored)
        {
            this.raspored.Add(raspored);
        }
        public string Ispisi()
        {
            if (raspored != null)
            {
                foreach (Component prikazEmisija in raspored)
                {
                    Tablica += prikazEmisija.Ispisi();
                }
            }
            return Tablica;
        }
    }
}
