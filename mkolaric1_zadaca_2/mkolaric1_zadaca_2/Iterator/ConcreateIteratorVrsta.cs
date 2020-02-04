using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_2.Entiteti;
using mkolaric1_zadaca_2.Singleton;

namespace mkolaric1_zadaca_1.Iterator
{
   public class ConcreateIteratorVrsta:IAbstractIterator
    {
        private List<IRasporedEmisija> listaVrstaEmisija=new List<IRasporedEmisija>();
        private List<Tuple<string, int>> programi = new List<Tuple<string, int>>();
        private List<Tuple<string, int>> dani = new List<Tuple<string, int>>();
        private int trenutniElement = 0;
        private int korak = 1;
        private int program = 0;
        private int dan = 0;
        private bool noviDan = true;
        private bool noviProgram = true;

        public ConcreateIteratorVrsta(List<IRasporedEmisija> lista,int vrsta)
        {
            bool dodanaEmisija = false;
            foreach (EmisijaLeaf emisija in lista)
            {
                if (vrsta == emisija.Emisija.Emisija.VrstaEmisije)
                {
                    listaVrstaEmisija.Add(emisija);
                    dodanaEmisija = true;
                }
            }
        }
        public IRasporedEmisija First()
        {
            int trenutniElement = 0;
            int program = 0;
            int dan = 0;
            bool noviDan = true;
            bool noviProgram = true;
            if (listaVrstaEmisija.Count == 0)
                return null;
            return listaVrstaEmisija[trenutniElement] as IRasporedEmisija;
        }

        public IRasporedEmisija Next()
        {
            trenutniElement += korak;
            if (!IsDone)
            {

                return listaVrstaEmisija[trenutniElement] as IRasporedEmisija;
            }
            else
                return null;
        }

        public bool IsDone
        {
            get
            {
                return trenutniElement >= listaVrstaEmisija.Count;
            }
        }
        public IRasporedEmisija CurrentItem
        {
            get
            {
                return listaVrstaEmisija[trenutniElement] as IRasporedEmisija;
            }
        }

        public bool hasNext()
        {
            return trenutniElement < listaVrstaEmisija.Count - 1;
        }


    }
}
