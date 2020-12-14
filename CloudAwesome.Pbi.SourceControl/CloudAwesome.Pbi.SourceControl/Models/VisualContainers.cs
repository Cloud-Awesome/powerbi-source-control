using Newtonsoft.Json;

namespace CloudAwesome.Pbi.SourceControl.Models
{
    public class VisualContainers
    {
        private object _config;
        private object _query;
        private object _dataTransforms;

        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public object Config
        {
            get => this._config;
            set => this._config = JsonConvert.DeserializeObject(value.ToString());
        }
        public object Filters { get; set; }

        public object Query
        {
            get => this._query;
            set => this._query = JsonConvert.DeserializeObject(value.ToString());
        }

        public object DataTransforms
        {
            get => this._dataTransforms;
            set => this._dataTransforms = JsonConvert.DeserializeObject(value.ToString());
        }
    }
}
