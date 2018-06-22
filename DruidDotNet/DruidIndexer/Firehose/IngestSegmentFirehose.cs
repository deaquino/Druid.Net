namespace DruidDotNet.DruidIndexer.Firehose
{
    public class IngestSegmentFirehose : BaseFirehose
    {
        public override string Type => "ingestSegment";
        public string DataSource { get; }
        public string Interval { get; }

        public IngestSegmentFirehose(string dataSource, string interval) : base()
        {
            DataSource = dataSource;
            Interval = interval;
        }

    }
}
