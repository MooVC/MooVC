namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorResourceResourceIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Resource? left = default;
        Resource? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Resource? left = default;
        Resource right = ResourceTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Resource left = ResourceTestsData.Create();
        Resource right = ResourceTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Resource left = ResourceTestsData.Create();
        Resource right = ResourceTestsData.Create(customToolNamespace: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}