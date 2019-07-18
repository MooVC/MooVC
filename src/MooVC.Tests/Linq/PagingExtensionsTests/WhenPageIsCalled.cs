namespace MooVC.Linq.PagingExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Moq;
    using Xunit;

    public sealed class WhenPageIsCalled
    {
        [Fact]
        public void GivenNoPagingThenTheQueryAbleIsReturned()
        {
            IQueryable<int> expected = Enumerable.Empty<int>().AsQueryable();
            IQueryable<int> actual = expected.Page(null);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenPagingThenApplyIsCalled()
        {
            var paging = new Mock<Paging>(Paging.FirstPage, Paging.MinimumSize);

            IQueryable<int> expected = Enumerable.Empty<int>().AsQueryable();

            _ = paging
                .Setup(pg => pg.Apply(It.Is<IQueryable<int>>(value => value == expected)))
                .Returns(expected);

            IQueryable<int> actual = expected.Page(paging.Object);

            paging.Verify(pg => pg.Apply(It.IsAny<IQueryable<int>>()), Times.Once);

            Assert.Equal(expected, actual);
        }
    }
}