using Druid.Net.Helpers;
using Newtonsoft.Json;
using System;

namespace Druid.Net.Aggregator
{
    public class FieldAggregator : IAggregator
    {
        private readonly FieldAggregatorTypes _type;

        [JsonProperty]
        public string Type => Enum.GetName(typeof(FieldAggregatorTypes), _type).ToCamelCase();
        public string Name { get; }

        public FieldAggregator(string name, FieldAggregatorTypes type)
        {
            Name = name;
            _type = type;
        }
    }
}
