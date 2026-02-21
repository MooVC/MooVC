namespace MooVC.Syntax.Attributes.Project.OutputTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorTaskOutputTaskOutputIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Output left = OutputTestsData.Create();
        Output right = OutputTestsData.Create(itemName: "Other");

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}