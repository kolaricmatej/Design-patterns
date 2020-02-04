using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Decorator;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_3.CoR;
using mkolaric1_zadaca_3.Dodaci;
using mkolaric1_zadaca_3.Entiteti;
using mkolaric1_zadaca_3.Memento;
using mkolaric1_zadaca_3.Singleton;

namespace mkolaric1_zadaca_3.Model
{
    public class Model
    {
        public TvKucaSingleton program;
        public Originator o;
        public Caretaker c;
        public Model()
        {
            program=TvKucaSingleton.GetInstance();
            o = new Originator(program.rasporedPrograma);
            c=new Caretaker(o);
        }
        public bool ispisProvjereParametara(string[] args)
        {
            if (!ProvjeraUlaznihParametara.ProvjeraParametara(args))
            {
                return true;
            }

            return false;
        }

        public string ispisPrograma()
        {
            string ispis = "";
            foreach (var programi in program.ListaPrograma)
            {
               ispis+= programi.Id + " " + programi.Naziv+"\n";
            }

            return ispis;
        }

        public void IspisSume(int program, int dan)
        {
            foreach (TvProgrami prog in TvKucaSingleton.GetInstance().rasporedPrograma)
            {
                if (prog.Id == program)
                {
                    foreach (DanComposite dani in prog.listaDana)
                    {
                        if (dani.Dan.Id == dan)
                        {
                            Component proba = new Decorator(dani);
                            proba.Prihod();
                        }
                    }
                }

            }
        }
        public void IspisPremaVrsti(int izbor)
        {
            foreach (TvProgrami prog in TvKucaSingleton.GetInstance().rasporedPrograma)
            {
                foreach (DanComposite dani in prog.listaDana)
                {
                    Component raspored = new Decorator(dani);
                    raspored.IspisPremaVrsti(prog, dani, izbor);
                }
            }
        }

        public  void ObrisiEmisiju(int broj)
        {
            foreach (TvProgrami prog in TvKucaSingleton.GetInstance().rasporedPrograma)
            {
                foreach (DanComposite dani in prog.listaDana)
                {
                    foreach (EmitiranjeEmisija e in dani.listaEmisija.ToList())
                    {
                        if (e.RedniBroj == broj)
                        {
                            c.Backup();
                            o.obrisiEmisiju(broj);
                            return;
                        }
                    }
                }
            }
            o.obrisiEmisiju(broj);
        }

        public  bool unosLozinke(string lozinka)
        {
            var lozinka1 = new Password1();
            var lozinka2 = new Password2();
            var lozinka3 = new Password3();

            lozinka1.SetNext(lozinka2).SetNext(lozinka3);
            return lozinka1.isAuthorised(lozinka);
        }

        public string sakrijLozinku()
        {
            string lozinka = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    lozinka += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && lozinka.Length > 0)
                    {
                        lozinka = lozinka.Substring(0, (lozinka.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);

            return lozinka;
        }

        public void IspisTablice(int program, int dan)
        {
            foreach (TvProgrami prog in TvKucaSingleton.GetInstance().dohvatiListu())
            {
                if (prog.Id == program)
                {
                    foreach (DanComposite dani in prog.listaDana)
                    {
                        if (dani.Dan.Id == dan)
                        {
                            Component proba = new Decorator(dani);
                            proba.Ispisi();
                        }
                    }
                }
            }
        }
    }
}
