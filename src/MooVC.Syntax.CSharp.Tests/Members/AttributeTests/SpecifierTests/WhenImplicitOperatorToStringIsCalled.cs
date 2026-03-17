namespace MooVC.Syntax.CSharp.Members.AttributeTests.SpecifierTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Method = "method";

    [Test]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Attribute.Specifier? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void GivenValueThenReturnsMatchingString()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Method;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(Method);
    }
}