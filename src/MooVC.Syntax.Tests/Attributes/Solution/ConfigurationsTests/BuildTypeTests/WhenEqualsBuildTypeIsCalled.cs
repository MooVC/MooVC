namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.BuildTypeTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualsBuildTypeIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
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