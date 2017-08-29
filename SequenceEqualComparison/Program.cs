using System;
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
        private IEnumerable<int> _first;
        private IEnumerable<int> _second;

        [Params(1, 10, 20, 50, 100, 200, 500, 1000, 10000, 1000000, int.MaxValue)]
        public int Count;

        [GlobalSetup]
        public void Initialize()
        {
            _first = Initialize(Enumerable.Range(1, Count));
            _second = Initialize(Enumerable.Range(1, Count));

            CheckCorrectness();
        }

        private void CheckCorrectness()
        {
            if (!_first.SequenceEqual(_second))
            {
                throw new Exception("wrong test setup, we want equal collections");
            }

            if (!_first.SequenceEqualNew(_second))
            {
                throw new Exception("wrong new implementation");
            }
        }

        protected abstract IEnumerable<int> Initialize(IEnumerable<int> range);

        [Benchmark(Description = "New")]
        public void TestArrayNew()
        {
            bool b = _first.SequenceEqualNew(_second);
        }

        [Benchmark(Description = "Old")]
        public void TestArrayOld()
        {
            bool b = _first.SequenceEqual(_second);
        }
    }

    public class BenchmarkUsingArray : BenchmarkBase
    {
        protected override IEnumerable<int> Initialize(IEnumerable<int> range)
        {
            return range.ToArray();
        }
    }

    public class BenchmarkUsingList : BenchmarkBase
    {
        protected override IEnumerable<int> Initialize(IEnumerable<int> range)
        {
            return range.ToList();
        }
    }

    public class BenchmarkUsingImmutableList : BenchmarkBase
    {
        protected override IEnumerable<int> Initialize(IEnumerable<int> range)
        {
            return ImmutableList.Create(range.ToArray());
        }
    }

    public class BenchmarkUsingSortedSet : BenchmarkBase
    {
        protected override IEnumerable<int> Initialize(IEnumerable<int> range)
        {
            return new SortedSet<int>(range);
        }
    }

    public class BenchmarkUsingIEnumerable : BenchmarkBase
    {
        protected override IEnumerable<int> Initialize(IEnumerable<int> range)
        {
            return range;
        }
    }
}