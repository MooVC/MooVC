namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTests;

public sealed class WhenEqualityOperatorTargetTargetIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
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