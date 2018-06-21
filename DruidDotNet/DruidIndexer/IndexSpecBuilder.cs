using DruidDotNet.DruidIndexer.Spec;
using System;
using System.Collections.Generic;

namespace DruidDotNet.DruidIndexer
{
    public class IndexSpecBuilder
    {
        private const string IndexType = "index";
        private readonly IndexSpec _spec;

        public IndexSpecBuilder()
        {
            _spec = new IndexSpec();
            _spec.Type = _spec.TuningConfig.Type = _spec.IoConfig.Type = IndexType;
        }

        public IndexSpecBuilder SetDataSource(string dataSource)
        {
            _spec.Spec.DataSource = dataSource;
            return this;
        }

        public IndexSpecBuilder SetParser(string type, string parserFormat, string tsColumn, string tsFormat)
        {
            _spec.Spec.Parser.Type = type;
            _spec.Spec.Parser.ParseSpec.Format = parserFormat;
            _spec.Spec.Parser.ParseSpec.TimestampSpec.Column = tsColumn;
            _spec.Spec.Parser.ParseSpec.TimestampSpec.Format = tsFormat;
            return this;
        }

        public IndexSpecBuilder AddDimensions(List<string> dimensions)
        {
            return AddDimensions(dimensions.ToArray());
        }

        public IndexSpecBuilder AddDimensions(params string[] dimensions)
        {
            foreach (var dimension in dimensions)
            {
                _spec.Spec.Parser.DimensionsSpec.Dimensions.Add(dimension);
            }

            return this;
        }

        public IndexSpecBuilder AddExcludedDimensions(List<string> dimensions)
        {
            return AddExcludedDimensions(dimensions.ToArray());
        }

        public IndexSpecBuilder AddExcludedDimensions(params string[] dimensions)
        {
            foreach (var dimension in dimensions)
            {
                _spec.Spec.Parser.DimensionsSpec.DimensionExclusions.Add(dimension);
            }

            return this;
        }

        public IndexSpecBuilder AddSpatialDimensions(List<string> dimensions)
        {
            return AddSpatialDimensions(dimensions.ToArray());
        }

        public IndexSpecBuilder AddSpatialDimensions(params string[] dimensions)
        {
            foreach (var dimension in dimensions)
            {
                _spec.Spec.Parser.DimensionsSpec.SpatialDimensions.Add(dimension);
            }

            return this;
        }

        public IndexSpecBuilder AddMetric(string type, string name, string fieldName = null)
        {
            _spec.Spec.MetricsSpec.Add(new MetricsSpec(type, name, fieldName));
            return this;
        }
        public IndexSpecBuilder SetGranularity(string type, string segmentGranularity, string queryGranularity, DateTime startDate, DateTime endDate)
        {
            _spec.Spec.GranularitySpec.Type = type;
            _spec.Spec.GranularitySpec.SegmentGranularity = segmentGranularity;
            _spec.Spec.GranularitySpec.SegmentGranularity = queryGranularity;
            _spec.Spec.GranularitySpec.StartDate = startDate;
            _spec.Spec.GranularitySpec.EndDate = endDate;
            return this;
        }

        public IndexSpecBuilder SetIoConfig(string type, string baseDir, string filter)
        {
            _spec.IoConfig.FireHose.Type = type;
            _spec.IoConfig.FireHose.BaseDir = baseDir;
            _spec.IoConfig.FireHose.Filter = filter;
            return this;
        }

        public IndexSpecBuilder SetForceExtendableShard(bool force)
        {
            _spec.TuningConfig.ForceExtendableShardSpecs = force;
            return this;
        }

        public IndexSpec GetRequest()
        {
            return _spec;
        }
    }
}