## Introduction 
DruidDotNet exposes a simple API to work with Druid.

## Build
[![Build Status](https://ci.appveyor.com/api/projects/status/k28ufn8sgc01j1cf?svg=true)](https://ci.appveyor.com/project/deaquino/druid-net)
[![NuGet](https://img.shields.io/nuget/v/Druid.Net.svg)](https://www.nuget.org/packages/Druid.Net/)

[![Build history](https://buildstats.info/appveyor/chart/deaquino/druid-net)](https://ci.appveyor.com/project/deaquino/beatpulse/druid-net)

## Getting Started
Install-Package Druid.Net
```csharp
var request = new IndexSpecBuilder("DataSourceName")
    .SetParser("string", "json", "TimestampField", "auto")
    //type of granularity, segment granularity, query granularity, intervals startDate and endDate
    .SetGranularity("uniform", new SimpleGranularity(SimpleGranularityTypes.Year),
        new SimpleGranularity(SimpleGranularityTypes.None), DateTime.Now.Date.AddDays(-1), DateTime.Now.Date)
    .SetFirehose(new LocalFirehose("/path", "*.json"))
    .SetForceExtendableShard(true)
    .AddDimensions("dimension1", "dimension2")
    .AddExcludedDimensions("dim_to_exclude")
    .AddMetric(new CountAggregator("count"))
    .GetRequest();

var api = new IndexerClient("http://druid.com:8081/");

var result = await api.IndexAndWait(request, TimeSpan.FromMinutes(1));
```
