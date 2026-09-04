namespace MooVC.Syntax.CSharp.AttributeTests.OptionsTests.StylesTests;

public sealed class WhenInequalityOperatorStylesStylesIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Options.Styles left = Attribute.Options.Styles.Inline;
        Attribute.Options.Styles right = Attribute.Options.Styles.Separate;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}