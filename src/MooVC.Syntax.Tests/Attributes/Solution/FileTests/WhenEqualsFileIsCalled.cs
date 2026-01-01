namespace MooVC.Syntax.Attributes.Solution.FileTests;

using MooVC.Syntax;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsFileIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        File subject = FileTestsData.Create();

        // Act
        bool result = subject.Equals(default);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        File subject = FileTestsData.Create();
        File other = FileTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        File subject = FileTestsData.Create();
        File other = FileTestsData.Create(path: Snippet.From("other.cs"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}