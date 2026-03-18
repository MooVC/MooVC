namespace MooVC.Syntax.Project.ParameterTests;

public sealed class WhenEqualsTaskParameterIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create();
        Parameter? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create();
        Parameter other = ParameterTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create();
        Parameter other = ParameterTestsData.Create(name: new Name("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}