using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_2.Entiteti;

namespace mkolaric1_zadaca_2.FactoryMethod
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
                    string [] parametri= r.Split(';');
                    if (parametri.Length > 5)
                    {
                        Console.WriteLine("Ne ispravan broj parametara u datoteci tvkuca.txt");
                    }
                    if (parametri[3].Equals("") || parametri[3].Equals(TimeSpan.Parse("00:00:00")))
                    {
                        red[3] = "23:59:00";
                    }
                    tv=new TvProgrami(int.Parse(parametri[0]),parametri[1],TimeSpan.Parse(parametri[2]),TimeSpan.Parse(parametri[3]),parametri[4] );
                    ListaEntiteta.Add(tv);
                }
            }
        }
    }
}
