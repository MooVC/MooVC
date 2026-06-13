namespace MooVC.Syntax.CSharp.SymbolTests.QualificationTests.FormatsTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsEquivalentInstance()
    {
        // Arrange
        const string value = "Global";

        // Act
        Qualification.Options.Formats result = value;

        // Assert
        _ = await Assert.That(result == value).IsTrue();
    }
}