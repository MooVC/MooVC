namespace MooVC.Syntax.Project.TargetTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        Target subject = TargetTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Target subject = TargetTestsData.Create();
        object other = TargetTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}