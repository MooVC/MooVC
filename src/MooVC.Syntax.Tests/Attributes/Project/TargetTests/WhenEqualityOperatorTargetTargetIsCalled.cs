namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorTargetTargetIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Target? left = default;
        Target? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Target left = TargetTestsData.Create();
        Target right = TargetTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Target left = TargetTestsData.Create();
        Target right = TargetTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}