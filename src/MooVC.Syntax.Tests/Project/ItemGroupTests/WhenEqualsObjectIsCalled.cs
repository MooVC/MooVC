namespace MooVC.Syntax.Project.ItemGroupTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();
        object other = ItemGroupTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}