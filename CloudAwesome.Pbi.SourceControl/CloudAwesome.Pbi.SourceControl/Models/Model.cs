using Newtonsoft.Json;

namespace CloudAwesome.Pbi.SourceControl.Models
{
    public class Model
    {
        public string Culture { get; set; }
        public object DataAccessOptions { get; set; }
        public string DefaultPowerBIDataSourceVersion { get; set; }
        public string SourceQueryCulture { get; set; }
        public string StructureModifiedTime { get; set; }
        public Table[] Tables { get; set; }
        public object[] Cultures { get; set; }
        public object[] Annotations { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings()
            {
                ContractResolver = new IgnorePropertiesResolver(new[]
                {
                    "Tables"
                })
            });
        }
    }
}
