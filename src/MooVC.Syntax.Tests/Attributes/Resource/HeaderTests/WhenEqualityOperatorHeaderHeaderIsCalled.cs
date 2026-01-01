namespace MooVC.Syntax.Attributes.Resource.HeaderTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorHeaderHeaderIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Header? left = default;
        Header? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Header? left = default;
        Header right = HeaderTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Header left = HeaderTestsData.Create();
        Header right = HeaderTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Header left = HeaderTestsData.Create();
        Header right = HeaderTestsData.Create(value: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}