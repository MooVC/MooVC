namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsItemIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Item subject = ItemTestsData.Create();
        Item? other = default;

        // Act
        bool result = subject.Equals(other);

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
        Item other = ItemTestsData.Create(include: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}