using System.Collections.Generic;

namespace DruidDotNet.DruidIndexer
{
    public class GranularitySpec
    {
        public string Type { get; set; }
        public string SegmentGranularity { get; set; }
        public string QueryGranularity { get; set; }
        public List<string> Intervals { get; set; }
    }
}
