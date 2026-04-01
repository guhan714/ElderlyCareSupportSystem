
# BenchmarkDotNet v0.15.8, Linux Fedora Linux 43 (Xfce)
### 11th Gen Intel Core i3-1115G4 3.00GHz (Max: 1.51GHz), 1 CPU, 4 logical and 2 physical cores .NET SDK 10.0.103
### [Host]     : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v4
### DefaultJob : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v4


| Method          | Mean     | Error   | StdDev  | Ratio | RatioSD |
|---------------- |---------:|--------:|--------:|------:|--------:|
| GetAsync_Dapper | 124.6 us | 1.30 us | 1.15 us |  1.00 |    0.01 |
| GetAsync_EFCore | 216.4 us | 2.78 us | 2.60 us |  1.74 |    0.03 |
