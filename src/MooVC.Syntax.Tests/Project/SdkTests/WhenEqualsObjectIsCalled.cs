namespace MooVC.Syntax.Project.SdkTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create();
        object other = SdkTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}