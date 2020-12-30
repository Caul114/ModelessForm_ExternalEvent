using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ModelessForm_ExternalEvent.DataFromExcel
{
    /// <summary>
    ///   Classe che gestisce l'importazione della pagina Excel
    /// </summary>
    /// 
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

        /// <summary>
        ///   Metodo che restituisce la pagina Excel selezionata
        /// </summary>
        /// 
        public List<string> XlSheets(string xlPercorso)
        {
            if(File.Exists(xlPercorso))
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
            else
            {
                MessageBox.Show("Si è verificato un errore nel caricamento del file Excel."
                     + "\nControlla che il file Excel abbia il nome corretto o che sia posizionato nella cartella corretta.");
                return _excelSheets;
            }
        }
    }
}