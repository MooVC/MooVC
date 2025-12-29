namespace MooVC.Syntax.CSharp.Attributes.Project.TaskOutputTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualityOperatorTaskOutputTaskOutputIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        TaskOutput? left = default;
        TaskOutput? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TaskOutput left = TaskOutputTestsData.Create();
        TaskOutput right = TaskOutputTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TaskOutput left = TaskOutputTestsData.Create();
        TaskOutput right = TaskOutputTestsData.Create(itemName: new Identifier("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}