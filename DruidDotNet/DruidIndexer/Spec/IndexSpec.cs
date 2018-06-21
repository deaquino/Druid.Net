namespace DruidDotNet.DruidIndexer.Spec
{
    public class IndexSpec
    {
        public string Type { get; set; }
        public DataSchemaParent Spec { get; set; } = new DataSchemaParent();
    }
}
