namespace MooVC.Syntax.CSharp.SymbolTests.QualificationTests.FormatsTests;

public sealed class WhenEqualityOperatorFormatsFormatsIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Qualification.Options.Formats left = Qualification.Options.Formats.Full;
        Qualification.Options.Formats right = Qualification.Options.Formats.Full;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}