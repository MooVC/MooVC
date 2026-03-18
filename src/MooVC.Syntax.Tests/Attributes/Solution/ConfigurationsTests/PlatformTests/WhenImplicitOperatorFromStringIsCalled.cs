namespace MooVC.Syntax.Attributes.Solution.ConfigurationsTests.PlatformTests;

using MooVC.Syntax.Attributes.Solution;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        const string value = "ARM";

        // Act
        Configurations.Platform subject = value;

        // Assert
        await Assert.That((subject == value)).IsTrue();
        await Assert.That(subject.Equals(value)).IsTrue();
    }
}