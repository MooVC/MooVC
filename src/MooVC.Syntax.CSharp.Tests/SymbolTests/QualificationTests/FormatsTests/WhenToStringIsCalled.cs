namespace MooVC.Syntax.CSharp.SymbolTests.QualificationTests.FormatsTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsValue()
    {
        // Arrange
        Qualification.Options.Formats subject = Qualification.Options.Formats.Minimum;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("Minimum");
    }
}