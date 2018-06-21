namespace DruidDotNet.DruidIndexer.Spec
{
    public class IndexSpec
    {
        public string Type { get; set; };
        public DataSchema Spec { get; set; } = new DataSchema();
        public IoConfig IoConfig { get; set; } = new IoConfig();
        public TuningConfig TuningConfig { get; set; } = new TuningConfig();
    }
}
