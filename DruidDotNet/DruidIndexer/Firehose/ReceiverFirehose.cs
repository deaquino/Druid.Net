namespace DruidDotNet.DruidIndexer.Firehose
{
    public class ReceiverFirehose : IFirehose
    {
        public string Type => "receiver";
        public string ServiceName { get; }
        public int BufferSize { get; }

        public ReceiverFirehose(string serviceName, int bufferSize) : base()
        {
            ServiceName = serviceName;
            BufferSize = bufferSize;
        }

    }
}
