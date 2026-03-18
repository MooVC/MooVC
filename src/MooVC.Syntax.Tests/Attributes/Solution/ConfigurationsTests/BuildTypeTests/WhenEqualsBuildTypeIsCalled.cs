namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.BuildTypeTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualsBuildTypeIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.BuildType("Custom");
        Configurations.BuildType? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new Configurations.BuildType("Custom");
        var other = new Configurations.BuildType("Custom");

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.BuildType("Custom");
        var other = new Configurations.BuildType("Other");

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}