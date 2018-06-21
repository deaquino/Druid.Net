using System;
using System.Collections.Generic;

namespace DruidDotNet.DruidIndexer.Spec
{
    public class GranularitySpec
    {
        public string Type { get; set; }
        public string SegmentGranularity { get; set; }
        public string QueryGranularity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //TODO: Multiple Dates Interval, ISO Format Date
        public List<string> Intervals => StartDate.HasValue && EndDate.HasValue
            ? new List<string> { $"{StartDate.Value.ToString()}/{EndDate.Value.ToString()}" }
            : new List<string>(0);
    }
}
