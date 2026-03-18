namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.BuildTypeTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.BuildType("Custom");

        // Act
        bool result = subject.Equals(default(object));

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.BuildType("Custom");

        // Act
        bool result = subject.Equals("Other");

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
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