namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenStringThenReturnsKind()
    {
        // Arrange
        const string Value = "record";

        // Act
        Struct.Kind result = Value;

        // Assert
        await Assert.That(result).IsEqualTo(Struct.Kind.Record);
    }
}