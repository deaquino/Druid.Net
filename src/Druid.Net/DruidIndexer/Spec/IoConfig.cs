using Druid.Net.DruidIndexer.Firehose;

namespace Druid.Net.DruidIndexer.Spec
{
    public class IoConfig
    {
        public string Type { get; set; }
        public IFirehose Firehose { get; set; }
    }
}
