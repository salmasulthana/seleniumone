
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using Excel;
using System.Collections;

namespace seleniumone

{
    public class ExcelLib
    {
        public string username;
        public string password;
        public static string projectpath = GetProjectFolder.getpath();
        public static List<ExcelDataEntry> excelsheet = new List<ExcelDataEntry>();

        public static int totalrows;
        public static int totalcolumns;

        public static Object[][] allrows;

        public static void printobjectarray()
        {
            for (int i = 0; i < totalrows; i++)
            {
                Object[] excelrow = allrows[i];
                for (int j = 0; j < excelrow.Length; j++)
                {
                    Console.Write("{0} ", excelrow[j]);
                }
                Console.Write("\n"); 
            }
        }

        /*
        public void testcaseinputs()
        {
            allrows = new Object[totalrows];
            int rownumber = 1;
            int iterator = 0;
            foreach (ExcelDataEntry cell in excelsheet)
            {
                Console.WriteLine(cell.colValue);
                if (rownumber > totalrows)
                {
                    break;
                }
            }
        }
         * */

        public static void testcaseinputs()
        {
            Console.WriteLine(excelsheet.Count);
            allrows = new Object[totalrows][];
            int rownumber = 1;
            int iterator = 0;
            Object[] objectarr = new Object[totalcolumns];
            foreach (ExcelDataEntry cell in excelsheet)
            {
                if (rownumber > totalrows) 
                {
                    break;
                }
                if (cell.row == rownumber)
                {
                    objectarr[iterator] = cell.colValue;
                    if (iterator == 1)
                    {
                        allrows[rownumber - 1] = objectarr;
                        Console.WriteLine("Username = {0} and Password = {1}", objectarr[0], objectarr[1]);
                        rownumber++;
                        iterator = 0;
                        /*yield return new ExcelLib
                        {
                            username = objectarr[0].ToString(),
                            password = objectarr[1].ToString()
                        };*/
                        objectarr = new Object[totalcolumns];
                    }
                    else
                    {
                        iterator++;
                    }
                }

            }
        }

        public static DataTable OpenExcel(string filePath){
            FileStream stream = File.Open(filePath,FileMode.Open ,FileAccess.ReadWrite);

            IExcelDataReader XLReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            XLReader.IsFirstRowAsColumnNames = true;

            DataSet result = XLReader.AsDataSet();

            DataTableCollection table = result.Tables;

            DataTable resultTable = table["Sheet1"];

            return resultTable;
        
        }

        public static void populate_sheet(string filePath)
        {
            DataTable table = OpenExcel(filePath);
            totalrows = table.Rows.Count;
            totalcolumns = table.Columns.Count;
            Console.WriteLine("Rows = {0} columns = {1}",totalrows,totalcolumns);
            for (int row = 1; row <= totalrows; row++)
            {

                for(int col=0;col<totalcolumns;col++){
                    ExcelDataEntry dtEntry = new ExcelDataEntry();
                    dtEntry.row = row;
                    dtEntry.colName = table.Columns[col].ColumnName;
                    dtEntry.colValue = table.Rows[row-1][col].ToString();
                    excelsheet.Add(dtEntry);
                    Console.WriteLine(dtEntry.row + " " + dtEntry.colName + " " + dtEntry.colValue);
                }
            }
        }

        public static string read_entry(int row, string columnName)
        {

            try
            {
                string data = (from colData in excelsheet
                               where colData.colName == columnName && colData.row == row
                               select colData.colValue).SingleOrDefault();

                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

    public class ExcelDataEntry
    {
        public int row;
        public string colName;
        public string colValue;
    }
}
