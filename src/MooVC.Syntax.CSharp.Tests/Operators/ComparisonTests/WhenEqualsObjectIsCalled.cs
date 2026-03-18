namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenNonComparisonObjectThenReturnsFalse()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
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