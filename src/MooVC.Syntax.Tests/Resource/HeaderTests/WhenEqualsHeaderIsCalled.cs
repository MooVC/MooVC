namespace MooVC.Syntax.Resource.HeaderTests;

public sealed class WhenEqualsHeaderIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Header subject = HeaderTestsData.Create();
        Header? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Header subject = HeaderTestsData.Create();
        Header other = HeaderTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Header subject = HeaderTestsData.Create();
        Header other = HeaderTestsData.Create(value: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}