using Autodesk.Revit.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace ModelessForm_ExternalEvent.Config
{
    public partial class DataCellPaths : Form
    {
        #region Private data members

        // Dichiaro una instanza di ConfigPanel
        private ConfigPanel configPanel = new ConfigPanel();

        // Valore del Path del file Configuration
        private string _pathConfig = "";

        // Valore del path DATACELL sulla cartella CLOUD
        private string _pathDataCell = "";

        // Imposta i valori delle raw e delle column dell'Excel Config 
        private int _rawCommessa = 2;
        private int _colDataCell = 3;
        #endregion

        #region Class public property
        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public string DataCellPath
        {
            get { return _pathDataCell; }
        }
        #endregion

        public DataCellPaths()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Modulo gestore eventi chiuso
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Disattiva la form DataCell
            ModelessForm.thisModForm.WakeUp();
            // non dimenticare di chiamare la classe base
            base.OnFormClosed(e);
        }

        private void settingsDataCellButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Ottiene il nuovo Path del File di configurazione
                    _pathDataCell = folderBrowserDialog1.SelectedPath;

                    // Lo scrive in un file esterno Json
                    string jsonText = File.ReadAllText(ModelessForm.thisModForm.PathFileTxt);
                    var traduction = JsonConvert.DeserializeObject<IList<Data>>(jsonText);
                    dynamic jsonObj = JsonConvert.DeserializeObject(jsonText);
                    // Se l'oggetto .json esiste già...
                    if (traduction.Count == 2)
                    {
                        jsonObj[1]["Path"] = _pathDataCell;
                        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                        File.WriteAllText(ModelessForm.thisModForm.PathFileTxt, output);
                    }
                    else // ... altrimenti lo crea
                    {
                        traduction.Add(new Data { Id = 2, Name = "DataCellPath", Path = _pathDataCell });
                        jsonText = JsonConvert.SerializeObject(traduction);
                        File.WriteAllText(ModelessForm.thisModForm.PathFileTxt, jsonText);
                    }
                    
                    // Ottiene il _pathconfig
                    Data singleItem = traduction.FirstOrDefault(x => x.Id == 1);
                    _pathConfig = singleItem.Path;

                    // Ottiene i path di AbacoCells.xlsm e di Images
                    ExportExcelAndChangeValue(_pathConfig, _rawCommessa, _colDataCell);

                    // Chiude la Form
                    this.Close();

                    // Avvisa che per far funziona reil DataCell bisogna riaccenderlo
                    MessageBox.Show("Hai concluso correttamente la Configurazione. " +
                        "\nRientra cliccando nuovamente sul Plugin DataCell che trovi nel Pannello Bold.");

                    // Chiude il DataCell 
                    ModelessForm.thisModForm.Close();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        /// <summary>
        ///   Metodo che Esporta in Excel i cambiamenti effettuati in alcune sue celle
        /// </summary>
        /// 
        public void ExportExcelAndChangeValue(string pathExcel, int raw, int col)
        {

            Excel.Application excelApp = new Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("Non puoi creare un documento Excel." +
                    "\nIl tuo PC potrebbe non essere abilitato per il salvataggio di un file Excel.");
                return;
            }

            Excel.Workbooks workbooks = excelApp.Workbooks;
            Excel.Workbook workbook = workbooks.Open(
                  pathExcel,
                  Type.Missing, //updatelinks
                  false,        //readonly
                  Type.Missing, //format
                  Type.Missing, //Password
                  Type.Missing, //writeResPass
                  true,         //ignoreReadOnly
                  Type.Missing, //origin
                  Type.Missing, //delimiter
                  true,         //editable
                  Type.Missing, //Notify
                  Type.Missing, //converter
                  Type.Missing, //AddToMru
                  Type.Missing, //Local
                  Type.Missing); //corruptLoad);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Recupera l'intervallo utilizzato.
            Excel.Range used_range = worksheet.UsedRange;

            // Ottiene il numero massimo di righe e colonne.
            int max_row = used_range.Rows.Count;
            int max_col = used_range.Columns.Count;

            // Ottiene i valori del foglio.
            object[,] values = (object[,])used_range.Value2;

            // Imposta il numero della riga e della colonna che si vuole ottenere
            int rawCommessa = raw;
            int colDataCell = col;

            //used_range.Cells[rawCommessa, colDataCell] = _newPathDataCell;

            // Imposta il path della Distinta
            SetCellContent(worksheet, max_row, max_col, rawCommessa, colDataCell);

            worksheet.Columns.EntireColumn.AutoFit();

            // Crea un file Excel temporaneo e lo salva al posto di quello originale
            string tmpName = Path.GetTempFileName();
            //string tmpName = @"C:\Users\Bold\Documents\Bold Software\Config\temp.xlsx";
            File.Delete(tmpName);

            if (pathExcel != "")
            {
                try
                {
                    workbook.SaveAs(tmpName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore di esportazione!\n" + ex.Message);
                }
            }
            workbook.Close(false, Type.Missing, Type.Missing);
            excelApp.Quit();
            File.Delete(pathExcel);
            File.Move(tmpName, pathExcel);


            // Chiude tutti i processi Excel ancora attivi
            KillExcel();

            // Forza un Garbage collector immediato
            GC.Collect();
        }


        /// <summary>
        ///   Metodo che imposta il contenuto della cella specifica
        /// </summary>
        /// 
        private void SetCellContent(Excel.Worksheet worksheet, int max_row, int max_col, int recordRaw, int recordCol)
        {
            // Copia i valori nella griglia.
            for (int row = 2; row <= max_row; row++)
            {
                for (int col = 1; col <= max_col; col++)
                {
                    if (row == recordRaw && col == recordCol && recordCol == 3)
                    {
                        worksheet.Cells[row, col] = _pathDataCell;
                    }
                    else if (row == recordRaw && col == (recordCol + 1) && (recordCol + 1) == 4)
                    {
                        worksheet.Cells[row, col] = _pathDataCell + @"\AbacoCells.xlsm";
                    }
                    else if (row == recordRaw && col == (recordCol + 2) && (recordCol + 2) == 5)
                    {
                        worksheet.Cells[row, col] = _pathDataCell + @"\Images";
                    }
                }
            }
        }

        /// <summary>
        ///   Metodo che chiude tutti i processi Excel attivi
        /// </summary>
        ///        
        static void KillExcel()
        {
            Process[] AllProcesses = Process.GetProcessesByName("excel");

            // Fai un check per Killare tutti i processi Excel
            foreach (Process ExcelProcess in AllProcesses)
            {
                //if (myHashtable.ContainsKey(ExcelProcess.Id) == true)
                ExcelProcess.Kill();
            }
            AllProcesses = null;
        }
    }
}
