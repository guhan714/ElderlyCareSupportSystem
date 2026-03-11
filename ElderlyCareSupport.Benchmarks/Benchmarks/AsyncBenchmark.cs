using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ElderlyCareSupport.Benchmarks.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90)]
[SimpleJob(RuntimeMoniker.Net10_0, baseline:true)]
public class AsyncBenchmark
{

    [Benchmark]
    public async Task Delay()
    {
        await Task.Delay(1);
    }
}