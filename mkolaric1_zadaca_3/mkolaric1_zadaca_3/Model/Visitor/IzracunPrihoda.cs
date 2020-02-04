using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Entiteti;

namespace mkolaric1_zadaca_3.Visitor
{
    public class IzracunPrihoda: Visitor
    {
    private int ukupanPrihod;

    public int getUkupanPrihod()
    {
        return ukupanPrihod;
    }

    public void posjeti(VrstaEmisije vrstaEmisije)
    {
        if (vrstaEmisije.Reklama != 0)
        {
            ukupanPrihod += vrstaEmisije.Trajanje;
        }
    }
    }
}
