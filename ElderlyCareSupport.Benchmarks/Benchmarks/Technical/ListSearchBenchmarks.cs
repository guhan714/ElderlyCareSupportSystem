using BenchmarkDotNet.Attributes;

namespace ElderlyCareSupport.Benchmarks.Benchmarks.Technical;

[MemoryDiagnoser]
[RankColumn]
public class CollectionSearchBenchmarks
{
    private List<string> ListOfString { get; set; }
    private HashSet<string> HashSetString { get; set; }
    
    [Params(1000, 5000, 10_000)]
    public int Count { get; set; }

    [Params("500", "2500", "5000")]
    public string Target { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
       ListOfString = Enumerable.Range(1, Count).Select(x => x.ToString()).ToList();
       HashSetString = Enumerable.Range(1, Count).Select(x => x.ToString()).ToHashSet();
    }


    [Benchmark(Baseline = true)]
    public string? ListFirstOrDefault()
    {
        return ListOfString.FirstOrDefault(a => a == Target);
    }
    
    [Benchmark]
    public string? HashSetGetTryGetValue()
    {
        var exists = HashSetString.TryGetValue(Target, out string? value);
        return exists ? value : null;
    }
}