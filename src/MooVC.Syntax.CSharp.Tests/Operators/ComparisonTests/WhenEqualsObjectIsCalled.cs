namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNonComparisonObjectThenReturnsFalse()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenComparisonObjectThenReturnsResultOfComparisonEquals()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create();
        object target = ComparisonTestsData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }
}