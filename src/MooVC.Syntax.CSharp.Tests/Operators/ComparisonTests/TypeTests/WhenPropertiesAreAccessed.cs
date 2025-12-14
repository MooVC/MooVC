namespace MooVC.Syntax.CSharp.Operators.ComparisonTests.TypeTests;

public sealed class WhenPropertiesAreAccessed
{
    [Fact]
    public void GivenInequalityThenFlagsReflectValue()
    {
        // Arrange
        Comparison.Type subject = Comparison.Type.Inequality;

        // Act
        bool isInequality = subject.IsInequality;
        bool isEquality = subject.IsEquality;
        string representation = subject.ToString();

        // Assert
        isInequality.ShouldBeTrue();
        isEquality.ShouldBeFalse();
        representation.ShouldBe("!=");
    }
}