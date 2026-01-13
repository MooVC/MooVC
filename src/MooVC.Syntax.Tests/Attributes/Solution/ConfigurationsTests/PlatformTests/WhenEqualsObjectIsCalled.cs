namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.PlatformTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.Platform("CustomPlatform");

        // Act
        bool result = subject.Equals(default(object));

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.Platform("CustomPlatform");

        // Act
        bool result = subject.Equals("OtherPlatform");

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenPlatformWithSameValueThenReturnsTrue()
    {
        // Arrange
        var subject = new Configurations.Platform("CustomPlatform");
        object other = new Configurations.Platform("CustomPlatform");

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}