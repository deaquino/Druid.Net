﻿namespace DruidDotNet.DruidIndexer.Spec
{
    public class Parser
    {
        public string Type { get; set; }
        public ParseSpec ParseSpec { get; set; } = new ParseSpec();
        public DimensionsSpec DimensionsSpec { get; set; } = new DimensionsSpec();
    }
}