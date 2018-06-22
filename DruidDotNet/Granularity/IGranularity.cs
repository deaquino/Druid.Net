namespace DruidDotNet.Granularity
{
    public interface IGranularity<T>
    {
        T Granularity { get; }
    }
}
