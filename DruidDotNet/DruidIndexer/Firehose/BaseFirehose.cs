using System;
namespace DruidDotNet.DruidIndexer.Firehose
{
    public abstract class BaseFirehose : IFirehose
    {
        public abstract string Type { get; }
    }
}
