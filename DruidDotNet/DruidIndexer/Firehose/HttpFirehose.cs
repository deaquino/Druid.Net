using System.Collections.Generic;

namespace DruidDotNet.DruidIndexer.Firehose
{
    public class HttpFirehose : IFirehose
    {
        public string Type => "http";
        public List<string> Uris { get; }

        public HttpFirehose(params string[] uris) : this(new List<string>(uris))
        {
        }

        public HttpFirehose(List<string> uris) : base()
        {
            Uris = uris;
        }

    }
}
