#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

#endregion

namespace ModelessForm_ExternalEvent
{
    /// <summary>
    /// Implementa l'interfaccia del componente aggiuntivo Revit IExternalApplication
    /// </summary>
    /// 
    public class App : IExternalApplication
    {        
        // Instanza della classe 
        internal static App thisApp = null;
        
        // Instanza della finestra di dialogo non modale
        private ModelessForm m_MyForm;

        // Creo un gestore privato
        private RequestHandler _handler;

        // Creo un evento privato
        private ExternalEvent _exEvent;

        /// <summary>
        /// Propriet� pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public RequestHandler GetHandler
        {
            get { return _handler; }
        }

        /// <summary>
        /// Propriet� pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public ExternalEvent GetEvent
        {
            get { return _exEvent; }
        }

        #region IExternalApplication Members
        /// <summary>
        /// Implementa l'evento OnStartup
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public Result OnStartup(UIControlledApplication application)
        {
            m_MyForm = null;   // nessun dialogo ancora necessario; il comando lo porter�

            thisApp = this;  // accesso statico a questa istanza dell'applicazione

            // Metodo per aggiungere un Tab e un RibbonPanel
            RibbonPanel ribbonPanel = RibbonPanel(application);
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            // Creazione del Button da inserire nel Tab
            if(ribbonPanel.AddItem(
                new PushButtonData("DataCell", "DataCell", thisAssemblyPath, "ModelessForm_ExternalEvent.Command"))
                is PushButton button)
            {
                // ToolTip mostrato
                button.ToolTip = "Mostra i parametri delle finestre";
                // Icona del Button
                Uri uriImage = new Uri(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Bold Software\DataCell\Icon\revit_small.png");
                BitmapImage image = new BitmapImage(uriImage);
                button.LargeImage = image;
            };


            return Result.Succeeded;
        }

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
        ///   Questo metodo crea e mostra una finestra di dialogo non modale, a meno che non esista gi�.
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
               
                _handler = new RequestHandler();

                // Evento esterno per la finestra di dialogo da utilizzare (per inviare richieste)
                _exEvent = ExternalEvent.Create(_handler);

                // Diamo gli oggetti alla nuova finestra di dialogo. 
                // La finestra di dialogo diventa il proprietario responsabile della loro disposizione, alla fine.
                m_MyForm = new ModelessForm(_exEvent, _handler);
                m_MyForm.Show();
                m_MyForm.BringToFront();
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
        ///   Rende la finestra di dialogo secondaria
        /// </summary>
        /// 
        public void DontShowFormTop()
        {
            //m_MyForm.WindowState = FormWindowState.Minimized;
            m_MyForm.TopMost = false;
        }

        /// <summary>
        ///   Rende la finestra di dialogo primaria
        /// </summary>
        /// 
        public void ShowFormTop()
        {
            //m_MyForm.WindowState = FormWindowState.Normal;
            m_MyForm.TopMost = true;
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

        #region Ribbon Panel

        public RibbonPanel RibbonPanel(UIControlledApplication uiapp)
        {
            // Nome del Tab
            string tab = "BOLD";

            // Dichiara e inizializza un RibbonPanel vuoto
            RibbonPanel ribbonPanel = null;

            // Prova a creare un Ribbon Tab
            try
            {
                uiapp.CreateRibbonTab(tab);
            }
            catch (Exception ex)
            {
                Utils.HandleError(ex);
            }

            // Prova a creare un RibbonPanel
            try
            {
                RibbonPanel panel = uiapp.CreateRibbonPanel(tab, "Utilities");
            }
            catch (Exception ex)
            {
                Utils.HandleError(ex);
            }

            // Verifica se il tab del Panel esiste gia'
            List<RibbonPanel> panels = uiapp.GetRibbonPanels(tab);
            foreach (RibbonPanel p in panels.Where(x => x.Name == "Utilities"))
            {
                ribbonPanel = p;
            }

            return ribbonPanel;
        }

        #endregion


    }
}
