using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Osnovno;


namespace mkolaric1_zadaca_1.Ucitavanje
{
    class OsobaFactory : Ucitavanje
    {
        private List<Osoba> listaOsoba = new List<Osoba>();
        Osoba o = new Osoba();
        public override void UcitajZapise(string filePath)
        {
            String red;
            Boolean error = false;
            string message = "";
            StreamReader file = new StreamReader(filePath);
            file.ReadLine();

            while ((red = file.ReadLine()) != null)
            {
                String[] splitLine = red.Split(';');
                String key;
                String value;
                if (splitLine.Count() == 2)
                {
                    int id = int.Parse(splitLine[0]);
                    string naziv = splitLine[1];
                    o = new Osoba(id, naziv);
                    listaOsoba.Add(o);
                }

                else
                {
                    message = "Svojstvo je preskočeno - " + red + "zbog prevelikog/premalog broja argumenata";
                }
            }
        }

        public List<Osoba> GetList(string filePath)
        {
            UcitajZapise(filePath);
            return listaOsoba;

        }
    }
}
