namespace MooVC.Syntax.IdentifierTests.OptionsTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenOptionsThenContainsConfiguredPropertyValue()
    {
        // Arrange
        var subject = new Identifier.Options { Casing = Identifier.Casing.Pascal };

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).Contains(nameof(Identifier.Options.Casing));
        _ = await Assert.That(result).Contains(nameof(Identifier.Casing.Pascal));
    }
}