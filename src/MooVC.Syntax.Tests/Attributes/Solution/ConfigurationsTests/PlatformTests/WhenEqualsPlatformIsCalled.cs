namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.PlatformTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualsPlatformIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.Platform("CustomPlatform");
        Configurations.Platform? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new Configurations.Platform("CustomPlatform");
        var other = new Configurations.Platform("CustomPlatform");

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.Platform("CustomPlatform");
        var other = new Configurations.Platform("OtherPlatform");

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}