namespace MooVC.Syntax.Solution.ItemTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Item subject = ItemTestsData.Create();
        object other = ItemTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        Item subject = ItemTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}