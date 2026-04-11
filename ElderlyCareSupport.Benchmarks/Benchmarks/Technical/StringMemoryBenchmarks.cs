using BenchmarkDotNet.Attributes;

namespace ElderlyCareSupport.Benchmarks.Benchmarks.Technical;

[MemoryDiagnoser]
public class StringMemoryBenchmarks
{
    public const string Source = "ADMIN";
    public const string Target = "Admin";

    [Benchmark(Baseline = true)]
    public bool ToUpperComparison()
    {
        return Source.ToUpper() == Target.ToUpper();
    }

    [Benchmark]
    public bool EqualsComparison()
    {
        return string.Equals(Source, Target, StringComparison.OrdinalIgnoreCase);
    }
    
}