using System;
using System.Collections.Generic;

using CloudAwesome.Pbi.SourceControl.FileExtractorTypes;

namespace CloudAwesome.Pbi.SourceControl
{
    public class FilePackagerStrategies
    {
        public readonly Dictionary<string, IFilePackagerType> Strategies = new Dictionary<string, IFilePackagerType>();

        public FilePackagerStrategies()
        {
            Strategies.Add("DataModelSchema", new DataModelSchemaPackager());
            Strategies.Add("Layout", new LayoutPackager());
            Strategies.Add("DiagramLayout", new DiagramLayoutPackager());
            Strategies.Add("Settings", new SettingsPackager());
            Strategies.Add("Metadata", new MetadataPackager());
        }

        public IFilePackagerType GetFilePackagerType(string name)
        {
            var packagerTypeNotFoundExceptionMessage =
                $"Strategy for file type '{name}' is not found. Has the format of pbit files been upgraded by MS to include a new file type?";

            Strategies.TryGetValue(name, out var packager);

            if (packager == null)
            {
                Console.WriteLine($"** File of type '{name}' is not supported in this routine. It has been ignored **");
            }

            return packager;
        }
    }
}
