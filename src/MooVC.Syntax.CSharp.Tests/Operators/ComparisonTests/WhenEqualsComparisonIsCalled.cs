namespace MooVC.Syntax.CSharp.Operators.ComparisonTests;

public sealed class WhenEqualsComparisonIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Comparison? subject = default;
        Comparison target = ComparisonTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create();
        Comparison target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create();
        Comparison target = ComparisonTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create();
        Comparison target = ComparisonTestsData.Create(@operator: Comparison.Type.GreaterThan);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}