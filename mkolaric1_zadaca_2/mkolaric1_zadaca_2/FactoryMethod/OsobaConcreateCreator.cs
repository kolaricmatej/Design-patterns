using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Dodaci;
using mkolaric1_zadaca_2.Entiteti;

namespace mkolaric1_zadaca_2.FactoryMethod
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
                    string[] parametri = r.Split(';');
                    if (parametri.Length > 2)
                    {
                        Console.WriteLine("Neispravan unos parametara u datoteci osobe.txt red:"+r);
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
