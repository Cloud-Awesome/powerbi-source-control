using Newtonsoft.Json;

namespace CloudAwesome.Pbi.SourceControl.Models
{
    public class Section
    {
        private object visualContainers;

        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Filters { get; set; }
        public int Ordinal { get; set; }
        public VisualContainers[] VisualContainers { get; set; }
        public object Config { get; set; }
        public int DisplayOption { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
