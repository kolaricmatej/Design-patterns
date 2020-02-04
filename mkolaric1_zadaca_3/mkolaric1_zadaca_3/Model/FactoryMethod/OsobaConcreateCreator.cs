using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Dodaci;
using mkolaric1_zadaca_3.Entiteti;

namespace mkolaric1_zadaca_3.FactoryMethod
{
    public class OsobaConcreateCreator: Creator
    {
        protected override void DodajPodatke()
        {
            if (File.Exists(putanja))
            {
                string[] red = File.ReadAllLines(putanja).Skip(1).ToArray();
                foreach (var r in red)
                {
                    Osoba osoba = new Osoba();
                    string[] parametri = r.Trim().Split(';');
                    if (parametri.Length > 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("POGREŠKA: prilikom učitavanja osoba - red: " + r);
                        Console.ResetColor();
                    }
                    else
                    {
                        osoba.Id = int.Parse(parametri[0]);
                        osoba.Naziv = parametri[1];
                        ListaEntiteta.Add(osoba);
                    }
                }
            }
        }
    }
}
