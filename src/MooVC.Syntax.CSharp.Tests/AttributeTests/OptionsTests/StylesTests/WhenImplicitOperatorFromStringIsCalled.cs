namespace MooVC.Syntax.CSharp.AttributeTests.OptionsTests.StylesTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsEquivalentInstance()
    {
        // Arrange
        const string value = "Inline";

        // Act
        Attribute.Options.Styles result = value;

        // Assert
        _ = await Assert.That(result == value).IsTrue();
    }
}