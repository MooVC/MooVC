namespace MooVC.Syntax.CSharp.ComparisonTests.TypesTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenATypeThenReturnsTheValue()
    {
        // Arrange
        Comparison.Types type = Comparison.Types.Equality;

        // Act
        string value = type;

        // Assert
        _ = await Assert.That(value).IsEqualTo(Comparison.Types.Equality.ToString());
    }
}