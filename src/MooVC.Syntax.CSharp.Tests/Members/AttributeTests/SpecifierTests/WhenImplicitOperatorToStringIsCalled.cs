namespace MooVC.Syntax.CSharp.Members.AttributeTests.SpecifierTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Method = "method";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Attribute.Specifier? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenValueThenReturnsMatchingString()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Method;

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Method);
    }
}