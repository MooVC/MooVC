namespace MooVC.Syntax.CSharp.Elements.VariableTests.CasingTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorFromIntIsCalled
{
    private const int PascalValue = 0;
    private const int CamelValue = 1;

    [Test]
    public async Task GivenValueThenEqualsInt()
    {
        // Arrange
        int value = CamelValue;

        // Act
        Identifier.Casing subject = value;

        // Assert
        _ = await Assert.That((subject == value)).IsTrue();
        _ = await Assert.That(subject.Equals(value)).IsTrue();
    }

    [Test]
    public async Task GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        int value = PascalValue;

        // Act
        Identifier.Casing subject = value;
        int result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(value);
    }
}