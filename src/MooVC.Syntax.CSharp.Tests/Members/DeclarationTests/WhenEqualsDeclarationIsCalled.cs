namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

public sealed class WhenEqualsDeclarationIsCalled
{
    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Declaration subject = DeclarationTestsData.Create();
        Declaration? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Declaration subject = DeclarationTestsData.Create();
        Declaration other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create();
        Declaration right = DeclarationTestsData.Create();

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create();
        Declaration right = DeclarationTestsData.Create("Different");

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}