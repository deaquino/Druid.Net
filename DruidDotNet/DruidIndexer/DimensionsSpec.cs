using System.Collections.Generic;

namespace DruidDotNet.DruidIndexer
{
    public class DimensionsSpec
    {
        public HashSet<string> Dimensions { get; set; }
        public HashSet<string> DimensionExclusions { get; set; }
        public HashSet<string> SpatialDimensions { get; set; }
    }
}
