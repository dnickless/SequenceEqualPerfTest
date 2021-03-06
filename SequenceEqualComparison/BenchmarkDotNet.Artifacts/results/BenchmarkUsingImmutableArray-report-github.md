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
 |    **New** |         **1** |            **90.19 ns** |          **1.8441 ns** |          **4.6604 ns** |            **91.98 ns** |
 |    Old |         1 |           124.24 ns |          5.4093 ns |         15.9495 ns |           121.66 ns |
 |    **New** |        **10** |           **254.32 ns** |          **0.2204 ns** |          **0.1458 ns** |           **254.36 ns** |
 |    Old |        10 |           254.80 ns |          0.4814 ns |          0.3758 ns |           254.68 ns |
 |    **New** |        **20** |           **414.25 ns** |          **8.3559 ns** |         **24.3745 ns** |           **404.84 ns** |
 |    Old |        20 |           393.21 ns |          7.8761 ns |         21.0228 ns |           384.96 ns |
 |    **New** |        **50** |           **981.14 ns** |          **0.8156 ns** |          **0.6368 ns** |           **981.00 ns** |
 |    Old |        50 |           804.46 ns |         41.1471 ns |         42.2550 ns |           781.35 ns |
 |    **New** |       **100** |         **1,591.00 ns** |         **31.8425 ns** |         **88.2353 ns** |         **1,547.94 ns** |
 |    Old |       100 |         1,682.78 ns |          0.7822 ns |          0.5656 ns |         1,682.87 ns |
 |    **New** |       **200** |         **3,289.89 ns** |          **1.8604 ns** |          **1.1071 ns** |         **3,289.85 ns** |
 |    Old |       200 |         3,245.88 ns |          2.5214 ns |          1.8231 ns |         3,245.32 ns |
 |    **New** |       **500** |         **8,165.66 ns** |        **133.2801 ns** |        **104.0563 ns** |         **8,129.29 ns** |
 |    Old |       500 |         7,300.42 ns |        241.9773 ns |        383.8017 ns |         7,083.78 ns |
 |    **New** |      **1000** |        **16,156.14 ns** |          **6.1160 ns** |          **4.7749 ns** |        **16,156.50 ns** |
 |    Old |      1000 |        15,857.85 ns |          6.7619 ns |          5.6465 ns |        15,856.75 ns |
 |    **New** |     **10000** |       **168,572.35 ns** |      **3,347.5304 ns** |      **9,386.8343 ns** |       **162,106.53 ns** |
 |    Old |     10000 |       144,287.00 ns |      7,381.1938 ns |      7,579.9419 ns |       140,227.90 ns |
 |    **New** |   **1000000** |    **16,150,152.98 ns** |     **71,537.2376 ns** |     **55,851.5648 ns** |    **16,135,687.01 ns** |
 |    Old |   1000000 |    14,042,564.71 ns |     39,200.0795 ns |     34,749.8460 ns |    14,033,573.52 ns |
 |    **New** | **100000000** | **1,486,328,273.92 ns** | **29,264,105.5581 ns** | **28,741,261.8645 ns** | **1,487,017,566.15 ns** |
 |    Old | 100000000 | 1,477,435,980.65 ns | 27,575,280.3571 ns | 28,317,780.0445 ns | 1,470,555,259.30 ns |
