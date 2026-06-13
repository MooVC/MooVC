namespace MooVC.Syntax.Solution.ConfigurationsTests.BuildTypeTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        const string value = "Custom";

        // Act
        Configurations.BuildType subject = value;

        // Assert
        _ = await Assert.That(subject == value).IsTrue();
        _ = await Assert.That(subject).IsEqualTo(value);
    }
}