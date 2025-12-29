namespace MooVC.Syntax.CSharp.Attributes.Project.ItemGroupTests;

public sealed class WhenEqualsItemGroupIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();
        ItemGroup? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();
        ItemGroup other = ItemGroupTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();
        ItemGroup other = ItemGroupTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}