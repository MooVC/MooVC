namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.BuildTypeTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.BuildType("Custom");

        // Act
        bool result = subject.Equals(default(object));

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var subject = new Configurations.BuildType("Custom");

        // Act
        bool result = subject.Equals("Other");

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenBuildTypeWithSameValueThenReturnsTrue()
    {
        // Arrange
        var subject = new Configurations.BuildType("Custom");
        object other = new Configurations.BuildType("Custom");

        // Act
        bool result = subject.Equals(other);

        // Assert
        await Assert.That(result).IsTrue();
    }
}