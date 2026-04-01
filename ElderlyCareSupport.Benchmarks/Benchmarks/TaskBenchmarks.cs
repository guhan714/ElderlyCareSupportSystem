using BenchmarkDotNet.Attributes;

namespace ElderlyCareSupport.Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class TaskBenchmarks
{
    [Benchmark]
    public async Task Sequence()
    {
        await Wait();
        await Wait2();
    }

    [Benchmark]
    public async Task WhenAll()
    {
        var task = Wait();
        var task2 = Wait2();
        
        await Task.WhenAll(task, task2);
    }

    private async Task Wait()
    {
        await Task.Delay(100);
    }
    
    private async  Task Wait2()
    {
        await Task.Delay(100);
    }
    
}