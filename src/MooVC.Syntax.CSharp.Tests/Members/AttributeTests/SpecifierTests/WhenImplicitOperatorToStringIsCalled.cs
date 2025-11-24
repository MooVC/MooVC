namespace MooVC.Syntax.CSharp.Members.AttributeTests.SpecifierTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Method = "method";

    [Fact]
    public void GivenNullSubjectThenEmptyStringIsReturned()
    {
        // Arrange
        Attribute.Specifier? subject = default;

        // Act
        string result = subject;

        // Assert
        result.ShouldBeEmpty();
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