using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ModelessForm_ExternalEvent.FromToExcel
{
    public class ImportDataFromExcel
    {
        /// <summary>
        /// Metodo per importare un file da Excel
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="worksheetName"></param>
        /// <param name="saveAsLocation"></param>
        /// <returns></returns>
        public DataTable ReadExcelToDataTable(
            string worksheetName, string saveAsLocation, int HeaderLine, int ColumnStart)
        {
            DataTable dataTable = new DataTable();
            Excel.Application excel;
            Excel.Workbook excelworkBook;
            Excel.Worksheet excelSheet;
            Excel.Range range;
            try
            {
                // Get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Open(saveAsLocation);
                // Work sheet

                excelSheet = (Excel.Worksheet)excelworkBook.Worksheets.Item[worksheetName];
                range = excelSheet.UsedRange;
                int cl = range.Columns.Count;
                // loop through each row and add values to our sheet
                int rowcount = range.Rows.Count;
                //create the header of table
                for (int j = ColumnStart; j <= cl; j++)
                {
                    dataTable.Columns.Add(Convert.ToString
                                            (range.Cells[HeaderLine, j].Value2), typeof(string));
                }
                //filling the table from  excel file                
                for (int i = HeaderLine + 1; i <= rowcount; i++)
                {
                    DataRow dr = dataTable.NewRow();
                    for (int j = ColumnStart; j <= cl; j++)
                    {

                        dr[j - ColumnStart] = Convert.ToString(range.Cells[i, j].Value2);
                    }

                    dataTable.Rows.InsertAt(dr, dataTable.Rows.Count + 1);
                }

                //now close the workbook and make the function return the data table

                excelworkBook.Close();
                excel.Quit();
                return dataTable;
                
                
            }
            catch (Exception)
            {
                MessageBox.Show("L'elemento che hai selezionato non ha una Distinta che gli corrisponda.");
                return null;
            }
            finally
            {
                excelSheet = null;
                range = null;
                excelworkBook = null;
            }
        }
    }
}
