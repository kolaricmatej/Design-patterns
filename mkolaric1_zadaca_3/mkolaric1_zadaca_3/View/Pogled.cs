using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Decorator;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_3.CoR;
using mkolaric1_zadaca_3.Entiteti;
using mkolaric1_zadaca_3.Memento;
using mkolaric1_zadaca_3.Singleton;

namespace mkolaric1_zadaca_3.View
{
    public class Pogled:IView
    {
        public void NeispravanUnosArgumenata(bool ispravno)
        {
            if (ispravno)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Neispravan unos argumenata");
                Console.ResetColor();
            }
            
        }
        public void prikazIzbornika()
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("-----------------------------------------------------\n");
            Console.Write("IZBORNIK\n");
            Console.ResetColor();
            Console.Write("1) Prikaz vremenskog plana za dan i program u tjednu\n");
           Console.Write("2) Prikaz prihoda od reklama\n");
            Console.Write("3) Prikaz vrste emisija\n");
           Console.Write("4) Promjena osobe i uloge\n");
            Console.Write("5) Obrisi emisiju prema ID\n");
           Console.Write("6) Prikazi povijest pohranjivanja\n");
             Console.Write("7) Vrati željeni zapis\n");
            Console.Write("8) Prikazi raspored uz CoF\n");
            Console.Write("9) Promjeni pogled\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("10) Exit\n");
            Console.Write("-----------------------------------------------------\n");
            Console.ResetColor();
            Console.Write("Odaberi opciju: ");

        }
        public void ispisPorgramaEmisije(string programi)
        {
            Console.WriteLine(programi);
            Console.Write("Unesite redni broj programa:");
        }
        public void UnosPrograma(TvKucaSingleton program, int broj)
        {
            if (!program.ListaPrograma.Exists(e => e.Id == broj))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Unjeli ste program koji ne postoji");
                Console.ResetColor();
            }
        }
        public void UnosDana()
        {
            Console.Write("Unesite dan:");
        }

        public void provjeraDana(int dan)
        {
            if (dan > 7 || dan < 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Unjeli ste dan koji ne postoji");
                Console.ResetColor();
            }
        }

        public  void IspisVrstaEmisija()
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
           
        }

        public void ObrisiEmisijuPremaID()
        {
            Console.Write("Unesite broj emisije koju želite obrisati: ");
        }

        public void PrikaziPovijest()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("PRIKAZ POVIJESTI");
            Console.WriteLine("-----------------------------------------------------");
            Console.ResetColor();
        }

        public void VratiZeljeniZapis()
        {
            Console.Write("Unesite broj zapisa kojeg želite vratiti: "); ;
        }

        public  void UnosPassworda()
        {
            Console.Write("Unesite password za otkljucavanje: ");

        }

        public void Netocnalozinka()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine("Nemate dopuštenje za pregled rasporeda");
            Console.ResetColor();
        }

        public void PrikazPogleda()
        {
            Console.WriteLine("POGLED 1: Uobičajni pogled");
            Console.WriteLine("POGLED 2: Pogled sa numeracijom");
            Console.WriteLine("Unesite broj pogleda koji želite prikazati:");
        }

        public void NeispravanPogled()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Neispravan usnos");
            Console.ResetColor();
        }
    }
}
