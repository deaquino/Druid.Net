using Druid.Net.Granularity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Druid.Net.DruidIndexer.Spec
{
    public class GranularitySpec
    {
        public string Type { get; set; }

        public string SegmentGranularity => SimpleSegmentGranularity.Granularity;
        public string QueryGranularity => SimpleQueryGranularity.Granularity;

        [JsonIgnore]
        public SimpleGranularity SimpleSegmentGranularity { get; set; }

        [JsonIgnore]
        public SimpleGranularity SimpleQueryGranularity { get; set; }

        [JsonIgnore]
        public DateTime? StartDate { get; set; }

        [JsonIgnore]
        public DateTime? EndDate { get; set; }

        //TODO: Multiple Dates Interval, ISO Format Date
        public List<string> Intervals => StartDate.HasValue && EndDate.HasValue
            ? new List<string> { $"{StartDate.Value.ToString("yyyy-MM-dd")}/{EndDate.Value.ToString("yyyy-MM-dd")}" }
            : new List<string>(0);
    }
}
