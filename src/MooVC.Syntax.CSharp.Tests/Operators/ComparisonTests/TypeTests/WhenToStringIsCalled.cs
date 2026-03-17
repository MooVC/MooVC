namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenAValueThenReturnsTheValue()
    {
        // Arrange
        Comparison.Type type = Comparison.Type.Equality;

        // Act
        string result = type.ToString();

        // Assert
        result.ShouldBe("==");
    }
}