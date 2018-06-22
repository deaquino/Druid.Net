using DruidDotNet.Helpers;
using System;

namespace DruidDotNet.Aggregator
{
    public class FieldAggregator : IAggregator
    {
        public string Type { get; }
        public string Name { get; }

        public FieldAggregator(string name, FieldAggregatorTypes type)
        {
            Name = name;
            Type = Enum.GetName(typeof(FieldAggregatorTypes), type).ToCamelCase();
        }
    }
}
