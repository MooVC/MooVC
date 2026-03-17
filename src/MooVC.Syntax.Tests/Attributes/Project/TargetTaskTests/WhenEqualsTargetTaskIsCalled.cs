namespace MooVC.Syntax.Attributes.Project.TargetTaskTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsTargetTaskIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        TargetTask subject = TargetTaskTestsData.Create();
        TargetTask other = TargetTaskTestsData.Create(name: new Name("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}