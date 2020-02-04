using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkolaric1_zadaca_1.Interface
{
    public interface IParametri
    {
        void AddParameter(String key, String value);

        String GetParameter(String parameterName);


        List<String> GetListParameters(string parametarName);
        List<KeyValuePair<string,string>> GetListParameters();
    }

}
