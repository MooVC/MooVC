namespace MooVC.Syntax.CSharp.Concepts.OptionsTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsOptionsIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Options();
        Options? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var subject = new Options();
        var other = new Options();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var subject = new Options();
        Options other = new Options().WithNamespace(Qualifier.Options.Block);

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}