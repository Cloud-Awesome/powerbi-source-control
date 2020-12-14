using System;
using System.IO;
using System.IO.Compression;
using System.IO.Abstractions;
using System.Text;
using Newtonsoft.Json;

using CloudAwesome.Pbi.SourceControl.Models;

namespace CloudAwesome.Pbi.SourceControl
{
    public class Packager
    {
        public void Pack(string filePath, string outputPath, bool debug = true)
        {
            using (var fileStream = new FileSystem().File.Open(filePath, FileMode.Open))
            {
                using (var zip = new ZipArchive(fileStream, ZipArchiveMode.Update))
                {
                    var reportName = Path.GetFileNameWithoutExtension(filePath);

                    var settings = new PackagerSettings()
                    {
                        OutputFolder = $"{outputPath}\\{reportName}"
                    };

                    if (Directory.Exists(settings.OutputFolder))
                    {
                        Directory.Delete(settings.OutputFolder,true);
                    }
                    Directory.CreateDirectory(settings.OutputFolder);

                    foreach (var archiveEntry in zip.Entries)
                    {
                        var strategies = new FilePackagerStrategies();
                        var packager = strategies.GetFilePackagerType(archiveEntry.Name);

                        if (packager == null) continue;
                        Console.WriteLine($"Processing file: {archiveEntry.Name}");

                        using (var ms = new MemoryStream())
                        {
                            archiveEntry.Open().CopyTo(ms);
                            var unzippedArray = ms.ToArray();
                            var encodedJsonString = Encoding.Unicode.GetString(unzippedArray);
                            
                            packager.Unpack(encodedJsonString, settings);

                        }
                    }
                }
            }
        }

        public void Unpack()
        {
            throw new NotImplementedException();
        }
    }
}
