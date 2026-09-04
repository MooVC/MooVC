namespace MooVC.Syntax.CSharp.ComparisonTests.TypesTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenAValueThenReturnsTheValue()
    {
        // Arrange
        Comparison.Types type = Comparison.Types.Equality;

        // Act
        string result = type.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("==");
    }
}