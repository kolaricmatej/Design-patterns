using System;
using System.Collections.Generic;
using mkolaric1_zadaca_1.Composite;
using mkolaric1_zadaca_1.Entiteti;

namespace mkolaric1_zadaca_3.Memento
{
    public interface Memento
    {
        string GetName();
        List<IRasporedEmisija> GetState();
        DateTime GetDate();
        int GetRedniBroj();
        void IspisiRaspored();

    }
}