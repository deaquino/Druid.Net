﻿using DruidDotNet.DruidIndexer.Spec;
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
            _spec.Type = _spec.Spec.TuningConfig.Type = _spec.Spec.IoConfig.Type = IndexType;
        }

        public IndexSpecBuilder SetDataSource(string dataSource)
        {
            _spec.Spec.DataSchema.DataSource = dataSource;
            return this;
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

        public IndexSpecBuilder AddMetric(string type, string name, string fieldName = null)
        {
            _spec.Spec.DataSchema.MetricsSpec.Add(new MetricsSpec(type, name, fieldName));
            return this;
        }
        public IndexSpecBuilder SetGranularity(string type, string segmentGranularity, string queryGranularity, DateTime startDate, DateTime endDate)
        {
            _spec.Spec.DataSchema.GranularitySpec.Type = type;
            _spec.Spec.DataSchema.GranularitySpec.SegmentGranularity = segmentGranularity;
            _spec.Spec.DataSchema.GranularitySpec.QueryGranularity = queryGranularity;
            _spec.Spec.DataSchema.GranularitySpec.StartDate = startDate;
            _spec.Spec.DataSchema.GranularitySpec.EndDate = endDate;
            return this;
        }

        public IndexSpecBuilder SetIoConfig(string type, string baseDir, string filter)
        {
            _spec.Spec.IoConfig.Firehose.Type = type;
            _spec.Spec.IoConfig.Firehose.BaseDir = baseDir;
            _spec.Spec.IoConfig.Firehose.Filter = filter;
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