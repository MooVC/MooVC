namespace MooVC.Linq.PagingTests;

using Xunit;

public sealed class WhenIsDefaultIsCalled
{
    [Fact]
    public void GivenThePagingDefaultThenAPositiveResponseIsReturned()
    {
        Assert.True(Paging.Default.IsDefault);
    }

    [Fact]
    public void GivenAPagingInstanceThatDoesNotUseDefaultSettingsThenANegativeResponseIsReturned()
    {
        var paging = new Paging(page: 2, size: 5);

        Assert.False(paging.IsDefault);
    }
}