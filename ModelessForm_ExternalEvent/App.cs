#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop;
using System;
using System.Collections.Generic;

#endregion

namespace ModelessForm_ExternalEvent
{
    public class App : IExternalApplication
    {
        /// <summary>
        /// Implementa l'interfaccia del componente aggiuntivo Revit IExternalApplication
        /// </summary>
        /// 
        
        // Instanza della classe 
        internal static App thisApp = null;
        
        // Instanza della finestra di dialogo non modale
        private ModelessForm m_MyForm;

        #region IExternalApplication Members
        /// <summary>
        /// Implementa l'evento OnShutDown
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        
        public Result OnShutdown(UIControlledApplication application)
        {
            if (m_MyForm != null && m_MyForm.Visible)
            {
                m_MyForm.Close();
            }

            return Result.Succeeded;
        }

        /// <summary>
        /// Implementa l'evento OnStartup
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public Result OnStartup(UIControlledApplication application)
        {
            m_MyForm = null;   // nessun dialogo ancora necessario; il comando lo porterà

            thisApp = this;  // accesso statico a questa istanza dell'applicazione


            return Result.Succeeded;
        }

        /// <summary>
        ///   Questo metodo crea e mostra una finestra di dialogo non modale, a meno che non esista già.
        /// </summary>
        /// <remarks>
        ///   Il comando esterno lo richiama su richiesta dell'utente finale
        /// </remarks>
        /// 
        public void ShowForm(UIApplication uiapp)
        {
            // If we do not have a dialog yet, create and show it
            if (m_MyForm == null || m_MyForm.IsDisposed)
            {
                
                // Un nuovo gestore per gestire l'invio delle richieste tramite la finestra di dialogo
                RequestHandler handler = new RequestHandler();

                // Evento esterno per la finestra di dialogo da utilizzare (per inviare richieste)
                ExternalEvent exEvent = ExternalEvent.Create(handler);

                // Diamo gli oggetti alla nuova finestra di dialogo. 
                // La finestra di dialogo diventa il proprietario responsabile della loro disposizione, alla fine.
                m_MyForm = new ModelessForm(exEvent, handler);
                m_MyForm.Show();
                //m_MyForm.TopMost = true;
            }
        }

        /// <summary>
        ///   Restituisce la finestra di dialogo.
        /// </summary>
        /// 
        public ModelessForm RetriveForm()
        {
            return m_MyForm;            
        }

        /// <summary>
        ///   Riattivare la finestra di dialogo dal suo stato di attesa.
        /// </summary>
        /// 
        public void WakeFormUp()
        {
            if (m_MyForm != null)
            {
                m_MyForm.WakeUp();
            }
        }
        #endregion
    }
}
