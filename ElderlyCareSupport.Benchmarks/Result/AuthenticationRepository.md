
# BenchmarkDotNet v0.15.8, Linux Fedora Linux 43 (Xfce)
### 11th Gen Intel Core i3-1115G4 3.00GHz (Max: 1.51GHz), 1 CPU, 4 logical and 2 physical cores .NET SDK 10.0.103
### [Host]     : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v4
### DefaultJob : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v4



| Method         | Mean     | Error   | StdDev  | Ratio | RatioSD | Rank | Gen0    | Allocated | Alloc Ratio |
|--------------- |---------:|--------:|--------:|------:|--------:|-----:|--------:|----------:|------------:|
| GetUser_Dapper | 162.9 us | 1.61 us | 1.50 us |  1.00 |    0.01 |    1 |  0.9766 |   3.48 KB |        1.00 |
| GetUser_EFCore | 243.8 us | 4.52 us | 4.44 us |  1.50 |    0.03 |    2 | 12.2070 |  37.46 KB |       10.75 |
