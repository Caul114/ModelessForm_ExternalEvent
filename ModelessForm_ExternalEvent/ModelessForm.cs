using Autodesk.Revit.UI;
using ModelessForm_ExternalEvent.Config;
using ModelessForm_ExternalEvent.DataFromExcel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace ModelessForm_ExternalEvent
{
    /// <summary>
    /// La classe della nostra finestra di dialogo non modale.
    /// </summary>
    /// <remarks>
    /// Oltre ad altri metodi, ha un metodo per ogni pulsante di comando. 
    /// In ognuno di questi metodi non viene fatto nient'altro che il sollevamento
    /// di un evento esterno con una richiesta specifica impostata nel gestore delle richieste.
    /// </remarks>
    /// 
    public partial class ModelessForm : Form
    {
        // In questo esempio, la finestra di dialogo possiede il gestore e gli oggetti evento, 
        // ma non è un requisito. Potrebbero anche essere proprietà statiche dell'applicazione.

        #region Private data members

        private RequestHandler m_Handler;
        private ExternalEvent m_ExEvent;

        // Instanza della classe 
        internal static ModelessForm thisModForm = null;

        // Dichiara la Form per il file di Configurazione
        private ConfigPanel configPanel = new ConfigPanel();

        // Dichiara la Form per l'assegnazione del Nome del Progetto
        private SetProjectName setProjectName;

        // Dichiara la Form della lente d'ingrandimento
        private MagnifyingGlass magnifyingGlass;

        // Dichiara la Form del cambio codici
        private CodeDefinition _codeDefinition;

        // Percorso del singolo file .json da importare di default
        private string _pathFileConfig = @"\BOLD Software\DataQuery\ConfigPath.json";
        private string _pathFileTxt = string.Empty;
        private string _pathConfig = string.Empty;

        private string _pathExcel = string.Empty;
        ImportData importData = new ImportData();

        // Percorso del file Excel utile per la Configurazione
        private string _pathDataCell = string.Empty;

        // Nome della variabile che contiene il Codice Tipologia
        private string _typologieCode = string.Empty;
        //private string _typologieCode = "BOLDDistinta";

        // Nome della variabile che contiene il Codice Cellula
        private string _cellCode = string.Empty;

        // Nome della variabile che contiene il Codice Posizionale
        private string _positionalCode = string.Empty;

        // Inizializza la Classe ExportValueToExcel
        ExportValueToExcel exportValueToExcel = new ExportValueToExcel();

        // Dati del foglio Excel utili per determinare la cella da prendere
        private int _rawCommessa = 2;
        private int _colDataCell = 3;

        // Percorso della cartella Immagini di default
        private string _folderImageSkeleton = string.Empty;
        private string _folderImageDefault = string.Empty;
        private string _folderImageActual = string.Empty;
        private string _folderName = string.Empty;

        // Percorso della cartella family delle immagini
        private string _familyType = string.Empty;

        // Valore attivo nella ComboBox
        private string valueActive;

        // Valore della Distinta presente nella DataGridView
        private string valueDistintaActive;

        // Valore di default della ComboBox Distinta
        private string _defaultTextComboBox = "<- Scegli una pagina del documento Excel ->";

        // Valore booleano di errore
        bool error = false;

        // Valore booleano per impostare le nuove immagini
        bool newImages = false;

        // Valore booleano per usare o meno la Lente d'ingrandimento
        private bool _activeMagnifyngGlass = false;

        // Variabile in cui viene salvato il dataGridView attualmente visualizzato
        private DataGridView _dataGridViewOriginal;

        // Variabile in cui viene salvato il dataGridView che verrà visualizzato dopo le modifiche
        private DataGridView _dataGridViewToNumbers;

        // Valore booleano che ice se c'è stato un cambiamento nel fogli Excel
        private bool _excelChanged = false;
        #endregion

        #region Class public property
        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public RequestHandler GetHandler
        {
            get { return m_Handler; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public ExternalEvent GetEvent
        {
            get { return m_ExEvent; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public string PathFileConfig
        {
            get { return _pathFileConfig; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public string PathFileTxt
        {
            get { return _pathFileTxt; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public string PathTypologieCode
        {
            get { return _pathExcel; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public string PathImages
        {
            get { return _folderImageDefault; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public string TypologieCode
        {
            get { return _typologieCode; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public string CellCode
        {
            get { return _cellCode; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public string PositionalCode
        {
            get { return _positionalCode; }
        }
        #endregion

        /// <summary>
        ///   Costruttore della finestra di dialogo
        /// </summary>
        /// 
        public ModelessForm(ExternalEvent exEvent, RequestHandler handler)
        {
            InitializeComponent();
            m_Handler = handler;
            m_ExEvent = exEvent;

            // Riempie l'istanza di questa classe con la Form
            thisModForm = this;

            // Inizializza i DataGridView di visualizzazione
            _dataGridViewOriginal = new DataGridView();
            _dataGridViewToNumbers = new DataGridView();

            double FeetToInc = Constant.FeetToInc(21, 9);
            double feetToMm = Constant.FeetToMm(FeetToInc);
            double mmToFeet = Constant.MmToFeet(feetToMm);
            int[] intToFeet = Constant.IncToFeet(mmToFeet);

            // Metodo che cattura il nome del progetto e lo visualizza nel suo TextBox
            GetNameProjectButton();

            // Verifica se il _pathConfig ed il _pathDataCell esistano o meno
            GetFileTxt();
            if(_pathConfig.Length > 1)
            {
                GetDataCellPath();
            }

            // Inizializza i codici nel caso in cui siano già memorizzati
            GetCodes();

            // Prende il percorso dei file dal file .json di Configurazione 
            if (_pathConfig == string.Empty)
            {
                MessageBox.Show("Il file Excel di Configurazione non è stato caricato."
                     + "\nSegui questa procedura per caricare il file di configurazione corretto.");
                ShowConfigPanel();
            } 
            else if (_pathDataCell == string.Empty)
            {
                configPanel.ShowDataCellPaths();
            }
            else if(_typologieCode == string.Empty || _cellCode == string.Empty || _positionalCode == string.Empty)
            {
                ConfigureTheCodes();
            }
            else
            {
                // Esporta le modifiche su foglio Excel, del pathDataCell, di DataSheets.xlsm e di Images
                exportValueToExcel.ExportExcelAndChangeValue(_pathConfig, _pathDataCell, "", "", _rawCommessa, _colDataCell);

                _pathExcel = _pathDataCell + @"\DataSheets.xlsm";
                _folderImageSkeleton = _pathDataCell + @"\Images_Skeleton";
                _folderImageDefault = _pathDataCell + @"\Images";

                // Definisce i colori di alcune forme
                captureButton.BackColor = Color.DodgerBlue;

                // Inserisce le immagini selezionate
                _folderImageActual = _folderImageDefault;
                SetModifyPicture();

                // Imposta l'origine dati della Combobox e la riempie
                List<string> dataBuffer = importData.XlSheets(_pathExcel);
                // Chiude tutti i processi Excel ancora attivi
                KillExcel();
                if (dataBuffer != null)
                {
                    foreach (var sheet in dataBuffer)
                    {
                        comboBox1.Items.Add(sheet);
                    }
                }
            }
        }

        /// <summary>
        /// Modulo gestore eventi chiuso
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // possediamo sia l'evento che il gestore
            // dovremmo eliminarlo prima di chiudere la finestra

            m_ExEvent.Dispose();
            m_ExEvent = null;
            m_Handler = null;

            // non dimenticare di chiamare la classe base
            base.OnFormClosed(e);
        }

        /// <summary>
        ///   Attivatore / disattivatore del controllo
        /// </summary>
        ///
        private void EnableCommands(bool status)
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Enabled = status;
            }
            if (!status)
            {
                this.exitButton.Enabled = true;
            }
        }


        /// <summary>
        ///   Un metodo di supporto privato per effettuare una richiesta 
        ///   e allo stesso tempo mettere la finestra di dialogo in sospensione.
        /// </summary>
        /// <remarks>
        ///   Ci si aspetta che il processo che esegue la richiesta 
        ///   (l'helper Idling in questo caso particolare) 
        ///   riattivi anche la finestra di dialogo dopo aver terminato l'esecuzione.
        /// </remarks>
        ///
        public void MakeRequest(RequestId request)
        {
            ModelessForm_ExternalEvent.App.thisApp.DontShowFormTop();
            m_Handler.Request.Make(request);
            m_ExEvent.Raise();
            DozeOff();            
        }


        /// <summary>
        ///   DozeOff -> disabilita tutti i controlli (tranne il pulsante Esci)
        /// </summary>
        /// 
        public void DozeOff()
        {
            EnableCommands(false);
        }

        /// <summary>
        ///   WakeUp -> abilita tutti i controlli
        /// </summary>
        /// 
        public void WakeUp()
        {
            EnableCommands(true);
        }

        /// <summary>
        ///   Metodo di interazione con la finestra di dialogo
        /// </summary>
        /// 
        private void ModelessForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///   Metodo che restituisce il Directory Path dei file Excel
        /// </summary>
        /// 
        public string GetExcelDirectoryPath()
        {
            string directoryName = Path.GetDirectoryName(_pathExcel);
            return directoryName;
        }

        /// <summary>
        ///   Verifica se il file .json di configurazione esista o meno
        /// </summary>
        /// 
        public void GetFileTxt()
        {
            _pathFileTxt = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + _pathFileConfig;

            if (File.Exists(_pathFileTxt))
            {
                // Salva il percorso in un file .txt
                //_pathConfig = File.ReadAllText(_pathFileTxt);

                // Legge il .json dal file
                string jsonText = File.ReadAllText(_pathFileTxt);
                if(jsonText != "")
                {
                    var traduction = JsonConvert.DeserializeObject<IList<Data>>(jsonText);
                    Data singleItem = traduction.FirstOrDefault(x => x.Id == 1);
                    if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + singleItem.Value))
                    {
                        _pathConfig = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + singleItem.Value;
                    }                    
                }
            }
            else
            {
                _pathConfig = "";
            }
        }

        /// <summary>
        ///   Verifica se il percorso DataCell esiste o meno
        /// </summary>
        /// 
        public void GetDataCellPath()
        {
            // legge ilfile .json
            string jsonText = File.ReadAllText(_pathFileTxt);
            var traduction = JsonConvert.DeserializeObject<IList<Data>>(jsonText);

            if (traduction.Any(x => x.Id == 2))
            {
                Data singleItem = traduction.FirstOrDefault(x => x.Id == 2);
                if(Directory.Exists(singleItem.Value))
                {
                    _pathDataCell = singleItem.Value;
                }
            }
            else
            {
                _pathDataCell = "";
            }
        }

        /// <summary>
        ///   Metodo per attivare il ConfigPanel
        /// </summary>
        /// 
        private void ShowConfigPanel()
        {
            // Inizializzo la Form della Configurazione
            configPanel = new ConfigPanel();
            configPanel.Show();
            this.DozeOff();
            this.SendToBack();
            configPanel.TopMost = true;
        }

        /// <summary>
        ///   Forza la chiusura del ConfigPanel
        /// </summary>
        /// 
        public void CloseConfigPanel()
        {
            if (configPanel != null && configPanel.Visible)
            {
                // Chiudo la form ConfigPanel
                this.BringToFront();
                configPanel.Close();
            }
        }

        /// <summary>
        ///   Attiva la Form della modifica del Path di Configurazione
        /// </summary>
        /// 
        private void settingsButton_Click(object sender, EventArgs e)
        {
            if(!File.Exists(_pathFileTxt))
            {
                ShowConfigPanel();
            } 
            else if (File.ReadAllText(_pathFileTxt) == "")
            {
                ShowConfigPanel();
            }
            else
            {
                configPanel.ShowDataCellPaths();
            }
        }

        #region Configure CodeDefinition
        /// <summary>
        ///   Chiama il pannello che inizializza i Codici di Tipologia, Cellula e Posizionale, se presenti
        /// </summary>
        /// 
        public void GetCodes()
        {
            _pathFileTxt = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + _pathFileConfig;

            if (File.Exists(_pathFileTxt))
            {
                // Legge il .json dal file
                string jsonText = File.ReadAllText(_pathFileTxt);
                if (jsonText != string.Empty)
                {
                    var traduction = JsonConvert.DeserializeObject<IList<Data>>(jsonText);
                    Data singleItem1 = traduction.FirstOrDefault(x => x.Id == 5);
                    if (singleItem1 != null && singleItem1.Value != string.Empty)
                    {
                        _typologieCode = singleItem1.Value;
                    }
                    Data singleItem2 = traduction.FirstOrDefault(x => x.Id == 6);
                    if (singleItem2 != null && singleItem2.Value != string.Empty)
                    {
                        _cellCode = singleItem2.Value;
                    }
                    Data singleItem3 = traduction.FirstOrDefault(x => x.Id == 7);
                    if (singleItem3 != null && singleItem3.Value != string.Empty)
                    {
                        _positionalCode = singleItem3.Value;
                    }
                }
            }
        }

        /// <summary>
        ///   Chiama il pannello che permette la Configurazione dei Codici di Tipologia, Cellula e Posizionale
        /// </summary>
        /// 
        public void ConfigureTheCodes()
        {
            CodeDefinition codForm = new CodeDefinition();
            codForm.Show();
            this.DozeOff();
            this.SendToBack();
            codForm.TopMost = true;
            MakeRequest(RequestId.Code);
        }

        /// <summary>
        ///   Metodo che imposta i nuovi codici
        /// </summary>
        /// 
        public void GoToChanges()
        {
            MakeRequest(RequestId.ChangeCode);
        }

        /// <summary>
        ///   Metodo che imposta i nuovi codici
        /// </summary>
        /// 
        public void CodesChanges()
        {
            // Implementa un'istanza di CodeDefinition
            _codeDefinition = CodeDefinition.thisCodeDef;
            _typologieCode = _codeDefinition.TypologieCode;
            _cellCode = _codeDefinition.CellCode;
            _positionalCode = _codeDefinition.PositionalCode;
        }

        /// <summary>
        ///   Forza la chiusura del Form CodeDefinition
        /// </summary>
        /// 
        public void CloseCodeDefinition()
        {
            if (_codeDefinition != null && _codeDefinition.Visible)
            {
                // Chiudo la Form CodeDefinition
                this.BringToFront();
                _codeDefinition.Close();
            }
        }
        #endregion

        #region Name Project
        /// <summary>
        ///   Metodo che cattura il nome del progetto memorizzato nel foglio Excel
        /// </summary>
        /// 
        private void GetNameProjectButton()
        {
            MakeRequest(RequestId.ProjectName);
        }

        /// <summary>
        ///   Metodo che imposta il nome del Progetto nel TextBox
        /// </summary>
        /// 
        public void SetNameProject()
        {
            nameProjectTextBox.Text = m_Handler.ProjectName;
        }

        /// <summary>
        ///   Cambia il nome del Progetto
        /// </summary>
        /// 
        private void nameProjectButton_Click(object sender, EventArgs e)
        {
            setProjectName = new SetProjectName();
            setProjectName.Show();
            this.DozeOff();
            this.SendToBack();
            setProjectName.TopMost = true;
        }

        /// <summary>
        ///   Forza la chiusura del ConfigPanel
        /// </summary>
        /// 
        public void CloseSetProjectName()
        {
            if (setProjectName != null && setProjectName.Visible)
            {
                // Chiudo la form ConfigPanel
                this.WakeUp();
                this.BringToFront();
                setProjectName.Close();
            }
        }

        #endregion

        #region NrPanels
        /// <summary>
        ///   Metodo che permette di contare i PanelCurtain di ciascun Codice
        /// </summary>
        /// 
        public void NrCodes()
        {
            int[] nrcodes = m_Handler.NrCodesPanels;
            nrTypologiePanelsTextBox.Text = nrcodes[0].ToString();
            nrCellPanelsTextBox.Text = nrcodes[1].ToString();
            nrPositionalPanelsTextBox.Text = nrcodes[2].ToString();
        }
        #endregion

        #region Capture Button

        /// <summary>
        ///   Metodo che cattura un singolo oggetto della View
        /// </summary>
        /// 
        private void captureButton_Click(object sender, EventArgs e)
    {

        if (dataGridView1.Columns.Count > 0)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            _dataGridViewOriginal.Rows.Clear();
            _dataGridViewOriginal.Columns.Clear();
            _dataGridViewToNumbers.Rows.Clear();
            _dataGridViewToNumbers.Columns.Clear();
            ToggleSwitchToOff();
        }
        MakeRequest(RequestId.Id);
    }

    /// <summary>
    ///   Metodo che imposta il valore della distinta presente nella ComboBox del DataGrid in base alla selezione del Button
    /// </summary>
    /// 
    public void ValueDistintaFromCaptureButton()
    {
        valueDistintaActive = m_Handler.GetValueTypologieCode;
    }

    /// <summary>
    ///   Metodo che imposta il valore del CODICE TIPOLOGIA in base alla selezione del Button
    /// </summary>
    /// 
    public void ValueTypologyCodex()
    {
        typologyTextBox.Text = m_Handler.GetValueTypologieCode;
    }

    /// <summary>
    ///   Metodo che imposta il valore del CODICE CELLULCA (Panel Type Identifier) in base alla selezione del Button
    /// </summary>
    /// 
    public void ValuePanelTypeIdentifierFromCaptureButton()
    {
        panelTypeIdentifierTextBox.Text = m_Handler.GetValueCellCode;
    }

    /// <summary>
    ///   Metodo che imposta il valore dell'Unit Identifier in base alla selezione del Button
    /// </summary>
    /// 
    public void ValueUnitIdentifierFromCaptureButton()
    {
        unitIdentifierTextBox.Text = m_Handler.GetValuePositionalCode;
    }
    #endregion

        #region Cancel

        /// <summary>
        ///   Metodo collegato al pulsante Cancella tutto, che ripulisce la DataGridView, i TextBox e la ListBox
        /// </summary>
        /// 
        private void cleanButton_Click(object sender, EventArgs e)
        {
            nameFamilyTextBox.Text = null;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            _dataGridViewOriginal.Rows.Clear();
            _dataGridViewOriginal.Columns.Clear();
            _dataGridViewToNumbers.Rows.Clear();
            _dataGridViewToNumbers.Columns.Clear();
            ToggleSwitchToOff();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            comboBox1.Text = _defaultTextComboBox;
            typologyTextBox.Text = null;
            unitIdentifierTextBox.Text = null;
            panelTypeIdentifierTextBox.Text = null;
            nrTypologiePanelsTextBox.Text = null;
            nrCellPanelsTextBox.Text = null;
            nrPositionalPanelsTextBox.Text = null;
            error = true;
            SetModifyPicture();
        }

        /// <summary>
        ///   Metodo che ripulisce la DataGridView, i TextBox e la ListBox
        /// </summary>
        /// 
        public void CleanAll()
        {
            nameFamilyTextBox.Text = null;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            _dataGridViewOriginal.Rows.Clear();
            _dataGridViewOriginal.Columns.Clear();
            _dataGridViewToNumbers.Rows.Clear();
            _dataGridViewToNumbers.Columns.Clear();
            ToggleSwitchToOff();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            comboBox1.Text = _defaultTextComboBox;
            typologyTextBox.Text = null;
            unitIdentifierTextBox.Text = null;
            panelTypeIdentifierTextBox.Text = null;
            nrTypologiePanelsTextBox.Text = null;
            nrCellPanelsTextBox.Text = null;
            nrPositionalPanelsTextBox.Text = null;
            error = true;
            SetModifyPicture();
        }

        #endregion

        #region ListBox

        /// <summary>
        ///   Metodo che riempie la ListBox
        /// </summary>
        /// 
        public void ShowListBox1()
        {
            // Resetta il contenuto della ListBox
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            // Popola la ListBox con l'ArrayList delle dimensioni
            ArrayList lista = m_Handler.GetList;
            listBox1.DataSource = lista;
            // Seleziona i titoli delle dimensioni con SelectionMode esteso
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            int count = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (i == count)
                {
                    listBox1.SetSelected(i, true);
                    count += 3;
                }
            }
        }

        #endregion

        #region ComboBox and Excel/DataGridView

        /// <summary>
        ///   Metodo che permette di scegliere il file Excel da caricare nella ComboBox
        /// </summary>
        ///
        private void excelDistintaButton_Click(object sender, EventArgs e)
        {
            if (uploadExcelOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Imposto il nuovo Path del documento da aprire
                    _pathExcel = uploadExcelOpenFileDialog.FileName;

                    // Cancella il contenuto della ComboBox e della DataGrid
                    comboBox1.Items.Clear();
                    comboBox1.Text = _defaultTextComboBox;
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    _dataGridViewOriginal.Rows.Clear();
                    _dataGridViewOriginal.Columns.Clear();
                    _dataGridViewToNumbers.Rows.Clear();
                    _dataGridViewToNumbers.Columns.Clear();
                    ToggleSwitchToOff();

                    // Imposta l'origine dati della Combobox e la riempie con il nuovo documento Excel
                    ImportData newData = new ImportData();
                    List<string> dataBuffer = newData.XlSheets(_pathExcel);
                    foreach (var sheet in dataBuffer)
                    {
                        comboBox1.Items.Add(sheet);
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
        ///   Metodo che sceglie l'elemento attivo nella ComboBox e lo mostra nel DataGridView
        /// </summary>
        /// 
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ottiene la stringa selezionata nella ComboBox
            string selectedItem = (string)comboBox1.SelectedItem;
            valueDistintaActive = selectedItem;

            // Chiama il metodo che importa la pagina scelta del file Excel
            GetDataFromExcel(selectedItem, _pathExcel);

            // Chiama questo metodo e modifica il Count
            MakeRequest(RequestId.ComboBox);
        }

        public void SetComboBox(string selectedItem)
        {
            // Imposta la stringa nella ComboBox
            comboBox1.SelectedItem = selectedItem;
            // Chiama il metodo che importa la pagina scelta del file Excel
            GetDataFromExcel(selectedItem, _pathExcel);
        }

        /// <summary>
        ///   Metodo che Importa il foglio Excel
        /// </summary>
        ///         
        public void GetDataFromExcel(string selectedItem, string path)
        {
            // Assegna al valore attivo nella ComboBox il SelectItem = valore selezionato
            valueActive = selectedItem;

            // Se il DataGridView ha qualche oggetto al suo interno viene ripulito.
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                _dataGridViewOriginal.Rows.Clear();
                _dataGridViewOriginal.Columns.Clear();
                _dataGridViewToNumbers.Rows.Clear();
                _dataGridViewToNumbers.Columns.Clear();
                ToggleSwitchToOff();

            }

            // Ottieni l'oggetto dell'applicazione Excel.
            Excel.Application excel_app = new Excel.Application();

            // Apri la cartella di lavoro in sola lettura
            // (per aprirlo e basta, inserire solo il path del file Excel)
            Excel.Workbook workbook = excel_app.Workbooks.Open(
                path,
                Type.Missing, true, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);

            Excel.Worksheet sheet = (Excel.Worksheet)workbook.Worksheets.Item[selectedItem];

            // Recupera l'intervallo utilizzato.
            Excel.Range used_range = sheet.UsedRange;

            // Ottieni il numero massimo di righe e colonne.
            int max_row = used_range.Rows.Count;
            int max_col = used_range.Columns.Count;

            // Ottieni i valori del foglio.
            object[,] values = (object[,])used_range.Value2;

            // Ottieni i titoli delle colonne.
            SetGridColumns(dataGridView1, values, max_col); 

            // Recupera i dati.
            SetGridContents(dataGridView1, values, max_row, max_col);

            // Chiude la cartella di lavoro senza salvare le modifiche.
            workbook.Close(false, Type.Missing, Type.Missing);

            // Chiude il file Excel.
            excel_app.Quit();

            // Chiude tutti i processi Excel ancora attivi
            KillExcel();

            // Forza il Garbage Collector a ripulire
            GC.Collect();
        }

        /// <summary>
        ///   Metodo che imposta il DataGridView: i nomi delle colonne della griglia dalla riga 1
        /// </summary>
        /// 
        private void SetGridColumns(DataGridView dgv, object[,] values, int max_col)
        {
            dataGridView1.Columns.Clear();

            // Ottieni i valori del titolo.
            for (int col = 1; col <= max_col; col++)
            {
                string title = (string)values[1, col];
                dgv.Columns.Add("col_" + title, title);
            }
        }

        /// <summary>
        ///   Metodo che imposta il DataGridView: il contenuto della griglia
        /// </summary>
        /// 
        private void SetGridContents(DataGridView dgv, object[,] values, int max_row, int max_col)
        {
            // Copia i valori nella griglia.
            for (int row = 2; row <= max_row; row++)
            {
                object[] row_values = new object[max_col];
                for (int col = 1; col <= max_col; col++)
                    row_values[col - 1] = values[row, col];
                dgv.Rows.Add(row_values);
            }
        }

        /// <summary>
        ///   Metodo che Importa il foglio Excel per ottenere i dati contenuti in ALCUNE sue celle
        /// </summary>
        ///         
        public void GetSingleDataFromExcel(string path)
        {
            // Ottiene l'oggetto dell'applicazione Excel.
            Excel.Application excel_app = new Excel.Application();

            // Apre il foglio Excel
            Excel.Workbook workbook = excel_app.Workbooks.Open(path);

            Excel.Worksheet sheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Recupera l'intervallo utilizzato.
            Excel.Range used_range = sheet.UsedRange;

            // Ottiene il numero massimo di righe e colonne.
            int max_row = used_range.Rows.Count;
            int max_col = used_range.Columns.Count;

            // Ottiene i valori del foglio.
            object[,] values = (object[,])used_range.Value2;

            //// Ottiene i titoli delle colonne.
            //SetGridColumns(dataGridView1, values, max_col);

            // Imposta il numero della riga e della colonna che si vuole ottenere
            int rawCommessa = _rawCommessa;
            int colDataCell = _colDataCell;

            // Imposta il path della Distinta
            SetPathContent(values, max_row, max_col, rawCommessa, colDataCell);

            // Chiude la cartella di lavoro senza salvare le modifiche.
            workbook.Close(false, Type.Missing, Type.Missing);

            // Chiude il file Excel.
            excel_app.Quit();

            // Rilascia tutti collegamenti ai File Excel
            Marshal.ReleaseComObject(sheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excel_app);

            // Chiude tutti i processi Excel ancora attivi
            KillExcel();

            // Forza il Garbage Collector a ripulire
            GC.Collect();
        }

        /// <summary>
        ///   Metodo che imposta il contenuto della griglia
        /// </summary>
        /// 
        private void SetPathContent(object[,] values, int max_row, int max_col, int recordRaw, int dataCellCol)
        {
            // Copia i valori nella griglia.
            for (int row = 2; row <= max_row; row++)
            {
                for (int col = 1; col <= max_col; col++)
                {
                    if (row == recordRaw && col == dataCellCol)
                    {
                        _pathDataCell = (string)values[row, col];
                    }
                }
            }
        }

        /// <summary>
        ///   Metodo che chiama il salvataggio del contenuto del DataGridView
        /// </summary>
        /// 
        private void saveExcelDistintabutton_Click(object sender, EventArgs e)
        {
            if (toggle_Switch1.IsOn == false)
            {
                string sheet = valueDistintaActive;
                ExportExcel(_pathExcel, sheet, dataGridView1);
                _excelChanged = true;
            }
            else
            {
                MessageBox.Show("Non puoi salvare il file Excel fino a che stai visualizzando\ni Valori della Distinta in formato numerico.");
            }
        }

        /// <summary>
        ///   Metodo che Esporta in Excel il contenuto del DataGridView
        /// </summary>
        /// 
        public void ExportExcel(string fileName, string sheetDistinta, DataGridView myDGV)
        {

            if (myDGV.Rows.Count > 0)
            {
                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("Non puoi creare un documento Excel." +
                        "\nIl tuo PC potrebbe non essere abilitato per il salvataggio di un file Excel.");
                    return;
                }

                Excel.Workbooks workbooks = xlApp.Workbooks;
                Excel.Workbook workbook = workbooks.Open(fileName);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets.Item[sheetDistinta];

                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
                }

                for (int r = 0; r < myDGV.Rows.Count; r++)
                {
                    for (int i = 0; i < myDGV.ColumnCount; i++)
                    {
                        worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                    }
                    Application.DoEvents();
                }
                worksheet.Columns.EntireColumn.AutoFit();

                if (fileName != "")
                {
                    try
                    {
                        workbook.Save();
                        MessageBox.Show("Salvataggio riuscito.", "Avviso", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Errore di esportazione!\n" + ex.Message);
                    }
                }

                workbook.Close(0);
                xlApp.Quit();

                // Chiude tutti i processi Excel ancora attivi
                KillExcel();

                GC.Collect();
            }
            else
            {
                MessageBox.Show("Non hai caricato alcun file.\nSalvataggio non riuscito.", "Avviso", MessageBoxButtons.OK);
            }
                      
        }

        /// <summary>
        ///   Apre il file Excel visualizzato
        /// </summary>
        /// 
        private void openExcelDistintaButton_Click(object sender, EventArgs e)
        {
            //Excel.Application excel = new Excel.Application();
            //Excel.Workbook wb = excel.Workbooks.Open(_pathExcel);
            if(File.Exists(_pathExcel))
            {
                // Chiude tutti i processi Excel ancora attivi
                KillExcel();
                // Apre il file Excel
                Process.Start(_pathExcel);
            }
        }

        /// <summary>
        ///   Metodo che chiude tutti i processi Excel attivi
        /// 
        static void KillExcel()
        {
            Process[] AllProcesses = Process.GetProcessesByName("excel");

            // check to kill the right process
            foreach (Process ExcelProcess in AllProcesses)
            {
                //if (myHashtable.ContainsKey(ExcelProcess.Id) == true)
                    ExcelProcess.Kill();
            }
            AllProcesses = null;
        }   

        /// <summary>
        ///   Valore attivo nella ComboBox in formato stringa
        /// </summary>
        /// 
        public string ValueSelectedComboBox()
        {
            return valueActive;
        }

        /// <summary>
        ///   Metodo che riporta il TOGGLE SWITCH a OFF
        /// </summary>
        /// 
        private void ToggleSwitchToOff()
        {
            if(toggle_Switch1.IsOn == true)
            {
                toggle_Switch1.IsOn = false;
            }
        }

        /// <summary>
        ///   Metodo che permette la modifica della visualizzazione tramite il TOGGLE SWITCH
        /// </summary>
        /// 
        private void toggle_Switch_Click(object sender, EventArgs e)
        {
            if(dataGridView1.ColumnCount == 0 || 
                m_Handler.GetValueTypologieCode != comboBox1.SelectedItem.ToString())
            {
                toggle_Switch1.IsOn = false;
            }
            else
            {
                // Ottieni il numero massimo di righe e colonne del nuovo DataGridView
                int max_row = dataGridView1.Rows.Count;
                int max_col = dataGridView1.Columns.Count;

                if (_dataGridViewOriginal.ColumnCount == 0 || _excelChanged )
                { 
                    if(_dataGridViewOriginal.ColumnCount > 0 || _dataGridViewToNumbers.ColumnCount > 0)
                    {
                        _dataGridViewOriginal.Rows.Clear();
                        _dataGridViewOriginal.Columns.Clear();
                        _dataGridViewToNumbers.Rows.Clear();
                        _dataGridViewToNumbers.Columns.Clear();
                    }
                    // Crea un oggetto con i valori vuoti del foglio.
                    string value = string.Empty;
                    object[,] values = new object[max_row, max_col];
                    for (int i = 0; i < max_row; i++)
                    {
                        for (int j = 0; j < max_col; j++)
                        {
                            values[i, j] = value;
                        }
                    }

                    // Ottieni i titoli delle colonne.
                    SetGridColumns2(_dataGridViewOriginal, values, max_col);
                    SetGridColumns2(_dataGridViewToNumbers, values, max_col);

                    // Imposta i DatagridView delle stesse dimensioni del Datagrid originale
                    SetGridContents2(_dataGridViewOriginal, values, max_row, max_col);
                    SetGridContents2(_dataGridViewToNumbers, values, max_row, max_col);

                    // Imposta il Datagridview Originale da
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        _dataGridViewOriginal.Columns[i].HeaderText = dataGridView1.Columns[i].HeaderText;
                    }

                    for (int r = 0; r < dataGridView1.Rows.Count; r++)
                    {
                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        {
                            _dataGridViewOriginal.Rows[r].Cells[i].Value = dataGridView1.Rows[r].Cells[i].Value;                            
                        }
                    }
                }

                if (toggle_Switch1.IsOn)
                {
                    bool alert = false;
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        _dataGridViewToNumbers.Columns[i].HeaderText = dataGridView1.Columns[i].HeaderText;
                    }

                    for (int r = 0; r < dataGridView1.Rows.Count; r++)
                    {
                        for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        {
                            if (r >= 0 && r < (max_row - 1) && i >= 2 && i <= 3)
                            {
                                if(dataGridView1.Rows[r].Cells[i].Value != null)
                                {
                                    string value = dataGridView1.Rows[r].Cells[i].Value.ToString();
                                    _dataGridViewToNumbers.Rows[r].Cells[i].Value = ConvertToStringTheValue(value);
                                    if (_dataGridViewToNumbers.Rows[r].Cells[i].Value != dataGridView1.Rows[r].Cells[i].Value)
                                    {
                                        _dataGridViewToNumbers.Rows[r].Cells[i].Style.BackColor = System.Drawing.Color.LightGreen;
                                    }
                                    else
                                    {
                                        alert = true;
                                        _dataGridViewToNumbers.Rows[r].Cells[i].Style.BackColor = System.Drawing.Color.Crimson;
                                    }
                                }
                                else
                                {
                                    _dataGridViewToNumbers.Rows[r].Cells[i].Value = dataGridView1.Rows[r].Cells[i].Value;
                                }
                            }
                            else
                            {
                                _dataGridViewToNumbers.Rows[r].Cells[i].Value = dataGridView1.Rows[r].Cells[i].Value;
                            }
                        }
                    }
                    if(alert)
                    {
                        MessageBox.Show("Alcuni valori nel foglio Excel non corrispondono al progetto.\nModificali.", "Attenzione!");
                        alert = false;
                    }

                    // Assegna il DataGridView modificato al DataGrid
                    for (int i = 0; i < _dataGridViewToNumbers.ColumnCount; i++)
                    {
                        dataGridView1.Columns[i].HeaderText = _dataGridViewToNumbers.Columns[i].HeaderText;
                    }

                    for (int r = 0; r < _dataGridViewToNumbers.Rows.Count; r++)
                    {
                        for (int i = 0; i < _dataGridViewToNumbers.ColumnCount; i++)
                        {
                            dataGridView1.Rows[r].Cells[i].Value = _dataGridViewToNumbers.Rows[r].Cells[i].Value;
                            dataGridView1.Rows[r].Cells[i].Style.BackColor = _dataGridViewToNumbers.Rows[r].Cells[i].Style.BackColor;
                        }
                                               
                    }
                }
                else
                {
                    // Assegna il DataGridView originale al DataGrid
                    for (int i = 0; i < _dataGridViewOriginal.ColumnCount; i++)
                    {
                        dataGridView1.Columns[i].HeaderText = _dataGridViewOriginal.Columns[i].HeaderText;
                    }

                    for (int r = 0; r < _dataGridViewOriginal.Rows.Count; r++)
                    {
                        for (int i = 0; i < _dataGridViewOriginal.ColumnCount; i++)
                        {
                            dataGridView1.Rows[r].Cells[i].Value = _dataGridViewOriginal.Rows[r].Cells[i].Value;
                            dataGridView1.Rows[r].Cells[i].Style.BackColor = _dataGridViewOriginal.Rows[r].Cells[i].Style.BackColor;
                        }
                    }
                }

                // Impedisce di rimpostare i vari DataGridView
                _excelChanged = false;
            } 
        }

        /// <summary>
        ///   Metodo che converte i valori del DataGridView 
        /// </summary>
        /// 
        private string ConvertToStringTheValue(string value)
        {
            // Importa tutti i valori dei parametri dell'elemento scelto
            List<string[]> dimensionList = m_Handler.GetListBoxStrings;

            // Se i valori del parametro non sono stati prelevati, esce
            if(dimensionList.Count > 0)
            {
                // Variabile bool di controllo
                bool control = false;
                // Spezza la stringa in due stringhe con i valori e con gli operatori
                char[] separators = new char[] {'-', '+' };
                string valueReplaced = value.Replace("#", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);
                string[] values = valueReplaced.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                int count = values.Count();
                string operatorString = valueReplaced;
                string resultOper = string.Empty;
                for (int i = 0; i < count; i++)
                {
                    resultOper = operatorString.Replace(values[i], " ");
                    operatorString = resultOper;
                }
                operatorString = resultOper.Trim(' ');
                string[] operators = operatorString.Split(' ');

                double num1 = GetTheValueOfTheListBoxDimension(values, 0, dimensionList);                

                // Se il valore numerico è uguale a zero, esce
                if(num1 > 0)
                {
                    
                    // Fa le operazioni previste dalla formula
                    int rif = 1;
                    double resultFinal = num1;
                    while (count > 1)
                    {                        
                        if (values[rif].Contains("H") || values[rif].Contains("L"))
                        {
                            double num2 = GetTheValueOfTheListBoxDimension(values, 1 , dimensionList);

                            if(num2 == 0)
                            {
                                control = true;
                                break;
                            }

                            switch (operators[rif - 1])
                            {
                                case "+":
                                    resultFinal += num2;
                                    break;
                                case "-":
                                    resultFinal -= num2;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            switch (operators[rif - 1])
                            {
                                case "+":
                                    resultFinal += Convert.ToDouble(values[rif]);
                                    break;
                                case "-":
                                    resultFinal -= Convert.ToDouble(values[rif]);
                                    break;
                                default:
                                    break;
                            }
                        }

                        rif++;
                        if (rif == count)
                        {
                            break;
                        }
                    }

                    if(!control)
                    {
                        //Converte il risultato finale in una stringa
                        value = Convert.ToString(resultFinal) + " mm";
                    }
                }
            }

            return value;
        }

        /// <summary>
        ///   Metodo che calcola il valore della vareabile dimensioanle contenuta nel Datagrid
        /// </summary>
        /// 
        private double GetTheValueOfTheListBoxDimension(string[] values, int index, List<string[]> dimensionList)
        {
            // Se contiene valori diversi da quelli contenuti nelle Dimensioni, li trasforma
            string param = string.Empty;
            switch (values[index])
            {
                case "H":
                case "CellH":
                    param = "CellH";
                    break;
                case "H1":
                case "CellH1":
                    param = "CellH1";
                    break;
                case "H2":
                case "H3":
                case "H4":
                case "CellH2":
                    param = "CellH2";
                    break;
                case "L1":
                case "L2":
                case "L3":
                case "CellL":
                    param = "CellL";
                    break;
                default:
                    break;
            }

            // Comverte la variabile iniziale in un numero double
            double num = 0D;
            foreach (string[] item in dimensionList)
            {
                if (item[0] == param)
                {
                    num = Convert.ToDouble(item[1]);
                }
            }
            return num;
        }

        /// <summary>
        ///   Metodo che imposta il DataGridView: i nomi delle colonne della griglia dalla riga 1
        /// </summary>
        /// 
        private void SetGridColumns2(DataGridView dgv, object[,] values, int max_col)
        {
            //dataGridView1.Columns.Clear();

            // Ottieni i valori del titolo.
            for (int col = 0; col < max_col; col++)
            {
                string title = (string)values[1, col];
                dgv.Columns.Add("col_" + title, title);
            }
        }

        /// <summary>
        ///   Metodo che imposta il DataGridView: il contenuto della griglia
        /// </summary>
        /// 
        private void SetGridContents2(DataGridView dgv, object[,] values, int max_row, int max_col)
        {
            // Copia i valori nella griglia.
            for (int row = 1; row < max_row; row++)
            {
                object[] row_values = new object[max_col];
                for (int col = 0; col < max_col; col++)
                    row_values[col] = values[row, col];
                dgv.Rows.Add(row_values);
            }
        }
        #endregion

        #region PictureBox

        /// <summary>
        ///   Metodo che permette di caricare la cartella delle immagini
        /// </summary>
        /// 
        private void imagesButton_Click(object sender, EventArgs e)
        {
            // Mostra la FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Imposta il nuovo Path
                _folderName = folderBrowserDialog1.SelectedPath;
                _folderImageActual = _folderName;

                // Carica le nuove immagini
                newImages = true;
                SetModifyPicture();
            }
            // Cancel button was pressed.
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        // Recupera il valore stringa del tipo della famiglia dall'elemento selezionato
        private string GetPathModifier()
        {
            // Cattura il tipo di famiglia dell'immagine
            _familyType = m_Handler.GetFamilyType;

            if (newImages)
            {
                return "";
            }
            else if(_familyType == null)
            {
                return "";
            }
            else if(error)
            {
                return "";
            }
            else
            {                
                nameFamilyTextBox.Text = _familyType;
                return _familyType;
            }
        }

        // Implemento una classe che mi permetta di creare una lista per le caratteristiche delle immagini
        public struct DataPicture
        {
            public DataPicture(string strValue, int intValue1, int intValue2)
            {
                StringData = strValue;
                IntegerData1 = intValue1;
                IntegerData2 = intValue2;
            }
            public string StringData { get; private set; }
            public int IntegerData1 { get; private set; }
            public int IntegerData2 { get; private set; }
        }

        // Riempio una lista con tutti i dati delle immagini del singolo oggetto
        public void SetModifyPicture()
        {
            PictureBoxCentral(GetDataPictureCentral().StringData, GetDataPictureCentral().IntegerData1, GetDataPictureCentral().IntegerData2);              
            PictureBoxDx(GetDataPictureDx().StringData, GetDataPictureDx().IntegerData1, GetDataPictureDx().IntegerData2);
            PictureBoxSx(GetDataPictureSx().StringData, GetDataPictureSx().IntegerData1, GetDataPictureSx().IntegerData2);
            PictureBoxHigh(GetDataPictureHigh().StringData, GetDataPictureHigh().IntegerData1, GetDataPictureHigh().IntegerData2);
            error = false;
        }
        public DataPicture GetDataPictureCentral()
        {
            // Proprietà immagine centrale
            string pathc = "";
            string stringToAdd = GetPathModifier();
            if (stringToAdd == null || stringToAdd == "")
            {
                pathc = _folderImageSkeleton + "\\_F.png";
            }
            else
            {
                pathc = _folderImageActual + "\\" + stringToAdd + "_F.png";
            }

            int widthc = 222;
            int heigthc = 325;

            if (File.Exists(pathc))
            {                
                var data = new DataPicture(pathc, widthc, heigthc);
                return data;
            }
            else
            {
                var data = new DataPicture(_folderImageSkeleton + @"\_F.png", widthc, heigthc);
                return data;                 
            }
        }

        public DataPicture GetDataPictureDx()
        {
            // Proprietà immagine destra
            string pathd = "";
            string stringToAdd = GetPathModifier();
            if (stringToAdd == null || stringToAdd == "")
            {
                pathd = _folderImageSkeleton + "\\_R.png";
            }
            else
            {
                pathd = _folderImageActual + "\\" + stringToAdd + "_R.png";
            }

            int widthd = 65;
            int heigthd = 325;

            if (File.Exists(pathd))
            {                
                var data = new DataPicture(pathd, widthd, heigthd);
                return data;
            }
            else
            {
                var data = new DataPicture(_folderImageSkeleton + @"\_R.png", widthd, heigthd);
                return data;
            }
            
        }

        public DataPicture GetDataPictureSx()
        {
            // Proprietà immagine sinistra
            string paths = "";
            string stringToAdd = GetPathModifier();
            if (stringToAdd == null || stringToAdd == "")
            {
                paths = _folderImageSkeleton + "\\_L.png";
            }
            else
            {
                paths = _folderImageActual + "\\" + stringToAdd + "_L.png";
            }

            int widths = 65;
            int heigths = 325;

            if (File.Exists(paths))
            {

                var data = new DataPicture(paths, widths, heigths);
                return data;
            }
            else
            {
                var data = new DataPicture(_folderImageSkeleton + @"\_L.png", widths, heigths);
                return data;
            }
            
        }

        public DataPicture GetDataPictureHigh()
        {
            // Proprietà immagine alta
            string pathh = "";
            string stringToAdd = GetPathModifier();
            if (stringToAdd == null || stringToAdd == "")
            {
                pathh = _folderImageSkeleton + "\\_P.png";
            }
            else
            {
                pathh = _folderImageActual + "\\" + stringToAdd + "_P.png";
            }

            int widthh = 222;
            int heigthh = 25;

            if (File.Exists(pathh))
            {
                var data = new DataPicture(pathh, widthh, heigthh);
                return data;
            }
            else
            {
                var data = new DataPicture(_folderImageSkeleton + @"\_P.png", widthh, heigthh);
                return data;
            }
            
        }        

        private Bitmap MyImage1;
        private Bitmap MyImage2;
        private Bitmap MyImage3;
        private Bitmap MyImage4;

        public object App { get; internal set; }

        public void PictureBoxCentral(string fileToDisplay, int xSize, int ySize)
        {
            // Sets up an image object to be displayed.
            if (MyImage1 != null)
            {
                MyImage1.Dispose();
            }

            //// Set the size of the PictureBox control.
            //pictureBoxCentral.Size = new System.Drawing.Size(xSize, ySize);

            pictureBoxCentral.SizeMode = PictureBoxSizeMode.Zoom;

            if (File.Exists(fileToDisplay))
            {
                MyImage1 = new Bitmap(fileToDisplay);
            }
            else
            {
                MessageBox.Show("Si è verificato un errore nel caricamento dell'immagine."
                    + "\nControlla che i nomi o il percorso di caricamento delle immagini siano corretti.");

                if(MyImage1 != null)
                {
                    _folderImageActual = _folderImageDefault;

                    MyImage1 = new Bitmap(_folderImageActual + "\\_F.png");
                    nameFamilyTextBox.Text = null;
                }
            }
            pictureBoxCentral.Image = (Image)MyImage1;
        }
        public void PictureBoxDx(string fileToDisplay, int xSize, int ySize)
        {
            //Sets up an image object to be displayed.
            if (MyImage2 != null)
            {
                MyImage2.Dispose();
            }
            //// Set the size of the PictureBox control.
            //pictureBoxDx.Size = new System.Drawing.Size(xSize, ySize);

            pictureBoxDx.SizeMode = PictureBoxSizeMode.Zoom;

            if (File.Exists(fileToDisplay))
            {
                MyImage2 = new Bitmap(fileToDisplay);
            }
            else
            {
                if (MyImage2 != null)
                {
                    _folderImageActual = _folderImageDefault;
                    MyImage2 = new Bitmap(_folderImageActual + "\\_R.png");
                    nameFamilyTextBox.Text = null;
                }
            }
            pictureBoxDx.Image = (Image)MyImage2;
        }

        public void PictureBoxSx(string fileToDisplay, int xSize, int ySize)
        {
            //Sets up an image object to be displayed.
            if (MyImage3 != null)
            {
                MyImage3.Dispose();
            }
            //// Set the size of the PictureBox control.
            //pictureBoxSx.Size = new System.Drawing.Size(xSize, ySize);

            pictureBoxSx.SizeMode = PictureBoxSizeMode.Zoom;

            if (File.Exists(fileToDisplay))
            {
                MyImage3 = new Bitmap(fileToDisplay);
            }
            else
            {
                if (MyImage3 != null)
                {
                    _folderImageActual = _folderImageDefault;
                    MyImage3 = new Bitmap(_folderImageActual + "\\_L.png");
                    nameFamilyTextBox.Text = null;
                }                    
            }
            pictureBoxSx.Image = (Image)MyImage3;
        }

        public void PictureBoxHigh(string fileToDisplay, int xSize, int ySize)
        {
            //Sets up an image object to be displayed.
            if (MyImage4 != null)
            {
                MyImage4.Dispose();
            }
            //// Set the size of the PictureBox control.
            //pictureBoxHigh.Size = new System.Drawing.Size(xSize, ySize);

            pictureBoxHigh.SizeMode = PictureBoxSizeMode.Zoom;

            if (File.Exists(fileToDisplay))
            {
                MyImage4 = new Bitmap(fileToDisplay);
            }
            else
            {
                if (MyImage4 != null)
                {
                    _folderImageActual = _folderImageDefault;
                    MyImage4 = new Bitmap(_folderImageActual + "\\_P.png");
                    nameFamilyTextBox.Text = null;
                }                    
            }
            pictureBoxHigh.Image = (Image)MyImage4;

            // Rendo newImages false, in modo da poter modificare nuovamente le immagini quando si sceglie un oggetto
            newImages = false;
        }
        #endregion

        #region Magnifying Glass
        /// <summary>
        ///   Attiva la Form della lente d'ingrandimento.
        /// </summary>
        /// 
        private void magnifyingGlassButton_Click(object sender, EventArgs e)
        {
            _activeMagnifyngGlass = true;
            //magnifyingGlass = new MagnifyingGlass();
            //magnifyingGlass.Show();
            //this.SendToBack();
            //magnifyingGlass.TopMost = true;
        }

        /// <summary>
        ///   Forza la chiusura della Form della lente d'ingrandimento.
        /// </summary>
        /// 
        private void magnifyingGlassCloseButton_Click(object sender, EventArgs e)
        {
            _activeMagnifyngGlass = false;
            //if (magnifyingGlass != null && magnifyingGlass.Visible)
            //{
            //    this.BringToFront();
            //    magnifyingGlass.Close();
            //}
        }

        /// <summary>
        ///   Attiva la Form della lente d'ingrandimento.
        /// </summary>
        /// 
        private void pictureBoxCentral_GlassButton_Enter(object sender, EventArgs e)
        {
            if (_activeMagnifyngGlass == true)
            {
                magnifyingGlass = new MagnifyingGlass();
                magnifyingGlass.Show();
                this.SendToBack();
                magnifyingGlass.TopMost = true;
            }
        }

        /// <summary>
        ///   Forza la chiusura della Form della lente d'ingrandimento.
        /// </summary>
        /// 
        private void pictureBoxCentral_GlassButton_Leave(object sender, EventArgs e)
        {
            if (_activeMagnifyngGlass == true && magnifyingGlass != null && magnifyingGlass.Visible)
            {
                this.BringToFront();
                magnifyingGlass.Close();
            }
        }

        /// <summary>
        ///   Attiva la Form della lente d'ingrandimento.
        /// </summary>
        /// 
        private void pictureBoxHigh_GlassButton_Enter(object sender, EventArgs e)
        {
            if (_activeMagnifyngGlass == true)
            {
                magnifyingGlass = new MagnifyingGlass();
                magnifyingGlass.Show();
                this.SendToBack();
                magnifyingGlass.TopMost = true;
            }
        }

        /// <summary>
        ///   Forza la chiusura della Form della lente d'ingrandimento.
        /// </summary>
        /// 
        private void pictureBoxHigh_GlassButton_Leave(object sender, EventArgs e)
        {
            if (_activeMagnifyngGlass == true && magnifyingGlass != null && magnifyingGlass.Visible)
            {
                this.BringToFront();
                magnifyingGlass.Close();
            }
        }

        /// <summary>
        ///   Attiva la Form della lente d'ingrandimento.
        /// </summary>
        /// 
        private void pictureBoxSx_GlassButton_Enter(object sender, EventArgs e)
        {
            if(_activeMagnifyngGlass == true)
            {
                magnifyingGlass = new MagnifyingGlass();
                magnifyingGlass.Show();
                this.SendToBack();
                magnifyingGlass.TopMost = true;
            }
        }

        /// <summary>
        ///   Forza la chiusura della Form della lente d'ingrandimento.
        /// </summary>
        /// 
        private void pictureBoxSx_GlassButton_Leave(object sender, EventArgs e)
        {
            if (_activeMagnifyngGlass == true && magnifyingGlass != null && magnifyingGlass.Visible)
            {
                this.BringToFront();
                magnifyingGlass.Close();
            }
        }

        /// <summary>
        ///   Attiva la Form della lente d'ingrandimento.
        /// </summary>
        /// 
        private void pictureBoxDx_GlassButton_Enter(object sender, EventArgs e)
        {
            if (_activeMagnifyngGlass == true)
            {
                magnifyingGlass = new MagnifyingGlass();
                magnifyingGlass.Show();
                this.SendToBack();
                magnifyingGlass.TopMost = true;
            }
        }

        /// <summary>
        ///   Forza la chiusura della Form della lente d'ingrandimento.
        /// </summary>
        /// 
        private void pictureBoxDx_GlassButton_Leave(object sender, EventArgs e)
        {
            if (_activeMagnifyngGlass == true && magnifyingGlass != null && magnifyingGlass.Visible)
            {
                this.BringToFront();
                magnifyingGlass.Close();
            }
        }

        #endregion


        /// <summary>
        ///   Exit - chiude la finestra di dialogo
        /// </summary>
        /// 
        public void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }  // class
}
