using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelessForm_ExternalEvent.Config
{
    public class Json
    {
        private List<Data> _data = new List<Data>();

        public List<Data> WriteJson(int id, string name, string path)
        {
            _data.Add(new Data()
            {
                Id = id,
                Name = name,
                Path = path
            });
            string jsonString = JsonConvert.SerializeObject(_data.ToArray());
            //write string to file
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Bold Software\DataCell\ConfigPath.json", jsonString);

            return _data;
        }
    }
}
