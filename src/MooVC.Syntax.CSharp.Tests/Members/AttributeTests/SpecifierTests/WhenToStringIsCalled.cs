namespace MooVC.Syntax.CSharp.Members.AttributeTests.SpecifierTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenNoneThenReturnsEmpty()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.None;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Test]
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