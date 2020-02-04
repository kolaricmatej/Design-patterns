using System;
using mkolaric1_zadaca_1.Interface;
using System.Collections.Generic;
using System.Linq;

namespace mkolaric1_zadaca_1.Ucitavanje
{
    public class UcitavanjeProgramaProduct : IParametri
    {
        
       private List<KeyValuePair<string, string>> listaParametara=new List<KeyValuePair<string, string>>();

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

        public List<string> GetListParameters(string parametarName)
        {
            List<string> tvprogrami = new List<string>();
            foreach (var VARIABLE in listaParametara)
            {
                if (VARIABLE.Key.Equals(parametarName))
                {
                    tvprogrami.Add(VARIABLE.Value);

                }
            }
            return tvprogrami;
        }

        public List<KeyValuePair<string,string>> GetListParameters()
        {
            
            return listaParametara.ToList();
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
    }
}
