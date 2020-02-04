using mkolaric1_zadaca_3.Entiteti;
using mkolaric1_zadaca_3.Memento;
using mkolaric1_zadaca_3.Singleton;

namespace mkolaric1_zadaca_3.View
{
    public interface IView
    {
        void NeispravanUnosArgumenata(bool ispravno);
        void prikazIzbornika();
        void ispisPorgramaEmisije(string programi);
        void UnosPrograma(TvKucaSingleton program, int broj);
        void UnosDana();
        void provjeraDana(int dan);
        void IspisVrstaEmisija();
        void ObrisiEmisijuPremaID();
        void PrikaziPovijest();
        void VratiZeljeniZapis();
        void UnosPassworda();
        void Netocnalozinka();
         void PrikazPogleda();
         void NeispravanPogled();
    }
}