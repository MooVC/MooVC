namespace MooVC.Syntax.CSharp.Elements.IdentifierTests.CasingTests;

public sealed class WhenPropertiesAreCalled
{
    [Theory]
    [InlineData(0, true, false, false, false)]
    [InlineData(1, false, true, false, false)]
    [InlineData(2, false, false, true, false)]
    [InlineData(3, false, false, false, true)]
    public void GivenCasingThenFlagsMatch(int value, bool expectedPascal, bool expectedCamel, bool expectedKebab, bool expectedSnake)
    {
        // Arrange
        Identifier.Casing subject = value;

        // Act & Assert
        subject.IsPascal.ShouldBe(expectedPascal);
        subject.IsCamel.ShouldBe(expectedCamel);
        subject.IsKebab.ShouldBe(expectedKebab);
        subject.IsSnake.ShouldBe(expectedSnake);
    }

    [Theory]
    [InlineData(0, "Pascal")]
    [InlineData(1, "Camel")]
    [InlineData(2, "Kebab")]
    [InlineData(3, "Snake")]
    public void GivenCasingThenToStringMatches(int value, string expected)
    {
        // Arrange
        Identifier.Casing subject = value;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}