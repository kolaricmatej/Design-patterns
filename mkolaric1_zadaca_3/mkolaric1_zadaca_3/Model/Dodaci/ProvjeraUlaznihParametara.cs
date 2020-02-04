using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mkolaric1_zadaca_3.Dodaci
{
    public class ProvjeraUlaznihParametara
    {

        public static bool ProvjeraParametara(string[] ulazniParametri)
        {
            string[] parametri = {"-t","-e","-v", "-o", "-u"};
            foreach (var param in parametri)
            {
                if (!ulazniParametri.Contains(param))
                {
                    return false;
                }
            }
            return true;
        }


        public static Dictionary<string, string> VratiKljucVrijednost(string[] ulazniParametri)
        {
            Dictionary<string, string> parametri = new Dictionary<string, string>();
            for (int i = 0; i < ulazniParametri.Length; i+=2)
            {
                parametri.Add(ulazniParametri[i], ulazniParametri[i+1]);
            }

            return parametri;

        }

        




    }
}
