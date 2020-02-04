using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Iterator;
using mkolaric1_zadaca_2.Entiteti;

namespace mkolaric1_zadaca_1.Decorator
{
    public class Decorator:Component
    {
        protected Component Komponenta;
        bool postaviZaglavlje = false;
        public Decorator(Component komponenta)
        {
            this.Komponenta = komponenta;
        }
        public List<IRasporedEmisija> Ispisi()
        {
            List<IRasporedEmisija> ispis = Komponenta.Ispisi();
            IAbstractIterator iterator=new ConcreateIterator(ispis);
            Console.Write(new string('-', 94) + "\n");
            Console.Write($"|{"Naziv programa",-40}|{"Pocetak",25}|{"Kraj",25}|\n");
            Console.Write(new string('-',94)+"\n");
            while (iterator.hasNext())
            {
                IRasporedEmisija raspored = iterator.Next();
                Console.Write($"|{((EmisijaLeaf) raspored).Emisija.Emisija.naziv,-40}|{((EmisijaLeaf) raspored).Emisija.Pocetak,25}|{((EmisijaLeaf) raspored).Emisija.Kraj,25}|\n");
            }

            Console.WriteLine(new string('-',94));
            return null;
        }

        public int Prihod()
        {
            List<IRasporedEmisija> ispis = Komponenta.Ispisi();
            IAbstractIterator iterator = new ConcreateIterator(ispis);
            Console.Write(new string('-', 94) + "\n");
            Console.Write($"|{"Naziv programa",-40}|{"Vrsta emisije",-25}|{"Trajanje",25}|\n");
            Console.Write(new string('-', 94) + "\n");
            while (iterator.hasNext())
            {
                IRasporedEmisija raspored = iterator.Next();
                Console.Write($"|{((EmisijaLeaf)raspored).Emisija.Emisija.naziv,-40}|{((EmisijaLeaf)raspored).Emisija.Emisija.vrsta.Vrsta,-25}|{((EmisijaLeaf)raspored).Emisija.Emisija.vrsta.Trajanje,25}|\n");
            }
            Console.Write(new string('-', 94) + "\n");
            Console.Write($"|{"Prihodi u minutama",-40}|{"",-40}{Komponenta.Prihod(),11}|\n");
            Console.Write(new string('-',94)+"\n");
            return 0;
        }

        public List<IRasporedEmisija> IspisPremaVrsti(TvProgrami program, DanComposite dan,int vrsta)
        {
            
            List<IRasporedEmisija> prikaz = Komponenta.IspisPremaVrsti(program,dan,vrsta);
            IAbstractIterator iterator=new ConcreateIteratorVrsta(prikaz,vrsta);
            if (iterator.hasNext())
            {
                if (!postaviZaglavlje)
                {
                    Console.Write(new string('-',122)+"\n");
                    Console.Write($"|{"Program",-20}|{"Dan",-15}|{"Naziv Emisije",-40}|{"Pocetak",20}|{"Kraj",20}\n");
                    Console.Write(new string('-',122)+"\n");
                    postaviZaglavlje = true;
                }
            }

            IRasporedEmisija raspored = iterator.First();
            while (!iterator.IsDone)
            {
                
                Console.Write($"|{program.Naziv,-20}|{dan.Dan.Naziv,-15}|{((EmisijaLeaf) raspored).Emisija.Emisija.naziv,-40}|{((EmisijaLeaf) raspored).Emisija.Pocetak,20}|{((EmisijaLeaf) raspored).Emisija.Kraj,20}\n");
                raspored = iterator.Next();
            }
            return null;
        }
    }
}
