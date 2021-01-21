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

        // Valore del Path del file Configuration
        private string _pathConfig = "";
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

                    // Lo scrive in un file esterno
                    //System.IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Bold Software\Config\ConfigPath.txt", _pathConfig);
                    
                    // Lo scrive in un file esterno Json
                    Json fileJson = new Json();
                    List<Data> data = fileJson.WriteJson(1, "ConfigPath", _pathConfig);

                    if (_pathConfig.Contains("Config.xlsx"))
                    {
                        // Chiude questo pannello
                        modelessForm = App.thisApp.RetriveForm();
                        modelessForm.CloseConfigPanel();

                        // Apre il pannello DataCellPaths
                        ShowDataCellPaths();
                    }
                    else
                    {
                        MessageBox.Show("Non hai scelto il file corretto.\n" +
                            "Inserisci nuovamente il nome del file, ricordandoti che abbia questa estensione: \"...\\Config.xlsx\"");
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
