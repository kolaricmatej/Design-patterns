using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_1.FactoryMethod;
using mkolaric1_zadaca_3.Entiteti;
using mkolaric1_zadaca_3.FactoryMethod;
using mkolaric1_zadaca_3.Singleton;

namespace mkolaric1_zadaca_1.Dodaci
{
    class UcitavanjeDatotekaPrograma
    {
        public List<TvProgrami> listaTVparametara { get; set; }
        public List<Emisija> listaEmisijaUkupno { get; set; }
        public List<Osoba> listaOsobaUkupno { get; set; }
        public List<Uloga> listaUlogaUkupno { get; set; }
        public List<VrstaEmisije> listaVrstaEmisije { get; set; }


        public List<TvProgrami> listaProgramaKuce(Dictionary<string, string> parametri)
        {
            Creator listaTvPrograma = new TvParametriConcreateCreator();
            listaTvPrograma.DodajPutanju(parametri["-t"]);
            listaTVparametara = listaTvPrograma.ListaEntiteta.Cast<TvProgrami>().ToList();
            TvKucaSingleton.GetInstance().ListaPrograma = listaTVparametara;
            return listaTVparametara;
        }


        public List<Emisija> listaSvihEmisija(Dictionary<string, string> parametri)
        {
            List<Emisija>lista=new List<Emisija>();
            Creator listaEmisija = new EmisijaConcreateCreator();
            listaEmisija.DodajPutanju(parametri["-e"]);
            listaEmisijaUkupno = listaEmisija.ListaEntiteta.Cast<Emisija>().ToList();
            foreach (var emisija in listaEmisijaUkupno)
            {
                foreach (var vrsta in listaVrstaEmisije)
                {
                    if (emisija.VrstaEmisije == vrsta.Id)
                    {
                        emisija.vrsta=new VrstaEmisije(vrsta.Id,vrsta.Vrsta,vrsta.Reklama,vrsta.Trajanje);
                    }
                }
            }
            return listaEmisijaUkupno;
        }

        public List<Osoba> listaSvihOsoba(Dictionary<string, string> parametri)
        {
            List<Osoba> lista=new List<Osoba>();
            Creator listaOsoba = new OsobaConcreateCreator();
            listaOsoba.DodajPutanju(parametri["-o"]);
            listaOsobaUkupno = listaOsoba.ListaEntiteta.Cast<Osoba>().ToList();
            return listaOsobaUkupno;
        }

        public List<Uloga> listaSvihUloga(Dictionary<string, string> parametri)
        {
            List<Uloga>lista=new List<Uloga>();
            Creator listaUloga = new UlogaConcreateCreator();
            listaUloga.DodajPutanju(parametri["-u"]);
            listaUlogaUkupno = listaUloga.ListaEntiteta.Cast<Uloga>().ToList();
            return listaUlogaUkupno;
        }
        public List<VrstaEmisije> listaVrstaEmisija(Dictionary<string, string> parametri)
        {
            List<VrstaEmisije> lista = new List<VrstaEmisije>();
            Creator listaVrsteEmisija = new VrstaEmisijeConcreateCreator();
            listaVrsteEmisija.DodajPutanju(parametri["-v"]);
            listaVrstaEmisije = listaVrsteEmisija.ListaEntiteta.Cast<VrstaEmisije>().ToList();
            return listaVrstaEmisije;
        }
    }
}
