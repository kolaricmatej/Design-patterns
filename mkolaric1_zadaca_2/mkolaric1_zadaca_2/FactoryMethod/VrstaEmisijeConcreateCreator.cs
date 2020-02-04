using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_2.FactoryMethod;

namespace mkolaric1_zadaca_1.FactoryMethod
{
    class VrstaEmisijeConcreateCreator:Creator
    {
        protected override void DodajPodatke()
        {
            if (File.Exists(putanja))
            {
                string[] red = File.ReadAllLines(putanja).Skip(1).ToArray();
                foreach (var r in red)
                {
                    string[] parametri = r.Split(';');
                    if (parametri.Length != 4)
                    {
                        Console.WriteLine("Neispravno definirani parametri-red: " + r);
                    }
                    else
                    {
                        VrstaEmisije vrsta=new VrstaEmisije();
                        vrsta.Id =int.Parse(parametri[0]);
                        vrsta.Vrsta = parametri[1];
                        if (!ProvjeraPostojanjaReklama(parametri,r)) return;
                        vrsta.Reklama = int.Parse(parametri[2]);
                        if (ProvjeraPostojanjaTrajanja(parametri,r)) return;
                        vrsta.Trajanje = int.Parse(parametri[3]);
                        ListaEntiteta.Add(vrsta);
                    }
                }
            }
        }

        private static bool ProvjeraPostojanjaTrajanja(string[] parametri,string r)
        {
            int ulaz;
            if (!int.TryParse(parametri[3], out ulaz))
            {
                Console.WriteLine("Nema definirano trajanje reklame red: "+r, Console.ForegroundColor == ConsoleColor.Red);
                return true;
            }

            return false;
        }

        private static bool ProvjeraPostojanjaReklama(string[] parametri, string r)
        {
            int ulaz;
            if (!int.TryParse(parametri[2], out ulaz))
            {
                Console.WriteLine("Nema definirano postojanje reklame red: "+r, Console.ForegroundColor == ConsoleColor.Red);
                return false;
            }
            else
            {
                if (ulaz != 0 && ulaz != 1)
                {
                    Console.WriteLine("Nema definirano postojanje reklame red :"+r, Console.ForegroundColor == ConsoleColor.Red);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
