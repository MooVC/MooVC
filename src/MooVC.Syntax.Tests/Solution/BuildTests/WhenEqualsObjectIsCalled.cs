namespace MooVC.Syntax.Solution.BuildTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Build subject = BuildTestsData.Create();
        object other = BuildTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}