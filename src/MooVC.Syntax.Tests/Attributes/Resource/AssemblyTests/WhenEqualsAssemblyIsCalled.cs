namespace MooVC.Syntax.Attributes.Resource.AssemblyTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsAssemblyIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Assembly subject = AssemblyTestsData.Create();
        Assembly? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Assembly subject = AssemblyTestsData.Create();
        Assembly other = AssemblyTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Assembly subject = AssemblyTestsData.Create();
        Assembly other = AssemblyTestsData.Create(name: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}