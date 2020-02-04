using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_3.Entiteti;

namespace mkolaric1_zadaca_3.FactoryMethod
{
    class TvParametriConcreateCreator:Creator
    {
        
        TvProgrami tv= new TvProgrami();
        protected override void DodajPodatke()
        {
            if (File.Exists(putanja))
            {
                string[] red = File.ReadAllLines(putanja).Skip(1).ToArray();
                foreach (var r in red)
                {
                    string [] parametri= r.Trim().Split(';');
                    if (parametri.Length!=5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("POGREŠKA: prilikom učitavanja Tv parametara - red: " + r);
                        Console.ResetColor();
                    }
                    else
                    {
                        tv = new TvProgrami(int.Parse(parametri[0]), parametri[1], TimeSpan.Parse(parametri[2]), TimeSpan.Parse(parametri[3]), parametri[4]);
                        ListaEntiteta.Add(tv);
                    }
                    if (parametri[3].Equals("") || parametri[3].Equals(TimeSpan.Parse("00:00:00")))
                    {
                        red[3] = "23:59:00";
                    }

                }
            }
        }
    }
}
