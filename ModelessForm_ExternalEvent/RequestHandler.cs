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
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ModelessForm_ExternalEvent.DataFromExcel;

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

        // Il valore dell'Unit Identifier
        private string _unitIdentifier;

        // Il valore delPanel TypeIdentifier
        private string _panelTypeIdentifier;

        // Il tipo della famiglia in formato stringa
        private string _familyType;

        // Il valore attivo nella pagina
        int count = 0;

        // La lista di stringhe che restituirà i valori da inserire in ListBox
        private ArrayList _dimensionsList;

        // Un instanza della finestra di dialogo
        private ModelessForm modelessForm;

        // Un instanza di DataTable per riempire il DataGridView
        private DataTable _table;

        // Percorso file Excel con tutte le Distinte
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
        public string GetUnitIdentifier
        {
            get { return _unitIdentifier; }
        }

        /// <summary>
        /// Proprietà pubblica per accedere al valore della richiesta corrente
        /// </summary>
        public string GetPanelTypeIdentifier
        {
            get { return _panelTypeIdentifier; }
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
                                // Cancello tutti i valori presenti nell'ArrayList
                                _dimensionsList.Clear();
                                // Imposta il valore della Distinta per la Form
                                modelessForm.valueDistintaFromCaptureButton();
                                // Imposta il valore dello UnitIdentifier per la Form
                                PickUnitIdentifier(uiapp, pickedObject);
                                modelessForm.valueUnitIdentifierFromCaptureButton();
                                // Imposta il valore dello UnitIdentifier per la Form
                                PickPanelTypeIdentifier(uiapp, pickedObject);
                                modelessForm.valuePanelTypeIdentifierFromCaptureButton();
                                // Chiama il metodo che seleziona il parametro stringa della famiglia scelta e riempie il PictureBox
                                GetTypeParameterOfFamily(uiapp, pickedObject);
                                modelessForm.SetModifyPicture();
                                // Chiama il metodo che seleziona le Dimensioni dell'oggetto selezionato e riempie la ListBox
                                _dimensionsList = GetParameters(uiapp, pickedObject);
                                modelessForm.ShowListBox1();
                                // Chiama il metodo che seleziona la Distinta corretta nella ComboBox e riempie la DataGrid
                                modelessForm.SetComboBox(_valueDistinta);                                
                            }
                            else
                            {
                                MessageBox.Show("Questo elemento non ha un valore BOLD_Distinta. Aggiungilo.");
                                modelessForm.CleanAll();
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
        ///   La subroutine di selezione di un elemento che torna il valore stringa dell'Unit Identifier
        /// </summary>
        /// <remarks>
        /// Il valore dell'UnitIdentifier e' composto dai Parametri dell'elemento UI-ItemCategory, 
        /// UI-ProjectAbbreviation, UI-Quadrant, UI-FloorNumber e UI-UnitNumber
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>m>
        /// 
        private void PickUnitIdentifier(UIApplication uiapp, Reference reference)
        {
            // Chiamo la vista attiva e seleziono gli elementi che mi servono
            UIDocument uidoc = uiapp.ActiveUIDocument;
            ElementId eleId = reference.ElementId;
            Element ele = uidoc.Document.GetElement(eleId);
            ElementType eleType = uidoc.Document.GetElement(ele.GetTypeId()) as ElementType;

            // Restituisce il valore del parametro UI-ItemCategory  
            string strUIItemCategory = "";   
            if (eleType.LookupParameter("UI-ItemCategory") != null)
            {
                Parameter par = eleType.LookupParameter("UI-ItemCategory");
                strUIItemCategory = par.AsString();
            }
            else { strUIItemCategory = "xxx"; }

            // Restituisce il valore del parametro UI-ProjectAbbreviation  
            string strUIProjectAbbreviation = "";
            if (eleType.LookupParameter("UI-ProjectAbbreviation") != null)
            {
                Parameter par = eleType.LookupParameter("UI-ProjectAbbreviation");
                strUIProjectAbbreviation = par.AsString();
            }
            else { strUIProjectAbbreviation = "xxx"; }

            // Restituisce il valore del parametro UI-Quadrant
            string strUIQuadrant = "";
            if (ele.LookupParameter("UI-Quadrant") != null)
            {
                Parameter par = ele.LookupParameter("UI-Quadrant");
                strUIQuadrant = par.AsString();
            }
            else { strUIQuadrant = "xx"; }

            // Restituisce il valore del parametro UI-FloorNumber
            string strUIFloorNumber = "";
            if (ele.LookupParameter("UI-FloorNumber") != null)
            {
                Parameter par = ele.LookupParameter("UI-FloorNumber");
                strUIFloorNumber = par.AsString();
            }
            else { strUIFloorNumber = "xx"; }

            // Restituisce il valore del parametro UI-UnitNumber
            string strUIUnitNumber = "";
            if (ele.LookupParameter("UI-UnitNumber") != null)
            {
                Parameter par = ele.LookupParameter("UI-UnitNumber");
                strUIUnitNumber = par.AsString();
            }
            else { strUIUnitNumber = "xxx"; }

            // Imposta la stringa finale
            _unitIdentifier = 
                strUIItemCategory + "-" +
                strUIProjectAbbreviation + "-" +
                strUIQuadrant + "-" +
                strUIFloorNumber + "-" +
                strUIUnitNumber;
        }

        /// <summary>
        ///   La subroutine di selezione di un elemento che torna il valore stringa del Panel Type Identifier
        /// </summary>
        /// <remarks>
        /// Il valore del Panel Type Identifier e' composto dai Parametri dell'elemento PNT-ItemCategory, 
        /// PNT-ProjectAbbreviation, PNT-WallType e PNT-PanelType        
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>m>
        /// 
        private void PickPanelTypeIdentifier(UIApplication uiapp, Reference reference)
        {
            // Chiamo la vista attiva e seleziono gli elementi che mi servono
            UIDocument uidoc = uiapp.ActiveUIDocument;
            ElementId eleId = reference.ElementId;
            Element ele = uidoc.Document.GetElement(eleId);
            ElementType eleType = uidoc.Document.GetElement(ele.GetTypeId()) as ElementType;

            // Restituisce il valore del parametro PNT-ItemCategory
            string strPNTItemCategory = "";
            if (eleType.LookupParameter("PNT-ItemCategory") != null)
            {
                Parameter par = eleType.LookupParameter("PNT-ItemCategory");
                strPNTItemCategory = par.AsString();
            }
            else { strPNTItemCategory = "xxx"; }

            // Restituisce il valore del parametro PNT-ProjectAbbreviation
            string strPNTProjectAbbreviation = "";
            if (eleType.LookupParameter("PNT-ProjectAbbreviation") != null)
            {
                Parameter par = eleType.LookupParameter("PNT-ProjectAbbreviation");
                strPNTProjectAbbreviation = par.AsString();
            }
            else { strPNTProjectAbbreviation = "xxx"; }

            // Restituisce il valore del parametro PNT-WallType
            string strPNTWallType = "";
            if (eleType.LookupParameter("PNT-WallType") != null)
            {
                Parameter par = eleType.LookupParameter("PNT-WallType");
                strPNTWallType = par.AsString();
            }
            else { strPNTWallType = "xxxx"; }

            // Restituisce il valore del parametro PNT-PanelType
            string strPNTPanelType = "";
            if (ele.LookupParameter("PNT-PanelType") != null)
            {
                Parameter par = ele.LookupParameter("PNT-PanelType");
                strPNTPanelType = par.AsString();
            }
            else { strPNTPanelType = "xx"; }

            _panelTypeIdentifier =
                strPNTItemCategory + "-" +
                strPNTProjectAbbreviation + "-" +
                strPNTWallType + "-" +
                strPNTPanelType;
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
            return _dimensionsList = GetDimensionsList(uiapp, ele, reference);
        }

        /// <summary>
        ///   La subroutine che cattura i parametri dimensionali dell'oggetto selezionato
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>m>
        /// 
        private ArrayList GetDimensionsList(UIApplication uiapp, Element ele, Reference reference)
        {
            // Ottiene tutti i Paramtetri contenuti nei singoli Gruppi di Parametri
            Dictionary<BuiltInParameterGroup, List<BuiltInParameter>> dict = GroupBuiltInParameters(ele);
            // Estrae i parametri che appartengono a Dimensions
            List<Parameter> pList = ParametersInGroup(ele, BuiltInParameterGroup.PG_GEOMETRY);

            // Cattura i due parametri delle Type Properties
            List<Parameter> pListTypeProperties = GetDimensionsTypeProperties(uiapp, reference);
            foreach (Parameter item in pListTypeProperties)
            {
                pList.Add(item);
            }

            // Li ordina in modo crescente
            List<Parameter> pListOrdered = pList.OrderBy(x => x.Definition.Name).ToList();

            // Se i parametri dimensionali sono presenti, ricava i loro valori e li aggiunge alla lista, 
            // altrimenti scrive una stringa vuota
            string ctrl = "";
            foreach (Parameter par in pListOrdered)
            {
                // Se il nome del parametro è già presente o uguale a BOLD_Distinta, salta a quello dopo
                if (par.Definition.Name != ctrl && par.Definition.Name != "BOLD_Distinta")
                {
                    _dimensionsList.Add(par.Definition.Name + ":");
                    if (par.AsValueString() == null)
                    {
                        _dimensionsList.Add("-----");
                    }
                    else if (par.Definition.Name == "Area")
                    {
                        // Converte il valore in modo che sia corretto
                        double MyString = par.AsDouble();
                        double newvalueMyString = UnitUtils.ConvertFromInternalUnits(MyString, DisplayUnitType.DUT_SQUARE_METERS);
                        _dimensionsList.Add(newvalueMyString + " m^2");
                    }
                    else
                    {
                        _dimensionsList.Add(par.AsValueString());
                    }
                    _dimensionsList.Add("");

                    ctrl = par.Definition.Name;
                }
                else { continue; }
            }
            return _dimensionsList;
        }

        private static Dictionary<BuiltInParameterGroup, List<BuiltInParameter>> GroupBuiltInParameters(Element e)
        {
            Dictionary<BuiltInParameterGroup, List<BuiltInParameter>> dict =
                new Dictionary<BuiltInParameterGroup, List<BuiltInParameter>>();

            foreach (Parameter p in e.Parameters)
            {
                if (p.IsShared)
                    continue;

                if (p.Definition == null)
                    break;

                if (!dict.ContainsKey(p.Definition.ParameterGroup))
                {
                    dict.Add(p.Definition.ParameterGroup, new List<BuiltInParameter>());
                }

                BuiltInParameter biParam = (p.Definition as InternalDefinition).BuiltInParameter;
                if (!dict[p.Definition.ParameterGroup].Contains(biParam))
                {
                    dict[p.Definition.ParameterGroup].Add(biParam);
                }
            }
            return dict;
        }

        private static List<Parameter> ParametersInGroup(Element e, BuiltInParameterGroup g)
        {
            Dictionary<BuiltInParameterGroup, List<Parameter>> groupDict = GroupParameters(e);
            return groupDict.Keys.Contains(g) ? groupDict[g] : null;
        }

        private static Dictionary<BuiltInParameterGroup, List<Parameter>> GroupParameters(Element e)
        {
            Dictionary<BuiltInParameterGroup, List<Parameter>> dict =
                new Dictionary<BuiltInParameterGroup, List<Parameter>>();

            foreach (Parameter p in e.Parameters)
            {
                if (!dict.ContainsKey(p.Definition.ParameterGroup))
                {
                    dict.Add(p.Definition.ParameterGroup, new List<Parameter>());
                }

                dict[p.Definition.ParameterGroup].Add(p);
            }

            return dict;
        }

        /// <summary>
        ///   La subroutine che cattura il parametro TYPE PROPERTIES della FAMIGLIA scelta in formato lista di parametri
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>
        private static List<Parameter> GetDimensionsTypeProperties(UIApplication uiapp, Reference reference)
        {
            List<Parameter> listParameter = new List<Parameter>();

            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            ElementId eleId = reference.ElementId;
            Element ele = doc.GetElement(eleId);
            ElementType eleType = doc.GetElement(ele.GetTypeId()) as ElementType;
            ParameterSet parameterSet = eleType.Parameters;

            foreach (Parameter par in parameterSet)
            {
                if(par.Definition.Name == "CellSp" || par.Definition.Name == "DistanceLevel")
                {
                    listParameter.Add(par);
                }
            }
            return listParameter;
        }


        /// <summary>
        ///   La subroutine che cattura il parametro TIPO della FAMIGLIA scelta in formato stringa
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="uiapp">L'oggetto Applicazione di Revit</param>
        private void GetTypeParameterOfFamily(UIApplication uiapp, Reference reference)
        {
            // Chiamo la vista attiva e seleziono gli elementi che mi servono
            UIDocument uidoc = uiapp.ActiveUIDocument;
            ElementId eleId = reference.ElementId;
            Element ele = uidoc.Document.GetElement(eleId);
            _familyType = GetTypeParameterElementType(uiapp, ele);
        }

        /// <summary>
        /// Restituisce il valore in formato stringa della FAMIGLIA
        /// </summary>
        private string GetTypeParameterElementType(UIApplication uiapp, Element e)
        {
            ParameterSet ps = e.Parameters;

            string singleString = null;
            foreach (Parameter param in ps)
            {
                if (param.Definition.Name == "Family" || param.Definition.Name == "Famiglia")
                    singleString = param.AsValueString();
            }
            return singleString;
        }

    }  // class

}  // namespace

