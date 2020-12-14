using System.IO;
using CloudAwesome.Pbi.SourceControl.Models;
using Newtonsoft.Json;

namespace CloudAwesome.Pbi.SourceControl.FileExtractorTypes
{
    public class SettingsPackager: IFilePackagerType
    {
        public string Name => "Settings";
        public void Unpack(string encodedJsonString, PackagerSettings settings)
        {
            var diagramLayout = JsonConvert.DeserializeObject<object>(encodedJsonString);

            // 1. Create root file for DataModelSchema.json
            File.WriteAllText($"{settings.OutputFolder}\\Settings.json", diagramLayout.ToString());

        }

        public void Pack()
        {
            throw new System.NotImplementedException();
        }
    }
}
