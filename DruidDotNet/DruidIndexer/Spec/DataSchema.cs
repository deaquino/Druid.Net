using DruidDotNet.Aggregator;
using System.Collections.Generic;

namespace DruidDotNet.DruidIndexer.Spec
{

    public class DataSchemaParent
    {
        public DataSchema DataSchema { get; set; } = new DataSchema();
        public IoConfig IoConfig { get; set; } = new IoConfig();
        public TuningConfig TuningConfig { get; set; } = new TuningConfig();
    }

    public class DataSchema
    {
        public string DataSource { get; set; }
        public Parser Parser { get; set; } = new Parser();
        public List<IAggregator> MetricsSpec { get; set; } = new List<IAggregator>();
        public GranularitySpec GranularitySpec { get; set; } = new GranularitySpec();
    }
}
