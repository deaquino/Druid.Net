using DruidDotNet.Helpers;
using System;

namespace DruidDotNet.Aggregator
{
    public class FieldAggregator : BaseAggregator
    {
        public override string Type { get; }
        public override string Name { get; }

        public FieldAggregator(string name, FieldAggregatorTypes type)
        {
            Name = name;
            Type = Enum.GetName(typeof(FieldAggregatorTypes), type).ToCamelCase();
        }
    }
}
