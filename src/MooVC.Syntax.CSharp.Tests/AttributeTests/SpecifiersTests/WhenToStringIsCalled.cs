namespace MooVC.Syntax.CSharp.AttributeTests.SpecifiersTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenNoneThenReturnsEmpty()
    {
        // Arrange
        Attribute.Specifiers subject = Attribute.Specifiers.None;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValueThenReturnsValue()
    {
        // Arrange
        Attribute.Specifiers subject = Attribute.Specifiers.Property;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("property");
    }
}