using System.IO;
using CloudAwesome.Pbi.SourceControl.Models;
using Newtonsoft.Json;

namespace CloudAwesome.Pbi.SourceControl.FileExtractorTypes
{
    public class DiagramLayoutPackager: IFilePackagerType
    {
        public string Name => "DiagramLayout";
        public void Unpack(string encodedJsonString, PackagerSettings settings)
        {
            var diagramLayout = JsonConvert.DeserializeObject<object>(encodedJsonString);

            // 1. Create root file for DataModelSchema.json
            File.WriteAllText($"{settings.OutputFolder}\\DiagramLayout.json", diagramLayout.ToString());

        }

        public void Pack()
        {
            throw new System.NotImplementedException();
        }
    }
}
