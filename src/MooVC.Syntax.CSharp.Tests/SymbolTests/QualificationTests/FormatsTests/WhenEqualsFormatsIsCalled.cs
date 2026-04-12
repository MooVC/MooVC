namespace MooVC.Syntax.CSharp.SymbolTests.QualificationTests.FormatsTests;

public sealed class WhenEqualsFormatsIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Qualification.Options.Formats subject = Qualification.Options.Formats.Full;
        Qualification.Options.Formats other = Qualification.Options.Formats.Global;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}