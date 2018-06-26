using Druid.Net.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Druid.Net.Granularity
{
    public class SimpleGranularity : IGranularity<string>
    {
        private readonly SimpleGranularityTypes _granularity;

        public string Granularity => Enum.GetName(typeof(SimpleGranularityTypes), _granularity).ToSnakeCase();
        public SimpleGranularity(SimpleGranularityTypes granularity)
        {
            _granularity = granularity;
        }
    }
}
