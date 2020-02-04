using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Decorator;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_3.Entiteti;
using mkolaric1_zadaca_3.Singleton;

namespace mkolaric1_zadaca_3.Memento
{
    public class ConcreteMeneto: Memento
    {
        private List<IRasporedEmisija> raspored;
        private DateTime datum;
        public int RedniBroj { get; set; } = 0;
        public ConcreteMeneto(List<IRasporedEmisija> raspored)
        {
            this.raspored = new List<IRasporedEmisija>();
            foreach (TvProgrami tvProgram in raspored)
            {
                this.raspored.Add((TvProgrami)tvProgram.clone());
            }

            datum = DateTime.Now;
        }
        public string GetName()
        {
            string ispis= $"{this.datum} - " + "Pohrana "+RedniBroj+". " + "\n";
            return ispis;
        }

        public List<IRasporedEmisija> GetState()
        {
            return raspored;
        }

        public void IspisiRaspored()
        {
            
            foreach (TvProgrami programi in raspored)
            {
                foreach (DanComposite dani in programi.listaDana)
                {
                    Component proba = new Decorator(dani);
                    proba.IspisCijelogRasporeda(programi, dani);
                }
            }
           
        }
        public DateTime GetDate()
        {
            return this.datum;
        }

        public int GetRedniBroj()
        {
            return RedniBroj;
        }

    }
}
