using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Decorator;
using mkolaric1_zadaca_3.Entiteti;
using mkolaric1_zadaca_3.Singleton;

namespace mkolaric1_zadaca_3.View
{
    class Pogled2:IView
    {
        public static int rednibroj = 0;
        public void NeispravanUnosArgumenata(bool ispravno)
        {
            if (ispravno)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ispisRednogBroja()+"Neispravan unos argumenata");
                Console.ResetColor();
            }

        }
        public void prikazIzbornika()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(ispisRednogBroja()+"-----------------------------------------------------\n");
            Console.Write(ispisRednogBroja() + "IZBORNIK\n");
            Console.ResetColor();
            Console.Write(ispisRednogBroja() + "1) Prikaz vremenskog plana za dan i program u tjednu\n");
            Console.Write(ispisRednogBroja() + "2) Prikaz prihoda od reklama\n");
            Console.Write(ispisRednogBroja() + "3) Prikaz vrste emisija\n");
            Console.Write(ispisRednogBroja() + "4) Promjena osobe i uloge\n");
            Console.Write(ispisRednogBroja() + "5) Obrisi emisiju prema ID\n");
            Console.Write(ispisRednogBroja() + "6) Prikazi povijest pohranjivanja\n");
            Console.Write(ispisRednogBroja() + "7) Vrati željeni zapis\n");
            Console.Write(ispisRednogBroja() + "8) Prikazi raspored uz CoF\n");
            Console.Write(ispisRednogBroja() + "9) Promjeni pogled\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(ispisRednogBroja() + "10) Exit\n");
            Console.Write(ispisRednogBroja() + "-----------------------------------------------------\n");
            Console.ResetColor();
            Console.Write(ispisRednogBroja() + "Odaberi opciju: ");

        }
        public void ispisPorgramaEmisije(string programi)
        {
            Console.WriteLine(ispisRednogBroja()+programi);
            Console.Write(ispisRednogBroja() + "Unesite redni broj programa:");
        }
        public void UnosPrograma(TvKucaSingleton program, int broj)
        {
            if (!program.ListaPrograma.Exists(e => e.Id == broj))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ispisRednogBroja() + "Unjeli ste program koji ne postoji");
                Console.ResetColor();
            }
        }
        public void UnosDana()
        {
            Console.Write(ispisRednogBroja() + "Unesite dan:");
        }

        public void provjeraDana(int dan)
        {
            if (dan > 7 || dan < 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ispisRednogBroja() + "Unjeli ste dan koji ne postoji");
                Console.ResetColor();
            }
        }


        public void IspisVrstaEmisija()
        {
            Console.WriteLine(ispisRednogBroja() + "1) informativna");
            Console.WriteLine(ispisRednogBroja() + "2) dokumentarna");
            Console.WriteLine(ispisRednogBroja() + "3) film");
            Console.WriteLine(ispisRednogBroja() + "4) serija");
            Console.WriteLine(ispisRednogBroja() + "5) zabava");
            Console.WriteLine(ispisRednogBroja() + "6) sport");
            Console.WriteLine(ispisRednogBroja() + "7) kviz");
            Console.WriteLine(ispisRednogBroja() + "8) animirani film");
            Console.WriteLine(ispisRednogBroja() + "9) mozaik");
            Console.Write(ispisRednogBroja() + "Odaberite vrstu emisije za koju želite prikaz:");

        }

        public void ObrisiEmisijuPremaID()
        {
            Console.Write(ispisRednogBroja() + "Unesite broj emisije koju želite obrisati: ");
        }

        public void PrikaziPovijest()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(ispisRednogBroja() + "PRIKAZ POVIJESTI");
            Console.WriteLine(ispisRednogBroja() + "-----------------------------------------------------");
            Console.ResetColor();
        }

        public void VratiZeljeniZapis()
        {
            Console.Write(ispisRednogBroja() + "Unesite broj zapisa kojeg želite vratiti: "); ;
        }

        public void UnosPassworda()
        {
            Console.Write(ispisRednogBroja() + "Unesite password za otkljucavanje: ");

        }

        public void Netocnalozinka()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine(ispisRednogBroja() + "Nemate dopuštenje za pregled rasporeda");
            Console.ResetColor();
        }

        public void PrikazPogleda()
        {
            Console.WriteLine(ispisRednogBroja()+"POGLED 1: Uobičajni pogled");
            Console.WriteLine(ispisRednogBroja()+"POGLED 2: Pogled sa numeracijom");
            Console.WriteLine(ispisRednogBroja()+"Unesite broj pogleda koji želite prikazati:");
        }

        public void NeispravanPogled()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ispisRednogBroja()+"Neispravan usnos");
            Console.ResetColor();
        }

        private static string ispisRednogBroja()
        {
            rednibroj++;
            string ispis = "";
            switch (true)
            {
                case true when rednibroj < 10:
                    return "[" + "0000" + (rednibroj) + "] ";
                case true when rednibroj < 100:
                    return "[" + "000" + (rednibroj - 1) + "] ";
                case true when rednibroj < 1000:
                    return "[" + "00" + (rednibroj) + "] ";
                case true when rednibroj < 10000:
                    return "[" + "0" + (rednibroj) + "] ";
                case true when rednibroj < 100000:
                    return "[" +  (rednibroj) + "] ";
            }
            return null;
        }
    }
}
