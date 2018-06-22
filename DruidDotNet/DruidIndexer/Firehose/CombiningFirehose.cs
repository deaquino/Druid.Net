using System.Collections.Generic;

namespace DruidDotNet.DruidIndexer.Firehose
{
    public class CombiningFirehose : BaseFirehose
    {
        public override string Type => "combining";
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
