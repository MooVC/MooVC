namespace MooVC.Syntax.CSharp.SymbolTests.QualificationTests.FormatsTests;

public sealed class WhenInequalityOperatorFormatsStringIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Qualification.Options.Formats left = Qualification.Options.Formats.Full;
        string right = "Minimum";

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}