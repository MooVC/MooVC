namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorResourceResourceIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Resource? left = default;
        Resource? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Resource? left = default;
        Resource right = ResourceTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Resource left = ResourceTestsData.Create();
        Resource right = ResourceTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Resource left = ResourceTestsData.Create();
        Resource right = ResourceTestsData.Create(customToolNamespace: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}