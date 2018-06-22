using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DruidDotNet.Granularity
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SimpleGranularity : IGranularity<string>
    {
        private readonly SimpleGranularityTypes _granularity;
        public SimpleGranularity(SimpleGranularityTypes granularity)
        {
            _granularity = granularity;
        }

        public string Granularity => _granularity.ToString();
    }
}
