namespace MooVC.Syntax.Attributes.Project.OutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorTaskOutputTaskOutputIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Output? left = default;
        Output? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Output left = OutputTestsData.Create();
        Output right = OutputTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Output left = OutputTestsData.Create();
        Output right = OutputTestsData.Create(itemName: "Other");

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}