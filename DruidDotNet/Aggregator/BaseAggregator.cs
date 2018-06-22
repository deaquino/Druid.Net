namespace DruidDotNet.Aggregator
{
    public abstract class BaseAggregator : BaseType, IAggregator
    {
        public abstract string Name { get; }
    }
}
