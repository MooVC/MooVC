namespace MooVC.Syntax.CSharp.AttributeTests.OptionsTests.StylesTests;

public sealed class WhenEqualityOperatorStylesStylesIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Options.Styles left = Attribute.Options.Styles.Inline;
        Attribute.Options.Styles right = Attribute.Options.Styles.Inline;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}