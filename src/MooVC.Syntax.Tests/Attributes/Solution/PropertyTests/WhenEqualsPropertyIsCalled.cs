namespace MooVC.Syntax.Attributes.Solution.PropertyTests;

using MooVC.Syntax;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsPropertyIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();

        // Act
        bool result = subject.Equals(default);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        Property other = PropertyTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        Property other = PropertyTestsData.Create(name: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}