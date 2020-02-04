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
    public class ProgramConcreateCreator: Creator
    {
        public ProgramConcreateCreator(string naziv)
        {
            
        }
        protected override void DodajPodatke()
        {
            Program program;
            if (File.Exists(putanja))
            {
                string[] red = File.ReadAllLines(putanja).Skip(1).ToArray();
                foreach (var r in red)
                {
                    string[] parametri = r.Split(';');
                    if (parametri.Length > 5 || parametri.Length<3)
                    {
                        Console.WriteLine("Neispravan zapis- sadrži previše elemenata red: "+r,Console.ForegroundColor == ConsoleColor.Red);
                    }
                    else
                    {
                        program = new Program();
                        program.Id = int.Parse(parametri[0]);
                        program.DaniUTjednu= pretvorbaDana(parametri, program);
                        program.Pocetak = provjeraPocetka(parametri);
                        program.OsobaUloga = kreirajOsobaUlogu(parametri, program);
                        ListaEntiteta.Add(program);
                    }
                }
            }
        }

        private static List<int> kreirajOsobaUlogu(string[] parametri, Program program)
        {
            List<int> privremena = new List<int>();
            if (parametri.Length>3&&(parametri[3] != "" && parametri[3] != " "))
            {
                string[] osobaUloga = parametri[3].Split(',');
                foreach (var o in osobaUloga)
                {
                    privremena.AddRange( program.kreirajOsobaUloga(o));
                }
                return privremena;
            }
            return null;
        }

        private static TimeSpan provjeraPocetka(string[] parametri)
        {
            if (parametri.Length>2&& (parametri[2]==""||parametri[2]==" "))
            {
                return TimeSpan.Zero;
            }
            return TimeSpan.Parse(parametri[2]);
        }

        private static List<int> pretvorbaDana(string[] parametri, Program program)
        {
            if (parametri[1].Length > 1&&( parametri[1]!="" || parametri[1]!=" "))
            {
               return program.VratiDane(parametri[1]);
            }
            return null;
        }
    }
}
