using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelessForm_ExternalEvent.ToExcel
{
    public class Util
    {
        public const string Caption = "Revit API BOLD";

        /// <summary>
        /// MessageBox wrapper for error message.
        /// </summary>
        public static void ErrorMsg(string msg)
        {
            Debug.WriteLine(msg);

            //WinForms.MessageBox.Show( msg, Caption, WinForms.MessageBoxButtons.OK, WinForms.MessageBoxIcon.Error );

            TaskDialog d = new TaskDialog(Caption);
            d.MainIcon = TaskDialogIcon.TaskDialogIconWarning;
            d.MainInstruction = msg;
            d.Show();
        }

    }
}
