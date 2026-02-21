namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorTargetTaskTargetTaskIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        TargetTask? left = default;
        TargetTask? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask left = TargetTaskTestsData.Create();
        TargetTask right = TargetTaskTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask left = TargetTaskTestsData.Create();
        TargetTask right = TargetTaskTestsData.Create(name: "Other");

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}