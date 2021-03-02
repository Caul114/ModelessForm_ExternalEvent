using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelessForm_ExternalEvent.Config
{
    public partial class SetProjectName : Form
    {
        #region Private data members
        // Istanza della classe
        internal static SetProjectName thisApp = null;

        // Nuovo nome del Progetto
        private string _newProjectName = string.Empty;

        // Instanza una classe della Form Principale
        private ModelessForm _modelessForm;
        #endregion

        #region Class public property
        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public string NewProjectName
        {
            get { return _newProjectName; }
        }
        #endregion
        public SetProjectName()
        {
            InitializeComponent();

            thisApp = this;
            GetProjectName();
        }

        /// <summary>
        ///   Ottiene il valore salvato nel nome del Progetto
        /// </summary>
        /// 
        private void GetProjectName()
        {
            // Chiama il metodo che ottine il nome salvato nel Progetto
            _modelessForm = App.thisApp.RetriveForm();
            _modelessForm.MakeRequest(RequestId.ProjectName);
        }

        /// <summary>
        ///   Ottiene il valore salvato nel nome del Progetto
        /// </summary>
        /// 
        public void FillProjectName(string name)
        {
            // Asswgna il valore salvato nela TextBox
            insertNameProjectTextBox.Text = name;
        }

        /// <summary>
        ///   Salva il nuovo valore nel progetto
        /// </summary>
        /// 
        private void saveButton_Click(object sender, EventArgs e)
        {
            _newProjectName = insertNameProjectTextBox.Text;

            // Chiama il metodo che imposta il nuovo nome del Progetto
            _modelessForm = App.thisApp.RetriveForm();
            _modelessForm.MakeRequest(RequestId.SetProjectName);
        }

        /// <summary>
        ///   Cancella le modifiche
        /// </summary>
        /// 
        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Chiama il metodo che chiude questa Form e riattiva la Form
            _modelessForm = App.thisApp.RetriveForm();
            _modelessForm.CloseSetProjectName();
        }

        /// <summary>
        ///   Rende nulla l'istanza di questa Form
        /// </summary>
        ///
        public void SetProjectNameNull()
        {
            thisApp = null;
        }
    }
}
