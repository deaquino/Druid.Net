namespace Druid.Net.Granularity
{
    public interface IGranularity<T>
    {
        T Granularity { get; }
    }
}
