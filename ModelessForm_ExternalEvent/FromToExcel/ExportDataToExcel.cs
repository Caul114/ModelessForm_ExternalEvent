using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using X = Microsoft.Office.Interop.Excel;

namespace ModelessForm_ExternalEvent.ToExcel
{
    public class ExportDataToExcel
    {
        public void GetExportDataToExcel(UIApplication uiapp, Reference reference)
        {
            string valueParameter = null;
            List<ElementData> data = new List<ElementData>();

            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;


            // Chiama la vista attiva e seleziona gli elementi che mi servono
            ElementId eleId = reference.ElementId;
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


            // Launch Excel

            X.Application excel = new X.Application(); // 2020
            if (null == excel)
            {
                Util.ErrorMsg("Failed to get or start Excel.");
            }
            excel.Visible = true;
            X.Workbook workbook = excel.Workbooks.Add(Missing.Value);
            X.Worksheet worksheet;
            //while( 1 < workbook.Sheets.Count )
            //{
            //  worksheet = workbook.Sheets.get_Item( 0 ) as X.Worksheet;
            //  worksheet.Delete();
            //}
            worksheet = excel.ActiveSheet as X.Worksheet;
            worksheet.Name = valueParameter;
            worksheet.Cells[1, 1] = "ID";
            worksheet.Cells[1, 2] = "Parameter";
            worksheet.Cells[1, 3] = "Instance";
            worksheet.Cells[1, 4] = "Category";
            worksheet.Cells[1, 5] = "Family";
            worksheet.Cells[1, 6] = "Type";
            worksheet.Cells[1, 7] = "Path";
            worksheet.get_Range("A1", "Z1").Font.Bold = true;

            //List<Element> elems = Utils.GetTargetInstances(doc,
            //  CreateAndBindSharedParam.Target);

            // Get Shared param Guid

            //Guid paramGuid = Utils.SharedParamGUID(app,
            //  Constants.SharedParamsGroupAPI,
            //  Constants.SharedParamsDefFireRating);

            //if (paramGuid.Equals(Guid.Empty))
            //{
            //    Utils.ErrorMsg("No Shared param found in the file - aborting...");
            //    return Result.Failed;
            //}

            // Loop through all elements and export each to an Excel row


            int row = 2;
            foreach (var item in data)
            {
                // Id: ElementId -> int
                worksheet.Cells[row, 1] = item.Id.IntegerValue; // ID

                // Parameter
                worksheet.Cells[row, 2] = item.Parameter;

                // 
                worksheet.Cells[row, 3] = item.Instance;

                // 
                worksheet.Cells[row, 4] = item.Category;

                // 
                worksheet.Cells[row, 5] = item.Family;

                // 
                worksheet.Cells[row, 6] = item.Type;

                // 
                worksheet.Cells[row, 7] = item.Document;

                ++row;
            }
        }
    }
}
