using System.Collections.Generic;

namespace DruidDotNet.DruidIndexer
{

    public class DataSchema
    {
        public string DataSource { get; set; }
        public Parser Parser { get; set; }
        public List<MetricsSpec> MetricsSpec { get; set; }
        public GranularitySpec GranularitySpec { get; set; }
    }
}
