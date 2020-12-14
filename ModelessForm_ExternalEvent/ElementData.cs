using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelessForm_ExternalEvent
{
    public class ElementData
    {
        ElementId _id;
        string _instance;
        string _category;
        string _family;
        string _type;
        string _parameter;
        string _document;
        string _folder;

        public ElementData(ElementId id, string parameter, string instance, string category, string family, string type, string path)
        {
            _id = id;
            _parameter = parameter;
            _instance = instance;
            _category = category;
            _family = family;
            _type = type;
            int i = path.LastIndexOf("\\");
            _document = path.Substring(i + 1);
            _folder = path.Substring(0, i);
        }


        public ElementId Id
        {
            get { return _id; }
        }
        public string Parameter
        {
            get { return _parameter; }
        }
        public string Instance
        {
            get { return _instance; }
        }
        public string Category
        {
            get { return _category; }
        }
        public string Family
        {
            get { return _family; }
        }
        public string Type
        {
            get { return _type; }
        }
        public string Document
        {
            get { return _document; }
        }
        public string Folder
        {
            get { return _folder; }
        }
    }
}
