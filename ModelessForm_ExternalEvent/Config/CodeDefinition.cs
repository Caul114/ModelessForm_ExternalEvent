using Autodesk.Revit.UI;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelessForm_ExternalEvent.Config
{
    public partial class CodeDefinition : Form
    {
        #region Private data members

        private RequestHandler m_Handler;

        // Istanza della classe 
        internal static CodeDefinition thisCodeDef = null;

        // Dichiarazione della Form principale
        private ModelessForm _modelessForm;

        // Variabile che indica il nome del Codice Tipologia
        private string _typologieCode = string.Empty;

        // Variabile che indica il nome del Codice Cellula
        private string _cellCode = string.Empty;

        // Variabile che indica il nome del Codice Posizionale
        private string _positionalCode = string.Empty;

        // Dichiaro una instanza di ExportValueToExcel
        private ExportValueToExcel exportValueToExcel = new ExportValueToExcel();

        // Imposta i valori delle raw e delle column dell'Excel Config 
        private int _rawCommessa = 2;
        private int _colValue = 0;

        #endregion

        #region Class public property
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

        public CodeDefinition()
        {
            m_Handler = new RequestHandler();
            InitializeComponent();

            thisCodeDef = this;
        }

        /// <summary>
        ///   Riempie le ComboBoxes
        /// </summary>
        /// 
        public void FillTheComboBoxes(List<string> stringList)
        {
            foreach (string item in stringList)
            {
                typologieCodeComboBox.Items.Add(item);
                cellCodeComboBox.Items.Add(item);
                positionalCodeComboBox.Items.Add(item);
            }
        }

        /// <summary>
        ///   Salva le modifiche effettuate
        /// </summary>
        /// 
        private void saveButton_Click(object sender, EventArgs e)
        {
            _typologieCode = typologieCodeComboBox.SelectedItem as string;
            _cellCode = cellCodeComboBox.SelectedItem as string;
            _positionalCode = positionalCodeComboBox.SelectedItem as string;

            // Chiama il metodo che implementa i cambiamenti
            _modelessForm = App.thisApp.RetriveForm();
            _modelessForm.GoToChanges();

            // Salva i cambiamenti nel File di configurazione
            SavesCodesInJson();
        }

        /// <summary>
        ///   Salva i nuovi codici nel file .json di Configurazione
        /// </summary>
        /// 
        private void SavesCodesInJson()
        {
            _modelessForm = App.thisApp.RetriveForm();
            string pathExcel = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                _modelessForm.PathFileConfig;

            if(File.Exists(pathExcel))
            {
                // Scrive i codici in un file esterno Json di Configurazione
                Json fileJson = new Json();
                fileJson.UpdateJson(5, 4, "TypologieCode", _typologieCode);
                fileJson.UpdateJson(6, 5, "CellCode", _cellCode);
                fileJson.UpdateJson(7, 6, "PositionalCode", _positionalCode);

                // Ottiene il _pathconfig del foglio Excel
                string jsonText = File.ReadAllText(ModelessForm.thisModForm.PathFileTxt);
                IList<Data> traduction = JsonConvert.DeserializeObject<IList<Data>>(jsonText);
                Data singleItem = traduction.FirstOrDefault(x => x.Id == 1);
                string pathExcelConfig = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + singleItem.Value;

                // Esporta le modifiche su foglio Excel, del pathDataCell, di AbacoCells.xlsm e di Images
                //exportValueToExcel.KillExcel();
                 _colValue = 6;
                exportValueToExcel.ExportExcelAndChangeValue(pathExcelConfig, _typologieCode, _cellCode, _positionalCode, _rawCommessa, _colValue);
                //_colValue = 7;
                //exportValueToExcel.ExportExcelAndChangeValue(pathExcelConfig, _cellCode, _rawCommessa, _colValue);
                //_colValue = 8;
                //exportValueToExcel.ExportExcelAndChangeValue(pathExcelConfig, _positionalCode, _rawCommessa, _colValue);

                // Chiude la Form
                this.Close();

                // Avvisa che per far funziona reil DataCell bisogna riaccenderlo
                MessageBox.Show("Hai concluso correttamente la Configurazione. " +
                    "\nRientra cliccando nuovamente sul Plugin DataCell che trovi nel Pannello BOLD");

                // Chiude il DataCell 
                ModelessForm.thisModForm.Close();
            }

        }
    }
}
