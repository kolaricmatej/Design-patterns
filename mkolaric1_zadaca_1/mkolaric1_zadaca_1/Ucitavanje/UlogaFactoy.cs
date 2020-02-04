using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Osnovno;


namespace mkolaric1_zadaca_1.Ucitavanje
{
    class UlogaFactoy : Ucitavanje
    {
        List<Uloga> listaUloga = new List<Uloga>();
        Uloga u = new Uloga();
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
                    string opis = splitLine[1];
                    u = new Uloga(id, opis);
                    listaUloga.Add(u);
                }
                else
                {
                    message = "Svojstvo je preskočeno - " + red + "zbog prevelikog/premalog broja argumenata";
                }
            }

        }

        public List<Uloga> GetList(string filePath)
        {
            UcitajZapise(filePath);
            return listaUloga;
        }
    }
}
