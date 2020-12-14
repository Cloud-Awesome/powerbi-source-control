using System.IO;
using Newtonsoft.Json;

using CloudAwesome.Pbi.SourceControl.Models;

namespace CloudAwesome.Pbi.SourceControl.FileExtractorTypes
{
    public class LayoutPackager: IFilePackagerType
    {
        public string Name => "Layout";

        public void Unpack(string encodedJsonString, PackagerSettings settings)
        {
            var layout = JsonConvert.DeserializeObject<Layout>(encodedJsonString);

            // 1. Create root file for DataModelSchema.json
            File.WriteAllText($"{settings.OutputFolder}\\Layout.json", layout.ToString());

            var folderPath = $"{settings.OutputFolder}\\Sections";
            Directory.CreateDirectory(folderPath);

            foreach (var section in layout.Sections)
            {
                File.WriteAllText($"{folderPath}\\{section.DisplayName.ToValidFileName()}.json", section.ToString());
            }
        }

        public void Pack()
        {
            throw new System.NotImplementedException();
        }
    }
}
