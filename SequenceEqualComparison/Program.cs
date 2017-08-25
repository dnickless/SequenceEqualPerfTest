using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;

namespace SequenceEqualComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkUsingIEnumerable>();
            BenchmarkRunner.Run<BenchmarkUsingArray>();
            BenchmarkRunner.Run<BenchmarkUsingList>();
            BenchmarkRunner.Run<BenchmarkUsingImmutableList>();
            BenchmarkRunner.Run<BenchmarkUsingSortedSet>();
        }
    }

    [CoreJob]
    public abstract class BenchmarkBase
    {
        protected IEnumerable<int> l1;
        protected IEnumerable<int> l2;

        [Params(1, 10, 20, 50, 100, 200, 500, 1000, 10000, 1000000, int.MaxValue)]
        public int Count;

        [GlobalSetup]
        public void Initialize()
        {
            Initialize(Enumerable.Range(1, Count));
        }

        protected abstract void Initialize(IEnumerable<int> range);

        [Benchmark(Description = "New")]
        public void TestArrayNew()
        {
            bool b = l1.SequenceEqualNew(l2);
        }

        [Benchmark(Description = "Old")]
        public void TestArrayOld()
        {
            bool b = l1.SequenceEqual(l2);
        }
    }

    public class BenchmarkUsingArray : BenchmarkBase
    {
        protected override void Initialize(IEnumerable<int> range)
        {
            l1 = range.ToArray();
            l2 = range.ToArray();
        }
    }

    public class BenchmarkUsingList : BenchmarkBase
    {
        protected override void Initialize(IEnumerable<int> range)
        {
            l1 = range.ToList();
            l2 = range.ToList();
        }
    }

    public class BenchmarkUsingImmutableList : BenchmarkBase
    {
        protected override void Initialize(IEnumerable<int> range)
        {
            l1 = ImmutableList.Create(range.ToArray());
            l2 = ImmutableList.Create(range.ToArray());
        }
    }

    public class BenchmarkUsingSortedSet : BenchmarkBase
    {
        protected override void Initialize(IEnumerable<int> range)
        {
            l1 = new SortedSet<int>(range);
            l2 = new SortedSet<int>(range);
        }
    }

    public class BenchmarkUsingIEnumerable : BenchmarkBase
    {
        protected override void Initialize(IEnumerable<int> range)
        {
            l1 = range;
            l2 = range;
        }
    }
}