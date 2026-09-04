namespace MooVC.Syntax.CSharp.AttributeTests.SpecifiersTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Method = "method";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Attribute.Specifiers? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenValueThenReturnsMatchingString()
    {
        // Arrange
        Attribute.Specifiers subject = Attribute.Specifiers.Method;

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Method);
    }
}