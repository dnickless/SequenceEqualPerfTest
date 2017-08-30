``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 7 SP1 (6.1.7601)
Processor=Intel Xeon CPU X5670 2.93GHz, ProcessorCount=24
Frequency=2857460 Hz, Resolution=349.9612 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host] : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  Core   : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT

Job=Core  Runtime=Core  

```
 | Method |     Count |                Mean |              Error |             StdDev |              Median |
 |------- |---------- |--------------------:|-------------------:|-------------------:|--------------------:|
 |    **New** |         **1** |            **51.19 ns** |          **1.9418 ns** |          **2.3116 ns** |            **49.92 ns** |
 |    Old |         1 |            77.41 ns |          1.5798 ns |          3.7238 ns |            75.14 ns |
 |    **New** |        **10** |           **180.29 ns** |          **0.2424 ns** |          **0.2024 ns** |           **180.24 ns** |
 |    Old |        10 |           203.98 ns |          8.0888 ns |          9.6291 ns |           198.46 ns |
 |    **New** |        **20** |           **344.56 ns** |          **7.1014 ns** |         **20.8272 ns** |           **328.17 ns** |
 |    Old |        20 |           335.97 ns |          0.9114 ns |          0.7611 ns |           335.87 ns |
 |    **New** |        **50** |           **859.85 ns** |          **0.3313 ns** |          **0.3099 ns** |           **859.72 ns** |
 |    Old |        50 |           753.26 ns |         13.1253 ns |         10.9602 ns |           747.29 ns |
 |    **New** |       **100** |         **1,571.07 ns** |         **31.2722 ns** |         **85.0784 ns** |         **1,514.42 ns** |
 |    Old |       100 |         1,566.75 ns |         31.1829 ns |         78.8032 ns |         1,617.26 ns |
 |    **New** |       **200** |         **2,969.59 ns** |         **44.7214 ns** |         **34.9155 ns** |         **2,959.99 ns** |
 |    Old |       200 |         2,865.40 ns |          6.2120 ns |          5.1873 ns |         2,865.38 ns |
 |    **New** |       **500** |         **7,926.77 ns** |        **157.2661 ns** |        **400.2925 ns** |         **8,092.03 ns** |
 |    Old |       500 |         8,360.36 ns |        359.5511 ns |      1,060.1444 ns |         8,281.27 ns |
 |    **New** |      **1000** |        **15,289.58 ns** |        **447.7730 ns** |        **656.3398 ns** |        **14,953.46 ns** |
 |    Old |      1000 |        14,996.01 ns |        296.7106 ns |        807.2229 ns |        15,469.89 ns |
 |    **New** |     **10000** |       **150,353.42 ns** |      **6,654.7716 ns** |      **7,922.0322 ns** |       **146,117.37 ns** |
 |    Old |     10000 |       144,796.81 ns |      2,885.5331 ns |      8,462.7690 ns |       138,478.73 ns |
 |    **New** |   **1000000** |    **16,442,357.14 ns** |      **8,154.2391 ns** |      **5,896.0488 ns** |    **16,444,390.30 ns** |
 |    Old |   1000000 |    14,783,632.74 ns |    302,430.4808 ns |    891,723.0963 ns |    15,435,334.72 ns |
 |    **New** | **100000000** | **1,524,679,186.24 ns** | **25,669,473.0346 ns** | **24,011,238.6665 ns** | **1,523,225,020.36 ns** |
 |    Old | 100000000 | 1,434,421,562.85 ns | 27,815,809.8849 ns | 26,018,923.2926 ns | 1,433,289,088.55 ns |