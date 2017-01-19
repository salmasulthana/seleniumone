using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace seleniumone
{
     
    public class ExcelCalls
    {
        public string username { get; set; }
        public string password { get; set; }

        public static IEnumerable getValues
        {
            get
            {
                ExcelLib.populate_sheet(GetProjectFolder.getpath() + "GmailLoginDDT.xlsx");
                ExcelLib.testcaseinputs();
                for (int i = 0; i < ExcelLib.totalrows; i++)
                {
                    Object[] excelrow = ExcelLib.allrows[i];
                    yield return new ExcelCalls
                    {
                        username = excelrow[0].ToString(),
                        password = excelrow[1].ToString()
                    };
                }
            }
        }
    }
}
