//
// (C) Copyright 2003-2017 by Autodesk, Inc.
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE. AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is subject to
// restrictions set forth in FAR 52.227-19 (Commercial Computer
// Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
// (Rights in Technical Data and Computer Software), as applicable.
//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ModelessForm_ExternalEvent.DataFromExcel;
using ModelessForm_ExternalEvent.FromToExcel;
using ModelessForm_ExternalEvent.ToExcel;

namespace ModelessForm_ExternalEvent
{
    /// <summary>
    ///   Una classe con metodi per eseguire le richieste effettuate dall'utente della finestra di dialogo.
    /// </summary>
    /// 
    public class RequestHandler : IExternalEventHandler  // Un'istanza di una classe che implementa questa interfaccia verrà registrata prima con Revit e ogni volta che viene generato l'evento esterno corrispondente, verrà richiamato il metodo Execute di questa interfaccia.
    {
        #region Private data members
        // Il valore dell'ultima richiesta effettuata dal modulo non modale
        private Request m_request = new Request();

        // Il Riferimento all'oggetto selezionato
        Reference pickedObject;

        // Il valore di BOLD_Distinta
        private string _valueDistinta;

        // Il valore selezionato nella ComboBox
        private string _valueSelectedComboBox;

        // Il tipo della famiflia in formato stringa
        private string _familyType;

        // Il valore attivo nella pagina
        private string _valueActive;
        int count = 0;

        // La lista di stringhe che restituirà i valori da inserire in ListBox
        private ArrayList _dimensionsList;

        // Un instanza della finestra di dialogo
        private ModelessForm modelessForm;

        // Un instanza di DataTable per riempire il DataGridView
        private DataTable _table;

        // Percorso file Excel con tutte le Distinte
        string path = "C:\\DatiLDB\\ExcelData\\AbacoCells.xlsx";
        string path2 = "C:\\DatiLDB\\ExcelData\\AbacoCellsSalvato.xlsx";
        private List<string> _listXlSh;
        #endregion

