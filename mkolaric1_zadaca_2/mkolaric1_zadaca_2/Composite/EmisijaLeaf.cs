using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Entiteti;
using mkolaric1_zadaca_1.Iterator;
using mkolaric1_zadaca_2.Entiteti;

namespace mkolaric1_zadaca_1.Composite
{
    public class EmisijaLeaf:IRasporedEmisija
    {
        public EmitiranjeEmisija Emisija { get; set; }
        public EmisijaLeaf(EmitiranjeEmisija emisija)
        {
            this.Emisija = emisija;
        }
        public void Add(IRasporedEmisija i)
        {
            Console.WriteLine("Nije moguče dodati element jer se radi o listu");
        }

        public void Remove(IRasporedEmisija i)
        {
            Console.WriteLine("Nije moguće obrisat jer se radi o listu");
        }

        public void Display()
        {
            throw new NotImplementedException();
        }

        public IRasporedEmisija roditelj { get; set; }
    }
}
