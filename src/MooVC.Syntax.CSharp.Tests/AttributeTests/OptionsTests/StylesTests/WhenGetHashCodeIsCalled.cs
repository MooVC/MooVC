namespace MooVC.Syntax.CSharp.AttributeTests.OptionsTests.StylesTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEquivalentValuesThenHashCodesMatch()
    {
        // Arrange
        Attribute.Options.Styles left = Attribute.Options.Styles.Inline;
        Attribute.Options.Styles right = Attribute.Options.Styles.Inline;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }
}