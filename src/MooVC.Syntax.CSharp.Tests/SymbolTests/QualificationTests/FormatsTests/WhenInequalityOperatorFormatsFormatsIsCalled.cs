namespace MooVC.Syntax.CSharp.SymbolTests.QualificationTests.FormatsTests;

public sealed class WhenInequalityOperatorFormatsFormatsIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Qualification.Options.Formats left = Qualification.Options.Formats.Full;
        Qualification.Options.Formats right = Qualification.Options.Formats.Global;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}