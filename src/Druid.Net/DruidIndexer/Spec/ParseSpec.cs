namespace Druid.Net.DruidIndexer.Spec
{
    public class ParseSpec
    {
        public string Format { get; set; }
        public TimestampSpec TimestampSpec { get; set; } = new TimestampSpec();
        public DimensionsSpec DimensionsSpec { get; set; } = new DimensionsSpec();
    }
}
