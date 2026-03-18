namespace MooVC.Syntax.CSharp.Elements.VariableTests.CasingTests;

using MooVC.Syntax.Elements;

public sealed class WhenPropertiesAreCalled
{
    [Test]
    [Arguments(0, true, false, false, false)]
    [Arguments(1, false, true, false, false)]
    [Arguments(2, false, false, true, false)]
    [Arguments(3, false, false, false, true)]
    public async Task GivenCasingThenFlagsMatch(int value, bool expectedPascal, bool expectedCamel, bool expectedKebab, bool expectedSnake)
    {
        // Arrange
        Identifier.Casing subject = value;

        // Act & Assert
        await Assert.That(subject.IsPascal).IsEqualTo(expectedPascal);
        await Assert.That(subject.IsCamel).IsEqualTo(expectedCamel);
        await Assert.That(subject.IsKebab).IsEqualTo(expectedKebab);
        await Assert.That(subject.IsSnake).IsEqualTo(expectedSnake);
    }

    [Test]
    [Arguments(0, "Pascal")]
    [Arguments(1, "Camel")]
    [Arguments(2, "Kebab")]
    [Arguments(3, "Snake")]
    public async Task GivenCasingThenToStringMatches(int value, string expected)
    {
        // Arrange
        Identifier.Casing subject = value;

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(expected);
    }
}