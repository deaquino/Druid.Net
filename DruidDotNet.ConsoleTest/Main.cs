using DruidDotNet.Aggregator;
using DruidDotNet.DruidIndexer;
using DruidDotNet.DruidIndexer.Firehose;
using DruidDotNet.Granularity;
using System;

namespace DruidDotNet.ConsoleTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var request = new IndexSpecBuilder("X")
                .SetParser("string", "json", "x", "auto")
                .SetGranularity("uniform", new SimpleGranularity(SimpleGranularityTypes.Year), new SimpleGranularity(SimpleGranularityTypes.None), DateTime.Now, DateTime.Now)
                .SetFirehose(new LocalFirehose("/x", "*.x"))
                .SetForceExtendableShard(true)
                .AddDimensions("dim1", "dim2")
                .AddMetric(new CountAggregator("count"))
                .GetRequest();

            var api = new IndexerClient("http://cwdruid.westeurope.cloudapp.azure.com:8081/");



            var result = api.IndexAndWait(request, TimeSpan.FromMinutes(1)).Result;
        }
    }
}
