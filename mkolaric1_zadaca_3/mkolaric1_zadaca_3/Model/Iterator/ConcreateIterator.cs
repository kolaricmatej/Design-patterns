using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Composite;

namespace mkolaric1_zadaca_1.Iterator
{
    public class ConcreateIterator : IAbstractIterator
    {
        private List<IRasporedEmisija> Lista;
        private int trenutniElement = 0;
        private int korak = 1;

        public ConcreateIterator(List<IRasporedEmisija> lista)
        {
            Lista = lista;
        }

        public IRasporedEmisija First()
        {
            trenutniElement = 0;
            if (Lista.Count != 0)
            {
                return Lista[trenutniElement] as IRasporedEmisija;
            }

            return null;

        }

        public IRasporedEmisija Next()
        {
            trenutniElement += korak;
            if (!IsDone)
            {
                return Lista[trenutniElement] as IRasporedEmisija;
            }
            return null;
        }

        public bool IsDone
        {
            get { return trenutniElement >= Lista.Count; }
        }

        public IRasporedEmisija CurrentItem
        {
            get { return Lista[trenutniElement] as IRasporedEmisija; }
        }

        public bool hasNext()
        {
            return trenutniElement < Lista.Count - 1;
        }

    }

}
