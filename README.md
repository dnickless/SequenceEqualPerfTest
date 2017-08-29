# SequenceEqualPerfTest

Just a temporary repository to test if the suggested change to the Linq SequenceEqual method at https://github.com/dotnet/corefx/pull/23368 helps performance or does the opposite for the various collection types.

Since I'm using Benchmark.NET we are currently limited to x64 architecture.

Results (calculated using Benchmark.NET) on my machine can be found at:

https://github.com/dnickless/SequenceEqualPerfTest/tree/master/SequenceEqualComparison/BenchmarkDotNet.Artifacts/results
