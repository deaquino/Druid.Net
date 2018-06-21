namespace DruidDotNet.DruidIndexer
{
    public class IndexSpec
    {
        public string Type => "index";
        public DataSchema Spec { get; set; }
        public IoConfig IoConfig { get; set; }
        public TuningConfig TuningConfig { get; set; }
    }
}
