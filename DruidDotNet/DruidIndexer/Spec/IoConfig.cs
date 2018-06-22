using DruidDotNet.DruidIndexer.Firehose;

namespace DruidDotNet.DruidIndexer.Spec
{
    public class IoConfig
    {
        public string Type { get; set; }
        public IFirehose Firehose { get; set; }
    }
}
