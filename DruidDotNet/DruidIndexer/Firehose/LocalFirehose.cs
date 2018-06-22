﻿namespace DruidDotNet.DruidIndexer.Firehose
{
    public class LocalFirehose : BaseFirehose
    {
        public override string Type => "local";
        public string BaseDir { get; }
        public string Filter { get; }

        public LocalFirehose(string baseDir, string filter = null) : base()
        {
            BaseDir = baseDir;
            Filter = filter;
        }
    }
}
