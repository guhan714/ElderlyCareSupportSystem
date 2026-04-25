using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using ElderlyCareSupport.Benchmarks.Benchmarks.Domain;

var config = ManualConfig
        .Create(DefaultConfig.Instance)
        .WithSummaryStyle(new SummaryStyle(null, false, null, null, ratioStyle: RatioStyle.Trend))
    ;
BenchmarkRunner.Run<RoleBenchmarks>(config);