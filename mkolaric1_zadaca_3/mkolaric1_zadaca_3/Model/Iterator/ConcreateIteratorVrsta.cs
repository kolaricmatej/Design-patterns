using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_3.Entiteti;
using mkolaric1_zadaca_3.Singleton;

namespace mkolaric1_zadaca_1.Iterator
{
   public class ConcreateIteratorVrsta:IAbstractIterator
    {
        private List<IRasporedEmisija> listaVrstaEmisija=new List<IRasporedEmisija>();
        private int trenutniElement = 0;
        private int korak = 1;

        public ConcreateIteratorVrsta(List<IRasporedEmisija> lista)
        {
            this.listaVrstaEmisija = lista;
        }
        public IRasporedEmisija First()
        {
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
