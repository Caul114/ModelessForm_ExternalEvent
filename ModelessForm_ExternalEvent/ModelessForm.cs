using Autodesk.Revit.UI;
using ModelessForm_ExternalEvent.DataFromExcel;
using ModelessForm_ExternalEvent.FromToExcel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        // Percorso del singolo file excel da importare
        string path = "C:\\DatiLDB\\ExcelData\\AbacoCells.xlsx";
        ImportData importData = new ImportData();

        // Valore attivo nella ComboBox
        private string valueActive;

        /// <summary>
        ///   Costruttore della finestra di dialogo
        /// </summary>
        /// 
        public ModelessForm(ExternalEvent exEvent, RequestHandler handler)
        {
            InitializeComponent();
            m_Handler = handler;
            m_ExEvent = exEvent;

            // Imposta l'origine dati della Combobox e la riempie
            List<string> dataBuffer = importData.XlSheets(path);
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
        ///   Metodo che riempie il TextBox Distinta
        /// </summary>
        /// 
        public void ShowValueBOLD_Distinta()
        {
            textDistintaPicker.Text = m_Handler.GetDistintaValue;
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

                // Aggiunge il log delle azioni effettuate nella ListBox
                listBox1.DataSource = m_Handler.GetLog;
            }
        }

        /// <summary>
        ///   Metodo che ripulisce la DataGridView, i TextBox e la ListBox
        /// </summary>
        /// 
        private void cleanButton_Click(object sender, EventArgs e)
        {
            textDistintaPicker.Text = null;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            listBox1.DataSource = null;
            listBox1.Items.Clear();
        }

        /// <summary>
        ///   Metodo che esporta il Contenuto del DataGridView in un foglio Excel
        /// </summary>
        /// 
        private void exportButton_Click(object sender, EventArgs e)
        {
            MakeRequest(RequestId.Exp);
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            MakeRequest(RequestId.Imp);
        }


        /// <summary>
        ///   Exit - chiude la finestra di dialogo
        /// </summary>
        /// 
        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///   Metodo che sceglie l'elemento attivo nella ComboBox e lo mostra nel DataGridView
        /// </summary>
        /// 
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Chiama questo metodo e modifica il Count
            MakeRequest(RequestId.ComboBox);

            string selectedEmployee = (string)comboBox1.SelectedItem;

            // Assegna al valore attivo nella ComboBox il selectedEmployee
            valueActive = selectedEmployee;

            textDistintaComboBox.Text = selectedEmployee;

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
                    path,
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

        private void functionGroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void importDistintaLabel_Click(object sender, EventArgs e)
        {

        }

        //public DataTable GetDataTableFromDataGridSource()
        //{
        //    // Crea una DataTable
        //    DataTable dt = new DataTable();

        //    // Aggiunge le colonne
        //    foreach (DataGridViewColumn column in dataGridView1.Columns)
        //    {
        //        dt.Columns.Add(column.HeaderText, column.ValueType);
        //    }

        //    // Aggiunge le righe
        //    foreach (DataGridViewRow row in dataGridView1.Rows)
        //    {
        //        dt.Rows.Add();
        //        foreach (DataGridViewCell cell in row.Cells)
        //        {
        //            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
        //        }
        //    }
        //    return dt;
        //}
    }  // class
}
