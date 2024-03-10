namespace MooVC.Linq.PagingTests;

public sealed class WhenIsDefaultIsCalled
{
    [Fact]
    public void GivenThePagingDefaultThenAPositiveResponseIsReturned()
    {
        // Arrange
        Paging paging = Paging.Default;

        // Act
        bool isDefault = paging.IsDefault;

        // Assert
        _ = isDefault.Should().BeTrue();
    }

    [Fact]
    public void GivenAPagingInstanceThatDoesNotUseDefaultSettingsThenANegativeResponseIsReturned()
    {
        // Arrange
        var paging = new Paging(page: 2, size: 5);

        // Act
        bool isDefault = paging.IsDefault;

        // Assert
        _ = isDefault.Should().BeFalse();
    }
}