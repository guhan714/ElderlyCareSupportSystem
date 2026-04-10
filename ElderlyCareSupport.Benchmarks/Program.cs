using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using ElderlyCareSupport.Benchmarks.Benchmarks.Technical;

var config = ManualConfig
        .Create(DefaultConfig.Instance)
        .WithSummaryStyle(new SummaryStyle(null, true, null, null, ratioStyle: RatioStyle.Trend))
    ;
BenchmarkRunner.Run<CollectionSearchBenchmarks>(config);