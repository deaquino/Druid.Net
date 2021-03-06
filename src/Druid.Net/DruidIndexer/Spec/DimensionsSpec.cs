﻿using System.Collections.Generic;

namespace Druid.Net.DruidIndexer.Spec
{
    public class DimensionsSpec
    {
        public HashSet<string> Dimensions { get; set; } = new HashSet<string>();
        public HashSet<string> DimensionExclusions { get; set; } = new HashSet<string>();
        public HashSet<string> SpatialDimensions { get; set; } = new HashSet<string>();
    }
}
