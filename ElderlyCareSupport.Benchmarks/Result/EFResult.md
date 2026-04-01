# EFCore

## ToList
| Method       | Mean     | Error   | StdDev  | Gen0    | Allocated |
|------------- |---------:|--------:|--------:|--------:|----------:|
| GetCountries | 239.7 us | 4.78 us | 7.71 us | 17.5781 |  55.45 KB |

| Method       | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------- |---------:|---------:|---------:|-------:|----------:|
| GetCountries | 98.62 us | 1.663 us | 1.556 us | 1.7090 |   5.81 KB |


# Dapper

## ToList
| Method       | Mean     | Error   | StdDev  | Gen0   | Allocated |
|------------- |---------:|--------:|--------:|-------:|----------:|
| GetCountries | 100.2 us | 1.91 us | 1.70 us | 0.7324 |   2.51 KB |

| Method       | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------- |---------:|---------:|---------:|-------:|----------:|
| GetCountries | 80.73 us | 1.395 us | 1.237 us | 0.4883 |   1.99 KB |
