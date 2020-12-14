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
using System.Drawing;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ModelessForm_ExternalEvent.ToExcel;

namespace ModelessForm_ExternalEvent
{
    /// <summary>
    ///   Una classe con metodi per eseguire le richieste effettuate dall'utente della finestra di dialogo.
    /// </summary>
    /// 
    public class RequestHandler : IExternalEventHandler  // Un'istanza di una classe che implementa questa interfaccia verrà registrata prima con Revit e ogni volta che viene generato l'evento esterno corrispondente, verrà richiamato il metodo Execute di questa interfaccia.
    {
        // Il valore dell'ultima richiesta effettuata dal modulo non modale
        private Request m_request = new Request();

        // Il Riferimento all'elemento selezionato
        Reference pickedObject;

        // Il valore restituito dal metodo per riempire il ListBox
        private ArrayList _result;

        // Il valore restituito dal metodo per riempire il DataGridView
        private List<ElementData> _parametersElement;

        // Un instanza della finestra di dialogo
        private ModelessForm modelessForm;
        
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
        public ArrayList GetStringa
        {
            get { return _result; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public List<ElementData> ElementParameters
        {
            get { return _parametersElement; }
        }


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
                            // Metodo per seleziona un oggetto
                            pickedObject = PickObject(uiapp);
                            // Metodo per restituire il singolo parametro alla ListBox
                            _result = PickSingleObject(uiapp, pickedObject);
                            modelessForm = App.thisApp.RetriveForm();
                            modelessForm.ShowListBox1();
                            // Metodo per restituire i valori dei parametri al DataGridView
                            _parametersElement = GetSingleElement(uiapp, pickedObject);
                            modelessForm.ShowDataGridView1();
                            break;
                        }
                    case RequestId.Exp:
                        {
                            // Metodo per esportare i parametri dell'elemento in un foglio Excel
                            ExportDataToExcel exp = new ExportDataToExcel();
                            exp.GetExportDataToExcel(uiapp, pickedObject);
                            break;
                        }
                    case RequestId.Imp:
                        {
                            // Metodo per importare i parametri dell'elemento da un foglio Excel

                            break;
                        }
                    default:
                        {
                            // some kind of a warning here should
                            // notify us about an unexpected request 
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
            // Get the selected view
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection choices = uidoc.Selection;

            // Get the single element
            Reference pickedObj = uidoc.Selection.PickObject(ObjectType.Element);
            return pickedObj;
        }

        /// <summary>
        ///   La subroutine di selezione di molti elementi
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>m>
        /// 
        private void PickMultipleObject(UIApplication uiapp)
        {
            UIDocument uidoc = uiapp.ActiveUIDocument;

            // Verifica se c'è qualcosa di selezionato nella view attiva

            if ((uidoc != null) && (uidoc.Selection != null))
            {
                ICollection<ElementId> selElements = uidoc.Selection.GetElementIds();
                if (selElements.Count > 0)
                {
                    // ...                   
                }
            }
        }

        /// <summary>
        ///   La subroutine di selezione di un elemento da mostrare in una ListBox
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>m>
        /// 
        private ArrayList PickSingleObject(UIApplication uiapp, Reference reference)
        {
            // l'ArrayList da restituire
            ArrayList stringhe = new ArrayList();

            // Chiamo la vista attiva e seleziono gli elementi che mi servono
            UIDocument uidoc = uiapp.ActiveUIDocument;
            ElementId eleId = reference.ElementId;
            Element ele = uidoc.Document.GetElement(eleId);

            // Prende il valore del parametro
            if (ele.LookupParameter("BOLD_Distinta") != null)
            {
                Parameter pardistinta = ele.LookupParameter("BOLD_Distinta");
                //MessageBox.Show($"BOLD_Distinta: " + pardistinta.AsString(), "Parameter: ");
                stringhe.Add($"BOLD_Distinta: " + pardistinta.AsString());
            }
            else
            {
                stringhe.Add($"BOLD_Distinta: " + "Nessun valore");
            }
            return stringhe;
        }

        /// <summary>
        ///   La subroutine di selezione di un elemento da mostrare in una DataGridView
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>m>
        /// 
        private List<ElementData> GetSingleElement(UIApplication uiapp, Reference reference)
        {
            string valueParameter = null;
            List<ElementData> data = new List<ElementData>();


            // Chiama la vista attiva e seleziona gli elementi che mi servono
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            ElementId eleId = pickedObject.ElementId;
            Element ele = uidoc.Document.GetElement(eleId);
            ElementId eleTypeId = ele.GetTypeId();
            ElementType eleType = doc.GetElement(eleTypeId) as ElementType;

            // Prende il valore del parametro
            if (ele.LookupParameter("BOLD_Distinta") != null)
            {
                Parameter pardistinta = ele.LookupParameter("BOLD_Distinta");
                //MessageBox.Show($"BOLD_Distinta: " + pardistinta.AsString(), "Parameter: ");
                valueParameter = pardistinta.AsString();
            }
            else
            {
                valueParameter = "Nessun valore";
            }

            // Riempie la lista con i dati dell'elemento
            data.Add(new ElementData(eleId, valueParameter, ele.Name, ele.Category.Name,
                eleType.FamilyName, eleType.Name, doc.PathName));

            return data;
        }


    }  // class

}  // namespace

