using System.Collections.Generic;

namespace Druid.Net.DruidIndexer.Firehose
{
    public class CombiningFirehose : IFirehose
    {
        public string Type => "combining";
        public List<IFirehose> Delegates { get; }

        public CombiningFirehose(params IFirehose[] delegates) : this(new List<IFirehose>(delegates))
        {
        }

        public CombiningFirehose(List<IFirehose> delegates) : base()
        {
            Delegates = delegates;
        }
    }
}
