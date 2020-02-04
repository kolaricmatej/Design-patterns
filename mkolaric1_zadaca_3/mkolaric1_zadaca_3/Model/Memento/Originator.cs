using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_3.Entiteti;

namespace mkolaric1_zadaca_3.Memento
{
    public class Originator
    { 
        private List<IRasporedEmisija> _raspored=new List<IRasporedEmisija>();
        private static int broj = 0;

        public Originator(List<IRasporedEmisija> _raspored)
        {
            this._raspored = _raspored;
        }

        public void obrisiEmisiju(int redniBroj)
        {
            foreach (TvProgrami programi in _raspored)
            {
                foreach (DanComposite dan in programi.listaDana)
                {
                    var itemToRemove =dan.listaEmisija.SingleOrDefault(r =>((EmitiranjeEmisija)r).RedniBroj == redniBroj);
                    if (dan.listaEmisija.Contains(itemToRemove))
                    {
                        dan.listaEmisija.Remove(itemToRemove);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Obrisana emisija s rednim brojem: " + redniBroj);
                        Console.ResetColor();
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Emisija je već obrisana");
                        Console.ResetColor();
                        return;
                    }
                }
            }
        }

        public Memento Save()
        {
            broj++;
            ConcreteMeneto cm= new ConcreteMeneto(this._raspored);
            cm.RedniBroj = broj;
            return cm;
        }

        public void Restore(Memento memento)
        {
            if (!(memento is ConcreteMeneto))
            {
                throw new Exception("Memento ne postoji " + memento.ToString());
            }
            else
            {
               this._raspored= memento.GetState();
               Singleton.TvKucaSingleton.GetInstance().PostaviListu(this._raspored); 
            }
        }
    }
}
