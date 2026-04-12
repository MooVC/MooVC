namespace MooVC.Syntax.CSharp.AttributeTests.OptionsTests.StylesTests;

public sealed class WhenEqualsStylesIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Attribute.Options.Styles subject = Attribute.Options.Styles.Inline;
        Attribute.Options.Styles other = Attribute.Options.Styles.Separate;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}