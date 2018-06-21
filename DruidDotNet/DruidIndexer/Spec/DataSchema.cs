using System.Collections.Generic;

namespace DruidDotNet.DruidIndexer.Spec
{

    public class DataSchema
    {
        public string DataSource { get; set; }
        public Parser Parser { get; set; } = new Parser();
        public List<MetricsSpec> MetricsSpec { get; set; } = new List<MetricsSpec>();
        public GranularitySpec GranularitySpec { get; set; } = new GranularitySpec();
    }
}
