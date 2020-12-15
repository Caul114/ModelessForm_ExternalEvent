using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ModelessForm_ExternalEvent.ToExcel
{
    public class ImportDataFromExcel
    {
        // Instanza della classe 
        internal static ImportDataFromExcel thisImport = null;

        public Tuple<Excel.Application, Excel.Workbook> ExcelOpen(string xlPercorso)
        {
            var excelApp = new Excel.Application();
            excelApp.Visible = false;
            Excel.Workbook wb = excelApp.Workbooks.Open(xlPercorso);
            return Tuple.Create(excelApp, wb);
        }

        public List<String> XlSheets(string xlPercorso)
        {
            Excel.Application xlApp = ExcelOpen(xlPercorso).Item1;
            Excel.Workbook xlwb = ExcelOpen(xlPercorso).Item2;
            List<String> listSh = new List<string>();
            foreach (Excel.Worksheet xlws in xlApp.Worksheets)
            {
                listSh.Add(xlws.Name);
            }
            return listSh;
        }
    }
}
