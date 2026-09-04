namespace MooVC.Syntax.IdentifierTests.CasingTests;

public sealed class WhenPropertiesAreCalled
{
    [Test]
    [Arguments("Pascal", true, false, false, false)]
    [Arguments("Camel", false, true, false, false)]
    [Arguments("Kebab", false, false, true, false)]
    [Arguments("Snake", false, false, false, true)]
    public async Task GivenCasingThenFlagsMatch(string value, bool expectedPascal, bool expectedCamel, bool expectedKebab, bool expectedSnake)
    {
        // Arrange
        Identifier.Casing subject = value;

        // Act & Assert
        _ = await Assert.That(subject.IsPascal).IsEqualTo(expectedPascal);
        _ = await Assert.That(subject.IsCamel).IsEqualTo(expectedCamel);
        _ = await Assert.That(subject.IsKebab).IsEqualTo(expectedKebab);
        _ = await Assert.That(subject.IsSnake).IsEqualTo(expectedSnake);
    }

    [Test]
    [Arguments("Pascal")]
    [Arguments("Camel")]
    [Arguments("Kebab")]
    [Arguments("Snake")]
    public async Task GivenCasingThenToStringMatches(string value)
    {
        // Arrange
        Identifier.Casing subject = value;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }
}