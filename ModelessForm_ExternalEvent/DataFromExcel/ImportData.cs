using System;
using System.Collections.Generic;

using Excel = Microsoft.Office.Interop.Excel;

namespace ModelessForm_ExternalEvent.DataFromExcel
{
    public class ImportData
    {

        #region Private data members
        private List<string> _excelSheets = new List<string>();       // Proprietà privata di una lista di stringhe
        #endregion

        public List<string> XlSheets(string xlPercorso)
        {
            Tuple<Excel.Application, Excel.Workbook> xlDocument = ExcelOpen(xlPercorso);
            Excel.Application xlApp = xlDocument.Item1;
            Excel.Workbook xlwb = xlDocument.Item2;
            List<string> nameSchedule = new List<string>();
            foreach (Excel.Worksheet xlws in xlApp.Worksheets)
            {
                _excelSheets.Add(xlws.Name);
            }
            return _excelSheets;
        }

        public Tuple<Excel.Application, Excel.Workbook> ExcelOpen(string xlPercorso)
        {
            var excelApp = new Excel.Application();
            excelApp.Visible = false;
            Excel.Workbook wb = excelApp.Workbooks.Open(xlPercorso);
            return Tuple.Create(excelApp, wb);
        }
    }
}