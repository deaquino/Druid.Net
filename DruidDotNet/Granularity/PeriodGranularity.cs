using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NodaTime;

namespace DruidDotNet.Granularity
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PeriodGranularity : IGranularity<PeriodGranularity.PeriodType>
    {
        private readonly PeriodType _granularity;
        public PeriodGranularity(Period period, DateTimeZone timeZone = null, Instant? origin = null)
        {
            _granularity = new PeriodType(period, timeZone, origin);
        }

        public PeriodType Granularity => _granularity;

        public class PeriodType : BaseType
        {
            public override string Type => "period";
            public Period Period { get; set; }
            public DateTimeZone TimeZone { get; set; }
            public Instant? Origin { get; set; }

            public PeriodType(Period period, DateTimeZone timeZone, Instant? origin)
            {
                Period = period;
                TimeZone = timeZone;
                Origin = origin;
            }
        }

    }
}
