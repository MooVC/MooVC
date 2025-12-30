namespace MooVC.Syntax.CSharp.Attributes.Solution.ItemTests;

using MooVC.Syntax.CSharp;

public sealed class WhenEqualsItemIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Item subject = ItemTestsData.Create();

        // Act
        bool result = subject.Equals(default);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Item subject = ItemTestsData.Create();
        Item other = ItemTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Item subject = ItemTestsData.Create();
        Item other = ItemTestsData.Create(path: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}