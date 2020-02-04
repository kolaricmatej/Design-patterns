using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Osnovno;

namespace mkolaric1_zadaca_1.Ucitavanje
{
    class EmisijaFactory : Ucitavanje
    {
        List<Emisija> listaEmisijaParam = new List<Emisija>();
        private Emisija e = new Emisija();
        private int id;
        private string naziv;
        private int trajanje;
        private List<int> osoba1;
        private List<int> osoba2;

        public override void UcitajZapise(string filePath)
        {
            String red;
            Boolean error = false;
            string message = "";
            StreamReader file = new StreamReader(filePath);
            file.ReadLine();

            while ((red = file.ReadLine()) != null)
            {
                String[] splitLine = red.Split(';', ',');
                String key;
                String value;
                if (splitLine.Count() > 1 || splitLine.Count() <= 4)
                {
                    id = int.Parse(splitLine[0]);
                    naziv = splitLine[1];
                    trajanje = int.Parse(splitLine[2]);
                    if (splitLine.Length > 3 && !splitLine[3].Equals(""))
                    {
                        osoba1 = e.kreirajOsobaUloga(splitLine[3]);
                        if (splitLine.Length > 4 && !splitLine[4].Equals(""))
                        {
                            osoba2 = e.kreirajOsobaUloga(splitLine[4]);
                        }
                    }
                    e = new Emisija(id, naziv, trajanje, osoba1, osoba2);
                    listaEmisijaParam.Add(e);
                }
                else
                {
                    message = "Svojstvo je preskočeno - " + red + "zbog prevelikog broja argumenata";
                }
            }
        }

        public List<Emisija> GetList(string filePath)
        {
            UcitajZapise(filePath);
            return listaEmisijaParam;
        }
    }
}
