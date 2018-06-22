using System;

namespace DruidDotNet.DruidIndexer.Firehose
{
    public class TimedFirehose : BaseFirehose
    {
        public override string Type => "timed";
        public IFirehose Delegate { get; }
        public DateTime ShutoffTime { get; }

        public TimedFirehose(DateTime shutoffTime, IFirehose firehose) : base()
        {
            ShutoffTime = shutoffTime;
            Delegate = firehose;
        }
    }
}
