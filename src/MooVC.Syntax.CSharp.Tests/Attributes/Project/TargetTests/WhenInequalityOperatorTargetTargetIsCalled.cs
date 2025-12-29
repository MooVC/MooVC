namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTests;

public sealed class WhenInequalityOperatorTargetTargetIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Target left = TargetTestsData.Create();
        Target right = TargetTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}