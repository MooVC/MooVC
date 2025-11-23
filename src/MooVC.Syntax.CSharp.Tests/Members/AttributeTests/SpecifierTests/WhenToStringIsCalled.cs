namespace MooVC.Syntax.CSharp.Members.AttributeTests.SpecifierTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenNoneThenReturnsEmpty()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.None;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValueThenReturnsValue()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Property;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe("property");
    }
}