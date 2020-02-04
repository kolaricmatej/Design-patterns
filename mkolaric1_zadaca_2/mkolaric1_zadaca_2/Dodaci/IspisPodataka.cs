using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using mkolaric1_zadaca_2.FactoryMethod;

namespace mkolaric1_zadaca_1.Dodaci
{
    class IspisPodataka
    {
        DataTable produces= new DataTable();


        public DataTable ispisiGresku(string greska)
        {
            produces.TableName = "POGREŠKE";
            //produces.Columns.Add("Id", typeof(int)).AllowDBNull = true;
            produces.Columns.Add("Pogreška", typeof(string));
            produces.Rows.Add( greska);
            return produces;
        }
    }
}
