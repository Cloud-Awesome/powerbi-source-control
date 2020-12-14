using Newtonsoft.Json;

namespace CloudAwesome.Pbi.SourceControl.Models
{
    public class Layout
    {
        private object _config;

        public int Id { get; set; }
        public object ResourcePackages { get; set; }
        public Section[] Sections { get; set; }
        public object Config
        {
            get => this._config;
            set => this._config = JsonConvert.DeserializeObject(value.ToString());
        }
        public int LayoutOptimization { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings()
            {
                ContractResolver = new IgnorePropertiesResolver(new[]
                {
                    "Sections"
                })
            });
        }
    }
}
