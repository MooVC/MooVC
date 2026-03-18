namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenEqualsResultIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        Result? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        Result other = ResultTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        Result other = ResultTestsData.Create(type: new Symbol { Name = "Other" });

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}