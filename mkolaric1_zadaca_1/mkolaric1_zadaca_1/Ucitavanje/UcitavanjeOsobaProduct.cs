using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Interface;

namespace mkolaric1_zadaca_1.Ucitavanje
{
    class UcitavanjeOsobaProduct:IParametri
    {
        private List<KeyValuePair<string, string>> listaParametara = new List<KeyValuePair<string, string>>();

        public IParametri IParametri
        {
            get => default;
            set
            {
            }
        }

        public void AddParameter(string key, string value)
        {
            listaParametara.Add(new KeyValuePair<string, string>(key,value));
        }

        public string GetParameter(string parameterName)
        {
            foreach (var vrijednost in listaParametara)
            {
                if (vrijednost.Key.Equals(parameterName))
                {
                    return vrijednost.Value;
                }
            }
            return "Neispravno definirat parametar";
        }

        public List<string> GetListParameters(string parametarName)
        {
            List<string> listaNaziva = new List<string>();
            foreach (var VARIABLE in listaParametara)
            {
                if (VARIABLE.Key.Equals(parametarName))
                {
                    listaNaziva.Add(VARIABLE.Value);

                }
            }
            return listaNaziva;
        }

        public List<KeyValuePair<string, string>> GetListParameters()
        {
            return listaParametara.ToList();
        }
    }
}
