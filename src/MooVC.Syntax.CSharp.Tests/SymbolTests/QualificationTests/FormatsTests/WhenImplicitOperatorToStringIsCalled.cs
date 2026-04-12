namespace MooVC.Syntax.CSharp.SymbolTests.QualificationTests.FormatsTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUnderlyingString()
    {
        // Arrange
        Qualification.Options.Formats subject = Qualification.Options.Formats.Full;

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo("Full");
    }
}