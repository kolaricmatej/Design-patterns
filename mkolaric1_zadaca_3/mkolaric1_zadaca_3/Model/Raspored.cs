using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_3.Entiteti;
using mkolaric1_zadaca_3.Singleton;

namespace mkolaric1_zadaca_1
{
    public class Raspored
    {

        public IRasporedEmisija RasporedEmisija { get; set; }


        public Raspored(List<Program> listaProgram, List<EmitiranjeEmisija> listaEmisija, TvProgrami tvProgram)
        {
            kreirajOsnovniRaspored(listaProgram,listaEmisija,tvProgram);
            DodjeliTvKucuProgramima(tvProgram);
        }

        public void kreirajOsnovniRaspored(List<Program> listaProgram, List<EmitiranjeEmisija> listaEmisija,TvProgrami program)
        {
            RasporedEmisija = new TvProgrami(program.Id, program.Naziv, program.Pocetak, program.Kraj, program.NazivDatoteke);

                Dan d = new Dan(1, "Ponedjeljak");
                RasporedEmisija.Add(new DanComposite(d));
                program.listaDana.Add(new DanComposite(d));
                d = new Dan(2, "Utorak");
                program.listaDana.Add(new DanComposite(d));
                RasporedEmisija.Add(new DanComposite(d));
                d = new Dan(3, "Srijeda");
                RasporedEmisija.Add(new DanComposite(d));
                program.listaDana.Add(new DanComposite(d));
                d = new Dan(4, "Cetvrtak");
                RasporedEmisija.Add(new DanComposite(d));
                program.listaDana.Add(new DanComposite(d));
                d = new Dan(5, "Petak");
                RasporedEmisija.Add(new DanComposite(d));
                program.listaDana.Add(new DanComposite(d));
                d = new Dan(6, "Subota");
                RasporedEmisija.Add(new DanComposite(d));
                program.listaDana.Add(new DanComposite(d));
                d = new Dan(7, "Nedjelja");
                RasporedEmisija.Add(new DanComposite(d));
                program.listaDana.Add(new DanComposite(d));
                emisijeSPocetkom(listaProgram, listaEmisija);
                program.listaDana = ((TvProgrami)RasporedEmisija).listaDana;

        }
        public void DodjeliTvKucuProgramima(TvProgrami program)
        {

            TvKucaSingleton.GetInstance().Add(program);

        }


        public void emisijeSPocetkom(List<Program> listaProgram, List<EmitiranjeEmisija> listaEmisija)
        {

            for (int i = 1; i <= 7; i++) 
            { 
                List<EmitiranjeEmisija> listaObrisanih = new List<EmitiranjeEmisija>(); 
                List<Program> emisijeSDanimaIPocetkom = listaProgram.Where(e => e.DaniUTjednu != null && e.Pocetak != TimeSpan.Zero && e.DaniUTjednu.Contains(i)).OrderBy(e=>e.Pocetak).ToList();

                List<Program> emisijeSDanimaBezPocetka = listaProgram.Where(e => e.DaniUTjednu != null && e.Pocetak == TimeSpan.Zero && e.DaniUTjednu.Contains(i)).OrderBy(e => e.Pocetak).ToList();
                
                List<Program> emisijeBezDanaIBezPocetka = listaProgram.Where(e => e.DaniUTjednu == null && e.Pocetak == TimeSpan.Zero).ToList();
                
                DanComposite dan = ((TvProgrami)RasporedEmisija).getDan(i);
                if (emisijeSDanimaBezPocetka.Count != 0 || emisijeSDanimaIPocetkom.Count != 0)
                {
                    DodajEmisijeDanu(listaEmisija, emisijeSDanimaIPocetkom, dan, listaObrisanih);
                    DodajEmisijeDanu(listaEmisija, emisijeSDanimaBezPocetka, dan, listaObrisanih);
                    DodajEmisijeBezDana(listaEmisija, emisijeBezDanaIBezPocetka, dan);
                }
                else
                {
                    foreach (var emisija in emisijeBezDanaIBezPocetka.ToList())
                    {
                        EmitiranjeEmisija _emisija = listaEmisija.FirstOrDefault(e => e.Emisija.Id == emisija.Id);
                        _emisija.Pocetak = TvKucaSingleton.GetInstance().dohvatiPocetak();
                        _emisija.Kraj = _emisija.Pocetak + TimeSpan.FromMinutes(_emisija.Emisija.trajanje);
                        dan.Add(_emisija);
                        listaEmisija.Remove(_emisija);
                        emisijeBezDanaIBezPocetka.Remove(emisija);
                    }
                   
                }
                          
            }
            
        }
        private static void DodajEmisijeDanu(List<EmitiranjeEmisija> listaEmisija, List<Program> emisijeSDanimaIPocetkom, DanComposite dan,
            List<EmitiranjeEmisija> listaObrisanih)
        {
            foreach (var emisija in emisijeSDanimaIPocetkom)
            {
                EmitiranjeEmisija _emisija = listaEmisija.FirstOrDefault(e => e.Emisija.Id == emisija.Id);
                dan.Add(_emisija);
                listaObrisanih.Add(_emisija);
                listaEmisija.Remove(_emisija);
            }

            listaEmisija.AddRange(listaObrisanih);
        }
        private static void DodajEmisijeBezDana(List<EmitiranjeEmisija> listaEmisija, List<Program> emisijeBezDanaIBezPocetka, DanComposite dan)
        {
            if (emisijeBezDanaIBezPocetka.Count != 0)
            {
                foreach (var emisija in emisijeBezDanaIBezPocetka.ToList())
                {
                    EmitiranjeEmisija _emisija = listaEmisija.FirstOrDefault(e => e.Emisija.Id == emisija.Id);
                    if (_emisija != null)
                    {
                        dan.Add(_emisija);
                        listaEmisija.Remove(_emisija);
                        emisijeBezDanaIBezPocetka.Remove(emisija);
                    }
                }
            }

        }
    }
}
