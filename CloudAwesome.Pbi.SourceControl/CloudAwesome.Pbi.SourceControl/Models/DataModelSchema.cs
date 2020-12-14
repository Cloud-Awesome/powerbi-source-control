using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudAwesome.Pbi.SourceControl.Models
{
    public class DataModelSchema
    {
        public Guid Name { get; set; }
        public int CompatibilityLevel { get; set; }
        public string CreatedTimestamp { get; set; }
        public string LastUpdate { get; set; }
        public string LastSchemaUpdate { get; set; }
        public string LastProcessed { get; set; }
        public Model Model { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings()
            {
                ContractResolver = new IgnorePropertiesResolver(new []
                {
                    "Model"
                })
            });
        }
    }
}
