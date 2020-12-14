using Newtonsoft.Json;

namespace CloudAwesome.Pbi.SourceControl.Models
{
    public class Table
    {
        public string Name { get; set; }
        public object[] Columns { get; set; }
        public object[] Partitions { get; set; }
        public object[] Annotations { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
