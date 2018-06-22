namespace DruidDotNet.Aggregator
{
    public class CountAggregator : BaseAggregator
    {
        public override string Type => "count";

        public override string Name { get; }

        public CountAggregator(string name)
        {
            Name = name;
        }
    }
}
