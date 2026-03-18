namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsItemIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
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