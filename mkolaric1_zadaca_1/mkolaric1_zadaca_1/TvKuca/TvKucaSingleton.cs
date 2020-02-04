using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Interface;

namespace mkolaric1_zadaca_1.TvKuca
{
    class TvKucaSingleton
    {
        private static TvKucaSingleton instance;
        private static object syncLock = new object();
        public List<TvKuca> ListaTvKuca;

        TvKuca tv = new TvKuca();
        private string putanjaTvKuca;

        public string PutanjaTvKuca
        {
            get => putanjaTvKuca; set => putanjaTvKuca=value;
        }

        protected TvKucaSingleton()
        {
            ListaTvKuca=new List<TvKuca>();
        }

        public static TvKucaSingleton Instace()
        {
            if (instance == null)
            {
                instance=new TvKucaSingleton();
            }
            return instance;
        }

        public void UcitajParametre(string naziv)
        {
            String red;
            Boolean error = false;
            string message = "";
            StreamReader file=new StreamReader(naziv);
            file.ReadLine();
           
            while ((red = file.ReadLine()) != null)
            {
                String[] splitLine = red.Split(';');
                String key;
                String value;
                if (splitLine.Count() == 5)
                {
                    key = "id";
                    value = splitLine[0];
                    tv.AddParameter(key, value);

                    key = "naziv";
                    value = splitLine[1];
                    tv.AddParameter(key, value);

                    key = "pocetak";
                    value = splitLine[2];
                    //error = NotParsableTime(error, value);
                    tv.AddParameter(key, value);

                    key = "kraj";
                    value = splitLine[3];
                    if (value == "")
                    {
                        value = "23:59";
                    }
                    // error = NotParsableTime(error, value);
                    tv.AddParameter(key, value);

                    key = "naziv datoteke";
                    value = splitLine[4];
                    // error = NotParsableName(error, value);
                    tv.AddParameter(key, value);

                    if (!error)
                    {
                        
                        ListaTvKuca.Add(tv);
                    }
                    else
                    {
                        message = "Svojstvo je preskočeno - " + red + "zbog nemogučnosti parsiranja";
                    }

                }
                else
                {
                    message = "Svojstvo je preskočeno - " + red + "zbog prevelikog broja argumenata";
                }
            }
        }

        public IParametri GetParametersLoader(string filePath)
        {
            return tv;
        }
    }
}
