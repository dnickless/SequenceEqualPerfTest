using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            BenchmarkRunner.Run<BenchmarkUsingArray>();
            BenchmarkRunner.Run<BenchmarkUsingArraySegment>();
            BenchmarkRunner.Run<BenchmarkUsingBindingList>();
            BenchmarkRunner.Run<BenchmarkUsingCollection>();
            BenchmarkRunner.Run<BenchmarkUsingIEnumerable>();
            BenchmarkRunner.Run<BenchmarkUsingImmutableArray>();
            BenchmarkRunner.Run<BenchmarkUsingImmutableList>();
            BenchmarkRunner.Run<BenchmarkUsingList>();
            BenchmarkRunner.Run<BenchmarkUsingSortedSet>();
        }
    }

    [CoreJob]
    public abstract class BenchmarkBase<T> where T : IEnumerable<int>
    {
        private T _first;
        private T _second;

        [Params(1, 10, 20, 50, 100, 200, 500, 1000, 10000, 1000000, 100000000)]
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

            if (_first.Count() != Count || _second.Count() != Count)
            {
                throw new Exception("wrong collection initializer");
            }
        }

        protected abstract T Initialize(IEnumerable<int> range);

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

    public class BenchmarkUsingArray : BenchmarkBase<int[]>
    {
        protected override int[] Initialize(IEnumerable<int> range)
        {
            return range.ToArray();
        }
    }

    public class BenchmarkUsingList : BenchmarkBase<List<int>>
    {
        protected override List<int> Initialize(IEnumerable<int> range)
        {
            return range.ToList();
        }
    }

    public class BenchmarkUsingImmutableList : BenchmarkBase<ImmutableList<int>>
    {
        protected override ImmutableList<int> Initialize(IEnumerable<int> range)
        {
            return ImmutableList.Create(range.ToArray());
        }
    }

    public class BenchmarkUsingSortedSet : BenchmarkBase<SortedSet<int>>
    {
        protected override SortedSet<int> Initialize(IEnumerable<int> range)
        {
            return new SortedSet<int>(range);
        }
    }

    public class BenchmarkUsingIEnumerable : BenchmarkBase<IEnumerable<int>>
    {
        protected override IEnumerable<int> Initialize(IEnumerable<int> range)
        {
            return range;
        }
    }

    public class BenchmarkUsingImmutableArray : BenchmarkBase<ImmutableArray<int>>
    {
        protected override ImmutableArray<int> Initialize(IEnumerable<int> range)
        {
            return ImmutableArray.Create(range.ToArray());
        }
    }

    public class BenchmarkUsingBindingList : BenchmarkBase<BindingList<int>>
    {
        protected override BindingList<int> Initialize(IEnumerable<int> range)
        {
            return new BindingList<int>(range.ToList());
        }
    }

    public class BenchmarkUsingArraySegment : BenchmarkBase<ArraySegment<int>>
    {
        protected override ArraySegment<int> Initialize(IEnumerable<int> range)
        {
            return new ArraySegment<int>(range.ToArray());
        }
    }

    public class BenchmarkUsingCollection : BenchmarkBase<Collection<int>>
    {
        protected override Collection<int> Initialize(IEnumerable<int> range)
        {
            return new Collection<int>(range.ToArray());
        }
    }
}