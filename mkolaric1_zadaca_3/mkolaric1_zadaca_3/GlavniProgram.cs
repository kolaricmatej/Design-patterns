using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Decorator;
using mkolaric1_zadaca_1.Dodaci;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_1.FactoryMethod;
using mkolaric1_zadaca_1.Iterator;
using mkolaric1_zadaca_3.CoR;
using mkolaric1_zadaca_3.FactoryMethod;
using mkolaric1_zadaca_3.Dodaci;
using mkolaric1_zadaca_3.Entiteti;
using mkolaric1_zadaca_3.Memento;
using mkolaric1_zadaca_3.Singleton;
using mkolaric1_zadaca_3.View;

namespace mkolaric1_zadaca_3
{
    class GlavniProgram
    { 
        
        static void Main(string[] args)
        {
            //--->
            Model.Model model=new Model.Model();
            Pogled pogled =new Pogled();
            Controller.Controller controler = new Controller.Controller(model,pogled);
            //<---
            List<Program> listaEmitiranja=new List<Program>();
            TvProgrami tv = new TvProgrami();
            List<EmitiranjeEmisija> listeEmisijaUProgramu = new List<EmitiranjeEmisija>();
            controler.getProvjeraParametara(args);
            Dictionary<string, string> parametri = ProvjeraUlaznihParametara.VratiKljucVrijednost(args);
            UcitavanjeDatotekaPrograma ucitavanje=new UcitavanjeDatotekaPrograma();
            ucitavanje.listaProgramaKuce(parametri);
            ucitavanje.listaVrstaEmisija(parametri);
            ucitavanje.listaSvihEmisija(parametri);
            ucitavanje.listaSvihOsoba(parametri);
            ucitavanje.listaSvihUloga(parametri);
            var lista = TvKucaSingleton.GetInstance().ListaPrograma;
            foreach (var program in lista)
            { 
                int index = TvKucaSingleton.GetInstance().ListaPrograma.IndexOf(program);
                TvKucaSingleton.GetInstance().indexPrograma = index; 
                listaEmitiranja = program.ucitajProgram(program.NazivDatoteke);
                listeEmisijaUProgramu=program.kreirajEmitiranja(listaEmitiranja, ucitavanje.listaEmisijaUkupno);
                Raspored r=new Raspored(listaEmitiranja, listeEmisijaUProgramu, program);
            }
            Originator o = new Originator(TvKucaSingleton.GetInstance().rasporedPrograma);
            Caretaker c = new Caretaker(o);
            TvKucaSingleton tvKuca = TvKucaSingleton.GetInstance();
            bool prikaz = true;
            while (prikaz)
            {
                prikaz=controler.unesiOdabirIzbornika();
            }
        }


        public void OdaberiPogled()
        {
            Console.WriteLine("Unesite broj pogleda koji želite prikazati");
            int izbor = int.Parse(Console.ReadLine());
            Pogled pogled =new Pogled();
            if (izbor == 1)
            {
                //pogled.postaviPogled();
            }else if (izbor == 2)
            {
                //pogled.postaviPogledSaZagradama();
            }
            else
            {
                Console.WriteLine("Neispravan usnos");
            }

        }
    }
}
