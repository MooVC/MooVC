namespace MooVC.Syntax.CSharp.ComparisonTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenComparisonObjectThenReturnsResultOfComparisonEquals()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create();
        object target = ComparisonTestsData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonComparisonObjectThenReturnsFalse()
    {
        // Arrange
        Comparison subject = ComparisonTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}