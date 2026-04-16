namespace MooVC.Syntax.CSharp.ComparisonTests;

public sealed class WhenEqualsComparisonIsCalled
{
    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create();
        Comparison target = ComparisonTestsData.Create(@operator: Comparison.Types.GreaterThan);

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create();
        Comparison target = ComparisonTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Comparison? subject = default;
        Comparison target = ComparisonTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create();
        Comparison target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}