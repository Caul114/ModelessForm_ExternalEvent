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

        // Il valore restituito dall'operazione
        private ArrayList _result;

        // Un instanza della finestra di dialogo
        private ModelessForm modelessForm;
        
        /// <summary>
        /// Una proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public Request Request
        {
            get { return m_request; }
        }

        public ArrayList Stringa
        {
            get { return _result; }
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
                            _result = PickSingleObject(uiapp);
                            modelessForm = App.thisApp.RetriveForm();
                            modelessForm.ShowListBox1();
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
        ///   La subroutine di modifica della porta principale - chiamata da ogni richiesta
        /// </summary>
        /// <remarks>
        ///   Cerca tutte le porte nella selezione corrente e se le trova applica ad esse l'operazione richiesta
        /// </remarks>
        /// <param name="uiapp">The Revit application object</param>
        /// <param name="text">Didascalia della transazione per l'operazione.</param>
        /// <param name="operation">Un delegato per eseguire l'operazione su un'istanza di una porta.</param>
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

        private ArrayList PickSingleObject(UIApplication uiapp)
        {
            ArrayList stringhe = new ArrayList();
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Selection choices = uidoc.Selection;

            // Verifica se c'è qualcosa di selezionato nella view attiva

            if ((uidoc != null) && (choices != null))
            {
                Reference pickedObj = uidoc.Selection.PickObject(ObjectType.Element);
                ElementId eleId = pickedObj.ElementId;
                Element ele = uidoc.Document.GetElement(eleId);

                if (pickedObj != null)
                {
                    Parameter pardistinta = ele.LookupParameter("BOLD_Distinta");
                    //MessageBox.Show($"BOLD_Distinta: " + pardistinta.AsString(), "Parameter: ");
                    stringhe.Add($"BOLD_Distinta: " + pardistinta.AsString());
                }
            }

            return stringhe;


        }
    }  // class

}  // namespace

