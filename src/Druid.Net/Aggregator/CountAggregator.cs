namespace Druid.Net.Aggregator
{
    public class CountAggregator : IAggregator
    {
        public string Type => "count";
        public string Name { get; }

        public CountAggregator(string name)
        {
            Name = name;
        }
    }
}
