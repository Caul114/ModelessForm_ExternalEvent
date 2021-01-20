using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModelessForm_ExternalEvent
{
    [Transaction(TransactionMode.ReadOnly)]
    public class CommandConfig : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;

            try
            {
                // External tool commands defined by add-ins are identified by the client id specified in 
                // the add-in manifest. It is also listed in the journal file when the command is launched manually.

                string name
                  = "BA2E663D-EFAF-4E11-B304-923314D8817D"; // --> Chiama l'Add-in PluginConfiguration

                RevitCommandId id_addin_external_tool_cmd
                  = RevitCommandId.LookupCommandId(
                    name);

                uiapp.PostCommand(id_addin_external_tool_cmd);

                return Result.Succeeded;

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }
    }
}
