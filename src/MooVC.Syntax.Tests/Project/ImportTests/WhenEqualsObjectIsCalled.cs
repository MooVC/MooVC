namespace MooVC.Syntax.Project.ImportTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        Import subject = ImportTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Import subject = ImportTestsData.Create();
        object other = ImportTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}