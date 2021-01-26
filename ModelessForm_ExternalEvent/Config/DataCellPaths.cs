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



namespace ModelessForm_ExternalEvent.Config
{
    public partial class DataCellPaths : Form
    {
        #region Private data members

        // Instanza della classe 
        internal static DataCellPaths thisDataCell = null;

        // Dichiaro una instanza di ConfigPanel
        private ConfigPanel configPanel = new ConfigPanel();

        // Dichiaro una instanza di ExportValueToExcel
        private ExportValueToExcel exportValueToExcel = new ExportValueToExcel();

        // Valore del Path del file Configuration
        private string _pathConfig = "";

        // Valore del path DATACELL 
        private string _pathDataCell = "";

        // Valore del path BOLD_Distinta 
        private string _pathBOLD_Distinta = "";

        // Valore del path IMAGES 
        private string _pathImages = "";

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
            thisDataCell = this;
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
                    if (_pathDataCell.Contains("\\DataCell") && !_pathDataCell.Contains("\\Images"))
                    {
                        string pathReplaced = _pathDataCell.Replace(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "");

                        // Imposta i Path degli altri due valori 
                        _pathBOLD_Distinta = pathReplaced + @"\AbacoCells.xlsm";
                        _pathImages = pathReplaced + @"\Images";

                        // Lo scrive in un file esterno Json
                        Json fileJson = new Json();
                        fileJson.UpdateJson(2, 1, "DataCellPath", pathReplaced);
                        fileJson.UpdateJson(3, 2, "AbacoCellPath", _pathBOLD_Distinta);
                        fileJson.UpdateJson(4, 3, "ImagesPath", _pathImages);

                        // Ottiene il _pathconfig
                        string jsonText = File.ReadAllText(ModelessForm.thisModForm.PathFileTxt);
                        IList<Data> traduction = JsonConvert.DeserializeObject<IList<Data>>(jsonText);
                        Data singleItem = traduction.FirstOrDefault(x => x.Id == 3);
                        _pathConfig = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + singleItem.Path;

                        // Esporta le modifiche su folgio Excel, del pathDataCell, di AbacoCells.xlsm e di Images
                        exportValueToExcel.ExportExcelAndChangeValue(_pathConfig, _pathDataCell, _rawCommessa, _colDataCell);

                        // Chiude la Form
                        this.Close();

                        // Avvisa che per far funziona reil DataCell bisogna riaccenderlo
                        MessageBox.Show("Hai concluso correttamente la Configurazione. " +
                            "\nRientra cliccando nuovamente sul Plugin DataCell che trovi nel Pannello BOLD");

                        // Chiude il DataCell 
                        ModelessForm.thisModForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Non hai inserito un percorso corretto." +
                            "\nClicca nuovamente il pulsante Inserisci e cerca il percorso corretto della cartella DataCell.");
                    }                    
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }       
    }
}
