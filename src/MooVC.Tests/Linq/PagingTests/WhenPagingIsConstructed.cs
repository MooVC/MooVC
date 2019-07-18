namespace MooVC.Linq.PagingTests
{
    using System;
    using Xunit;

    public sealed class WhenPagingIsConstructed
    {
        [Theory]
        [InlineData(Paging.FirstPage, Paging.MinimumSize)]
        [InlineData(Paging.FirstPage + 5, Paging.MinimumSize + 10)]
        [InlineData(Paging.FirstPage, ushort.MaxValue)]
        [InlineData(ushort.MaxValue, Paging.MinimumSize)]
        public void GivenAValidPageAndSizeThenThePropertiesAreSetToMatch(ushort page, ushort size)
        {
            var paging = new Paging(page: page, size: size);

            Assert.Equal(page, paging.Page);
            Assert.Equal(size, paging.Size);
        }

        [Theory]
        [InlineData(Paging.MinimumSize)]
        [InlineData(Paging.MinimumSize + 10)]
        [InlineData(ushort.MaxValue)]
        public void GivenAnInvalidPageAndAValidSizeThenThePageIsSetToTheFirstPageAndTheSizeIsSetToTheConfigured(ushort size)
        {
            ushort page = Math.Min((ushort)(Paging.FirstPage - 1), ushort.MinValue);

            var paging = new Paging(page: page, size: size);

            Assert.Equal(Paging.FirstPage, paging.Page);
            Assert.Equal(size, paging.Size);
        }

        [Theory]
        [InlineData(Paging.FirstPage)]
        [InlineData(Paging.FirstPage + 5)]
        [InlineData(ushort.MaxValue)]
        public void GivenAnValidPageAndAnInvalidSizeThenThePageIsSetToTheConfiguredAndTheSizeIsSetToTheMinimum(ushort page)
        {
            ushort size = Math.Min((ushort)(Paging.MinimumSize - 1), ushort.MinValue);

            var paging = new Paging(page: page, size: size);

            Assert.Equal(page, paging.Page);
            Assert.Equal(Paging.MinimumSize, paging.Size);
        }
    }
}