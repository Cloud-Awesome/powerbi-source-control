using System.IO;
using CloudAwesome.Pbi.SourceControl.Models;
using Newtonsoft.Json;

namespace CloudAwesome.Pbi.SourceControl.FileExtractorTypes
{
    public class MetadataPackager: IFilePackagerType
    {
        public string Name => "Metadata";
        public void Unpack(string encodedJsonString, PackagerSettings settings)
        {
            var diagramLayout = JsonConvert.DeserializeObject<object>(encodedJsonString);

            // 1. Create root file for DataModelSchema.json
            File.WriteAllText($"{settings.OutputFolder}\\Metadata.json", diagramLayout.ToString());

        }

        public void Pack()
        {
            throw new System.NotImplementedException();
        }
    }
}
