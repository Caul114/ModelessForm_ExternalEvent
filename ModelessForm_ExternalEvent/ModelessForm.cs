using Autodesk.Revit.UI;
using ModelessForm_ExternalEvent.DataFromExcel;
using ModelessForm_ExternalEvent.FromToExcel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        private RequestHandler m_Handler;
        private ExternalEvent m_ExEvent;

        // Percorso del singolo file excel da importare di default
        string pathExcel = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\DataCell_Bold_utilities\\AbacoCells.xlsx";
        ImportData importData = new ImportData();

        // Percorso della cartella Immagini di default
        string folderNameDefault = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\DataCell_Bold_utilities\\Images";
        string folderNameActual = "";        
        string folderName = "";

        // Valore attivo nella ComboBox
        private string valueActive;

        // Valore booleano di errore
        bool error = false;

        // Valore booleano per impostare le nuove immagini
        bool newImages = false;

        /// <summary>
        ///   Costruttore della finestra di dialogo
        /// </summary>
        /// 
        public ModelessForm(ExternalEvent exEvent, RequestHandler handler)
        {
            InitializeComponent();
            m_Handler = handler;
            m_ExEvent = exEvent;

            // Inserisco le immagini selezionate
            folderNameActual = folderNameDefault;
            SetModifyPicture();
            imagesTextBox.Text = folderNameDefault;

            // Imposta l'origine dati della Combobox e la riempie
            List<string> dataBuffer = importData.XlSheets(pathExcel);
            foreach (var sheet in dataBuffer)
            {
                comboBox1.Items.Add(sheet);
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
        private void MakeRequest(RequestId request)
        {
            App.thisApp.DontShowFormTop();
            m_Handler.Request.Make(request);
            m_ExEvent.Raise();
            DozeOff();            
        }


        /// <summary>
        ///   DozeOff -> disabilita tutti i controlli (tranne il pulsante Esci)
        /// </summary>
        /// 
        private void DozeOff()
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
            }
                MakeRequest(RequestId.Id);            
        }


        /// <summary>
        ///   Metodo che riempie la DataGridView
        /// </summary>
        /// 
        public void ShowDataGridView1()
        {
            if(m_Handler.GetTable != null)
            {
                // Riempie il DataGridView con la Sheet scelta del foglio Excel
                dataGridView1.DataSource = m_Handler.GetTable;
            }
        }

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
                if(i == count)
                {
                    listBox1.SetSelected(i, true);
                    count += 3;
                }
            }  
        }

        /// <summary>
        ///   Metodo collegato al pulsante Cancella tutto, che ripulisce la DataGridView, i TextBox e la ListBox
        /// </summary>
        /// 
        private void cleanButton_Click(object sender, EventArgs e)
        {
            nameFamilyTextBox.Text = null;
            textDistintaComboBox.Text = null;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            comboBox1.Text = "<- Scegli una pagina del foglio Excel ->";
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
            textDistintaComboBox.Text = null;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            comboBox1.Text = "<- Scegli una pagina del foglio Excel ->";
            error = true;
            SetModifyPicture();
        }

        /// <summary>
        ///   Metodo che esporta il Contenuto del DataGridView in un foglio Excel
        /// </summary>
        /// 
        private void exportButton_Click(object sender, EventArgs e)
        {
            if(dataGridView1.DataSource != null)
            {
                MakeRequest(RequestId.Exp);
            }
        }


        /// <summary>
        ///   Exit - chiude la finestra di dialogo
        /// </summary>
        /// 
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region ComboBox

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
                    pathExcel = uploadExcelOpenFileDialog.FileName;

                    // Cancella il contenuto della ComboBox e della DataGrid
                    comboBox1.Items.Clear();
                    comboBox1.Text = "<- Scegli una pagina del foglio Excel ->";
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();

                    // Imposta l'origine dati della Combobox e la riempie con il nuovo documento Excel
                    ImportData newData = new ImportData();
                    List<string> dataBuffer = newData.XlSheets(pathExcel);
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
            // Chiama questo metodo e modifica il Count
            MakeRequest(RequestId.ComboBox);

            string selectedItem = (string)comboBox1.SelectedItem;

            // Assegna al valore attivo nella ComboBox il selectedEmployee
            valueActive = selectedItem;

            textDistintaComboBox.Text = selectedItem;

            // Ottiene il foglio di lavoro dell'elemento selezionato.
            int sheetSelected = comboBox1.SelectedIndex + 1;
            if (sheetSelected > 0)
            {
                // Se il DataGridView ha qualche oggetto al suo interno viene ripulito.
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                }
                // Ottieni l'oggetto dell'applicazione Excel.
                Excel.Application excel_app = new Excel.Application();

                //// Rendi visibile Excel (opzionale).
                //excel_app.Visible = true;

                // Apri la cartella di lavoro in sola lettura.
                Excel.Workbook workbook = excel_app.Workbooks.Open(
                    pathExcel,
                    Type.Missing, true, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);

                Excel.Worksheet sheet = (Excel.Worksheet)workbook.Sheets[sheetSelected];

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

                // Chiude il server Excel.
                excel_app.Quit();
            }
            else
            {
                MessageBox.Show("Non hai selezionato alcun documento Excel.", "Errore!");
            }
        }

        // Imposta i nomi delle colonne della griglia dalla riga 1.
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

        // Imposta il contenuto della griglia..
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
        ///   Valore attivo nella ComboBox in formato stringa
        /// </summary>
        /// 
        public string ValueSelectedComboBox()
        {
            return valueActive;
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
                folderName = folderBrowserDialog1.SelectedPath;
                folderNameActual = folderName;
                imagesTextBox.Text = folderName;

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
            string familyType = "";
            if(newImages)
            {
                return "";
            }
            if(familyType == null)
            {
                return "";
            }
            else if(error)
            {
                return "";
            }
            else
            {
                familyType = m_Handler.GetFamilyType;
                nameFamilyTextBox.Text = familyType;
                return familyType;
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
            string pathc = folderNameActual + "\\" + GetPathModifier() + "_F.png";
            int widthc = 222;
            int heigthc = 325;
            var data = new DataPicture(pathc, widthc, heigthc);
            return data;
        }

        public DataPicture GetDataPictureDx()
        {
            // Proprietà immagine destra
            string pathd = folderNameActual + "\\" + GetPathModifier() + "_D.png";
            int widthd = 65;
            int heigthd = 325;
            var data = new DataPicture(pathd, widthd, heigthd);
            return data;
        }

        public DataPicture GetDataPictureSx()
        {
            // Proprietà immagine sinistra
            string paths = folderNameActual + "\\" + GetPathModifier() + "_S.png";
            int widths = 65;
            int heigths = 325;
            var data = new DataPicture(paths, widths, heigths);
            return data;
        }

        public DataPicture GetDataPictureHigh()
        {
            // Proprietà immagine alta
            string pathh = folderNameActual + "\\" + GetPathModifier() + "_P.png";
            int widthh = 222;
            int heigthh = 25;
            var data = new DataPicture(pathh, widthh, heigthh);
            return data;
        }        

        private Bitmap MyImage1;
        private Bitmap MyImage2;
        private Bitmap MyImage3;
        private Bitmap MyImage4;

        public void PictureBoxCentral(string fileToDisplay, int xSize, int ySize)
        {
            // Sets up an image object to be displayed.
            if (MyImage1 != null)
            {
                MyImage1.Dispose();
            }

            // Set the size of the PictureBox control.
            pictureBoxCentral.Size = new System.Drawing.Size(xSize, ySize);

            pictureBoxCentral.SizeMode = PictureBoxSizeMode.StretchImage;

            if (File.Exists(fileToDisplay))
            {
                MyImage1 = new Bitmap(fileToDisplay);
            }
            else
            {
                MessageBox.Show("Si è verificato un errore nel caricamento dell'immagine."
                    + "\nControlla che il nome dell'immagine o il percorso di caricamento siano corretti.");

                folderNameActual = folderNameDefault;
                imagesTextBox.Text = folderNameDefault;

                MyImage1 = new Bitmap(folderNameActual + "\\_F.png");
                nameFamilyTextBox.Text = null;
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
            // Set the size of the PictureBox control.
            pictureBoxDx.Size = new System.Drawing.Size(xSize, ySize);

            pictureBoxDx.SizeMode = PictureBoxSizeMode.StretchImage;

            if (File.Exists(fileToDisplay))
            {
                MyImage2 = new Bitmap(fileToDisplay);
            }
            else
            {
                folderNameActual = folderNameDefault;
                MyImage2 = new Bitmap(folderNameActual + "\\_D.png");
                nameFamilyTextBox.Text = null;
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
            // Set the size of the PictureBox control.
            pictureBoxSx.Size = new System.Drawing.Size(xSize, ySize);

            pictureBoxSx.SizeMode = PictureBoxSizeMode.StretchImage;

            if (File.Exists(fileToDisplay))
            {
                MyImage3 = new Bitmap(fileToDisplay);
            }
            else
            {
                folderNameActual = folderNameDefault;
                MyImage3 = new Bitmap(folderNameActual + "\\_S.png");
                nameFamilyTextBox.Text = null;
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
            // Set the size of the PictureBox control.
            pictureBoxHigh.Size = new System.Drawing.Size(xSize, ySize);

            pictureBoxHigh.SizeMode = PictureBoxSizeMode.StretchImage;

            if (File.Exists(fileToDisplay))
            {
                MyImage4 = new Bitmap(fileToDisplay);
            }
            else
            {
                folderNameActual = folderNameDefault;
                MyImage4 = new Bitmap(folderNameActual + "\\_P.png");
                nameFamilyTextBox.Text = null;
            }
            pictureBoxHigh.Image = (Image)MyImage4;

            // Rendo newImages false, in modo da poter modificare nuovamente le immagini quando si sceglie un oggetto
            newImages = false;
        }


        #endregion


    }  // class
}
