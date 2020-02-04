using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Interface;

namespace mkolaric1_zadaca_1.TvKuca
{


    class TvKuca : IParametri
    {
        List<KeyValuePair<string, string>> listaTvKuca = new List<KeyValuePair<string, string>>();
        public void AddParameter(String key, string value)
        {
            listaTvKuca.Add(new KeyValuePair<string, string>(key, value));
        }

        public String GetParameter(String parameterName)
        {
            foreach (var vrijednost in listaTvKuca)
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
            List<string> tvprogrami = new List<string>();
            foreach (var VARIABLE in listaTvKuca)
            {
                if (VARIABLE.Key.Equals(parametarName))
                {
                    tvprogrami.Add(VARIABLE.Value);

                }
            }
            return tvprogrami;
        }

        public List<KeyValuePair<string, string>> GetListParameters()
        {
            throw new NotImplementedException();
        }
    }
}
