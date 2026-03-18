namespace MooVC.Syntax.CSharp.ComparisonTests.TypeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenATypeThenReturnsTheValue()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        string value = type;

        // Assert
        _ = await Assert.That(value).IsEqualTo(Comparison.Type.Equality.ToString());
    }
}