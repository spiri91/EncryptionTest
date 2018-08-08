using System;
using System.Collections.Generic;
using Xunit;
using IsPossibleEncryption;

namespace CandidatesTests
{
    public class CheckIfPossibleEncryption
    {
        private class ItemHolders
        {
            public ItemHolders(string item1, string item2)
            {
                this.Item1 = item1;
                this.Item2 = item2;
            }

            public string Item1 { get; }

            public string Item2 { get; }
        }

        [Fact]
        public void Should_Return_False_For_This_Candidates()
        {
            var listOfCandidates = new List<ItemHolders>()
            {
                new ItemHolders("foo", "for"),
                new ItemHolders("foo", "foor"),
                new ItemHolders("", "foo"),
                new ItemHolders("foo", null),
                new ItemHolders(null, "foo")
            };
            var sut = new Candidates();

            listOfCandidates.ForEach(c => Assert.False(sut.Check(c.Item1, c.Item2)));
        }

        [Fact]
        public void Should_Return_True_For_This_Candidates()
        {
            var listOfCandidates = new List<ItemHolders>()
            {
                new ItemHolders("foo", "baa"),
                new ItemHolders(string.Empty, null),
                new ItemHolders(null, null)
            };

            var sut = new Candidates();

            listOfCandidates.ForEach(c => Assert.True(sut.Check(c.Item1, c.Item2)));
        }
    }
}