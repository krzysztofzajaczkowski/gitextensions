using System;
using System.Linq;
using GitExtUtils;
using GitUIPluginInterfaces;
using NUnit.Framework;

namespace GitCommandsTests
{
    [TestFixture]
    public sealed class ArrayExtensionsTests
    {
        [Test]
        public void Subsequence_throws_argument_out_of_range_exception_for_index_less_than_zero()
        {
            var nums = Enumerable.Range(0, 10).ToArray();
            Assert.Throws<ArgumentOutOfRangeException>(() => nums.Subsequence(-1, 1));
        }

        [Test]
        public void Subsequence_throws_argument_exception_for_index_greater_equal_than_length()
        {
            var nums = Enumerable.Range(0, 10).ToArray();
            Assert.Throws<ArgumentException>(() => nums.Subsequence(nums.Length, 1));
        }

        [Test]
        public void Subsequence_throws_overflow_exception_for_length_less_than_zero()
        {
            var nums = Enumerable.Range(0, 10).ToArray();
            Assert.Throws<OverflowException>(() => nums.Subsequence(0, -1));
        }

        [Test]
        public void Subsequence_throws_argument_exception_for_length_greater_than_array_length()
        {
            var nums = Enumerable.Range(0, 10).ToArray();
            Assert.Throws<ArgumentException>(() => nums.Subsequence(0, nums.Length + 1));
        }

        [Test]
        public void Subsequence()
        {
            var nums = Enumerable.Range(0, 10).ToArray();

            Assert.AreEqual(
                new[] { 0, 1, 2, 3 },
                nums.Subsequence(0, 4));
            Assert.AreEqual(
                new[] { 1, 2, 3, 4 },
                nums.Subsequence(1, 4));

            Assert.AreEqual(
                nums,
                nums.Subsequence(0, 10));

            Assert.AreEqual(
                Array.Empty<int>(),
                nums.Subsequence(0, 0));

            Assert.AreEqual(
                Array.Empty<int>(),
                nums.Subsequence(9, 0));
        }

        [Test]
        public void Append()
        {
            Assert.AreEqual(
                new[] { 0, 1 },
                new[] { 0 }.Append(1));
            Assert.AreEqual(
                new[] { 0 },
                Array.Empty<int>().Append(0));
            Assert.AreEqual(
                new[] { 0, 1, 2 },
                Array.Empty<int>().Append(0).Append(1).Append(2));
        }
    }
}
