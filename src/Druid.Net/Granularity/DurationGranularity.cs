using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NodaTime;
using System;

namespace Druid.Net.Granularity
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class DurationGranularity : IGranularity<DurationGranularity.DurationType>
    {
        private readonly DurationType _granularity;
        public DurationGranularity(TimeSpan duration, Instant? origin = null)
        {
            _granularity = new DurationType(duration, origin);
        }

        public DurationType Granularity => _granularity;

        public class DurationType : BaseType
        {
            public override string Type => "duration";
            public double Duration { get; set; }
            public Instant Origin { get; set; }

            public DurationType(TimeSpan duration, Instant? origin)
            {
                Duration = duration.TotalMilliseconds;

                if (!origin.HasValue)
                {
                    return;
                }

                Origin = origin.Value;
            }
        }

    }
}