        #region Class public property
        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public Request Request
        {
            get { return m_request; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public string GetDistintaValue
        {
            get { return _valueDistinta; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public string GetFamilyType
        {
            get { return _familyType; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere ai valori della ListBox
        /// </summary>
        public ArrayList GetList
        {
            get { return _dimensionsList; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere ai valori della DataTable
        /// </summary>
        public DataTable GetTable
        {
            get { return _table; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere ai valori della DataTable
        /// </summary>
        public List<string> Strings
        {
            get { return _listXlSh; }
        }
        #endregion

        #region Class public method
        /// <summary>
        /// Costruttore di default di RequestHandler
        /// </summary>
        public RequestHandler()
        {
            // Costruisce i membri dei dati per le proprietà
            _dimensionsList = new ArrayList();
            _listXlSh = new List<string>();
            _table = new DataTable();
        }
        #endregion

        /// <summary>
        ///   Un metodo per identificare questo gestore di eventi esterno
        /// </summary>
        public String GetName()
        {
            return "R2014 External Event Sample";
        }

        /// <summary>
        ///   Il metodo principale del gestore di eventi.
        /// </summary>
        /// <remarks>
        ///   Viene chiamato da Revit dopo che è stato generato l'evento esterno corrispondente 
        ///   (dal modulo non modale) e Revit ha raggiunto il momento in cui potrebbe 
        ///   chiamare il gestore dell'evento (cioè questo oggetto)
        /// </remarks>
        /// 
        public void Execute(UIApplication uiapp)
        {
            try
            {
                switch (Request.Take())
                {
                    case RequestId.None:
                        {
                            return;  // no request at this time -> we can leave immediately
                        }
                    case RequestId.Id:
                        {
                            // Chiama il metodo che seleziona un oggetto
                            pickedObject = PickObject(uiapp);
                            // Chiama il metodo che restituisce il valore della BOLD_Distinta
                            _valueDistinta = PickBOLD_distinta(uiapp, pickedObject);
                            // Cambia il count
                            count = 1;
                            modelessForm = App.thisApp.RetriveForm();
                            // Se il valore della BOLD_Distinta è presente, lo aggiunge alla Form
                            if (_valueDistinta != "Nessun valore" && _valueDistinta != null)
                            {                                
                                modelessForm.ShowValueBOLD_Distinta();
                                // Metodo per restituire i valori dei parametri al DataGridView
                                ImportDataFromExcel import = new ImportDataFromExcel();
                                _table = import.ReadExcelToDataTable(_valueDistinta, path, 10, 1);
                                modelessForm.ShowDataGridView1();
                                // Chiama il metodo che riempie la ListBox con le Dimensioni dell'oggetto selezionato
                                _dimensionsList = GetParameters(uiapp, pickedObject);
                                modelessForm.ShowListBox1();
                                // Chiama il metodo che seleziona il parametro stringa della famiglia scelta
                                GetTypeParameterOfFamily(uiapp, pickedObject);
                                modelessForm.SetModifyPicture();
                            }
                            else
                            {
                                MessageBox.Show("Questo elemento non ha alcun parametro BOLD_Distinta");
                                modelessForm.CleanAll();
                            }                            
                            break;
                        }
                    case RequestId.Exp:
                        {
                            // Metodo per esportare i parametri dell'elemento in un foglio Excel
                            modelessForm = App.thisApp.RetriveForm();
                            _valueSelectedComboBox = modelessForm.ValueSelectedComboBox();
                            if(count == 1)
                            {
                                _valueActive = _valueDistinta;
                            }
                            else if(count == 2)
                            {
                                _valueActive = _valueSelectedComboBox;
                            }                            
                            ImportDataFromExcel import = new ImportDataFromExcel();
                            DataTable tableFromComboBox = import.ReadExcelToDataTable(_valueActive, path, 10, 1);

                            ExportDataToExcel exp = new ExportDataToExcel();
                            bool risp = exp.GetExportDataToExcel(tableFromComboBox, _valueActive, path2);
                            if(risp == true)
                            {
                                MessageBox.Show("File salvato correttamente.");
                            }
                            else
                            {
                                MessageBox.Show("Il file non è stato salvato. Verifica l'errore.", "ERRORE!");
                            }
                           
                            break;
                        }
                    case RequestId.ComboBox:
                        {
                            count = 2;
                            break;
                        }
                    default:
                        {
                            // Una sorta di avviso qui dovrebbe informarci di una richiesta imprevista
                            break;
                        }
                }
            }
            finally
            {
                App.thisApp.WakeFormUp();
                App.thisApp.ShowFormTop();
            }

            return;
        }

        /// <summary>
        ///   La subroutine che cattura un singolo oggetto
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>m>
        /// 
        private Reference PickObject(UIApplication uiapp)
        {
            // Ottieni la vista selezionata
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection choices = uidoc.Selection;

            // Ottieni il singolo elemento
            Reference pickedObj = uidoc.Selection.PickObject(ObjectType.Element);
            return pickedObj;
        }

        /// <summary>
        ///   La subroutine di selezione di un elemento che torna il valore stringa di BOLD_Distinta
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>m>
        /// 
        private string PickBOLD_distinta(UIApplication uiapp, Reference reference)
        {
            // Chiamo la vista attiva e seleziono gli elementi che mi servono
            UIDocument uidoc = uiapp.ActiveUIDocument;
            ElementId eleId = reference.ElementId;
            Element ele = uidoc.Document.GetElement(eleId);

            // Restituisce il valore del parametro
            if (ele.LookupParameter("BOLD_Distinta") != null)
            {
                Parameter pardistinta = ele.LookupParameter("BOLD_Distinta");
                return pardistinta.AsString();
            }
            else
            {
                return "Nessun valore";
            }            
        }

        /// <summary>
        ///   La subroutine che restituisce i valori della LISTBOX
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>m>
        /// 
        private ArrayList GetParameters(UIApplication uiapp, Reference reference)
        {
            // Chiamo la vista attiva e seleziono gli elementi che mi servono
            UIDocument uidoc = uiapp.ActiveUIDocument;
            ElementId eleId = reference.ElementId;
            Element ele = uidoc.Document.GetElement(eleId);
            return _dimensionsList = GetDimensionsList(ele, reference);
        }

        /// <summary>
        ///   La subroutine che cattura i parametri dimensionali dell'oggetto selezionato
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>m>
        /// 
        private ArrayList GetDimensionsList(Element ele, Reference reference)
        {
            // GetOrderedParameters method -- Ottiene i parametri visibili in ordine.
            IList<Parameter> parIList = ele.GetOrderedParameters();

            // Lista dei nomi dei parametri contenuti nella Partizione Dimensioni
            List<string> parametriDimensionali = new List<string> {
                    "Lunghezza",
                    "Area",
                    "Volume",
                    "CellH",
                    "CellH2",
                    "CellL",
                    "CellDxH",
                    "CellSxH"
                };

            // Se i parametri dimensionali sono presenti, ricava i loro valori e li aggiunge alla lista, 
            // altrimenti scrive una stringa vuota

            foreach (Parameter par in parIList)
            {
                foreach (string str in parametriDimensionali)
                {
                    if (par.Definition.Name == str)
                    {
                        _dimensionsList.Add(par.Definition.Name + ":");
                        if (par.AsValueString() == null)
                        {
                            _dimensionsList.Add("-----");
                        }
                        else
                        {
                            _dimensionsList.Add(par.AsValueString());
                        }
                        _dimensionsList.Add("");
                    }
                }
            }
            return _dimensionsList;
        }


        /// <summary>
        ///   La subroutine che cattura il parametro TIPO della FAMIGLIA scelta in formato stringa
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>m>
        /// 
        private void GetTypeParameterOfFamily(UIApplication uiapp, Reference reference)
        {
            // Chiamo la vista attiva e seleziono gli elementi che mi servono
            UIDocument uidoc = uiapp.ActiveUIDocument;
            ElementId eleId = reference.ElementId;
            Element ele = uidoc.Document.GetElement(eleId);
            _familyType = GetTypeParameterElementType(uiapp, ele);
        }

        /// <summary>
        /// Restituisce tutti i valori dei parametri ritenuti rilevanti per l'elemento dato sotto forma di ArrayList.
        /// </summary>
        private string GetTypeParameterElementType(UIApplication uiapp, Element e)
        {
            ParameterSet ps = e.Parameters;

            string singleString = null;
            foreach (Parameter param in ps)
            {
                if (param.Definition.Name == "Tipo")
                    singleString = param.AsValueString();
            }
            return singleString;
        }

    }  // class

}  // namespace

