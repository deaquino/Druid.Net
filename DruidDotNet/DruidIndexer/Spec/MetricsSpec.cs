namespace DruidDotNet.DruidIndexer.Spec
{
    public class MetricsSpec
    {
        public string Type { get; }
        public string Name { get; }
        public string FieldName { get; }

        public MetricsSpec(string type, string name, string fieldName = null)
        {
            Type = type;
            Name = name;
            FieldName = fieldName;
        }
    }
}
