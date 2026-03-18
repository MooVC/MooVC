namespace MooVC.Syntax.CSharp.ComparisonTests.TypeTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenAValueThenReturnsTheValue()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        string result = type.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo("==");
    }
}