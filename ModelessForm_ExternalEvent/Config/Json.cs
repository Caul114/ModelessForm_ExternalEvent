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

        // Metodo per CREARE il file Json
        public List<Data> WriteJson(int id, string name, string path)
        {
            _data.Add(new Data()
            {
                Id = id,
                Name = name,
                Value = path
            });
            string jsonString = JsonConvert.SerializeObject(_data.ToArray());
            //write string to file
            File.WriteAllText(ModelessForm.thisModForm.PathFileTxt, jsonString);

            return _data;
        }

        // Metodo per MODIFICARE o AGGIUNGERE un oggetto del file .json
        public void UpdateJson(int id, int index, string name, string value)
        {
            string pathFileConfig = ModelessForm.thisModForm.PathFileTxt;
            string jsonText = string.Empty;
            if (!File.Exists(pathFileConfig))
            {
                _data.Add(new Data()
                {
                    Id = id,
                    Name = name,
                    Value = value
                });
                jsonText = JsonConvert.SerializeObject(_data.ToArray());
            }
            else
            {
                jsonText = File.ReadAllText(pathFileConfig);
            }
            IList<Data> traduction = JsonConvert.DeserializeObject<IList<Data>>(jsonText);
            dynamic jsonObj = JsonConvert.DeserializeObject(jsonText);
            // Se l'oggetto .json esiste già...
            if (traduction != null && traduction.Any(x => x.Id == id))
            {
                jsonObj[index]["Value"] = value;
                string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(ModelessForm.thisModForm.PathFileTxt, output);
            }
            else // ... altrimenti lo crea
            {
                if(traduction == null)
                {
                    traduction = new List<Data>();
                }
                traduction.Add(new Data { Id = id, Name = name, Value = value });
                jsonText = JsonConvert.SerializeObject(traduction);
                File.WriteAllText(ModelessForm.thisModForm.PathFileTxt, jsonText);
            }
        }
    }
}
