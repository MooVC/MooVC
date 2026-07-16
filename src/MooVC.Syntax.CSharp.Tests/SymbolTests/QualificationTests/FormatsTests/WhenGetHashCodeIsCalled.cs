namespace MooVC.Syntax.CSharp.SymbolTests.QualificationTests.FormatsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEquivalentValuesThenHashCodesMatch()
    {
        // Arrange
        Qualification.Options.Formats left = Qualification.Options.Formats.Global;
        Qualification.Options.Formats right = Qualification.Options.Formats.Global;

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }
}