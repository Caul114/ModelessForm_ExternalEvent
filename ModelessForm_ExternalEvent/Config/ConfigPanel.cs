using Autodesk.Revit.UI;
using Newtonsoft.Json;
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
    public partial class ConfigPanel : Form
    {
        #region Private data members
        // Dichiaro una instanza di DataCell
        private ModelessForm modelessForm;

        // Dichiaro una instanza di DataCellPaths
        private DataCellPaths dataCellPaths;

        // Dichiaro una instanza di ExportValueToExcel
        private ExportValueToExcel exportValueToExcel = new ExportValueToExcel();

        // Valore del Path del file Configuration
        private string _pathConfig = "";

        // Valore del path DATACELL 
        private string _pathDataCell = "";

        // Imposta i valori delle raw e delle column dell'Excel Config 
        private int _rawCommessa = 2;
        private int _colDataCell = 3;
        #endregion

        #region Class public property
        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public string PathConfig
        {
            get { return _pathConfig; }
        }

        #endregion
        public ConfigPanel()
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

        /// <summary>
        ///   Pulsante di modifica del Path di configurazione
        /// </summary>
        ///    
        private void configInitialButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Ottiene il nuovo Path del File di configurazione
                    _pathConfig = openFileDialog1.FileName;

                    if (!_pathConfig.Contains("BOLD Software\\Config\\Config.xlsx"))
                    {
                        MessageBox.Show("Non hai scelto il file corretto.\n" +
                            "Inserisci nuovamente il nome del file, ricordandoti che abbia questo percorso: \"...BOLD Software\\Config.xlsx\"");
                    }
                    else
                    {
                        // Lo scrive in un file esterno
                        //System.IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\BOLD Software\Config\ConfigPath.txt", _pathConfig);

                        // Lo scrive in un file esterno Json
                        Json fileJson = new Json();
                        string pathReplaced = _pathConfig.Replace(Environment.GetFolderPath(
                            Environment.SpecialFolder.MyDocuments), "");
                        fileJson.UpdateJson(1, 0, "ConfigPath", pathReplaced);

                        // Chiude questo pannello
                        modelessForm = App.thisApp.RetriveForm();
                        modelessForm.CloseConfigPanel();

                        // legge ilfile .json
                        string pathFileTxt = ModelessForm.thisModForm.PathFileTxt;
                        string jsonText = File.ReadAllText(pathFileTxt);
                        var traduction = JsonConvert.DeserializeObject<IList<Data>>(jsonText);

                        if (traduction.Any(x => x.Id == 2))
                        {
                            Data singleItem = traduction.FirstOrDefault(x => x.Id == 2);
                            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + singleItem.Path))
                            {
                                // Apre il pannello DataCellPaths
                                ShowDataCellPaths();
                            }
                            else
                            {
                                // Ottiene il path di DataCell                              
                                Data itemDataCell= traduction.FirstOrDefault(x => x.Id == 2);
                                _pathDataCell = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + itemDataCell.Path;

                                // Ottiene il path di AbacoCells
                                Data itemAbacoCells = traduction.FirstOrDefault(x => x.Id == 3);
                                _pathConfig = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + itemAbacoCells.Path;

                                // Ottiene i path di AbacoCells.xlsm e di Images
                                exportValueToExcel.ExportExcelAndChangeValue(_pathConfig, _pathDataCell, _rawCommessa, _colDataCell);

                                // Chiude la Form
                                this.Close();

                                // Avvisa che per far funziona reil DataCell bisogna riaccenderlo
                                MessageBox.Show("Hai concluso correttamente la Configurazione. " +
                                    "\nRientra cliccando nuovamente sul Plugin DataCell che trovi nel Pannello BOLD");

                                // Chiude il DataCell 
                                ModelessForm.thisModForm.Close();
                            }
                        }
                        else
                        {
                            // Apre il pannello DataCellPaths
                            ShowDataCellPaths();
                        }
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        /// <summary>
        ///   Metodo per attivare il ConfigPanel
        /// </summary>
        /// 
        public void ShowDataCellPaths()
        {
            // Disattiva la form DataCell
            ModelessForm.thisModForm.DozeOff();
            // Inizializza la Form della Configurazione
            dataCellPaths = new DataCellPaths();
            dataCellPaths.Show();
            dataCellPaths.TopMost = true;
        }

        /// <summary>
        ///   Forza la chiusura del ConfigPanel
        /// </summary>
        /// 
        public void CloseDataCellPaths()
        {
            if (dataCellPaths != null && dataCellPaths.Visible)
            {
                // Chiudo la form ConfigPanel
                dataCellPaths.Close();
            }
        }   
    }
}
