using CloudAwesome.Pbi.SourceControl.Models;

namespace CloudAwesome.Pbi.SourceControl.FileExtractorTypes
{
    public interface IFilePackagerType
    {
        string Name { get; }

        void Unpack(string encodedJsonString, PackagerSettings settings);

        void Pack();

    }
}
