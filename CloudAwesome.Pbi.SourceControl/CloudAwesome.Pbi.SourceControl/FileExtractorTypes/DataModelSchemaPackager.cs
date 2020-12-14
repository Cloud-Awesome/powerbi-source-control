using System;
using System.IO;
using CloudAwesome.Pbi.SourceControl.Models;
using Newtonsoft.Json;

namespace CloudAwesome.Pbi.SourceControl.FileExtractorTypes
{
    public class DataModelSchemaPackager: IFilePackagerType
    {
        public string Name => "DataModelSchema";

        public void Unpack(string encodedJsonString, PackagerSettings settings)
        {
            var schema = JsonConvert.DeserializeObject<DataModelSchema>(encodedJsonString);

            // 1. Create root file for DataModelSchema.json
            File.WriteAllText($"{settings.OutputFolder}\\DataModelSchema.json", schema.ToString());

            // 2. Create model.json
            File.WriteAllText($"{settings.OutputFolder}\\Model.json", schema.Model.ToString());

            // 3. Create file for each table
            var folderPath = $"{settings.OutputFolder}\\Tables";
            Directory.CreateDirectory(folderPath);

            foreach (var table in schema.Model.Tables)
            {
                File.WriteAllText($"{folderPath}\\{table.Name.ToValidFileName()}.json", table.ToString());
            }
        }

        public void Pack()
        {
            throw new NotImplementedException();
        }
    }
}
