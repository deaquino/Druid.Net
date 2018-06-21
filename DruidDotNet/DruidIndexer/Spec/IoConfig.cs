namespace DruidDotNet.DruidIndexer.Spec
{
    public class IoConfig
    {
        public string Type { get; set; }
        public Firehose Firehose { get; set; } = new Firehose();
    }
}
