namespace MooVC.Syntax.CSharp.AttributeTests.OptionsTests.StylesTests;

public sealed class WhenInequalityOperatorStylesStringIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Options.Styles left = Attribute.Options.Styles.Inline;
        string right = "Separate";

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}