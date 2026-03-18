namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.PlatformTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.Platform("CustomPlatform");

        // Act
        bool result = subject.Equals(default(object));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.Platform("CustomPlatform");

        // Act
        bool result = subject.Equals("OtherPlatform");

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenPlatformWithSameValueThenReturnsTrue()
    {
        // Arrange
        var subject = new Configurations.Platform("CustomPlatform");
        object other = new Configurations.Platform("CustomPlatform");

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}