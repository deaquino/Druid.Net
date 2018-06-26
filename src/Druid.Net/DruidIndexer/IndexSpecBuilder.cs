using Druid.Net.Aggregator;
using Druid.Net.DruidIndexer.Firehose;
using Druid.Net.DruidIndexer.Spec;
using Druid.Net.Granularity;
using System;
using System.Collections.Generic;

namespace Druid.Net.DruidIndexer
{
    public class IndexSpecBuilder
    {
        private const string IndexType = "index";
        private readonly IndexSpec _spec;

        public IndexSpecBuilder(string dataSource)
        {
            _spec = new IndexSpec();
            _spec.Spec.DataSchema.DataSource = dataSource;
            _spec.Type = _spec.Spec.TuningConfig.Type = _spec.Spec.IoConfig.Type = IndexType;
        }

        public IndexSpecBuilder SetParser(string type, string parserFormat, string tsColumn, string tsFormat)
        {
            _spec.Spec.DataSchema.Parser.Type = type;
            _spec.Spec.DataSchema.Parser.ParseSpec.Format = parserFormat;
            _spec.Spec.DataSchema.Parser.ParseSpec.TimestampSpec.Column = tsColumn;
            _spec.Spec.DataSchema.Parser.ParseSpec.TimestampSpec.Format = tsFormat;
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
                _spec.Spec.DataSchema.Parser.ParseSpec.DimensionsSpec.Dimensions.Add(dimension);
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
                _spec.Spec.DataSchema.Parser.ParseSpec.DimensionsSpec.DimensionExclusions.Add(dimension);
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
                _spec.Spec.DataSchema.Parser.ParseSpec.DimensionsSpec.SpatialDimensions.Add(dimension);
            }

            return this;
        }

        public IndexSpecBuilder AddMetric(IAggregator aggregator)
        {
            _spec.Spec.DataSchema.MetricsSpec.Add(aggregator);
            return this;
        }

        public IndexSpecBuilder SetGranularity(string type, SimpleGranularity segmentGranularity, SimpleGranularity queryGranularity,
            DateTime startDate, DateTime endDate)
        {
            _spec.Spec.DataSchema.GranularitySpec.Type = type;
            _spec.Spec.DataSchema.GranularitySpec.SimpleSegmentGranularity = segmentGranularity;
            _spec.Spec.DataSchema.GranularitySpec.SimpleQueryGranularity = queryGranularity;
            _spec.Spec.DataSchema.GranularitySpec.StartDate = startDate;
            _spec.Spec.DataSchema.GranularitySpec.EndDate = endDate;
            return this;
        }

        public IndexSpecBuilder SetFirehose(IFirehose firehose)
        {
            _spec.Spec.IoConfig.Firehose = firehose;
            return this;
        }

        public IndexSpecBuilder SetForceExtendableShard(bool force)
        {
            _spec.Spec.TuningConfig.ForceExtendableShardSpecs = force;
            return this;
        }

        public IndexSpec GetRequest()
        {
            return _spec;
        }
    }
}