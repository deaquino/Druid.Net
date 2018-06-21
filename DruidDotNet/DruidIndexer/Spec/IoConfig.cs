namespace DruidDotNet.DruidIndexer.Spec
{
    public class IoConfig
    {
        public string Type { get; set; }
        public FireHose FireHose { get; set; } = new FireHose();
    }
}
