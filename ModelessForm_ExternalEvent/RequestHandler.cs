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
using ModelessForm_ExternalEvent.FromToExcel;

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
        private string _result;

        // La lista di stringhe che restituirà i valori da inserire in ListBox
        private List<string> _logActions;

        // Il valore restituito dal metodo per riempire il DataGridView
        private List<ElementData> _parametersElement;

        // Un instanza della finestra di dialogo
        private ModelessForm modelessForm;

        // Un instanza di DataTable
        private DataTable _table;

        // Percorso file Excel con tutte le Distinte
        string path = "C:\\DatiLDB\\ExcelData\\AbacoCells.xlsx";
        private List<string> _listXlSh;
        #endregion

        #region class public property
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
        public string GetStringa
        {
            get { return _result; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere ai valori della ListBox
        /// </summary>
        public List<string> GetStringhe
        {
            get { return _logActions; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere ai valori della DataTable
        /// </summary>
        public DataTable GetTable
        {
            get { return _table; }
        }

        ///// <summary>
        ///// Proprietà pubblica per accedere al valore della richiesta corrente
        ///// </summary>
        //public List<ElementData> ElementParameters
        //{
        //    get { return _parametersElement; }
        //}

        public List<string> Strings
        {
            get { return _listXlSh; }
        }
        #endregion

        #region class public method
        /// <summary>
        /// Costruttore di default di RequestHandler
        /// </summary>
        public RequestHandler()
        {
            // Costruisce i membri dei dati per le proprietà
            _logActions = new List<string>();
            _listXlSh = new List<string>();
            _parametersElement = new List<ElementData>();
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
                            // Metodo che seleziona un oggetto
                            pickedObject = PickObject(uiapp);
                            // Metodo che restituisce il singolo parametro alla ListBox
                            _result = PickBOLD_distinta(uiapp, pickedObject);
                            if(_result != "Nessun valore" && _result != null)
                            {
                                modelessForm = App.thisApp.RetriveForm();
                                modelessForm.ShowValueBOLD_Distinta();
                                // Metodo per restituire i valori dei parametri al DataGridView
                                ImportDataFromExcel import = new ImportDataFromExcel();
                                _table = import.ReadExcelToDataTable(_result, path, 9, 1);
                                modelessForm.ShowDataGridView1();
                            }
                            else
                            {
                                MessageBox.Show("Questo elemento non ha alcun parametro BOLD_Distinta");
                            }
                            break;
                        }
                    case RequestId.Exp:
                        {
                            // Metodo per esportare i parametri dell'elemento in un foglio Excel
                            if(pickedObject != null)
                            {
                                //ExportDataToExcel exp = new ExportDataToExcel();
                                //exp.GetExportDataToExcel(uiapp, pickedObject);
                            }                            
                            break;
                        }
                    case RequestId.Imp:
                        {
                            // Metodo per importare i parametri dell'elemento da un foglio Excel
                            if (pickedObject != null)
                            {
                                //ImportDataFromExcel imp = new ImportDataFromExcel();
                                //_listXlSh = imp.XlSheets(path);
                            }
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
        ///   La subroutine di selezione di un elemento che mi torna il valore di BOLD_Distinta
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>m>
        /// 
        private string PickBOLD_distinta(UIApplication uiapp, Reference reference)
        {
            // l'ArrayList da restituire
            ArrayList stringhe = new ArrayList();

            // Chiamo la vista attiva e seleziono gli elementi che mi servono
            UIDocument uidoc = uiapp.ActiveUIDocument;
            ElementId eleId = reference.ElementId;
            Element ele = uidoc.Document.GetElement(eleId);

            // Restituisce il valore del parametro
            if (ele.LookupParameter("BOLD_Distinta") != null)
            {
                Parameter pardistinta = ele.LookupParameter("BOLD_Distinta");
                _logActions.Add("- Distinta selezionata: " + pardistinta.AsString());                
                return pardistinta.AsString();
            }
            else
            {
                return "Nessun valore";
            }            
        }

        /// <summary>
        ///   La subroutine di selezione di un elemento da mostrare in una DataGridView
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>m>
        ///// 
        //private List<ElementData> GetSingleElement(UIApplication uiapp, Reference reference)
        //{
        //    string valueParameter = null;
        //    List<ElementData> data = new List<ElementData>();

        //    // Chiama la vista attiva e seleziona gli elementi che mi servono
        //    UIDocument uidoc = uiapp.ActiveUIDocument;
        //    Document doc = uidoc.Document;
        //    ElementId eleId = pickedObject.ElementId;
        //    Element ele = uidoc.Document.GetElement(eleId);
        //    ElementId eleTypeId = ele.GetTypeId();
        //    ElementType eleType = doc.GetElement(eleTypeId) as ElementType;

        //    // Prende il valore del parametro
        //    if (ele.LookupParameter("BOLD_Distinta") != null)
        //    {
        //        Parameter pardistinta = ele.LookupParameter("BOLD_Distinta");
        //        valueParameter = pardistinta.AsString();
        //    }
        //    else
        //    {
        //        valueParameter = "Nessun valore";
        //    }

        //    // Riempie la lista con i dati dell'elemento
        //    data.Add(new ElementData(eleId, valueParameter, ele.Name, ele.Category.Name,
        //        eleType.FamilyName, eleType.Name, doc.PathName));
        //    _logActions.Add("- DataGridView mostra le proprietà dell'oggetto selezionato");

        //    return data;
        //}


    }  // class

}  // namespace

