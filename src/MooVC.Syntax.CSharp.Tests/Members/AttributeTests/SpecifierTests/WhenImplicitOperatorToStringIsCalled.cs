namespace MooVC.Syntax.CSharp.Members.AttributeTests.SpecifierTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Method = "method";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Attribute.Specifier? subject = default;

        // Act
        Func<string> act = () => (string)subject!;

        // Assert
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(act);
        exception.ParamName.ShouldBe(nameof(subject));
    }

    [Fact]
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