namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorTargetTaskTargetTaskIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask left = TargetTaskTestsData.Create();
        TargetTask right = TargetTaskTestsData.Create(name: new Name("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}