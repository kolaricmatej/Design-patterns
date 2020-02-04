using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Dodaci;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_1.Iterator;
using mkolaric1_zadaca_3.FactoryMethod;

namespace mkolaric1_zadaca_3.Entiteti
{
   public class TvProgrami:Product, IRasporedEmisija,Aggregate,Prototype.Prototype
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public TimeSpan Pocetak { get; set; }
        public TimeSpan Kraj { get; set; }
        public string NazivDatoteke { get; set; }

        public List<Program> listaEmitiranjaPrograma;

        public List<EmitiranjeEmisija> listaEmitiranja=new List<EmitiranjeEmisija>();

        public List<IRasporedEmisija> listaDana = new List<IRasporedEmisija>();
        public TvProgrami()
        {

        }
        public TvProgrami(int id, string naziv, TimeSpan pocetak, TimeSpan kraj, string nazivDatoteke)
        {
            Id = id;
            Naziv = naziv;
            Pocetak = pocetak;
            Kraj = kraj;
            NazivDatoteke = nazivDatoteke;
        }

        public List<Program> ucitajProgram(string nazivDateke)
        {
            Creator listaPrograma = new ProgramConcreateCreator(nazivDateke);
            listaPrograma.DodajPutanju(nazivDateke);
            listaEmitiranjaPrograma = listaPrograma.ListaEntiteta.Cast<Program>().ToList();
            return listaEmitiranjaPrograma;
        }
        public List<EmitiranjeEmisija> kreirajEmitiranja(List<Program> listaPrograma, List<Emisija> listaEmisija)
        {
            foreach (var program in listaPrograma)
            {
                foreach (var emisija in listaEmisija)
                {
                    if (program.Id == emisija.Id)
                    {
                        EmitiranjeEmisija emEmisije = new EmitiranjeEmisija(emisija, program.Pocetak);
                        listaEmitiranja.Add((EmitiranjeEmisija)emEmisije.clone());
                    }
                }
            }

            return listaEmitiranja;
        }

        public void Add(IRasporedEmisija i)
        {
            i.roditelj = this;
            listaDana.Add( (DanComposite)((DanComposite)i).clone());
        }

        public void Remove(IRasporedEmisija i)
        {
            listaDana.Remove(i);
        }

        public void Display()
        {
            IAbstractIterator iterator = CreateIterator();
            Console.WriteLine("Prolazim kroz listu dana:");
            for (IRasporedEmisija item = iterator.First(); !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(((DanComposite)item).Dan.Naziv);
            }
        }

        public IRasporedEmisija roditelj { get; set; }

        public DanComposite getDan(int i)
        {
            foreach (DanComposite d in listaDana)
            {
                Dan dan = d.Dan;
                if (dan.Id == i)
                {
                    return d;
                }
            }
            return null;
        }

        public IAbstractIterator CreateIterator()
        {
            return new ConcreateIterator(listaDana);
        }

        public Prototype.Prototype clone()
        {
            TvProgrami program=new TvProgrami(this.Id, this.Naziv, this.Pocetak, this.Kraj, this.NazivDatoteke);
            foreach (DanComposite dan in this.listaDana)
            {
                program.listaDana.Add((DanComposite)dan.clone());
            }

            foreach (EmitiranjeEmisija emitiranje in this.listaEmitiranja)
            {
                program.listaEmitiranja.Add((EmitiranjeEmisija)emitiranje.clone());
            }


            return program;
        }
    }
}
