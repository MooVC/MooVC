namespace MooVC.Syntax.CSharp.Members.AttributeTests.SpecifierTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenNoneThenReturnsEmpty()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.None;

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValueThenReturnsValue()
    {
        // Arrange
        Attribute.Specifier subject = Attribute.Specifier.Property;

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo("property");
    }
}