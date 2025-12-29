namespace MooVC.Syntax.CSharp.Attributes.Project.TaskParameterTests;

public sealed class WhenEqualityOperatorTaskParameterTaskParameterIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        TaskParameter? left = default;
        TaskParameter? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TaskParameter left = TaskParameterTestsData.Create();
        TaskParameter right = TaskParameterTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TaskParameter left = TaskParameterTestsData.Create();
        TaskParameter right = TaskParameterTestsData.Create(name: new Identifier("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}