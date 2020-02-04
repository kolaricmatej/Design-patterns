using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_3.Entiteti;

namespace mkolaric1_zadaca_3.FactoryMethod
{
    public class UlogaConcreateCreator:Creator
    {
        Uloga uloga=new Uloga();
        protected override void DodajPodatke()
        {
            if (File.Exists(putanja))
            {
                string[] red = File.ReadAllLines(putanja).Skip(1).ToArray();
                foreach (var r in red)
                {
                    string[] parametri = r.Trim().Split(';');
                    if (parametri.Length==2)
                    {
                        uloga = new Uloga(int.Parse(parametri[0]), parametri[1]);
                        ListaEntiteta.Add(uloga);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("POGREŠKA: prilikom učitavanja uloga - red: " + r);
                        Console.ResetColor();
                        return;
                    }
                }
            }
        }
    }
}
