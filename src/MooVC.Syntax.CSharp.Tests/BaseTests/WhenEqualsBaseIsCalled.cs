namespace MooVC.Syntax.CSharp.BaseTests;

public sealed class WhenEqualsBaseIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Base subject = BaseTestsData.Create(name: (Qualification)"Comparable");
        Base other = BaseTestsData.Create(name: (Qualification)"IComparable");

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}