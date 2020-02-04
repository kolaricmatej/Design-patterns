using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_1.Interface;
using mkolaric1_zadaca_1.Osnovno;

namespace mkolaric1_zadaca_1.Ucitavanje
{
    class ProgramiFactory:Ucitavanje
    {
        
        List<Program> listaProgram1Param = new List<Program>();
        List<Program> listaProgram2Param = new List<Program>();
        private Program p;
        private int id;
        private string dani;
        private TimeSpan pocetak;
        private string osoba1="";
        private string osoba2="";
        public override void UcitajZapise(string filePath)
        {
            String red;
            Boolean error = false;
            string message = "";
            StreamReader file = new StreamReader(filePath);
            file.ReadLine();
            switch (filePath)
            {
                case "DZ_1_program_1.txt":
                    while ((red = file.ReadLine()) != null)
                    {
                        String[] splitLine = red.Split(';');
                        if (splitLine.Count() > 1 || splitLine.Count() <= 4)
                        {
                            id = int.Parse(splitLine[0]);
                            dani = splitLine[1];

                            if (splitLine.Length > 2&&!splitLine[2].Equals(""))
                            {
                                pocetak= TimeSpan.Parse(splitLine[2]);
                                if (splitLine.Length > 3 && !splitLine[3].Equals(""))
                                {
                                    osoba1 = splitLine[3];
                                    if (splitLine.Length > 4 && !splitLine[4].Equals(""))
                                    {
                                        osoba2 = splitLine[4];
                                        
                                    }
                                }
                            }
                            p=new Program(id,dani,pocetak,osoba1,osoba2);
                            listaProgram1Param.Add(p);
                        }
                        else
                        {
                            message = "Svojstvo je preskočeno - " + red + "zbog prevelikog broja argumenata";
                        }
                    }
                    break;
                case "DZ_1_program_2.txt":
                    while ((red = file.ReadLine()) != null)
                    {
                        String[] splitLine = red.Split(';');
                        if (splitLine.Count() > 1 || splitLine.Count() <= 4)
                        {
                            id = int.Parse(splitLine[0]);
                            dani = splitLine[1];
                            if (splitLine.Length > 2&&!splitLine[2].Equals(""))
                            {
                                pocetak= TimeSpan.Parse(splitLine[2]);
                                if (splitLine.Length > 3 && !splitLine[3].Equals(""))
                                {
                                   osoba1 = splitLine[3];
                                    if (splitLine.Length > 4 && !splitLine[4].Equals(""))
                                    {
                                       osoba2 = splitLine[4];
                                    }
                                }
                            }
                            p=new Program(id,dani,pocetak,osoba1,osoba2);
                            listaProgram2Param.Add(p);
                        }
                        else
                        {
                            message = "Svojstvo je preskočeno - " + red + "zbog prevelikog broja argumenata";
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        public  List<Program> GetList(string filePath)
        {
            if (filePath.Contains("DZ_1_program_1"))
            {
               return listaProgram1Param;
            }
            else
            {
                return listaProgram2Param;
            }
        }

    }

}
