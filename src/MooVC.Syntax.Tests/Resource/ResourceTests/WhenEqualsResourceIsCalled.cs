namespace MooVC.Syntax.Resource.ResourceTests;

public sealed class WhenEqualsResourceIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create();
        Resource? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create();
        Resource other = ResourceTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Resource subject = ResourceTestsData.Create();
        Resource other = ResourceTestsData.Create(data: Data.Undefined);

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}