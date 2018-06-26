using System;

namespace Druid.Net.DruidIndexer.Firehose
{
    public class TimedFirehose : IFirehose
    {
        public string Type => "timed";
        public IFirehose Delegate { get; }
        public DateTime ShutoffTime { get; }

        public TimedFirehose(DateTime shutoffTime, IFirehose firehose) : base()
        {
            ShutoffTime = shutoffTime;
            Delegate = firehose;
        }
    }
}
