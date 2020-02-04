using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Decorator;
using mkolaric1_zadaca_1.Dodaci;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_1.FactoryMethod;
using mkolaric1_zadaca_1.Iterator;
using mkolaric1_zadaca_2.Dodaci;
using mkolaric1_zadaca_2.Entiteti;
using mkolaric1_zadaca_2.FactoryMethod;
using mkolaric1_zadaca_2.Singleton;

namespace mkolaric1_zadaca_2
{
    class GlavniProgram
    { 
        
        static void Main(string[] args)
        {
            List<Program> listaEmitiranja=new List<Program>();
            TvProgrami tv = new TvProgrami();
            List<EmitiranjeEmisija> listeEmisijaUProgramu = new List<EmitiranjeEmisija>();
            if (!ProvjeraUlaznihParametara.ProvjeraParametara(args))
            {
                Console.WriteLine("Neispravan unos argumenata");
                return;
            }
            Dictionary<string, string> parametri = ProvjeraUlaznihParametara.VratiKljucVrijednost(args);
            UcitavanjeDatotekaPrograma ucitavanje=new UcitavanjeDatotekaPrograma();
            ucitavanje.listaProgramaKuce(parametri);
            ucitavanje.listaVrstaEmisija(parametri);
            ucitavanje.listaSvihEmisija(parametri);
             ucitavanje.listaSvihOsoba(parametri);
            ucitavanje.listaSvihUloga(parametri);
            var lista = TvKucaSingleton.GetInstance().ListaPrograma;
            foreach (var program in lista)
            {
                int index = TvKucaSingleton.GetInstance().ListaPrograma.IndexOf(program);
                TvKucaSingleton.GetInstance().indexPrograma = index;
                 listaEmitiranja = program.ucitajProgram(program.NazivDatoteke);
               listeEmisijaUProgramu=program.kreirajEmitiranja(listaEmitiranja, ucitavanje.listaEmisijaUkupno);
               Raspored r=new Raspored(listaEmitiranja, listeEmisijaUProgramu, program);
               //r.emisijeSPocetkom(listaEmitiranja, listeEmisijaUProgramu);
            }
           
            

            TvKucaSingleton tvKuca = TvKucaSingleton.GetInstance();

            bool prikaz = true;
            while (prikaz)
            {
                prikaz = prikazIzbornika();
            }
        }

        public static bool prikazIzbornika()
        {
            Console.WriteLine("Odaberi opciju:");
            Console.WriteLine("1) Prikaz vremenskog plana za dan i program u tjednu");
            Console.WriteLine("2) Prikaz prihoda od reklama");
            Console.WriteLine("3) Prikaz vrste emisija");
            Console.WriteLine("4) Promjena osobe i uloge");
            Console.WriteLine("9) Exit");
            Console.Write("\r\nOdaberi opciju: ");
            switch (Console.ReadLine())
            {
                case "1":
                    ispisPorgramaEmisije();
                    return true;
                case "2":
                    ispisPrihoda();
                    return true;
                case "3":
                    IspisVrstaEmisija();
                    return true;
                case "4":
                    return true;
                case "9":
                    return false;
                default:
                    return true;
            }
           

        }

        public static void ispisPorgramaEmisije()
        {
            TvKucaSingleton program=TvKucaSingleton.GetInstance();
            Console.Write("Unesite program:");
            int broj = int.Parse(Console.ReadLine());
            if (broj > program.rasporedPrograma.Count)
            {
                Console.WriteLine("Unjeli ste program koji ne postoji");
            }
            else
            {
                Console.Write("Unesite dan:");
                int dan = int.Parse(Console.ReadLine());
                if (dan > 7 || dan < 1)
                {
                    Console.WriteLine("Unjeli ste dan koji ne postoji");
                }
                else
                {
                   IspisTablice(broj,dan);
                }
            }
        }

        public static void IspisTablice(int program, int dan)
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
                            proba.Ispisi();
                        }
                    }
                }
                
            }
        }
        public static void ispisPrihoda()
        {
            TvKucaSingleton program = TvKucaSingleton.GetInstance();
            Console.Write("Unesite program:");
            int broj = int.Parse(Console.ReadLine());
            if (broj > program.rasporedPrograma.Count)
            {
                Console.WriteLine("Unjeli ste program koji ne postoji");
            }
            else
            {
                Console.Write("Unesite dan:");
                int dan = int.Parse(Console.ReadLine());
                if (dan > 7 || dan < 1)
                {
                    Console.WriteLine("Unjeli ste dan koji ne postoji");
                }
                else
                {
                    IspisSume(broj,dan);
                }
            }
        }
        public static void IspisSume(int program, int dan)
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

        public static void IspisVrstaEmisija()
        {
            Console.WriteLine("1) informativna");
            Console.WriteLine("2) dokumentarna");
            Console.WriteLine("3) film");
            Console.WriteLine("4) serija");
            Console.WriteLine("5) zabava");
            Console.WriteLine("6) sport");
            Console.WriteLine("7) kviz");
            Console.WriteLine("8) animirani film");
            Console.WriteLine("9) mozaik");
            Console.Write("Odaberite vrstu emisije za koju želite prikaz:");
            int izbor = int.Parse(Console.ReadLine());
            foreach (TvProgrami prog in TvKucaSingleton.GetInstance().rasporedPrograma)
            {
                foreach (DanComposite dani in prog.listaDana)
                {
                    Component raspored = new Decorator(dani);
                    raspored.IspisPremaVrsti(prog,dani,izbor);
                }
            }
        }
    }

}
