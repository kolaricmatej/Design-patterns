using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Iterator;
using mkolaric1_zadaca_3.Entiteti;
using mkolaric1_zadaca_3.Singleton;

namespace mkolaric1_zadaca_3.Memento
{
   public class Caretaker
    {
        private List<Memento> listaMemento=new List<Memento>();
        private Originator originator = null;
        public Caretaker(Originator originator)
        {
            this.originator = originator;
        }

        public void Backup()
        {
            this.listaMemento.Add(this.originator.Save());
        }

        public void ShowHistory()
        {
            foreach (var memento in listaMemento)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(memento.GetName());
                Console.WriteLine("-----------------------------------------------------");
                Console.ResetColor();
                memento.IspisiRaspored();
            }
        }

        public void vratiZeljeniZapis(int redniBroj)
        {
            if (this.listaMemento.Count == 0)
            {
                return;
            }

            var memento = this.listaMemento.FirstOrDefault(a => a.GetRedniBroj() == redniBroj);
           Console.WriteLine("VRAČANJE ZAPISA NA: "+redniBroj+" Datum izmjene: "+memento.GetDate());
            originator.Restore(memento);
            
        }
    }
}
