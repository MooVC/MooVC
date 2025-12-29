namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTaskTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualsTargetTaskIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        TargetTask subject = TargetTaskTestsData.Create();
        TargetTask? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        TargetTask subject = TargetTaskTestsData.Create();
        TargetTask other = TargetTaskTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask subject = TargetTaskTestsData.Create();
        TargetTask other = TargetTaskTestsData.Create(name: new Identifier("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}