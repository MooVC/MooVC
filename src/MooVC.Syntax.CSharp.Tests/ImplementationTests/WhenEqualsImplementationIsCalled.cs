namespace MooVC.Syntax.CSharp.ImplementationTests;

public sealed class WhenEqualsImplementationIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Implementation subject = ImplementationTestsData.Create(name: (Qualification)"IComparable");
        Implementation other = ImplementationTestsData.Create(name: (Qualification)"IDisposable");

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}