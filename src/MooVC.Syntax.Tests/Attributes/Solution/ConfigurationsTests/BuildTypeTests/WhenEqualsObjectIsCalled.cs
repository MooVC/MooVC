namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.BuildTypeTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.BuildType("Custom");

        // Act
        bool result = subject.Equals(null);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.BuildType("Custom");

        // Act
        bool result = subject.Equals("Other");

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenBuildTypeWithSameValueThenReturnsTrue()
    {
        // Arrange
        var subject = new Configurations.BuildType("Custom");
        object other = new Configurations.BuildType("Custom");

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}