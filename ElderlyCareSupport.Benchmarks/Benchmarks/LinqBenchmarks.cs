using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace ElderlyCareSupport.Benchmarks.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net10_0, baseline:true)]
[RankColumn]
public class LinqBenchmarks
{

    private List<int> IntegerList { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        IntegerList = Enumerable.Range(1, 10000).ToList();
    }
    
    [Benchmark]
    public int FirstOrDefault()
    {
        return IntegerList.FirstOrDefault(a => a == 5000);
    }

    [Benchmark]
    public int Find()
    {
        return IntegerList.Find(a => a == 5000);
    }

    [Benchmark]
    public int SingleOrDefault()
    {
        return IntegerList.SingleOrDefault(a => a == 5000);
    }
}