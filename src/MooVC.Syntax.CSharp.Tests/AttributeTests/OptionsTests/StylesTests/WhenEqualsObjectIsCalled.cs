namespace MooVC.Syntax.CSharp.AttributeTests.OptionsTests.StylesTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Attribute.Options.Styles subject = Attribute.Options.Styles.Separate;
        object other = Attribute.Options.Styles.Separate;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}