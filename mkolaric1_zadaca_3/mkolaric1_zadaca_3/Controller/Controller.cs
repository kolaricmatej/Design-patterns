using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_3.Memento;
using mkolaric1_zadaca_3.View;

namespace mkolaric1_zadaca_3.Controller
{
    public class Controller
    {
        private Model.Model model;
        private IView pogled;
        public Controller(Model.Model model,IView pogled)
        {
            this.model = model;
            this.pogled = pogled;
        }

        public void getProvjeraParametara(string[] args)
        {
            pogled.NeispravanUnosArgumenata(model.ispisProvjereParametara(args));
        }

        public int getProgram()
        {
            int program = int.Parse(Console.ReadLine());
            return program;

        }

        public string getOdabir()
        {
            string odabir = Console.ReadLine();
            return odabir;
        }
        public int getOdabirVrste()
        {
            int odabir = int.Parse(Console.ReadLine());
            return odabir;
        }

        public string getPassword()
        {
            string passsword = Console.ReadLine();
            return passsword;
        }
        public int getDan()
        {
            int dan = int.Parse(Console.ReadLine());
            return dan;
        }
        public bool unesiOdabirIzbornika()
        {
            pogled.prikazIzbornika();
            switch (getOdabir())
            {
                case "1":
                    IspisPrograma();
                    return true;
                case "2":
                    IspisSume();
                    return true;
                case "3":
                    pogled.IspisVrstaEmisija();
                    model.IspisPremaVrsti(getOdabirVrste());
                    return true;
                case "4":
                    return true;
                case "5":
                    pogled.ObrisiEmisijuPremaID();
                    model.ObrisiEmisiju(getOdabirVrste());
                    return true;
                case "6":
                    pogled.PrikaziPovijest();
                    model.c.ShowHistory();
                    return true;
                case "7":
                    pogled.VratiZeljeniZapis();
                    model.c.vratiZeljeniZapis(getOdabirVrste());
                    return true;
                case "8":
                    provjeraPassworda();
                    return true;
                case "9":
                    OdaberiPogled();
                    return true;
                case "10":
                    return false;
                default:
                    return true;
            }
        }

        private void OdaberiPogled()
        {
            if (this.pogled.GetType() == typeof(Pogled))
            {
                this.pogled=new Pogled2();
            }
            else
            {
                this.pogled=new Pogled();
            }

        }
        private void provjeraPassworda()
        {
            pogled.UnosPassworda();
            string lozinka = model.sakrijLozinku();
            if (model.unosLozinke(lozinka))
            {
                IspisPrograma();
            }
            else
            {
                pogled.Netocnalozinka();
            }
        }

        private void IspisSume()
        {
            pogled.ispisPorgramaEmisije(model.ispisPrograma());
            int program = getProgram();
            pogled.UnosPrograma(model.program, program);
            pogled.UnosDana();
            int dan = getDan();
            pogled.provjeraDana(dan);
            model.IspisSume(program, dan);
        }

        private void IspisPrograma()
        {
            pogled.ispisPorgramaEmisije(model.ispisPrograma());
            int program = getProgram();
            pogled.UnosPrograma(model.program, program);
            pogled.UnosDana();
            int dan = getDan();
            pogled.provjeraDana(dan);
            model.IspisTablice(program, dan);
        }
    }
}
