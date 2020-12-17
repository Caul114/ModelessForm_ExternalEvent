using System;
using System.Collections.Generic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace ModelessForm_ExternalEvent.DataFromExcel
{
    public class ImportData
    {

        #region Private data members
        private List<string> _excelSheets = new List<string>();       // Proprietà privata di una lista di stringhe
        #endregion

        public Tuple<Excel.Application, Excel.Workbook> ExcelOpen(string xlPercorso)
        {
            var excelApp = new Excel.Application();
            excelApp.Visible = false;
            Excel.Workbook wb = excelApp.Workbooks.Open(xlPercorso);
            return Tuple.Create(excelApp, wb);
        }

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

        public DataTable SingleSheet(string xlPercorso, string nameSheet)
        {
            DataTable dt = null;

            try
            {
                object rowIndex = 1;
                dt = new DataTable();
                DataRow row;
                Tuple<Excel.Application, Excel.Workbook> xlDocument = ExcelOpen(xlPercorso);
                Excel.Application xlApp = xlDocument.Item1;
                Excel.Workbook xlwb = xlDocument.Item2;
                   //Excel.Workbook workBook = app.Workbooks.Open(xlPercorso, 0, true, 5, "", "", true,
                   //    Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Worksheet workSheet = (Excel.Worksheet)xlwb.ActiveSheet;

                //Excel.Worksheet singleWorkSheet = new Excel.Worksheet();
                //foreach (Excel.Worksheet sheet in xlApp.Worksheets)
                //{
                //    if(sheet.Name == nameSheet)
                //    {
                //        singleWorkSheet = sheet;
                //    }
                //}

                int temp = 1;
                while (((Excel.Range)workSheet.Cells[rowIndex, temp]).Value2 != null)
                {
                    dt.Columns.Add(Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, temp]).Value2));
                    temp++;
                }

                rowIndex = Convert.ToInt32(rowIndex) + 1;
                int columnCount = temp;
                temp = 1;
                while (((Excel.Range)workSheet.Cells[rowIndex, temp]).Value2 != null)
                {
                    row = dt.NewRow();
                    for (int i = 1; i < columnCount; i++)
                    {
                        row[i - 1] = Convert.ToString(((Excel.Range)workSheet.Cells[rowIndex, i]).Value2);
                    }
                    dt.Rows.Add(row);
                    rowIndex = Convert.ToInt32(rowIndex) + 1;
                    temp = 1;
                }
                xlApp.Workbooks.Close();
            }
            catch (Exception ex)
            {
                //lblError.Text = ex.Message;
            }
            return dt;
        }

    }
}