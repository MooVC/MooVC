namespace MooVC.Syntax.CSharp.VariableTests.CasingTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string PascalValue = "Pascal";
    private const string CamelValue = "Camel";

    [Test]
    public async Task GivenValueThenEqualsString()
    {
        // Arrange
        string value = CamelValue;

        // Act
        Identifier.Casing subject = value;

        // Assert
        _ = await Assert.That(subject == value).IsTrue();
        _ = await Assert.That(subject).IsEqualTo(value);
    }

    [Test]
    public async Task GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        string value = PascalValue;

        // Act
        Identifier.Casing subject = value;
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }
}