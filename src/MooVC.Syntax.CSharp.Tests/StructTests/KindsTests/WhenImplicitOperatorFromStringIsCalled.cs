namespace MooVC.Syntax.CSharp.StructTests.KindsTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenStringThenReturnsKind()
    {
        // Arrange
        const string Value = "record";

        // Act
        Struct.Kinds result = Value;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Struct.Kinds.Record);
    }
}