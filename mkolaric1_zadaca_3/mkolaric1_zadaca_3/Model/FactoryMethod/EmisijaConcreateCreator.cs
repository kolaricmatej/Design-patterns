using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_3.Entiteti;

namespace mkolaric1_zadaca_3.FactoryMethod
{
    public class EmisijaConcreateCreator: Creator
    {
        protected override void DodajPodatke()
        {
            if (File.Exists(putanja))
            {
                string[] red = File.ReadAllLines(putanja).Skip(1).ToArray();
                foreach (var r in red)
                {
                    string[] parametri = r.Trim().Split(';');
                    if (parametri.Length > 6 || parametri.Length<3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("POGREŠKA: prilikom učitavanja emisija - red: " + r);
                        Console.ResetColor();
                    }
                    else
                    {
                        if (provjeraPostojanjaTrajanja(parametri,r)) return;
                        if (provjeraPostojanjaVrste(parametri, r)) return;
                        Emisija e=new Emisija();
                        e.Id = int.Parse(parametri[0]);
                        e.naziv = parametri[1];
                        e.VrstaEmisije =int.Parse(parametri[2]);
                        e.trajanje = int.Parse(parametri[3]);
                        e.OsobaUloga = definiranjeOsobaUloge(parametri, e);
                        ListaEntiteta.Add(e);
                    }
                }
            }
        }

        private static List<int> definiranjeOsobaUloge(string[] parametri, Emisija e)
        {
            List<int> privremena=new List<int>();
            if (parametri[4]!="" && parametri[4]!=" ")
            {
                string[] osobaUloga = parametri[4].Split(',');
                foreach (var o in osobaUloga)
                {
                    privremena= e.kreirajOsobaUloga(o);
                }
                return privremena;
            }
            return null;
        }

        private static bool provjeraPostojanjaTrajanja(string[] parametri, string r)
        {
            if (parametri[3].Equals("") || parametri[3].Equals(" "))
            {
                Console.WriteLine("Nema definirano trajanje -  red:"+ r, Console.ForegroundColor == ConsoleColor.Red);
                return true;
            }
            return false;
        }
        private static bool provjeraPostojanjaVrste(string[] parametri, string r)
        {
            if (parametri[2].Equals("") || parametri[2].Equals(" "))
            {
                Console.WriteLine("Nema definirano vrsta emisije - red:" + r, Console.ForegroundColor == ConsoleColor.Red);
                return true;
            }
            return false;
        }
    }
}
